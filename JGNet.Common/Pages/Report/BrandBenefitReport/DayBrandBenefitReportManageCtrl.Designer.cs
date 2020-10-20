namespace JGNet.Common
{
    partial class DayBrandBenefitReportManageCtrl
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
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinComboBox_Brand = new JGNet.Common.BrandComboBox();
            this.skinLabel11 = new CCWin.SkinControl.SkinLabel();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.brandNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfRefundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesBenefitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.benefitRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refundRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinPanel1.SuspendLayout();
            
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.AutoSize = true;
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.skinComboBox_Brand);
            this.skinPanel1.Controls.Add(this.skinLabel11);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(960, 36);
            this.skinPanel1.TabIndex = 0;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(549, 1);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 3;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinComboBox_Brand
            // 
            this.skinComboBox_Brand.DisplayMember = "Name";
            this.skinComboBox_Brand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Brand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Brand.FormattingEnabled = true;
            this.skinComboBox_Brand.Location = new System.Drawing.Point(41, 6);
            this.skinComboBox_Brand.Name = "skinComboBox_Brand";
            this.skinComboBox_Brand.Size = new System.Drawing.Size(130, 22);
            this.skinComboBox_Brand.TabIndex = 0;
            this.skinComboBox_Brand.ValueMember = "ID";
            this.skinComboBox_Brand.WaterText = "";
            this.skinComboBox_Brand.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_Brand_SelectedIndexChanged);
            // 
            // skinLabel11
            // 
            this.skinLabel11.AutoSize = true;
            this.skinLabel11.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel11.BorderColor = System.Drawing.Color.White;
            this.skinLabel11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel11.Location = new System.Drawing.Point(3, 9);
            this.skinLabel11.Name = "skinLabel11";
            this.skinLabel11.Size = new System.Drawing.Size(32, 17);
            this.skinLabel11.TabIndex = 14;
            this.skinLabel11.Text = "店铺";
            this.skinLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(401, 7);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_End.TabIndex = 2;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(215, 7);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 1;
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(363, 9);
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
            this.skinLabel2.Location = new System.Drawing.Point(177, 9);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 10;
            this.skinLabel2.Text = "开始";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 36);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.skinSplitContainer1.Panel2Collapsed = true;
            this.skinSplitContainer1.Size = new System.Drawing.Size(960, 514);
            this.skinSplitContainer1.SplitterDistance = 253;
            this.skinSplitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brandNameDataGridViewTextBoxColumn,
            this.quantityOfSaleDataGridViewTextBoxColumn,
            this.quantityOfRefundDataGridViewTextBoxColumn,
            this.salesTotalMoneyDataGridViewTextBoxColumn,
            this.salesTotalPriceDataGridViewTextBoxColumn,
            this.salesTotalCostDataGridViewTextBoxColumn,
            this.salesBenefitDataGridViewTextBoxColumn,
            this.benefitRateDataGridViewTextBoxColumn,
            this.salesDiscountDataGridViewTextBoxColumn,
            this.purchaseDiscountDataGridViewTextBoxColumn,
            this.refundRateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.reportBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(960, 514);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // reportBindingSource
            // 
            this.reportBindingSource.DataSource = typeof(JGNet.BrandBenefitDayReport);
            // 
            // brandNameDataGridViewTextBoxColumn
            // 
            this.brandNameDataGridViewTextBoxColumn.DataPropertyName = "BrandName";
            this.brandNameDataGridViewTextBoxColumn.HeaderText = " 品牌 ";
            this.brandNameDataGridViewTextBoxColumn.Name = "brandNameDataGridViewTextBoxColumn";
            this.brandNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.brandNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quantityOfSaleDataGridViewTextBoxColumn
            // 
            this.quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName = "QuantityOfSale";
            this.quantityOfSaleDataGridViewTextBoxColumn.HeaderText = "销售总数";
            this.quantityOfSaleDataGridViewTextBoxColumn.Name = "quantityOfSaleDataGridViewTextBoxColumn";
            this.quantityOfSaleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityOfRefundDataGridViewTextBoxColumn
            // 
            this.quantityOfRefundDataGridViewTextBoxColumn.DataPropertyName = "QuantityOfRefund";
            this.quantityOfRefundDataGridViewTextBoxColumn.HeaderText = "退货总数";
            this.quantityOfRefundDataGridViewTextBoxColumn.Name = "quantityOfRefundDataGridViewTextBoxColumn";
            this.quantityOfRefundDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salesTotalMoneyDataGridViewTextBoxColumn
            // 
            this.salesTotalMoneyDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalMoney";
            this.salesTotalMoneyDataGridViewTextBoxColumn.HeaderText = "销售金额";
            this.salesTotalMoneyDataGridViewTextBoxColumn.Name = "salesTotalMoneyDataGridViewTextBoxColumn";
            this.salesTotalMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salesTotalPriceDataGridViewTextBoxColumn
            // 
            this.salesTotalPriceDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalPrice";
            this.salesTotalPriceDataGridViewTextBoxColumn.HeaderText = "吊牌总额";
            this.salesTotalPriceDataGridViewTextBoxColumn.Name = "salesTotalPriceDataGridViewTextBoxColumn";
            this.salesTotalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salesTotalCostDataGridViewTextBoxColumn
            // 
            this.salesTotalCostDataGridViewTextBoxColumn.DataPropertyName = "SalesTotalCost";
            this.salesTotalCostDataGridViewTextBoxColumn.HeaderText = "销售成本";
            this.salesTotalCostDataGridViewTextBoxColumn.Name = "salesTotalCostDataGridViewTextBoxColumn";
            this.salesTotalCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salesBenefitDataGridViewTextBoxColumn
            // 
            this.salesBenefitDataGridViewTextBoxColumn.DataPropertyName = "SalesBenefit";
            this.salesBenefitDataGridViewTextBoxColumn.HeaderText = "毛利";
            this.salesBenefitDataGridViewTextBoxColumn.Name = "salesBenefitDataGridViewTextBoxColumn";
            this.salesBenefitDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesBenefitDataGridViewTextBoxColumn.ToolTipText = "销售金额 - 销售成本";
            // 
            // benefitRateDataGridViewTextBoxColumn
            // 
            this.benefitRateDataGridViewTextBoxColumn.DataPropertyName = "BenefitRate";
            dataGridViewCellStyle1.Format = "P";
            this.benefitRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.benefitRateDataGridViewTextBoxColumn.HeaderText = "毛利率";
            this.benefitRateDataGridViewTextBoxColumn.Name = "benefitRateDataGridViewTextBoxColumn";
            this.benefitRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.benefitRateDataGridViewTextBoxColumn.ToolTipText = "毛利 / 销售金额";
            // 
            // salesDiscountDataGridViewTextBoxColumn
            // 
            this.salesDiscountDataGridViewTextBoxColumn.DataPropertyName = "SalesDiscount";
            this.salesDiscountDataGridViewTextBoxColumn.HeaderText = "销售折扣";
            this.salesDiscountDataGridViewTextBoxColumn.Name = "salesDiscountDataGridViewTextBoxColumn";
            this.salesDiscountDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesDiscountDataGridViewTextBoxColumn.ToolTipText = "销售金额 / 吊牌总额";
            // 
            // purchaseDiscountDataGridViewTextBoxColumn
            // 
            this.purchaseDiscountDataGridViewTextBoxColumn.DataPropertyName = "PurchaseDiscount";
            this.purchaseDiscountDataGridViewTextBoxColumn.HeaderText = "进货折扣";
            this.purchaseDiscountDataGridViewTextBoxColumn.Name = "purchaseDiscountDataGridViewTextBoxColumn";
            this.purchaseDiscountDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseDiscountDataGridViewTextBoxColumn.ToolTipText = "销售成本 / 吊牌总额";
            // 
            // refundRateDataGridViewTextBoxColumn
            // 
            this.refundRateDataGridViewTextBoxColumn.DataPropertyName = "RefundRate";
            dataGridViewCellStyle2.Format = "P";
            this.refundRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.refundRateDataGridViewTextBoxColumn.HeaderText = "退货率";
            this.refundRateDataGridViewTextBoxColumn.Name = "refundRateDataGridViewTextBoxColumn";
            this.refundRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.refundRateDataGridViewTextBoxColumn.ToolTipText = "退货总数/销售总数";
            // 
            // DayBrandBenefitReportManageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "DayBrandBenefitReportManageCtrl";
            this.Load += new System.EventHandler(this.DayBrandBenefitReportManageCtrl_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
           
            this.skinSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
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
        private BrandComboBox skinComboBox_Brand;
        private CCWin.SkinControl.SkinLabel skinLabel11;
        private Common.Components.BaseButton BaseButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfRefundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesBenefitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn benefitRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refundRateDataGridViewTextBoxColumn;
    }
}
