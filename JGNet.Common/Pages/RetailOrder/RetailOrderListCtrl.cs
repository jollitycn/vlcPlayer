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
using JGNet.Common;
using CCWin.SkinControl;
using CJBasic;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using CJBasic.Helpers;
using JGNet.Core.Tools; 
using JGNet.Core.Const;
using JGNet.Core;
using JGNet.Manage;
using JieXi.Common;

namespace JGNet.Common
{
    public partial class RetailOrderListCtrl : BaseModifyUserControl
    {

        private bool isOnline;
        private RetailListPagePara pagePara;
        private bool showShop;
        public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private bool isRefundOrder;
        public CJBasic.Action<String, BaseUserControl> RefundDetailClick;
        public CJBasic.Action<String, BaseUserControl> RetailDetailClick;
        public CJBasic.Action<RetailOrder, BaseUserControl> RedoClick;
        private RetailOrder clipboardOrder;
         
        private void RefundItem_Click(object sender, EventArgs e)
        {
            ReturnDetail(clipboardOrder);
        }
        private void RetailItem_Click(object sender, EventArgs e)
        {
            RetailDetail(clipboardOrder);
        }
        private RetailListPage ListPage { get; set; }
        public RetailOrderListCtrl()
        {
            InitializeComponent();
            Init();
        }

