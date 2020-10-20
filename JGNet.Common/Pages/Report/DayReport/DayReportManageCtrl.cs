using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using JGNet.Core.InteractEntity;
using CCWin;

using JGNet.Common.Core.Util;
using JGNet.Common.Core; 
using JGNet.Common.Components;
using JGNet.Core.Tools;
using JGNet.Common;
using CCWin.SkinControl;
using JGNet.Core.Const;

namespace JGNet.Common
{/// <summary>
/// 日报表
/// </summary>
    public partial class DayReportManageCtrl : BaseUserControl
    {
        private String shopID;

        private DayReportPagePara pagePara;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;


        /// <summary>
        /// 点击补货申请单明细触发
        /// </summary>
        public event CJBasic.Action<DayReport, BaseUserControl> DetailClick;

        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        // public event CJBasic.Action<DayReport> InboundClick;

        public DayReportManageCtrl()
        {
            InitializeComponent();

            MenuPermission =RolePermissionMenuEnum.日结存查询;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, BaseButton_Search_Click, new string[] {
            this.totalRechargeDataGridViewTextBoxColumn.DataPropertyName,
            this.salesInCashDataGridViewTextBoxColumn.DataPropertyName,
            this.quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName,
            this.salesCountDataGridViewTextBoxColumn.DataPropertyName,
            this.refundCountDataGridViewTextBoxColumn.DataPropertyName,
            });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.OrderSearch = Search;
        }

        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
        }
     

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();
          //  DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.dataGridView1.DataSource = null; this.pagePara = new DayReportPagePara(); 
            this.dataGridView1.AutoGenerateColumns = false;
            SetDisplay();
        }

        private void SetDisplay()
        {
           this.skinComboBoxShopID.Initialize( false,false, CommonGlobalCache.BusinessAccount.OnlineEnabled); 
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                pagePara.PageIndex = index;
                DayReportPage listPage = CommonGlobalCache.ServerProxy.GetDayReportPage(this.pagePara);
                this.BindingDayReportSource(listPage);
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
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
                DayReportPage listPage = CommonGlobalCache.ServerProxy.GetDayReportPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                this.BindingDayReportSource(listPage);
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
            this.pagePara = new DayReportPagePara()
            {
                Ascend = false,
                ColumnOrderby = DayReport._ReportDate,
                StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                EndDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                PageIndex = 0,
                PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                ShopID = shopID
            };
            dataGridViewPagingSumCtrl.OrderPara = pagePara;
            Search(null, null);

        }

        /// <summary>
        /// 绑定plenishOrderSource源到dataGridView中
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingDayReportSource(DayReportPage listPage)
        {
            this.dataGridViewPagingSumCtrl.BindingDataSource<DayReport>(listPage?.DayReportList, null, listPage?.TotalEntityCount, listPage?.DayReportSum);
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
                List < DayReport > curDayReportListSource = (List<DayReport>)this.dataGridView1.DataSource;
                DayReport item = curDayReportListSource[e.RowIndex];
                switch (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    case "明细":
                        if (this.DetailClick != null)
                        {
                            this.DetailClick(item,this);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
        }


        #endregion

        private void DayReportManageCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //   row.ReadOnly = true;
            DayReport order = (DayReport)row.DataBoundItem;

            if (shopIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetShopName(order.ShopID);
            }

            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void skinComboBoxShopID_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue);
        }
    }
}
