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

        public GeneralSettings GeneralSettings { get; set; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings  => SettingMgr.GetSetting<BardSettings>();
    }
}