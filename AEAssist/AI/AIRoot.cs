using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Reaper;
using AEAssist.Define;
using AEAssist.Gamelog;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIRoot
    {
        public static readonly AIRoot Instance = new AIRoot();

        public void Init()
        {
            _allBattleDatas.Clear();
            var baseType = typeof(IBattleData);
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;
                if (!baseType.IsAssignableFrom(type))
                    continue;
                _allBattleDataTypes.Add(type);
                _allBattleDatas[type] = Activator.CreateInstance(type) as IBattleData;
                LogHelper.Debug("Load BattleData: " + type);
            }
        }

        public static T GetBattleData<T>() where T: class,IBattleData
        {
            Instance._allBattleDatas.TryGetValue(typeof(T), out var data);
            return data as T;
        }
        

        private bool ClearBattleData;


        private readonly Dictionary<string, long> lastNoticeTime = new Dictionary<string, long>();

        private readonly Dictionary<Type, IBattleData> _allBattleDatas = new Dictionary<Type, IBattleData>();

        private readonly HashSet<Type> _allBattleDataTypes = new HashSet<Type>();

        public bool Stop
        {
            get => DataBinding.Instance.Stop;
            set => DataBinding.Instance.Stop = value;
        }

        public bool BurstOff
        {
            get => DataBinding.Instance.BurstOff;
            set => DataBinding.Instance.BurstOff = value;
        }

        public void Clear()
        {
            if (ClearBattleData)
                return;
            ForceClear();
        }

        public void ForceClear()
        {
            CountDownHandler.Instance.Close();
            
            _allBattleDatas.Clear();
            foreach (var type in _allBattleDataTypes)
            {
                _allBattleDatas[type] = Activator.CreateInstance(type) as IBattleData;
            }
            
            DataBinding.Instance.Reset();

            SpellHistoryMgr.Instance.Clear();
            AEGamelogManager.Instance.ClearAll();

            ClearBattleData = true;
            LogHelper.Debug("Clear battle data");
        }

        public async Task<bool> Update()
        {
            // 逻辑清单: 
            // 1. 检测当前是否可以使用GCD技能
            var timeNow = TimeHelper.Now();
            if (!ClearBattleData)
            {
                GetBattleData<BattleData>().Update(timeNow);
                SpellHistoryMgr.Instance.CheckIfNeedClearHistory();
            }

            DataBinding.Instance.Update();

            if (Stop)
            {
                if (Core.Me.CurrentTarget != null)
                    Core.Me.ClearTarget();
                GUIHelper.ShowInfo(Language.Instance.Content_AIRoot_Stoping);
                return false;
            }

            if (!Core.Me.HasTarget || !Core.Me.CurrentTarget.CanAttack)
            {
                if (CanNotice("key1", 1000))
                    GUIHelper.ShowInfo(Language.Instance.Content_AIRoot_NoTarget);
                return false;
            }

            if (!((Character) Core.Me.CurrentTarget).HasTarget && !CountDownHandler.Instance.CanDoAction
                                                               && !DataBinding.Instance.AutoAttack)
            {
                if (CanNotice("key2", 1000))
                    GUIHelper.ShowInfo(Language.Instance.Content_AIRoot_CanAttack);
                return false;
            }
            var battleData = GetBattleData<BattleData>();
            if (Core.Me.InCombat)
            {
                if (ClearBattleData) battleData.battleStartTime = timeNow;

                ClearBattleData = false;
            }

            var canUseAbility = true;
            var delta = timeNow -battleData.lastCastTime;
            var coolDown = GetGCDDuration();

            var canUseGCD = CanUseGCD();

            if (!canUseGCD && battleData.maxAbilityTimes > 0 && coolDown - delta >= coolDown * 0.33f)
                canUseAbility = true;
            else
                // LogHelper.Debug(
                //     $"NoAbility==> Need:{needDura} Times:{battleData.maxAbilityTimes} Delta: {coolDown - delta}");
                canUseAbility = false;

            if (canUseGCD)
            {
                SpellData ret = null;
                if (battleData.NextGCDSpellId != 0)
                {
                    ret = DataManager.GetSpellData(battleData.NextGCDSpellId);
                    if (ret != null && ret.IsUnlock())
                    {
                        if (SpellHelper.CanCastGCD(ret, Core.Me.CurrentTarget))
                        {
                            if (!await SpellHelper.CastGCD(ret, Core.Me.CurrentTarget))
                                ret = null;
                            else
                                battleData.NextGCDSpellId = 0;
                        }
                    }
                    else
                    {
                        ret = null;
                        battleData.NextGCDSpellId = 0;
                    }
                }

                if (ret == null)
                    ret = await AIMgrs.Instance.HandleGCD(Core.Me.CurrentJob, battleData.lastGCDSpell);
                if (ret != null)
                {
                    var msg = $"{battleData.BattleTime/1000} Cast GCD: {ret.Id} " + ret.LocalizedName;
                    LogHelper.Info(msg);
                    GUIHelper.ShowInfo(msg, 100);
                    var history = new SpellHistory
                    {
                        SpellId = ret.Id,
                        CastTime = timeNow,
                        Name = ret.LocalizedName
                    };
                    SpellHistoryMgr.Instance.AddGCDHistory(history);
                    
                    
                    if (battleData.lastGCDSpell == null)
                        CountDownHandler.Instance.Close();
                    battleData.lastGCDIndex++;
                    battleData.lastGCDSpell = ret;
                    battleData.lastCastTime = timeNow;
                    battleData.ResetMaxAbilityTimes();
                    battleData.lastAbilitySpell = null;
                }
            }

            if (canUseAbility)
            {
                SpellData ret = null;

                if (battleData.maxAbilityTimes == SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD &&
                    battleData.NextAbilityUsePotion)
                {
                    battleData.NextAbilitySpellId = 0;
                    var msg = "===>Try using Potion";
                    LogHelper.Info(msg);
                    var boolRet = await AIMgrs.Instance.UsePotion(Core.Me.CurrentJob);
                    if (boolRet)
                    {
                        battleData.NextAbilityUsePotion = false;
                        return false;
                    }
                }
                else if (battleData.NextAbilitySpellId != 0)
                {
                    ret = DataManager.GetSpellData(battleData.NextAbilitySpellId);
                    if (ret != null && ret.IsUnlock())
                    {
                        if (ActionManager.CanCast(ret, Core.Me.CurrentTarget))
                        {
                            if (!await SpellHelper.CastAbility(ret, Core.Me.CurrentTarget))
                                ret = null;
                            else
                                battleData.NextAbilitySpellId = 0;
                        }
                    }
                    else
                    {
                        ret = null;
                        battleData.NextAbilitySpellId = 0;
                    }
                }

                if (ret == null)
                    ret = await AIMgrs.Instance.HandleAbility(Core.Me.CurrentJob, battleData.lastAbilitySpell);
                if (ret != null)
                {
                    var msg = $"{battleData.BattleTime/1000} Cast Ability: {ret.Id} " + ret.LocalizedName;
                    LogHelper.Info(msg);
                    GUIHelper.ShowInfo(msg, 100);
                    var history = new SpellHistory
                    {
                        SpellId = ret.Id,
                        CastTime = timeNow,
                        Name = ret.LocalizedName,
                        GCDIndex = battleData.lastGCDIndex
                    };
                    SpellHistoryMgr.Instance.AddAbilityHistory(history);
                    battleData.maxAbilityTimes--;
                    //LogHelper.Info($"剩余使用能力技能次数: {_maxAbilityTimes}");
                }
            }

            return false;
        }

        // 当前是否是GCD后半段
        public bool Is2ndAbilityTime()
        {
            if (SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD < 2)
                return true;
            if (GetBattleData<BattleData>().maxAbilityTimes < SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD)
            {
                return true;
            }
            
            var delta = TimeHelper.Now() - GetBattleData<BattleData>().lastCastTime;
            var coolDown = GetGCDDuration();

            if (coolDown - delta < coolDown * 0.5f)
                return true;
            return false;
        }

        public double GetGCDDuration()
        {
            var spell = RotationManager.Instance.GetBaseGCDSpell();
            return spell.AdjustedCooldown.TotalMilliseconds;
        }

        // gcd技能处于没有冷却完毕状态 (考虑了队列时间,实际上是是否可以发出指令使用GCD技能了)
        public bool CanUseGCD()
        {
            var ret = RotationManager.Instance.GetBaseGCDSpell();
            return ret.Cooldown.TotalMilliseconds < SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
        }

        public void MuteAbilityTime()
        {
            GetBattleData<BattleData>().maxAbilityTimes = 0;
        }


        private bool CanNotice(string key, long interval)
        {
            var now = TimeHelper.Now();
            if (lastNoticeTime.TryGetValue(key, out var lastTime))
                if (lastTime + interval > now)
                    return false;

            lastNoticeTime[key] = now;
            return true;
        }
    }
}