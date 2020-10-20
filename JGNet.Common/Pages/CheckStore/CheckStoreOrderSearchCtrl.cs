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
using JGNet.Common.Core.Util;
using CJBasic;

namespace JGNet.Common

{
    public partial class CheckStoreOrderSearchCtrl : BaseModifyUserControl
    {
        private CheckStoreOrderPagePara pagePara = null;
        private String shopID;

         
        /// <summary>
        /// 点击修改盘点差异单
        /// </summary>
        public event CJBasic.Action<CheckStoreOrder,  BaseUserControl> UpdateCheckStoreOrderClick;
        public event CJBasic.Action<CheckStoreOrder, BaseUserControl,Panel> CheckStoreDetailClick;
        public event CJBasic.Action<CheckStoreOrder, BaseUserControl, string> CheckStoreDetailExcept;
        /// <summary>
        /// 点击差异单明细
        /// </summary>

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public CheckStoreOrderSearchCtrl()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, new string[] { CheckStoreWinCount.DataPropertyName, CheckStoreLostCount.DataPropertyName, CheckStoreSum.DataPropertyName });
            //if (IsPos)
            //{
             //   dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnCancel);
         //   }
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
            skinSplitContainer1.Panel2Collapsed = true;
            MenuPermission = RolePermissionMenuEnum.盘点单查询;

