namespace JGNet.Common
{
    partial class RefundOrderListCtrl
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
            this.skinSplitContainer1 = new CCWin.SkinControl.SkinSplitContainer();
            this.dataGridView_RefundOrder = new System.Windows.Forms.DataGridView();
            this.refundOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView_RefundDetail = new System.Windows.Forms.DataGridView();
            this.refundDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinLabel_MoneyWeiXin = new CCWin.SkinControl.SkinLabel();
            this.skinLabelReceivedActual = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_MoneyCash = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_MoneyBankCard = new CCWin.SkinControl.SkinLabel();
            this.skinLabel8 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_MoneyAlipay = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_MoneyIntegration = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_MoneyStoredCard = new CCWin.SkinControl.SkinLabel();
            this.skinLabel11 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel12 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel13 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel14 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel16 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel15 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_remark = new CCWin.SkinControl.SkinLabel();
            this.skinLabelElse = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_PromotionIllustration = new CCWin.SkinControl.SkinLabel();
            this.costumeClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memeberIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoneyReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guideIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costumeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumMoneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinSplitContainer1.Panel1.SuspendLayout();
            this.skinSplitContainer1.Panel2.SuspendLayout();
            this.skinSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refundOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refundDetailBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costumeClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skinSplitContainer1
            // 
            this.skinSplitContainer1.CollapsePanel = CCWin.SkinControl.CollapsePanel.Panel2;
            this.skinSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.skinSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.skinSplitContainer1.Name = "skinSplitContainer1";
            this.skinSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // skinSplitContainer1.Panel1
            // 
            this.skinSplitContainer1.Panel1.Controls.Add(this.dataGridView_RefundOrder);
            // 
            // skinSplitContainer1.Panel2
            // 
            this.skinSplitContainer1.Panel2.Controls.Add(this.dataGridView_RefundDetail);
            this.skinSplitContainer1.Size = new System.Drawing.Size(1160, 572);
            this.skinSplitContainer1.SplitterDistance = 339;
            this.skinSplitContainer1.TabIndex = 11;
            // 
            // dataGridView_RefundOrder
            // 
            this.dataGridView_RefundOrder.AllowUserToAddRows = false;
            this.dataGridView_RefundOrder.AllowUserToDeleteRows = false;
            this.dataGridView_RefundOrder.AutoGenerateColumns = false;
            this.dataGridView_RefundOrder.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_RefundOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.OriginOrderID,
            this.shopIDDataGridViewTextBoxColumn,
            this.memeberIDDataGridViewTextBoxColumn,
            this.totalCountDataGridViewTextBoxColumn,
            this.TotalMoneyReceived,
            this.guideIDDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.StateName});
            this.dataGridView_RefundOrder.DataSource = this.refundOrderBindingSource;
            this.dataGridView_RefundOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RefundOrder.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_RefundOrder.MultiSelect = false;
            this.dataGridView_RefundOrder.Name = "dataGridView_RefundOrder";
            this.dataGridView_RefundOrder.ReadOnly = true;
            this.dataGridView_RefundOrder.RowTemplate.Height = 23;
            this.dataGridView_RefundOrder.Size = new System.Drawing.Size(1160, 339);
            this.dataGridView_RefundOrder.TabIndex = 0;
            this.dataGridView_RefundOrder.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_RefundOrder_CellFormatting);
            this.dataGridView_RefundOrder.SelectionChanged += new System.EventHandler(this.dataGridView_RefundOrder_SelectionChanged);
            // 
            // refundOrderBindingSource
            // 
            this.refundOrderBindingSource.DataSource = typeof(JGNet.RetailOrder);
            // 
            // dataGridView_RefundDetail
            // 
            this.dataGridView_RefundDetail.AllowUserToAddRows = false;
            this.dataGridView_RefundDetail.AllowUserToDeleteRows = false;
            this.dataGridView_RefundDetail.AutoGenerateColumns = false;
            this.dataGridView_RefundDetail.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_RefundDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.costumeIDDataGridViewTextBoxColumn,
            this.CostumeName,
            this.colorNameDataGridViewTextBoxColumn,
            this.sizeNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.buyCountDataGridViewTextBoxColumn,
            this.sumMoneyDataGridViewTextBoxColumn});
            this.dataGridView_RefundDetail.DataSource = this.refundDetailBindingSource;
            this.dataGridView_RefundDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RefundDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_RefundDetail.MultiSelect = false;
            this.dataGridView_RefundDetail.Name = "dataGridView_RefundDetail";
            this.dataGridView_RefundDetail.ReadOnly = true;
            this.dataGridView_RefundDetail.RowTemplate.Height = 23;
            this.dataGridView_RefundDetail.Size = new System.Drawing.Size(1160, 229);
            this.dataGridView_RefundDetail.TabIndex = 1;
            // 
            // refundDetailBindingSource
            // 
            this.refundDetailBindingSource.DataSource = typeof(JGNet.RetailDetail);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skinLabel_MoneyWeiXin);
            this.groupBox1.Controls.Add(this.skinLabelReceivedActual);
            this.groupBox1.Controls.Add(this.skinLabel_MoneyCash);
            this.groupBox1.Controls.Add(this.skinLabel_MoneyBankCard);
            this.groupBox1.Controls.Add(this.skinLabel8);
            this.groupBox1.Controls.Add(this.skinLabel5);
            this.groupBox1.Controls.Add(this.skinLabel_MoneyAlipay);
            this.groupBox1.Controls.Add(this.skinLabel_MoneyIntegration);
            this.groupBox1.Controls.Add(this.skinLabel_MoneyStoredCard);
            this.groupBox1.Controls.Add(this.skinLabel11);
            this.groupBox1.Controls.Add(this.skinLabel12);
            this.groupBox1.Controls.Add(this.skinLabel13);
            this.groupBox1.Controls.Add(this.skinLabel14);
            this.groupBox1.Controls.Add(this.skinLabel16);
            this.groupBox1.Controls.Add(this.skinLabel15);
            this.groupBox1.Controls.Add(this.skinLabel_remark);
            this.groupBox1.Controls.Add(this.skinLabelElse);
            this.groupBox1.Controls.Add(this.skinLabel2);
            this.groupBox1.Controls.Add(this.skinLabel_PromotionIllustration);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 572);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 78);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退款方式";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // skinLabel_MoneyWeiXin
            // 
            this.skinLabel_MoneyWeiXin.AutoSize = true;
            this.skinLabel_MoneyWeiXin.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyWeiXin.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyWeiXin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyWeiXin.Location = new System.Drawing.Point(376, 25);
            this.skinLabel_MoneyWeiXin.Name = "skinLabel_MoneyWeiXin";
            this.skinLabel_MoneyWeiXin.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_MoneyWeiXin.TabIndex = 17;
            this.skinLabel_MoneyWeiXin.Text = "000000";
            // 
            // skinLabelReceivedActual
            // 
            this.skinLabelReceivedActual.AutoSize = true;
            this.skinLabelReceivedActual.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelReceivedActual.BorderColor = System.Drawing.Color.White;
            this.skinLabelReceivedActual.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelReceivedActual.ForeColor = System.Drawing.Color.Blue;
            this.skinLabelReceivedActual.Location = new System.Drawing.Point(75, 25);
            this.skinLabelReceivedActual.Name = "skinLabelReceivedActual";
            this.skinLabelReceivedActual.Size = new System.Drawing.Size(50, 17);
            this.skinLabelReceivedActual.TabIndex = 18;
            this.skinLabelReceivedActual.Text = "000000";
            // 
            // skinLabel_MoneyCash
            // 
            this.skinLabel_MoneyCash.AutoSize = true;
            this.skinLabel_MoneyCash.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyCash.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyCash.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyCash.Location = new System.Drawing.Point(169, 25);
            this.skinLabel_MoneyCash.Name = "skinLabel_MoneyCash";
            this.skinLabel_MoneyCash.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_MoneyCash.TabIndex = 19;
            this.skinLabel_MoneyCash.Text = "000000";
            // 
            // skinLabel_MoneyBankCard
            // 
            this.skinLabel_MoneyBankCard.AutoSize = true;
            this.skinLabel_MoneyBankCard.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyBankCard.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyBankCard.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyBankCard.Location = new System.Drawing.Point(272, 25);
            this.skinLabel_MoneyBankCard.Name = "skinLabel_MoneyBankCard";
            this.skinLabel_MoneyBankCard.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_MoneyBankCard.TabIndex = 20;
            this.skinLabel_MoneyBankCard.Text = "000000";
            // 
            // skinLabel8
            // 
            this.skinLabel8.AutoSize = true;
            this.skinLabel8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel8.BorderColor = System.Drawing.Color.White;
            this.skinLabel8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel8.Location = new System.Drawing.Point(339, 25);
            this.skinLabel8.Name = "skinLabel8";
            this.skinLabel8.Size = new System.Drawing.Size(44, 17);
            this.skinLabel8.TabIndex = 10;
            this.skinLabel8.Text = "微信：";
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(552, 25);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(68, 17);
            this.skinLabel5.TabIndex = 11;
            this.skinLabel5.Text = "积分返现：";
            // 
            // skinLabel_MoneyAlipay
            // 
            this.skinLabel_MoneyAlipay.AutoSize = true;
            this.skinLabel_MoneyAlipay.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyAlipay.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyAlipay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyAlipay.Location = new System.Drawing.Point(496, 25);
            this.skinLabel_MoneyAlipay.Name = "skinLabel_MoneyAlipay";
            this.skinLabel_MoneyAlipay.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_MoneyAlipay.TabIndex = 21;
            this.skinLabel_MoneyAlipay.Text = "000000";
            // 
            // skinLabel_MoneyIntegration
            // 
            this.skinLabel_MoneyIntegration.AutoSize = true;
            this.skinLabel_MoneyIntegration.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyIntegration.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyIntegration.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyIntegration.Location = new System.Drawing.Point(620, 25);
            this.skinLabel_MoneyIntegration.Name = "skinLabel_MoneyIntegration";
            this.skinLabel_MoneyIntegration.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_MoneyIntegration.TabIndex = 22;
            this.skinLabel_MoneyIntegration.Text = "000000";
            // 
            // skinLabel_MoneyStoredCard
            // 
            this.skinLabel_MoneyStoredCard.AutoSize = true;
            this.skinLabel_MoneyStoredCard.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_MoneyStoredCard.BorderColor = System.Drawing.Color.White;
            this.skinLabel_MoneyStoredCard.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_MoneyStoredCard.Location = new System.Drawing.Point(721, 25);
            this.skinLabel_MoneyStoredCard.Name = "skinLabel_MoneyStoredCard";
            this.skinLabel_MoneyStoredCard.Size = new System.Drawing.Size(101, 17);
            this.skinLabel_MoneyStoredCard.TabIndex = 23;
            this.skinLabel_MoneyStoredCard.Text = "559（赠送44.2）";
            // 
            // skinLabel11
            // 
            this.skinLabel11.AutoSize = true;
            this.skinLabel11.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel11.BorderColor = System.Drawing.Color.White;
            this.skinLabel11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel11.Location = new System.Drawing.Point(445, 25);
            this.skinLabel11.Name = "skinLabel11";
            this.skinLabel11.Size = new System.Drawing.Size(56, 17);
            this.skinLabel11.TabIndex = 12;
            this.skinLabel11.Text = "支付宝：";
            // 
            // skinLabel12
            // 
            this.skinLabel12.AutoSize = true;
            this.skinLabel12.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel12.BorderColor = System.Drawing.Color.White;
            this.skinLabel12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel12.Location = new System.Drawing.Point(676, 25);
            this.skinLabel12.Name = "skinLabel12";
            this.skinLabel12.Size = new System.Drawing.Size(51, 17);
            this.skinLabel12.TabIndex = 13;
            this.skinLabel12.Text = "VIP卡：";
            // 
            // skinLabel13
            // 
            this.skinLabel13.AutoSize = true;
            this.skinLabel13.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel13.BorderColor = System.Drawing.Color.White;
            this.skinLabel13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel13.Location = new System.Drawing.Point(225, 25);
            this.skinLabel13.Name = "skinLabel13";
            this.skinLabel13.Size = new System.Drawing.Size(56, 17);
            this.skinLabel13.TabIndex = 14;
            this.skinLabel13.Text = "银联卡：";
            // 
            // skinLabel14
            // 
            this.skinLabel14.AutoSize = true;
            this.skinLabel14.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel14.BorderColor = System.Drawing.Color.White;
            this.skinLabel14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel14.ForeColor = System.Drawing.Color.Blue;
            this.skinLabel14.Location = new System.Drawing.Point(36, 25);
            this.skinLabel14.Name = "skinLabel14";
            this.skinLabel14.Size = new System.Drawing.Size(44, 17);
            this.skinLabel14.TabIndex = 15;
            this.skinLabel14.Text = "实收：";
            // 
            // skinLabel16
            // 
            this.skinLabel16.AutoSize = true;
            this.skinLabel16.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel16.BorderColor = System.Drawing.Color.White;
            this.skinLabel16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel16.Location = new System.Drawing.Point(131, 25);
            this.skinLabel16.Name = "skinLabel16";
            this.skinLabel16.Size = new System.Drawing.Size(44, 17);
            this.skinLabel16.TabIndex = 16;
            this.skinLabel16.Text = "现金：";
            // 
            // skinLabel15
            // 
            this.skinLabel15.AutoSize = true;
            this.skinLabel15.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel15.BorderColor = System.Drawing.Color.White;
            this.skinLabel15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel15.Location = new System.Drawing.Point(36, 51);
            this.skinLabel15.Name = "skinLabel15";
            this.skinLabel15.Size = new System.Drawing.Size(44, 17);
            this.skinLabel15.TabIndex = 8;
            this.skinLabel15.Text = "备注：";
            // 
            // skinLabel_remark
            // 
            this.skinLabel_remark.AutoSize = true;
            this.skinLabel_remark.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_remark.BorderColor = System.Drawing.Color.White;
            this.skinLabel_remark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_remark.Location = new System.Drawing.Point(82, 51);
            this.skinLabel_remark.Name = "skinLabel_remark";
            this.skinLabel_remark.Size = new System.Drawing.Size(32, 17);
            this.skinLabel_remark.TabIndex = 9;
            this.skinLabel_remark.Text = "备注";
            // 
            // skinLabelElse
            // 
            this.skinLabelElse.AutoSize = true;
            this.skinLabelElse.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelElse.BorderColor = System.Drawing.Color.White;
            this.skinLabelElse.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelElse.Location = new System.Drawing.Point(869, 25);
            this.skinLabelElse.Name = "skinLabelElse";
            this.skinLabelElse.Size = new System.Drawing.Size(0, 17);
            this.skinLabelElse.TabIndex = 5;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(828, 25);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(44, 17);
            this.skinLabel2.TabIndex = 4;
            this.skinLabel2.Text = "其他：";
            // 
            // skinLabel_PromotionIllustration
            // 
            this.skinLabel_PromotionIllustration.AutoSize = true;
            this.skinLabel_PromotionIllustration.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_PromotionIllustration.BorderColor = System.Drawing.Color.White;
            this.skinLabel_PromotionIllustration.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_PromotionIllustration.Location = new System.Drawing.Point(12, 25);
            this.skinLabel_PromotionIllustration.Name = "skinLabel_PromotionIllustration";
            this.skinLabel_PromotionIllustration.Size = new System.Drawing.Size(0, 17);
            this.skinLabel_PromotionIllustration.TabIndex = 3;
            // 
            // costumeClassBindingSource
            // 
            this.costumeClassBindingSource.DataSource = typeof(JGNet.CostumeClass);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "单据编号";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iDDataGridViewTextBoxColumn.Width = 140;
            // 
            // OriginOrderID
            // 
            this.OriginOrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OriginOrderID.DataPropertyName = "OriginOrderID";
            this.OriginOrderID.HeaderText = "相关销售单";
            this.OriginOrderID.Name = "OriginOrderID";
            this.OriginOrderID.ReadOnly = true;
            this.OriginOrderID.Width = 140;
            // 
            // shopIDDataGridViewTextBoxColumn
            // 
            this.shopIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.shopIDDataGridViewTextBoxColumn.DataPropertyName = "ShopID";
            this.shopIDDataGridViewTextBoxColumn.HeaderText = "店铺";
            this.shopIDDataGridViewTextBoxColumn.Name = "shopIDDataGridViewTextBoxColumn";
            this.shopIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.shopIDDataGridViewTextBoxColumn.Width = 140;
            // 
            // memeberIDDataGridViewTextBoxColumn
            // 
            this.memeberIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.memeberIDDataGridViewTextBoxColumn.DataPropertyName = "MemeberID";
            this.memeberIDDataGridViewTextBoxColumn.HeaderText = "会员卡号";
            this.memeberIDDataGridViewTextBoxColumn.Name = "memeberIDDataGridViewTextBoxColumn";
            this.memeberIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.memeberIDDataGridViewTextBoxColumn.Width = 140;
            // 
            // totalCountDataGridViewTextBoxColumn
            // 
            this.totalCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.totalCountDataGridViewTextBoxColumn.DataPropertyName = "TotalCount";
            this.totalCountDataGridViewTextBoxColumn.HeaderText = "总数量";
            this.totalCountDataGridViewTextBoxColumn.Name = "totalCountDataGridViewTextBoxColumn";
            this.totalCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalCountDataGridViewTextBoxColumn.Width = 125;
            // 
            // TotalMoneyReceived
            // 
            this.TotalMoneyReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalMoneyReceived.DataPropertyName = "TotalMoneyReceived";
            this.TotalMoneyReceived.HeaderText = "总金额";
            this.TotalMoneyReceived.Name = "TotalMoneyReceived";
            this.TotalMoneyReceived.ReadOnly = true;
            this.TotalMoneyReceived.Width = 124;
            // 
            // guideIDDataGridViewTextBoxColumn
            // 
            this.guideIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.guideIDDataGridViewTextBoxColumn.DataPropertyName = "GuideID";
            this.guideIDDataGridViewTextBoxColumn.HeaderText = "导购员";
            this.guideIDDataGridViewTextBoxColumn.Name = "guideIDDataGridViewTextBoxColumn";
            this.guideIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.guideIDDataGridViewTextBoxColumn.Width = 124;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "开单日期";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.createTimeDataGridViewTextBoxColumn.Width = 124;
            // 
            // StateName
            // 
            this.StateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StateName.DataPropertyName = "StateName";
            this.StateName.HeaderText = "状态";
            this.StateName.Name = "StateName";
            this.StateName.ReadOnly = true;
            this.StateName.Width = 54;
            // 
            // costumeIDDataGridViewTextBoxColumn
            // 
            this.costumeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.costumeIDDataGridViewTextBoxColumn.DataPropertyName = "CostumeID";
            this.costumeIDDataGridViewTextBoxColumn.HeaderText = "款号";
            this.costumeIDDataGridViewTextBoxColumn.Name = "costumeIDDataGridViewTextBoxColumn";
            this.costumeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.costumeIDDataGridViewTextBoxColumn.Width = 180;
            // 
            // CostumeName
            // 
            this.CostumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CostumeName.DataPropertyName = "CostumeName";
            this.CostumeName.HeaderText = "商品名称";
            this.CostumeName.Name = "CostumeName";
            this.CostumeName.ReadOnly = true;
            this.CostumeName.Width = 180;
            // 
            // colorNameDataGridViewTextBoxColumn
            // 
            this.colorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colorNameDataGridViewTextBoxColumn.DataPropertyName = "ColorName";
            this.colorNameDataGridViewTextBoxColumn.HeaderText = "颜色";
            this.colorNameDataGridViewTextBoxColumn.Name = "colorNameDataGridViewTextBoxColumn";
            this.colorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // sizeNameDataGridViewTextBoxColumn
            // 
            this.sizeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sizeNameDataGridViewTextBoxColumn.DataPropertyName = "SizeDisplayName";
            this.sizeNameDataGridViewTextBoxColumn.HeaderText = "尺码";
            this.sizeNameDataGridViewTextBoxColumn.Name = "sizeNameDataGridViewTextBoxColumn";
            this.sizeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sizeNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "吊牌价";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 160;
            // 
            // buyCountDataGridViewTextBoxColumn
            // 
            this.buyCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.buyCountDataGridViewTextBoxColumn.DataPropertyName = "BuyCount";
            this.buyCountDataGridViewTextBoxColumn.HeaderText = "数量";
            this.buyCountDataGridViewTextBoxColumn.Name = "buyCountDataGridViewTextBoxColumn";
            this.buyCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.buyCountDataGridViewTextBoxColumn.Width = 159;
            // 
            // sumMoneyDataGridViewTextBoxColumn
            // 
            this.sumMoneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sumMoneyDataGridViewTextBoxColumn.DataPropertyName = "SumMoney";
            this.sumMoneyDataGridViewTextBoxColumn.HeaderText = "金额";
            this.sumMoneyDataGridViewTextBoxColumn.Name = "sumMoneyDataGridViewTextBoxColumn";
            this.sumMoneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumMoneyDataGridViewTextBoxColumn.Width = 54;
            // 
            // RefundOrderListCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinSplitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Name = "RefundOrderListCtrl";
            this.Load += new System.EventHandler(this.RefundOrderListCtrl_Load);
            this.skinSplitContainer1.Panel1.ResumeLayout(false);
            this.skinSplitContainer1.Panel2.ResumeLayout(false);
            this.skinSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refundOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RefundDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refundDetailBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costumeClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource refundDetailBindingSource;
        private System.Windows.Forms.BindingSource refundOrderBindingSource;
        private System.Windows.Forms.BindingSource costumeClassBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private CCWin.SkinControl.SkinLabel skinLabel15;
        private CCWin.SkinControl.SkinLabel skinLabel_remark;
        private CCWin.SkinControl.SkinLabel skinLabel_PromotionIllustration;
        private CCWin.SkinControl.SkinSplitContainer skinSplitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_RefundOrder;
        private System.Windows.Forms.DataGridView dataGridView_RefundDetail;
        private CCWin.SkinControl.SkinLabel skinLabelElse;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyWeiXin;
        private CCWin.SkinControl.SkinLabel skinLabelReceivedActual;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyCash;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyBankCard;
        private CCWin.SkinControl.SkinLabel skinLabel8;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyAlipay;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyIntegration;
        private CCWin.SkinControl.SkinLabel skinLabel_MoneyStoredCard;
        private CCWin.SkinControl.SkinLabel skinLabel11;
        private CCWin.SkinControl.SkinLabel skinLabel12;
        private CCWin.SkinControl.SkinLabel skinLabel13;
        private CCWin.SkinControl.SkinLabel skinLabel14;
        private CCWin.SkinControl.SkinLabel skinLabel16;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memeberIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoneyReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn guideIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn costumeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostumeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumMoneyDataGridViewTextBoxColumn;
    }
}
