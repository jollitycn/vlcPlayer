using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

using JGNet.Common.Core;  
using JGNet.Common.Components; 
using CJBasic.Helpers;
using JGNet.Core.InteractEntity;
using JGNet.Common.Core.Util;
using JieXi.Common;

namespace JGNet.Common
{
    public partial class ReplenishDetailCtrl : BaseModifyCostumeIDUserControl
    {

        private ReplenishOrder curReplenishOrder;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl; 
        public ReplenishDetailCtrl(ReplenishOrder order)
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,new string[] {
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
            sumCountDataGridViewTextBoxColumn.DataPropertyName,
            SumMoney4Price.DataPropertyName
            });
            
            dataGridViewPagingSumCtrl.Initialize(); 
            this.curReplenishOrder = order;
            this.Initialize(); 
        }

        private void Initialize()
        {
            if (this.curReplenishOrder == null)
            {
                return;
            }
            try
            {
                this.skinTextBox_OrderID.Text = "补货申请单号：" + this.curReplenishOrder.ID;
                //this.skinLabel_ShopName.Text ="店铺名称："+ CommonGlobalCache.GetShopName(this.curReplenishOrder.ShopID) ;
           //     this.skinTextBox_OrderID.Text = "调拨单号：" + this.curReplenishOrder.ID;
                this.skinLabelReceive.Text = "收货方：" + CommonGlobalCache.GetShopName(this.curReplenishOrder.ShopID);

                if (!String.IsNullOrEmpty(curReplenishOrder.AllocateOrderID))
                {
                    Outbound outbound = CommonGlobalCache.ServerProxy.GetOneOutbound(this.curReplenishOrder.AllocateOrderID);
                    if (outbound != null)
                    {
                        //获取出库单
                        
                        this.skinLabelSend.Text = "发货方：" + CommonGlobalCache.GetShopName(outbound.OutboundOrder.ShopID);
                    }
                }

                skinLabelRemarks.Text = "备注：" + curReplenishOrder.Remarks;
                List<ReplenishDetail> list = CommonGlobalCache.ServerProxy.GetReplenishDetail(this.curReplenishOrder.ID);
                this.BindingReplenishDetailSource(list);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.Logger.Log(ee, "ReplenishDetailCtrl.Initialize", CJBasic.Loggers.ErrorLevel.Standard);
            }

        }

        private void BindingReplenishDetailSource(List<ReplenishDetail> list)
        { 
            if (list != null && list.Count > 0)
            {
                foreach (ReplenishDetail detail in list)
                {
                    detail.CostumeName= CommonGlobalCache.GetCostumeName(detail.CostumeID);
               
                } 
            } 
            dataGridViewPagingSumCtrl.BindingDataSource<ReplenishDetail>(DataGridViewUtil.ToDataTable(list));
           
        }

        private void ReplenishDetailCtrl_Load(object sender, EventArgs e)
        {
        }

        public override void HighlightCostume()
        {
            if (this.dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ReplenishDetail detail = row.DataBoundItem as ReplenishDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
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



            // List<ReplenishDetail> listtb1 =(List<ReplenishDetail>)(dataGridView1.DataSource);
            DataTable listtb1 = dataGridView1.DataSource as DataTable;
            DataTable tb2 = listtb1.Copy();
           /* foreach (ReplenishDetail idetail in listtb1)
            {
                ReplenishDetail tDetail = new ReplenishDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }*/


            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }
        public void Print()
        {
            DataGridView dgv = deepCopyDataGridView();
            ReplenishOrderPrinter.Print(this.curReplenishOrder, dgv, 2);
        }

        public void DoExport(string path)
        {

            try
            {
                // DataTable listtb1 = (dataGridView1.DataSource as DataTable);

                List<ReplenishDetail> list = CommonGlobalCache.ServerProxy.GetReplenishDetail(this.curReplenishOrder.ID);
                //  List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(curReturnOrder.OutboundOrderID);
                // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                int ColNum = 0;
                foreach (DataGridViewColumn item in dataGridView1.Columns)
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

                foreach (ReplenishDetail cItem in list)
                {
                     cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);
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
                
                    curCell.CellName = "补货申请单";


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
                curCellOrderValue.CellName = curReplenishOrder.ID;
                curCellOrderValue.CellMergeNum = 2;
                cellList.Add(curCellOrderValue);

                CellType curCellCreaterUser = new CellType();
                curCellCreaterUser.RowIndex = 1;
                curCellCreaterUser.CellName = "申请时间";
                curCellCreaterUser.CellMergeNum = 1;
                cellList.Add(curCellCreaterUser);

                CellType curCellCreaterUserValue = new CellType();
                curCellCreaterUserValue.RowIndex = 1;
                curCellCreaterUserValue.CellName = curReplenishOrder.CreateTime.GetDateTimeFormats('f')[0].ToString();
                curCellCreaterUserValue.CellMergeNum = 2;
                cellList.Add(curCellCreaterUserValue);

                
                CellType curCellTime = new CellType();
                curCellTime.RowIndex = 2;
                curCellTime.CellName = "申请店铺";
                curCellTime.CellMergeNum = 1;
                cellList.Add(curCellTime);

                CellType curCellTimeValue = new CellType();
                curCellTimeValue.RowIndex = 2;
                curCellTimeValue.CellName = curReplenishOrder.ShopName;
                curCellTimeValue.CellMergeNum = 2;
                cellList.Add(curCellTimeValue);



                CellType curCellSource = new CellType();
                curCellSource.RowIndex = 2;
                curCellSource.CellName = "申请人：";
                curCellSource.CellMergeNum = 1;
                cellList.Add(curCellSource);



                CellType curCellSourceValue = new CellType();
                curCellSourceValue.RowIndex = 2;
                  curCellSourceValue.CellName = CommonGlobalCache.GetUserName(curReplenishOrder.RequestGuideID);
                curCellSourceValue.CellMergeNum = 2;
                cellList.Add(curCellSourceValue);


                CellType curCellTarget = new CellType();
                curCellTarget.RowIndex = 3;
                curCellTarget.CellName = "总数量：";
                curCellTarget.CellMergeNum = 1;
                cellList.Add(curCellTarget);



                CellType curCellTargetValue = new CellType();
                curCellTargetValue.RowIndex = 3;
                curCellTargetValue.CellName = curReplenishOrder.TotalCount.ToString();
                curCellTargetValue.CellMergeNum = 2;
                cellList.Add(curCellTargetValue);



                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = 3;
                curCellTotal.CellName = "金额：";
                curCellTotal.CellMergeNum = 1;
                cellList.Add(curCellTotal);



                CellType curCellTotalValue = new CellType();
                curCellTotalValue.RowIndex = 3;
                curCellTotalValue.CellName = curReplenishOrder.TotalPrice.ToString();
                curCellTotalValue.CellMergeNum = 2;
                cellList.Add(curCellTotalValue);




 

                CellType curCellRemark = new CellType();
                curCellRemark.RowIndex = 4;
                curCellRemark.CellName = "备注：";
                curCellRemark.CellMergeNum = 1;
                cellList.Add(curCellRemark);



                CellType curCellRemarkValue = new CellType();
                curCellRemarkValue.RowIndex = 4;
                curCellRemarkValue.CellName = curReplenishOrder.Remarks.ToString();
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
    }
}
