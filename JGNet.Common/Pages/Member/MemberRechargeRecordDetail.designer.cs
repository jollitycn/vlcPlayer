namespace JGNet.Common
{
    partial class MemberRechargeRecordDetail 
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
            this.skinPanel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rechargeRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memberBalanceChangeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanelSendGift = new System.Windows.Forms.Panel();
            this.MemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonateMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RechargeMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechargeRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBalanceChangeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinPanel2.Location = new System.Drawing.Point(4, 38);
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.Size = new System.Drawing.Size(1192, 500);
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
            this.MemberID,
            this.Column1,
            this.DonateMoney,
            this.BalanceNew,
            this.BalanceOld,
            this.RechargeMoney,
            this.Remarks,
            this.CreateTime});
            this.dataGridView1.DataSource = this.rechargeRecordBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1192, 500);
            this.dataGridView1.TabIndex = 3;
            // 
            // rechargeRecordBindingSource
            // 
            this.rechargeRecordBindingSource.DataSource = typeof(JGNet.RechargeRecord);
            // 
            // memberBalanceChangeBindingSource
            // 
            this.memberBalanceChangeBindingSource.DataSource = typeof(JGNet.Core.InteractEntity.MemberBalanceChange);
            // 
            // skinPanelSendGift
            // 
            this.skinPanelSendGift.BackColor = System.Drawing.Color.Transparent;
            this.skinPanelSendGift.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanelSendGift.Location = new System.Drawing.Point(4, 28);
            this.skinPanelSendGift.Name = "skinPanelSendGift";
            this.skinPanelSendGift.Size = new System.Drawing.Size(1192, 10);
            this.skinPanelSendGift.TabIndex = 0;
            // 
            // MemberID
            // 
            this.MemberID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MemberID.DataPropertyName = "MemberID";
            this.MemberID.HeaderText = "会员卡号";
            this.MemberID.Name = "MemberID";
            this.MemberID.Width = 150;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "GuideName";
            this.Column1.HeaderText = "操作人";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // DonateMoney
            // 
            this.DonateMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DonateMoney.DataPropertyName = "DonateMoney";
            this.DonateMoney.HeaderText = "赠送金额";
            this.DonateMoney.Name = "DonateMoney";
            this.DonateMoney.Width = 150;
            // 
            // BalanceNew
            // 
            this.BalanceNew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BalanceNew.DataPropertyName = "BalanceNew";
            this.BalanceNew.HeaderText = "充值后金额";
            this.BalanceNew.Name = "BalanceNew";
            this.BalanceNew.Width = 150;
            // 
            // BalanceOld
            // 
            this.BalanceOld.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BalanceOld.DataPropertyName = "BalanceOld";
            this.BalanceOld.HeaderText = "充值钱金额";
            this.BalanceOld.Name = "BalanceOld";
            this.BalanceOld.Width = 150;
            // 
            // RechargeMoney
            // 
            this.RechargeMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RechargeMoney.DataPropertyName = "RechargeMoney";
            this.RechargeMoney.HeaderText = "充值金额";
            this.RechargeMoney.Name = "RechargeMoney";
            this.RechargeMoney.Width = 150;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 200;
            // 
            // CreateTime
            // 
            this.CreateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "充值时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.Width = 78;
            // 
            // MemberRechargeRecordDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 542);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.skinPanel2);
            this.Controls.Add(this.skinPanelSendGift);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MemberRechargeRecordDetail";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "会员充值记录";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MemberconsumptionSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rechargeRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBalanceChangeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel skinPanelSendGift;
        private System.Windows.Forms.Panel skinPanel2;
        private System.Windows.Forms.DataGridView dataGridView1; 
        private System.Windows.Forms.BindingSource memberBalanceChangeBindingSource;
        private System.Windows.Forms.BindingSource rechargeRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonateMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceOld;
        private System.Windows.Forms.DataGridViewTextBoxColumn RechargeMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}
