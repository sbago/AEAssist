using System.Collections.Generic;

namespace AEAssist.AI
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
        public int NextBattery2Use { get; set; } = 50;

        public void ResetBattery()
        {
            NextBattery2Use = 50;
        }

        public Queue<int> NextBatteryQueue = new Queue<int>();

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