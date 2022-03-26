using System.ComponentModel;

namespace AEAssist
{
    partial class GUI
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
            this.components = new System.ComponentModel.Container();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SaveSetting = new System.Windows.Forms.Button();
            this.TTKPanel = new System.Windows.Forms.Panel();
            this.TTKHpLineLabel = new System.Windows.Forms.Label();
            this.TTKControl = new System.Windows.Forms.CheckBox();
            this.TTKHpLine = new System.Windows.Forms.TextBox();
            this.ShowOverlay = new System.Windows.Forms.Button();
            this.BardTab = new System.Windows.Forms.TabPage();
            this.CheckBardPotion = new System.Windows.Forms.Button();
            this.BardPotion = new System.Windows.Forms.Label();
            this.Peloton = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainTab.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.TTKPanel.SuspendLayout();
            this.BardTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.GeneralTab);
            this.MainTab.Controls.Add(this.BardTab);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Multiline = true;
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(800, 450);
            this.MainTab.TabIndex = 1;
            // 
            // GeneralTab
            // 
            this.GeneralTab.BackColor = System.Drawing.Color.Silver;
            this.GeneralTab.Controls.Add(this.textBox1);
            this.GeneralTab.Controls.Add(this.SaveSetting);
            this.GeneralTab.Controls.Add(this.TTKPanel);
            this.GeneralTab.Controls.Add(this.ShowOverlay);
            this.GeneralTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(792, 424);
            this.GeneralTab.TabIndex = 0;
            this.GeneralTab.Text = "GeneralSetting";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(106, 21);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Q群: 814352226";
            // 
            // SaveSetting
            // 
            this.SaveSetting.Location = new System.Drawing.Point(11, 190);
            this.SaveSetting.Name = "SaveSetting";
            this.SaveSetting.Size = new System.Drawing.Size(128, 34);
            this.SaveSetting.TabIndex = 6;
            this.SaveSetting.Text = "保存设置";
            this.SaveSetting.UseVisualStyleBackColor = true;
            this.SaveSetting.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // TTKPanel
            // 
            this.TTKPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TTKPanel.Controls.Add(this.TTKHpLineLabel);
            this.TTKPanel.Controls.Add(this.TTKControl);
            this.TTKPanel.Controls.Add(this.TTKHpLine);
            this.TTKPanel.Location = new System.Drawing.Point(11, 96);
            this.TTKPanel.Name = "TTKPanel";
            this.TTKPanel.Size = new System.Drawing.Size(208, 71);
            this.TTKPanel.TabIndex = 5;
            // 
            // TTKHpLineLabel
            // 
            this.TTKHpLineLabel.Location = new System.Drawing.Point(3, 28);
            this.TTKHpLineLabel.Name = "TTKHpLineLabel";
            this.TTKHpLineLabel.Size = new System.Drawing.Size(72, 21);
            this.TTKHpLineLabel.TabIndex = 5;
            this.TTKHpLineLabel.Text = "血量判定";
            this.TTKHpLineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.TTKHpLineLabel, "血量剩余多少就进入濒死状态,4人本会除2");
            // 
            // TTKControl
            // 
            this.TTKControl.Location = new System.Drawing.Point(3, 3);
            this.TTKControl.Name = "TTKControl";
            this.TTKControl.Size = new System.Drawing.Size(98, 29);
            this.TTKControl.TabIndex = 3;
            this.TTKControl.Text = "开启TTK";
            this.TTKControl.UseVisualStyleBackColor = true;
            this.TTKControl.CheckedChanged += new System.EventHandler(this.TTKControl_CheckedChanged);
            // 
            // TTKHpLine
            // 
            this.TTKHpLine.Location = new System.Drawing.Point(81, 28);
            this.TTKHpLine.Name = "TTKHpLine";
            this.TTKHpLine.Size = new System.Drawing.Size(111, 21);
            this.TTKHpLine.TabIndex = 4;
            this.TTKHpLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TTKHpLine.TextChanged += new System.EventHandler(this.TTKHpLine_TextChanged);
            // 
            // ShowOverlay
            // 
            this.ShowOverlay.Location = new System.Drawing.Point(11, 15);
            this.ShowOverlay.Name = "ShowOverlay";
            this.ShowOverlay.Size = new System.Drawing.Size(105, 23);
            this.ShowOverlay.TabIndex = 1;
            this.ShowOverlay.Text = "显示Overlay";
            this.ShowOverlay.UseVisualStyleBackColor = true;
            this.ShowOverlay.Click += new System.EventHandler(this.ShowOverlay_Click);
            // 
            // BardTab
            // 
            this.BardTab.BackColor = System.Drawing.Color.DimGray;
            this.BardTab.Controls.Add(this.CheckBardPotion);
            this.BardTab.Controls.Add(this.BardPotion);
            this.BardTab.Controls.Add(this.Peloton);
            this.BardTab.Location = new System.Drawing.Point(4, 22);
            this.BardTab.Name = "BardTab";
            this.BardTab.Size = new System.Drawing.Size(792, 424);
            this.BardTab.TabIndex = 1;
            this.BardTab.Text = "BardSetting";
            // 
            // CheckBardPotion
            // 
            this.CheckBardPotion.Location = new System.Drawing.Point(222, 46);
            this.CheckBardPotion.Name = "CheckBardPotion";
            this.CheckBardPotion.Size = new System.Drawing.Size(105, 27);
            this.CheckBardPotion.TabIndex = 2;
            this.CheckBardPotion.Text = "检查爆发药数量";
            this.CheckBardPotion.UseVisualStyleBackColor = true;
            this.CheckBardPotion.Click += new System.EventHandler(this.CheckBardPotion_Click);
            // 
            // BardPotion
            // 
            this.BardPotion.Location = new System.Drawing.Point(24, 51);
            this.BardPotion.Name = "BardPotion";
            this.BardPotion.Size = new System.Drawing.Size(202, 22);
            this.BardPotion.TabIndex = 1;
            this.BardPotion.Text = "爆发药: 5级巧力之幻药 数量 0\r\n";
            this.BardPotion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Peloton
            // 
            this.Peloton.Location = new System.Drawing.Point(24, 24);
            this.Peloton.Name = "Peloton";
            this.Peloton.Size = new System.Drawing.Size(108, 24);
            this.Peloton.TabIndex = 0;
            this.Peloton.Text = "使用速行";
            this.Peloton.UseVisualStyleBackColor = true;
            this.Peloton.CheckedChanged += new System.EventHandler(this.Peloton_CheckedChanged);
            // 
            // GUI
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainTab);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI";
            this.ShowIcon = false;
            this.Text = "AEAssist";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.MainTab.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GeneralTab.PerformLayout();
            this.TTKPanel.ResumeLayout(false);
            this.TTKPanel.PerformLayout();
            this.BardTab.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button SaveSetting;

        private System.Windows.Forms.Label TTKHpLineLabel;
        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.Panel TTKPanel;

        private System.Windows.Forms.CheckBox TTKControl;
        private System.Windows.Forms.TextBox TTKHpLine;

        private System.Windows.Forms.Button CheckBardPotion;

        private System.Windows.Forms.Label BardPotion;

        private System.Windows.Forms.CheckBox Peloton;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button ShowOverlay;

        private System.Windows.Forms.TabPage GeneralTab;
        private System.Windows.Forms.TabPage BardTab;

        private System.Windows.Forms.TabControl MainTab;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;

        #endregion
    }
}