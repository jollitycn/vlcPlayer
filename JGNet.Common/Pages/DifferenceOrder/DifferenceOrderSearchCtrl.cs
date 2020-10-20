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
using JGNet.Core;
using JGNet.Common.Components;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class DifferenceOrderSearchCtrl : BaseModifyUserControl
    {
        private bool isOnlyGetOut = false;
        private Shop shop;
        private string shopID;
        private DifferenceOrderPagePara pagePara;

        private bool isOpenDate = true;


        /// <summary>
        /// 点击查询入库差异单明细
        /// </summary>
        public event CJBasic.Action<DifferenceOrder, BaseUserControl,Panel > DifferenceOrderDetailClick;
        public event CJBasic.Action<String, BaseUserControl,Panel> OutboundOrderDetailClick;
        public event CJBasic.Action<String, BaseUserControl,Panel> InboundOrderDetailClick;
        public event CJBasic.Action<String, BaseUserControl,Panel> SourceOrderDetailClick;
         
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public DifferenceOrderSearchCtrl()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged,BaseButton_Search_Click, 
                new string[] { totalDiffCountDataGridViewTextBoxColumn.DataPropertyName });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
            MenuPermission = RolePermissionMenuEnum.差异单查询;
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            skinToolTip1.SetToolTip(this.skinTextBox_OrderID.SkinTxt, this.skinTextBox_OrderID.WaterText);
            shop = IsPos ? CommonGlobalCache.CurrentShop : null;
            shopID = IsPos ? shop.ID : null;
            SetComboBox_State();
            this.dataGridView1.DataSource = null;
            this.skinTextBox_OrderID.SkinTxt.Text = String.Empty;
            costumeTextBox1.Text = string.Empty;
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            SetOrderPrefix();
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void SetOrderPrefix()
        {

            List<ListItem<string>> stateList = new List<ListItem<string>>();
            stateList.Add(new ListItem<string>(CommonGlobalUtil.COMBOBOX_ALL, null));
            stateList.Add(new ListItem<string>("调拨", OrderPrefix.AllocateOrder));
            stateList.Add(new ListItem<string>("盘点", OrderPrefix.CheckStoreOrder));
            
           // stateList.Add(new ListItem<string>("补货申请", OrderPrefix.ReplenishOrder));


            this.skinComboBox_orderPrefix.DisplayMember = "Key";
            this.skinComboBox_orderPrefix.ValueMember = "Value";
            this.skinComboBox_orderPrefix.DataSource = stateList;
            //默认为调拨单
            skinComboBox_orderPrefix.SelectedValue = OrderPrefix.AllocateOrder;
        }

        private void SetComboBox_State()
        {
            List<ListItem<DifferenceOrderConfirmed>> stateList = new List<ListItem<DifferenceOrderConfirmed>>();
            stateList.Add(new ListItem<DifferenceOrderConfirmed>(CommonGlobalUtil.COMBOBOX_ALL, DifferenceOrderConfirmed.All));
            stateList.Add(new ListItem<DifferenceOrderConfirmed>("已确认", DifferenceOrderConfirmed.True));
            stateList.Add(new ListItem<DifferenceOrderConfirmed>("未确认", DifferenceOrderConfirmed.False));

            this.skinComboBox_State.DisplayMember = "Key";
            this.skinComboBox_State.ValueMember = "Value";
            this.skinComboBox_State.DataSource = stateList; 
        }
        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                DifferenceOrderPage listPage = CommonGlobalCache.ServerProxy.GetDifferenceOrderPage(this.pagePara);
                this.BindingDifferenceOrderSource(listPage);
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
                if ( CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                string orderID = string.IsNullOrEmpty(this.skinTextBox_OrderID.SkinTxt.Text) ? null : this.skinTextBox_OrderID.SkinTxt.Text;
                string costumeID = string.IsNullOrEmpty(this.costumeTextBox1.SkinTxt.Text) ? null : this.costumeTextBox1.SkinTxt.Text;
                this.pagePara = new DifferenceOrderPagePara()
                {    
                    OrderID = orderID,
                    CostumeID = costumeID,
                    IsOpenDate = this.isOpenDate,
                    IsOnlyGetOut = this.isOnlyGetOut,
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                    ShopID = shopID,
                     
                    OrderPrefixType = ValidateUtil.CheckEmptyValue( this.skinComboBox_orderPrefix.SelectedValue),
                    DifferenceOrderConfirmed = (DifferenceOrderConfirmed)this.skinComboBox_State.SelectedValue

                };
                DifferenceOrderPage listPage = CommonGlobalCache.ServerProxy.GetDifferenceOrderPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingDifferenceOrderSource(listPage);
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

        #region 绑定DifferenceOrder数据源
        private void BindingDifferenceOrderSource(DifferenceOrderPage listPage)
        {
             
            if (listPage != null && listPage.DifferenceOrderList != null && listPage.DifferenceOrderList.Count > 0)
            {
                //将名称赋值，用于显示
                foreach (DifferenceOrder order in listPage.DifferenceOrderList)
                {
                    order.InboundShopName = CommonGlobalCache.GetShopName(order.InboundShopID);
                    order.OutboundShopName = CommonGlobalCache.GetShopName(order.OutboundShopID);
                }
                 }
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage?.DifferenceOrderList, null, listPage?.TotalEntityCount, listPage?.DifferenceOrderSum);

            this.skinSplitContainer1.Panel2Collapsed = true;
            this.dataGridView1.Refresh();
        }
        #endregion

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
                List<DifferenceOrder> list = (List<DifferenceOrder>)this.dataGridView1.DataSource;
                DifferenceOrder item = (DifferenceOrder)list[e.RowIndex];
                if (e.ColumnIndex == iDDataGridViewTextBoxColumn.Index)
                {
                    item.Print = false;
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.DifferenceOrderDetailClick?.Invoke(item,this, this.skinSplitContainer1.Panel2);
                }
                else if (e.ColumnIndex == InboundOrderID.Index)
                {
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.InboundOrderDetailClick?.Invoke(item.InboundOrderID, this, this.skinSplitContainer1.Panel2);
                }
                else if (e.ColumnIndex == OutboundOrderID.Index)
                {
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.OutboundOrderDetailClick?.Invoke(item.OutboundOrderID, this, this.skinSplitContainer1.Panel2);
                }
                else if (e.ColumnIndex == sourceOrderIDDataGridViewTextBoxColumn1.Index)
                {
                   /* this.skinSplitContainer1.Panel2Collapsed = false;
                    this.SourceOrderDetailClick?.Invoke(item.SourceOrderID, this, this.skinSplitContainer1.Panel2);*/
                }
                else if (e.ColumnIndex == ColumnPrint.Index)
                {
                    item.Print = true;
                    this.DifferenceOrderDetailClick?.Invoke(item, this, this.skinSplitContainer1.Panel2);

                }

            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }


        #endregion

        public override void RefreshPage()
        { 
            this.skinSplitContainer1.Panel2Collapsed = true;
            if (this.pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(this.pagePara.PageIndex);
            }
        }

        /// <summary>
        /// 工作台跳转到差异单查询
        /// </summary>
        /// <param name="differenceOrderConfirmed"></param>
        public void WorkDifferenceOrderStateSearch(DifferenceOrderConfirmed differenceOrderConfirmed)
        {
            this.skinComboBox_State.SelectedValue = differenceOrderConfirmed;
           // this.isOpenDate = false;
            //进来时是自己的 
            this.BaseButton_Search_Click(null, null);
            this.shopID = CommonGlobalCache.CurrentShopID;
            this.skinComboBox_orderPrefix.SelectedValue = OrderPrefix.AllocateOrder;
            this.skinComboBox_State.SelectedValue = DifferenceOrderConfirmed.False;
            DateTimeUtil.DateTimePicker_All(dateTimePicker_Start, dateTimePicker_End);
            this.isOnlyGetOut = true;
            this.isOpenDate = true;

            BaseButton_Search_Click(null, null);
             
        }


        /// <summary>
        /// 根据差异单确认状态查询
        /// </summary>
        /// <param name="differenceOrderConfirmed"></param>
        public void DifferenceOrderStateSearch(DifferenceOrderConfirmed differenceOrderConfirmed)
        {
            this.skinComboBox_State.SelectedValue = differenceOrderConfirmed;
            this.isOpenDate = false;
            //进来时是自己的
            this.shopID = CommonGlobalCache.CurrentShopID;
            this.isOnlyGetOut = true;
            this.BaseButton_Search_Click(null, null);
            this.shopID = IsPos ? shop.ID: null;
            this.isOnlyGetOut = false;
            this.isOpenDate = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DifferenceOrder order = (DifferenceOrder)row.DataBoundItem;

            if (Confirmed.Index == e.ColumnIndex)
            {

                e.Value = order.Confirmed ? "已确认" : "未确认";
            }
            else if (SourceType.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalUtil.OrderType(order.SourceOrderID);
            } 
        }

        private void DifferenceOrderSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
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

