using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AEAssist.Define;
using AEAssist.Helper;
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

        public void Reset()
        {
            this.CurrentSongPlaylist = SongStrategyEnum.WM_MB_AP;
            this.RestHealthPercent = 70f;
            this.ApexArrowValue = 95;
            this.Songs_WM_TimeLeftForSwitch = 2000;
            this.Songs_MB_TimeLeftForSwitch = 11000;
            this.Songs_AP_TimeLeftForSwitch = 2000;
            this.UsePeloton = false;
            this.BuffsDelay2GCD = false;
            this.TTK_IronJaws = 28;

            this.UsePotionId = 36105; // 5级巧力幻药
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

        public int UsePotionId { get; set; }
    }
}