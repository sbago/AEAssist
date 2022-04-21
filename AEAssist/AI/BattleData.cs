using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Gamelog;
using AEAssist.Helper;
using AEAssist.TriggerSystem;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BattleData : IBattleData
    {
        #region BaseSpellControl
        public SpellData lastAbilitySpell;

        public long lastCastTime;

        public int lastGCDIndex;
        public SpellData lastGCDSpell;
        public int maxAbilityTimes;
        public bool LimitAbility;

        public HashSet<uint> LockSpellId = new HashSet<uint>();
        
        
        public void ResetMaxAbilityTimes()
        {
            maxAbilityTimes = SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD;

            if (LimitAbility)
            {
                LogHelper.Info( "limit maxAbilityTimes => 1");
                maxAbilityTimes = 1;
                LimitAbility = false;
            }
        }

        #endregion

        #region NextSpell

        private uint _NextAbilitySpellId;
        public uint NextAbilitySpellId
        {
            get => _NextAbilitySpellId;
            set
            {
                _NextAbilitySpellId = value;
                if (_NextAbilitySpellId != 0)
                {
                    AbilityRetryEndTime = TimeHelper.Now() + 6000;
                }

                LogHelper.Info("NextAbility: " + NextAbilitySpellId);
            }
        }
        public bool NextAbilityUsePotion;

        private uint _NextGcdSpellId;
        public uint NextGcdSpellId
        {
            get => _NextGcdSpellId;
            set
            {
                _NextGcdSpellId = value;
                if (_NextGcdSpellId != 0)
                {
                    GCDRetryEndTime = TimeHelper.Now() + 6000;
                }
            }
        }

        public long GCDRetryEndTime;
        public long AbilityRetryEndTime;

        #endregion

        #region TriggerLine

        private readonly Dictionary<string, long> ExecutedTriggers = new Dictionary<string, long>();


        private void CalTriggerLine()
        {
            var CurrTriggerLine = DataBinding.Instance.CurrTriggerLine;
            if (CurrTriggerLine == null)
                return;
            if (ExecutedTriggers.Count == CurrTriggerLine.Triggers.Count)
                return;
            foreach (var v in CurrTriggerLine.Triggers)
            {
                if (ExecutedTriggers.ContainsKey(v.Id))
                    continue;
                if (TriggerSystemMgr.Instance.HandleTriggers(v)) ExecutedTriggers.Add(v.Id, TimeHelper.Now());
            }
        }

        public long GetExecutedTriggersTime(string id)
        {
            ExecutedTriggers.TryGetValue(id, out var time);
            return time;
        }
        #endregion

        public BattleData()
        {
            ResetMaxAbilityTimes();
        }

        public long BattleStartTime { get; set; }
        public long CurrBattleTime { get; private set; }
        public int OpenerIndex;

        public void Update(long currTime)
        {
            CurrBattleTime = currTime - BattleStartTime;
            // var enemys = TargetMgr.Instance.EnemysIn25;
            // foreach (var v in enemys.Values)
            // {
            //     if (v.SpellCastInfo == null || !v.IsCasting)
            //         continue;
            //     LogHelper.Info($"Character {v.Name} Casting===>{v.SpellCastInfo.SpellData.LocalizedName}");
            // }

            // foreach (var v in Core.Me.CharacterAuras.AuraList)
            // {
            //     LogHelper.Info($"{v.LocalizedName} Id: {v.Id}  TimeLeft: {v.TimeLeft}");
            // }

            CalTriggerLine();
            AEGamelogManager.Instance.CheckLog();
        }

    }
}