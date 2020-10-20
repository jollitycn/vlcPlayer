using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core.Util;
using JGNet.Common.Core; 
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Core.Tools;
using JieXi.Common;
using CJBasic;

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class BenefitReportManageCtrl : BaseUserControl
    {
        private DataGridViewRow currRow;
        private GetShopBenefitReportsPara pagePara1;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        /// <summary>
        ///  详情页
        /// </summary>
        public event CJBasic.Action<GetBenefitReportsPara, Panel, BaseUserControl> DetailClick;

        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        // public event CJBasic.Action<DayBenefitReport> InboundClick;

        public BenefitReportManageCtrl()
        {
            InitializeComponent();
            MenuPermission =RolePermissionMenuEnum.店铺营业报表;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView1_SelectionChanged;
            dataGridViewPagingSumCtrl.OrderSearch += Search;
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            this.dataGridView1.AutoGenerateColumns = false;
            IsPos =  HasPermission(RolePermissionEnum.查看_只看本店);
        }

        private new bool IsPos = false;

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();

            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            CommonGlobalUtil.SetTime(skinComboBox_Time);
            this.pagePara1 = new GetShopBenefitReportsPara();
            this.dataGridViewPagingSumCtrl.SetDataSource<DayBenefitReport>(null);
            this.skinSplitContainer1.Panel2Collapsed = true; 
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        } 

        private void SearchDetailList(DataRowView report)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            GetBenefitReportsPara para = new GetBenefitReportsPara()
            {
                IsMonth = isMonth,
                StartDate = startDate,
                EndDate = endDate,
                ShopID = report["ShopID"].ToString(),
                IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1"
            };
            this.DetailClick?.Invoke(para, this.skinSplitContainer1.Panel2, this);
        }

        /// <summary>
        /// 绑定plenishOrderSource源到dataGridView中
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingSource(  List<DayBenefitReport> listPage)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;

            if (listPage != null)
            {
                foreach (var item in listPage)
                {
                    item.RefundRate = Math.Abs(item.RefundRate);
                    item.QuantityOfRefund = Math.Abs(item.QuantityOfRefund);
                }
            }
            this.dataGridViewPagingSumCtrl.BindingDataSource<DayBenefitReport>(DataGridViewUtil.ToDataTable(listPage));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRowView report = (DataRowView)row.DataBoundItem; 
                if ("总计".Equals(report["ShopName"].ToString()))
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
            }
        }

        private void DayBenefitReportManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        /// <summary>
        /// 变更行、单元格触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            ///不重复提交
            if (row != null && row.Index != -1 && row != currRow)
            { 

                DataRowView report = (DataRowView)row.DataBoundItem;
                SearchDetailList(report);
                currRow = row;
            }
        }

        private void Search(object sender, EventArgs args)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                List<DayBenefitReport> listPage = CommonGlobalCache.ServerProxy.GetShopBenefitReports(this.pagePara1); 
                this.BindingSource(listPage);
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

        private bool isMonth = false;
        private int startDate = 0;
        private int endDate = 0;
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            if (isMonth)
            {
                startDate = TimeHelper.GetReportMonth(this.dateTimePicker_Start.Value);
                endDate = TimeHelper.GetReportMonth(this.dateTimePicker_End.Value);
            }
            else
            {
                startDate = TimeHelper.GetReportDay(this.dateTimePicker_Start.Value);
                endDate = TimeHelper.GetReportDay(this.dateTimePicker_End.Value);
            }

            this.pagePara1 = new GetShopBenefitReportsPara()
            {
                IsPos = IsPos,
                StartDate = startDate,
                EndDate = endDate,
                IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1",
                ShopID = IsPos ? CommonGlobalCache.CurrentShopID : null
            };
            Search(null, null);
        } 

        private void skinComboBox_Time_SelectedIndexChanged(object sender, EventArgs e)
        {
            isMonth = false;
            QuickDateSelectorEnum enumValue = (QuickDateSelectorEnum)skinComboBox_Time.SelectedValue;
            switch (enumValue)
            {
                case QuickDateSelectorEnum.YESTODAY:
                    DateTimeUtil.DateTimePicker_Yestoday(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.TODAY:
                    DateTimeUtil.DateTimePicker_Today(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.THISWEEK:
                    DateTimeUtil.DateTimePicker_ThisWeek(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.LASTWEEK:
                    DateTimeUtil.DateTimePicker_LastWeek(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.THISMONTH:
                    DateTimeUtil.DateTimePicker_ThisMonth(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.LASTMONTH:
                    DateTimeUtil.DateTimePicker_LastMonth(this.dateTimePicker_Start, this.dateTimePicker_End);
                    break;
                case QuickDateSelectorEnum.THISYEAR:
                    DateTimeUtil.DateTimePicker_ThisYear(this.dateTimePicker_Start, this.dateTimePicker_End);
                    isMonth = true;
                    break;
                case QuickDateSelectorEnum.LASTYEAR:
                    DateTimeUtil.DateTimePicker_LastYear(this.dateTimePicker_Start, this.dateTimePicker_End);
                    isMonth = true;
                    break;
                case QuickDateSelectorEnum.ALL:
                    DateTimeUtil.DateTimePicker_All(this.dateTimePicker_Start, this.dateTimePicker_End);
                    isMonth = true;
                    break;
                default:
                    break;
            }
        }

        private String path;
        private void baseButton2_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "店铺营业报表" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                if (dataGridView1.DataSource != null && dataGridView1.Rows.Count > 0)
                {
                    DataTable dt=  this.dataGridView1.DataSource as DataTable;
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
                    NPOIHelper.ExportExcel( dt, path);

                    GlobalMessageBox.Show("导出完毕！");
                }
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //quantityOfSaleDataGridViewTextBoxColumn
            //if (e.ColumnIndex == QuantityOfRefund.Index )
            //{
            //     CostumeRetailAnalysisDetailForm form = new CostumeRetailAnalysisDetailForm();
            //    form.getData();
            //}
        }
    }
}
