using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using AEAssist.Define;
using UserControl = System.Windows.Controls.UserControl;

namespace AEAssist.View
{
    public partial class GeneralSettingView : UserControl
    {
        private readonly List<HotkeyData> HotkeyDatas;


        public GeneralSettingView()
        {
            InitializeComponent();

            HotkeyDatas = GetHotkeyData();

            Hotkey_Stop.ItemsSource = HotkeyDatas;
            Hotkey_CloseBuff.ItemsSource = HotkeyDatas;
            Hotkey_Stop.SelectedValue = Enum.Parse(typeof(Keys), SettingMgr.GetSetting<HotkeySetting>().StopKey);
            Hotkey_CloseBuff.SelectedValue =
                Enum.Parse(typeof(Keys), SettingMgr.GetSetting<HotkeySetting>().CloseBuffKey);

            SwitchLan.ItemsSource = LanguageHelper.LanOptions;
            SwitchLan.SelectedValue = AEAssist.Language.Instance.LanType;

        }

        private List<HotkeyData> GetHotkeyData()
        {
            var HotkeyDatas = new List<HotkeyData>();
            var array = Enum.GetValues(typeof(Keys));
            foreach (var v in array)
            {
                var key = (Keys) v;
                if (key == Keys.None)
                    continue;
                HotkeyDatas.Add(new HotkeyData
                {
                    Key = key,
                    Name = key.ToString()
                });
            }

            return HotkeyDatas;
        }

        private void ShowOverlay_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.SwitchOverlay();
        }

        private void Hotkey_Stop_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<HotkeySetting>().StopKey = Hotkey_Stop.SelectedValue.ToString();
            SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
            SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
        }

        private void Hotkey_CloseBuff_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<HotkeySetting>().CloseBuffKey = Hotkey_CloseBuff.SelectedValue.ToString();
            SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
            SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
        }

        private void SwitchLan_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageHelper.SwitchLan((string)SwitchLan.SelectedValue);
        }
    }
}