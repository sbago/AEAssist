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
        
        
        
        public bool CloseBuff{ get; set; }

        public bool Stop { get; set; }

        public bool UseDot { get; set; } = true;

        public bool UseApex { get; set; } = true;
        
        public bool AutoAttack { get; set; } = false;


        #region NextSongs

        public ActionResourceManager.Bard.BardSong nextSong = ActionResourceManager.Bard.BardSong.None;

        #endregion
        

        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings  => SettingMgr.GetSetting<BardSettings>();
        
        public DebugCenter DebugCenter =>DebugCenter.Intance;
        
        public HotkeySetting HotkeySetting =>SettingMgr.GetSetting<HotkeySetting>();

        public TriggerLine TriggerLine;
    }
}