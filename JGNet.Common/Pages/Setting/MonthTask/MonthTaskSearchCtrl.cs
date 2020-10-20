using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CJBasic;
using JGNet.Core.InteractEntity;
using CCWin;
using CJBasic.Loggers;
using JGNet.Common.Core;  
using JGNet.Common.Components;
using JGNet.Common.Core.Util;
using JGNet.Common.Entitys;

namespace JGNet.Common
{
    public partial class MonthTaskSearchCtrl : BaseUserControl
    {

        private MonthTaskPagePara pagePara;
        private MonthTaskSearch currShopTask;
        private List<MonthTask> monthGuideTaskList;
        private List<MonthTaskSearch> monthGuideTaskSearchList;
        private String shopID;
        public CJBasic.Action<MonthTask, Type> DetailClick;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrlDetail;

        public MonthTaskSearchCtrl()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView_MonthTask, new String[] {
                target1DataGridViewTextBoxColumn.DataPropertyName,
                target2DataGridViewTextBoxColumn.DataPropertyName,
                target3DataGridViewTextBoxColumn.DataPropertyName,
                target4DataGridViewTextBoxColumn.DataPropertyName,
                target5DataGridViewTextBoxColumn.DataPropertyName,
                target6DataGridViewTextBoxColumn.DataPropertyName,
                target7DataGridViewTextBoxColumn.DataPropertyName,
                target8DataGridViewTextBoxColumn.DataPropertyName,
                target9DataGridViewTextBoxColumn.DataPropertyName,
                target10DataGridViewTextBoxColumn.DataPropertyName,
                target11DataGridViewTextBoxColumn.DataPropertyName,
                target12DataGridViewTextBoxColumn.DataPropertyName,
            });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            this.dataGridViewPagingSumCtrlDetail = new DataGridViewPagingSumCtrl(this.dataGridView_RefundDetail, new String[] {
            moneyOfSaleDataGridViewTextBoxColumn.DataPropertyName});
            dataGridViewPagingSumCtrlDetail.Initialize();
            MenuPermission = RolePermissionMenuEnum.销售目标;
            skinComboBoxShopID.Initialize();
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }
        private void Initialize()
        {
            this.numericUpDown_year.Value = DateTime.Now.Year; 

            this.BindingMonthTaskDataSource(null);
            this.BindingRefundDetailDataSource(null, -1);
            this.pagePara = new MonthTaskPagePara();
           this.dataGridViewPagingSumCtrl.Initialize(1);
            if (HasPermission(RolePermissionEnum.编辑))
            {
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(Column2, Column4);
            }
            else
            {
                dataGridView_MonthTask.CellValidating -= dataGridView_CellValidating;
                dataGridView_RefundDetail.CellValidating -= dataGridView_CellValidating;
                skinComboBoxShopID.Enabled = false;
                dataGridView_MonthTask.ReadOnly = true;
                dataGridView_RefundDetail.ReadOnly = true;
                skinComboBoxShopID.SelectedValue = CommonGlobalCache.CurrentShopID;
                shopDataGridViewTextBoxColumn.Visible = false;
                skinLabel1.Visible = false;
                dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnSetting, ColumnSetting2);
            }

            skinSplitContainer1.Panel2Collapsed = true;

        }

        List<MonthTask> listPage;
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                this.pagePara = new MonthTaskPagePara()
                {
                    Year = (int)numericUpDown_year.Value,
                    ShopID = shopID
                };
                listPage = CommonGlobalCache.ServerProxy.GetMonthTaskPage(this.pagePara);

                //获取当前月份的任务
                if (listPage == null)
                {
                    return;
                }

                List<MonthTaskSearch> monthTaskSearchList = new List<MonthTaskSearch>();
                List<Shop> shops = new List<Shop>();

                //获取所有店铺 
                foreach (MonthTask task in listPage)
                {
                    Shop shop = CommonGlobalCache.GetShop(task.ShopID);
                    if (!shops.Contains(shop))
                    {
                        shops.Add(shop);
                    }
                }
                foreach (Shop shop in shops)
                {
                    MonthTaskSearch item = new MonthTaskSearch();
                    item.MonthTasks = new List<MonthTask>();
                    item.Shop = shop;
                    item.Year = (int)this.numericUpDown_year.Value;
                    foreach (MonthTask task in listPage)
                    {
                        if (task?.ShopID == shop?.ID)
                        {
                            item.MonthTasks.Add(task);
                            String month = task.Month.ToString().Substring(4);
                            switch (month)
                            {
                                case "01":
                                    item.Target1 = task.MoneyOfSale;
                                    item.AutoID1 = task.AutoID;
                                    break;
                                case "02":
                                    item.Target2 = task.MoneyOfSale;
                                    item.AutoID2 = task.AutoID;
                                    break;
                                case "03":
                                    item.Target3 = task.MoneyOfSale;
                                    item.AutoID3 = task.AutoID;
                                    break;
                                case "04":
                                    item.Target4 = task.MoneyOfSale;
                                    item.AutoID4 = task.AutoID;
                                    break;
                                case "05":
                                    item.Target5 = task.MoneyOfSale;
                                    item.AutoID5 = task.AutoID;
                                    break;
                                case "06":
                                    item.Target6 = task.MoneyOfSale;
                                    item.AutoID6 = task.AutoID;
                                    break;
                                case "07":
                                    item.Target7 = task.MoneyOfSale;
                                    item.AutoID7 = task.AutoID;
                                    break;
                                case "08":
                                    item.Target8 = task.MoneyOfSale;
                                    item.AutoID8 = task.AutoID;
                                    break;
                                case "09":
                                    item.Target9 = task.MoneyOfSale;
                                    item.AutoID9 = task.AutoID;
                                    break;
                                case "10":
                                    item.Target10 = task.MoneyOfSale;
                                    item.AutoID10 = task.AutoID;
                                    break;
                                case "11":
                                    item.Target11 = task.MoneyOfSale;
                                    item.AutoID11 = task.AutoID;
                                    break;
                                case "12":
                                    item.Target12 = task.MoneyOfSale;
                                    item.AutoID12 = task.AutoID;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    monthTaskSearchList.Add(item);
                }

                if (numericUpDown_year.Value < DateTime.Now.Year || !HasPermission( RolePermissionEnum.编辑))
                {
                   // dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(ColumnSetting, ColumnSetting2);
                    ColumnSetting2.Visible = false;
                    ColumnSetting.Visible = false;
                }
                else
                {
                    ColumnSetting2.Visible = true;
                    ColumnSetting.Visible = true;
                }

                this.BindingMonthTaskDataSource(monthTaskSearchList);
                #region 清空dataGridView_MonthTask的绑定源 
                this.BindingRefundDetailDataSource(null, -1);
                #endregion
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
        /// 绑定MonthTask数据源
        /// </summary>
        private void BindingMonthTaskDataSource(
                List<MonthTaskSearch> listPage)
        {
            skinSplitContainer1.Panel2Collapsed = true;
            monthGuideTaskSearchList = listPage;

            dataGridViewPagingSumCtrl.BindingDataSource(listPage);

            //判断现在月份,如果小于当前月份则不允许修改

            int month = DateTime.Now.Month;
            foreach (DataGridViewColumn col in dataGridView_MonthTask.Columns)
            {
                if (shopDataGridViewTextBoxColumn != col && dataGridViewPagingSumCtrl.AutoIndexColumn != col)
                {
                    //增加了序号+1
                    col.ReadOnly = col.Index < month && Decimal.ToInt32(numericUpDown_year.Value) <= DateTime.Now.Year;
                    // col.ReadOnly = col.Index < month  && Decimal.ToInt32(numericUpDown_year.Value) <= DateTime.Now.Year;
                    if (HasPermission(RolePermissionEnum.编辑))
                    {
                        if (col.ReadOnly)
                        {
                            col.DefaultCellStyle.ForeColor = Color.DarkGray;
                        }
                        else
                        {
                            col.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 绑定RefundDetail数据源
        /// </summary>
        private void BindingRefundDetailDataSource(MonthTaskSearch search, int index)
        {
            skinSplitContainer1.Panel2Collapsed = false;
           // this.dataGridView_RefundDetail.DataSource = null;
            if (search != null && index != -1)
            {
                monthGuideTaskList = new List<MonthTask>();
                int month = int.Parse((search.Year.ToString() + (index < 10 ? "0" + index : index.ToString())));
                GetMonthTaskPara para = new GetMonthTaskPara()
                {
                    GuideID = null,
                    ShopID = search?.Shop?.ID,
                    Year = search.Year,
                    Month = month
                };
                monthGuideTaskList = CommonGlobalCache.ServerProxy.GetMonthTasks(para); 
                if (monthGuideTaskList != null && monthGuideTaskList.Count > 0)
                {
                    foreach (MonthTask detail in monthGuideTaskList)
                    {
                        detail.GuideName = CommonGlobalCache.GetUserName(detail.GuideID); 
                    } 
                } 


                moneyOfSaleDataGridViewTextBoxColumn.ReadOnly = index < DateTime.Now.Month && Decimal.ToInt32(numericUpDown_year.Value) <= DateTime.Now.Year;
                //设置日目标
                bool isEditable =     !(index <DateTime.Now.Month && Decimal.ToInt32(numericUpDown_year.Value) <= DateTime.Now.Year);
                ColumnSetting2.Text = isEditable ? "设置日目标" : string.Empty;
                if (HasPermission( RolePermissionEnum.编辑))
                {
                    if (moneyOfSaleDataGridViewTextBoxColumn.ReadOnly)
                    {
                        moneyOfSaleDataGridViewTextBoxColumn.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }
                    else
                    {
                        moneyOfSaleDataGridViewTextBoxColumn.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                //绑定之后设置过期单元格只读
                //foreach(dataGridView_RefundDetail.Rows)
            }

            dataGridViewPagingSumCtrlDetail.BindingDataSource(monthGuideTaskList);
            //  dataGridViewPagingSumCtrlDetail.BindingDataSource(refundDetailList); 
        }

        private void MonthTaskSearchCtrl_Load(object sender, EventArgs e)
        {

            this.Initialize();
        }

        private void dataGridView_MonthTask_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MonthTask.CurrentRow != null)
            {

                MonthTaskSearch item = (MonthTaskSearch)dataGridView_MonthTask.CurrentRow.DataBoundItem;
                currShopTask = item;
                this.BindingRefundDetailDataSource(item, dataGridView_MonthTask.CurrentCell.ColumnIndex);
            }
        }
        private object clickValue;
         

        private void ShowDayTask(MonthTaskSearch search,MonthTask task, bool readOnly = false)
        {
            MonthTaskForm form = new MonthTaskForm();
            if (!readOnly)
            {
                if (search != null)
                {
                    form.SearchConfirm += Form_SearchConfirm;
                } else
                {
                    form.Confirm += Form_Confirm;
                }
            }
            //form.Confirm;
            form.ShowDialog(search, task, readOnly);
        }
        /// <summary>
        /// 当前月份店铺任务
        /// </summary>
        MonthTask curMonthTask;
        private void Form_SearchConfirm(MonthTaskSearch obj)
        {
            if (obj != null)
            {
                foreach (var item in obj.MonthTasks)
                {
                    Form_Confirm(item);
                }
            }
        }

        private void Form_Confirm(MonthTask obj)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                curMonthTask = obj;
                UpdateMonthTaskResult result = CommonGlobalCache.ServerProxy.UpdateMonthTask(curMonthTask);
                switch (result)
                {
                    case UpdateMonthTaskResult.Success:
                        break;
                    case UpdateMonthTaskResult.IsLessCurrentMonth:
                        break;
                    case UpdateMonthTaskResult.Error:
                        GlobalMessageBox.Show("内部错误！");
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

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(skinComboBoxShopID.SelectedValue);
        }



        private void dataGridView_MonthTask_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                //当前更改的列 
                DataGridViewCell cell = view.CurrentCell;
                //当前绑定数据
                MonthTaskSearch item = cell.OwningRow.DataBoundItem as MonthTaskSearch;
                MonthTask task = item.MonthTasks[e.ColumnIndex-1];
                task.ShopID = item.Shop.ID;


                int monthIndex = e.ColumnIndex;
                switch (monthIndex)
                {//增加了序号
                    case 1:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target1);
                        task.AutoID = item.AutoID1;
                        break;
                    case 2:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target2); task.AutoID = item.AutoID2;
                        break;
                    case 3:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target3); task.AutoID = item.AutoID3;
                        break;
                    case 4:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target4); task.AutoID = item.AutoID4;
                        break;
                    case 5:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target5); task.AutoID = item.AutoID5;
                        break;
                    case 6:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target6); task.AutoID = item.AutoID6;
                        break;
                    case 7:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target7); task.AutoID = item.AutoID7;
                        break;
                    case 8:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target8); task.AutoID = item.AutoID8;
                        break;
                    case 9:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target9); task.AutoID = item.AutoID9;
                        break;
                    case 10:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target10); task.AutoID = item.AutoID10;
                        break;
                    case 11:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target11); task.AutoID = item.AutoID11;
                        break;
                    case 12:
                        task.MoneyOfSale = Decimal.ToInt32(item.Target12); task.AutoID = item.AutoID12;
                        break;
                    default:
                        break;
                }


                //if (task.MoneyOfSale == 0) {
                //    GlobalMessageBox.Show(this.FindForm(), "不能设置为0！");
                //    dataGridView_RefundDetail.CellValueChanged -= dataGridView_RefundDetail_CellValueChanged;
                //    dataGridView_MonthTask.CellValueChanged -= dataGridView_MonthTask_CellValueChanged;
                //    view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = clickValue;
                //    view.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                //    dataGridView_RefundDetail.CellValueChanged += dataGridView_RefundDetail_CellValueChanged;
                //    dataGridView_MonthTask.CellValueChanged += dataGridView_MonthTask_CellValueChanged;
                //    //view.CancelEdit();
                //    //view.RefreshEdit(); view.Refresh();
                //    return; 
                //}
                task.Month = item.Year * 100 + monthIndex;
                task.GuideID = "";
                UpdateMonthTaskResult result = CommonGlobalCache.ServerProxy.UpdateMonthTask(task);
                switch (result)
                {
                    case UpdateMonthTaskResult.Success:
                        //平摊
                        AvgDetail(task);

                        break;
                    case UpdateMonthTaskResult.IsLessCurrentMonth:
                        view.CancelEdit();  
                        break;
                    case UpdateMonthTaskResult.Error:
                        view.CancelEdit(); 
                        GlobalMessageBox.Show("内部错误！");
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

        private void AvgDetail(MonthTask task)
        {
            //            List<MonthTask> monthTasks = dataGridView_RefundDetail.DataSource as List<MonthTask>;

            if (dataGridView_RefundDetail.RowCount > 0)
            {
                double avgMonthTask = task.MoneyOfSale / dataGridView_RefundDetail.RowCount;
                foreach (DataGridViewRow item in dataGridView_RefundDetail.Rows)
                {
                    item.Cells[moneyOfSaleDataGridViewTextBoxColumn.Index].Value = avgMonthTask;
                }
            }
        }

        private void dataGridView_RefundDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridView view = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                
                //当前更改的列 
                DataGridViewCell cell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //当前绑定数据
                MonthTask task = cell.OwningRow.DataBoundItem as MonthTask;

                //if (task.MoneyOfSale == 0)
                //{
                //    GlobalMessageBox.Show(this.FindForm(), "不能设置为0！");
                //       view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = clickValue;
                //    view.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                //    return;
                //}
                UpdateMonthTaskResult result = CommonGlobalCache.ServerProxy.UpdateMonthTask(task);
                switch (result)
                {
                    case UpdateMonthTaskResult.Success:
                        break;
                    case UpdateMonthTaskResult.IsLessCurrentMonth:
                        view.CancelEdit();  
                        break;
                    case UpdateMonthTaskResult.Error:
                        view.CancelEdit();  
                        GlobalMessageBox.Show("内部错误！");
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

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridView grid = (DataGridView)sender;
                grid.Rows[e.RowIndex].ErrorText = "";
                //增加了序号
                if (e.ColumnIndex > 0 && e.ColumnIndex != Column4.Index && e.ColumnIndex != ColumnSetting.Index && e.ColumnIndex != ColumnSetting2.Index && e.ColumnIndex != Column2.Index)
                // if (e.ColumnIndex > 1)
                {
                    Int32 newInteger = 0;
                    if (!int.TryParse(e.FormattedValue.ToString(), out newInteger))
                    {
                        e.Cancel = true;
                        grid.Rows[e.RowIndex].ErrorText = "请输入整数";
                        GlobalMessageBox.Show("请输入整数！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            // }
        }
         
        private void dataGridView_MonthTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            clickValue = dataGridView_MonthTask.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            MonthTaskSearch search = dataGridView_MonthTask.Rows[e.RowIndex].DataBoundItem as MonthTaskSearch;
            String content = CommonGlobalUtil.ConvertToString(clickValue);
            if (content == "设置日目标")
            {
                curMonthTask = null;

                int month = Decimal.ToInt32(numericUpDown_year.Value) * 100 + DateTime.Now.Month;
                // int month = new Date( DateTime.Now).ToDateInteger();
                foreach (var item in search.MonthTasks)
                {
                    if (item.Month == month)
                    {
                        curMonthTask = item;
                        break;
                    }

                }
                ShowDayTask(search, curMonthTask);
            }
            else if (content == "查看日目标")
            {
                curMonthTask = null;
                int month = Decimal.ToInt32(numericUpDown_year.Value) * 100 + DateTime.Now.Month;
                // int month = new Date( DateTime.Now).ToDateInteger();
                foreach (var item in search.MonthTasks)
                {
                    if (item.Month == month)
                    {
                        curMonthTask = item;
                        break;
                    }
                }
                ShowDayTask(search, curMonthTask, false);
            }
        }

        private void dataGridView_RefundDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
            clickValue = dataGridView_RefundDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            String content = CommonGlobalUtil.ConvertToString(clickValue);

            MonthTask item = dataGridView_RefundDetail.Rows[e.RowIndex].DataBoundItem as MonthTask;
            if (content == "设置日目标")
            {
                curMonthTask = item;
                ShowDayTask(null, curMonthTask);
            }
            else if (content == "查看日目标")
            {
                curMonthTask = item;
                ShowDayTask(null, curMonthTask, true);
            }
        }  
    }
}
