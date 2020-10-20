using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin;
using JGNet.Common.Core;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using JGNet.Common.Components;
using CJBasic.Helpers;
using JGNet.Core.Const;
using JGNet.Common.Core.Util;
using JieXi.Common;

namespace JGNet.Common
{
    public partial class CheckStoreDetailCtrl : BaseModifyCostumeIDUserControl
    {
        private CheckStoreOrder curCheckStoreOrder;
       public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
       // public DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl2;
        public CheckStoreDetailCtrl()
        {
            InitializeComponent();
            Init();
        }

        private DataGridView deepCopyDataGridView(DataTable details)
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
                if (dataGridView1.Columns[i].Visible==false)
                {
                    dgvTmp.Columns[i].Visible = false;
                }
                dgvTmp.Columns[i].DataPropertyName = dataGridView1.Columns[i].DataPropertyName;
                dgvTmp.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText;
                dgvTmp.Columns[i].Tag = dataGridView1.Columns[i].Tag;
                dgvTmp.Columns[i].Name = dataGridView1.Columns[i].Name;
                if (dgvTmp.Columns[i].DataPropertyName == "FAtm"|| dgvTmp.Columns[i].DataPropertyName == "XSAtm" || dgvTmp.Columns[i].DataPropertyName == "SAtm"
                    || dgvTmp.Columns[i].DataPropertyName == "MAtm" || dgvTmp.Columns[i].DataPropertyName == "LAtm" || dgvTmp.Columns[i].DataPropertyName == "XLAtm"
                    || dgvTmp.Columns[i].DataPropertyName == "XL2Atm" || dgvTmp.Columns[i].DataPropertyName == "XL3Atm" || dgvTmp.Columns[i].DataPropertyName == "XL4Atm"
                    || dgvTmp.Columns[i].DataPropertyName == "XL5Atm" || dgvTmp.Columns[i].DataPropertyName == "XL6Atm" )
                {
                    dgvTmp.Columns[i].Visible = false;
                }
            }


            DataTable tb2 =details.Copy();
             
           /* foreach (CheckStoreDetail idetail in details)
            {
                CheckStoreDetail tDetail = new CheckStoreDetail();
                ReflectionHelper.CopyProperty(idetail, tDetail);
                tb2.Add(tDetail);

            }*/

            dgvTmp.DataSource = tb2;



