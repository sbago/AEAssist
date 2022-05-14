﻿using AEAssist.Define;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class SageSettings : IBaseSetting
    {
        public SageSettings()
        {
            Reset();
        }
        
        public int Dot_TimeLeft { get; set; } = ConstValue.AuraTick;
        public int TTK_EukrasianDosis { get; set; }

        public int LucidDreamingTrigger { get; set; } = ConstValue.LucidDreamingDefaultRefresh;
        public bool LucidDreamingToggle { get; set; } = true;
        
        public bool EarlyDecisionMode { get; set; }

        public string SageOpener { get; set; } = "Default";

        public void Reset()
        {
            EarlyDecisionMode = true;
            Dot_TimeLeft = ConstValue.AuraTick;
            TTK_EukrasianDosis = 30;
            SageOpener = "Default";
        }
    }
}