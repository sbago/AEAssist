using System.Collections.Generic;

namespace AETriggers.TriggerModel
{
    public class TriggerLine
    {        
        public ushort RawZoneId;
        public uint SubZoneId;
        public string TargetJob;
        public List<Trigger> Triggers = new List<Trigger>();
        public string Author;
        public string Name;

        public int ConfigVersion;

        public static int CurrConfigVersion = 3;
    }
}