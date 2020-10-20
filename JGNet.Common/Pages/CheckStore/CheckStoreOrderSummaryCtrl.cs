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
using JGNet.Core.Tools;
using JieXi.Common;
using CJBasic;

namespace JGNet.Common
{
    public partial class CheckStoreOrderSummaryCtrl : BaseModifyUserControl
    {
        private GetCheckStoreSummaryPagePara pagePara = null;
        private String shopID;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CheckStoreOrderSummaryCtrl()
        {
            InitializeComponent();
            try
            {
                this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                    dataGridViewPagingSumCtrl_CurrentPageIndexChanged,
                    BaseButton_Search_Click,
                    new String[] {
                        CountInSnapshotColumn.DataPropertyName,
                        CountInCheckColumn.DataPropertyName,
                        dataGridViewTextBoxColumn3.DataPropertyName,
                    dataGridViewTextBoxColumn5.DataPropertyName });
                dataGridViewPagingSumCtrl.Initialize();
                dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
                skinSplitContainer1.Panel2Collapsed = true;
                MenuPermission = RolePermissionMenuEnum.盘点汇总;
                SetState();
                skinComboBoxShop.Initialize();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
          //  baseButtonExport.data
        }

        private void SetState()
        {
            #region 初始化skinComboBox_State
            List<ListItem<CheckStoreState>> listItems = new List<ListItem<CheckStoreState>>();
            listItems.Add(new ListItem<CheckStoreState>(EnumHelper.GetDescription(CheckStoreState.All), CheckStoreState.All));
            listItems.Add(new ListItem<CheckStoreState>(EnumHelper.GetDescription(CheckStoreState.Win), CheckStoreState.Win));
            listItems.Add(new ListItem<CheckStoreState>(EnumHelper.GetDescription(CheckStoreState.Lost), CheckStoreState.Lost));

            this.skinComboBox_State.DisplayMember = "Key";
            this.skinComboBox_State.ValueMember = "Value";
            this.skinComboBox_State.DataSource = listItems;
            #endregion
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }
        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                if (this.pagePara == null)
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                CheckStoreSummaryPage listPage = CommonGlobalCache.ServerProxy.GetCheckStoreSummaryPage(this.pagePara);
                this.BindingCheckStoreSummaryBindingSource(listPage);
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
            this.pagePara = new GetCheckStoreSummaryPagePara()
            {
                StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                //CheckStoreTaskID = this.textBoxTaskId.Text,
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                ShopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShop.SelectedValue),
                State = (CheckStoreState)skinComboBox_State.SelectedValue
            };
            Search();
        }

        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                CheckStoreSummaryPage listPage = CommonGlobalCache.ServerProxy.GetCheckStoreSummaryPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                dataGridViewPagingSumCtrl.Initialize(listPage);
                BindingCheckStoreSummaryBindingSource(listPage);
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
        private void BindingCheckStoreSummaryBindingSource(CheckStoreSummaryPage listPage)
        {
            if (listPage != null && listPage.CheckStoreSummarys != null && listPage.CheckStoreSummarys.Count > 0)
            {
                foreach (CheckStoreSummary order in listPage.CheckStoreSummarys)
                {
                    Costume costume = CommonGlobalCache.CostumeList.Find(t => t.ID == order.CostumeID);
                    if (costume != null)
                    {
                        order.Price = costume.Price;
                        order.CostPrice = costume.CostPrice;
                        order.CostumeName = costume.Name;
                        order.ShopName = CommonGlobalCache.GetShopName(order.ShopID);
                    }
                }
            }
            this.skinSplitContainer1.Panel2Collapsed = true;
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage?.CheckStoreSummarys, null, listPage?.TotalEntityCount, listPage?.CheckStoreSummarySum);
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
        }
        private void CheckStoreSummarySummaryCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }
        private void Initialize()
        {
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.dataGridView1.DataSource = null;
            this.skinSplitContainer1.Panel2Collapsed = true;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView view = sender as DataGridView;
            //if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }

            //try
            //{
            //    if (CommonGlobalUtil.EngineUnconnectioned(this))
            //    {
            //        return;
            //    }

            //    //当前更改的列 
            //    DataGridViewCell cell = view.CurrentCell;
            //    //当前绑定数据
            //    CheckStoreSummary item = cell.OwningRow.DataBoundItem as CheckStoreSummary;
            //    item.WinLostMoney = item.WinLostCount * item.AveragePrice2;
            //    cell.OwningRow.Cells[winLostMoneyDataGridViewTextBoxColumn.Index].Value = item.WinLostMoney;
            //    AveragePrice2AndWinLostMoney bean = new AveragePrice2AndWinLostMoney();
            //    CJBasic.Helpers.ReflectionHelper.CopyProperty(item, bean);
            //    //传时间
            //    CJBasic.Helpers.ReflectionHelper.CopyProperty(pagePara, bean);
            //    UpdateResult result = CommonGlobalCache.ServerProxy.UpdateAveragePrice2AndWinLostMoney(bean);
            //    switch (result)
            //    {
            //        case UpdateResult.Success:
            //            break;
            //        case UpdateResult.Error:
            //            view.CancelEdit();
            //            GlobalMessageBox.Show("内部错误！");
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch (Exception ee)
            //{

            //    CommonGlobalUtil.ShowError(ee);
            //}
            //finally
            //{
            //    CommonGlobalUtil.UnLockPage(this);
            //}
        }
        private void skinComboBoxShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.shopID = ValidateUtil.CheckEmptyValue(skinComboBoxShop.SelectedValue);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

            DataGridView view = sender as DataGridView;
            CheckStoreSummary item = view.Rows[e.RowIndex].DataBoundItem as CheckStoreSummary;
            if (e.ColumnIndex == dataGridViewTextBoxColumn3.Index || e.ColumnIndex == dataGridViewTextBoxColumn5.Index)
            {
                CheckStoreOrderSummaryProfitForm form = new CheckStoreOrderSummaryProfitForm();
                form.ShowDialog(item.CheckStoreOrderIDs, item.CostumeID);
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
        
        private String path;
        private void baseButtonExport_Click(object sender, EventArgs e)
        {
           

        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "盘点汇总" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                List<CheckStoreSummary> unableStore = new List<CheckStoreSummary>();
                List<CheckStoreSummary> stores = new List<CheckStoreSummary>();
                List<CheckStoreSummary> list = (List<CheckStoreSummary>)this.dataGridView1.DataSource;
                System.Collections.SortedList columns = new System.Collections.SortedList();
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }


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
