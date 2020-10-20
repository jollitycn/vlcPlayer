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
using JGNet.Common.Core.Util;
using JGNet.Common.Printers;
using JieXi.Common;

namespace JGNet.Common
{/// <summary>
/// 采购退货明细
/// </summary>
    public partial class ReturnOrderDetailCtrl : BaseModifyCostumeIDUserControl
    {

        private PurchaseOrder curReturnOrder;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl; 
        public ReturnOrderDetailCtrl(PurchaseOrder order )
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1,new String[] {
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
        }


        private void Initialize()
        {
            if (this.curReturnOrder == null)
            {
                return;
            }
            try
            {
                this.skinTextBox_OrderID.Text = "采购单号：" + this.curReturnOrder.ID;
                this.skinLabel_ShopName.Text = "店铺名称：" + CommonGlobalCache.GetShopName(this.curReturnOrder.DestShopID);
                skinLabelRemarks.Text = "备注：" + curReturnOrder.Remarks;
                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(this.curReturnOrder.InboundOrderID);
                if (curReturnOrder.IsReturnType)
                {
                    SalePrice.Visible = false;

                }
                this.BindingOutboundDetailSource(list);
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
            //  dgvTmp.AllowUserToAddRows = false; //不允许用户生成行，否则导出后会多出最后一行

            dgvTmp.AutoGenerateColumns = false;

            DataTable listtb1 = (dataGridView1.DataSource as DataTable ) ;
            DataTable tb2 = listtb1.Copy();
          /*  foreach (DataRow  dr in listtb1.Rows)
            {
                DataRow tDetail = tb2.NewRow(); 
              //tDetail.CostumeID = idetail.CostumeID;
              //  tDetail.CostumeName = idetail.CostumeName;
              //  tDetail.BrandName = idetail.BrandName;
              //  tDetail.ColorName = idetail.ColorName;
              //  tDetail.Year = idetail.Year;
              //  tDetail.Season = idetail.Season;
              //  tDetail.CostPrice = idetail.CostPrice;
              //  tDetail.Price = idetail.Price;
              //  tDetail.SalePrice = idetail.SalePrice;
              //  tDetail.F = idetail.F;
              //  tDetail.XS= idetail.XS;
              //  tDetail.S = idetail.S;
              //  tDetail.M = idetail.M;
              //  tDetail.L = idetail.L;
              //  tDetail.XL = idetail.XL;
              //  tDetail.XL2 = idetail.XL2;
              //  tDetail.XL3 = idetail.XL3;
              //  tDetail.XL4 = idetail.XL4;
              //  tDetail.XL5 = idetail.XL5;
              //  tDetail.XL6 = idetail.XL6;
              //  tDetail.SumCount = idetail.SumCount;
              //  tDetail.SumCost = idetail.SumCost;
              //  tDetail.Comment = idetail.Comment;

               ReflectionHelper.CopyProperty(dr, tDetail);                
                tb2.Rows.Add(tDetail);

            }*/

            List<DataGridViewTextBoxColumn> listColumns = new List<DataGridViewTextBoxColumn>();

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

                /*   DataGridViewColumn dgvColumn = new DataGridViewColumn();
                  DataGridViewTextBoxColumn TxtBoxColumn = new DataGridViewTextBoxColumn();
                  TxtBoxColumn.Name = dataGridView1.Columns[i].Name;
                  TxtBoxColumn.Visible = dataGridView1.Columns[i].Visible;
                  TxtBoxColumn.DataPropertyName= dataGridView1.Columns[i].DataPropertyName;
                  TxtBoxColumn.HeaderText = dataGridView1.Columns[i].HeaderText;
                  TxtBoxColumn.Tag = dataGridView1.Columns[i].Tag;
                  TxtBoxColumn.Name = dataGridView1.Columns[i].Name;
                  listColumns.Add(TxtBoxColumn); */

            }
           // dgvTmp.Columns.AddRange( listColumns.ToArray());


            dgvTmp.DataSource = tb2;

             
            return dgvTmp;
        }

        public void Print()
        {
            DataGridView dgv = deepCopyDataGridView();
            PurchaseReturnOrderPrinter.Print(curReturnOrder, dgv, 2);
        }

        public void DoExport(string path)
        {

            try
            {
                // DataTable listtb1 = (dataGridView1.DataSource as DataTable);

                List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(this.curReturnOrder.InboundOrderID);
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

                foreach (BoundDetail cItem in list)
                {
                     cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);
                }


                List<CellType> cellList = new List<CellType>();
                NPOIHelper.hsRowCount = 5;
               

             /*   CellType curCellI = new CellType();
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
                if (curReturnOrder.ID.StartsWith("U")) { curCell.CellName = "采购退货单"; }
                else if(curReturnOrder.ID.StartsWith("A"))
                {
                    curCell.CellName = "采购进货单";
                }

                curCell.Title = true;
                    curCell.CellMergeNum = ColNum;
             
                // curCell.CellMergeIndex = 12;
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
                curCellSource.CellName = "供应商：";
                curCellSource.CellMergeNum = 1;
                cellList.Add(curCellSource);



                CellType curCellSourceValue = new CellType();
                curCellSourceValue.RowIndex = 2;
                curCellSourceValue.CellName = curReturnOrder.SupplierName;
                curCellSourceValue.CellMergeNum = 2;
                cellList.Add(curCellSourceValue);


                CellType curCellTarget = new CellType();
                curCellTarget.RowIndex = 2;
                curCellTarget.CellName = "操作人：";
                curCellTarget.CellMergeNum = 1;
                cellList.Add(curCellTarget);



                CellType curCellTargetValue = new CellType();
                curCellTargetValue.RowIndex = 2;
                 curCellTargetValue.CellName = curReturnOrder.UserName; 
                curCellTargetValue.CellMergeNum = 2;
                cellList.Add(curCellTargetValue);



                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = 3;
                curCellTotal.CellName = "总数量：";
                curCellTotal.CellMergeNum = 1;
                cellList.Add(curCellTotal);



                CellType curCellTotalValue = new CellType();
                curCellTotalValue.RowIndex = 3;
                curCellTotalValue.CellName = curReturnOrder.TotalCount.ToString();
                curCellTotalValue.CellMergeNum = 2;
                cellList.Add(curCellTotalValue);





                CellType curCellBalanceOld = new CellType();
                curCellBalanceOld.RowIndex = 3;
                curCellBalanceOld.CellName = "总成本：";
                curCellBalanceOld.CellMergeNum = 1;
                cellList.Add(curCellBalanceOld);



                CellType curCellBalanceValueOld = new CellType();
                curCellBalanceValueOld.RowIndex = 3;
                curCellBalanceValueOld.CellName = curReturnOrder.TotalCost.ToString();
                curCellBalanceValueOld.CellMergeNum = 2;
                cellList.Add(curCellBalanceValueOld);


 

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
        private void BindingOutboundDetailSource(List<BoundDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (BoundDetail detail in list)
                {
                    detail.CostumeName= CommonGlobalCache.GetCostumeName(detail.CostumeID);
                }
            }

            dataGridViewPagingSumCtrl.BindingDataSource<BoundDetail>(DataGridViewUtil.ToDataTable(list)); 
        }

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        BoundDetail detail = row.DataBoundItem as BoundDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
            }
        }

    }
}
