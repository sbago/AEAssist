using System.Windows;
using System.Windows.Controls;
using AEAssist;

namespace AEAssist.View.Overlay
{
    public partial class ReaperOverlay : UserControl
    {
        public ReaperOverlay()
        {
            InitializeComponent();
        }

        private void Reset_OnClick(object sender, RoutedEventArgs e)
        {
            AEAssist.DataBinding.Instance.Reset();
        }

        private void ChangeTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            Entry.TriggerLineWindow.OnTriggerLineLoad = 
                s =>
                    this.CurrTriggerLine.Content = $"当前加载时间轴: {s}";
            
            Entry.TriggerLineWindow.OnTriggerLineClear=()=>
                this.CurrTriggerLine.Content="当前加载时间轴: 无";
            
            Entry.TriggerLineWindow.Show();
        }
    }
}