            checkStoreDetailCtrl1.MenuPermission = RolePermissionMenuEnum.盘点单查询;
        }
         

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {

            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
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
                CheckStoreOrderPage listPage = CommonGlobalCache.ServerProxy.GetCheckStoreOrderPage(this.pagePara);
                this.BindingCheckStoreOrderBindingSource(listPage);
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
            string orderID = string.IsNullOrEmpty(this.skinTextBox_OrderID.SkinTxt.Text) ? null : this.skinTextBox_OrderID.SkinTxt.Text;
            this.pagePara = new CheckStoreOrderPagePara()
            {
                CheckStoreOrderID = orderID,
                IsOpenDate = true,
                StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                ShopID = shopID,
                CostumeID= CostumeCurrentShopTextBox1.Text,
                State = (CheckStoreOrderState)this.skinComboBox_State.SelectedValue,
            };
            Search();
        }

        public void WorkDeskCtrlSearch(CheckStoreOrderState state)
        {
            this.pagePara = new CheckStoreOrderPagePara()
            {
                CheckStoreOrderID = null,
                IsOpenDate = false,
                StartDate = null,
                EndDate = null,
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                ShopID = shopID,
                 CostumeID= CostumeCurrentShopTextBox1.Text,
                State = state
            };
            Search();
        }

        public void Search(String orderId)
        {
            skinTextBox_OrderID.Text = orderId;
            DateTimeUtil.DateTimePicker_All(dateTimePicker_Start, dateTimePicker_End);
            BaseButton_Search_Click(null, null);
        }

        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (pagePara.State == CheckStoreOrderState.ChildOrder)
                {
                    // EmOnlinePrice.DataPropertyName = "EmOnlinePrice";

                    // dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(Column2, Column1, CreateTime, Column4, EmIsRecommandColumn, QuantityOfSale, EmTitle, IsHot, IsNew, PfShowOnline, EmShowOnline);
                    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnCancel, ColumnRedo, ColumnPrint, CheckUserID);
                }
                else
                {
                    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(ColumnCancel, ColumnRedo, ColumnPrint, CheckUserID);
                }
                CheckStoreOrderPage listPage = CommonGlobalCache.ServerProxy.GetCheckStoreOrderPage(this.pagePara);
               
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingCheckStoreOrderBindingSource(listPage);
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

        #region 绑定CheckStoreOrder源
        private void BindingCheckStoreOrderBindingSource(CheckStoreOrderPage listPage)
        {

            if (listPage != null && listPage.CheckStoreOrderList != null && listPage.CheckStoreOrderList.Count > 0)
            {
                //将名称赋值，用于显示
                foreach (CheckStoreOrder order in listPage.CheckStoreOrderList)
                {
                    order.OperatorUserName = CommonGlobalCache.GetUserName(order.OperatorUserID);
                    order.CheckUserName = CommonGlobalCache.GetUserName(order.CheckUserID);
                    order.ShopName = CommonGlobalCache.GetShopName(order.ShopID);
                }

            }
            this.skinSplitContainer1.Panel2Collapsed = true;
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage?.CheckStoreOrderList, null, listPage?.TotalEntityCount, listPage?.CheckStoreOrderSum);
        }
        #endregion

        CheckStoreOrder currentCheckStoreOrder = null;
        #region 点击单元格
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            List<CheckStoreOrder> list = (List<CheckStoreOrder>)this.dataGridView1.DataSource;
            CheckStoreOrder checkStoreOrder = list[e.RowIndex];

            if (e.ColumnIndex == iDDataGridViewTextBoxColumn.Index)
            {
                if (currentCheckStoreOrder != checkStoreOrder)
                {
                    currentCheckStoreOrder = checkStoreOrder;
                    SelectionChanged(checkStoreOrder);
                }

                if (checkStoreOrder == null || String.IsNullOrEmpty(checkStoreOrder.ID)) { return; }
            }
            else if (e.ColumnIndex == ColumnEdit.Index)
            {
                this.UpdateCheckStoreOrderClick?.Invoke(checkStoreOrder, this);
            }
            else if (e.ColumnIndex == ColumnDelete.Index)
            {
                try
                {
                    //删除
                    if (GlobalMessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (CommonGlobalUtil.EngineUnconnectioned(this))
                        {
                            return;
                        }
                        DeleteCheckStoreResult result = CommonGlobalCache.ServerProxy.DeleteCheckStore(checkStoreOrder.ID);
                        switch (result)
                        {
                            case DeleteCheckStoreResult.Success:
                                GlobalMessageBox.Show("删除成功！");
                                //含统计信息，从刷界面
                                dataGridViewPagingSumCtrl_CurrentPageIndexChanged(this.pagePara.PageIndex);
                                break;
                            case DeleteCheckStoreResult.StateIsPendingReviewOrApproved:
                                GlobalMessageBox.Show("状态是待审核或已审核，不能删除");
                                break;
                            case DeleteCheckStoreResult.Error:
                                GlobalMessageBox.Show("内部错误！");
                                break;
                            default:
                                break;
                        }
                    }
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
            else if (ColumnCancel.Index == e.ColumnIndex)
            {
                this.Cancel(checkStoreOrder);
            }
            else if (ColumnRedo.Index == e.ColumnIndex)
            {
                this.Redo(checkStoreOrder);
            }
            else if (e.ColumnIndex == ColumnPrint.Index)
            {
                //打印
                if (currentCheckStoreOrder != checkStoreOrder)
                {
                    currentCheckStoreOrder = checkStoreOrder;
                    SelectionChanged(checkStoreOrder);
                }

                if (checkStoreOrder == null || String.IsNullOrEmpty(checkStoreOrder.ID)) { return; }
                checkStoreDetailCtrl1?.Print();
            }
            else if (e.ColumnIndex == Column1.Index)
            {
                //导出
                path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "盘点单" + checkStoreOrder.ID + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                if (String.IsNullOrEmpty(path))
                {
                    return;
                }

                // this.CheckStoreDetailExcept?.Invoke(checkStoreOrder, this, path);
                checkStoreDetailCtrl1?.DoExport(path, checkStoreOrder);

            }

        }
        private string path=string.Empty;
        private String userID;
private void Cancel(CheckStoreOrder allocateOrder)
{
    try
    {
        if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }
        if (CommonGlobalUtil.EngineUnconnectioned(this))
        {
            return;
        }
        InteractResult result = null;
              /*  if (IsPos)
                {
                    GuideSelectForm form = new GuideSelectForm(GuideComboBoxInitializeType.Normal, shopID);
                    form.ConfirmClick += form_ConfirmClick;
                    form.ShowDialog();
                }*/
                
                userID = CommonGlobalCache.CurrentUserID;
                allocateOrder.CancelUserID = CommonGlobalCache.CurrentUserID;

                result = CommonGlobalCache.ServerProxy.OverrideCheckStore(allocateOrder.ID, userID);
        switch (result?.ExeResult)
        {
            case ExeResult.Success:
                GlobalMessageBox.Show("冲单成功！");
                break;
            case ExeResult.Error:
                GlobalMessageBox.Show(result.Msg);
                break;
            default:
                break;
        }
        this.RefreshPage();
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

        private void form_ConfirmClick(string guideID)
        {
           userID = guideID;
           // form.DialogResult = DialogResult.OK;
        }

        public event CJBasic.Action<CheckStoreOrder, BaseUserControl> RedoClick;

        private void Redo(CheckStoreOrder allocateOrder)
        {
            if (this.RedoClick != null)
            {
                this.RedoClick(allocateOrder, this);
            }
        }

        private void SelectionChanged(CheckStoreOrder checkStoreOrder)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (checkStoreOrder == null || String.IsNullOrEmpty(checkStoreOrder.ID)) { return; }
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.checkStoreDetailCtrl1.Search(checkStoreOrder,this); 
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

        private void BindingCheckStoreDetailSource(List<CheckStoreDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (CheckStoreDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }
            }

            this.dataGridViewPagingSumCtrl.BindingDataSource<CheckStoreDetail>(list);
        }

        #endregion

        //回调刷新界面
        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
        }

        private void CheckStoreOrderSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
            
        }

        private void Initialize()
        {
            skinToolTip1.SetToolTip(this.skinTextBox_OrderID.SkinTxt, this.skinTextBox_OrderID.WaterText);
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            skinComboBoxShop.Initialize();
            this.skinTextBox_OrderID.SkinTxt.Text = string.Empty;
            this.dataGridView1.DataSource = null;
            SetState();

            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void SetState()
        {
            #region 初始化skinComboBox_State
            List<ListItem<CheckStoreOrderState>> listItems = new List<ListItem<CheckStoreOrderState>>();
            listItems.Add(new ListItem<CheckStoreOrderState>(CommonGlobalUtil.COMBOBOX_ALL, CheckStoreOrderState.All));
            listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.Approved), CheckStoreOrderState.Approved));
            //listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.Canceled), CheckStoreOrderState.Canceled));
            //listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.Expired), CheckStoreOrderState.Expired));
            listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.PendingReview), CheckStoreOrderState.PendingReview));
            listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.Suspend), CheckStoreOrderState.Suspend));
            //listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.TaskIsCancel), CheckStoreOrderState.TaskIsCancel));
            listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.OverrideOrder), CheckStoreOrderState.OverrideOrder));
            listItems.Add(new ListItem<CheckStoreOrderState>(CheckStoreOrder.GetStateName(CheckStoreOrderState.ChildOrder), CheckStoreOrderState.ChildOrder));

            this.skinComboBox_State.DisplayMember = "Key";
            this.skinComboBox_State.ValueMember = "Value";
            this.skinComboBox_State.DataSource = listItems;
            #endregion
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;

            }
            DataGridViewUtil.CellFormatting_ReportShowZero(e, this.ReportShowZero);

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            CheckStoreOrder order = (CheckStoreOrder)row.DataBoundItem;
            if (ColumnDelete.Index == e.ColumnIndex || ColumnEdit.Index == e.ColumnIndex)
            {
                //已取消，不能修改
                CheckStoreOrderState orderState = (CheckStoreOrderState)order.State;
                if (orderState == CheckStoreOrderState.TaskIsCancel || orderState == CheckStoreOrderState.OverrideOrder)
                {
                    e.Value = null;
                }
                //else if (
                //    order.ShopID != CommonGlobalCache.CurrentShopID
                //    )
                ////  && !CommonGlobalUtil.IsAdminUser(order.OperatorUserID))
                //{    //店铺是自己的可以删可以改,
                //     //失效、退回、挂单可以删除
                //     //是管理端发起的盘点，POS端不能修改删除
                //    e.Value = null;
                //}
                else if ((CheckStoreOrderState)order.State == CheckStoreOrderState.Approved)
                {
                    //审核待审核不能删除，并且店铺不是自己的
                    //shopID=null 这是总仓
                    e.Value = null;
                }
            }
            else if (createTimeDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                if ((CheckStoreOrderState)order.State == CheckStoreOrderState.Suspend)
                {
                    e.Value = null;
                }
            }
            else if (e.ColumnIndex == ColumnCancel.Index)
            {
                if (
                    //IsPos ||
                    (CheckStoreOrderState)order.State != CheckStoreOrderState.Approved
                    || (CheckStoreOrderState)order.State == CheckStoreOrderState.ChildOrder/*|| order.ShopID != CommonGlobalCache.CurrentShopID*/)
                {
                    e.Value = null;
                }
            }
            else if (e.ColumnIndex == ColumnRedo.Index)
            {
                if ((CheckStoreOrderState)order.State != CheckStoreOrderState.OverrideOrder
                    //  || order.ShopID != CommonGlobalCache.CurrentShopID 
                    || (CheckStoreOrderState)order.State == CheckStoreOrderState.ChildOrder)
                {
                    e.Value = null;
                }
            }
            else if (e.ColumnIndex == ColumnPrint.Index)
            {
                if ((CheckStoreOrderState)order.State == CheckStoreOrderState.ChildOrder)
                {
                    e.Value = null;
                }
            }
        }

        private void skinComboBoxShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue);
        } 
    }
}
