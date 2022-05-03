using System;
using System.IO;
using System.Windows;
using AETriggers.TriggerModel;
using Microsoft.Win32;

namespace AEAssist.View.Overlay
{
    public partial class TriggerLineWindow : Window
    {
        public Action OnTriggerLineClear;
        public Action<string> OnTriggerLineLoad;

        public TriggerLineWindow()
        {
            InitializeComponent();
        }

        private void LoadTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Json(*.json)|*.json";
            openFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.Multiselect = false;
            var ret = openFile.ShowDialog();

            if (!ret.HasValue || !ret.Value)
                return;
            var file = openFile.FileName;
            {
                string str = "";
                (str,DataBinding.Instance.CurrTriggerLine) = TriggerHelper.LoadTriggerLine(file);
                if (str != null)
                {
                    MessageBox.Show(str);
                }

                if (DataBinding.Instance.CurrTriggerLine != null)
                {
                    MessageBox.Show("Load Success!");
                    TriggerLineAuthor.Content = $"Author: {DataBinding.Instance.CurrTriggerLine.Author}";
                    TriggerLineTargetDuty.Content = $"Duty: {DataBinding.Instance.CurrTriggerLine.TargetDuty}";
                    TriggerLineJob.Content =
                        $"TargetJob: {DataBinding.Instance.CurrTriggerLine.TargetJob}";
                    TriggerLineVersion.Content = $"Version: {DataBinding.Instance.CurrTriggerLine.Version}";
                    OnTriggerLineLoad?.Invoke(Path.GetFileNameWithoutExtension(file));
                }
            }
        }

        private void ClearTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            DataBinding.Instance.CurrTriggerLine = null;
            OnTriggerLineClear?.Invoke();
        }
    }
}