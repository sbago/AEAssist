using System.Collections.Generic;

namespace AEAssist
{
    public class TriggerLine
    {
        public static int CurrConfigVersion = 3;
        public string Author;

        public int ConfigVersion;
        public ushort CurrZoneId;
        public string Name;
        public uint SubZoneId;
        public string TargetJob;
        public List<Trigger> Triggers = new List<Trigger>();
    }
}