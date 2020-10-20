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
using JGNet.Common.Core; using JGNet.Common;
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Core.Tools;
using ESBasic.Helpers;

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class MonthBrandBenefitReportManageCtrl : BaseUserControl
    {
        private DataGridViewRow currRow;
        private BrandBenefitMonthReportsPara pagePara1;
        private string shopID;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        /// <summary>
        /// 点击补货单明细触发
        /// </summary>
        public event ESBasic.Action<BrandBenefitMonthReportsPara, Panel, BaseUserControl> DetailClick;
       
        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
       // public event ESBasic.Action<BrandBenefitMonthReport> InboundClick;

        public MonthBrandBenefitReportManageCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, new string[] {
                 quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName,
               quantityOfRefundDataGridViewTextBoxColumn.DataPropertyName,
           salesTotalMoneyDataGridViewTextBoxColumn.DataPropertyName,
             salesTotalPriceDataGridViewTextBoxColumn.DataPropertyName,
                salesTotalCostDataGridViewTextBoxColumn.DataPropertyName });
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView1_SelectionChanged;
          
        }

        private void Initialize()
        {
            isInitialized = false;
            List<ListItem<int>> stateList = new List<ListItem<int>>();
        
            CommonGlobalUtil.SetStartEndForMonth(dateTimePicker_Start, dateTimePicker_End);
            this.pagePara1 = new BrandBenefitMonthReportsPara();
            this.dataGridView1.DataSource = null;
            CommonGlobalUtil.SetShop(skinComboBox_Shop);
            this.skinSplitContainer1.Panel2Collapsed = true;
            if (IsPos)
            {
                skinComboBox_Shop.Enabled = false;
                skinComboBox_Shop.SelectedValue = CommonGlobalCache.CurrentShopID;
            }
        }


        private void SearchDetailList(DataRowView report)
        {//20180518
            if (this.DetailClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.DetailClick?.Invoke(
                    new BrandBenefitMonthReportsPara()
                    {
                        BrandName = report["BrandName"].ToString(),
                        IsPos = IsPos, 
                        ShopID = null,
                        StartReportMonth = int.Parse(this.dateTimePicker_Start.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_MONTH_FORMAT)),
                        EndReportMonth = int.Parse(this.dateTimePicker_End.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_MONTH_FORMAT)),
                    }, this.skinSplitContainer1.Panel2, this);
            }
        }

        /// <summary>
        /// 绑定plenishOrderSource源到dataGridView中
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingSource(DataGridView view, List<BrandBenefitMonthReport> details)
        {
            view.DataSource = null;
            this.skinSplitContainer1.Panel2Collapsed = true;
            if (details != null)
            {
                foreach (var item in details)
                {
                    item.RefundRate = Math.Abs(item.RefundRate);
                    item.QuantityOfRefund = Math.Abs(item.QuantityOfRefund);
                }
            } 
            dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ToDataTable<BrandBenefitMonthReport>(details), SalesBenefit, ListSortDirection.Descending);
           
        }
         


         

        private void BrandBenefitMonthReportManageCtrl_Load(object sender, EventArgs e)
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
            if (row != null && row != currRow)
            {
                if (String.IsNullOrEmpty(shopID))
                {
                    DataRowView summary = (DataRowView)row.DataBoundItem; 
                    SearchDetailList(summary);

                    currRow = row;
                }
                else
                {
                    this.skinSplitContainer1.Panel2Collapsed = true;
                } 
            }
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                this.pagePara1 = new BrandBenefitMonthReportsPara()
                {
                    //BrandName = (int)this.skinComboBox_Brand.SelectedValue == -1 ? String.Empty : (this.skinComboBox_Brand.SelectedItem as Brand).Name,
                    IsPos = IsPos,
                    StartReportMonth = int.Parse(this.dateTimePicker_Start.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_MONTH_FORMAT)),
                    EndReportMonth = int.Parse(this.dateTimePicker_End.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_MONTH_FORMAT)),
                    ShopID = !String.IsNullOrEmpty(shopID) ? shopID : SystemDefault.Report_Summary
                };
                List<BrandBenefitMonthReport> listPage = CommonGlobalCache.ServerProxy.GetBrandBenefitMonthReports(this.pagePara1);
               
                this.BindingSource(this.dataGridView1, listPage); 
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }
         

        private void skinComboBox_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_Shop.SelectedValue);
        }

        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool isInitialized;
        private void MonthBrandBenefitReportManageCtrl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !isInitialized)
            {
                dateTimePicker_End.Initialize();
                dateTimePicker_Start.Initialize();
                skinComboBox_Shop.Focus();
                isInitialized = true;
            }
        }
    }
}
