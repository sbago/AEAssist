using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using AEAssist.AI;
using AEAssist.DataBinding;
using AETriggers.TriggerModel;
using ff14bot.Enums;
using ff14bot.Managers;
using MessageBox = System.Windows.MessageBox;

namespace AEAssist.View.Overlay
{
    public partial class TriggerLineWindow : Window
    {
        public Action<string> OnTriggerLineLoad;
        
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
                BaseSettings.Instance.CurrTriggerLine = TriggerHelper.LoadTriggerLine(openFileDialog.FileName);
                if (BaseSettings.Instance.CurrTriggerLine != null)
                {
                    MessageBox.Show("加载时间轴成功!");
                    TriggerLineJob.Content = BaseSettings.Instance.CurrTriggerLine.TargetJob.ToString();
                    TriggerLineTargetDuty.Content = BaseSettings.Instance.CurrTriggerLine.TargetDuty.ToString();
                    OnTriggerLineLoad?.Invoke(Path.GetFileName(openFileDialog.FileName));
                }
            }
        }
        
    }
}