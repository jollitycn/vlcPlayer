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
using JGNet.Manage.Components;

namespace JGNet.Common
{
    public partial class DayReportDetailCtrl : BaseModifyUserControl
    {

        private DayReport curDayReport;
        public event CJBasic.Action<RetailListPagePara, BaseUserControl> SalesCount_Click;
        public event CJBasic.Action<RechargeRecordListPara, BaseUserControl> RechargeRecord_Click;
        public event CJBasic.Action<RefundListPagePara, BaseUserControl> RefundCount_Click;
        public event CJBasic.Action<RetailListPagePara, BaseUserControl> GuideDetail_Click;
        public event CJBasic.Action<List<Guide>, BaseUserControl> GuideInited;

        public DayReportDetailCtrl(DayReport order = null, CJBasic.Action<List<Guide>, BaseUserControl> dayReportDetailCtrl_GuideInited = null)
        {
            InitializeComponent();
            this.GuideInited += dayReportDetailCtrl_GuideInited;
            this.Initialize(order);
            if (order == null)
            {
                MenuPermission = RolePermissionMenuEnum.当日结存;
            }
            else
            {
                MenuPermission = RolePermissionMenuEnum.日结存查询;
            }
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

                
                if (this.curDayReport.ManualConfirm || !IsPos)
                {
                    this.richTextBox_Remark.ReadOnly = true; 
                }
                else
                {
                    this.skinLabel_Operator.Visible = false;
                } 
                this.BindingSource();
                BaseButton_Search_Click(null, null);
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

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                } 
                GetGuideDayAchievementsPara pagePara = new GetGuideDayAchievementsPara()
                {
                    ReportDate = curDayReport.ReportDate,                    
                    ShopID = curDayReport.ShopID
                };
                List<GuideDayAchievement> listPage = CommonGlobalCache.ServerProxy.GetGuideDayAchievements(pagePara);
                //如果是今天的那么返回实时的如果不是调用原数据接口
                foreach (GuideDayAchievement item in listPage)
                {
                    item.GuideName = CommonGlobalCache.GetUserName(item.GuideID);
                    item.ShopName = CommonGlobalCache.GetShopName(item.ShopID);
                }

                this.dataGridView1.DataSource = null;
                SalesCountSum.DataPropertyName = "SalesCount";
                quantityOfSaleSumDataGridViewTextBoxColumn.DataPropertyName = "QuantityOfSale";
                moneyOfSaleSumDataGridViewTextBoxColumn.DataPropertyName = "MoneyOfSale";
                this.dataGridView1.DataSource = listPage; 
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

