using System.Windows;
using System.Windows.Controls;
using AEAssist.Helper;

namespace AEAssist.View
{
    public partial class BardSettingView : UserControl
    {
        public BardSettingView()
        {
            InitializeComponent();
            this.ChoosePotion.ItemsSource = PotionHelper.AllPotions;
            this.ChoosePotion.SelectedValue = SettingMgr.GetSetting<BardSettings>().UsePotionId;
            ButtonBase_OnClick(null,null);
        }

        private void ChoosePotion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<BardSettings>().UsePotionId = (int)ChoosePotion.SelectedValue;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var value = PotionHelper.CheckNum(SettingMgr.GetSetting<BardSettings>().UsePotionId);
            this.PotionCount.Content = "数量: " + value.ToString();
        }
    }
}