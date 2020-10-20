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
using JGNet.Common.Components;
using JGNet.Core;

namespace JGNet.Common
{
    public partial class RetailOrderDetailCtrl : BaseModifyCostumeIDUserControl
    {   

        public CJBasic.Action<String, BaseUserControl> RefundOrderDetail;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public RetailOrderDetailCtrl(RetailOrder order)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this. dataGridView_RetailDetail);
            dataGridViewPagingSumCtrl.Initialize();
            Initialize(order);
            this.BindingRetailDetailDataSource(order);
        }

        private void Initialize(RetailOrder order)
        {
            skinLabel_createDate.Text = order.CreateTime.ToString();
            skinLabel_memberID.Text = order.MemeberID;
            skinLabel_totalCount.Text = order.TotalCount.ToString();
            skinLabel_totalMoney.Text = order.TotalMoneyReceived.ToString();
            linkLabel_refundOrder.Text = order.RefundOrderID;
            skinLabel_orderID.Text = order.ID;
            skinLabel_shop.Text = CommonGlobalCache.GetShopName(order.ShopID);
            skinLabel_remark.Text = order.Remarks;
            if (String.IsNullOrEmpty(order.SalesPromotionID))
            {
                this.skinLabel_SalesPromotion.Text = CommonGlobalUtil.COMBOBOX_NULL;
            }
            else
            {
                this.skinLabel_SalesPromotion.Text = order.PromotionText;
            }
            this.skinLabel_MoneyCash.Text = order.MoneyCash.ToString();
            skinLabel_SmallMoneyRemoved.Text = order.SmallMoneyRemoved.ToString();
            //可能会少个一分钱

            this.skinLabel_MoneyStoredCard.Text = order.MoneyVipCard.ToString() + "(赠送" + order.MoneyVipCardDonate + ")";
            skinLabelReceivedActual.Text = order.TotalMoneyReceivedActual.ToString();
            this.skinLabel_MoneyBankCard.Text = order.MoneyBankCard.ToString();
            this.skinLabel_MoneyIntegration.Text = order.MoneyIntegration.ToString();// (order.MoneyIntegration * CommonGlobalCache.IntegralConversionBalanceRatio).ToString();
            this.skinLabel_MoneyWeiXin.Text = order.MoneyWeiXin.ToString();
            this.skinLabel_MoneyAlipay.Text = order.MoneyAlipay.ToString();
            this.skinLabel_MoneyOther.Text = order.MoneyOther.ToString();
            this.skinLabelGiftTicket.Text = order.MoneyDeductedByTicket.ToString();
            skinLabel_guide.Text = CommonGlobalCache.GetUserName(order.GuideID);
            this.skinLabel_MoneyChange.Text = order.MoneyChange.ToString();
        }

        /// <summary>
        /// 绑定RetailDetail数据源
        /// </summary>
        private void BindingRetailDetailDataSource(RetailOrder order)
        {
            try
            {

                List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(order?.ID);
                if (retailDetailList != null && retailDetailList.Count > 0)
                {
                    foreach (RetailDetail detail in retailDetailList)
                    {
                        detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                        detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                    }
                }
                this.dataGridViewPagingSumCtrl.BindingDataSource(retailDetailList);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                UnLockPage();
            }
        }


        public override void HighlightCostume()
        {
            if (dataGridView_RetailDetail.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView_RetailDetail.Rows)
                    {
                        RetailDetail detail = row.DataBoundItem as RetailDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }

                }
            }
        }

         

        private void linkLabel_refundOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.RefundOrderDetail?.Invoke(this.linkLabel_refundOrder.Text, this.SourceCtrlType);
        }
       
    }
}
