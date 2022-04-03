using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.DataBinding;
using AEAssist.TriggerSystem;
using AETriggers.TriggerModel;
using ff14bot.Objects;

namespace AEAssist.AI
{
    public class BattleData
    {

        public BattleData()
        {
            maxAbilityTimes = SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimsInGCD;
        }

        public long lastCastTime;
        public SpellData lastGCDSpell;
        public SpellData lastAbilitySpell;
        public int maxAbilityTimes ;
        
        public long battleStartTime;
        public long BattleTime { get; private set; }

        private HashSet<string> ExecutedTriggers = new HashSet<string>();


        private Dictionary<long, List<TaskCompletionSource<bool>>> AllBattleTimeTcs =
            new Dictionary<long, List<TaskCompletionSource<bool>>>();

        private HashSet<long> TempKeys = new HashSet<long>();

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

            CalTriggerLine();
        }

        void CalBattleTime(long currTime)
        {
            BattleTime = currTime - battleStartTime;
            if (BattleTime == 0)
            {
                return;
            }
            if (AllBattleTimeTcs.Count == 0)
                return;

            TempKeys.Clear();
            foreach (var v in AllBattleTimeTcs)
            {
                if(v.Key>BattleTime)
                    continue;
                TempKeys.Add(v.Key);
            }

            foreach (var v in TempKeys)
            {
                foreach (var tcsList in AllBattleTimeTcs[v])
                {
                    tcsList.SetResult(true);
                }

                AllBattleTimeTcs.Remove(v);
            }
        }

        void CalTriggerLine()
        {
            var CurrTriggerLine = BaseSettings.Instance.CurrTriggerLine;
            if (CurrTriggerLine == null)
                return;
            if (ExecutedTriggers.Count == CurrTriggerLine.Triggers.Count)
                return;
            foreach (var v in CurrTriggerLine.Triggers)
            {
                if(ExecutedTriggers.Contains(v.Id))
                    continue;
                if (TriggerSystemMgr.Instance.HandleTriggers(v))
                {
                    this.ExecutedTriggers.Add(v.Id);
                }
            }
        }

        public void AddTcs(long time, TaskCompletionSource<bool> tcs)
        {
            if (!AllBattleTimeTcs.TryGetValue(time, out var list))
            {
                list = new List<TaskCompletionSource<bool>>();
                this.AllBattleTimeTcs[time] = list;
            }

            list.Add(tcs);
        }
    }
}