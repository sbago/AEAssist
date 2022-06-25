using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using AEAssist.Opener;
using ff14bot.Enums;
using UserControl = System.Windows.Controls.UserControl;

namespace AEAssist.View
{
    public partial class SMNSettingView : UserControl
    {
        public SMNSettingView()
        {
            InitializeComponent();

            var swiftcastOption = new Dictionary<int, string>
            {
                { 0, "不使用" },
                { 1, "螺旋气流" },
                { 2, "螺旋气流/红宝石" }
            };
            SwiftcastOption.ItemsSource = swiftcastOption;
            SwiftcastOption.SelectedIndex = SettingMgr.GetSetting<SMNSettings>().SwiftcastOption;
            

   
        }
        private void ChooseSwiftcastOption_OnSelectionChanged(object sender, EventArgs eventArgs)
        {
            SettingMgr.GetSetting<SMNSettings>().SwiftcastOption = int.Parse(SwiftcastOption.SelectedValue.ToString());
        }

        
    }
}