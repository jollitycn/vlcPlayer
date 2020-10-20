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
    public partial class RefundOrderDetailCtrl : BaseModifyCostumeIDUserControl
    { 
        private RetailOrder order;
         
        public CJBasic.Action<string, BaseUserControl> RetailOrderDetail;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public RefundOrderDetailCtrl(RetailOrder order)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView_Detail);
            dataGridViewPagingSumCtrl.Initialize();
            this.order = order;

            this.Initialize();
            this.BindingRetailDetailDataSource();
        }
        private void Initialize()
        {
            skinLabel_createDate.Text = order.CreateTime.ToString();
            skinLabel_memberID.Text = order.MemeberID;
            skinLabel_totalCount.Text = order.TotalCount.ToString();
            //     skinLabel_totalMoney.Text = order.TotalPrice.ToString();
            skinLabel_totalMoney.Text = order.TotalMoneyReceived.ToString();
            skinLabel_orderID.Text = order.ID;
            skinLabel_shop.Text = CommonGlobalCache.GetShopName(order.ShopID);
            linkLabel_retailOrderID.Text = order.OriginOrderID;
            skinLabel_remark.Text = order.Remarks;
            skinLabelWeixin.Text = order.MoneyWeiXin.ToString();
            this.skinLabel_MoneyCash.Text = order.MoneyCash.ToString();
            this.skinLabel_MoneyStoredCard.Text = order.MoneyVipCard.ToString();
            //   this.skinLabel_RefundAll.Text = order.RefundAll ? "是" : "否";
            this.skinLabel_MoneyIntegration.Text = order.MoneyIntegration.ToString();

            skinLabel_guide.Text = CommonGlobalCache.GetUserName(order.GuideID);
        }

        /// <summary>
        /// 绑定RetailDetail数据源
        /// </summary>
        private void BindingRetailDetailDataSource( )
        {
            try
            {
                List<RetailDetail> retailDetailList = null;
                if (order == null)
                {
                    dataGridViewPagingSumCtrl.BindingDataSource(retailDetailList);
                }
                else
                {
                  retailDetailList = CommonGlobalCache.ServerProxy.GetRefundDetailList(order.ID);
                 
                    if (retailDetailList != null && retailDetailList.Count > 0)
                    {
                        foreach (RetailDetail detail in retailDetailList)
                        {
                            detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                            detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID,detail.SizeName);
                        }
                      // this.dataGridView_Detail.DataSource = retailDetailList;
                        
                    }
                    dataGridViewPagingSumCtrl.BindingDataSource(retailDetailList);
                } 
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally {
               UnLockPage();
            }
        }
        public override void HighlightCostume()
        {
            if (this.dataGridView_Detail.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView_Detail.Rows)
                    {
                        RetailDetail detail = row.DataBoundItem as RetailDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
            }
        }
         
        private void linkLabel_retailOrderID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.RetailOrderDetail?.Invoke(linkLabel_retailOrderID.Text,this.SourceCtrlType);        }

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
            dataGridView_Detail.Dispose();
            Console.WriteLine(dataGridView_Detail.Name +":"+ dataGridView_Detail.IsDisposed);
            dataGridView_Detail = null;
            base.Dispose(disposing);
        }
    }


}
