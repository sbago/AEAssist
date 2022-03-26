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
    }
}