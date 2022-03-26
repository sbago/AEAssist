using System;
using System.Windows.Forms;
using AEAssist.AI;

namespace AEAssist
{
    public partial class Overlay : Form
    {
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            LogHelper.Info("打开Overlay窗口");
        }

        private void CountDown5s_Click(object sender, EventArgs e)
        {
            CountDownHandler.Instance.StartCountDown();
        }

        private void Battle_Click(object sender, EventArgs e)
        {
            CountDownHandler.Instance.StartNow();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                AIRoot.Instance.SetStop(true);
                checkBox1.Text = "恢复";
            }
            else
            {
                AIRoot.Instance.SetStop(false);
                checkBox1.Text = "停手";
            }
        }
    }
}