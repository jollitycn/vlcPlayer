using CCWin.SkinControl;
using ESBasic.Widget;

namespace JGNet.Common
{
    partial class MonthBrandBenefitReportManageCtrl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinPanel1 = new System.Windows.Forms.Panel();
            this.BaseButton1 = new JGNet.Common.Components.BaseButton();
            this.skinComboBox_Shop = new  SkinComboBox();
            this.skinLabel11 = new CCWin.SkinControl.SkinLabel();
            this.dateTimePicker_End = new YearMonthPicker();
            this.dateTimePicker_Start = new YearMonthPicker();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfSaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityOfRefundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesTotalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesBenefit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BenefitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesAverageDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.reportBindingSource.DataSource = typeof(JGNet.BrandBenefitMonthReport);
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.BaseButton1);
            this.skinPanel1.Controls.Add(this.skinComboBox_Shop);
            this.skinPanel1.Controls.Add(this.skinLabel11);
            this.skinPanel1.Controls.Add(this.dateTimePicker_End);
            this.skinPanel1.Controls.Add(this.dateTimePicker_Start);
            this.skinPanel1.Controls.Add(this.skinLabel3);
            this.skinPanel1.Controls.Add(this.skinLabel2);
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPanel1.Location = new System.Drawing.Point(0, 0);
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.Size = new System.Drawing.Size(960, 39);
            this.skinPanel1.TabIndex = 0;
            // 
            // BaseButton1
            // 
            this.BaseButton1.BackColor = System.Drawing.Color.Transparent;
            this.BaseButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BaseButton1.DownBack = global::JGNet.Common.Properties.Resources.btnDownBack;
            this.BaseButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.BaseButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BaseButton1.Location = new System.Drawing.Point(549, 3);
            this.BaseButton1.MouseBack = global::JGNet.Common.Properties.Resources.btnMouseBack;
            this.BaseButton1.Name = "BaseButton1";
            this.BaseButton1.NormlBack = global::JGNet.Common.Properties.Resources.btnNormlBack;
            this.BaseButton1.Size = new System.Drawing.Size(75, 32);
            this.BaseButton1.TabIndex = 3;
            this.BaseButton1.Text = "查询";
            this.BaseButton1.UseVisualStyleBackColor = false;
            this.BaseButton1.Click += new System.EventHandler(this.BaseButton_Search_Click);
            // 
            // skinComboBox_Shop
            // 
            this.skinComboBox_Shop.DisplayMember = "AutoID";
            this.skinComboBox_Shop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_Shop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_Shop.FormattingEnabled = true;
            this.skinComboBox_Shop.Location = new System.Drawing.Point(41, 7);
            this.skinComboBox_Shop.Name = "skinComboBox_Shop";
            this.skinComboBox_Shop.Size = new System.Drawing.Size(130, 22);
            this.skinComboBox_Shop.TabIndex = 0;
            this.skinComboBox_Shop.ValueMember = "AutoID";
            this.skinComboBox_Shop.WaterText = "";
            this.skinComboBox_Shop.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_Brand_SelectedIndexChanged);
            // 
            // skinLabel11
            // 
            this.skinLabel11.AutoSize = true;
            this.skinLabel11.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel11.BorderColor = System.Drawing.Color.White;
            this.skinLabel11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel11.Location = new System.Drawing.Point(3, 10);
            this.skinLabel11.Name = "skinLabel11";
            this.skinLabel11.Size = new System.Drawing.Size(32, 17);
            this.skinLabel11.TabIndex = 16;
            this.skinLabel11.Text = "店铺";
            this.skinLabel11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.CustomFormat = "yyyy-MM";
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_End.Location = new System.Drawing.Point(401, 8);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.ShowUpDown = true;
            this.dateTimePicker_End.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_End.TabIndex = 2;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.CustomFormat = "yyyy-MM";
            this.dateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Start.Location = new System.Drawing.Point(215, 8);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.ShowUpDown = true;
            this.dateTimePicker_Start.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker_Start.TabIndex = 1;
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(363, 10);
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
            this.skinLabel2.Location = new System.Drawing.Point(177, 10);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 10;
            this.skinLabel2.Text = "开始";
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 39);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.skinSplitContainer1.Panel2Collapsed = true;
            this.skinSplitContainer1.Size = new System.Drawing.Size(960, 511);
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
            this.BrandName,
            this.quantityOfSaleDataGridViewTextBoxColumn,
            this.quantityOfRefundDataGridViewTextBoxColumn,
            this.salesTotalMoneyDataGridViewTextBoxColumn,
            this.salesTotalPriceDataGridViewTextBoxColumn,
            this.salesTotalCostDataGridViewTextBoxColumn,
            this.SalesBenefit,
            this.BenefitRate,
            this.SalesDiscount,
            this.SalesAverageDiscount,
            this.refundRateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.reportBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(960, 511);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // BrandName
            // 
            this.BrandName.DataPropertyName = "BrandName";
            this.BrandName.HeaderText = " 品牌 ";
            this.BrandName.Name = "BrandName";
            this.BrandName.ReadOnly = true;
            this.BrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // SalesBenefit
            // 
            this.SalesBenefit.DataPropertyName = "SalesBenefit";
            this.SalesBenefit.HeaderText = "毛利";
            this.SalesBenefit.Name = "SalesBenefit";
            this.SalesBenefit.ReadOnly = true;
            this.SalesBenefit.ToolTipText = "销售金额 - 销售成本";
            // 
            // BenefitRate
            // 
            this.BenefitRate.DataPropertyName = "BenefitRate";
            dataGridViewCellStyle3.Format = "P";
            this.BenefitRate.DefaultCellStyle = dataGridViewCellStyle3;
            this.BenefitRate.HeaderText = "毛利率";
            this.BenefitRate.Name = "BenefitRate";
            this.BenefitRate.ReadOnly = true;
            this.BenefitRate.ToolTipText = "毛利 / 销售金额";
            // 
            // SalesDiscount
            // 
            this.SalesDiscount.DataPropertyName = "SalesDiscount";
            this.SalesDiscount.HeaderText = "销售折扣";
            this.SalesDiscount.Name = "SalesDiscount";
            this.SalesDiscount.ReadOnly = true;
            this.SalesDiscount.ToolTipText = "销售金额 / 吊牌总额";
            // 
            // SalesAverageDiscount
            // 
            this.SalesAverageDiscount.DataPropertyName = "PurchaseDiscount";
            this.SalesAverageDiscount.HeaderText = "进货折扣";
            this.SalesAverageDiscount.Name = "SalesAverageDiscount";
            this.SalesAverageDiscount.ReadOnly = true;
            this.SalesAverageDiscount.ToolTipText = "销售成本 / 吊牌总额";
            // 
            // refundRateDataGridViewTextBoxColumn
            // 
            this.refundRateDataGridViewTextBoxColumn.DataPropertyName = "RefundRate";
            dataGridViewCellStyle4.Format = "P";
            this.refundRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.refundRateDataGridViewTextBoxColumn.HeaderText = "退货率";
            this.refundRateDataGridViewTextBoxColumn.Name = "refundRateDataGridViewTextBoxColumn";
            this.refundRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.refundRateDataGridViewTextBoxColumn.ToolTipText = "退货总数/销售总数";
            // 
            // MonthBrandBenefitReportManageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.skinPanel1);
            this.Name = "MonthBrandBenefitReportManageCtrl";
            this.Load += new System.EventHandler(this.BrandBenefitMonthReportManageCtrl_Load);
            this.VisibleChanged += new System.EventHandler(this.MonthBrandBenefitReportManageCtrl_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
           
            this.skinSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel skinPanel1;
        private YearMonthPicker dateTimePicker_End;
        private YearMonthPicker dateTimePicker_Start;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.BindingSource reportBindingSource; 
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1; 
        private SkinComboBox skinComboBox_Shop;
        private CCWin.SkinControl.SkinLabel skinLabel11;
        private Common.Components.BaseButton BaseButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfSaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityOfRefundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalMoneyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesTotalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesBenefit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BenefitRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesAverageDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn refundRateDataGridViewTextBoxColumn;
    }
}
