namespace JGNet.Common
{
    partial class MemberImportForm
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
            this.skinLabelFileName = new CCWin.SkinControl.SkinLabel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.skinComboBoxShopID = new ShopComboBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.baseButtonChooseFile = new JGNet.Common.Components.BaseButton();
            this.skinPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaseButton_Cancel
            // 
            this.BaseButton_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton_Cancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton_Cancel.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton_Cancel.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton_Cancel.Location = new System.Drawing.Point(357, 69);
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
            this.BaseButton_OK.Location = new System.Drawing.Point(276, 69);
            this.BaseButton_OK.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton_OK.Name = "BaseButton_OK";
            this.BaseButton_OK.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton_OK.Size = new System.Drawing.Size(75, 32);
            this.BaseButton_OK.TabIndex = 0;
            this.BaseButton_OK.Text = "确定";
            this.BaseButton_OK.UseVisualStyleBackColor = false;
            this.BaseButton_OK.Click += new System.EventHandler(this.BaseButton_OK_Click);
            // 
            // skinLabelFileName
            // 
            this.skinLabelFileName.AutoSize = true;
            this.skinLabelFileName.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelFileName.BorderColor = System.Drawing.Color.White;
            this.skinLabelFileName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelFileName.Location = new System.Drawing.Point(159, 45);
            this.skinLabelFileName.Name = "skinLabelFileName";
            this.skinLabelFileName.Size = new System.Drawing.Size(68, 17);
            this.skinLabelFileName.TabIndex = 0;
            this.skinLabelFileName.Text = "修改日期："; 
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.linkLabel1);
            this.skinPanel2.Controls.Add(this.skinComboBoxShopID);
            this.skinPanel2.Controls.Add(this.skinLabel5);
            this.skinPanel2.Controls.Add(this.skinLabelFileName);
            this.skinPanel2.Controls.Add(this.baseButtonChooseFile);
            this.skinPanel2.Controls.Add(this.BaseButton_OK);
            this.skinPanel2.Controls.Add(this.BaseButton_Cancel);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(4, 28);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(436, 105);
            this.skinPanel2.TabIndex = 6; 
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(81, 77);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "下载模板";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // skinComboBoxShopID
            // 
            this.skinComboBoxShopID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxShopID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxShopID.FormattingEnabled = true;
            this.skinComboBoxShopID.Location = new System.Drawing.Point(78, 7);
            this.skinComboBoxShopID.Name = "skinComboBoxShopID";
            this.skinComboBoxShopID.Size = new System.Drawing.Size(142, 22);
            this.skinComboBoxShopID.TabIndex = 10;
            this.skinComboBoxShopID.WaterText = "";
            this.skinComboBoxShopID.SelectedIndexChanged += new System.EventHandler(this.skinComboBoxShopID_SelectedIndexChanged);
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(28, 10);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(44, 17);
            this.skinLabel5.TabIndex = 11;
            this.skinLabel5.Text = "店铺：";
            // 
            // baseButtonChooseFile
            // 
            this.baseButtonChooseFile.BackColor = System.Drawing.Color.Transparent;
            this.baseButtonChooseFile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButtonChooseFile.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButtonChooseFile.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButtonChooseFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButtonChooseFile.Location = new System.Drawing.Point(78, 37);
            this.baseButtonChooseFile.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButtonChooseFile.Name = "baseButtonChooseFile";
            this.baseButtonChooseFile.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButtonChooseFile.Size = new System.Drawing.Size(75, 32);
            this.baseButtonChooseFile.TabIndex = 0;
            this.baseButtonChooseFile.Text = "选择文件";
            this.baseButtonChooseFile.UseVisualStyleBackColor = false;
            this.baseButtonChooseFile.Click += new System.EventHandler(this.baseButtonChooseFile_Click);
            // 
            // MemberImportForm
            // 
            this.AcceptButton = this.BaseButton_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 137);
            this.ControlBox = false;
            this.Controls.Add(this.skinPanel2);
            this.Name = "MemberImportForm";
            this.Text = "请选择";
            this.skinPanel2.ResumeLayout(false);
            this.skinPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Common.Components.BaseButton BaseButton_Cancel;
        private Common.Components.BaseButton BaseButton_OK;
        private CCWin.SkinControl.SkinLabel skinLabelFileName;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private ShopComboBox skinComboBoxShopID;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Components.BaseButton baseButtonChooseFile;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}