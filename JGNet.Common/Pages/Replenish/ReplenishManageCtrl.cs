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
using CJBasic.Helpers;
using CJBasic;

namespace JGNet.Common
{
    public partial class ReplenishManageCtrl : BaseModifyUserControl
    { private String shopID;

        private ReplenishCostumePagePara pagePara;

        private ReplenishOrderState orderState = ReplenishOrderState.All;
      private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;

        public bool isOpenDate = true;

        /// <summary>
        /// 点击补货申请单明细触发
        /// </summary>
        public event CJBasic.Action<ReplenishOrder,Panel,bool> ReplenishDetailClick;
        public event CJBasic.Action<ReplenishOrder, Panel, string> ReplenishDetailExcept;
        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        public event CJBasic.Action<ReplenishOrder, BaseUserControl> OutboundClick;
        public event CJBasic.Action<ReplenishOrder, BaseUserControl> ReReplenishClick;
        public event CJBasic.Action<ReplenishOrder, BaseUserControl> PickClick; 


        /// <summary>
        /// 点击收货按钮触发 参数：string 源OrderID; Type 源OrderID
        /// </summary>
        public event CJBasic.Action<string, BaseUserControl> InboundClick;

        public ReplenishManageCtrl()
        { 
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click,new string[] { totalCountDataGridViewTextBoxColumn.DataPropertyName, totalPriceDataGridViewTextBoxColumn.DataPropertyName });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();  
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            Initialize();
            MenuPermission = RolePermissionMenuEnum.店铺补货单查询;
        }

        public ReplenishManageCtrl(ReplenishOrderState state)
        {
            InitializeComponent();
            orderState = state;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, new string[] { totalCountDataGridViewTextBoxColumn.DataPropertyName, totalPriceDataGridViewTextBoxColumn.DataPropertyName });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;

