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

namespace JGNet.Common
{
    /// <summary>
    /// pos端的调拨查询，manage端的总仓调拨
    /// </summary>
    public partial class CurrentShopAllocateManageCtrl : BaseModifyUserControl
    {
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2; 
        private AllocateOrderPagePara pagePara;
        private bool isAllocateInbound = true;//是否是调拨入库   true:调拨入库  false:调拨
        AllocateOrderState state;
        private List<AllocateOrder> curAllocateOrderListSource;//当前绑定的AllocateOrder集合源

        /// <summary>
        /// 点击调拨单入库明细触发
        /// </summary>
        public event CJBasic.Action<String, BaseUserControl, Panel> InboundDetailClick;

        /// <summary>
        /// 点击调拨单出库明细触发
        /// </summary>
        public event CJBasic.Action<String, BaseUserControl, Panel> OutboundDetailClick;

        /// <summary>
        /// 点击收货按钮触发 参数：源OrderID
        /// </summary>
        public event CJBasic.Action<string, BaseUserControl, Panel> InboundClick;
        public event CJBasic.Action<AllocateOrder, BaseUserControl> ReAllocateClick;
        public event CJBasic.Action<AllocateOrder, BaseUserControl> PickClick;


        /// <summary>
        /// 调拨查询管理
        /// </summary>
        /// <param name="state">调拨状态</param>
        /// <param name="isAllocateInbound">true:调拨入库  false:调拨</param>
        public CurrentShopAllocateManageCtrl(AllocateOrderState state = AllocateOrderState.All)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(this.dataGridView2, new string[] {
             xSDataGridViewTextBoxColumn.DataPropertyName,
       sDataGridViewTextBoxColumn.DataPropertyName,
       mDataGridViewTextBoxColumn.DataPropertyName,
       lDataGridViewTextBoxColumn.DataPropertyName,
       xLDataGridViewTextBoxColumn.DataPropertyName,
       xL2DataGridViewTextBoxColumn.DataPropertyName,
       xL3DataGridViewTextBoxColumn.DataPropertyName,
       xL4DataGridViewTextBoxColumn.DataPropertyName,
       xL5DataGridViewTextBoxColumn.DataPropertyName,
       xL6DataGridViewTextBoxColumn.DataPropertyName,
       fDataGridViewTextBoxColumn.DataPropertyName
            });
            dataGridViewPagingSumCtrl2.SpecAutoSizeModeColumns(new DataGridViewColumn[] { costumeIDDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl2.Initialize();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, new string[] { totalCountDataGridViewTextBoxColumn.DataPropertyName, totalPriceDataGridViewTextBoxColumn.DataPropertyName });

            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn});
            dataGridViewPagingSumCtrl.Initialize();

            dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
            this.createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            this.dataGridView1.AutoGenerateColumns = false;
            this.state = state;


           
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            isAllocateInbound = true;
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.costumeTextBox1.Text = string.Empty;
            this.skinTextBox_OrderID.SkinTxt.Text = string.Empty;
            CommonGlobalUtil.SetAllocateOrderState(skinComboBox_State);
            CommonGlobalUtil.SetShop(skinComboBox_DestShop); 
            //#endregion

            this.skinComboBox_State.SelectedValue = state;
            this.SetFormByIsAllocateInbound();
            this.dataGridView1.DataSource = null;