        private void Init(bool hideOper = false)
        {
            //MenuPermission = RolePermissionMenuEnum.销售退货单查询;
            this.dataGridView_RetailOrder.AutoGenerateColumns = false;
            dataGridView_RetailDetail.AutoGenerateColumns = false;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView_RetailOrder, PageControlPanel21_CurrentPageIndexChanged, BaseButton_Search_Click,
                new String[] {
    // TextBoxColumnOFshowCash.DataPropertyName,
     MoneyBankCard.DataPropertyName,
     MoneyWeiXin.DataPropertyName,
     MoneyAlipay.DataPropertyName,
     MoneyBuyByTicket.DataPropertyName,
     MoneyCash.DataPropertyName,
     MoneyVipCard.DataPropertyName,
        totalCountDataGridViewTextBoxColumn.DataPropertyName,
                        totalPriceDataGridViewTextBoxColumn.DataPropertyName,
                        TotalMoneyReceivedActual.DataPropertyName,
                    CarriageCost.DataPropertyName,
                MoneyOtherColumn.DataPropertyName});
            if (hideOper)
            {
                //不分页
                dataGridViewPagingSumCtrl.Paging = false;
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnRedo, ColumnRemove, ColumnPrint);
            }
            this.Initialize();
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] { Remarks });
            dataGridViewPagingSumCtrl.Initialize();
            SetUpOrderStrip(dataGridViewPagingSumCtrl.InnerContextMenuStrip);
            new DataGridViewPagingSumCtrl(dataGridView_RetailDetail).Initialize();
        }

        bool curFlag = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="para"></param>
        /// <param name="showShop">只在POS端多加判断</param>
        public RetailOrderListCtrl(RetailListPagePara para, Boolean showShop = false, bool flag = false )
        {
            InitializeComponent();
            curFlag = flag;
            Init(true);
            this.pagePara = para;
            if (pagePara.PageSize != 0)
            {
                dataGridViewPagingSumCtrl.PageSize = pagePara.PageSize;
            }
            this.showShop = showShop;

        }

        public void Search()
        {
            this.BaseButton_Search_Click(null, null);
        }

        public void BindingSource(RetailListPagePara pagePara, bool isOnline)
        {
            this.isOnline = isOnline;
            this.pagePara = pagePara;
            Search();
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        public void Initialize()
        {

            if (skinSplitContainer1 != null) { skinSplitContainer1.Panel2Collapsed = true; }
            List<DataGridViewColumn> listColumn = new List<DataGridViewColumn>();
            List<DataGridViewColumn> noDisplayListColumn = new List<DataGridViewColumn>();

            if ((CommonGlobalCache.BusinessAccount != null && CommonGlobalCache.BusinessAccount.OnlineEnabled))
            {
                listColumn.Add(CarriageCost);
            }
            else
            {
                noDisplayListColumn.Add(CarriageCost); 
            }

            if (curFlag)
            {
                noDisplayListColumn.Add(ColumnRemove);
            }
            else
            {

                listColumn.Add(ColumnRemove);
            }
            if (noDisplayListColumn.Count > 0) {
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(noDisplayListColumn.ToArray());
            }
            if (listColumn.Count > 0)
            {
                dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(listColumn.ToArray());
            }

            createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
            if (dataGridViewPagingSumCtrl != null)
            {
                dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
                dataGridViewPagingSumCtrl.Clear();
            }
            this.dataGridView_RetailDetail.DataSource = null;
            this.pagePara = new RetailListPagePara();
            SetRetailOrderLabel(null);
        }

        /// <summary>
        /// 设置retailOrder对应的标签
        /// </summary>
        /// <param name="retailOrder"></param>
        private void SetRetailOrderLabel(RetailOrder retailOrder)
        {
            if (retailOrder == null)
            {
                this.skinLabel_MoneyCash.Text = "";
                this.skinLabel_MoneyStoredCard.Text = "";
                this.skinLabel_MoneyBankCard.Text = "";
                this.skinLabel_MoneyIntegration.Text = "";
                this.skinLabel_MoneyWeiXin.Text = "";
                this.skinLabel_MoneyAlipay.Text = "";
                this.skinLabelMoneyOther.Text = "";
                this.skinLabel_MoneyChange.Text = "";
                this.skinLabelReceivedActual.Text = "";
                skinLabel_SmallMoneyRemoved.Text = string.Empty;
                skinLabel_remark.Text = string.Empty;
                this.skinLabel_SalesPromotion.Text = string.Empty;
                skinLabelGiftTicket.Text = string.Empty;
            }
            else
            {
                skinLabel_SmallMoneyRemoved.Text = retailOrder.SmallMoneyRemoved.ToString();
                this.skinLabel_MoneyCash.Text = retailOrder.MoneyCash.ToString();
                this.skinLabel_MoneyStoredCard.Text = retailOrder.MoneyVipCard.ToString() + "(赠送" + retailOrder.MoneyVipCardDonate + ")";
                skinLabelReceivedActual.Text = retailOrder.TotalMoneyReceivedActual.ToString();
                this.skinLabel_MoneyBankCard.Text = retailOrder.MoneyBankCard.ToString();
                this.skinLabel_MoneyIntegration.Text = retailOrder.MoneyIntegration.ToString();
                this.skinLabel_MoneyWeiXin.Text = retailOrder.MoneyWeiXin.ToString();
                this.skinLabel_MoneyAlipay.Text = retailOrder.MoneyAlipay.ToString();
                this.skinLabelMoneyOther.Text = retailOrder.MoneyOther.ToString();
                this.skinLabel_MoneyChange.Text = retailOrder.MoneyChange.ToString();
                skinLabelGiftTicket.Text = retailOrder.MoneyDeductedByTicket.ToString();
                skinLabel_remark.Text = retailOrder.Remarks;
                if (String.IsNullOrEmpty(retailOrder.SalesPromotionID))
                {
                    this.skinLabel_SalesPromotion.Text = CommonGlobalUtil.COMBOBOX_NULL;
                }
                else
                {
                    this.skinLabel_SalesPromotion.Text = retailOrder.PromotionText;
                }
            }

            SetDisplay();
        }

        private void SetDisplay()
        {
            //isRefundOrder = (pagePara.RetailOrderType == RetailOrderType.RefundOrder);
           // isRefundOrder = (pagePara.RetailOrderType == RetailOrderType.RefundOrder);
            skinLabel14.Visible = !isRefundOrder;
            skinLabel16.Visible = !isRefundOrder;
            skinLabel19.Visible = !isRefundOrder;
            skinLabel1.Visible = !isRefundOrder;
            //促销活动 
            this.skinLabel_MoneyChange.Visible = !isRefundOrder;
            skinLabel_SalesPromotion.Visible = !isRefundOrder;
            skinLabel_SmallMoneyRemoved.Visible = !isRefundOrder;
            skinLabelGiftTicket.Visible = !isRefundOrder;
            this.groupBox1.Text = isRefundOrder ? "退款方式" : "付款方式";
        }

        /// <summary>
        /// 绑定RetailOrder数据源
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingRetailOrderDataSource()
        {
            this.dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ListToBindingList( ListPage?.ResultList), null, ListPage?.TotalEntityCount, ListPage?.RetailOrderSum);
        }

        private void PageControlPanel21_CurrentPageIndexChanged(int index)
        {
            if (this.pagePara == null)
            {
                return;
            }
            pagePara.PageIndex = index;
            ListPage = CommonGlobalCache.ServerProxy.GetRetailListPage(pagePara);
            if (ListPage.ResultList != null)
            {
                foreach (RetailOrder orderItem in ListPage.ResultList)
                {
                    orderItem.ShowCash = orderItem.MoneyCash - orderItem.MoneyChange;
                }
            }
            this.BindingRetailOrderDataSource();
        }

        /// <summary>
        /// 绑定RetailDetail数据源并设置下方的Label值
        /// </summary>
        private void BindingRetailDetailDataSourceAndCleanLabel(RetailOrder retailOrder)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            if (retailOrder == null || String.IsNullOrEmpty(retailOrder.ID))
            {
                this.dataGridView_RetailDetail.DataSource = null;
            }
            else
            {
                List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
                this.dataGridView_RetailDetail.DataSource = null;
                if (retailDetailList != null && retailDetailList.Count > 0)
                {
                    foreach (RetailDetail detail in retailDetailList)
                    {
                        detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                        detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                     //   detail.SinglePrice = detail.SumMoney / detail.BuyCount*-1;
                      //  detail.BrandName =CommonGlobalCache.GetBrandName4CostumeID(detail.CostumeID);
                    }
                    this.dataGridView_RetailDetail.DataSource =   DataGridViewUtil.ListToBindingList(retailDetailList)  ;
                }
            }
            this.dataGridView_RetailDetail.Refresh();
            this.SetRetailOrderLabel(retailOrder);
        }

        //点击查询按钮
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                this.skinSplitContainer1.Panel2Collapsed = true;
                ListPage = CommonGlobalCache.ServerProxy.GetRetailListPage(pagePara);
                if (ListPage.ResultList != null)
                {
                    foreach (RetailOrder orderItem in ListPage.ResultList)
                    {
                        orderItem.ShowCash = orderItem.MoneyCash - orderItem.MoneyChange;
                    }
                }
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(ListPage);
                this.BindingRetailOrderDataSource();
            }
            catch (Exception ee)
            {
                WriteLog("Message:" + ee.Message + "StackTrace" + ee.StackTrace);
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void dataGridView_RetailOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
                if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
                DataGridViewRow row = dataGridView_RetailOrder.Rows[e.RowIndex];
                RetailOrder order = (RetailOrder)row.DataBoundItem;

                //if (column_guideName.Index == e.ColumnIndex)
                //{
                //    e.Value = CommonGlobalCache.GetUserName(order.GuideID);
                //}
                //else
                if (shopIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
                {
                    if (isOnline)
                    {
                        e.Value = SystemDefault.onlineName;

                    }
                    else
                    {
                        e.Value = CommonGlobalCache.GetShopName(order.ShopID);
                    }
                }
                else if (ColumnRemove.Index == e.ColumnIndex)
                {
                    if (order.IsCancel|| order.ShopName=="线上商城")
                    {
                        e.Value = String.Empty;
                    }
                }
                else if (ColumnRedo.Index == e.ColumnIndex)
                {
                    if (!order.IsCancel)
                    {
                        e.Value = String.Empty;
                    }

                }

              /*  else if (GuideName.Index == e.ColumnIndex)
                {
                    if(order.)
                }*/

                //else if (ColumnEdit.Index == e.ColumnIndex)
                //{
                //    if (order.IsCancel)
                //    {
                //        e.Value = String.Empty;
                //    }
                //}

            }
            catch { }
        }

        private void dataGridView_RetailOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                List<RetailOrder> source = DataGridViewUtil.BindingListToList<RetailOrder>(this.dataGridView_RetailOrder.DataSource);
                RetailOrder item = source[e.RowIndex];
                if (ColumnRemove.Index == e.ColumnIndex)
                {
                    //冲单
                    Cancel(item);
                }
                else if (ColumnRedo.Index == e.ColumnIndex)
                {
                    Redo(item);
                }
                else if (ColumnPrint.Index == e.ColumnIndex)
                {
                    if (isRefundOrder)
                    {
                        //打印
                        Print(item);
                    }
                    else
                    {
                        PrintRetail(item);
                    }
                }

                else if (Column1.Index == e.ColumnIndex)
                {
                    string fileName = string.Empty;
                    if (isRefundOrder)
                    {
                        fileName = "退货单";
                    }
                    else {

                        fileName = "销售单";
                    }
                    path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", fileName + item.ID + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                    if (String.IsNullOrEmpty(path))
                    {
                        return;
                    }
                    Export(item);

                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }
        string path = string.Empty;
        private void Export(RetailOrder retailOrder)
        {
            //  RefundOrderPrintUtil printHelper = new RefundOrderPrintUtil();
            // List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
            //foreach (var item in retailDetailList)
            //{
            //    Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
            //    // 显示自己设置的尺码组和对应的尺码列表
            //    item.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(item.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
            //}

            try
            {

                List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
                // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
               

                keys.Add("BusinessTime");
                values.Add("业务日期");
                keys.Add("SaleBillID");
                values.Add("销售单号");
                keys.Add("GuidId");
                values.Add("整单导购员");
                keys.Add("Shop");
                values.Add("店铺");
                keys.Add("VIPCard");
                values.Add("VIP卡号");
                keys.Add("VIPName");
                values.Add("VIP姓名");
                foreach (DataGridViewColumn item in dataGridView_RetailDetail.Columns)
                {  
                        keys.Add(item.DataPropertyName); 
                        values.Add(item.HeaderText); 
                }
               
                

                foreach (RetailDetail cItem in retailDetailList)
                {
                    //cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);

                       Costume costume = CommonGlobalCache.GetCostume(cItem.CostumeID);
                    cItem.CostumeName = costume.Name;
                    cItem.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(cItem.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
                }


                /*     List<CellType> cellList = new List<CellType>();
                     NPOIHelper.hsRowCount = 4;


                     CellType curCellI = new CellType();
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
                     cellList.Add(curCellI);



                     CellType curCell = new CellType();
                     curCell.RowIndex = 0; 
                     curCell.CellName = retailOrder.ShopName;
                     if (ColNum % 2 == 0)
                     {
                         curCell.CellMergeNum = ColNum - (ColNum / 2) + 1;
                     }
                     else
                     {
                         curCell.CellMergeNum = ColNum - (ColNum / 2);
                     }
                     // curCell.CellMergeIndex = 12;
                     cellList.Add(curCell);

                     CellType curCellOrder = new CellType();
                     curCellOrder.RowIndex = 1;
                     curCellOrder.CellName = "单号：";
                     curCellOrder.CellMergeNum = 1;
                     cellList.Add(curCellOrder);



                     CellType curCellOrderValue = new CellType();
                     curCellOrderValue.RowIndex = 1;
                     curCellOrderValue.CellName = retailOrder.ID;
                     curCellOrderValue.CellMergeNum = 2;
                     cellList.Add(curCellOrderValue);

                     CellType curCellCreaterUser = new CellType();
                     curCellCreaterUser.RowIndex = 1;
                     curCellCreaterUser.CellName = "日期";
                     curCellCreaterUser.CellMergeNum = 1;
                     cellList.Add(curCellCreaterUser);

                     CellType curCellCreaterUserValue = new CellType();
                     curCellCreaterUserValue.RowIndex = 1;
                     curCellCreaterUserValue.CellName = retailOrder.CreateTime.GetDateTimeFormats('f')[0].ToString();
                     curCellCreaterUserValue.CellMergeNum = 2;
                     cellList.Add(curCellCreaterUserValue);



                     CellType curCellTime = new CellType();
                     curCellTime.RowIndex = 2;
                     curCellTime.CellName = "电话";
                     curCellTime.CellMergeNum = 1;
                     cellList.Add(curCellTime);

                     CellType curCellTimeValue = new CellType();
                     curCellTimeValue.RowIndex =2;
                     curCellTimeValue.CellName = CommonGlobalCache.CurrentShop?.PhoneNumber;
                     curCellTimeValue.CellMergeNum = 2;
                     cellList.Add(curCellTimeValue);



                     CellType curCellSource = new CellType();
                     curCellSource.RowIndex = 2;
                     curCellSource.CellName = "地址：";
                     curCellSource.CellMergeNum = 1;
                     cellList.Add(curCellSource);



                     CellType curCellSourceValue = new CellType();
                     curCellSourceValue.RowIndex = 2;
                     curCellSourceValue.CellName = CommonGlobalCache.CurrentShop?.Address;
                     curCellSourceValue.CellMergeNum = 2;
                     cellList.Add(curCellSourceValue);


                     CellType curCellTarget = new CellType();
                     curCellTarget.RowIndex = 3;
                     curCellTarget.CellName = "顾问：";
                     curCellTarget.CellMergeNum = 1;
                     cellList.Add(curCellTarget);



                     CellType curCellTargetValue = new CellType();
                     curCellTargetValue.RowIndex = 3;
                     curCellTargetValue.CellName = CommonGlobalCache.GetUserName(retailOrder.GuideID);
                     curCellTargetValue.CellMergeNum = 2;
                     cellList.Add(curCellTargetValue);


                  NPOIHelper.CellValues = cellList;*/



               DataTable dt = DataGridViewUtil.ToDataTable(retailDetailList);
                dt.Columns.Add("BusinessTime");
                dt.Columns.Add("SaleBillID");
                dt.Columns.Add("GuidId");
                dt.Columns.Add("Shop");
                dt.Columns.Add("VIPCard");
                dt.Columns.Add("VIPName");
                foreach (DataRow dr in dt.Rows)
                {
                    dr["BusinessTime"] = retailOrder.EntryTime.GetDateTimeFormats('f')[0].ToString();
                    dr["SaleBillID"] = retailOrder.ID;
                    dr["GuidId"] = retailOrder.GuideName;
                    dr["Shop"] = retailOrder.ShopName;
                    dr["VIPCard"] = retailOrder.MemeberID;
                    dr["VIPName"] = retailOrder.MemeberID!=null && retailOrder.MemeberID!="" ?  CommonGlobalCache.ServerProxy.GetOneMember(retailOrder.MemeberID).Name:""; 

                }



                List<CellType> cellList = new List<CellType>();
                NPOIHelper.bottomHsRowCount = 1;

                CellType curCellIT = new CellType();
                curCellIT.RowIndex = dt.Rows.Count + 1;
                curCellIT.CellName = "汇总：";
                curCellIT.IsCollect = true;
                curCellIT.CellMergeNum = 1;

                cellList.Add(curCellIT);
                for (int k = 0; k < 11; k++)
                {
                    CellType curCellI = new CellType();
                    curCellI.RowIndex = dt.Rows.Count+1;
                    curCellI.CellName = "";
                    curCellI.CellMergeNum = 1;

                    cellList.Add(curCellI);
                }
                
                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = dt.Rows.Count +1;//1是要多加一行标题列
                curCellTotal.CellName =retailOrder.TotalCount.ToString();
                curCellTotal.IsCollect = true;
                curCellTotal.CellMergeNum = 1;

                cellList.Add(curCellTotal);

                CellType curCellTotalPrice = new CellType();
                curCellTotalPrice.RowIndex = dt.Rows.Count + 1;
                curCellTotalPrice.CellName = retailOrder.TotalMoneyReceived.ToString();
                curCellTotalPrice.CellMergeNum = 1;
                curCellTotalPrice.IsCollect = true;
                cellList.Add(curCellTotalPrice);

                NPOIHelper.BottomCellValues = cellList;




                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();
                NPOIHelper.ExportExcel(dt, path);

                GlobalMessageBox.Show("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }

        }

            private void Redo(RetailOrder allocateOrder)
        {
            if (this.RedoClick != null)
            {
                this.RedoClick(allocateOrder, this);
            }
        }

        //private void EditDetail(RetailOrder item)
        //{
        //    //打开修改日期窗口
        //    DateSelectForm form = new DateSelectForm("修改开单日期", "修改日期：", item.CreateTime, "正在处理中……");
        //    editOrder = item;
        //    form.ConfirmClick += form_ConfirmClick;
        //    form.ShowDialog();
        //}

        private RetailOrder editOrder;
        UpdateTimePara para;
        DateSelectForm form;
        private void form_ConfirmClick(DateTime datetime, DateSelectForm form)
        {
            try
            {

                para = new UpdateTimePara()
                {
                    CreateTime = datetime,
                    OrderId = editOrder?.ID
                };
                this.form = form;
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoUpdate);
                cb.BeginInvoke(null, null);
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
                InteractResult result = CommonGlobalCache.ServerProxy.UpdateRetailTime(para);
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        SuccessEdit();
                        break;
                    case ExeResult.Error:
                        FailedEdit();
                        ShowMessage(result.Msg);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void FailedEdit()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.FailedEdit));
            }
            else
            {
                form.Cancel();
            }
        }

         

        private void SuccessEdit()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric(this.SuccessEdit));
            }
            else
            {
                GlobalMessageBox.Show("修改成功！");
                form.SetDialogResult(DialogResult.OK);
                this.RefreshPage();
            }
        }

        private void Print(RetailOrder retailOrder)
        {
            RefundOrderPrintUtil printHelper = new RefundOrderPrintUtil();
            List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
            foreach (var item in retailDetailList)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                // 显示自己设置的尺码组和对应的尺码列表
                item.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(item.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
            }

            RefundCostume retailCostume = new RefundCostume()
            {
                RefundDetailList = retailDetailList,
                RefundOrder = retailOrder,

            };
            int times = CommonGlobalUtil.ConvertToInt32(CommonGlobalCache.GetParameter(ParameterConfigKey.PrintCount).ParaValue);
            DataGridView dgv = deepCopyDataGridView();
            printHelper.Print(retailCostume, times, dgv);
        }

        internal void ShowPrintColumn(bool show)
        {
            ColumnPrint.Visible = show;
        }

        private void PrintRetail(RetailOrder retailOrder)
        {
            OrderPrintUtil printHelper = new OrderPrintUtil();
            List<RetailDetail> retailDetailList = CommonGlobalCache.ServerProxy.GetRetailDetailList(retailOrder.ID);
            foreach (var item in retailDetailList)
            {
                Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                // 显示自己设置的尺码组和对应的尺码列表
                item.SizeDisplayName = CostumeStoreHelper.GetCostumeSizeName(item.SizeName, CommonGlobalCache.GetSizeGroup(costume.SizeGroupName));
            }

            RetailCostume retailCostume = new RetailCostume()
            {
                RetailDetailList = retailDetailList,
                RetailOrder = retailOrder
            };
            int times = CommonGlobalUtil.ConvertToInt32(CommonGlobalCache.GetParameter(ParameterConfigKey.PrintCount).ParaValue);
            DataGridView dgv = deepCopyDataGridView();
            printHelper.Print(retailCostume, times, dgv);
        }

        private DataGridView deepCopyDataGridView()
        {
            DataGridView dgvTmp = new DataGridView();

            dgvTmp.Name = "dgvTmp";
            this.Controls.Add(dgvTmp);
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行

            dgvTmp.AutoGenerateColumns = false;



            List<RetailDetail> listtb1 = DataGridViewUtil.BindingListToList<RetailDetail>(dataGridView_RetailDetail.DataSource);

            List<RetailDetail> tb2 = new List<RetailDetail>();
            int autoID = 0;
            foreach (RetailDetail idetail in listtb1)
            {
                RetailDetail tDetail = new RetailDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                autoID++;
                tDetail.PrintAutoID = autoID;
                tb2.Add(tDetail);

            }
            DataGridViewTextBoxColumn dgvColumnAuto = new DataGridViewTextBoxColumn();
            dgvColumnAuto.Name = "序列号";
            dgvColumnAuto.HeaderText = "序列号";
            dgvColumnAuto.Visible = true;
            dgvColumnAuto.DataPropertyName = "PrintAutoID";
            dgvTmp.Columns.Add(dgvColumnAuto);

          //  List<DataGridViewTextBoxColumn> listColumns = new List<DataGridViewTextBoxColumn>();


            for (int i = 0; i < dataGridView_RetailDetail.Columns.Count; i++)
            {
                dgvTmp.Columns.Add(dataGridView_RetailDetail.Columns[i].Name, dataGridView_RetailDetail.Columns[i].HeaderText);
                if (dataGridView_RetailDetail.Columns[i].DefaultCellStyle.Format.Contains("N")) //使导出Excel文档金额列可做SUM运算
                {
                    dgvTmp.Columns[i + 1].DefaultCellStyle.Format = dataGridView_RetailDetail.Columns[i].DefaultCellStyle.Format;

                }
                if (!dataGridView_RetailDetail.Columns[i].Visible)
                {
                    dgvTmp.Columns[i + 1].Visible = false;
                }
                dgvTmp.Columns[i + 1].DataPropertyName = dataGridView_RetailDetail.Columns[i].DataPropertyName;
                if (dataGridView_RetailDetail.Columns[i].HeaderText == "单价") { dgvTmp.Columns[i + 1].HeaderText = "吊牌价"; }
                else if (dataGridView_RetailDetail.Columns[i].HeaderText == "销售额") { dgvTmp.Columns[i + 1].HeaderText = "金额"; }
                else
                {
                    dgvTmp.Columns[i + 1].HeaderText = dataGridView_RetailDetail.Columns[i].HeaderText;
                }
                dgvTmp.Columns[i + 1].Tag = dataGridView_RetailDetail.Columns[i].Tag;
                dgvTmp.Columns[i + 1].Name = dataGridView_RetailDetail.Columns[i].Name;

            }
            dgvTmp.DataSource = tb2;


            return dgvTmp;
        }

        private void ReturnDetail(RetailOrder item)
        {
            if (item != null)
            {
                SourceCtrlType.RefreshPageDisable = true;
                RefundDetailClick?.Invoke(item.RefundOrderID, this.SourceCtrlType);
            }
        }

        private void RetailDetail(RetailOrder item)
        {
            if (item != null)
            {
                SourceCtrlType.RefreshPageDisable = true;
                RetailDetailClick?.Invoke(item.OriginOrderID, this.SourceCtrlType);
            }
        }

        public override void RefreshPage()
        {
            if (this.pagePara != null)
            {
                PageControlPanel21_CurrentPageIndexChanged(this.pagePara.PageIndex);
            }
        }

        private void Cancel(RetailOrder allocateOrder)
        {
            try
            {
                if (!String.IsNullOrEmpty(allocateOrder.RefundOrderID))

                {
                    GlobalMessageBox.Show("销售单已退货，不能冲单！");
                    return;
                }
                String userId = string.Empty;
                if (IsPos)
                {
                    SelectGuideForm form = new SelectGuideForm();
                    if (form.ShowDialog(this.FindForm()) != DialogResult.OK)
                    {
                        return;
                    }
                    else
                    {
                        userId = form.Guide.ID;
                    }
                }
                else
                {
                    if (GlobalMessageBox.Show("是否确认操作？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    userId = CommonGlobalCache.CurrentUserID;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                CancelRetailOrderPara para = new CancelRetailOrderPara()
                {
                    CancelGuideID = userId,
                    RetailOrderID = allocateOrder.ID
                };

                InteractResult result =null;
                if (allocateOrder.IsRefundOrder)
                {
                    result = CommonGlobalCache.ServerProxy.CancelRefundOrder(para);
                }
                else
                {
                    result = CommonGlobalCache.ServerProxy.CancelRetailOrder(para);
                }
                switch (result.ExeResult)
                {
                    case ExeResult.Success:
                        GlobalMessageBox.Show("冲单成功！");

                        break;
                    //case ExeResult.IsNotToday:
                    //    GlobalMessageBox.Show("不是今天的销售/退货单！");
                    //    break;
                    //case CancelRetailOrderResult.IsRefundOrder:
                    //    GlobalMessageBox.Show("不是销售单！");
                    //    break;
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

        private void RetailOrderListCtrl_Load(object sender, EventArgs e)
        {
            if (this.pagePara != null)
            {
                Search();
                if (curFlag)
                {

                    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnRemove);
                }
               /* else
                {

                    dataGridViewPagingSumCtrl.RemoveNotShowInColumnSettings(ColumnRemove);
                }*/
               
            }
            CommonGlobalUtil.WriteLog("控件加载表格样式dataGridView_RetailOrder=" + dataGridView_RetailOrder.AutoSizeColumnsMode);
        }

        DataGridViewRow currRow = null;
        private void dataGridView_RetailOrder_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            ///不重复提交  DataGridViewRow row = view.CurrentRow;
            if (row != null && row.Index > -1 && row != currRow)
            {
                RetailOrder item = (RetailOrder)row.DataBoundItem;
                isRefundOrder = item.IsRefundOrder ;
                SetDisplay();
                this.BindingRetailDetailDataSourceAndCleanLabel(item);
                currRow = row;
            }
        }

        private void dataGridView_RetailOrder_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                clipboardOrder = view.Rows[e.RowIndex].DataBoundItem as RetailOrder;
                if (clipboardOrder.IsRefundOrder)
                {
                    retailItem.Visible = !String.IsNullOrEmpty(clipboardOrder.OriginOrderID);
                    refundItem.Visible = false;
                }
                else
                {
                    retailItem.Visible = false;
                    refundItem.Visible = !String.IsNullOrEmpty(clipboardOrder.RefundOrderID);
                }
            }
        }

        ToolStripMenuItem retailItem;
        ToolStripMenuItem refundItem;

        private void SetUpOrderStrip(ContextMenuStrip strip)
        {
            retailItem = new ToolStripMenuItem();
            retailItem.Name = "retailItem";
            retailItem.Text = "查看销售单";
            retailItem.Click += RetailItem_Click;
            strip.Items.Add(retailItem);
            refundItem = new ToolStripMenuItem();
            refundItem.Name = "refundItem";
            refundItem.Text = "查看退货单";
            refundItem.Click += RefundItem_Click;
            strip.Items.Add(refundItem);
        }

        private void dataGridView_RetailDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //  dataGridView_RetailDetail

            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            //DataGridViewRow row = dataGridView_RetailOrder.Rows[e.RowIndex];
            //RetailDetail orderDetail = (RetailDetail)row.DataBoundItem;

            //if (column_guideName.Index == e.ColumnIndex)
            //{
            //    e.Value = CommonGlobalCache.GetUserName(order.GuideID);
            //}
            //else
            
        }
    }
}
