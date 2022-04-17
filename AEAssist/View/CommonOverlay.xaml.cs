using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using AETriggers.TriggerModel;
using Microsoft.Win32;

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
            var openFile = new OpenFileDialog();
            openFile.Filter = "Json(*.json)|*.json";
            openFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.Multiselect = false;
            var ret = openFile.ShowDialog();

            if (!ret.HasValue || !ret.Value)
                return;
            var file = openFile.FileName;
            {
                DataBinding.Instance.CurrTriggerLine = TriggerHelper.LoadTriggerLine(file);
                if (DataBinding.Instance.CurrTriggerLine != null)
                {
                    MessageBox.Show("Load Success!");
                    CurrTriggerLine.Content =Path.GetFileNameWithoutExtension(file);
                }
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.Close();
        }

        private void ClearTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            DataBinding.Instance.CurrTriggerLine = null;
            CurrTriggerLine.Content = "NULL";
        }
    }
}