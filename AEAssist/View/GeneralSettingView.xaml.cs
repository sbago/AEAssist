using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AEAssist.Helper;

namespace AEAssist.View
{
    public partial class GeneralSettingView : UserControl
    {
        private ObservableCollection<DotBlackList_Data> Ob_DotBlackList = new ObservableCollection<DotBlackList_Data>();

        public GeneralSettingView()
        {
            InitializeComponent();


            SwitchLan.ItemsSource = LanguageHelper.LanOptions;
            SwitchLan.SelectedValue = AEAssist.Language.Instance.LanType;


            Dex_ChoosePotion.ItemsSource = PotionHelper.DexPotions;
            Dex_ChoosePotion.SelectedValue = SettingMgr.GetSetting<GeneralSettings>().DexPotionId;

            Str_ChoosePotion.ItemsSource = PotionHelper.StrPotions;
            Str_ChoosePotion.SelectedValue = SettingMgr.GetSetting<GeneralSettings>().StrPotionId;

            RefreshDotBlackList();

            var dir = Directory.CreateDirectory(TriggerLineSwitchHelper.Path);

            Path.Content = dir.FullName;
        }

        private void ShowOverlay_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.SwitchOverlay();
        }

        private void SwitchLan_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageHelper.SwitchLan((string) SwitchLan.SelectedValue);
        }

        private void Dex_ChoosePotion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<GeneralSettings>().DexPotionId = (int) Dex_ChoosePotion.SelectedValue;
        }

        private void Str_ChoosePotion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<GeneralSettings>().StrPotionId = (int) Str_ChoosePotion.SelectedValue;
        }

        private void DotBlackList_Add_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(DotBlackList_Input.Text))
                return;
            if (SettingMgr.GetSetting<GeneralSettings>().DotBlacklist.Add(DotBlackList_Input.Text))
                RefreshDotBlackList();
        }

        private void DotBlackList_Remove_OnClick(object sender, RoutedEventArgs e)
        {
            var currSelect = DotBlackList.SelectedItem as ListBoxItem;

            if (currSelect == null)
                return;
            if (SettingMgr.GetSetting<GeneralSettings>().DotBlacklist.Remove(currSelect.Content.ToString()))
                RefreshDotBlackList();
        }

        private void RefreshDotBlackList()
        {
            DotBlackList.SelectedItem = null;
            DotBlackList.Items.Clear();


            foreach (var v in SettingMgr.GetSetting<GeneralSettings>().DotBlacklist)
                DotBlackList.Items.Add(new ListBoxItem
                {
                    Content = v,
                    Foreground = Brushes.Aqua,
                    Height = 25,
                    Width = 100,
                    FontSize = 10,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                });
        }

        private void RefreshHotkey_OnClick(object sender, RoutedEventArgs e)
        {
            SettingMgr.GetSetting<HotkeySetting>().RegisHotkey();
            SettingMgr.GetSetting<HotkeySetting>().ResetHotkeyName();
        }

        private void LoadTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            TriggerLineSwitchHelper.LoadAll();
        }

        private class DotBlackList_Data
        {
            public string Name { get; set; }
        }
    }
}