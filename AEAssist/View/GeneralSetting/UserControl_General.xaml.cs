using System.Windows;
using System.Windows.Controls;
using QuickGraph;

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
        
        private void UseCombatMessageOverlay_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataBinding.Instance.GeneralSettings.UseCombatMessageOverlay)
            {
                OverlayManager.OverlayManager.Instance.StartCombatMessageOverlay();
                return;
            }
            OverlayManager.OverlayManager.Instance.StopCombatMessageOverlay();
        }
    }
}