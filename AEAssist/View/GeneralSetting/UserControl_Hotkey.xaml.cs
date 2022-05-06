using System.Windows;
using System.Windows.Controls;

namespace AEAssist.View.GeneralSetting
{
    public partial class UserControl_Hotkey : UserControl
    {
        public UserControl_Hotkey()
        {
            InitializeComponent();
        }
        
        private void RefreshHotkey_OnClick(object sender, RoutedEventArgs e)
        {
            SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
            SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
        }
    }
}