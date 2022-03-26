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
            Peloton.Checked = BardSettings.Instance.UsePeloton;
            CheckBardPotion_Click(null,null);
            
            TTKHpLine.Text = GeneralSettings.Instance.TimeToKill_HpLine.ToString();
            TTKControl.Checked =  GeneralSettings.Instance.OpenTTK;
        }

        private void ShowOverlay_Click(object sender, EventArgs e)
        {
            GUIHelper.OpenOverlay();
        }

        private void Peloton_CheckedChanged(object sender, EventArgs e)
        {
            BardSettings.Instance.UsePeloton = Peloton.CheckState == CheckState.Checked;
        }

        private void CheckBardPotion_Click(object sender, EventArgs e)
        {
            var num = PotionHelper.CheckNum(BardSettings.Instance.PotionId);
            this.BardPotion.Text = $"爆发药 5级巧力之幻药 数量 {num.ToString()}";
        }

        private void TTKControl_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.Instance.OpenTTK = TTKControl.Checked;
        }

        private void TTKHpLine_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(TTKHpLine.Text, out var num))
            {
                TTKHpLine.Text = GeneralSettings.Instance.TimeToKill_HpLine.ToString();
                return;
            }

            GeneralSettings.Instance.TimeToKill_HpLine = num;
        }

        private void SaveSetting_Click(object sender, EventArgs e)
        {
            DataHelper.Save();
        }
    }
}