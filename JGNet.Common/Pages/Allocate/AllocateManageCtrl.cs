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
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Core.Tools;
using CJBasic.Helpers;
using JieXi.Common;
using CJBasic;

namespace JGNet.Common
{
    public partial class AllocateManageCtrl : BaseModifyUserControl
    {

        private GetAllocateOrdersPara pagePara ;

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
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;

        private bool isCheckOnlyCurShop = false;

        /// <summary>
        /// 调拨查询管理
        /// </summary>
        public AllocateManageCtrl()
        {
            InitializeComponent();
            MenuPermission=RolePermissionMenuEnum.调拨单查询;
            dataGridViewPagingSumCtrl2 = new DataGridViewPagingSumCtrl(this.dataGridView2);
            dataGridViewPagingSumCtrl2.Initialize();

            isCheckOnlyCurShop=HasPermission(RolePermissionMenuEnum.调拨单查询, RolePermissionEnum.查看_只看本店);

            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, 
                new string[] { totalCountDataGridViewTextBoxColumn.DataPropertyName, totalPriceDataGridViewTextBoxColumn.DataPropertyName } );

            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });

            dataGridViewPagingSumCtrl.Initialize();

            createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            shopComboBox1.Initialize(false);
            shopCmbSend.Initialize(false);
            ShopCmbGet.Initialize(false);
           
            //  dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
        }


        //private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        //{SourceShopName
        //    this.skinSplitContainer1.Panel2Collapsed = true;
        //}
        private void Initialize()
        {
             
            this.costumeTextBox1.Text = string.Empty;
            this.skinTextBox_OrderID.SkinTxt.Text = string.Empty;
            this.dataGridViewPagingSumCtrl.SetDataSource<AllocateOrder>(null);
            DateTimeUtil.DateTimePicker_Today(dateTimePicker_Start, dateTimePicker_End);
            this.skinSplitContainer1.Panel2Collapsed = true;

            CommonGlobalUtil.SetAllocateOrderState(skinComboBox_State);
            CommonGlobalUtil.SetAllocateOrderReceiptState(skinCmbReceiptState);
            CommonGlobalUtil.SetAllocateOrderType(skinComboType);
            AdminUser adminU = CommonGlobalCache.GetAdminUser(CommonGlobalCache.CurrentUserID);
            bool isadmin = false;
            if (adminU != null)
            {
                isadmin = adminU.RoleIDs.Contains("1");
            }
            if (!isCheckOnlyCurShop || isadmin)
            {
                //显示发货方与收货方
                    this.skinlblGet.Visible = true;
                    this.skinlblSend.Visible = true;
                    this.shopCmbSend.Visible = true;
                    this.ShopCmbGet.Visible = true;
                    this.skinLabel6.Visible = false;
                    this.shopComboBox1.Visible = false;
                    this.skinComboType.Visible = false;
                    this.skinLabel5.Visible = false;

            }
            else
            {  //显示店铺类型
                this.skinlblGet.Visible = false;
                this.skinlblSend.Visible = false;
                this.shopCmbSend.Visible = false;
                this.ShopCmbGet.Visible = false;
                this.skinLabel6.Visible = true;
                this.shopComboBox1.Visible = true;
                this.skinComboType.Visible = true;
                this.skinLabel5.Visible = true;
              
              
                   
            }

            // CommonGlobalUtil.SetAllocateReceivedOrderState(skinComboBoxBoundState);
            //  CommonGlobalUtil.SetShop(skinComboBox_DestShop);
            // CommonGlobalUtil.SetShop(skinComboBox_SourceShop);
        }


        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
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
                InteractResult<AllocateOrderPage> listPage = CommonGlobalCache.ServerProxy.GetAllocateOrders(this.pagePara);
                BindingAllocateOrderSource(listPage.Data);
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

        #region 绑定AllocateOrder源
        private void BindingAllocateOrderSource(AllocateOrderPage listPage)
        {
            if (listPage != null && listPage.AllocateOrderList != null && listPage.AllocateOrderList.Count > 0)
            {
                this.curAllocateOrderListSource = listPage.AllocateOrderList;

                foreach (var order in listPage.AllocateOrderList)
                {
                    order.SourceShopName= CommonGlobalCache.GetShopName(order.SourceShopID);
                    order.DestShopName = CommonGlobalCache.GetShopName(order.DestShopID);
                    order.OperatorName = CommonGlobalCache.GetUserName(order.SourceUserID);
                } 
            }

            this.curAllocateOrderListSource = listPage?.AllocateOrderList;
            this.dataGridViewPagingSumCtrl.BindingDataSource(this.curAllocateOrderListSource,null, listPage?.TotalEntityCount, listPage?.AllocateOrderSum);
            this.skinSplitContainer1.Panel2Collapsed = true;

        }
        #endregion

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
                string shopid = ValidateUtil.CheckEmptyValue(this.shopComboBox1.SelectedValue);
                AllocateOrderState state = (AllocateOrderState)this.skinComboBox_State.SelectedValue;
                AllocateOrderType type = (AllocateOrderType)this.skinComboType.SelectedValue;
                string descShopId= ValidateUtil.CheckEmptyValue(this.ShopCmbGet.SelectedValue);
                string SourceShopId = ValidateUtil.CheckEmptyValue(this.shopCmbSend.SelectedValue);
                // AllocateOrderState boundState=(AllocateOrderState)skinComboBoxBoundState.SelectedValue;
                /* if (boundState != AllocateOrderState.All)
                 {
                     state = boundState; 
                 }*/
                /*   pagePara = new AllocateOrderPagePara()
                   {
                       CostumeID = costumeID,
                       AllocateOrderID = orderID,
                       AllocateOrderState = state,
                       IsOpenDate = this.isOpenDate,
                     //  SourceShopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_SourceShop.SelectedValue),
                    //   DestShopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_DestShop.SelectedValue),

                       StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                       EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                       PageIndex = 0,
                       PageSize = this.dataGridViewPagingSumCtrl.PageSize
                   };*/

                /* if (pagePara.DestShopID == pagePara.SourceShopID)
                 {
                     ShowError("发货方与收货方不能相同！");
                     return;
                 }*/
                //  AllocateOrderPage listPage = null;
                //   listPage = CommonGlobalCache.ServerProxy.GetAllocateOrderPage(this.pagePara);
                pagePara = new GetAllocateOrdersPara()
                {
                    AllocateOrderID = orderID,
                    AllocateOrderState = state,
                    CostumeID = costumeID,
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    ShopID = shopid,
                    Type = type,
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                    ReceiptState = (ReceiptState)skinCmbReceiptState.SelectedValue,
                    LockShop = isCheckOnlyCurShop,
                     DestShopID=descShopId,
                       SourceShopID= SourceShopId,
                        Remarks=ValidateUtil.CheckEmptyValue(this.txtRemark.SkinTxt.Text),

                };
                InteractResult<AllocateOrderPage> allOrderPage = CommonGlobalCache.ServerProxy.GetAllocateOrders(pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(allOrderPage.Data);
                this.BindingAllocateOrderSource(allOrderPage.Data);
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


        private DataGridView deepCopyDataGridView(List<BoundDetail> list)
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
            


        //    List<AllocateOrder> listtb1 = (List<AllocateOrder>)(dataGridView1.DataSource);

            List<BoundDetail> tb2 = new List<BoundDetail>();
            foreach (BoundDetail idetail in list)
            {
                BoundDetail tDetail = new BoundDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }

            dgvTmp.DataSource = tb2;

          /*  foreach (DataGridViewColumn dgvColumn in dgvTmp.Columns)
            {
                 //dgvColumn.DataPropertyName==
                    switch (dgvColumn.DataPropertyName)
                {
                    case "CostumeID":
                        dgvColumn.HeaderText = "款号";
                        break;
                    case "CostumeName":
                        dgvColumn.HeaderText = "商品名称";
                        break;
                    case "BrandName":
                        dgvColumn.HeaderText = "品牌";
                        break;
                    case "ColorName":
                        dgvColumn.HeaderText = "颜色";
                        break;
                    case "Year":
                        dgvColumn.HeaderText = "年份";
                        break;
                    case "Season":
                        dgvColumn.HeaderText = "季节";
                        break;
                    case "Price":
                        dgvColumn.HeaderText = "吊牌价";
                        break;
                    case "SalePrice":
                        dgvColumn.HeaderText = "售价";
                        break;
                    case "F":
                        dgvColumn.HeaderText = "F";
                        break;
                    case "XS":
                        dgvColumn.HeaderText = "XS";
                        break;

                    case "S":
                        dgvColumn.HeaderText = "S";
                        break;
                    case "M":
                        dgvColumn.HeaderText = "M";
                        break;

                    case "L":
                        dgvColumn.HeaderText = "L";
                        break;
                    case "XL":
                        dgvColumn.HeaderText = "XL";
                        break;
                    case "XL2":
                        dgvColumn.HeaderText = "2XL";
                        break;
                    case "XL3":
                        dgvColumn.HeaderText = "3XL";
                        break;
                    case "XL4":
                        dgvColumn.HeaderText = "4XL";
                        break;
                    case "XL5":
                        dgvColumn.HeaderText = "5XL";
                        break;
                    case "XL6":
                        dgvColumn.HeaderText = "6XL";
                        break;
                    case "SumCount":
                        dgvColumn.HeaderText = "数量";
                        break;
                    case "SumMoney":
                        dgvColumn.HeaderText = "总金额";
                        break;
                    case "Comment":
                        dgvColumn.HeaderText = "备注";
                        break;
                    default:
                        break;
                }
               
            }*/


            return dgvTmp;
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
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                String name = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
                if (name == inboundDetail.Name)
                {
                    this.ClickInboundDetail(this.curAllocateOrderListSource[e.RowIndex]);
                }
                else if (name == outboundDetail.Name)
                {
                    this.ClickOutboundDetail(this.curAllocateOrderListSource[e.RowIndex]);
                }
                else if (operationColumn.Index == e.ColumnIndex)
                { this.Inbound(this.curAllocateOrderListSource[e.RowIndex]); }
                else if (ColumnCancel.Index == e.ColumnIndex)
                { this.Cancel(this.curAllocateOrderListSource[e.RowIndex]); }
                else if (ColumnRedo.Index == e.ColumnIndex)
                { this.ReAllocate(this.curAllocateOrderListSource[e.RowIndex]); }
                else if (ColumnPick.Index == e.ColumnIndex)
                {
                    this.Pick(this.curAllocateOrderListSource[e.RowIndex]);
                }
                else if (ColumnPrint.Index == e.ColumnIndex)
                {
                    AllocateOrder order = this.curAllocateOrderListSource[e.RowIndex];
                    List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(order.OutboundOrderID);
                    BindingReplenishDetailSource(list);
                    // SumMoney.Visible = false;
                    //  SumMoney.Tag = WholesaleDeliveryPrinter.PrinterNoCount;
                    DataGridView dgv = deepCopyDataGridView(list);
                    AllocateOrderPrintUtil.Print(order, dgv);
                    //  SumMoney.Visible = true;
                }
                else if (ColumnExcept.Index == e.ColumnIndex)
                {
                    AllocateOrder order = this.curAllocateOrderListSource[e.RowIndex];


                    path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "调拨单"+ order.ID + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    if (String.IsNullOrEmpty(path))
                    {
                        return;
                    }
                    Export(order);
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }
        private void Export(AllocateOrder order)
        {

            try
            {

                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(order.OutboundOrderID);
                // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                int ColNum = 0;
                foreach (DataGridViewColumn item in dataGridView2.Columns)
                {
                    if (item.Visible && item.Name!= "sumCostDataGridViewTextBoxColumn")
                    {
                        ColNum++;
                        keys.Add(item.DataPropertyName);
                        if (item.HeaderText == "XL2")
                        {
                            item.HeaderText = "2XL";
                        }
                        if (item.HeaderText == "XL3")
                        {
                            item.HeaderText = "3XL";
                        }
                        if (item.HeaderText == "XL4")
                        {
                            item.HeaderText = "4XL";
                        }
                        if (item.HeaderText == "XL5")
                        {
                            item.HeaderText = "5XL";
                        }
                        if (item.HeaderText == "XL6")
                        {
                            item.HeaderText = "6XL";
                        }
                        values.Add(item.HeaderText);


                    }
                }

                foreach (BoundDetail cItem in list)
                {
                    cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);
                }


                List<CellType> cellList = new List<CellType>();
                NPOIHelper.hsRowCount = 4;
                

               /* CellType curCellI = new CellType();
                curCellI.RowIndex = 0;
                curCellI.CellName = "";
                if (ColNum % 2 == 0)
                {

                    curCellI.CellMergeNum = ColNum / 2 - 1;
                }
                else
                {
                    curCellI.CellMergeNum = ColNum / 2;
                }
                cellList.Add(curCellI);*/



                CellType curCell = new CellType();
                curCell.RowIndex = 0;
                curCell.CellName = "调拨单";
                curCell.Title = true; 
                curCell.CellMergeNum = ColNum  ;
                 
               
                // curCell.CellMergeIndex = 12;
                cellList.Add(curCell);

                CellType curCellOrder = new CellType();
                curCellOrder.RowIndex = 1;
                curCellOrder.CellName = "单号：";
                curCellOrder.CellMergeNum = 1;
                cellList.Add(curCellOrder);



                CellType curCellOrderValue = new CellType();
                curCellOrderValue.RowIndex = 1;
                curCellOrderValue.CellName = order.ID;
                curCellOrderValue.CellMergeNum = 2;
                cellList.Add(curCellOrderValue);

                CellType curCellCreaterUser = new CellType();
                curCellCreaterUser.RowIndex = 1;
                curCellCreaterUser.CellName = "开单员";
                curCellCreaterUser.CellMergeNum = 1;
                cellList.Add(curCellCreaterUser);

                CellType curCellCreaterUserValue = new CellType();
                curCellCreaterUserValue.RowIndex = 1;
                curCellCreaterUserValue.CellName = order.OperatorName;
                curCellCreaterUserValue.CellMergeNum = 2;
                cellList.Add(curCellCreaterUserValue);



                CellType curCellTime = new CellType();
                curCellTime.RowIndex = 1;
                curCellTime.CellName = "开单时间";
                curCellTime.CellMergeNum = 1;
                cellList.Add(curCellTime);

                CellType curCellTimeValue = new CellType();
                curCellTimeValue.RowIndex = 1;
                curCellTimeValue.CellName = order.CreateTime.GetDateTimeFormats('f')[0].ToString(); ;
                curCellTimeValue.CellMergeNum = 2;
                cellList.Add(curCellTimeValue);



                CellType curCellSource = new CellType();
                curCellSource.RowIndex = 2;
                curCellSource.CellName = "发货方：";
                curCellSource.CellMergeNum = 1;
                cellList.Add(curCellSource);



                CellType curCellSourceValue = new CellType();
                curCellSourceValue.RowIndex = 2;
                curCellSourceValue.CellName = order.SourceShopName;
                curCellSourceValue.CellMergeNum = 2;
                cellList.Add(curCellSourceValue);


                CellType curCellTarget = new CellType();
                curCellTarget.RowIndex = 2;
                curCellTarget.CellName = "收货方：";
                curCellTarget.CellMergeNum = 1;
                cellList.Add(curCellTarget);



                CellType curCellTargetValue = new CellType();
                curCellTargetValue.RowIndex = 2;
                curCellTargetValue.CellName = order.DestShopName;
                curCellTargetValue.CellMergeNum = 2;
                cellList.Add(curCellTargetValue);



                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = 2;
                curCellTotal.CellName = "总数量：";
                curCellTotal.CellMergeNum = 1;
                cellList.Add(curCellTotal);



                CellType curCellTotalValue = new CellType();
                curCellTotalValue.RowIndex = 2;
                curCellTotalValue.CellName = order.TotalCount.ToString();
                curCellTotalValue.CellMergeNum = 2;
                cellList.Add(curCellTotalValue);





                CellType curCellBalance = new CellType();
                curCellBalance.RowIndex = 2;
                curCellBalance.CellName = "总金额：";
                curCellBalance.CellMergeNum = 1;
                cellList.Add(curCellBalance);



                CellType curCellBalanceValue = new CellType();
                curCellBalanceValue.RowIndex = 2;
                curCellBalanceValue.CellName = order.TotalPrice.ToString();
                curCellBalanceValue.CellMergeNum = 2;
                cellList.Add(curCellBalanceValue);



                CellType curCellRemark = new CellType();
                curCellRemark.RowIndex = 3;
                curCellRemark.CellName = "备注：";
                curCellRemark.CellMergeNum = 1;
                cellList.Add(curCellRemark);



                CellType curCellRemarkValue = new CellType();
                curCellRemarkValue.RowIndex = 3;
                curCellRemarkValue.CellName = order.Remarks;
                curCellRemarkValue.CellMergeNum = 10;
                cellList.Add(curCellRemarkValue);


                NPOIHelper.CellValues = cellList; 


                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);

                GlobalMessageBox.Show("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }
        List<BoundDetail>    detailList=null;
        private void BindingReplenishDetailSource(List<BoundDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }

            }
            detailList = list;
           this.dataGridViewPagingSumCtrl2.BindingDataSource<BoundDetail>(list);
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
            if (allocateOrder.DestShopID != CommonGlobalCache.CurrentShopID )
            {
                if (CommonGlobalCache.CurrentShopID != CommonGlobalCache.GeneralStoreShopID)
                {
                    GlobalMessageBox.Show("本店铺不是收货店铺，不能收货！");
                    return;
                }
            }

            if (this.InboundClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.InboundClick(allocateOrder.ID, this, this.skinSplitContainer1.Panel2);
            }
        }

        private void ClickInboundDetail(AllocateOrder allocateOrder)
        {
            if ((AllocateOrderState)allocateOrder.State!= AllocateOrderState.Receipt)
            {
                GlobalMessageBox.Show("该单还未收货，入库单明细为空");
                return;
            }

                this.skinSplitContainer1.Panel2Collapsed = false;
                 this.InboundDetailClick?.Invoke(allocateOrder.InboundOrderID, this, this.skinSplitContainer1.Panel2);

        }

        private void ClickOutboundDetail(AllocateOrder allocateOrder)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            this.OutboundDetailClick?.Invoke(allocateOrder.OutboundOrderID, this,this.skinSplitContainer1.Panel2);
        }
 
        #endregion

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            if (e.Value == null)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            AllocateOrder order = (AllocateOrder)row.DataBoundItem;

            AllocateOrderState state = (AllocateOrderState)order.State;
            if (operationColumn.Index == e.ColumnIndex)
            {
                if ((state == AllocateOrderState.Delivery && order.DestShopID != CommonGlobalCache.CurrentShopID 
                   && CommonGlobalCache.CurrentShopID!= CommonGlobalCache.GeneralStoreShopID
                    ) 
                    || state == AllocateOrderState.OverrideOrder
                    || state == AllocateOrderState.HangUp
                    || state == AllocateOrderState.Receipt)
                {
                    e.Value = null;
                }
            }
            else if (ColumnCancel.Index == e.ColumnIndex)
            {
                if (state != AllocateOrderState.Delivery && state != AllocateOrderState.Receipt)
                {
                    e.Value = null;
                }
            }
            else if (ColumnRedo.Index == e.ColumnIndex)
            {
                if (  state != AllocateOrderState.OverrideOrder )
                {
                    e.Value = null;
                }
            }
            else if (ColumnPick.Index == e.ColumnIndex)
            {
                if (state != AllocateOrderState.HangUp)
                {
                    e.Value = null;
                }
            }
            else if (FinishedTime.Index == e.ColumnIndex)
            {
                if (state != AllocateOrderState.Receipt)
                {
                    e.Value = null;
                }
            }
        }

        private void AllocateManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
           

        }
        public void WorkSearch(AllocateOrderState state)
        {
            this.skinComboBox_State.SelectedValue = state;
            this.skinCmbReceiptState.SelectedValue = ReceiptState.WaitReceipt;
            this.ShopCmbGet.SelectedValue = CommonGlobalCache.CurrentShopID;
            DateTimeUtil.DateTimePicker_All(dateTimePicker_Start, dateTimePicker_End);
            this.BaseButton_Search_Click(null, null);

        }

        /// <summary>
        /// 根据调拨状态查询
        /// </summary>
        /// <param name="state">调拨状态</param>
        public void AllocateOrderStateSearch(AllocateOrderState state)
        {
            // this.skinComboBox_State.SelectedValue = state;
            if (state == AllocateOrderState.Delivery || state == AllocateOrderState.Receipt)
            {
                this.skinComboBox_State.SelectedValue = AllocateOrderState.Normal;
            }
            
            this.BaseButton_Search_Click(null, null);
        }

        private void costumeTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }

        private String path;
        private void baseButton3_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "调拨单" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }

                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoExport);
                cb.BeginInvoke(null, null);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
        }


        private void DoExport()
        {
            try
            {
                List<AllocateOrder> list =( List<AllocateOrder>)(dataGridView1.DataSource);
               // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (item.Visible)
                    {
                        if (item.Name != "operationColumn" && item.Name != "ColumnCancel" && item.Name != "ColumnRedo" && item.Name != "ColumnPick" && item.Name != "ColumnPrint")
                        {
                            keys.Add(item.DataPropertyName);
                            values.Add(item.HeaderText);
                        }
                    }
                }
            /*    List<AllocateOrder> ExportList = new List<AllocateOrder>();
                foreach (AllocateOrder cItem in list)
                {
                    AllocateOrder curBrand = new AllocateOrder();
                    curBrand.Name = cItem.Name;
                    curBrand.FirstCharSpell = cItem.FirstCharSpell;
                    ExportList.Add(curBrand);
                }*/



                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);

                GlobalMessageBox.Show("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }
    }
}
