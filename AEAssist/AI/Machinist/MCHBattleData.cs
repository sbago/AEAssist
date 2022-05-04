using System.Collections.Generic;

namespace AEAssist.AI.Machinist
{
    public enum MCHComboStages
    {
        SplitShot,
        SlugShot,
        CleanShot,
        SpreadShot
    }

    public class MCHBattleData : IBattleData
    {
        public MCHComboStages ComboStages;
        public int HyperchargeGCDCount = 0;

        public Queue<int> NextBatteryQueue = new Queue<int>();
        public int NextBattery2Use { get; set; } = 50;

        public void ResetBattery()
        {
            NextBattery2Use = 50;
        }

        public void ApplyNextBatteryQueue()
        {
            if (NextBatteryQueue.Count == 0)
            {
                ResetBattery();
                return;
            }

            NextBattery2Use = NextBatteryQueue.Dequeue();
        }
    }
}