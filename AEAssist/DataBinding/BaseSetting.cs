using System.Windows.Input;
using AEAssist.AI;
using Buddy.Overlay;
using Clio.Utilities.Collections;
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

        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings  => SettingMgr.GetSetting<BardSettings>();
        
        public DebugCenter DebugCenter =>DebugCenter.Intance;
    }
}