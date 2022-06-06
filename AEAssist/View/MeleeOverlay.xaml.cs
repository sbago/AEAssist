using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace AEAssist.View
{
    public partial class MeleeOverlay : UserControl
    {
        public MeleeOverlay()
        {
            InitializeComponent();
        }
        

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayManager.OverlayManager.Instance.Close();
        }

    }
}