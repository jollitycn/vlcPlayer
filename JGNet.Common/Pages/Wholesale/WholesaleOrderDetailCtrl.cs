using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Common.Components;
using CJBasic.Helpers;
using JGNet.Core.InteractEntity;
using JGNet.Common.Core.Util;
using JieXi.Common;

namespace JGNet.Common
{/// <summary>
/// 采购退货明细
/// </summary>
    public partial class WholesaleOrderDetailCtrl : BaseModifyCostumeIDUserControl
    {

        private PfOrder curReturnOrder;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl; 
        public WholesaleOrderDetailCtrl(PfOrder order)
        {
            InitializeComponent();
            skinLabel2.Text = order.PayTypeName;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new String[] {
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
                   fDataGridViewTextBoxColumn.DataPropertyName,
                sumMoneyDataGridViewTextBoxColumn.DataPropertyName,
                sumCountDataGridViewTextBoxColumn.DataPropertyName

            });
            dataGridViewPagingSumCtrl.Initialize();
            
            this.curReturnOrder = order;
            this.Initialize();
            MenuPermission = RolePermissionMenuEnum.批发发货退货单查询;
        }

        public void Print()
        {
            try
            {
                DataGridView dgv = deepCopyDataGridView();
                WholesaleDeliveryPrinter.Print(curReturnOrder, dgv, 2);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void DoExport(string path)
        {

            try
            {
                // DataTable listtb1 = (dataGridView1.DataSource as DataTable);

                List<PfOrderDetail> list = CommonGlobalCache.ServerProxy.GetPfOrderDetails(this.curReturnOrder.ID);
                //  List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(curReturnOrder.OutboundOrderID);
                // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                int ColNum = 0;
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (item.Visible)
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

                foreach (PfOrderDetail cItem in list)
                {
                   // cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);
                }


                List<CellType> cellList = new List<CellType>();
                NPOIHelper.hsRowCount = 5; 

               /*  CellType curCellI = new CellType();
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
                */


                CellType curCell = new CellType();
                curCell.RowIndex = 0;
                if (curReturnOrder.IsRefundOrder) { curCell.CellName = "批发退货单"; }
                else
                {
                    curCell.CellName = "批发发货单";
                }

                if (ColNum % 2 == 0)
                {
                    curCell.CellMergeNum = ColNum;
                }
                else
                {
                    curCell.CellMergeNum = ColNum;
                }
                // curCell.CellMergeIndex = 12;
                curCell.Title = true;
                cellList.Add(curCell);

                CellType curCellOrder = new CellType();
                curCellOrder.RowIndex = 1;
                curCellOrder.CellName = "单号：";
                curCellOrder.CellMergeNum = 1;
                cellList.Add(curCellOrder);



                CellType curCellOrderValue = new CellType();
                curCellOrderValue.RowIndex = 1;
                curCellOrderValue.CellName = curReturnOrder.ID;
                curCellOrderValue.CellMergeNum = 2;
                cellList.Add(curCellOrderValue);

                CellType curCellCreaterUser = new CellType();
                curCellCreaterUser.RowIndex = 1;
                curCellCreaterUser.CellName = "客户";
                curCellCreaterUser.CellMergeNum = 1;
                cellList.Add(curCellCreaterUser);

                CellType curCellCreaterUserValue = new CellType();
                curCellCreaterUserValue.RowIndex = 1;
                curCellCreaterUserValue.CellName = curReturnOrder.PfCustomerName;
                curCellCreaterUserValue.CellMergeNum = 2;
                cellList.Add(curCellCreaterUserValue);



                CellType curCellTime = new CellType();
                curCellTime.RowIndex = 1;
                curCellTime.CellName = "开单时间";
                curCellTime.CellMergeNum = 1;
                cellList.Add(curCellTime);

                CellType curCellTimeValue = new CellType();
                curCellTimeValue.RowIndex = 1;
                curCellTimeValue.CellName = curReturnOrder.CreateTime.GetDateTimeFormats('f')[0].ToString(); ;
                curCellTimeValue.CellMergeNum = 2;
                cellList.Add(curCellTimeValue);



                CellType curCellSource = new CellType();
                curCellSource.RowIndex = 2;
                curCellSource.CellName = "操作人：";
                curCellSource.CellMergeNum = 1;
                cellList.Add(curCellSource);



                CellType curCellSourceValue = new CellType();
                curCellSourceValue.RowIndex = 2;
                curCellSourceValue.CellName = curReturnOrder.AdminUserName;
                curCellSourceValue.CellMergeNum = 2;
                cellList.Add(curCellSourceValue);


                CellType curCellTarget = new CellType();
                curCellTarget.RowIndex = 2;
                curCellTarget.CellName = "付款方式：";
                curCellTarget.CellMergeNum = 1;
                cellList.Add(curCellTarget);



                CellType curCellTargetValue = new CellType();
                curCellTargetValue.RowIndex = 2;
                if (curReturnOrder.PayType == 0) { curCellTargetValue.CellName = "记账"; }
                if (curReturnOrder.PayType == 1) { curCellTargetValue.CellName = "余额"; }
                if (curReturnOrder.PayType == 2) { curCellTargetValue.CellName = "现金"; } 
                curCellTargetValue.CellMergeNum = 2;
                cellList.Add(curCellTargetValue);



                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = 2;
                curCellTotal.CellName = "总数量：";
                curCellTotal.CellMergeNum = 1;
                cellList.Add(curCellTotal);



                CellType curCellTotalValue = new CellType();
                curCellTotalValue.RowIndex = 2;
                curCellTotalValue.CellName = curReturnOrder.TotalCount.ToString();
                curCellTotalValue.CellMergeNum = 2;
                cellList.Add(curCellTotalValue);





                CellType curCellBalanceOld = new CellType();
                curCellBalanceOld.RowIndex = 3;
                curCellBalanceOld.CellName = "上欠金额：";
                curCellBalanceOld.CellMergeNum = 1;
                cellList.Add(curCellBalanceOld);



                CellType curCellBalanceValueOld = new CellType();
                curCellBalanceValueOld.RowIndex = 3;
                curCellBalanceValueOld.CellName = curReturnOrder.PaymentBalanceOld.ToString();
                curCellBalanceValueOld.CellMergeNum = 2;
                cellList.Add(curCellBalanceValueOld);



                CellType curCellCurPay = new CellType();
                curCellCurPay.RowIndex = 3;
                curCellCurPay.CellName = "本次应收金额：";
                curCellCurPay.CellMergeNum = 1;
                cellList.Add(curCellCurPay);



                CellType curCellCurPayValue = new CellType();
                curCellCurPayValue.RowIndex = 3;
                curCellCurPayValue.CellName = curReturnOrder.TotalPfPrice.ToString();
                curCellCurPayValue.CellMergeNum = 2;
                cellList.Add(curCellCurPayValue);


                CellType curCellBalance = new CellType();
                curCellBalance.RowIndex = 3;
                curCellBalance.CellName = "应收总额：";
                curCellBalance.CellMergeNum = 1;
                cellList.Add(curCellBalance);



                CellType curCellBalanceValue = new CellType();
                curCellBalanceValue.RowIndex = 3;
                curCellBalanceValue.CellName = curReturnOrder.PaymentBalance.ToString();
                curCellBalanceValue.CellMergeNum = 2;
                cellList.Add(curCellBalanceValue);


                CellType curCellRemark = new CellType();
                curCellRemark.RowIndex = 4;
                curCellRemark.CellName = "备注：";
                curCellRemark.CellMergeNum = 1;
                cellList.Add(curCellRemark);



                CellType curCellRemarkValue = new CellType();
                curCellRemarkValue.RowIndex = 4;
                curCellRemarkValue.CellName = curReturnOrder.Remarks.ToString();
                curCellRemarkValue.CellMergeNum = 8;
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

        private DataGridView deepCopyDataGridView()
        {
            DataGridView dgvTmp = new DataGridView();

            dgvTmp.Name = "dgvTmp";
            this.Controls.Add(dgvTmp);
            dgvTmp.AutoGenerateColumns = false;
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dgvTmp.Columns.Add(dataGridView1.Columns[i].Name, dataGridView1.Columns[i].HeaderText);
                if (dataGridView1.Columns[i].DefaultCellStyle.Format.Contains("N")) //使导出Excel文档金额列可做SUM运算
                {
                    dgvTmp.Columns[i].DefaultCellStyle.Format = dataGridView1.Columns[i].DefaultCellStyle.Format;

                }
                if (!dataGridView1.Columns[i].Visible)
                {
                    dgvTmp.Columns[i].Visible = false;
                }
                dgvTmp.Columns[i].DataPropertyName = dataGridView1.Columns[i].DataPropertyName;
                dgvTmp.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText;
                dgvTmp.Columns[i].Tag = dataGridView1.Columns[i].Tag;
                dgvTmp.Columns[i].Name = dataGridView1.Columns[i].Name;
            }



            DataTable listtb1 =  (dataGridView1.DataSource as DataTable);

            DataTable tb2 = listtb1.Copy();
            /* foreach (DataRow idetail in listtb1.Rows)
             {
                 DataRow tDetail = tb2.NewRow();

                 ReflectionHelper.CopyProperty(idetail, tDetail);
                 tb2.Rows.Add(tDetail);

             }*/

            foreach (DataRow dr in tb2.Rows)
            {
                // dr["CostumeID"]
             //  dr["Price"]= CommonGlobalCache.GetCostume(dr["CostumeID"].ToString()).Price;
            }

            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }
        public WholesaleOrderDetailCtrl(String orderID)
        {
            InitializeComponent();

       
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new String[] {
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
                   fDataGridViewTextBoxColumn.DataPropertyName,
                sumMoneyDataGridViewTextBoxColumn.DataPropertyName,
                sumCountDataGridViewTextBoxColumn.DataPropertyName

            });
            dataGridViewPagingSumCtrl.Initialize();
            GetPfOrderPagePara para = new GetPfOrderPagePara()
            {
                PfOrderID = orderID, 
                PageIndex = 0,
                PageSize = 1
            };
            PfOrderPage listPage = CommonGlobalCache.ServerProxy.GetPfOrderPage(para);
            if (listPage != null && listPage.PfOrders.Count == 1)
            {
                //获取order
                this.curReturnOrder = listPage.PfOrders[0];
            
            }

           
            this.Initialize();
        }
        

        private void Initialize()
        {
            if (this.curReturnOrder == null)
            {
                return;
            }
            try
            {
                skinLabel2.Text = curReturnOrder.PayTypeName;
                skinLabelOrder.Text = curReturnOrder.IsRefundOrder ? "批发退货单号：" : "批发发货单号：";
                skinLabelRemark.Text = curReturnOrder.Remarks;
                skinLabelOrderId.Text = curReturnOrder.ID;
                List<PfOrderDetail> list = CommonGlobalCache.ServerProxy.GetPfOrderDetails(this.curReturnOrder.ID);
                this.BindingOutboundDetailSource(list);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void BindingOutboundDetailSource(List<PfOrderDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (PfOrderDetail detail in list)
                {
                    detail.CostumeName= CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    
                }
            }

            dataGridViewPagingSumCtrl.BindingDataSource<PfOrderDetail>(DataGridViewUtil.ToDataTable(list)); 
        }

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        PfOrderDetail detail = row.DataBoundItem as PfOrderDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }

                }
            }
        } 
    }
}
