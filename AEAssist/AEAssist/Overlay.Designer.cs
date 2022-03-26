using System.ComponentModel;

namespace AEAssist
{
    partial class Overlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CountDown5s = new System.Windows.Forms.Button();
            this.Battle = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DebugText = new System.Windows.Forms.Label();
            this.battleStateLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BuffControlCheckBox = new System.Windows.Forms.CheckBox();
            this.BuffState = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CountDown5s
            // 
            this.CountDown5s.CausesValidation = false;
            this.CountDown5s.Location = new System.Drawing.Point(16, 7);
            this.CountDown5s.Name = "CountDown5s";
            this.CountDown5s.Size = new System.Drawing.Size(104, 23);
            this.CountDown5s.TabIndex = 0;
            this.CountDown5s.Text = "倒计时5秒(F8)";
            this.CountDown5s.UseVisualStyleBackColor = true;
            this.CountDown5s.Click += new System.EventHandler(this.CountDown5s_Click);
            // 
            // Battle
            // 
            this.Battle.CausesValidation = false;
            this.Battle.Location = new System.Drawing.Point(126, 7);
            this.Battle.Name = "Battle";
            this.Battle.Size = new System.Drawing.Size(120, 23);
            this.Battle.TabIndex = 1;
            this.Battle.Text = "立即战斗(F9)";
            this.Battle.UseVisualStyleBackColor = true;
            this.Battle.Click += new System.EventHandler(this.Battle_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox1.CausesValidation = false;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkBox1.Location = new System.Drawing.Point(16, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 28);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "停手(F10)";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Debug信息:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DebugText
            // 
            this.DebugText.Location = new System.Drawing.Point(20, 28);
            this.DebugText.Name = "DebugText";
            this.DebugText.Size = new System.Drawing.Size(230, 33);
            this.DebugText.TabIndex = 4;
            this.DebugText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // battleStateLabel
            // 
            this.battleStateLabel.ForeColor = System.Drawing.Color.Lime;
            this.battleStateLabel.Location = new System.Drawing.Point(126, 36);
            this.battleStateLabel.Name = "battleStateLabel";
            this.battleStateLabel.Size = new System.Drawing.Size(102, 27);
            this.battleStateLabel.TabIndex = 5;
            this.battleStateLabel.Text = "战斗中";
            this.battleStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DebugText);
            this.panel1.Location = new System.Drawing.Point(16, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 69);
            this.panel1.TabIndex = 6;
            // 
            // BuffControlCheckBox
            // 
            this.BuffControlCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.BuffControlCheckBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BuffControlCheckBox.CausesValidation = false;
            this.BuffControlCheckBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BuffControlCheckBox.Location = new System.Drawing.Point(16, 70);
            this.BuffControlCheckBox.Name = "BuffControlCheckBox";
            this.BuffControlCheckBox.Size = new System.Drawing.Size(104, 28);
            this.BuffControlCheckBox.TabIndex = 7;
            this.BuffControlCheckBox.Text = "关闭Buff(F11)";
            this.BuffControlCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BuffControlCheckBox.UseVisualStyleBackColor = false;
            this.BuffControlCheckBox.CheckedChanged += new System.EventHandler(this.BuffControlCheckBox_CheckedChanged);
            // 
            // BuffState
            // 
            this.BuffState.ForeColor = System.Drawing.Color.Lime;
            this.BuffState.Location = new System.Drawing.Point(126, 70);
            this.BuffState.Name = "BuffState";
            this.BuffState.Size = new System.Drawing.Size(102, 27);
            this.BuffState.TabIndex = 8;
            this.BuffState.Text = "战斗中";
            this.BuffState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Overlay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(274, 180);
            this.ControlBox = false;
            this.Controls.Add(this.BuffState);
            this.Controls.Add(this.BuffControlCheckBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.battleStateLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Battle);
            this.Controls.Add(this.CountDown5s);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Overlay";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Overlay";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox BuffControlCheckBox;
        private System.Windows.Forms.Label BuffState;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label battleStateLabel;

        private System.Windows.Forms.Label DebugText;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button CountDown5s;
        private System.Windows.Forms.Button Battle;

        #endregion
    }
}