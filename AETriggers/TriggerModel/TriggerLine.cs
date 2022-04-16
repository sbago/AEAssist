﻿using System.Collections.Generic;

namespace AETriggers.TriggerModel
{
    public class TriggerLine
    {        
        public string TargetDuty;
        public string TargetJob;
        public List<Trigger> Triggers = new List<Trigger>();
        public string Version;
        public string Author;

        public int ConfigVersion;

        public static int CurrConfigVersion = 1;
    }
}