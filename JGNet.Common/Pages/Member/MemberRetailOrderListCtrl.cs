using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using CCWin.SkinControl;
using CJBasic;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using CJBasic.Helpers;
using JGNet.Core.Tools;
using JGNet.Core.Const;
using JGNet.Core;

namespace JGNet.Common
{
    public partial class MemberRetailOrderListCtrl : BaseForm
    {

        private bool isOnline;
        private RetailListPagePara pagePara;
        private bool showShop;
        public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private bool isRefundOrder;
        public CJBasic.Action<String, BaseUserControl> RefundDetailClick;
        public CJBasic.Action<String, BaseUserControl> RetailDetailClick;
        public CJBasic.Action<RetailOrder, BaseUserControl> RedoClick;
        private RetailOrder clipboardOrder;
        private string memberID;
        private int dateInt;
        private void RefundItem_Click(object sender, EventArgs e)
        {
            ReturnDetail(clipboardOrder);
        }
        private void RetailItem_Click(object sender, EventArgs e)
        {
            RetailDetail(clipboardOrder);
        }
        private RetailListPage ListPage { get; set; }
        public MemberRetailOrderListCtrl()
        {
            InitializeComponent();
            Init();
        }

        private void Init(bool hideOper = false)
        {
            this.dataGridView_RetailOrder.AutoGenerateColumns = false;
            dataGridView_RetailDetail.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView_RetailOrder, PageControlPanel21_CurrentPageIndexChanged, BaseButton_Search_Click,
                new String[] {
     MoneyCash.DataPropertyName,
     MoneyBankCard.DataPropertyName,
     MoneyWeiXin.DataPropertyName,
     MoneyAlipay.DataPropertyName,
     MoneyBuyByTicket.DataPropertyName,
     MoneyVipCard.DataPropertyName,
        totalCountDataGridViewTextBoxColumn.DataPropertyName,
                        totalPriceDataGridViewTextBoxColumn.DataPropertyName,
                        TotalMoneyReceivedActual.DataPropertyName,
                    CarriageCost.DataPropertyName,
                MoneyOtherColumn.DataPropertyName});
            dataGridViewPagingSumCtrl.Initialize();
           // SetUpOrderStrip(dataGridViewPagingSumCtrl.InnerContextMenuStrip);
            new DataGridViewPagingSumCtrl(dataGridView_RetailDetail).Initialize();
            if (hideOper)
            {
                //不分页
                dataGridViewPagingSumCtrl.Paging = false;
               // dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnRedo, ColumnRemove, ColumnPrint);
            }
         
            this.Initialize();
            MenuPermission = RolePermissionMenuEnum.会员管理;
        }

