using System;
using System.Windows.Forms;
using AEAssist.Define;

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
            
        }

        private void ShowOverlay_Click(object sender, EventArgs e)
        {
            GUIHelper.OpenOverlay();
        }

        private void Peloton_CheckedChanged(object sender, EventArgs e)
        {
            BardSettings.Instance.UsePeloton = Peloton.CheckState == CheckState.Checked;
        }
    }
}