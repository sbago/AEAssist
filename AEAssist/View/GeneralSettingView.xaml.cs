using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Helper;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using UserControl = System.Windows.Controls.UserControl;

namespace AEAssist.View
{
    public partial class GeneralSettingView : UserControl
    {
        private readonly List<HotkeyData> HotkeyDatas;

        class DotBlackList_Data
        {
            public string Name { get; set; }
        }
        
        private ObservableCollection<DotBlackList_Data> Ob_DotBlackList = new ObservableCollection<DotBlackList_Data>();

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

            
            Dex_ChoosePotion.ItemsSource = PotionHelper.DexPotions;
            Dex_ChoosePotion.SelectedValue = SettingMgr.GetSetting<GeneralSettings>().DexPotionId;
            
            Str_ChoosePotion.ItemsSource = PotionHelper.StrPotions;
            Str_ChoosePotion.SelectedValue = SettingMgr.GetSetting<GeneralSettings>().StrPotionId;

           
            
            RefreshDotBlackList();
            
            
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
            if (string.IsNullOrEmpty(this.DotBlackList_Input.Text))
                return;
            if (SettingMgr.GetSetting<GeneralSettings>().DotBlacklist.Add(this.DotBlackList_Input.Text))
            {
                RefreshDotBlackList();
            }
        }

        private void DotBlackList_Remove_OnClick(object sender, RoutedEventArgs e)
        {
            var currSelect = this.DotBlackList.SelectedItem as ListBoxItem;
      
            if (currSelect == null)
                return;
            LogHelper.Info(currSelect.GetType().ToString());
            LogHelper.Info(currSelect.Content.GetType().ToString());
            if (SettingMgr.GetSetting<GeneralSettings>().DotBlacklist.Remove(currSelect.Content.ToString()))
            {
                RefreshDotBlackList();
            }
        }

        void RefreshDotBlackList()
        {
            this.DotBlackList.SelectedItem = null;
            this.DotBlackList.Items.Clear();
          
            
            foreach (var v in SettingMgr.GetSetting<GeneralSettings>().DotBlacklist)
            {
                this.DotBlackList.Items.Add(new ListBoxItem()
                {
                    Content = v,
                    Foreground =  Brushes.Aqua,
                    Height = 25,
                    Width = 100,
                    FontSize = 10,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                });
            }
            
        }
    }
}