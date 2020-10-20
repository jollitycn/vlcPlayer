using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core.Util;
using JGNet.Common.Core; 
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Core.Tools;
using CJBasic.Helpers;
using JGNet.Core;

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class WorkDeskCtrl : BaseUserControl
    {

        /// <summary>
        /// 点击未处理补货申请单LinkLabel 触发  参数补货申请单状态
        /// </summary>
        public event CJBasic.Action<ReplenishOrderState, EventArgs> UnconfirmedReplenishOrderCountClick;

        /// <summary>
        /// 点击未处理补货申请单LinkLabel 触发   
        /// </summary>
        public event CJBasic.Action<object, EventArgs> UnconfirmedAllocateOrderCountClick;
        public event CJBasic.Action<object, EventArgs> UnconfirmedDifferenceOrderCountClick;
        public event CJBasic.Action<object, EventArgs> IsCostumeStoreHaveNegativeClick;
        public event CJBasic.Action<object, EventArgs> CheckOrderCountClick;
        public event CJBasic.Action<object, EventArgs> CheckStoreTaskCountClick;
        public event CJBasic.Action<object, EventArgs> TodayAddMemberCountClick;
        public event CJBasic.Action<object, EventArgs> OnlineOrderClick;
        public event CJBasic.Action<object, EventArgs> OnlineOrderRefundClick;



        public BaseUserControl MenuItemCtrl {  set { this.skinSplitContainer1.Panel2.Controls.Add(value); } }
        public WorkDeskCtrl()
        {
            InitializeComponent();
            this.UnconfirmedReplenishOrderCountClick += delegate { };
            this.UnconfirmedAllocateOrderCountClick += delegate { };
            this.UnconfirmedDifferenceOrderCountClick += delegate { };
            this.TodayAddMemberCountClick += delegate { };
            this.CheckOrderCountClick += delegate { };
            MenuPermission = RolePermissionMenuEnum.工作台;
        }


        private void Initialize(Boolean showError)
        {
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this, false, showError))
                {
                    return;
                }

                WorkTableInfoPara para = new WorkTableInfoPara()
                {
                    ShopID = CommonGlobalCache.CurrentShopID,
                    IsPos = IsPos
                };
                WorkTableInfo workTableInfo = CommonGlobalCache.ServerProxy.WorkTableInfo(para);

                if (workTableInfo == null)
                {
                    return;
                }
                if (IsPos)
                {
                    //盘点待审核
                    skinLabel7.Visible = false;
                    skinLabel4.Visible = false;
                    linkLabel_checkOrderCount.Visible = false;

                    //线上订单待发货 
                    skinLabel15.Visible = false;
                    skinLabel17.Visible = false;
                    linkLabelOnlineOrder.Visible = false;

                    //线上退货单
                    skinLabel16.Visible = false;
                    skinLabel18.Visible = false;
                    linkLabelOnlineOrderRefund.Visible = false;
                }

                GetAllocateOrdersPara pagePara = new GetAllocateOrdersPara()
                {
                    AllocateOrderID = null,
                    AllocateOrderState = AllocateOrderState.Normal,
                    CostumeID = null,
                    EndDate = new CJBasic.Date(DateTime.Now),
                    StartDate = new CJBasic.Date("1900-01-01"),
                    ShopID = "",
                    Type = AllocateOrderType.All,
                    PageIndex = 0,
                    PageSize =20,
                    ReceiptState = ReceiptState.WaitReceipt,
                    LockShop = HasPermission(RolePermissionMenuEnum.调拨单查询, RolePermissionEnum.查看_只看本店),
                    DestShopID = CommonGlobalCache.CurrentShopID,
                    SourceShopID = "",

                };

                InteractResult<AllocateOrderPage> listPage = CommonGlobalCache.ServerProxy.GetAllocateOrders(pagePara);

                this.linkLabel_UnconfirmedAllocateOrderCount.Text = listPage.Data.AllocateOrderList.Count.ToString();



                linkLabelNewMember.Text = workTableInfo.TodayAddMemberCount.ToString();

                CheckStoreOrderPagePara  checkPagePara = new CheckStoreOrderPagePara()
                {
                    CheckStoreOrderID = null,
                    IsOpenDate = true,
                    StartDate = new CJBasic.Date("1900-01-01"),
                    EndDate = new CJBasic.Date(DateTime.Now),
                    PageIndex = 0,
                    PageSize = 1000,
                    //ShopID = CommonGlobalCache.CurrentShopID,
                    CostumeID =null,
                    State = CheckStoreOrderState.PendingReview,
                };

                CheckStoreOrderPage ChecklistPage = CommonGlobalCache.ServerProxy.GetCheckStoreOrderPage(checkPagePara);

                this.linkLabel_checkOrderCount.Text = ChecklistPage.CheckStoreOrderList.Count.ToString();


                DifferenceOrderPagePara  checkOrderPagePara = new DifferenceOrderPagePara()
                {
                    OrderID = null,
                    CostumeID = null,
                    IsOpenDate = true,
                    IsOnlyGetOut =true,
                    StartDate = new CJBasic.Date("1900-01-01"),
                    EndDate = new CJBasic.Date(DateTime.Now),
                    PageIndex = 0,
                    PageSize = 1000,
                    ShopID = CommonGlobalCache.CurrentShopID,
                    OrderPrefixType = ValidateUtil.CheckEmptyValue(OrderPrefix.AllocateOrder),
                    DifferenceOrderConfirmed = DifferenceOrderConfirmed.False,

                };

                DifferenceOrderPage checkOrderListPage = CommonGlobalCache.ServerProxy.GetDifferenceOrderPage(checkOrderPagePara);

                this.DifferenceOrderConfirmedIsFalseCount.Text = checkOrderListPage.DifferenceOrderList.Count.ToString();




                GetEmOrderPagePara  EmpagePara = new GetEmOrderPagePara()
                {
                    OrderID =null,
                    StartDate = new CJBasic.Date("1900-01-01"),
                    EndDate = new CJBasic.Date(DateTime.Now),
                    PageIndex = 0,
                    PageSize = 1000,
                    MemberPhoneOrName = null,
                    CostumeIDOrName =null,
                    OrderState =  EmRetailOrderState.WaitDelivery,
                    RefundStatus = RefundStatus.NotSelect,
                };

                EmOrderPage EmlistPage = CommonGlobalCache.ServerProxy.GetEmOrderPage(EmpagePara);

                

                //开通erp 且未开通线上商城 ，线上商城和工作台两个线上订单数字，灰掉
                if (!CommonGlobalCache.BusinessAccount.OnlineEnabled && CommonGlobalCache.BusinessAccount.ERPEnabled ==true)
                {

                    linkLabelOnlineOrder.Enabled = false;
                    linkLabelOnlineOrderRefund.Enabled = false;


                }
                //未开通erp 但是开通了线上商城
                if (CommonGlobalCache.BusinessAccount.OnlineEnabled && !CommonGlobalCache.BusinessAccount.ERPEnabled)
                {
                    skinLabel4.Visible = false;
                    skinLabel3.Visible = false;
                    skinLabel6.Visible = false;
                    skinLabel7.Visible = false;
                    skinLabel9.Visible = false;
                    skinLabel10.Visible = false;
                    linkLabel_UnconfirmedAllocateOrderCount.Visible = false;
                    DifferenceOrderConfirmedIsFalseCount.Visible = false;
                    linkLabel_checkOrderCount.Visible = false;

                    skinLabel14.Visible = false;
                    linkLabelNewMember.Visible = false;
                }

                    linkLabelOnlineOrder.Text = EmlistPage.ResultList.Count.ToString();


                GetEmOrderPagePara EmReturnpagePara = new GetEmOrderPagePara()
                {
                    OrderID = null,
                    StartDate = new CJBasic.Date("1900-01-01"),
                    EndDate = new CJBasic.Date(DateTime.Now),
                    PageIndex = 0,
                    PageSize = 1000,
                    MemberPhoneOrName = null,
                    CostumeIDOrName = null,
                    OrderState = EmRetailOrderState.All,
                     
                    RefundStatus = RefundStatus.Refunding,
                };

                EmOrderPage EmReturnlistPage = CommonGlobalCache.ServerProxy.GetEmOrderPage(EmReturnpagePara);

             int rows=  EmReturnlistPage.ResultList.FindAll(t => t.RefundStateName == EmRetailOrder.GetRefundState(RefundStateEnum.RefundApplication) || t.RefundStateName == EmRetailOrder.GetRefundState(RefundStateEnum.Refunding)).Count;

                linkLabelOnlineOrderRefund.Text = rows.ToString();
                if (workTableInfo.IsCostumeStoreHaveNegative)
                {
                    linkLabel1.Text = "有";
                    linkLabel1.ForeColor = Color.Red;
                    linkLabel1.Enabled = true;
                }
                else
                {
                    linkLabel1.Text = "无";
                    linkLabel1.DisabledLinkColor = Color.Green;
                    linkLabel1.Enabled = false;
                }

              //  RefreshStoreState(workTableInfo.CostumeStoreLocked);
                //CommonGlobalCache.IsCheckStoreState = workTableInfo.CostumeStoreLocked;
            }
            catch (Exception ex)
            {
                ShowError(ex, showError);
            }
            finally
            {
                UnLockPage();
            }
        }

        private void linkLabel_UnconfirmedReplenishOrderCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.UnconfirmedReplenishOrderCountClick( IsPos?ReplenishOrderState.Processing: ReplenishOrderState.NotProcessing,null);
        }
        public bool isWorkDesk=false;
        private void linkLabel_UnconfirmedAllocateOrderCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isWorkDesk = true;
            this.UnconfirmedAllocateOrderCountClick(null,null);

        }


        private void linkLabel_UnconfirmedDifferenceOrderCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isWorkDesk = true;
            this.UnconfirmedDifferenceOrderCountClick(null,null);
        }


        public override void RefreshPage()
        {
            this.Initialize(false);
        }

        private void BaseButton_Refresh_Click(object sender, EventArgs e)
        {
            this.Initialize(true);
        }
         

        private void WorkDeskCtrl_Load(object sender, EventArgs e)
        {

            this.Initialize(false);
        }

        private void linkLabel_checkOrderCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            isWorkDesk = true;
            this.CheckOrderCountClick(null,null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.IsCostumeStoreHaveNegativeClick(null, null);
        }

        private void CheckStoreTaskCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CheckStoreTaskCountClick(null, null);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Initialize(false);
        }

        private void linkLabelNewMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            TodayAddMemberCountClick?.Invoke(null,null);
        }

        private void linkLabelOnlineOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            OnlineOrderClick?.Invoke(null, null);
        }

        private void linkLabelOnlineOrderRefund_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isWorkDesk = true;
            OnlineOrderRefundClick?.Invoke(null, null);
        }
    }
}
