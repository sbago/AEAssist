using System.Windows;
using System.Windows.Controls;

namespace AEAssist.View
{
    public partial class OverlayHeader : UserControl
    {
        public OverlayHeader()
        {
            InitializeComponent();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.Close();
        }
    }
}