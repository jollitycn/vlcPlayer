namespace JGNet.Common
{
    partial class BenefitReportManageCtrl
    {
        /// <> 
        /// 必需的设计器变量。
        /// </>
        private System.ComponentModel.IContainer components = null;

        /// <> 
        /// 清理所有正在使用的资源。
        /// </>
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

        /// <> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.baseButton2 = new JGNet.Common.Components.BaseButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinComboBox_Time = new CCWin.SkinControl.SkinComboBox();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRecharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfRefundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesActualRecvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesBenefit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesVipContributionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesAverageDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesJointRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesPerMemberPayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesPerCostumePayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refundRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportBindingSource
            // 
            this.reportBindingSource.DataSource = typeof(JGNet.DayBenefitReport);
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.baseButton2);
            this.skinPanel1.Controls.Add(this.skinLabel1);
            this.skinPanel1.Controls.Add(this.skinComboBox_Time);
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(1160, 36);
            this.skinPanel1.TabIndex = 0;
            // 
            // baseButton2
            // 
            this.baseButton2.BackColor = System.Drawing.Color.Transparent;
            this.baseButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.baseButton2.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.baseButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.baseButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baseButton2.Location = new System.Drawing.Point(596, 1);
            this.baseButton2.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.baseButton2.Size = new System.Drawing.Size(75, 32);
            this.baseButton2.TabIndex = 126;
            this.baseButton2.Text = "导出";
            this.baseButton2.UseVisualStyleBackColor = false;
            this.baseButton2.Click += new System.EventHandler(this.baseButton2_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(3, 9);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 125;
            this.skinLabel1.Text = "时间";
            // 
            // skinComboBox_Time
            // 
            this.skinComboBox_Time.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Time.FormattingEnabled = true;
            this.skinComboBox_Time.Location = new System.Drawing.Point(41, 6);
            this.skinComboBox_Time.Name = "skinComboBox_Time";
            this.skinComboBox_Time.Size = new System.Drawing.Size(96, 22);
            this.skinComboBox_Time.TabIndex = 124;
            this.skinComboBox_Time.WaterText = "";
            this.skinComboBox_Time.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_Time_SelectedIndexChanged);
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(515, 1);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 2;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(367, 5);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_End.TabIndex = 1;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(181, 5);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 0;
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(329, 7);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(32, 17);
            this.skinLabel3.TabIndex = 9;
            this.skinLabel3.Text = "结束";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(143, 7);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 10;
            this.skinLabel2.Text = "开始";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.CollapsePanel = CCWin.SkinControl.CollapsePanel.Panel2;
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 36);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 614);
            this.skinSplitContainer1.SplitterDistance = 189;
            this.skinSplitContainer1.SplitterWidth = 8;
            this.skinSplitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.TotalRecharge,
            this.quantityOfSaleDataGridViewTextBoxColumn,
            this.quantityOfRefundDataGridViewTextBoxColumn,
            this.salesCountDataGridViewTextBoxColumn,
            this.salesTotalMoneyDataGridViewTextBoxColumn,
            this.salesActualRecvDataGridViewTextBoxColumn,
            this.salesTotalCostDataGridViewTextBoxColumn,
            this.SalesBenefit,
            this.SalesVipContributionDataGridViewTextBoxColumn,
            this.SalesAverageDiscount,
            this.salesTotalPriceDataGridViewTextBoxColumn,
            this.salesJointRateDataGridViewTextBoxColumn,
            this.salesPerMemberPayDataGridViewTextBoxColumn,
            this.salesPerCostumePayDataGridViewTextBoxColumn,
            this.refundRateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.reportBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 189);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "ShopName";
            this.Column1.HeaderText = "店铺名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // TotalRecharge
            // 
            this.TotalRecharge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalRecharge.DataPropertyName = "TotalRecharge";
            this.TotalRecharge.HeaderText = "会员充值";
            this.TotalRecharge.Name = "TotalRecharge";
            this.TotalRecharge.ReadOnly = true;
            // 
            // quantityOfSaleDataGridViewTextBoxColumn
            // 
            this.quantityOfSaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName = "QuantityOfSale";
            this.quantityOfSaleDataGridViewTextBoxColumn.HeaderText = "销量";
            this.quantityOfSaleDataGridViewTextBoxColumn.Name = "quantityOfSaleDataGridViewTextBoxColumn";
            this.quantityOfSaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityOfSaleDataGridViewTextBoxColumn.ToolTipText = "销售总数";
            this.quantityOfSaleDataGridViewTextBoxColumn.Width = 54;
            // 
            // quantityOfRefundDataGridViewTextBoxColumn
            // 
            this.quantityOfRefundDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.quantityOfRefundDataGridViewTextBoxColumn.DataPropertyName = "QuantityOfRefund";
            this.quantityOfRefundDataGridViewTextBoxColumn.HeaderText = "退货";
            this.quantityOfRefundDataGridViewTextBoxColumn.Name = "quantityOfRefundDataGridViewTextBoxColumn";
            this.quantityOfRefundDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityOfRefundDataGridViewTextBoxColumn.ToolTipText = "退货总数";
            this.quantityOfRefundDataGridViewTextBoxColumn.Width = 54;
            // 
            // salesCountDataGridViewTextBoxColumn
            // 
            this.salesCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesCountDataGridViewTextBoxColumn.DataPropertyName = "SalesCount";
            this.salesCountDataGridViewTextBoxColumn.HeaderText = "单数";
            this.salesCountDataGridViewTextBoxColumn.Name = "salesCountDataGridViewTextBoxColumn";
            this.salesCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesCountDataGridViewTextBoxColumn.ToolTipText = "销售单数";
            this.salesCountDataGridViewTextBoxColumn.Width = 54;
            // 
            // salesTotalMoneyDataGridViewTextBoxColumn
            // 
            this.salesTotalMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesTotalMoneyDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalMoney";
            this.salesTotalMoneyDataGridViewTextBoxColumn.HeaderText = "销售总额";
            this.salesTotalMoneyDataGridViewTextBoxColumn.Name = "salesTotalMoneyDataGridViewTextBoxColumn";
            this.salesTotalMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesTotalMoneyDataGridViewTextBoxColumn.Width = 90;
            // 
            // salesActualRecvDataGridViewTextBoxColumn
            // 
            this.salesActualRecvDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesActualRecvDataGridViewTextBoxColumn.DataPropertyName = "SalesActualRecv";
            this.salesActualRecvDataGridViewTextBoxColumn.HeaderText = "实收额";
            this.salesActualRecvDataGridViewTextBoxColumn.Name = "salesActualRecvDataGridViewTextBoxColumn";
            this.salesActualRecvDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesActualRecvDataGridViewTextBoxColumn.ToolTipText = "销售总额 - 积分抵扣 -  vip赠送金额 - 优惠券金额";
            this.salesActualRecvDataGridViewTextBoxColumn.Width = 66;
            // 
            // salesTotalCostDataGridViewTextBoxColumn
            // 
            this.salesTotalCostDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesTotalCostDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalCost";
            this.salesTotalCostDataGridViewTextBoxColumn.HeaderText = "销售成本";
            this.salesTotalCostDataGridViewTextBoxColumn.Name = "salesTotalCostDataGridViewTextBoxColumn";
            this.salesTotalCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesTotalCostDataGridViewTextBoxColumn.Width = 90;
            // 
            // SalesBenefit
            // 
            this.SalesBenefit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SalesBenefit.DataPropertyName = "SalesBenefit";
            this.SalesBenefit.HeaderText = "毛利";
            this.SalesBenefit.Name = "SalesBenefit";
            this.SalesBenefit.ReadOnly = true;
            this.SalesBenefit.ToolTipText = "实收额 - 销售成本";
            this.SalesBenefit.Width = 54;
            // 
            // SalesVipContributionDataGridViewTextBoxColumn
            // 
            this.SalesVipContributionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SalesVipContributionDataGridViewTextBoxColumn.DataPropertyName = "SalesVipContribution";
            dataGridViewCellStyle1.Format = "P2";
            dataGridViewCellStyle1.NullValue = null;
            this.SalesVipContributionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SalesVipContributionDataGridViewTextBoxColumn.HeaderText = "VIP贡献率";
            this.SalesVipContributionDataGridViewTextBoxColumn.Name = "SalesVipContributionDataGridViewTextBoxColumn";
            this.SalesVipContributionDataGridViewTextBoxColumn.ReadOnly = true;
            this.SalesVipContributionDataGridViewTextBoxColumn.ToolTipText = "会员的销售额 / 销售总额";
            // 
            // SalesAverageDiscount
            // 
            this.SalesAverageDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SalesAverageDiscount.DataPropertyName = "SalesAverageDiscount";
            this.SalesAverageDiscount.HeaderText = "平均折扣";
            this.SalesAverageDiscount.Name = "SalesAverageDiscount";
            this.SalesAverageDiscount.ReadOnly = true;
            this.SalesAverageDiscount.ToolTipText = "销售总额 / 总金额";
            // 
            // salesTotalPriceDataGridViewTextBoxColumn
            // 
            this.salesTotalPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesTotalPriceDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalPrice";
            this.salesTotalPriceDataGridViewTextBoxColumn.HeaderText = "吊牌总额";
            this.salesTotalPriceDataGridViewTextBoxColumn.Name = "salesTotalPriceDataGridViewTextBoxColumn";
            this.salesTotalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesTotalPriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // salesJointRateDataGridViewTextBoxColumn
            // 
            this.salesJointRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesJointRateDataGridViewTextBoxColumn.DataPropertyName = "SalesJointRate";
            dataGridViewCellStyle2.Format = "P2";
            this.salesJointRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.salesJointRateDataGridViewTextBoxColumn.HeaderText = "连带率";
            this.salesJointRateDataGridViewTextBoxColumn.Name = "salesJointRateDataGridViewTextBoxColumn";
            this.salesJointRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesJointRateDataGridViewTextBoxColumn.ToolTipText = "销售总数 / 销售单数";
            this.salesJointRateDataGridViewTextBoxColumn.Width = 66;
            // 
            // salesPerMemberPayDataGridViewTextBoxColumn
            // 
            this.salesPerMemberPayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesPerMemberPayDataGridViewTextBoxColumn.DataPropertyName = "SalesPerMemberPay";
            this.salesPerMemberPayDataGridViewTextBoxColumn.HeaderText = "客单价";
            this.salesPerMemberPayDataGridViewTextBoxColumn.Name = "salesPerMemberPayDataGridViewTextBoxColumn";
            this.salesPerMemberPayDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesPerMemberPayDataGridViewTextBoxColumn.ToolTipText = "实收额 / 销售单数";
            this.salesPerMemberPayDataGridViewTextBoxColumn.Width = 66;
            // 
            // salesPerCostumePayDataGridViewTextBoxColumn
            // 
            this.salesPerCostumePayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.salesPerCostumePayDataGridViewTextBoxColumn.DataPropertyName = "SalesPerCostumePay";
            this.salesPerCostumePayDataGridViewTextBoxColumn.HeaderText = "物单价";
            this.salesPerCostumePayDataGridViewTextBoxColumn.Name = "salesPerCostumePayDataGridViewTextBoxColumn";
            this.salesPerCostumePayDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesPerCostumePayDataGridViewTextBoxColumn.ToolTipText = "实收额 / 销售总数";
            this.salesPerCostumePayDataGridViewTextBoxColumn.Width = 66;
            // 
            // refundRateDataGridViewTextBoxColumn
            // 
            this.refundRateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.refundRateDataGridViewTextBoxColumn.DataPropertyName = "RefundRate";
            dataGridViewCellStyle3.Format = "P2";
            this.refundRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.refundRateDataGridViewTextBoxColumn.HeaderText = "退货率";
            this.refundRateDataGridViewTextBoxColumn.Name = "refundRateDataGridViewTextBoxColumn";
            this.refundRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.refundRateDataGridViewTextBoxColumn.ToolTipText = "退货总数 / 销售总数";
            this.refundRateDataGridViewTextBoxColumn.Width = 66;
            // 
            // BenefitReportManageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "BenefitReportManageCtrl";
            this.Load += new System.EventHandler(this.DayBenefitReportManageCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.BindingSource reportBindingSource; 
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1; 
        private Common.Components.BaseButton BaseButton1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinComboBox skinComboBox_Time;
        private Components.BaseButton baseButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRecharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfRefundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesActualRecvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesBenefit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesVipContributionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesAverageDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesJointRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPerMemberPayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesPerCostumePayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refundRateDataGridViewTextBoxColumn;
    }
}
