using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using JGNet.Common;
using JGNet.Common.Core; 
using JGNet.Common.Core.Util;
using CJBasic;
using JGNet.Common.Components;

namespace JGNet.Common
{
    public partial class DayReportOnlineDetailCtrl : BaseModifyUserControl
    {

        private DayReport curDayReport;
        public CJBasic.Action<RetailListPagePara, BaseUserControl> SalesCount_Click;
        public CJBasic.Action<RefundListPagePara, BaseUserControl> RefundCount_Click;

        public DayReportOnlineDetailCtrl(DayReport order=null)
        {
            InitializeComponent(); 
                this.Initialize(order);
            if (order == null)
            {
                MenuPermission=RolePermissionMenuEnum.当日结存;
            }
            else
            {
                MenuPermission=RolePermissionMenuEnum.日结存查询;
            }
            //  new DataGridViewPagingSumCtrl(dataGridView2).Initialize();
            //  new DataGridViewPagingSumCtrl(dataGridView1).Initialize();
        }

        public void Initialize(DayReport order = null)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (order != null)
                {
                    this.curDayReport = order;
                }
                else
                {
                    //不传就是当日结存。
                    this.curDayReport = CommonGlobalCache.ServerProxy.GetTodayDayReport(CommonGlobalCache.CurrentShopID);
                }
                if (this.curDayReport == null)
                {
                    return;
                }

                
              
                this.BindingSource(); 
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

        private bool reportShowZero;
 

        private void BindingSource()
        { 

            this.skinLabel_shop.Text = "店铺：" + CommonGlobalCache.GetShopName(curDayReport.ShopID);
            this.skinLabelDate.Text = "日期：" + curDayReport.ReportDate;
            this.skinLabel_SalesCount.Text = curDayReport.SalesCount.ToString();
            this.skinLabel_RefundCount.Text =  curDayReport.RefundCount.ToString();

            skinLabel_QuantityOfSale.Text = (curDayReport.QuantityOfSale+ curDayReport.EmQuantityOfSale).ToString();
            skinLabelCostumeMoney.Text = (curDayReport.SalesTotalMoney - curDayReport.CarriageCost).ToString();
            skinLabelCarriageCost.Text = curDayReport.CarriageCost.ToString();
            skinLabel_QuantityOfRefund.Text = (curDayReport.QuantityOfRefund * -1 + curDayReport.EmQuantityOfRefund * -1).ToString();
            
            DayReport[] reportDetails = new DayReport[] { curDayReport };

            List<DayReport> reports = new List<DayReport>();
            // reports.Add(curDayReport);
            //充值
            DayReport cz = new DayReport();
            cz.SalesInAlipay = curDayReport.RechargeInAlipay;
            cz.SalesInBankCard = curDayReport.RechargeInBankCard;
            cz.SalesInCash = curDayReport.RechargeInCash;
            cz.SalesInWeiXin = curDayReport.RechargeInWeiXin;
            cz.TotalRecharge = curDayReport.TotalRecharge;
            cz.SalesInGiftTicket = curDayReport.SalesInGiftTicket;
            reports.Add(cz);
            //收入
            DayReport sr = new DayReport();
            sr.SalesInAlipay = curDayReport.SalesInAlipay;
            sr.SalesInBankCard = curDayReport.SalesInBankCard;
            sr.SalesInCash = curDayReport.SalesInCash;
            sr.SalesInWeiXin = curDayReport.SalesInWeiXin;
            sr.SalesInVipBalance = curDayReport.SalesInVipBalance;
            sr.SalesInVipIntegration = curDayReport.SalesInVipIntegration;
            sr.TotalRecharge = curDayReport.SalesTotalMoney;
            sr.SalesInGiftTicket = curDayReport.SalesInGiftTicket;
            reports.Add(sr);
            //退货

            DayReport refund = new DayReport();

            refund.SalesInCash = curDayReport.RefundInCash ;
            refund.SalesInWeiXin = curDayReport.RefundInWeiXin;
            refund.SalesInVipBalance = curDayReport.RefundInVipBalance ;
            refund.SalesInVipIntegration = curDayReport.RefundInVipIntegration;
            refund.TotalRecharge = curDayReport.RefundTotalMoney ;
            reports.Add(refund);
            //小计
            DayReport sum = new DayReport();
            sum.SalesInCash = sr.SalesInCash + cz.SalesInCash + refund.SalesInCash;
            sum.SalesInAlipay = sr.SalesInAlipay + cz.SalesInAlipay + refund.SalesInAlipay;
            sum.SalesInBankCard = sr.SalesInBankCard + cz.SalesInBankCard + refund.SalesInBankCard;
            sum.SalesInWeiXin = sr.SalesInWeiXin + cz.SalesInWeiXin + refund.SalesInWeiXin;
            sum.SalesInVipBalance = sr.SalesInVipBalance + cz.SalesInVipBalance + refund.SalesInVipBalance;
            sum.SalesInVipIntegration = sr.SalesInVipIntegration + cz.SalesInVipIntegration + refund.SalesInVipIntegration;
            sum.TotalRecharge = sr.TotalRecharge + cz.TotalRecharge + refund.TotalRecharge  ;
            sum.SalesInGiftTicket = sr.SalesInGiftTicket;
            reports.Add(sum);
            yysr = sr;
            czmx = cz;
            total = sum;
            this.dataGridView2.DataSource = reports;
        }

