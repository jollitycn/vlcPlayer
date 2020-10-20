namespace JGNet.Common.Components
{
    partial class NewSupplierComboBoxForm
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
            this.BaseButton_Search = new JGNet.Common.Components.BaseButton();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinTextBoxName = new JGNet.Common.TextBox();
            this.textBoxSort = new JGNet.Common.NumericTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // BaseButton_Search
            // 
            this.BaseButton_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseButton_Search.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Search.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Search.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Search.Location = new System.Drawing.Point(115, 110);
            this.BaseButton_Search.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_Search.Name = "BaseButton_Search";
            this.BaseButton_Search.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_Search.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_Search.TabIndex = 3;
            this.BaseButton_Search.Text = "确定";
            this.BaseButton_Search.UseVisualStyleBackColor = false;
            this.BaseButton_Search.Click += new System.EventHandler(this.BaseButton1_Click);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(12, 42);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 83;
            this.skinLabel2.Text = "供应商名称";
            // 
            // skinTextBoxName
            // 
            this.skinTextBoxName.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBoxName.DownBack = null;
            this.skinTextBoxName.Icon = null;
            this.skinTextBoxName.IconIsButton = false;
            this.skinTextBoxName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxName.IsPasswordChat = '\0';
            this.skinTextBoxName.IsSystemPasswordChar = false;
            this.skinTextBoxName.Lines = new string[0];
            this.skinTextBoxName.Location = new System.Drawing.Point(90, 33);
            this.skinTextBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBoxName.MaxLength = 32767;
            this.skinTextBoxName.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBoxName.MouseBack = null;
            this.skinTextBoxName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBoxName.Multiline = true;
            this.skinTextBoxName.Name = "skinTextBoxName";
            this.skinTextBoxName.NormlBack = null;
            this.skinTextBoxName.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBoxName.ReadOnly = false;
            this.skinTextBoxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBoxName.Size = new System.Drawing.Size(206, 34);
            // 
            // 
            // 
            this.skinTextBoxName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBoxName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBoxName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBoxName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBoxName.SkinTxt.Multiline = true;
            this.skinTextBoxName.SkinTxt.Name = "BaseText";
            this.skinTextBoxName.SkinTxt.Size = new System.Drawing.Size(196, 24);
            this.skinTextBoxName.SkinTxt.TabIndex = 0;
            this.skinTextBoxName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxName.SkinTxt.WaterText = "";
            this.skinTextBoxName.TabIndex = 1;
            this.skinTextBoxName.TabStop = true;
            this.skinTextBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBoxName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxName.WaterText = "";
            this.skinTextBoxName.WordWrap = true;
            this.skinTextBoxName.Leave += new System.EventHandler(this.skinTextBoxName_Leave);
            // 
            // textBoxSort
            // 
            this.textBoxSort.BackColor = System.Drawing.Color.Transparent;
            this.textBoxSort.DecimalPlaces = 0;
            this.textBoxSort.DownBack = null;
            this.textBoxSort.Icon = null;
            this.textBoxSort.IconIsButton = false;
            this.textBoxSort.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxSort.IsPasswordChat = '\0';
            this.textBoxSort.IsSystemPasswordChar = false;
            this.textBoxSort.Lines = new string[] {
        "100"};
            this.textBoxSort.Location = new System.Drawing.Point(90, 71);
            this.textBoxSort.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxSort.MaxLength = 32767;
            this.textBoxSort.MaxNum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.textBoxSort.MinimumSize = new System.Drawing.Size(28, 28);
            this.textBoxSort.MinNum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textBoxSort.MouseBack = null;
            this.textBoxSort.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxSort.Multiline = true;
            this.textBoxSort.Name = "textBoxSort";
            this.textBoxSort.NormlBack = null;
            this.textBoxSort.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxSort.ReadOnly = false;
            this.textBoxSort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxSort.Size = new System.Drawing.Size(206, 34);
            // 
            // 
            // 
            this.textBoxSort.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSort.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSort.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxSort.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textBoxSort.SkinTxt.Multiline = true;
            this.textBoxSort.SkinTxt.Name = "BaseText";
            this.textBoxSort.SkinTxt.Size = new System.Drawing.Size(196, 24);
            this.textBoxSort.SkinTxt.TabIndex = 0;
            this.textBoxSort.SkinTxt.Text = "100";
            this.textBoxSort.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxSort.SkinTxt.WaterText = "";
            this.textBoxSort.TabIndex = 87;
            this.textBoxSort.TabStop = true;
            this.textBoxSort.Text = "100";
            this.textBoxSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxSort.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textBoxSort.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxSort.WaterText = "";
            this.textBoxSort.WordWrap = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(24, 80);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 86;
            this.skinLabel1.Text = "显示排序";
            // 
            // NewSupplierComboBoxForm
            // 
            this.AcceptButton = this.BaseButton_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 149);
            this.Controls.Add(this.textBoxSort);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinTextBoxName);
            this.Controls.Add(this.BaseButton_Search);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSupplierComboBoxForm";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "添加供应商";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Common.Components.BaseButton BaseButton_Search;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private TextBox skinTextBoxName;
        private NumericTextBox textBoxSort;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}