        internal void ShowDialog(string memberId,int dateInt)
        {
            this.memberID = memberId;
            this.dateInt = dateInt;
            Search();
            this.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <param name="showShop">只在POS端多加判断</param>
       /* public RetailOrderListCtrl(RetailListPagePara para, Boolean showShop = false)
        {
            InitializeComponent();
            Init(true);
            this.pagePara = para;
            if (pagePara.PageSize != 0)
            {
                dataGridViewPagingSumCtrl.PageSize = pagePara.PageSize;
            }
            this.showShop = showShop;

        }*/

        public void Search()
        {
            this.BaseButton_Search_Click(null, null);
        }

        public void BindingSource(RetailListPagePara pagePara, bool isOnline)
        {
           /* this.isOnline = isOnline;
            this.pagePara = pagePara;*/
            Search();
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        public void Initialize()
        {

            if (skinSplitContainer1 != null) { skinSplitContainer1.Panel2Collapsed = true; }
             
            if (CommonGlobalCache.BusinessAccount != null && CommonGlobalCache.BusinessAccount.OnlineEnabled)
            {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(CarriageCost);
            }
            else
            {
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(CarriageCost);
            }

            createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            if (dataGridViewPagingSumCtrl != null)
            {
                dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
                dataGridViewPagingSumCtrl.Clear();
            }
            this.dataGridView_RetailDetail.DataSource = null;
            this.pagePara = new RetailListPagePara();
            SetRetailOrderLabel(null);
        }

        /// <summary>
        /// 设置retailOrder对应的标签
        /// </summary>
        /// <param name="retailOrder"></param>
        private void SetRetailOrderLabel(RetailOrder retailOrder)
        {
            if (retailOrder == null)
            {
                this.skinLabel_MoneyCash.Text = "";
                this.skinLabel_MoneyStoredCard.Text = "";
                this.skinLabel_MoneyBankCard.Text = "";
                this.skinLabel_MoneyIntegration.Text = "";
                this.skinLabel_MoneyWeiXin.Text = "";
                this.skinLabel_MoneyAlipay.Text = "";
                this.skinLabelMoneyOther.Text = "";
                this.skinLabel_MoneyChange.Text = "";
                this.skinLabelReceivedActual.Text = "";
                skinLabel_SmallMoneyRemoved.Text = string.Empty;
                skinLabel_remark.Text = string.Empty;
                this.skinLabel_SalesPromotion.Text = string.Empty;
                skinLabelGiftTicket.Text = string.Empty;
            }
            else
            {
                skinLabel_SmallMoneyRemoved.Text = retailOrder.SmallMoneyRemoved.ToString();
                this.skinLabel_MoneyCash.Text = retailOrder.MoneyCash.ToString();
                this.skinLabel_MoneyStoredCard.Text = retailOrder.MoneyVipCard.ToString() + "(赠送" + retailOrder.MoneyVipCardDonate + ")";
                skinLabelReceivedActual.Text = retailOrder.TotalMoneyReceivedActual.ToString();
                this.skinLabel_MoneyBankCard.Text = retailOrder.MoneyBankCard.ToString();
                this.skinLabel_MoneyIntegration.Text = retailOrder.MoneyIntegration.ToString();
                this.skinLabel_MoneyWeiXin.Text = retailOrder.MoneyWeiXin.ToString();
                this.skinLabel_MoneyAlipay.Text = retailOrder.MoneyAlipay.ToString();
                this.skinLabelMoneyOther.Text = retailOrder.MoneyOther.ToString();
                this.skinLabel_MoneyChange.Text = retailOrder.MoneyChange.ToString();
                skinLabelGiftTicket.Text = retailOrder.MoneyDeductedByTicket.ToString();
                skinLabel_remark.Text = retailOrder.Remarks;
                if (String.IsNullOrEmpty(retailOrder.SalesPromotionID))
                {
                    this.skinLabel_SalesPromotion.Text = CommonGlobalUtil.COMBOBOX_NULL;
                }
                else
                {
                    this.skinLabel_SalesPromotion.Text = retailOrder.PromotionText;
                }
            }

            SetDisplay();
        }

        private void SetDisplay()
        {
            //isRefundOrder = (pagePara.RetailOrderType == RetailOrderType.RefundOrder);
           // isRefundOrder = (pagePara.RetailOrderType == RetailOrderType.RefundOrder);
            skinLabel14.Visible = !isRefundOrder;
            skinLabel16.Visible = !isRefundOrder;
            skinLabel19.Visible = !isRefundOrder;
            skinLabel1.Visible = !isRefundOrder;
            //促销活动 
            this.skinLabel_MoneyChange.Visible = !isRefundOrder;
            skinLabel_SalesPromotion.Visible = !isRefundOrder;
            skinLabel_SmallMoneyRemoved.Visible = !isRefundOrder;
            skinLabelGiftTicket.Visible = !isRefundOrder;
            this.groupBox1.Text = isRefundOrder ? "退款方式" : "付款方式";
        }

        /// <summary>
        /// 绑定RetailOrder数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingRetailOrderDataSource(List<RetailOrder>  memberRetailOrder)
        {
            this.dataGridViewPagingSumCtrl.BindingDataSource(memberRetailOrder);
        }

        private void PageControlPanel21_CurrentPageIndexChanged(int index)
        {
            if (this.pagePara == null)
            {
                return;
            }
            //            pagePara.PageIndex = index;
            string orderid="";
            List<RetailDetail>  ListItem = CommonGlobalCache.ServerProxy.GetRetailDetailList(orderid);
            // this.BindingRetailOrderDataSource();
        }

        /// <summary>
        /// 绑定RetailDetail数据源并设置下方的Label值
        /// </summary>
        private void BindingRetailDetailDataSourceAndCleanLabel(RetailOrder retailOrder)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            if (retailOrder == null || String.IsNullOrEmpty(retailOrder.ID))
            {
                this.dataGridView_RetailDetail.DataSource = null;
            }
            else
            {
                List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
                this.dataGridView_RetailDetail.DataSource = null;
                if (retailDetailList != null && retailDetailList.Count > 0)
                {
                    foreach (RetailDetail detail in retailDetailList)
                    {
                        detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                        detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                    }
                    this.dataGridView_RetailDetail.DataSource = retailDetailList;
                }
            }
            this.dataGridView_RetailDetail.Refresh();
            this.SetRetailOrderLabel(retailOrder);
        }

        //点击查询按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                this.skinSplitContainer1.Panel2Collapsed = true;
                // ListPage = CommonGlobalCache.ServerProxy.GetRetailListPage(pagePara);
                InteractResult<List<RetailOrder>> memberRetailOrder = CommonGlobalCache.ServerProxy.GetReatilOrders(memberID, dateInt);
               // this.dataGridViewPagingSumCtrl.Initialize();
                this.BindingRetailOrderDataSource(memberRetailOrder.Data);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void dataGridView_RetailOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
                if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
                DataGridViewRow row = dataGridView_RetailOrder.Rows[e.RowIndex];
                RetailOrder order = (RetailOrder)row.DataBoundItem;

                if (column_guideName.Index == e.ColumnIndex)
                {
                    e.Value = CommonGlobalCache.GetUserName(order.GuideID);
                }
                else if (shopIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
                {
                    if (isOnline)
                    {
                        e.Value = SystemDefault.onlineName;
                    }
                    else
                    {
                        e.Value = CommonGlobalCache.GetShopName(order.ShopID);
                    }
                }

            }
            catch { }
        }

