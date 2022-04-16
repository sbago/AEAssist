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
        private readonly Dictionary<long, List<TaskCompletionSource<bool>>> AllBattleTimeTcs =
            new Dictionary<long, List<TaskCompletionSource<bool>>>();

        public long battleStartTime;

        private readonly Dictionary<string, long> ExecutedTriggers = new Dictionary<string, long>();
        public SpellData lastAbilitySpell;

        public long lastCastTime;

        public int lastGCDIndex;
        public SpellData lastGCDSpell;
        public int maxAbilityTimes;

        public bool LimitAbility;

        public int NearbyEnemyCount_Range12_12;
        public int NearbyEnemyCount_Range25_5;
        public int NearbyEnemyCount_Range25_8;

        public int NearbyEnemyCount_Range5_5;
        public int NearbyEnemyCount_Range8_8;

        public uint NextAbilitySpellId;
        public bool NextAbilityUsePotion;
        public uint NextGCDSpellId;

        private readonly HashSet<long> TempKeys = new HashSet<long>();

        public BattleData()
        {
            ResetMaxAbilityTimes();
        }

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

        public long BattleTime { get; private set; }

        public void Update(long currTime)
        {
            CalBattleTime(currTime);
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

            // CalRangeEnemy();
        }

        private void CalRangeEnemy()
        {
            var target = Core.Me.CurrentTarget;
            NearbyEnemyCount_Range12_12 = TargetHelper.GetNearbyEnemyCount(target, 12, 12);
            NearbyEnemyCount_Range25_8 = TargetHelper.GetNearbyEnemyCount(target, 25, 8);
            NearbyEnemyCount_Range25_5 = TargetHelper.GetNearbyEnemyCount(target, 25, 5);
            NearbyEnemyCount_Range5_5 = TargetHelper.GetNearbyEnemyCount(target, 5, 5);
            NearbyEnemyCount_Range8_8 = TargetHelper.GetNearbyEnemyCount(target, 8, 8);
        }

        private void CalBattleTime(long currTime)
        {
            BattleTime = currTime - battleStartTime;
            if (BattleTime == 0) return;

            if (AllBattleTimeTcs.Count == 0)
                return;

            TempKeys.Clear();
            foreach (var v in AllBattleTimeTcs)
            {
                if (v.Key > BattleTime)
                    continue;
                TempKeys.Add(v.Key);
            }

            foreach (var v in TempKeys)
            {
                foreach (var tcsList in AllBattleTimeTcs[v]) tcsList.SetResult(true);

                AllBattleTimeTcs.Remove(v);
            }
        }

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

        public void AddTcs(long time, TaskCompletionSource<bool> tcs)
        {
            if (!AllBattleTimeTcs.TryGetValue(time, out var list))
            {
                list = new List<TaskCompletionSource<bool>>();
                AllBattleTimeTcs[time] = list;
            }

            list.Add(tcs);
        }
    }
}