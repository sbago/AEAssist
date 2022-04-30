using System;
using System.Windows;
using AEAssist.AI;
using AEAssist.View;
using AETriggers.TriggerModel;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class DataBinding
    {
        private static DataBinding _instance;


        public static DataBinding Instance => _instance ?? (_instance = new DataBinding());

        public bool Burst
        {
            get;
            set;
            // var msg = !_closeBuff ? "Burst On" : "Burst Off";
            // GUIHelper.ShowToast(msg,2000);
        } = true;

        // 有什么资源用什么,使劲倾泻. 部分逻辑依赖
        public bool FinalBurst { get; set; }

        public bool Stop { get; set; }

        public bool AutoAttack { get; set; }

        public bool UseTrueNorth { get; set; }

        public bool UseAOE { get; set; } = true;
        
        public bool UseBattery { get; set; } = true;

        public string TimeStr { get; set; }
        
        public bool EarlyDecisionMode { get; set; }


        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings => SettingMgr.GetSetting<BardSettings>();
        public ReaperSettings ReaperSettings => SettingMgr.GetSetting<ReaperSettings>();
        
        public MCHSettings MCHSettings => SettingMgr.GetSetting<MCHSettings>();

        public SamuraiSettings SamuraiSettings => SettingMgr.GetSetting<SamuraiSettings>();

        public DebugCenter DebugCenter => DebugCenter.Intance;

        public HotkeySetting HotkeySetting => SettingMgr.GetSetting<HotkeySetting>();
        
        public Language Language =>Language.Instance;
        
        public TriggerLine CurrTriggerLine { get; set; }

        public void Reset()
        {
            Burst = true;
            Stop = false;
            UseApex = true;
            UseDot = true;
            AutoAttack = false;
            UseHarpe = false;
            UseSoulGauge = true;
            DoubleEnshroudPrefer = ReaperSettings.DoubleEnshroudPrefer;
            UseAOE = true;
            TimeStr = "";
            UseBattery = true;
            UseSong = true;
            FinalBurst = false;
            WildfireNoDelay = SettingMgr.GetSetting<MCHSettings>().WildfireFirst;
        }


        public void Update()
        {
            if (GeneralSettings.ShowBattleTime)
                TimeStr = $"{Language.Instance.Content_BattleTime}:  {AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs / 1000}";
            else
                TimeStr = $"{Language.Instance.Content_LocalTime}:  {DateTime.Now:hh:mm:ss}";
        }


        #region Bard

        public bool UseDot { get; set; } = true;

        public bool UseApex { get; set; } = true;

        public bool UseSong { get; set; } = true;

        #endregion

        #region Reaper

        public bool UseHarpe { get; set; }
        public bool UseSoulGauge { get; set; } = true;

        public bool DoubleEnshroudPrefer { get; set; } = true;

        #endregion

        #region MCH

        public bool WildfireNoDelay { get; set; }

        #endregion

        public bool OverlayVisibility { get; set; } = true;
    }
}