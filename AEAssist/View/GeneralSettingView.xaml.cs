using System.Windows;
using System.Windows.Controls;
using AEAssist.Helper;

namespace AEAssist.View
{
    public partial class GeneralSettingView : UserControl
    {
        public GeneralSettingView()
        {
            InitializeComponent();
        }

        private void ShowOverlay_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.ShowOverlay();
        }
    }
}