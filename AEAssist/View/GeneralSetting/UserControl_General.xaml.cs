using System.Windows;
using System.Windows.Controls;

namespace AEAssist.View.GeneralSetting
{
    public partial class UserControl_General : UserControl
    {
        public UserControl_General()
        {
            InitializeComponent();
        }

        private void ShowOverlay_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.SwitchOverlay();
        }
    }
}