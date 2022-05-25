using AEAssist.AI.Bard;
using AEAssist.Define;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class BardSettings : IBaseSetting
    {
        public BardSettings()
        {
            Reset();
        }

        public double RestHealthPercent { get; set; }
        public int ApexArrowValue { get; set; } 

        public SongStrategyEnum CurrentSongPlaylist { get; set; }

        public int Songs_WM_TimeLeftForSwitch { get; set; }
        public int Songs_MB_TimeLeftForSwitch { get; set; }
        public int Songs_AP_TimeLeftForSwitch { get; set; }

        public bool UsePeloton { get; set; }

        public bool BuffsDelay2GCD { get; set; } 

        public int TTK_IronJaws { get; set; } 

        public int Dot_TimeLeft { get; set; } = 2500;

        public bool EarlyEmpyrealArrow { get; set; } = true;

        public bool EarlyDecisionMode { get; set; }

        public bool ApexWaitBuffs { get; set; }

        public void Reset()
        {
            CurrentSongPlaylist = SongStrategyEnum.WM_MB_AP;
            RestHealthPercent = 70f;
            ApexArrowValue = 100;
            Songs_WM_TimeLeftForSwitch = 2000;
            Songs_MB_TimeLeftForSwitch = 11000;
            Songs_AP_TimeLeftForSwitch = 2000;
            UsePeloton = false;
            BuffsDelay2GCD = false;
            TTK_IronJaws = 28;
            EarlyDecisionMode = true;
            Dot_TimeLeft = 2500;
            EarlyEmpyrealArrow = true;
            ApexWaitBuffs = false;
        }

        public void OnLoad()
        {
            
        }
    }
}