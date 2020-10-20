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
using CCWin.SkinControl;
using CJBasic;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Core.Const;
using JGNet.Core.Tools;
using JGNet.Core;

namespace JGNet.Common
{

    public partial class RetailOrderSearchCtrl : BaseModifyUserControl 
    { 

        private RetailListPagePara pagePara;
        public CJBasic.Action<RetailOrder, BaseUserControl> RedoClick;
        public CJBasic.Action<String, BaseUserControl> RefundDetailClick;
        public CJBasic.Action<String, BaseUserControl> RetailDetailClick;
       
        private string shopID;

        public RetailOrderSearchCtrl()
        {
            InitializeComponent();
            skinComboBoxShopID.Initialize(false, CommonGlobalCache.IsGeneralStoreRetail != "1", !IsPos);
            MenuPermission = RolePermissionMenuEnum.销售退货单查询;
            retailOrderListCtrl2.MenuPermission = RolePermissionMenuEnum.销售退货单查询;
            //if (!HasPermission(RolePermissionEnum.查看_品牌))
            //{
            //    skinComboBox_Brand.Visible = false;
            //    skinLabel6.Visible = false;
            //}

        }

        public override void RefreshPage()
        {
            this.Search();
        }

        private void Initialize()
        {
            DateTimeUtil.DateTimePicker_Today(dateTimePicker_Start, dateTimePicker_End);
            this.pagePara = new RetailListPagePara();
            //20180530,销售退货单查询完关闭重新加载
            this.retailOrderListCtrl2.Initialize();

            if (HasPermission(RolePermissionEnum.打印))
            {
                retailOrderListCtrl2.ShowPrintColumn(true);
            }
            CommonGlobalUtil.SetBrand(skinComboBox_Brand);
            SetType();
            SetPayType();
            SetState(false);
        }
         
         
        private void SetType()
        {
            List<ListItem<RetailOrderType>> list = new List<ListItem<RetailOrderType>>();
            list.Add(new ListItem<RetailOrderType>(CommonGlobalUtil.COMBOBOX_ALL, RetailOrderType.All));
            list.Add(new ListItem<RetailOrderType>("销售", RetailOrderType.RetailOrder));
            list.Add(new ListItem<RetailOrderType>("退货", RetailOrderType.RefundOrder));
            this.skinComboBox_type.DisplayMember = "Key";
            this.skinComboBox_type.ValueMember = "Value";
            this.skinComboBox_type.DataSource = list;
        }

