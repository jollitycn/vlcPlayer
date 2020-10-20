namespace JGNet.Common
{
    partial class ConfusedStoreAdjustRecordDetailCtrl
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
            this.skinPanel2.Location = new System.Drawing.Point(0, 0);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1160, 650);
            this.skinPanel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
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
            this.dataGridView1.Size = new System.Drawing.Size(1160, 650);
            this.dataGridView1.TabIndex = 4;
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
            this.colorName1DataGridViewTextBoxColumn.Width = 101;
            // 
            // sizeName1DataGridViewTextBoxColumn
            // 
            this.sizeName1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeName1DataGridViewTextBoxColumn.DataPropertyName = "SizeDisplayName1";
            this.sizeName1DataGridViewTextBoxColumn.HeaderText = "下调尺码";
            this.sizeName1DataGridViewTextBoxColumn.Name = "sizeName1DataGridViewTextBoxColumn";
            this.sizeName1DataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeName1DataGridViewTextBoxColumn.Width = 102;
            // 
            // countPre1DataGridViewTextBoxColumn
            // 
            this.countPre1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countPre1DataGridViewTextBoxColumn.DataPropertyName = "CountChange1";
            this.countPre1DataGridViewTextBoxColumn.HeaderText = "下调数量";
            this.countPre1DataGridViewTextBoxColumn.Name = "countPre1DataGridViewTextBoxColumn";
            this.countPre1DataGridViewTextBoxColumn.ReadOnly = true;
            this.countPre1DataGridViewTextBoxColumn.Width = 101;
            // 
            // colorName2DataGridViewTextBoxColumn
            // 
            this.colorName2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorName2DataGridViewTextBoxColumn.DataPropertyName = "ColorName2";
            this.colorName2DataGridViewTextBoxColumn.HeaderText = "上调颜色";
            this.colorName2DataGridViewTextBoxColumn.Name = "colorName2DataGridViewTextBoxColumn";
            this.colorName2DataGridViewTextBoxColumn.ReadOnly = true;
            this.colorName2DataGridViewTextBoxColumn.Width = 102;
            // 
            // sizeName2DataGridViewTextBoxColumn
            // 
            this.sizeName2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeName2DataGridViewTextBoxColumn.DataPropertyName = "SizeDisplayName2";
            this.sizeName2DataGridViewTextBoxColumn.HeaderText = "上调尺码";
            this.sizeName2DataGridViewTextBoxColumn.Name = "sizeName2DataGridViewTextBoxColumn";
            this.sizeName2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeName2DataGridViewTextBoxColumn.Width = 101;
            // 
            // countPre2DataGridViewTextBoxColumn
            // 
            this.countPre2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countPre2DataGridViewTextBoxColumn.DataPropertyName = "CountChange2";
            this.countPre2DataGridViewTextBoxColumn.HeaderText = "上调数量";
            this.countPre2DataGridViewTextBoxColumn.Name = "countPre2DataGridViewTextBoxColumn";
            this.countPre2DataGridViewTextBoxColumn.ReadOnly = true;
            this.countPre2DataGridViewTextBoxColumn.Width = 102;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 150;
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
            // ConfusedStoreAdjustRecordDetailCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinPanel2);
            this.Name = "ConfusedStoreAdjustRecordDetailCtrl";
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource3)).EndInit();
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.BindingSource memberBindingSource3;
        private System.Windows.Forms.DataGridView dataGridView1;
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