        DayReport yysr;
        DayReport czmx;
        DayReport total;
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.Rows[e.RowIndex];
            //   row.ReadOnly = true;
            DayReport order = (DayReport)row.DataBoundItem;

            switch (e.RowIndex)
            {
                case 0:
                    row.HeaderCell.Value = "充值";
                    if (SalesInGiftTicket.Index == e.ColumnIndex || dataGridViewTextBoxColumn6.Index == e.ColumnIndex || dataGridViewTextBoxColumn7.Index == e.ColumnIndex)
                    {
                        e.Value = "-";
                    }
                    break;
                case 1:
                    row.HeaderCell.Value = "收入";
                    break;
                case 2:
                    row.HeaderCell.Value = "退货";
                    if (SalesInGiftTicket.Index == e.ColumnIndex)
                    {
                        e.Value = "-";
                    }
                    break;
                case 3:
                    row.HeaderCell.Value = "小计";
                    break;
                default:
                    break;
            }

            //小计 总额 始终显示，其他为零不显示
            if (row.HeaderCell.Value.ToString() == "小计" && Revenue.Index == e.ColumnIndex)
            { }
            else
            {
                DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
            }

        }
           
        private void skinLabel_SalesCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = int.Parse(this.skinLabel_SalesCount.Text);
            if (count==0)
            {
                return;
            }
            this.SalesCount_Click?.Invoke(new RetailListPagePara()
            {
                RetailOrderID = null,
                CostumeID = null,
                StartDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                EndDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
      ClassID=-1,
                BrandID = -1,
                RetailOrderState =  RetailOrderState.IsEffective,
                  RetailPayType = RetailPayType.All,
                   RetailOrderType = RetailOrderType.RetailOrder,
                IsOpenDate = true,
                PageIndex = 0,
                PageSize = int.MaxValue,
                ShopID = curDayReport.ShopID
            }, this);

        }

        private void skinLabel_RefundCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = int.Parse(this.skinLabel_RefundCount.Text);
            if (count == 0)
            {
                return;
            }
            this.RefundCount_Click?.Invoke(new RefundListPagePara()
            {
                RefundOrderID = null,
                CostumeID = null,
                StartDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                EndDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                MemberID = null,
                PageIndex = 0, 
                PageSize = int.MaxValue,
                ShopID = curDayReport.ShopID
            }, this);

        }
         
         

        private void DayReportOnlineDetailCtrl_Leave(object sender, EventArgs e)
        {
            //离开时，设置不刷新原界面
            //这个是自己的
            BaseUserControl ctrl = (BaseUserControl)this.SourceTabPage?.Controls[0];
            if (ctrl != null) { 
            ctrl.RefreshPageDisable = true;
            }
        }
          
    }
}
