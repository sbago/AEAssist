using System.Windows;

namespace AEAssist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveSetting_OnClick(object sender, RoutedEventArgs e)
        {
            SettingMgr.Instance.Save();
        }

        private void ResetSetting_OnClick(object sender, RoutedEventArgs e)
        {
            SettingMgr.Instance.Reset();
        }
    }
}