            this.skinSplitContainer1.Panel2Collapsed = true;
        }



        private void SetFormByIsAllocateInbound()
        {
            if (this.isAllocateInbound)
            {
                this.skinComboBox_AllocateType.SelectedIndex = 0;
            }
            else
            {
                this.skinComboBox_AllocateType.SelectedIndex = 1;
            }
        }
        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
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

                pagePara.PageIndex = index;
                AllocateOrderPage listPage = null;
                //if (this.isAllocateInbound)
                //{
                listPage = CommonGlobalCache.ServerProxy.GetAllocateOrderPage(this.pagePara);
                //}
                //else
                //{
                //    listPage = CommonGlobalCache.ServerProxy.GetAllocateOutboundPage(this.pagePara);
                //}
                this.BindingAllocateOrderSource(listPage);
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

        private void BindingAllocateOrderSource(AllocateOrderPage listPage)
        {
            skinSplitContainer1.Panel2Collapsed = true;
            curAllocateOrderListSource = null;
            if (listPage != null && listPage.AllocateOrderList != null && listPage.AllocateOrderList.Count > 0)
            {
                this.curAllocateOrderListSource = listPage.AllocateOrderList;

                foreach (var item in listPage.AllocateOrderList)
                {
                    switch (item.State)
                    {
                        case (byte)AllocateOrderState.Delivery:
                            // item.Operation = this.isAllocateInbound ?"收货":"冲单";
                            item.Operation = item.DestShopID == CommonGlobalCache.CurrentShopID ? "收货" : string.Empty;
                            if (String.IsNullOrEmpty(item.Operation))
                            {
                                item.Operation = item.SourceShopID == CommonGlobalCache.CurrentShopID ? "冲单" : string.Empty;
                            }
                            break;
                        case (byte)AllocateOrderState.OverrideOrder:
                            item.Operation = this.isAllocateInbound ? string.Empty : "重做";
                            break;
                        case (byte)AllocateOrderState.HangUp:
                            item.Operation = this.isAllocateInbound ? string.Empty : "提单";
                            break;
                        default:
                            item.Operation = string.Empty;
                            break;
                    }
                }
            }
            this.dataGridViewPagingSumCtrl.BindingDataSource(this.curAllocateOrderListSource, null, listPage?.TotalEntityCount, listPage?.AllocateOrderSum);
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
                string costumeID = string.IsNullOrEmpty(this.costumeTextBox1.SkinTxt.Text) ? null : this.costumeTextBox1.SkinTxt.Text;


                pagePara = new AllocateOrderPagePara()
                {
                    CostumeID = costumeID,
                    AllocateOrderID = orderID,
                    AllocateOrderState = (AllocateOrderState)this.skinComboBox_State.SelectedValue,
                    IsOpenDate = true,
                    SourceShopID = CommonGlobalCache.CurrentShopID,
                    DestShopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_DestShop.SelectedValue),
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize
                };
                Search();
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

        private void Search()
        {
            AllocateOrderPage listPage = null;
            if (this.isAllocateInbound)
            {
                this.pagePara.SourceShopID = (string)this.skinComboBox_DestShop.SelectedValue;
                this.pagePara.DestShopID = CommonGlobalCache.CurrentShopID;
            }
            else
            {
                this.pagePara.DestShopID = (string)this.skinComboBox_DestShop.SelectedValue;
                this.pagePara.SourceShopID = CommonGlobalCache.CurrentShopID;
            }
            listPage = CommonGlobalCache.ServerProxy.GetAllocateOrderPage(this.pagePara);
            dataGridViewPagingSumCtrl.OrderPara = pagePara;
            this.dataGridViewPagingSumCtrl.Initialize(listPage);
            this.BindingAllocateOrderSource(listPage);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                String name = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
                if (name == inboundDetail.Name)
                {
                    this.ClickInboundDetail(this.curAllocateOrderListSource[e.RowIndex]);
                }
                else if (name == outboundDetail.Name)
                {
                    this.ClickOutboundDetail(this.curAllocateOrderListSource[e.RowIndex]);
                }
                else if (column_operation.Index == e.ColumnIndex)
                {
                    DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (cell.Value != null && !String.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        switch (cell.Value)
                        {
                            case "收货":
                                this.Inbound(this.curAllocateOrderListSource[e.RowIndex]);

                                break;
                            case "冲单":
                                this.Cancel(this.curAllocateOrderListSource[e.RowIndex]);
                                break;
                            case "重做":
                                this.ReAllocate(this.curAllocateOrderListSource[e.RowIndex]);
                                break;
                            case "提单":
                                this.Pick(this.curAllocateOrderListSource[e.RowIndex]);
                                break;
                            default:
                                break;
                        }
                    }

                }
                else if (ColumnPrint.Index == e.ColumnIndex)
                {
                    AllocateOrder order = this.curAllocateOrderListSource[e.RowIndex];
                    List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(order.OutboundOrderID);
                    this.BindingReplenishDetailSource(list);
                    //Column2.Visible = false;
                    //SumMoney.Visible = false;
                    //Column2.Tag = AllocateOrderPrintUtil.PrinterNoCount;
                    //SumMoney.Tag = AllocateOrderPrintUtil.PrinterNoCount;
                    DataGridView dgv = deepCopyDataGridView();
                    AllocateOrderPrintUtil.Print(order, dgv);
                    //SumMoney.Visible = true;
                    //Column2.Visible = true;
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }
        private DataGridView deepCopyDataGridView()
        {
            DataGridView dgvTmp = new DataGridView();

            dgvTmp.Name = "dgvTmp";
            this.Controls.Add(dgvTmp);
            dgvTmp.AutoGenerateColumns = false;
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dgvTmp.Columns.Add(dataGridView2.Columns[i].Name, dataGridView2.Columns[i].HeaderText);
                if (dataGridView2.Columns[i].DefaultCellStyle.Format.Contains("N")) //使导出Excel文档金额列可做SUM运算
                {
                    dgvTmp.Columns[i].DefaultCellStyle.Format = dataGridView2.Columns[i].DefaultCellStyle.Format;

                }
                if (!dataGridView2.Columns[i].Visible)
                {
                    dgvTmp.Columns[i].Visible = false;
                }
                dgvTmp.Columns[i].DataPropertyName = dataGridView2.Columns[i].DataPropertyName;
                dgvTmp.Columns[i].HeaderText = dataGridView2.Columns[i].HeaderText;
                dgvTmp.Columns[i].Tag = dataGridView2.Columns[i].Tag;
                dgvTmp.Columns[i].Name = dataGridView2.Columns[i].Name;
            }



            List<BoundDetail> listtb1 = DataGridViewUtil.BindingListToList<BoundDetail>(dataGridView2.DataSource);

            List<BoundDetail> tb2 = new List<BoundDetail>();
            foreach (BoundDetail idetail in listtb1)
            {
                BoundDetail tDetail = new BoundDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }

            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }
        private void BindingReplenishDetailSource(List<BoundDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }

            }
           // this.dataGridViewPagingSumCtrl3.BindingDataSource<BoundDetail>(list);
            this.dataGridViewPagingSumCtrl2.BindingDataSource<BoundDetail>(list);


        }
        private void ClickInboundDetail(AllocateOrder allocateOrder)
        {
            if ((AllocateOrderState)allocateOrder.State != AllocateOrderState.Receipt)
            {
                GlobalMessageBox.Show("该单还未收货，入库单明细为空");
                return;
            }

            if (this.InboundDetailClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.InboundDetailClick(allocateOrder.InboundOrderID, this, this.skinSplitContainer1.Panel2);
            }
        }

        private void ClickOutboundDetail(AllocateOrder allocateOrder)
        {
            if (this.OutboundDetailClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.OutboundDetailClick(allocateOrder.OutboundOrderID, this, this.skinSplitContainer1.Panel2);
            }
        }

        private void Cancel(AllocateOrder allocateOrder)
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
                InteractResult result = CommonGlobalCache.ServerProxy.OverrideAllocateOrder(allocateOrder.ID, CommonGlobalCache.CurrentUserID);
                switch (result.ExeResult)
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
        private void ReAllocate(AllocateOrder allocateOrder)
        {
            if (this.ReAllocateClick != null)
            {
                this.ReAllocateClick(allocateOrder, this);
            }
        }

        private void Pick(AllocateOrder allocateOrder)
        {
            if (this.PickClick != null)
            {
                this.PickClick(allocateOrder, this);
            }
        }
        private void Inbound(AllocateOrder allocateOrder)
        {
            if (allocateOrder.State != (byte)AllocateOrderState.Delivery)
            {
                GlobalMessageBox.Show("订单状态不是已发货，不能收货！");
                return;
            }
            if (allocateOrder.DestShopID != CommonGlobalCache.CurrentShopID)
            {
                GlobalMessageBox.Show("本店铺不是收货店铺，不能收货！");
                return;
            }

            if (this.InboundClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.InboundClick(allocateOrder.ID, this, this.skinSplitContainer1.Panel2);
            }
        }

        private void skinComboBox_AllocateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.skinComboBox_AllocateType.SelectedIndex == 0)
            {
                this.isAllocateInbound = true;
            }
            else
            {
                this.isAllocateInbound = false;
            }

        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            AllocateOrder order = (AllocateOrder)row.DataBoundItem;
            if (stateNameDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
            }
            else if (column_operation.Index == e.ColumnIndex)
            {

                if (e.Value == null)
                {
                    return;
                }


                if (order.State != (byte)AllocateOrderState.Delivery && order.State != (byte)AllocateOrderState.OverrideOrder)
                {
                    e.Value = null;
                }
            }
            else if (SourceShopName.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetShopName(order.SourceShopID);

            }
            else if (DestShopName.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetShopName(order.DestShopID);
            }
            else if (GuideName.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetUserName(order.SourceUserID);
            }
        }

        private void GeneralStoreAllocateManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        /// <summary>
        /// 根据调拨状态查询
        /// </summary>
        /// <param name="state">调拨状态</param>
        public void AllocateOrderStateSearch()
        {
            this.state = AllocateOrderState.Normal;
            this.skinComboBox_State.SelectedValue = state;
            this.skinComboBox_AllocateType.SelectedIndex = 0;
            pagePara = new AllocateOrderPagePara()
            {
                AllocateOrderState = AllocateOrderState.Delivery,
                IsOpenDate = false,
                SourceShopID = CommonGlobalCache.CurrentShopID,
                DestShopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_DestShop.SelectedValue),
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize
            };
            Search();
            pagePara.IsOpenDate = true;
        }

        private void costumeTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter) {
                BaseButton_Search_Click(null, null);
            }
        }
    }
}
