namespace JGNet.Common
{
    partial class RechargeRecordListCtrl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rechargeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memberIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guideIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceOldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rechargeMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donateMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceNewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechargeRecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memberIDDataGridViewTextBoxColumn,
            this.guideIDDataGridViewTextBoxColumn,
            this.balanceOldDataGridViewTextBoxColumn,
            this.rechargeMoneyDataGridViewTextBoxColumn,
            this.donateMoneyDataGridViewTextBoxColumn,
            this.balanceNewDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.rechargeRecordBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 650);
            this.dataGridView1.TabIndex = 4;
            // 
            // rechargeRecordBindingSource
            // 
            this.rechargeRecordBindingSource.DataSource = typeof(JGNet.RechargeRecord);
            // 
            // memberIDDataGridViewTextBoxColumn
            // 
            this.memberIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.memberIDDataGridViewTextBoxColumn.DataPropertyName = "MemberID";
            this.memberIDDataGridViewTextBoxColumn.HeaderText = "会员卡号";
            this.memberIDDataGridViewTextBoxColumn.Name = "memberIDDataGridViewTextBoxColumn";
            this.memberIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.memberIDDataGridViewTextBoxColumn.Width = 152;
            // 
            // guideIDDataGridViewTextBoxColumn
            // 
            this.guideIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.guideIDDataGridViewTextBoxColumn.DataPropertyName = "GuideName";
            this.guideIDDataGridViewTextBoxColumn.HeaderText = "操作人";
            this.guideIDDataGridViewTextBoxColumn.Name = "guideIDDataGridViewTextBoxColumn";
            this.guideIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.guideIDDataGridViewTextBoxColumn.Width = 152;
            // 
            // balanceOldDataGridViewTextBoxColumn
            // 
            this.balanceOldDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.balanceOldDataGridViewTextBoxColumn.DataPropertyName = "BalanceOld";
            this.balanceOldDataGridViewTextBoxColumn.HeaderText = "充值前金额";
            this.balanceOldDataGridViewTextBoxColumn.Name = "balanceOldDataGridViewTextBoxColumn";
            this.balanceOldDataGridViewTextBoxColumn.ReadOnly = true;
            this.balanceOldDataGridViewTextBoxColumn.Width = 152;
            // 
            // rechargeMoneyDataGridViewTextBoxColumn
            // 
            this.rechargeMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName = "RechargeMoney";
            this.rechargeMoneyDataGridViewTextBoxColumn.HeaderText = "充值金额";
            this.rechargeMoneyDataGridViewTextBoxColumn.Name = "rechargeMoneyDataGridViewTextBoxColumn";
            this.rechargeMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.rechargeMoneyDataGridViewTextBoxColumn.Width = 151;
            // 
            // donateMoneyDataGridViewTextBoxColumn
            // 
            this.donateMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.donateMoneyDataGridViewTextBoxColumn.DataPropertyName = "DonateMoney";
            this.donateMoneyDataGridViewTextBoxColumn.HeaderText = "赠送金额";
            this.donateMoneyDataGridViewTextBoxColumn.Name = "donateMoneyDataGridViewTextBoxColumn";
            this.donateMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.donateMoneyDataGridViewTextBoxColumn.Width = 152;
            // 
            // balanceNewDataGridViewTextBoxColumn
            // 
            this.balanceNewDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.balanceNewDataGridViewTextBoxColumn.DataPropertyName = "BalanceNew";
            this.balanceNewDataGridViewTextBoxColumn.HeaderText = "充值后金额";
            this.balanceNewDataGridViewTextBoxColumn.Name = "balanceNewDataGridViewTextBoxColumn";
            this.balanceNewDataGridViewTextBoxColumn.ReadOnly = true;
            this.balanceNewDataGridViewTextBoxColumn.Width = 152;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.ReadOnly = true;
            this.remarksDataGridViewTextBoxColumn.Width = 130;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "充值时间";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createTimeDataGridViewTextBoxColumn.Width = 78;
            // 
            // RechargeRecordListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "RechargeRecordListCtrl";
            this.Load += new System.EventHandler(this.RechargeRecordCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechargeRecordBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource rechargeRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guideIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceOldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rechargeMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn donateMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceNewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
    }
}