        private void SetPayType()
        {
            List<ListItem<RetailPayType>> list = new List<ListItem<RetailPayType>>();
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.All), RetailPayType.All));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Cash), RetailPayType.Cash));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.BankCard), RetailPayType.BankCard));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.WeiXin), RetailPayType.WeiXin));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Alipay), RetailPayType.Alipay));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.VipCard), RetailPayType.VipCard));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Ticket), RetailPayType.Ticket));
            list.Add(new ListItem<RetailPayType>(EnumHelper.GetDescription(RetailPayType.Other), RetailPayType.Other));
            this.brandComboBoxPayType.DisplayMember = "Key";
            this.brandComboBoxPayType.ValueMember = "Value";
            this.brandComboBoxPayType.DataSource = list;
        }

        private void SetState(bool isRefund)
        {
            List<ListItem<RetailOrderState>> list = new List<ListItem<RetailOrderState>>();
            list.Add(new ListItem<RetailOrderState>("正常", RetailOrderState.IsNormal));
            list.Add(new ListItem<RetailOrderState>("已冲单", RetailOrderState.IsCancel));
            list.Add(new ListItem<RetailOrderState>("所有", RetailOrderState.All));
            //672 销售单查询整改：当选择查询销售单时，状态调整
            //if (!isRefund)
            //{
            //    list.Add(new ListItem<RetailOrderState>("已退货", RetailOrderState.IsRefund));
            //}
            this.skinComboBoxState.DisplayMember = "Key";
            this.skinComboBoxState.ValueMember = "Value";
            this.skinComboBoxState.DataSource = list;
        }

        private void BaseButton_resetReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                CreateAllReportSelectForm form = new CreateAllReportSelectForm("重结报表", "开始日期：", this.dateTimePicker_Start.Value, "正在重新结算中……");
                form.ConfirmClick += form_ConfirmClick;
                form.ShowDialog();

            }
            catch (Exception ee)
            {


                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        CreateAllReportSelectForm form = null;
        DateTime dateTime = DateTime.Now;
        String createAllReportParaShopId;
        private void form_ConfirmClick(DateTime dateTime,String shopId, CreateAllReportSelectForm form)
        {

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.dateTime = dateTime;
                createAllReportParaShopId = shopId;
                this.form = form;
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoUpdate);
                cb.BeginInvoke(null, null); ShowProgressForm();
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

        }


        private void DoUpdate()
        {
            try
            {
                
                int days = TimeHelper.GetSpanDays(dateTime, DateTime.Now);
                days = days + 1;
                int i = 0;
                for (i = 0; i < days; i++)
                {
                    if (progressStop)
                    {
                        break;
                    }

                    DateTime oneDate = dateTime.AddDays(i * 1.0);
                    CreateAllReportPara para = new CreateAllReportPara()
                    {
                        Date = new Date(oneDate),
                        ShopId = createAllReportParaShopId
                    };

                    UpdateProgress(days, i + 1);
                    InteractResult result = CommonGlobalCache.ServerProxy.CreateAllReport(para);
                    switch (result.ExeResult)
                    {
                        case ExeResult.Success:
                            break;
                        case ExeResult.Error:
                            FailedProgress(new Exception(result.Msg));
                            CompleteEdit(true);
                            return;
                        default:
                            break;
                    }
                }
                CompleteEdit();
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

         
        private void CompleteEdit(bool stop=false)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<bool>(this.CompleteEdit),stop);
            }
            else
            {
                CompleteProgressForm();
                if (stop)
                {
                    form.Cancel();
                }
                else
                {
                    form.SetDialogResult(DialogResult.OK);
                    GlobalMessageBox.Show("重结成功！");
                }
            }
        }

          

        //点击查询按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            string orderID = this.skinTextBox_OrderID.SkinTxt.Text.Trim();
            orderID = string.IsNullOrEmpty(orderID) ? null : orderID;
            string costumeID = this.CostumeCurrentShopTextBox1.SkinTxt.Text;
            costumeID = string.IsNullOrEmpty(costumeID) ? null : costumeID;
            bool isOpenDate = true;
            Date startDate = new Date(this.dateTimePicker_Start.Value);
            Date endDate = new Date(this.dateTimePicker_End.Value);

            string curBrandStr =  ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue);
            int curBrand=0;
            if (curBrandStr == null)
            {
                curBrand = 0;
            }
            else
            {
                curBrand = Convert.ToInt32(curBrandStr);
            }
            this.pagePara = new RetailListPagePara()
            {
                RetailOrderState = (RetailOrderState)this.skinComboBoxState.SelectedValue,
                RetailOrderID = orderID,
                CostumeID = costumeID,
                StartDate = startDate,
                EndDate = endDate,
                ClassID = skinComboBoxBigClass.SelectedValue.ClassID,
                //SubSmallClass = skinComboBoxBigClass.SelectedValue?.SubSmallClass,
                BrandID = curBrand,
                IsOpenDate = isOpenDate,
                PageIndex = 0,
                PageSize = this.retailOrderListCtrl2.dataGridViewPagingSumCtrl.PageSize,
                RetailOrderType = (RetailOrderType)this.skinComboBox_type.SelectedValue,
                IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1",
                ShopID = shopID,
                GuideID = ValidateUtil.CheckEmptyValue(this.guideComboBox1.SelectedValue),
                RetailPayType = (RetailPayType)this.brandComboBoxPayType.SelectedValue,
                 IsOnlyNotPay= skinCheckBoxNew.Checked,
                  Remarks=ValidateUtil.CheckEmptyValue(this.txtRemark.SkinTxt.Text),
            };
            Search();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="para">内部调用的话不传</param>
        public void Search(RetailListPagePara para=null)
        { 
            if (para != null) { 
            this.pagePara = para;
            SetQueryCondition();
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                Shop shop= this.skinComboBoxShopID.SelectedItem as Shop;
                retailOrderListCtrl2.RedoClick = RedoClick;
                retailOrderListCtrl2.RefundDetailClick = RefundDetailClick;
                retailOrderListCtrl2.RetailDetailClick = RetailDetailClick;
                retailOrderListCtrl2.SourceCtrlType = this;
                this.retailOrderListCtrl2.BindingSource(pagePara, shop.Name==SystemDefault.onlineName);
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

        private void SetQueryCondition()
        {

            this.skinTextBox_OrderID.SkinTxt.Text = pagePara.RetailOrderID;
            this.CostumeCurrentShopTextBox1.SkinTxt.Text = pagePara.CostumeID;
            this.dateTimePicker_Start.Value = pagePara.StartDate.ToDateTime();
            this.dateTimePicker_End.Value = pagePara.EndDate.ToDateTime();
            skinComboBoxBigClass.SelectedValue = new Costume() {
                ClassID = pagePara.ClassID
                };
                skinComboBox_Brand.SelectedValue = pagePara.BrandID;
        
            if (!String.IsNullOrEmpty(pagePara.ShopID))
            { 
                skinComboBoxShopID.SelectedValue = pagePara.ShopID;
            }
            if (!String.IsNullOrEmpty(pagePara.GuideID))
            {
                guideComboBox1.SelectedValue = pagePara.GuideID;
            }
            skinComboBox_type.SelectedValue = pagePara.RetailOrderType;
        }

        private void RetailOrderSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
           // retailOrderListCtrl2.Show();
        }

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue);
            this.guideComboBox1.Initialize(Common.GuideComboBoxInitializeType.All, shopID);
        }

        private void skinComboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isRefund = RetailOrderType.RefundOrder == (RetailOrderType)this.skinComboBox_type.SelectedValue;
            SetState(isRefund);
           // retailOrderListCtrl2.ShowPrintColumn(!isRefund);
        } 

        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }

        private void retailOrderListCtrl2_Load(object sender, EventArgs e)
        {

        }
    }
}
