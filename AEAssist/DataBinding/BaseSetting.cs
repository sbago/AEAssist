using System.Windows.Input;
using AEAssist.AI;
using AETriggers.TriggerModel;
using Buddy.Overlay;
using Clio.Utilities.Collections;
using ff14bot.Managers;
using PropertyChanged;

namespace AEAssist.DataBinding
{
    [AddINotifyPropertyChangedInterface]
    public class BaseSettings
    {
        private static BaseSettings _instance;
        public static BaseSettings Instance => _instance ?? (_instance = new BaseSettings());

        public void Reset()
        {
            this.CloseBuff = false;
            this.Stop = false;
            this.UseApex = true;
            this.UseDot = true;
            this.AutoAttack = false;
            this.UseHarpe = false;
        }

        public bool CloseBuff{ get; set; }

        public bool Stop { get; set; }
        
        public bool AutoAttack { get; set; } = false;


        #region Bard

        public bool UseDot { get; set; } = true;

        public bool UseApex { get; set; } = true;
        

        #endregion

        #region Reaper

        public bool UseHarpe { get; set; } = false;

        #endregion





        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings  => SettingMgr.GetSetting<BardSettings>();
        public ReaperSettings ReaperSettings  => SettingMgr.GetSetting<ReaperSettings>();
        
        public DebugCenter DebugCenter =>DebugCenter.Intance;
        
        public HotkeySetting HotkeySetting =>SettingMgr.GetSetting<HotkeySetting>();
        public TriggerLine CurrTriggerLine { get; set; }
    }
}