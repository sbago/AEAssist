using AEAssist.AI;
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
        public int ApexArrowValue { get; set; } // 绝峰 多少能量就用

        public SongStrategyEnum CurrentSongPlaylist { get; set; }

        public int Songs_WM_TimeLeftForSwitch { get; set; }
        public int Songs_MB_TimeLeftForSwitch { get; set; }
        public int Songs_AP_TimeLeftForSwitch { get; set; }

        public bool UsePeloton { get; set; }

        public bool BuffsDelay2GCD { get; set; } // 起手双团辅延后两个GCD 还是1个

        public int TTK_IronJaws { get; set; } // 不刷伶牙

        public int Dot_TimeLeft { get; set; } = ConstValue.AuraTick;

        public bool EarlyDecisionMode { get; set; }

        public void Reset()
        {
            CurrentSongPlaylist = SongStrategyEnum.WM_MB_AP;
            RestHealthPercent = 70f;
            ApexArrowValue = 95;
            Songs_WM_TimeLeftForSwitch = 2000;
            Songs_MB_TimeLeftForSwitch = 11000;
            Songs_AP_TimeLeftForSwitch = 2000;
            UsePeloton = false;
            BuffsDelay2GCD = false;
            TTK_IronJaws = 28;
            EarlyDecisionMode = true;
            Dot_TimeLeft = ConstValue.AuraTick;
        }
    }
}