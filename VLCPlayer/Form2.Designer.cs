﻿namespace VLCPlayer
{
    partial class Form2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.skinFlowLayoutPanel1 = new CCWin.SkinControl.SkinFlowLayoutPanel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.skinTextBoxUrl = new CCWin.SkinControl.SkinTextBox();
            this.skinNumericUpDown1 = new CCWin.SkinControl.SkinNumericUpDown();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            this.skinPanel2.SuspendLayout();
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.skinFlowLayoutPanel1);
            this.skinPanel2.Controls.Add(this.skinPanel1);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(789, 313);
            this.skinPanel2.TabIndex = 4;
            // 
            // skinFlowLayoutPanel1
            // 
            this.skinFlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinFlowLayoutPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinFlowLayoutPanel1.DownBack = null;
            this.skinFlowLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.skinFlowLayoutPanel1.MouseBack = null;
            this.skinFlowLayoutPanel1.Name = "skinFlowLayoutPanel1";
            this.skinFlowLayoutPanel1.NormlBack = null;
            this.skinFlowLayoutPanel1.Size = new System.Drawing.Size(789, 280);
            this.skinFlowLayoutPanel1.TabIndex = 7;
            this.skinFlowLayoutPanel1.Resize += new System.EventHandler(this.skinFlowLayoutPanel1_Resize);
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinNumericUpDown1);
            this.skinPanel1.Controls.Add(this.skinButton2);
            this.skinPanel1.Controls.Add(this.skinButton3);
            this.skinPanel1.Controls.Add(this.skinButton1);
            this.skinPanel1.Controls.Add(this.skinTextBoxUrl);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(789, 33);
            this.skinPanel1.TabIndex = 5;
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(719, 7);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(62, 23);
            this.skinButton2.TabIndex = 1;
            this.skinButton2.Text = "断开";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(649, 7);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(64, 23);
            this.skinButton1.TabIndex = 1;
            this.skinButton1.Text = "连接";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // skinTextBoxUrl
            // 
            this.skinTextBoxUrl.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxUrl.DownBack = null;
            this.skinTextBoxUrl.Icon = null;
            this.skinTextBoxUrl.IconIsButton = false;
            this.skinTextBoxUrl.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxUrl.IsPasswordChat = '\0';
            this.skinTextBoxUrl.IsSystemPasswordChar = false;
            this.skinTextBoxUrl.Lines = new string[] {
        "rtsp://admin:admin123@192.168.1.33:554/H.264/ch1/main/av_stream"};
            this.skinTextBoxUrl.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxUrl.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxUrl.MaxLength = 32767;
            this.skinTextBoxUrl.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxUrl.MouseBack = null;
            this.skinTextBoxUrl.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxUrl.Multiline = false;
            this.skinTextBoxUrl.Name = "skinTextBoxUrl";
            this.skinTextBoxUrl.NormlBack = null;
            this.skinTextBoxUrl.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxUrl.ReadOnly = false;
            this.skinTextBoxUrl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxUrl.Size = new System.Drawing.Size(511, 28);
            // 
            // 
            // 
            this.skinTextBoxUrl.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxUrl.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxUrl.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxUrl.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxUrl.SkinTxt.Name = "BaseText";
            this.skinTextBoxUrl.SkinTxt.Size = new System.Drawing.Size(501, 18);
            this.skinTextBoxUrl.SkinTxt.TabIndex = 0;
            this.skinTextBoxUrl.SkinTxt.Text = "rtsp://admin:admin123@192.168.1.33:554/H.264/ch1/main/av_stream";
            this.skinTextBoxUrl.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxUrl.SkinTxt.WaterText = "";
            this.skinTextBoxUrl.TabIndex = 0;
            this.skinTextBoxUrl.Text = "rtsp://admin:admin123@192.168.1.33:554/H.264/ch1/main/av_stream";
            this.skinTextBoxUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxUrl.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxUrl.WaterText = "";
            this.skinTextBoxUrl.WordWrap = true;
            // 
            // skinNumericUpDown1
            // 
            this.skinNumericUpDown1.Location = new System.Drawing.Point(519, 7);
            this.skinNumericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.skinNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.skinNumericUpDown1.Name = "skinNumericUpDown1";
            this.skinNumericUpDown1.Size = new System.Drawing.Size(54, 21);
            this.skinNumericUpDown1.TabIndex = 2;
            this.skinNumericUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // skinButton3
            // 
            this.skinButton3.BackColor = System.Drawing.Color.Transparent;
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DownBack = null;
            this.skinButton3.Location = new System.Drawing.Point(579, 7);
            this.skinButton3.MouseBack = null;
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = null;
            this.skinButton3.Size = new System.Drawing.Size(64, 23);
            this.skinButton3.TabIndex = 1;
            this.skinButton3.Text = "初始化";
            this.skinButton3.UseVisualStyleBackColor = false;
            this.skinButton3.Click += new System.EventHandler(this.skinButton3_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(789, 313);
            this.Controls.Add(this.skinPanel2);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinFlowLayoutPanel skinFlowLayoutPanel1;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinTextBox skinTextBoxUrl;
        private CCWin.SkinControl.SkinNumericUpDown skinNumericUpDown1;
        private CCWin.SkinControl.SkinButton skinButton3;
    }
}

