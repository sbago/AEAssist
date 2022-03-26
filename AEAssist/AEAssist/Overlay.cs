using System;
using System.Windows.Forms;
using System.Windows.Media;
using AEAssist.AI;
using Color = System.Drawing.Color;

namespace AEAssist
{
    public partial class Overlay : Form
    {
        public Overlay()
        {
            InitializeComponent();
        }

        protected override bool ShowWithoutActivation => true;

        private void Overlay_Load(object sender, EventArgs e)
        {
            LogHelper.Info("打开Overlay窗口");
            BattleStop.Checked = AIRoot.Instance.Stop;
            BuffControlCheckBox.Checked = AIRoot.Instance.CloseBuff;
            PotionControl.Checked = GeneralSettings.Instance.UsePotion;
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
            AIRoot.Instance.Stop =(checkBox1.CheckState == CheckState.Checked);
        }
        
        public void RefreshCheckBox1(bool stop)
        {
            checkBox1.CheckState = stop ? CheckState.Checked : CheckState.Unchecked;
        }

        public void ShowDebug(string msg)
        {
            this.DebugText.Text = msg;
        }
        

        private void BuffControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AIRoot.Instance.CloseBuff = BuffControlCheckBox.Checked;
        }

        public void SwitchBuffControlState()
        {
            BuffControlCheckBox.Checked = !AIRoot.Instance.CloseBuff;
        }

        private void PotionControl_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.Instance.UsePotion = PotionControl.Checked;
        }

        public void SiwtchPotionControl()
        {
            PotionControl.Checked = !GeneralSettings.Instance.UsePotion;
        }
    }
}