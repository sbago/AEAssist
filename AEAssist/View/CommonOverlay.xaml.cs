using System.Windows;
using System.Windows.Controls;

namespace AEAssist.View
{
    public partial class CommonOverlay : UserControl
    {
        public CommonOverlay()
        {
            InitializeComponent();
        }

        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            DataBinding.Instance.Reset();
        }

        private void ChangeTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            Entry.TriggerLineWindow.OnTriggerLineLoad =
                s =>
                    CurrTriggerLine.Content = s;

            Entry.TriggerLineWindow.OnTriggerLineClear = () =>
                CurrTriggerLine.Content = "NULL";

            Entry.TriggerLineWindow.Show();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.Close();
        }
    }
}