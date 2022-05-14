using System.Windows.Controls;
using AEAssist.Opener;
using ff14bot.Enums;

namespace AEAssist.View
{
    public partial class SageSettingView : UserControl
    {
        public SageSettingView()
        {
            InitializeComponent();

            if (OpenerMgr.Instance.JobOpeners.ContainsKey(ClassJobType.Sage))
            {
                ChooseOpener.ItemsSource = OpenerMgr.Instance.JobOpeners[ClassJobType.Sage];
                ChooseOpener.SelectedValue = SettingMgr.GetSetting<SageSettings>().SageOpener;   
            }
        }

        private void ChooseOpener_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SettingMgr.GetSetting<SageSettings>().SageOpener = ChooseOpener.SelectedValue.ToString();
            OpenerMgr.Instance.SpecifyOpenerByName[ClassJobType.Sage] = ChooseOpener.SelectedValue.ToString();
        }
    }
}