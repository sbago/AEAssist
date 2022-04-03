using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using AEAssist.AI;
using AEAssist.DataBinding;
using AETriggers.TriggerModel;
using ff14bot.Enums;
using ff14bot.Managers;
using Microsoft.Win32;
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
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Json(*.json)|*.json";
            openFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.Multiselect = false;
            var ret = openFile.ShowDialog();
            
            if (!ret.HasValue || !ret.Value)
                return;
            var file = openFile.FileName;
            {
                BaseSettings.Instance.CurrTriggerLine = TriggerHelper.LoadTriggerLine(file);
                if (BaseSettings.Instance.CurrTriggerLine != null)
                {
                    MessageBox.Show("加载时间轴成功!");
                    TriggerLineAuthor.Content = $"作者: {BaseSettings.Instance.CurrTriggerLine.Author}"; 
                    TriggerLineTargetDuty.Content = $"目标副本: {BaseSettings.Instance.CurrTriggerLine.TargetDuty}"; 
                    TriggerLineJob.Content = $"目标职业: {BaseSettings.Instance.CurrTriggerLine.TargetJob.ToString()}"; 
                    TriggerLineVersion.Content = $"版本: {BaseSettings.Instance.CurrTriggerLine.Version}"; 
                    OnTriggerLineLoad?.Invoke(Path.GetFileName(file));
                }
                else
                {
                    MessageBox.Show("Failed: 加载时间轴失败!");
                }
            }
        }
        
    }
}