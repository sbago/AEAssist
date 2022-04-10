using System.Windows;

namespace AEAssist
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
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

        // private void ResetSetting_OnClick(object sender, RoutedEventArgs e)
        // {
        //     var result = MessageBox.Show( messageBoxText: "确定重置设置嘛?", "二次确认",  button: MessageBoxButton.YesNo,MessageBoxImage.Question);
        //     if (result ==  MessageBoxResult.Yes)
        //     {
        //         SettingMgr.Instance.Reset();
        //     }
        // }
    }
}