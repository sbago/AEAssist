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
            RreshBattleState();
            RefreshBuffState();
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
            RreshBattleState();
        }


        public void RefreshCheckBox1(bool stop)
        {
            checkBox1.CheckState = stop ? CheckState.Checked : CheckState.Unchecked;
        }

        void RreshBattleState()
        {
            if (AIRoot.Instance.Stop)
            {
                checkBox1.Text = "恢复(F10)";
            }
            else
            {
                checkBox1.Text = "停手(F10)";
            }
            if(AIRoot.Instance.Stop)
                ShowBattleState("停手中",Color.DarkRed);
            else
            {
                ShowBattleState("运行中",Color.SpringGreen);
            }
        }

        public void ShowDebug(string msg)
        {
            this.DebugText.Text = msg;
        }

        void ShowBattleState(string msg, System.Drawing.Color color)
        {
            this.battleStateLabel.Text = msg;
            this.battleStateLabel.ForeColor = color;
        }

        private void BuffControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AIRoot.Instance.CloseBuff = BuffControlCheckBox.Checked;

            RefreshBuffState();
        }

        public void SwitchBuffControlState()
        {
            BuffControlCheckBox.Checked = !AIRoot.Instance.CloseBuff;
        }

        void RefreshBuffState()
        {
            if (AIRoot.Instance.CloseBuff)
            {
                BuffControlCheckBox.Text = "开启Buff(F11)";
                ShowBuffState("关闭", Color.DarkRed);
            }
            else
            {
                BuffControlCheckBox.Text = "关闭Buff(F11)";
                ShowBuffState("开启", Color.SpringGreen);
            }
        }

        private void ShowBuffState(string msg, System.Drawing.Color color)
        {
            this.BuffState.Text = msg;
            this.BuffState.ForeColor = color;
        }
    }
}