        private void BindingSource()
        {
            //  if (!String.IsNullOrEmpty(curDayReport.EMallShopID) && curDayReport.EMallShopID == CommonGlobalCache.CurrentShopID)
            //{
            this.skinToolTip1.SetToolTip(this.skinLabel_QuantityOfSale, "线下" + curDayReport.QuantityOfSale + "件，线上" + curDayReport.EmQuantityOfSale + "件");
            skinLabel_QuantityOfSale.ForeColor = Color.Blue;
            this.skinToolTip1.SetToolTip(this.skinLabel_QuantityOfRefund, "线下" + (curDayReport.QuantityOfRefund * -1) + "件，线上" + (curDayReport.EmQuantityOfRefund * -1) + "件");
            skinLabel_QuantityOfRefund.ForeColor = Color.Blue;
            //  }

         //   this.skinLabel_State.Text = "状态：" + (this.curDayReport.ManualConfirm ? "已结存" : "未结存");
            this.skinLabel_shop.Text = "店铺：" + CommonGlobalCache.GetShopName(curDayReport.ShopID);
            this.skinLabel_Operator.Text = "操作人：" + CommonGlobalCache.GetUserName(curDayReport.AdminUserID);
            this.skinLabelDate.Text = "日期：" + curDayReport.ReportDate;
            this.skinLabel_SalesCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.SalesCount.ToString(), reportShowZero);
            this.skinLabel_RefundCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.RefundCount.ToString(), reportShowZero);
            skinLabel_NotConfirmedCount.Text = "未确认单据：" + ValidateUtil.ZeroToEmpty(curDayReport.NotConfirmedCount.ToString(), reportShowZero);
            this.richTextBox_Remark.Text = curDayReport.Remarks;
            ///库存 
            this.skinLabel_PreTotalCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.PreTotalCount.ToString(), reportShowZero);
            skinLabel_PurchaseInCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.PurchaseInCount.ToString(), reportShowZero);
            skinLabel_AllocateInCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.AllocateInCount.ToString(), reportShowZero);
            skinLabel_CheckStoreLostCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.CheckStoreLostCount.ToString(), reportShowZero);
            skinLabel_CheckStoreWinCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.CheckStoreWinCount.ToString(), reportShowZero);
            skinLabel_AllocateOutCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.AllocateOutCount.ToString(), reportShowZero);
            skinLabel_returnCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.ReturnCount.ToString(), reportShowZero);
          //  skinLabel_DiffAdjustCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.DiffAdjustCount.ToString(), reportShowZero);
            skinLabel_ScrapOutCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.ScrapOutCount.ToString(), reportShowZero);
            skinLabel_QuantityOfSale.Text = (curDayReport.QuantityOfSale + curDayReport.EmQuantityOfSale).ToString();
            skinLabel_TotalCount.Text = ValidateUtil.ZeroToEmpty(curDayReport.TotalCount.ToString(), reportShowZero);
            skinLabel_PreCash.Text = ValidateUtil.ZeroToEmpty(curDayReport.PreCash.ToString(), reportShowZero);
            skinLabel_CashCurrent.Text = ValidateUtil.ZeroToEmpty(curDayReport.CashCurrent.ToString(), reportShowZero);
            skinLabel_CashDeliverUp.Text = ValidateUtil.ZeroToEmpty(Math.Abs(curDayReport.CashDeliverUp).ToString(), reportShowZero);
            skinLabel_CashOut.Text = ValidateUtil.ZeroToEmpty(Math.Abs(curDayReport.CashOut).ToString(), reportShowZero);
            skinLabel_RechargeInCash.Text = ValidateUtil.ZeroToEmpty(curDayReport.RechargeInCash.ToString(), reportShowZero);
            skinLabel_SalesInCash.Text = ValidateUtil.ZeroToEmpty(curDayReport.SalesInCash.ToString(), reportShowZero);
            skinLabel_QuantityOfRefund.Text = ValidateUtil.ZeroToEmpty((curDayReport.QuantityOfRefund * -1 + curDayReport.EmQuantityOfRefund * -1).ToString(), reportShowZero);
            skinLabel_RefundInCash.Text = ValidateUtil.ZeroToEmpty((curDayReport.RefundInCash * -1).ToString(), reportShowZero);
            //  skinLabel_Revenue.Text = curDayReport.Revenue.ToString();
            skinLabel_CashInOthers.Text = ValidateUtil.ZeroToEmpty(curDayReport.CashInOthers.ToString(), reportShowZero);



            skinLabelPdDeliver.Text = ValidateUtil.ZeroToEmpty(curDayReport.PfDeliveryCount.ToString(), reportShowZero);
            skinLabelPfReturn.Text = ValidateUtil.ZeroToEmpty(curDayReport.PfReturnCount.ToString(), reportShowZero);
            //if (CommonGlobalUtil.IsPfEnable() && curDayReport.ShopID == CommonGlobalCache.GeneralStoreShopID)
            //{
            //    panelPf.Visible = true;
            //}
            //else {
            //    panelPf.Visible = false;
            //}

                DayReport[] reportDetails = new DayReport[] { curDayReport };
            //  this.dataGridView1.DataSource = reportDetails;
            //   this.dataGridView2.DataSource = reportDetails;


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
            cz.SalesInMoneyOther = curDayReport.SalesInMoneyOther;
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
            sr.SalesInMoneyOther = curDayReport.SalesInMoneyOther;
            reports.Add(sr);
            //退货

            DayReport refund = new DayReport();

            refund.SalesInCash = curDayReport.RefundInCash;
            refund.SalesInVipBalance = curDayReport.RefundInVipBalance;
            refund.SalesInVipIntegration = curDayReport.RefundInVipIntegration;
            refund.TotalRecharge = curDayReport.RefundTotalMoney;
            refund.SalesInBankCard = curDayReport.RefundInBankCard;
            refund.SalesInWeiXin = curDayReport.RefundInWeiXin;
            refund.SalesInAlipay = curDayReport.RefundInAlipay;
            refund.SalesInMoneyOther = curDayReport.SalesInMoneyOther;
            reports.Add(refund);
            //小计
            DayReport sum = new DayReport();
            sum.SalesInCash = sr.SalesInCash + cz.SalesInCash + refund.SalesInCash;
            sum.SalesInAlipay = sr.SalesInAlipay + cz.SalesInAlipay + refund.SalesInAlipay;
            sum.SalesInBankCard = sr.SalesInBankCard + cz.SalesInBankCard + refund.SalesInBankCard;
            sum.SalesInWeiXin = sr.SalesInWeiXin + cz.SalesInWeiXin + refund.SalesInWeiXin;
            sum.SalesInVipBalance = sr.SalesInVipBalance + cz.SalesInVipBalance + refund.SalesInVipBalance;
            sum.SalesInVipIntegration = sr.SalesInVipIntegration + cz.SalesInVipIntegration + refund.SalesInVipIntegration;
            sum.TotalRecharge = sr.TotalRecharge + cz.TotalRecharge + refund.TotalRecharge;
            sum.SalesInGiftTicket = sr.SalesInGiftTicket;
            refund.SalesInMoneyOther = sr.SalesInMoneyOther + cz.SalesInMoneyOther + refund.SalesInMoneyOther;  
            reports.Add(sum);
            yysr = sr;
            czmx = cz;
            total = sum;
            this.dataGridView2.DataSource = reports;

            skinLabel_Donate4Recharge.Text = "赠送金额：" + curDayReport.Donate4Recharge;

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
                    if (Column2.Index == e.ColumnIndex)
                    {
                        e.Value = string.Empty;
                    }
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

        //private void BaseButton_Confirm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (this.guideComboBox1.SelectedIndex == 0)
        //        {
        //            GlobalMessageBox.Show("操作人不能为空");
        //            return;
        //        }
        //        if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
        //        this.curDayReport.AdminUserID = this.guideComboBox1.SelectedValue.ToString();
        //        this.curDayReport.ManualConfirm = true;
        //        this.curDayReport.Remarks = this.richTextBox_Remark.Text.Trim();
        //        this.curDayReport.CreateTime = DateTime.Now;
        //        InsertResult result = CommonGlobalCache.ServerProxy.DayReportManualConfirm(this.curDayReport);
        //        if (result == InsertResult.Error)
        //        {
        //            GlobalMessageBox.Show("内部错误！");
        //            return;
        //        }
        //        GlobalMessageBox.Show("结存成功！");

        //        if (skinCheckBoxPrint.Checked)
        //        {
        //            //
        //            Print();
        //        }

        //        this.SaveSuccess();
        //    }
        //    catch (Exception ee)
        //    {
        //        CommonGlobalUtil.WriteLog(ee);
        //        GlobalMessageBox.Show("结存失败！");
        //    }
        //    finally
        //    {
        //        CommonGlobalUtil.UnLockPage(this);
        //    }
        //}

        private void Print()
        {
            DayReportPrintUtil printHelper = new DayReportPrintUtil();
            printHelper.Print(curDayReport, czmx, yysr, total);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                DataGridView view = (DataGridView)sender;
                switch (view.Rows[e.RowIndex].HeaderCell.Value)
                {
                    case "充值":
                        RechargeClick();
                        break;
                    case "收入":
                        SalesCountClick();
                        break;
                    case "退货":
                        RefundCountClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void skinLabel_SalesCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = int.Parse(this.skinLabel_SalesCount.Text);
            if (count == 0)
            {
                return;
            }
            SalesCountClick();



        }

        private void SalesCountClick()
        {
            this.SalesCount_Click?.Invoke(new RetailListPagePara()
            {
                RetailOrderID = null,
                CostumeID = null,
                StartDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                EndDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                 ClassID=-1,
                BrandID = -1,
                RetailOrderState = RetailOrderState.IsEffective,
                IsGetGeneralStore =true,
                IsOpenDate = true,
                PageIndex = 0,
                PageSize = int.MaxValue,
                RetailOrderType = RetailOrderType.RetailOrder, RetailPayType = RetailPayType.All,
                ShopID = curDayReport.ShopID, 
            }, this);
        }

        private void RechargeClick()
        {
            this.RechargeRecord_Click?.Invoke(new RechargeRecordListPara()
            {
                PhoneNumber = null,
                StartDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                EndDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
            }, this);
        }

        private void skinLabel_RefundCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int count = int.Parse(this.skinLabel_RefundCount.Text);
            if (count == 0)
            {
                return;
            }
            RefundCountClick();

        }

        private void RefundCountClick()
        {
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

        private void DayReportDetailCtrl_Leave(object sender, EventArgs e)
        {
            //离开时，设置不刷新原界面
            //这个是自己的
            BaseUserControl ctrl = (BaseUserControl)this.SourceTabPage?.Controls[0];
            if (ctrl != null)
            {
                ctrl.RefreshPageDisable = true;
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        DayOfGuideRetailOrderListForm form = new DayOfGuideRetailOrderListForm();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                DataGridView view = (DataGridView)sender;
                List<GuideDayAchievement> curDayReportListSource = (List<GuideDayAchievement>)view.DataSource;
                GuideDayAchievement item = curDayReportListSource[e.RowIndex];
                item.ReportDate =Convert.ToInt32(DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day);
                switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case "明细":
                     //   GuideDetailClick(item);
                        form.ShowDialog(curDayReport.ShopID, item.GuideID, curDayReport.ReportDate); 

                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void GuideDetailClick(GuideDayAchievement item)
        {
            this.GuideDetail_Click?.Invoke(new RetailListPagePara()
            {
                RetailOrderID = null,
                CostumeID = null,
                StartDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                EndDate = TimeHelper.GetReportDate(curDayReport.ReportDate.ToString()),
                 ClassID=-1,
                GuideID = item.GuideID,
                BrandID = -1,
                RetailOrderState = RetailOrderState.IsEffective,
                IsOpenDate = true,
                PageIndex = 0,
                PageSize = int.MaxValue,
                ShopID = curDayReport.ShopID,
                RetailOrderType = RetailOrderType.All,
                 RetailPayType= RetailPayType.All,
                IsGetGeneralStore =true,
            }, this);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridView view = sender as DataGridView;
            GuideDayAchievement item = view.Rows[e.RowIndex].DataBoundItem as GuideDayAchievement;
            GuideDetailClick(item);
        }
    }
}
