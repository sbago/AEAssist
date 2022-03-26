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
            this.SuspendLayout();
            // 
            // CountDown5s
            // 
            this.CountDown5s.CausesValidation = false;
            this.CountDown5s.Location = new System.Drawing.Point(16, 7);
            this.CountDown5s.Name = "CountDown5s";
            this.CountDown5s.Size = new System.Drawing.Size(76, 23);
            this.CountDown5s.TabIndex = 0;
            this.CountDown5s.Text = "倒计时5秒";
            this.CountDown5s.UseVisualStyleBackColor = true;
            this.CountDown5s.Click += new System.EventHandler(this.CountDown5s_Click);
            // 
            // Battle
            // 
            this.Battle.CausesValidation = false;
            this.Battle.Location = new System.Drawing.Point(98, 7);
            this.Battle.Name = "Battle";
            this.Battle.Size = new System.Drawing.Size(76, 23);
            this.Battle.TabIndex = 1;
            this.Battle.Text = "立即战斗";
            this.Battle.UseVisualStyleBackColor = true;
            this.Battle.Click += new System.EventHandler(this.Battle_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox1.CausesValidation = false;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkBox1.Location = new System.Drawing.Point(33, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 28);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "停手";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Overlay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(188, 75);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Battle);
            this.Controls.Add(this.CountDown5s);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Overlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Overlay_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button CountDown5s;
        private System.Windows.Forms.Button Battle;

        #endregion
    }
}