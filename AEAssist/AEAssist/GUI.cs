using System;
using System.Windows.Forms;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            Peloton.Checked = SettingMgr.GetSetting<BardSettings>().UsePeloton;
            CheckBardPotion_Click(null,null);

            var generalSetting = SettingMgr.GetSetting<GeneralSettings>();
            
            TTKHpLine.Text = generalSetting.TimeToKill_TimeInSec.ToString();
            TTKControl.Checked =  generalSetting.OpenTTK;
            textBox2.Text = generalSetting.TTK_IgnoreDamage.ToString();
        }

        private void ShowOverlay_Click(object sender, EventArgs e)
        {
            GUIHelper.OpenOverlay();
        }

        private void Peloton_CheckedChanged(object sender, EventArgs e)
        {
            SettingMgr.GetSetting<BardSettings>().UsePeloton = Peloton.CheckState == CheckState.Checked;
        }

        private void CheckBardPotion_Click(object sender, EventArgs e)
        {
            var num = PotionHelper.CheckNum( SettingMgr.GetSetting<BardSettings>().PotionId);
            this.BardPotion.Text = $"爆发药 5级巧力之幻药 数量 {num.ToString()}";
        }

        private void TTKControl_CheckedChanged(object sender, EventArgs e)
        {
            SettingMgr.GetSetting<GeneralSettings>().OpenTTK = TTKControl.Checked;
        }

        private void TTKHpLine_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(TTKHpLine.Text, out var num))
            {
                TTKHpLine.Text =  SettingMgr.GetSetting<GeneralSettings>().TimeToKill_TimeInSec.ToString();
                return;
            }

            SettingMgr.GetSetting<GeneralSettings>().TimeToKill_TimeInSec = num;
        }

        private void SaveSetting_Click(object sender, EventArgs e)
        {
            SettingMgr.Instance.Save();
            MessageBox.Show("保存成功!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out var num))
            {
                textBox2.Text =  SettingMgr.GetSetting<GeneralSettings>().TTK_IgnoreDamage.ToString();
                return;
            }

            SettingMgr.GetSetting<GeneralSettings>().TTK_IgnoreDamage = num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingMgr.Instance.Reset();
            MessageBox.Show("重置成功!");
        }
    }
}