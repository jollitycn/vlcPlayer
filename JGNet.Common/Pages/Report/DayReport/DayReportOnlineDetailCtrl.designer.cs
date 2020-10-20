using JGNet.Common;

namespace JGNet.Common
{
    partial class DayReportOnlineDetailCtrl
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dayReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_QuantityOfRefund = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_QuantityOfSale = new CCWin.SkinControl.SkinLabel();
            this.skinLabelDate = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_shop = new CCWin.SkinControl.SkinLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.skinLabel_RefundCount = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_SalesCount = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new CCWin.SkinControl.SkinLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabelCostumeMoney = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabelCarriageCost = new CCWin.SkinControl.SkinLabel();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesInGiftTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dataGridView2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(0, 470);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1160, 180);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "营业收入";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.SalesInGiftTicket,
            this.Revenue});
            this.dataGridView2.DataSource = this.dayReportBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1154, 160);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // dayReportBindingSource
            // 
            this.dayReportBindingSource.DataSource = typeof(JGNet.DayReport);
            // 
            // skinLabel10
            // 
            this.skinLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel10.AutoSize = true;
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel10.Location = new System.Drawing.Point(453, 171);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(68, 17);
            this.skinLabel10.TabIndex = 177;
            this.skinLabel10.Text = "顾客退货：";
            // 
            // skinLabel3
            // 
            this.skinLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(619, 171);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(68, 17);
            this.skinLabel3.TabIndex = 154;
            this.skinLabel3.Text = "当日销售：";
            // 
            // skinLabel_QuantityOfRefund
            // 
            this.skinLabel_QuantityOfRefund.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel_QuantityOfRefund.AutoSize = true;
            this.skinLabel_QuantityOfRefund.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_QuantityOfRefund.BorderColor = System.Drawing.Color.White;
            this.skinLabel_QuantityOfRefund.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_QuantityOfRefund.Location = new System.Drawing.Point(528, 171);
            this.skinLabel_QuantityOfRefund.Name = "skinLabel_QuantityOfRefund";
            this.skinLabel_QuantityOfRefund.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.skinLabel_QuantityOfRefund.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_QuantityOfRefund.TabIndex = 178;
            this.skinLabel_QuantityOfRefund.Text = "000000";
            this.skinLabel_QuantityOfRefund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLabel_QuantityOfSale
            // 
            this.skinLabel_QuantityOfSale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel_QuantityOfSale.AutoSize = true;
            this.skinLabel_QuantityOfSale.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_QuantityOfSale.BorderColor = System.Drawing.Color.White;
            this.skinLabel_QuantityOfSale.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_QuantityOfSale.Location = new System.Drawing.Point(700, 171);
            this.skinLabel_QuantityOfSale.Name = "skinLabel_QuantityOfSale";
            this.skinLabel_QuantityOfSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.skinLabel_QuantityOfSale.Size = new System.Drawing.Size(50, 17);
            this.skinLabel_QuantityOfSale.TabIndex = 171;
            this.skinLabel_QuantityOfSale.Text = "000000";
            this.skinLabel_QuantityOfSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLabelDate
            // 
            this.skinLabelDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabelDate.AutoSize = true;
            this.skinLabelDate.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelDate.BorderColor = System.Drawing.Color.White;
            this.skinLabelDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelDate.Location = new System.Drawing.Point(620, 142);
            this.skinLabelDate.Name = "skinLabelDate";
            this.skinLabelDate.Size = new System.Drawing.Size(32, 17);
            this.skinLabelDate.TabIndex = 100;
            this.skinLabelDate.Text = "日期";
            // 
            // skinLabel_shop
            // 
            this.skinLabel_shop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel_shop.AutoSize = true;
            this.skinLabel_shop.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_shop.BorderColor = System.Drawing.Color.White;
            this.skinLabel_shop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_shop.Location = new System.Drawing.Point(453, 142);
            this.skinLabel_shop.Name = "skinLabel_shop";
            this.skinLabel_shop.Size = new System.Drawing.Size(32, 17);
            this.skinLabel_shop.TabIndex = 99;
            this.skinLabel_shop.Text = "店铺";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(JGNet.Core.InteractEntity.GuideAchievementSummary);
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            // 
            // skinLabel_RefundCount
            // 
            this.skinLabel_RefundCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel_RefundCount.AutoSize = true;
            this.skinLabel_RefundCount.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_RefundCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_RefundCount.Location = new System.Drawing.Point(700, 206);
            this.skinLabel_RefundCount.Name = "skinLabel_RefundCount";
            this.skinLabel_RefundCount.Size = new System.Drawing.Size(44, 17);
            this.skinLabel_RefundCount.TabIndex = 2;
            this.skinLabel_RefundCount.TabStop = true;
            this.skinLabel_RefundCount.Text = "操作人";
            this.skinLabel_RefundCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.skinLabel_RefundCount_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.BorderColor = System.Drawing.Color.White;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(620, 206);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(68, 17);
            this.linkLabel1.TabIndex = 150;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "退货单数：";
            // 
            // skinLabel_SalesCount
            // 
            this.skinLabel_SalesCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel_SalesCount.AutoSize = true;
            this.skinLabel_SalesCount.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_SalesCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_SalesCount.Location = new System.Drawing.Point(528, 206);
            this.skinLabel_SalesCount.Name = "skinLabel_SalesCount";
            this.skinLabel_SalesCount.Size = new System.Drawing.Size(32, 17);
            this.skinLabel_SalesCount.TabIndex = 1;
            this.skinLabel_SalesCount.TabStop = true;
            this.skinLabel_SalesCount.Text = "店铺";
            this.skinLabel_SalesCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.skinLabel_SalesCount_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.BorderColor = System.Drawing.Color.White;
            this.linkLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(453, 206);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(68, 17);
            this.linkLabel2.TabIndex = 148;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "成交单数：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.skinLabelDate);
            this.groupBox7.Controls.Add(this.linkLabel2);
            this.groupBox7.Controls.Add(this.skinLabel_shop);
            this.groupBox7.Controls.Add(this.skinLabel_SalesCount);
            this.groupBox7.Controls.Add(this.linkLabel1);
            this.groupBox7.Controls.Add(this.skinLabel5);
            this.groupBox7.Controls.Add(this.skinLabel10);
            this.groupBox7.Controls.Add(this.skinLabelCostumeMoney);
            this.groupBox7.Controls.Add(this.skinLabel_RefundCount);
            this.groupBox7.Controls.Add(this.skinLabel2);
            this.groupBox7.Controls.Add(this.skinLabel_QuantityOfRefund);
            this.groupBox7.Controls.Add(this.skinLabelCarriageCost);
            this.groupBox7.Controls.Add(this.skinLabel3);
            this.groupBox7.Controls.Add(this.skinLabel_QuantityOfSale);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1160, 470);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            // 
            // skinLabel5
            // 
            this.skinLabel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(453, 242);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(68, 17);
            this.skinLabel5.TabIndex = 177;
            this.skinLabel5.Text = "商品金额：";
            // 
            // skinLabelCostumeMoney
            // 
            this.skinLabelCostumeMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabelCostumeMoney.AutoSize = true;
            this.skinLabelCostumeMoney.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelCostumeMoney.BorderColor = System.Drawing.Color.White;
            this.skinLabelCostumeMoney.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelCostumeMoney.Location = new System.Drawing.Point(528, 242);
            this.skinLabelCostumeMoney.Name = "skinLabelCostumeMoney";
            this.skinLabelCostumeMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.skinLabelCostumeMoney.Size = new System.Drawing.Size(50, 17);
            this.skinLabelCostumeMoney.TabIndex = 178;
            this.skinLabelCostumeMoney.Text = "000000";
            this.skinLabelCostumeMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLabel2
            // 
            this.skinLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(643, 242);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(44, 17);
            this.skinLabel2.TabIndex = 154;
            this.skinLabel2.Text = "运费：";
            // 
            // skinLabelCarriageCost
            // 
            this.skinLabelCarriageCost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.skinLabelCarriageCost.AutoSize = true;
            this.skinLabelCarriageCost.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelCarriageCost.BorderColor = System.Drawing.Color.White;
            this.skinLabelCarriageCost.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelCarriageCost.Location = new System.Drawing.Point(700, 242);
            this.skinLabelCarriageCost.Name = "skinLabelCarriageCost";
            this.skinLabelCarriageCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.skinLabelCarriageCost.Size = new System.Drawing.Size(50, 17);
            this.skinLabelCarriageCost.TabIndex = 171;
            this.skinLabelCarriageCost.Text = "000000";
            this.skinLabelCarriageCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SalesInWeiXin";
            this.dataGridViewTextBoxColumn4.HeaderText = "微信";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SalesInVipBalance";
            this.dataGridViewTextBoxColumn6.HeaderText = "VIP卡付款";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 300;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SalesInVipIntegration";
            this.dataGridViewTextBoxColumn7.HeaderText = "VIP卡积分返现";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 300;
            // 
            // SalesInGiftTicket
            // 
            this.SalesInGiftTicket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SalesInGiftTicket.DataPropertyName = "SalesInGiftTicket";
            this.SalesInGiftTicket.HeaderText = "优惠券金额";
            this.SalesInGiftTicket.Name = "SalesInGiftTicket";
            this.SalesInGiftTicket.ReadOnly = true;
            this.SalesInGiftTicket.Width = 226;
            // 
            // Revenue
            // 
            this.Revenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revenue.DataPropertyName = "TotalRecharge";
            this.Revenue.HeaderText = "总额";
            this.Revenue.Name = "Revenue";
            this.Revenue.ReadOnly = true;
            this.Revenue.Width = 54;
            // 
            // DayReportOnlineDetailCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Name = "DayReportOnlineDetailCtrl";
            this.Leave += new System.EventHandler(this.DayReportOnlineDetailCtrl_Leave);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion 
        private System.Windows.Forms.BindingSource dayReportBindingSource;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private CCWin.SkinControl.SkinLabel skinLabel_shop;
        private CCWin.SkinControl.SkinLabel skinLabelDate;
        private CCWin.SkinControl.SkinLabel skinLabel_QuantityOfRefund;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private CCWin.SkinControl.SkinLabel skinLabel_QuantityOfSale;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private CCWin.SkinToolTip skinToolTip1;
        private System.Windows.Forms.LinkLabel skinLabel_RefundCount;
        private CCWin.SkinControl.SkinLabel linkLabel1;
        private System.Windows.Forms.LinkLabel skinLabel_SalesCount;
        private CCWin.SkinControl.SkinLabel linkLabel2;
        private System.Windows.Forms.GroupBox groupBox7;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabelCostumeMoney;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabelCarriageCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesInGiftTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revenue;
    }
}
