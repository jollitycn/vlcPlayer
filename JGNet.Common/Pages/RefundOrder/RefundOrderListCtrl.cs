using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using CJBasic;
using JGNet.Core.InteractEntity;
using CCWin;
using CJBasic.Loggers;
using JGNet.Common.Core;  
using JGNet.Common.Components;

namespace JGNet.Common
{
    public partial class RefundOrderListCtrl : BaseModifyUserControl
    {
         
        private RefundListPagePara pagePara;
        private List<RetailOrder> refundOrderList;
        public CJBasic.Action<RetailOrder, BaseUserControl> DetailClick;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrlDetail;
        private DataGridViewRow currRow;

        public void Search(RefundListPagePara pagePara)
        {
            this.pagePara = pagePara;
            this.BaseButton_Search_Click(null, null);
        }

        public RefundOrderListCtrl()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView_RefundOrder, PageControlPanel21_CurrentPageIndexChanged,BaseButton_Search_Click, new string[] { totalCountDataGridViewTextBoxColumn.DataPropertyName, TotalMoneyReceived.DataPropertyName});
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView_RefundOrder_SelectionChanged;
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            this.dataGridViewPagingSumCtrlDetail = new DataGridViewPagingSumCtrl(this.dataGridView_RefundDetail, new string[] { buyCountDataGridViewTextBoxColumn.DataPropertyName, sumMoneyDataGridViewTextBoxColumn.DataPropertyName });
            dataGridViewPagingSumCtrlDetail.Initialize();
        }
        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }
        private void Initialize()
        { 
            this.pagePara = new RefundListPagePara(); 
            this.refundOrderList = null;

            createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
                this.BindingRefundOrderDataSource(null);
          this.BindingRefundDetailDataSource(null); 
           
            SetRetailOrderLabel(null);

        }

        private void PageControlPanel21_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                if (this.pagePara == null)
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                RefundListPage listPage = CommonGlobalCache.ServerProxy.GetRefundListPage(this.pagePara);
                this.BindingRefundOrderDataSource(listPage);
                this.BindingRefundDetailDataSource(null);
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }


                RefundListPage listPage = CommonGlobalCache.ServerProxy.GetRefundListPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingRefundOrderDataSource(listPage);
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }


        }

        /// <summary>
        /// 绑定RefundOrder数据源
        /// </summary>
        private void BindingRefundOrderDataSource(RefundListPage listPage)
        {
            this.skinSplitContainer1.Panel2Collapsed = true; 
            dataGridViewPagingSumCtrl.BindingDataSource(listPage?.ResultList,null, listPage?.TotalEntityCount);
        }


        /// <summary>
        /// 绑定RefundDetail数据源
        /// </summary>
        private void BindingRefundDetailDataSource(RetailOrder refundOrder)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            if (refundOrder == null || String.IsNullOrEmpty(refundOrder.ID))
            { 
                this.dataGridView_RefundDetail.DataSource = null;
            }
            else
            {
                List<RetailDetail> refundDetailList = CommonGlobalCache.ServerProxy.GetRefundDetailList(refundOrder.ID);
                this.dataGridView_RefundDetail.DataSource = null;
                if (refundDetailList != null && refundDetailList.Count > 0)
                {
                    foreach (RetailDetail detail in refundDetailList)
                    {
                        detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                        detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                    }
                    dataGridViewPagingSumCtrlDetail.BindingDataSource(refundDetailList); //   this.dataGridView_RefundDetail.DataSource = refundDetailList;
                }

                
            }
            this.dataGridView_RefundDetail.Refresh();
         }
        /// <summary>
        /// 设置retailOrder对应的标签
        /// </summary>
        /// <param name="retailOrder"></param>
        private void SetRetailOrderLabel(RetailOrder retailOrder)
        {
            if (retailOrder == null)
            {
                this.skinLabel_MoneyIntegration.Text = string.Empty;
                this.skinLabel_MoneyBankCard.Text = string.Empty;
                this.skinLabel_MoneyWeiXin.Text = string.Empty;
                this.skinLabel_MoneyAlipay.Text = string.Empty;
                this.skinLabelReceivedActual.Text = string.Empty;
                skinLabel_remark.Text = string.Empty;
                this.skinLabelElse.Text = String.Empty;
                skinLabel_remark.Text = string.Empty;
                this.skinLabel_MoneyCash.Text = string.Empty;
                skinLabel_MoneyStoredCard.Text = string.Empty;
                //  this.skinLabel_RefundAll.Text = string.Empty;
            }
            else
            {
                this.skinLabel_MoneyIntegration.Text = retailOrder.MoneyIntegration.ToString();
                this.skinLabel_MoneyCash.Text = retailOrder.MoneyCash.ToString();
                this.skinLabel_MoneyStoredCard.Text = retailOrder.MoneyVipCard.ToString() + "(赠送" + retailOrder.MoneyVipCardDonate + ")";
                skinLabelReceivedActual.Text = retailOrder.TotalMoneyReceivedActual.ToString();
                this.skinLabel_MoneyBankCard.Text = retailOrder.MoneyBankCard.ToString();
                this.skinLabel_MoneyWeiXin.Text = retailOrder.MoneyWeiXin.ToString();
                this.skinLabel_MoneyAlipay.Text = retailOrder.MoneyAlipay.ToString();
                skinLabel_remark.Text = retailOrder.Remarks;
                this.skinLabelElse.Text = retailOrder.MoneyOther.ToString();
                skinLabel_remark.Text = retailOrder.Remarks;
            }
        }
        private void RefundOrderListCtrl_Load(object sender, EventArgs e)
        {

            this.Initialize();
        }

        private void dataGridView_RefundOrder_SelectionChanged(object sender, EventArgs e)
        {

            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            ///不重复提交
            if (row != null && row.Index != -1 && row != currRow)
            {
                RetailOrder retailOrder = (RetailOrder)row.DataBoundItem;
                
                    this.BindingRefundDetailDataSource(retailOrder);
                    SetRetailOrderLabel(retailOrder);
              
                currRow = row;
            }
        }
         

        private void dataGridView_RefundOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView_RefundOrder.Rows[e.RowIndex];
            RetailOrder order = (RetailOrder)row.DataBoundItem;

            if (guideIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetUserName(order.GuideID);
            }
            else
              if (shopIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetShopName(order.ShopID);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
