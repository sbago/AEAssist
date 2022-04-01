using System.Collections.Generic;
using ff14bot.Enums;

namespace AETriggers.TriggerModel
{
    public class TriggerLine
    {
        public string Version;
        public string Author;
        public int TargetDuty;
        public ClassJobType TargetJob;
        public List<Trigger> Triggers = new List<Trigger>();
    }
}