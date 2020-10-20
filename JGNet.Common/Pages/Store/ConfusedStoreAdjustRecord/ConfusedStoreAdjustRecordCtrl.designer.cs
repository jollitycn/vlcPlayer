namespace JGNet.Common
{
    partial class ConfusedStoreAdjustRecordCtrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.memberBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.skinTextBox_costumeID = new JGNet.Common.CostumeTextBox();
            this.skinComboBoxShopID = new JGNet.Common.ShopComboBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.BaseButtonAdd = new JGNet.Common.Components.BaseButton();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.ShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatorUserIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorName1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeName1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPre1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorName2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeName2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPre2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).BeginInit();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memberBindingSource3
            // 
            this.memberBindingSource3.DataSource = typeof(JGNet.ConfusedStoreAdjustRecord);
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.dataGridView1);
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.Location = new System.Drawing.Point(0, 37);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1160, 613);
            this.skinPanel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShopName,
            this.operatorUserIDDataGridViewTextBoxColumn,
            this.costumeIDDataGridViewTextBoxColumn,
            this.colorName1DataGridViewTextBoxColumn,
            this.sizeName1DataGridViewTextBoxColumn,
            this.countPre1DataGridViewTextBoxColumn,
            this.colorName2DataGridViewTextBoxColumn,
            this.sizeName2DataGridViewTextBoxColumn,
            this.countPre2DataGridViewTextBoxColumn,
            this.Remarks,
            this.CreateTime});
            this.dataGridView1.DataSource = this.memberBindingSource3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 613);
            this.dataGridView1.TabIndex = 4;
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinTextBox_costumeID);
            this.skinPanel1.Controls.Add(this.skinComboBoxShopID);
            this.skinPanel1.Controls.Add(this.skinLabel4);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.BaseButtonAdd);
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 37);
            this.skinPanel1.TabIndex = 0;
            // 
            // skinTextBox_costumeID
            // 
            this.skinTextBox_costumeID.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox_costumeID.DownBack = null;
            this.skinTextBox_costumeID.FilterValid = true;
            this.skinTextBox_costumeID.Icon = null;
            this.skinTextBox_costumeID.IconIsButton = false;
            this.skinTextBox_costumeID.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_costumeID.IsPasswordChat = '\0';
            this.skinTextBox_costumeID.IsSystemPasswordChar = false;
            this.skinTextBox_costumeID.Lines = new string[0];
            this.skinTextBox_costumeID.Location = new System.Drawing.Point(41, 4);
            this.skinTextBox_costumeID.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox_costumeID.MaxLength = 32767;
            this.skinTextBox_costumeID.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox_costumeID.MouseBack = null;
            this.skinTextBox_costumeID.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox_costumeID.Multiline = false;
            this.skinTextBox_costumeID.Name = "skinTextBox_costumeID";
            this.skinTextBox_costumeID.NormlBack = null;
            this.skinTextBox_costumeID.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox_costumeID.ReadOnly = false;
            this.skinTextBox_costumeID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox_costumeID.Size = new System.Drawing.Size(142, 28);
            // 
            // 
            // 
            this.skinTextBox_costumeID.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox_costumeID.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox_costumeID.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox_costumeID.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox_costumeID.SkinTxt.Name = "BaseText";
            this.skinTextBox_costumeID.SkinTxt.Size = new System.Drawing.Size(132, 18);
            this.skinTextBox_costumeID.SkinTxt.TabIndex = 0;
            this.skinTextBox_costumeID.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_costumeID.SkinTxt.WaterText = "";
            this.skinTextBox_costumeID.TabIndex = 0;
            this.skinTextBox_costumeID.TabStop = true;
            this.skinTextBox_costumeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox_costumeID.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox_costumeID.WaterText = "";
            this.skinTextBox_costumeID.WordWrap = true;
            this.skinTextBox_costumeID.CostumeSelected += new CJBasic.Action<JGNet.Costume, bool>(this.skinTextBox_costumeID_CostumeSelected);
            // 
            // skinComboBoxShopID
            // 
            this.skinComboBoxShopID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBoxShopID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBoxShopID.FormattingEnabled = true;
            this.skinComboBoxShopID.Location = new System.Drawing.Point(224, 7);
            this.skinComboBoxShopID.Name = "skinComboBoxShopID";
            this.skinComboBoxShopID.Size = new System.Drawing.Size(142, 22);
            this.skinComboBoxShopID.TabIndex = 1;
            this.skinComboBoxShopID.WaterText = "";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(186, 10);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(32, 17);
            this.skinLabel4.TabIndex = 23;
            this.skinLabel4.Text = "店铺";
            this.skinLabel4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(3, 10);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 22;
            this.skinLabel1.Text = "款号";
            // 
            // BaseButtonAdd
            // 
            this.BaseButtonAdd.BackColor = System.Drawing.Color.Transparent;
            this.BaseButtonAdd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButtonAdd.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButtonAdd.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButtonAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButtonAdd.Location = new System.Drawing.Point(453, 2);
            this.BaseButtonAdd.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButtonAdd.Name = "BaseButtonAdd";
            this.BaseButtonAdd.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButtonAdd.Size = new System.Drawing.Size(75, 32);
            this.BaseButtonAdd.TabIndex = 3;
            this.BaseButtonAdd.Text = "添加";
            this.BaseButtonAdd.UseVisualStyleBackColor = false;
            this.BaseButtonAdd.Click += new System.EventHandler(this.BaseButtonAdd_Click);
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(372, 2);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 2;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // ShopName
            // 
            this.ShopName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ShopName.DataPropertyName = "ShopName";
            this.ShopName.HeaderText = "店铺";
            this.ShopName.Name = "ShopName";
            this.ShopName.ReadOnly = true;
            this.ShopName.Width = 120;
            // 
            // operatorUserIDDataGridViewTextBoxColumn
            // 
            this.operatorUserIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.operatorUserIDDataGridViewTextBoxColumn.DataPropertyName = "OperatorUserName";
            this.operatorUserIDDataGridViewTextBoxColumn.HeaderText = "操作人";
            this.operatorUserIDDataGridViewTextBoxColumn.Name = "operatorUserIDDataGridViewTextBoxColumn";
            this.operatorUserIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.operatorUserIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // costumeIDDataGridViewTextBoxColumn
            // 
            this.costumeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeIDDataGridViewTextBoxColumn.DataPropertyName = "CostumeID";
            this.costumeIDDataGridViewTextBoxColumn.HeaderText = "款号";
            this.costumeIDDataGridViewTextBoxColumn.Name = "costumeIDDataGridViewTextBoxColumn";
            this.costumeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeIDDataGridViewTextBoxColumn.Width = 120;
            // 
            // colorName1DataGridViewTextBoxColumn
            // 
            this.colorName1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorName1DataGridViewTextBoxColumn.DataPropertyName = "ColorName1";
            this.colorName1DataGridViewTextBoxColumn.HeaderText = "下调颜色";
            this.colorName1DataGridViewTextBoxColumn.Name = "colorName1DataGridViewTextBoxColumn";
            this.colorName1DataGridViewTextBoxColumn.ReadOnly = true;
            this.colorName1DataGridViewTextBoxColumn.Width = 120;
            // 
            // sizeName1DataGridViewTextBoxColumn
            // 
            this.sizeName1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeName1DataGridViewTextBoxColumn.DataPropertyName = "SizeDisplayName1";
            this.sizeName1DataGridViewTextBoxColumn.HeaderText = "下调尺码";
            this.sizeName1DataGridViewTextBoxColumn.Name = "sizeName1DataGridViewTextBoxColumn";
            this.sizeName1DataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeName1DataGridViewTextBoxColumn.Width = 120;
            // 
            // countPre1DataGridViewTextBoxColumn
            // 
            this.countPre1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countPre1DataGridViewTextBoxColumn.DataPropertyName = "CountChange1";
            this.countPre1DataGridViewTextBoxColumn.HeaderText = "下调数量";
            this.countPre1DataGridViewTextBoxColumn.Name = "countPre1DataGridViewTextBoxColumn";
            this.countPre1DataGridViewTextBoxColumn.ReadOnly = true;
            this.countPre1DataGridViewTextBoxColumn.Width = 120;
            // 
            // colorName2DataGridViewTextBoxColumn
            // 
            this.colorName2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorName2DataGridViewTextBoxColumn.DataPropertyName = "ColorName2";
            this.colorName2DataGridViewTextBoxColumn.HeaderText = "上调颜色";
            this.colorName2DataGridViewTextBoxColumn.Name = "colorName2DataGridViewTextBoxColumn";
            this.colorName2DataGridViewTextBoxColumn.ReadOnly = true;
            this.colorName2DataGridViewTextBoxColumn.Width = 120;
            // 
            // sizeName2DataGridViewTextBoxColumn
            // 
            this.sizeName2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeName2DataGridViewTextBoxColumn.DataPropertyName = "SizeDisplayName2";
            this.sizeName2DataGridViewTextBoxColumn.HeaderText = "上调尺码";
            this.sizeName2DataGridViewTextBoxColumn.Name = "sizeName2DataGridViewTextBoxColumn";
            this.sizeName2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeName2DataGridViewTextBoxColumn.Width = 106;
            // 
            // countPre2DataGridViewTextBoxColumn
            // 
            this.countPre2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countPre2DataGridViewTextBoxColumn.DataPropertyName = "CountChange2";
            this.countPre2DataGridViewTextBoxColumn.HeaderText = "上调数量";
            this.countPre2DataGridViewTextBoxColumn.Name = "countPre2DataGridViewTextBoxColumn";
            this.countPre2DataGridViewTextBoxColumn.ReadOnly = true;
            this.countPre2DataGridViewTextBoxColumn.Width = 107;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 54;
            // 
            // CreateTime
            // 
            this.CreateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "调整时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 78;
            // 
            // ConfusedStoreAdjustRecordCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanel1);
            this.Name = "ConfusedStoreAdjustRecordCtrl";
            this.Load += new System.EventHandler(this.ConfusedStoreAdjustRecordCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.BindingSource memberBindingSource3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Common.Components.BaseButton BaseButton1;
        private Common.Components.BaseButton BaseButtonAdd;
        private CostumeTextBox skinTextBox_costumeID;
        private ShopComboBox skinComboBoxShopID;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatorUserIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorName1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeName1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countPre1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorName2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeName2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countPre2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}
