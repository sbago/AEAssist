﻿using System.Windows;
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
                    CurrTriggerLine.Content = $"当前加载时间轴: {s}";

            Entry.TriggerLineWindow.OnTriggerLineClear = () =>
                CurrTriggerLine.Content = "当前加载时间轴: 无";

            Entry.TriggerLineWindow.Show();
        }
    }
}