            Initialize();
            MenuPermission = RolePermissionMenuEnum.店铺补货单查询;
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.All), (int)ReplenishOrderState.All));
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.Cancel), (int)ReplenishOrderState.Cancel));
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.NotProcessing), (int)ReplenishOrderState.NotProcessing));
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.Processing), (int)ReplenishOrderState.Processing));
            //stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.OverrideOrder), (int)ReplenishOrderState.OverrideOrder));
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.Refused), (int)ReplenishOrderState.Refused));
            stateList.Add(new ListItem<int>(JGNet.Core.Tools.EnumHelper.GetDescription(ReplenishOrderState.HangUp), (int)ReplenishOrderState.HangUp));


            this.skinComboBoxState.DisplayMember = "Key";
            this.skinComboBoxState.ValueMember = "Value";
            this.skinComboBoxState.DataSource = stateList;
            this.skinComboBoxState.SelectedValue = (int)this.orderState;
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.BindingReplenishOrderSource(null);
            this.skinTextBox_OrderID.SkinTxt.Text = string.Empty;
            this.pagePara = new ReplenishCostumePagePara();
            this.skinComboBoxShopID.Initialize(false, true);
            SetDisplay();
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void SetDisplay()
        {
            //if (IsPos)
            //{
            //    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(ColumnCancel, ColumnReject, ColumnPick);
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(column_send, Column_ShopName);
            //}
            //else
            //{
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnPick);
            //    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(ColumnCancel, ColumnReject, column_send, Column_ShopName);
            //}
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (pagePara == null)
                {
                    return;
                }
                pagePara.PageIndex = index;
                ReplenishCostumePage listPage = CommonGlobalCache.ServerProxy.GetReplenishCostumePage(pagePara);
                this.BindingReplenishOrderSource(listPage);

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


        public void WorkTableInfo_Search() {
            isOpenDate = false;
            this.BaseButton_Search_Click(null,null);
            isOpenDate = true;
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                string orderID = string.IsNullOrEmpty(this.skinTextBox_OrderID.SkinTxt.Text) ? null : this.skinTextBox_OrderID.SkinTxt.Text;
                this.pagePara = new ReplenishCostumePagePara()
                {
                    CostumeID = costumeTextBox1.Text,
                    ReplenishOrderID = orderID,
                    IsOpenDate = this.isOpenDate,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                    ShopID = shopID,
                    ReplenishOrderState = (ReplenishOrderState)this.skinComboBoxState.SelectedValue,
                    BrandID = -1
                     
                };
                ReplenishCostumePage listPage = CommonGlobalCache.ServerProxy.GetReplenishCostumePage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingReplenishOrderSource(listPage);

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
        /// 绑定plenishOrderSource源到dataGridView中
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingReplenishOrderSource(ReplenishCostumePage listPage )
        {
           
             
            if (listPage != null && listPage.ReplenishOrderList != null && listPage.ReplenishOrderList.Count > 0)
            {

                List<ReplenishOrder> details = listPage.ReplenishOrderList;
                foreach (var order in details)
                {
                    order.ShopName = CommonGlobalCache.GetShopName(order.ShopID);
                    order.GuideName = CommonGlobalCache.GetUserName(order.RequestGuideID);
                }
                listPage.ReplenishOrderSum.CreateTime = default(DateTime); 
               
            }
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage?.ReplenishOrderList, null, listPage?.TotalEntityCount, listPage?.ReplenishOrderSum);
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        #region 点击单元格
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                List<ReplenishOrder> curReplenishOrderListSource = (List<ReplenishOrder>)this.dataGridView1.DataSource;
                ReplenishOrder item = curReplenishOrderListSource[e.RowIndex];
                if (e.ColumnIndex == iDDataGridViewTextBoxColumn.Index)
                {
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.ReplenishDetailClick?.Invoke(item, this.skinSplitContainer1.Panel2, false);
                }
                else if (e.ColumnIndex == column_send.Index)
                {
                    //点击【发货】按钮跳转到“调拨”页
                    this.Outbound(item);
                }
                //else if (e.ColumnIndex == column_receipt.Index)
                //{
                //    this.Inbound(item);
                //}
                else if (e.ColumnIndex == ColumnReject.Index)
                {
                    this.Refund(item);
                }
                else if (e.ColumnIndex == ColumnCancel.Index)
                {
                    this.Cancel(item);
                }
                else if (ColumnPick.Index == e.ColumnIndex)
                {
                    this.Pick(item);
                }
                else if (ColumnPrint.Index == e.ColumnIndex)
                {
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.ReplenishDetailClick?.Invoke(item, this.skinSplitContainer1.Panel2, true);
                }
                else if (Column1.Index == e.ColumnIndex)
                {
                    path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "补货申请单" + item.ID + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    if (String.IsNullOrEmpty(path))
                    {
                        return;
                    }

                    this.ReplenishDetailExcept?.Invoke(item, this.skinSplitContainer1.Panel2, path);
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
        private string path;
        private void Refund(ReplenishOrder item)
        {
            if (GlobalMessageBox.Show("是否确认拒绝该笔补货申请单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;

            }
            InteractResult result = CommonGlobalCache.ServerProxy.RefusedReplenishOrder(item.ID);
            switch (result.ExeResult)
            {
                case ExeResult.Success: 
                    item.State = (byte)ReplenishOrderState.Refused;
                    GlobalMessageBox.Show("已拒绝！");
                    dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
                    break;
                case ExeResult.Error:
                    GlobalMessageBox.Show(result.Msg);
                    break;
                default:
                    break;
            }
        }

  
        private void ReAllocate(ReplenishOrder item)
        {
            this.ReReplenishClick?.Invoke(item,this);
        }

        private void Pick(ReplenishOrder item)
        {
            this.PickClick?.Invoke(item, this);
        }

        private void Cancel(ReplenishOrder item)
        {
            if (GlobalMessageBox.Show("确定取该笔补货申请单吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;

            }
            InteractResult result = CommonGlobalCache.ServerProxy.CancelReplenish(item.ID);
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    // item.State = -1;
                    item.State = (byte)ReplenishOrderState.Cancel;
                    GlobalMessageBox.Show("已取消！");
                    dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);

                    break;
                case ExeResult.Error:
                    GlobalMessageBox.Show(result.Msg);
                    break;
                default:
                    break;
            }
        }
        #endregion


        /// <summary>
        /// 收货入库
        /// </summary>
        /// <param name="orderID"></param>
        private void Inbound(ReplenishOrder order)
        {
            if (order.State != (byte)ReplenishOrderState.Processing)
            {
                GlobalMessageBox.Show("订单状态不是已发货，不能收货！");
                return;
            }
            if (this.InboundClick != null)
            {
                this.InboundClick(order.ID, this);
            }
        }

        /// <summary>
        /// 收货入库
        /// </summary>
        /// <param name="orderID"></param>
        private void Outbound(ReplenishOrder order)
        {
            if (order.State != (byte)ReplenishOrderState.NotProcessing)
            {
                GlobalMessageBox.Show("订单状态不是未发货，不能发货！");
                return;
            }
            if (this.OutboundClick != null)
            { 
                this.OutboundClick(order,this);
            }
        }
        /// <summary>
        /// 刷新绑定源
        /// </summary> 
        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
        }
         
        private void ReplenishManageCtrl_Load(object sender, EventArgs e)
        {
        }

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            ReplenishOrder order = (ReplenishOrder)row.DataBoundItem;
            if (e.Value == null)
            {
                return;
            }


            //已发货不显示发货和取消，可以收货 
            if (order.State == (int)ReplenishOrderState.Processing)
            {
                if (column_send.Index == e.ColumnIndex || ColumnReject.Index == e.ColumnIndex || ColumnCancel.Index == e.ColumnIndex)
                {
                    e.Value = null;
                }
            }
            else if (order.State == (int)ReplenishOrderState.NotProcessing)
            {

                if (ColumnReject.Index == e.ColumnIndex)
                {
                    if (order.ShopID != CommonGlobalCache.CurrentShopID)
                    {
                        
                    }
                    else
                    {
                        e.Value = null;
                    }
                }
                else if (ColumnCancel.Index == e.ColumnIndex)
                {
                    //if (order.ShopID != CommonGlobalCache.CurrentShopID)
                    //{
                    //    e.Value = null;
                    //}
                }
            }
            //else if (order.State == (int)ReplenishOrderState.OverrideOrder) {
            //    //冲单
            //    if (column_send.Index == e.ColumnIndex 
            //        /*|| column_receipt.Index == e.ColumnIndex*/)
            //    {
            //        e.Value = null;
            //    }  
            //}
            else if (order.State == (int)ReplenishOrderState.Refused || order.State == (int)ReplenishOrderState.Cancel || order.State == (int)ReplenishOrderState.HangUp)
            {
                ///232 20180420 增加
                //已完成,已取消，不能操作
                if (ColumnCancel.Index == e.ColumnIndex || column_send.Index == e.ColumnIndex || ColumnReject.Index == e.ColumnIndex)
                {
                    e.Value = null;
                }
                //if (column_receipt.Index == e.ColumnIndex)
                //{
                //    e.Value = null;
                //}
            }

            if (order.State != (int)ReplenishOrderState.HangUp)
            {
                ///232 20180420 增加
                //已完成,已取消，不能操作
                if (ColumnPick.Index == e.ColumnIndex )
                {
                    e.Value = null;
                }
                //if (column_receipt.Index == e.ColumnIndex)
                //{
                //    e.Value = null;
                //}
            }
        } 

        private void costumeTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }
    }
}
