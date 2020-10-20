namespace JGNet.Common
{
    partial class SelectMoneyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.BaseButton_Cancel = new JGNet.Common.Components.BaseButton();
            this.BaseButton_OK = new JGNet.Common.Components.BaseButton();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.numericTextBox1 = new JGNet.Common.NumericTextBox();
            this.SuspendLayout();
            // 
            // BaseButton_Cancel
            // 
            this.BaseButton_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Cancel.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Cancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Cancel.Location = new System.Drawing.Point(137, 87);
            this.BaseButton_Cancel.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_Cancel.Name = "BaseButton_Cancel";
            this.BaseButton_Cancel.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_Cancel.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_Cancel.TabIndex = 1;
            this.BaseButton_Cancel.Text = "取消";
            this.BaseButton_Cancel.UseVisualStyleBackColor = false;
            this.BaseButton_Cancel.Click += new System.EventHandler(this.BaseButton_Cancel_Click);
            // 
            // BaseButton_OK
            // 
            this.BaseButton_OK.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_OK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_OK.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_OK.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_OK.Location = new System.Drawing.Point(56, 87);
            this.BaseButton_OK.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_OK.Name = "BaseButton_OK";
            this.BaseButton_OK.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_OK.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_OK.TabIndex = 0;
            this.BaseButton_OK.Text = "确定";
            this.BaseButton_OK.UseVisualStyleBackColor = false;
            this.BaseButton_OK.Click += new System.EventHandler(this.BaseButton_OK_Click);
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(7, 46);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(68, 17);
            this.skinLabel4.TabIndex = 0;
            this.skinLabel4.Text = "付款金额：";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.numericTextBox1.DecimalPlaces = 0;
            this.numericTextBox1.DownBack = null;
            this.numericTextBox1.Icon = null;
            this.numericTextBox1.IconIsButton = false;
            this.numericTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.numericTextBox1.IsPasswordChat = '\0';
            this.numericTextBox1.IsSystemPasswordChar = false;
            this.numericTextBox1.Lines = new string[] {
        "0"};
            this.numericTextBox1.Location = new System.Drawing.Point(82, 40);
            this.numericTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.numericTextBox1.MaxLength = 29;
            this.numericTextBox1.MaxNum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.numericTextBox1.MinNum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericTextBox1.MouseBack = null;
            this.numericTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.numericTextBox1.Multiline = false;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.NormlBack = null;
            this.numericTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.numericTextBox1.ReadOnly = false;
            this.numericTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericTextBox1.Size = new System.Drawing.Size(130, 28);
            // 
            // 
            // 
            this.numericTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.numericTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.numericTextBox1.SkinTxt.MaxLength = 29;
            this.numericTextBox1.SkinTxt.Name = "BaseText";
            this.numericTextBox1.SkinTxt.Size = new System.Drawing.Size(120, 18);
            this.numericTextBox1.SkinTxt.TabIndex = 0;
            this.numericTextBox1.SkinTxt.Text = "0";
            this.numericTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.numericTextBox1.SkinTxt.WaterText = "";
            this.numericTextBox1.TabIndex = 2;
            this.numericTextBox1.Text = "0";
            this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericTextBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.numericTextBox1.WaterText = "";
            this.numericTextBox1.WordWrap = true;
            // 
            // SelectMoneyForm
            // 
            this.AcceptButton = this.BaseButton_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 126);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.BaseButton_Cancel);
            this.Controls.Add(this.BaseButton_OK);
            this.Controls.Add(this.skinLabel4);
            this.Name = "SelectMoneyForm";
            this.Text = "输入付款金额";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Components.BaseButton BaseButton_Cancel;
        private Common.Components.BaseButton BaseButton_OK;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private NumericTextBox numericTextBox1;
    }
}