using System.Windows;
using System.Windows.Controls;
using AEAssist.View.Hotkey;
using AEAssist.View.Style;

namespace AEAssist.View.GeneralSetting
{
    public partial class UserControl_Hotkey : UserControl
    {
        public UserControl_Hotkey()
        {
            InitializeComponent();
            this.Hotkeys.ItemsSource = SettingMgr.GetSetting<HotkeySetting>().AllHotkeyDatas;

        }
        
        private void RefreshHotkey_OnClick(object sender, RoutedEventArgs e)
        {
            SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
            SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
        }
    }
}