        private void dataGridView_RetailOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }


        private void Redo(RetailOrder allocateOrder)
        {
           /* if (this.RedoClick != null)
            {
                this.RedoClick(allocateOrder, this);
            }*/
        }


        private RetailOrder editOrder;
        UpdateTimePara para;
        DateSelectForm form;
        private void form_ConfirmClick(DateTime datetime, DateSelectForm form)
        {
            
        }

     
         

       

        private void Print(RetailOrder retailOrder)
        {
            RefundOrderPrintUtil printHelper = new RefundOrderPrintUtil();
            List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
            foreach (var item in retailDetailList)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                // 显示自己设置的尺码组和对应的尺码列表
                item.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(item.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
            }

            RefundCostume retailCostume = new RefundCostume()
            {
                RefundDetailList = retailDetailList,
                RefundOrder = retailOrder,

            };
            int times = CommonGlobalUtil.ConvertToInt32(CommonGlobalCache.GetParameter(ParameterConfigKey.PrintCount).ParaValue);
            DataGridView dgv = deepCopyDataGridView();
            printHelper.Print(retailCostume, times, dgv);
        }

        internal void ShowPrintColumn(bool show)
        {
          //  ColumnPrint.Visible = show;
        }

        private void PrintRetail(RetailOrder retailOrder)
        {
            OrderPrintUtil printHelper = new OrderPrintUtil();
            List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
            foreach (var item in retailDetailList)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                // 显示自己设置的尺码组和对应的尺码列表
                item.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(item.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
            }

            RetailCostume retailCostume = new RetailCostume()
            {
                RetailDetailList = retailDetailList,
                RetailOrder = retailOrder
            };
            int times = CommonGlobalUtil.ConvertToInt32(CommonGlobalCache.GetParameter(ParameterConfigKey.PrintCount).ParaValue);
            DataGridView dgv = deepCopyDataGridView();
            printHelper.Print(retailCostume, times,dgv);
        }

        private DataGridView deepCopyDataGridView()
        {
            DataGridView dgvTmp = new DataGridView();

            dgvTmp.Name = "dgvTmp";
            this.Controls.Add(dgvTmp);
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行

            dgvTmp.AutoGenerateColumns = false;

            List<RetailDetail> listtb1 = DataGridViewUtil.BindingListToList<RetailDetail>(dataGridView_RetailDetail.DataSource);

            List<RetailDetail> tb2 = new List<RetailDetail>();
            int autoID = 0;
            foreach (RetailDetail idetail in listtb1)
            {
                RetailDetail tDetail = new RetailDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                autoID++;
                tDetail.PrintAutoID = autoID;
                tb2.Add(tDetail);

            }

            DataGridViewTextBoxColumn dgvColumnAuto = new DataGridViewTextBoxColumn();
            dgvColumnAuto.Name = "序列号";
            dgvColumnAuto.HeaderText = "序列号";
            dgvColumnAuto.Visible = true;
            dgvColumnAuto.DataPropertyName = "PrintAutoID";
            dgvTmp.Columns.Add(dgvColumnAuto);

            List<DataGridViewTextBoxColumn> listColumns = new List<DataGridViewTextBoxColumn>();

            for (int i = 0; i < dataGridView_RetailDetail.Columns.Count; i++)
            {
                dgvTmp.Columns.Add(dataGridView_RetailDetail.Columns[i].Name, dataGridView_RetailDetail.Columns[i].HeaderText);
                if (dataGridView_RetailDetail.Columns[i].DefaultCellStyle.Format.Contains("N")) //使导出Excel文档金额列可做SUM运算
                {
                    dgvTmp.Columns[i + 1].DefaultCellStyle.Format = dataGridView_RetailDetail.Columns[i].DefaultCellStyle.Format;

                }
                if (!dataGridView_RetailDetail.Columns[i].Visible)
                {
                    dgvTmp.Columns[i + 1].Visible = false;
                }
                dgvTmp.Columns[i + 1].DataPropertyName = dataGridView_RetailDetail.Columns[i].DataPropertyName;
                if (dataGridView_RetailDetail.Columns[i].HeaderText == "单价") { dgvTmp.Columns[i + 1].HeaderText = "吊牌价"; }
                else if (dataGridView_RetailDetail.Columns[i].HeaderText == "销售额") { dgvTmp.Columns[i + 1].HeaderText = "金额"; }
                else
                {
                    dgvTmp.Columns[i + 1].HeaderText = dataGridView_RetailDetail.Columns[i].HeaderText;
                }
                dgvTmp.Columns[i + 1].Tag = dataGridView_RetailDetail.Columns[i].Tag;
                dgvTmp.Columns[i + 1].Name = dataGridView_RetailDetail.Columns[i].Name;

            }
            dgvTmp.DataSource = tb2;


            return dgvTmp;
        }

        private void ReturnDetail(RetailOrder item)
        {
           /* SourceCtrlType.RefreshPageDisable = true;
            RefundDetailClick?.Invoke(item.RefundOrderID, this.SourceCtrlType);*/
        }

        private void RetailDetail(RetailOrder item)
        {
           /* SourceCtrlType.RefreshPageDisable = true;
            RetailDetailClick?.Invoke(item.OriginOrderID, this.SourceCtrlType);*/
        }

    

        private void RetailOrderListCtrl_Load(object sender, EventArgs e)
        {
            if (this.pagePara != null)
            {
                Search();
            }
        }

        DataGridViewRow currRow = null;
        private void dataGridView_RetailOrder_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            ///不重复提交  DataGridViewRow row = view.CurrentRow;
            if (row != null && row.Index > -1 && row != currRow)
            {
                RetailOrder item = (RetailOrder)row.DataBoundItem;
                isRefundOrder = item.IsRefundOrder ;
                SetDisplay();
                this.BindingRetailDetailDataSourceAndCleanLabel(item);
                currRow = row;
            }
        }

        private void dataGridView_RetailOrder_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                clipboardOrder = view.Rows[e.RowIndex].DataBoundItem as RetailOrder;
                if (clipboardOrder.IsRefundOrder)
                {
                    retailItem.Visible = !String.IsNullOrEmpty(clipboardOrder.OriginOrderID);
                    refundItem.Visible = false;
                }
                else
                {
                    retailItem.Visible = false;
                    refundItem.Visible = !String.IsNullOrEmpty(clipboardOrder.RefundOrderID);
                }
            }
        }

        ToolStripMenuItem retailItem;
        ToolStripMenuItem refundItem;

        private void SetUpOrderStrip(ContextMenuStrip strip)
        {
            retailItem = new ToolStripMenuItem();
            retailItem.Name = "retailItem";
            retailItem.Text = "查看销售单";
            retailItem.Click += RetailItem_Click;
            strip.Items.Add(retailItem);
            refundItem = new ToolStripMenuItem();
            refundItem.Name = "refundItem";
            refundItem.Text = "查看退货单";
            refundItem.Click += RefundItem_Click;
            strip.Items.Add(refundItem);
        }
    }
}
