using System.Windows;
using System.Windows.Controls;
using AEAssist.Helper;

namespace AEAssist.View
{
    public partial class ReaperSettingView : UserControl
    {
        public ReaperSettingView()
        {
            InitializeComponent();
            ChoosePotion.ItemsSource = PotionHelper.StrPotions;
            ChoosePotion.SelectedValue = SettingMgr.GetSetting<ReaperSettings>().UsePotionId;
            ButtonBase_OnClick(null, null);
        }

        private void ChoosePotion_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<ReaperSettings>().UsePotionId = (int) ChoosePotion.SelectedValue;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var value = PotionHelper.CheckNum(SettingMgr.GetSetting<ReaperSettings>().UsePotionId);
            PotionCount.Content = value.ToString();
        }
    }
}