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
                string str = "";
                TriggerLine line = null;
                (str,line) = TriggerHelper.LoadTriggerLine(file);
                if (str != null)
                {
                    MessageBox.Show(str);
                }

                if (line != null)
                {
                    DataBinding.Instance.ChangeTriggerLine(line);
                }
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.Instance.Close();
        }

        private void ClearTriggerLine_OnClick(object sender, RoutedEventArgs e)
        {
            DataBinding.Instance.ChangeTriggerLine(null);
        }
    }
}