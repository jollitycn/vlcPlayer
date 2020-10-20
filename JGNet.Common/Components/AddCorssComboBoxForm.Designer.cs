namespace JGNet.Common.Components
{
    partial class AddCorssComboBoxForm
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
            this.skinTextBoxValue = new  JGNet.Common.TextBox();
            this.skinLabel = new CCWin.SkinControl.SkinLabel();
            this.BaseButton_Search = new  Common.Components.BaseButton();
            this.SuspendLayout();
            // 
            // skinTextBoxValue
            // 
            this.skinTextBoxValue.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxValue.DownBack = null;
            this.skinTextBoxValue.Icon = null;
            this.skinTextBoxValue.IconIsButton = false;
            this.skinTextBoxValue.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxValue.IsPasswordChat = '\0';
            this.skinTextBoxValue.IsSystemPasswordChar = false;
            this.skinTextBoxValue.Lines = new string[0];
            this.skinTextBoxValue.Location = new System.Drawing.Point(80, 28);
            this.skinTextBoxValue.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxValue.MaxLength = 32767;
            this.skinTextBoxValue.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxValue.MouseBack = null;
            this.skinTextBoxValue.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxValue.Multiline = true;
            this.skinTextBoxValue.Name = "skinTextBoxValue";
            this.skinTextBoxValue.NormlBack = null;
            this.skinTextBoxValue.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxValue.ReadOnly = false;
            this.skinTextBoxValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxValue.Size = new System.Drawing.Size(206, 34);
            // 
            // 
            // 
            this.skinTextBoxValue.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxValue.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxValue.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxValue.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxValue.SkinTxt.Multiline = true;
            this.skinTextBoxValue.SkinTxt.Name = "BaseText";
            this.skinTextBoxValue.SkinTxt.Size = new System.Drawing.Size(196, 24);
            this.skinTextBoxValue.SkinTxt.TabIndex = 0;
            this.skinTextBoxValue.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxValue.SkinTxt.WaterText = "";
            this.skinTextBoxValue.TabIndex = 0;
            this.skinTextBoxValue.TabStop = true;
            this.skinTextBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxValue.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxValue.WaterText = "";
            this.skinTextBoxValue.WordWrap = true;
            // 
            // skinLabel
            // 
            this.skinLabel.AutoSize = true;
            this.skinLabel.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel.BorderColor = System.Drawing.Color.White;
            this.skinLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel.Location = new System.Drawing.Point(21, 36);
            this.skinLabel.Name = "skinLabel";
            this.skinLabel.Size = new System.Drawing.Size(44, 17);
            this.skinLabel.TabIndex = 22;
            this.skinLabel.Text = "标题：";
            // 
            // BaseButton_Search
            // 
            this.BaseButton_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton_Search.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Search.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Search.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Search.Location = new System.Drawing.Point(293, 28);
            this.BaseButton_Search.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_Search.Name = "BaseButton_Search";
            this.BaseButton_Search.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_Search.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_Search.TabIndex = 1;
            this.BaseButton_Search.Text = "确定";
            this.BaseButton_Search.UseVisualStyleBackColor = false;
            this.BaseButton_Search.Click += new System.EventHandler(this.BaseButton1_Click);
            // 
            // AddCorssComboBoxForm
            // 
            this.AcceptButton = this.BaseButton_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 76);
            this.Controls.Add(this.BaseButton_Search);
            this.Controls.Add(this.skinLabel);
            this.Controls.Add(this.skinTextBoxValue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCorssComboBoxForm";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Shown += new System.EventHandler(this.AddCorssComboBoxForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private  JGNet.Common.TextBox skinTextBoxValue;
        private CCWin.SkinControl.SkinLabel skinLabel;
        private Common.Components.BaseButton BaseButton_Search;
    }
}