            return dgvTmp;
        }
        public void Print()
        {
            //  this.curCheckStoreOrder = order;
            // this.Initialize();
            DataTable details= dataGridView1.DataSource as DataTable;
           // dataGridViewPagingSumCtrl2.BindingDataSource(details);
            DataGridView dgv=deepCopyDataGridView(details);
            CheckStoreOrderPrinter.Print(curCheckStoreOrder, dgv, 2);
        }
        public void DoExport(string path, CheckStoreOrder checkStoreOrder)
        {

            try
            {
                // DataTable listtb1 = (dataGridView1.DataSource as DataTable);

                List<CheckStoreDetail> list = CommonGlobalCache.ServerProxy.GetCheckStoreDetail(checkStoreOrder.ID);
                foreach (CheckStoreDetail Sdetail in list)
                {
                    Sdetail.CostumeName = CommonGlobalCache.GetCostumeName(Sdetail.CostumeID);
                }
                //  List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(curReturnOrder.OutboundOrderID);
                // System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                int ColNum = 0;
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (item.Visible)
                    {
                       
                        if (item.DataPropertyName != "FAtm" && item.DataPropertyName != "SAtm" && item.DataPropertyName != "MAtm" && item.DataPropertyName != "LAtm"
                            && item.DataPropertyName != "XLAtm" && item.DataPropertyName != "XL2Atm" && item.DataPropertyName != "XL3Atm" && item.DataPropertyName != "XL4Atm"
                            && item.DataPropertyName != "XL5Atm" && item.DataPropertyName != "XL6Atm" && item.DataPropertyName != "SumCountAtm" && item.DataPropertyName != "XSAtm"
                              && item.Name!= "sumCountDataGridViewTextBoxColumn" && item.DataPropertyName!="Price"  && item.DataPropertyName!= "SumCountWinLost" && item.DataPropertyName!="SumMoneyWinLost"
                            )
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
                }

                foreach (CheckStoreDetail cItem in list)
                {
                    // cItem.CostumeName = CommonGlobalCache.GetCostumeName(cItem.CostumeID);
                }


                List<CellType> cellList = new List<CellType>();
                NPOIHelper.hsRowCount = 5;




              /*  CellType curCellOrderTitle = new CellType();
                curCellOrderTitle.RowIndex = 0;
                curCellOrderTitle.CellName = "：";
                if (ColNum % 2 == 0)
                {

                    curCellOrderTitle.CellMergeNum = ColNum / 2 - 1;
                }
                else
                {
                    curCellOrderTitle.CellMergeNum = ColNum / 2;
                }
              //  curCellOrderTitle.CellMergeNum = 10;
                cellList.Add(curCellOrderTitle);
                */


                CellType curCellOrderTitleValue = new CellType();
                curCellOrderTitleValue.RowIndex = 0;
                curCellOrderTitleValue.CellName ="盘点单";
                curCellOrderTitleValue.Title = true;


                    curCellOrderTitleValue.CellMergeNum = ColNum;
               
                // curCellOrderTitleValue.CellMergeNum = 12;
                cellList.Add(curCellOrderTitleValue);





                CellType curCellOrder = new CellType();
                curCellOrder.RowIndex = 1;
                curCellOrder.CellName = "单号：";
                curCellOrder.CellMergeNum = 1;
                cellList.Add(curCellOrder);



                CellType curCellOrderValue = new CellType();
                curCellOrderValue.RowIndex = 1;
                curCellOrderValue.CellName = checkStoreOrder.ID;
                curCellOrderValue.CellMergeNum = 2;
                cellList.Add(curCellOrderValue);

                CellType curCellCreaterUser = new CellType();
                curCellCreaterUser.RowIndex = 1;
                curCellCreaterUser.CellName = "店铺";
                curCellCreaterUser.CellMergeNum = 1;
                cellList.Add(curCellCreaterUser);

                CellType curCellCreaterUserValue = new CellType();
                curCellCreaterUserValue.RowIndex = 1;
                curCellCreaterUserValue.CellName = checkStoreOrder.ShopName;
                curCellCreaterUserValue.CellMergeNum = 2;
                cellList.Add(curCellCreaterUserValue);



                CellType curCellTime = new CellType();
                curCellTime.RowIndex = 2;
                curCellTime.CellName = "操作人";
                curCellTime.CellMergeNum = 1;
                cellList.Add(curCellTime);

                CellType curCellTimeValue = new CellType();
                curCellTimeValue.RowIndex = 2;
                curCellTimeValue.CellName = checkStoreOrder.OperatorUserName;
                curCellTimeValue.CellMergeNum = 2;
                cellList.Add(curCellTimeValue);



                CellType curCellSource = new CellType();
                curCellSource.RowIndex = 2;
                curCellSource.CellName = "审核人：";
                curCellSource.CellMergeNum = 1;
                cellList.Add(curCellSource);



                CellType curCellSourceValue = new CellType();
                curCellSourceValue.RowIndex = 2;
                curCellSourceValue.CellName = checkStoreOrder.CheckUserName;
                curCellSourceValue.CellMergeNum = 2;
                cellList.Add(curCellSourceValue);


                CellType curCellTarget = new CellType();
                curCellTarget.RowIndex = 3;
                curCellTarget.CellName = "盘点时间：";
                curCellTarget.CellMergeNum = 1;
                cellList.Add(curCellTarget);



                CellType curCellTargetValue = new CellType();
                curCellTargetValue.RowIndex = 3;
                curCellTargetValue.CellName = checkStoreOrder.CreateTime.GetDateTimeFormats('f')[0].ToString(); ; 
                curCellTargetValue.CellMergeNum = 2;
                cellList.Add(curCellTargetValue);



                CellType curCellTotal = new CellType();
                curCellTotal.RowIndex = 3;
                curCellTotal.CellName = "审核时间：";
                curCellTotal.CellMergeNum = 1;
                cellList.Add(curCellTotal);



                CellType curCellTotalValue = new CellType();
                curCellTotalValue.RowIndex = 3;
                curCellTotalValue.CellName = checkStoreOrder.CheckTime.GetDateTimeFormats('f')[0].ToString(); ;
                curCellTotalValue.CellMergeNum = 2;
                cellList.Add(curCellTotalValue);




 

                CellType curCellRemark = new CellType();
                curCellRemark.RowIndex = 4;
                curCellRemark.CellName = "备注：";
                curCellRemark.CellMergeNum = 1;
                cellList.Add(curCellRemark);



                CellType curCellRemarkValue = new CellType();
                curCellRemarkValue.RowIndex = 4;
                curCellRemarkValue.CellName = checkStoreOrder.Remarks.ToString();
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
        BaseModifyUserControl SourceControl = null;
        public void Search(CheckStoreOrder order, BaseModifyUserControl SourcePage)
        {
            this.curCheckStoreOrder = order;
            SourceControl = SourcePage;
            this.Initialize();
        } 

        public CheckStoreDetailCtrl(CheckStoreOrder order,bool isPos)
        { 
            InitializeComponent();
            Init();
            this.curCheckStoreOrder = order;
            this.Initialize();
        }

        private void Init()
        {
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new string[] {
                     fAtmDataGridViewTextBoxColumn.DataPropertyName,
       xSAtmDataGridViewTextBoxColumn.DataPropertyName,
       sAtmDataGridViewTextBoxColumn.DataPropertyName,
       mAtmDataGridViewTextBoxColumn.DataPropertyName,
       lAtmDataGridViewTextBoxColumn.DataPropertyName,
       xLAtmDataGridViewTextBoxColumn.DataPropertyName,
       xL2AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL3AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL4AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL5AtmDataGridViewTextBoxColumn.DataPropertyName,
       xL6AtmDataGridViewTextBoxColumn.DataPropertyName,
       sumCountAtmDataGridViewTextBoxColumn.DataPropertyName,
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
        SumMoneyWinLost.DataPropertyName, sumCountWinLostDataGridViewTextBoxColumn.DataPropertyName
            });
            dataGridViewPagingSumCtrl.Initialize();
       

        }

        private void Initialize()
        {
            if (this.curCheckStoreOrder == null)
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                //增写主表单
                this.skinLabel_OrderID.Text = this.curCheckStoreOrder.ID;
                this.skinLabel_CreateTime.Text = this.curCheckStoreOrder.CreateTime.ToString(DateTimeUtil.DEFAULT_DATETIME_FORMAT);
                if (this.curCheckStoreOrder.CheckTime != SystemDefault.DateTimeNull)
                {
                    this.skinLabel_approvedTime.Text = this.curCheckStoreOrder.CheckTime.ToString(DateTimeUtil.DEFAULT_DATETIME_FORMAT);
                }
                else { this.skinLabel_approvedTime.Text = string.Empty; }
                this.skinLabel_Remarks.Text = this.curCheckStoreOrder.Remarks;
                this.skinLabel_OperatorUserName.Text = CommonGlobalCache.GetUserName( this.curCheckStoreOrder.OperatorUserID);

                //待审核状态时显示审核按钮
                ShowButtons((CheckStoreOrderState)curCheckStoreOrder.State);
                List<CheckStoreDetail> list = CommonGlobalCache.ServerProxy.GetCheckStoreDetail(this.curCheckStoreOrder.ID);
                this.BindingCheckStoreDetailSource(list, (CheckStoreOrderState)curCheckStoreOrder.State);
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

        private void BindingCheckStoreDetailSource(List<CheckStoreDetail> list, CheckStoreOrderState curState)
        { 
            if (list != null && list.Count > 0)
            {
                foreach (CheckStoreDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    //if (curState == CheckStoreOrderState.ChildOrder) {
                    //    detail.SumCountWinLost = 0;
                    //} 


                }
            }

            this.dataGridViewPagingSumCtrl.BindingDataSource<CheckStoreDetail>(DataGridViewUtil.ToDataTable(list));
        }

        private void BaseButton_cancel_Click(object sender, EventArgs e)
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
                CheckStoreOrderIDAndUser para = new CheckStoreOrderIDAndUser();
                para.CheckStoreOrderID = this.curCheckStoreOrder.ID;
                para.CheckUserID = CommonGlobalCache.CurrentUserID; 
                UpdateCheckStoreResult result = CommonGlobalCache.ServerProxy.CancelCheckStore(para);
                switch (result)
                {
                    case UpdateCheckStoreResult.Success:
                        GlobalMessageBox.Show("退回成功！"); 
                        ShowButtons(CheckStoreOrderState.Canceled);
                        this.RefreshPageAction?.Invoke(this.CurrentTabPage, this.SourceCtrlType);
                        break;
                    case UpdateCheckStoreResult.StateIsNotPendingReview:
                        GlobalMessageBox.Show("状态不是待审核，操作失败！");
                        break;
                    case UpdateCheckStoreResult.StateIsApprovedOrPendingReview:
                        GlobalMessageBox.Show("状态是已审核或者已取消，操作失败！");
                        break;
                    case UpdateCheckStoreResult.Error:
                        GlobalMessageBox.Show("内部错误！");
                        break;
                    default:
                        break;
                } 
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

        private void ShowButtons(CheckStoreOrderState state)
        {
            bool value = ((state == CheckStoreOrderState.PendingReview));
            this.BaseButtonConfirm.Visible = value;
            this.curCheckStoreOrder.State = (int)state;
            switch (state)
            {
                case CheckStoreOrderState.All:
                    break;
                case CheckStoreOrderState.PendingReview:
                    break;
                case CheckStoreOrderState.Approved:
                 //   this.skinLabel_StateName.Text = "已审核";
                    this.skinLabel_approvedTime.Text = this.curCheckStoreOrder.CheckTime.ToString(DateTimeUtil.DEFAULT_DATETIME_FORMAT);
                    break;
                case CheckStoreOrderState.Canceled:
                   // this.skinLabel_StateName.Text = "已退回";

                    break;
                case CheckStoreOrderState.Expired:
                    break;
                case CheckStoreOrderState.Suspend:
                    break;
                default:
                    break;
            }


        }

        private void BaseButtonConfirm_Click(object sender, EventArgs e)
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
                JGNet.Core.InteractEntity.CheckStoreOrderIDAndUser para = new JGNet.Core.InteractEntity.CheckStoreOrderIDAndUser();
                para.CheckStoreOrderID = this.curCheckStoreOrder.ID;
                para.CheckUserID = CommonGlobalCache.CurrentUserID;
                InteractResult result = CommonGlobalCache.ServerProxy.CheckStore(para);
                switch (result.ExeResult)
                {
                    case ExeResult.Error:
                        GlobalMessageBox.Show(result.Msg);
                        break;
                    case ExeResult.Success:
                        GlobalMessageBox.Show("审核成功！");
                        CommonGlobalUtil.WriteLog("审核成功！店铺ID:" + curCheckStoreOrder.ShopID);
                        this.curCheckStoreOrder.CheckTime = DateTime.Now;
                        ShowButtons(CheckStoreOrderState.Approved);
                        ///this.RefreshPage?.Invoke(this.CurrentTabPage, this.SourceTabPage);
                        this.RefreshPageAction?.Invoke(this.CurrentTabPage, this.SourceCtrlType);
                        SourceControl.RefreshPage();
                        //  this.SourceCtrlType.RefreshPage();
                        //  this.RefreshPageDisable = true;
                        //   this.SourceCtrlType.RefreshPageDisable = true;
                        break;
                    default:
                        break;
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
 

        public override void HighlightCostume()
        {
            if (dataGridView1.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        CheckStoreDetail detail = row.DataBoundItem as CheckStoreDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            if (e.Value == null) {
                return;
            }
            if (e.ColumnIndex == sumCountWinLostDataGridViewTextBoxColumn.Index)
            {
                if (curCheckStoreOrder.State ==8  )
                {
                    e.Value = 0;
                }
            }
            
            
        }
    }
}
