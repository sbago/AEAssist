using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using AEAssist.DataBinding;
using AETriggers.TriggerModel;
using ff14bot.Enums;
using ff14bot.Managers;
using MessageBox = System.Windows.MessageBox;

namespace AEAssist.View.Overlay
{
    public partial class TriggerLineWindow : Window
    {
        public TriggerLineWindow()
        {
            InitializeComponent();
        }
        
        private void LoadTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var ret = openFileDialog.ShowDialog();
            if (ret == System.Windows.Forms.DialogResult.Yes)
            {
                BaseSettings.Instance.TriggerLine = TriggerHelper.LoadTriggerLine(openFileDialog.FileName);
                if (BaseSettings.Instance.TriggerLine != null)
                {
                    MessageBox.Show("加载时间轴成功!");
                    TriggerLineJob.Content = BaseSettings.Instance.TriggerLine.TargetJob.ToString();
                    TriggerLineTargetDuty.Content = BaseSettings.Instance.TriggerLine.TargetDuty.ToString();
                }
            }
        }
        
    }
}