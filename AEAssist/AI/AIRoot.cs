using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class AIRoot
    {
        public static readonly AIRoot Instance = new AIRoot();
        
        private long _lastCastTime;
        private SpellData _lastGCDSpell;
        private SpellData _lastAbilitySpell;
        private int _maxAbilityTimes ;
        
        public bool lastIronJawWithBuff;
        public long lastCastRagingStrikesTime;

        private Dictionary<string, long> lastNoticeTime = new Dictionary<string, long>();

        public long lastCastSongTime;

        private bool _stop;
        public bool Stop
        {
            get
            {
                return _stop;
            }
            set
            {
                _stop = value;
                if (value)
                {
                    Core.Me.ClearTarget();
                }
            }
        }

        public bool CloseBuff { get; set; }

        public AIRoot()
        {
            _lastCastTime = TimeHelper.Now();
            _maxAbilityTimes = SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD;
        }

        public void Clear()
        {
            _lastGCDSpell = null;
            _lastAbilitySpell = null;
            _maxAbilityTimes = SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD;
            lastCastRagingStrikesTime = 0;
            lastIronJawWithBuff = false;
            lastCastSongTime = 0;

            if (CanNotice("Clear", 2000))
                LogHelper.Debug("Clear battle data");
        }

        public async Task<bool> Update()
        {
            // 逻辑清单: 
            // 1. 检测当前是否可以使用GCD技能

            if (Stop)
            {
                GUIHelper.ShowInfo("停手中");
                return false;
            }

            if (ff14bot.Core.Me.IsCasting)
                return false;



            if (!ff14bot.Core.Me.HasTarget || !ff14bot.Core.Me.CurrentTarget.CanAttack)
            {
                if (CanNotice("key1", 1000))
                    GUIHelper.ShowInfo("未选择目标/目标不可被攻击");
                return false;
            }

            if (!((Character) ff14bot.Core.Me.CurrentTarget).HasTarget && !CountDownHandler.Instance.CanDoAction)
            {
                if (CanNotice("key2", 1000))
                    GUIHelper.ShowInfo("目标可被攻击,准备战斗");
                return false;
            }

            var timeNow = TimeHelper.Now();

            bool canUseGCD = true;
            bool canUseAbility = true;
            var delta = timeNow - _lastCastTime;
            var coolDown = GetGCDDuration();
            if (_lastGCDSpell != null)
            {
                var coolDownForQueue = coolDown - SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
                if (delta < coolDownForQueue)
                {
                    canUseGCD = false;
                }
            }

            var needDura = ConstValue.AnimationLockMs + SettingMgr.GetSetting<GeneralSettings>().UserLatencyOffset;
            if (_maxAbilityTimes > 0 && coolDown - delta > needDura)
            {
                canUseAbility = true;
            }
            else
            {
                canUseAbility = false;
            }

            if (canUseGCD)
            {
                //todo: check gcd
                var ret = await AIMgrs.Instance.HandleGCD(Core.Me.CurrentJob, _lastGCDSpell);
                if (ret != null)
                {
                    GUIHelper.ShowInfo("Cast GCD: " + ret.LocalizedName, 100);
                    if (_lastGCDSpell == null)
                        CountDownHandler.Instance.Close();
                    _lastGCDSpell = ret;
                    _lastCastTime = timeNow;
                    _maxAbilityTimes = SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD;
                    _lastAbilitySpell = null;
                }
            }

            if (canUseAbility)
            {
                //todo : check ability
                var ret = await AIMgrs.Instance.HandleAbility(Core.Me.CurrentJob, _lastAbilitySpell);
                if (ret != null)
                {
                    GUIHelper.ShowInfo("Cast Ability: " + ret.LocalizedName, 100);
                    _maxAbilityTimes--;
                    //LogHelper.Info($"剩余使用能力技能次数: {_maxAbilityTimes}");
                }
            }

            return false;
        }

        // 当前是否是GCD后半段
        public bool Is2ndAbilityTime()
        {
            if (_lastGCDSpell == null)
                return false;
            if (_maxAbilityTimes == 1)
                return true;
            if (SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD != 2)
                return true;
            var timeNow = TimeHelper.Now();
            var delta = timeNow - _lastCastTime;
            var coolDown = _lastGCDSpell.AdjustedCooldown.TotalMilliseconds;
            if (delta > coolDown / SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD)
                return true;
            return false;
        }

        public double GetGCDDuration()
        {
            if (_lastGCDSpell == null)
                return 2500;
            return _lastGCDSpell.AdjustedCooldown.TotalMilliseconds;
        }

        public void MuteAbilityTime()
        {
            _maxAbilityTimes = 0;
        }

        bool CanNotice(string key,long interval)
        {
            var now = TimeHelper.Now();
            if (lastNoticeTime.TryGetValue(key, out var lastTime))
            {
                if (lastTime + interval > now)
                    return false;
            }

            lastNoticeTime[key] = now;
            return true;
        }
    }
}