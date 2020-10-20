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

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class DayBrandBenefitReportManageCtrl : BaseUserControl
    {
        private DataGridViewRow currRow;
        private BrandBenefitDayReportsPara pagePara1;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private string shopID;

        /// <summary>
        /// 点击补货单明细触发
        /// </summary>
        public event ESBasic.Action<BrandBenefitDayReportsPara, Panel, BaseUserControl> DetailClick;
      
        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
       // public event ESBasic.Action<BrandBenefitDayReport> InboundClick;

        public DayBrandBenefitReportManageCtrl()
        {
            InitializeComponent();

            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new string[] {
               quantityOfSaleDataGridViewTextBoxColumn.DataPropertyName,
               quantityOfRefundDataGridViewTextBoxColumn.DataPropertyName,
           salesTotalMoneyDataGridViewTextBoxColumn.DataPropertyName,
             salesTotalPriceDataGridViewTextBoxColumn.DataPropertyName,
                salesTotalCostDataGridViewTextBoxColumn.DataPropertyName,
              salesBenefitDataGridViewTextBoxColumn.DataPropertyName
});
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView1_SelectionChanged;
            this.dataGridView1.AutoGenerateColumns = false; 
        }

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();

            CommonGlobalUtil.SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.pagePara1 = new BrandBenefitDayReportsPara(); 
            this.dataGridView1.DataSource = null;

            this.skinSplitContainer1.Panel2Collapsed = true;
            CommonGlobalUtil.SetShop(skinComboBox_Brand);
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            if (IsPos) {
                skinComboBox_Brand.Enabled = false;
                skinComboBox_Brand.SelectedValue = CommonGlobalCache.CurrentShopID;
            }
        }  


        private void SearchDetailList(DataRowView report)
        {//20180518
            if (this.DetailClick != null)
            {
                this.skinSplitContainer1.Panel2Collapsed = false;
                this.DetailClick?.Invoke(
                    new BrandBenefitDayReportsPara()
                    { 
                        BrandName = report["BrandName"].ToString(),
                        IsPos = IsPos,
                        ShopID = null,
                        StartReportDate = int.Parse(this.dateTimePicker_Start.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_DATE_FORMAT)),
                        EndReportDate = int.Parse(this.dateTimePicker_End.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_DATE_FORMAT)),
                    }, this.skinSplitContainer1.Panel2, this);
            }
        }

        /// <summary>
        /// 绑定plenishOrderSource源到dataGridView中
        /// </summary>
        /// <param name="listPage"></param>
        private void BindingSource(DataGridView view, List<BrandBenefitDayReport> listPage)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
            if (listPage != null)
            {

                foreach (var item in listPage)
                {
                    item.RefundRate = Math.Abs(item.RefundRate);
                    item.QuantityOfRefund = Math.Abs(item.QuantityOfRefund);
                }
                 
                this.dataGridViewPagingSumCtrl.BindingDataSource(DataGridViewUtil.ToDataTable<BrandBenefitDayReport>(listPage), salesBenefitDataGridViewTextBoxColumn, ListSortDirection.Descending);
            }
            else
            {
                view.DataSource = null;
            }
        }
         


         

        private void DayBrandBenefitReportManageCtrl_Load(object sender, EventArgs e)
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
            if (row != null && row.Index!=-1 && row != currRow)
            {
                if (String.IsNullOrEmpty(shopID))
                {
                    //   BrandBenefitDayReport summary = (BrandBenefitDayReport)row.DataBoundItem;
                    DataRowView summary = (DataRowView)row.DataBoundItem;
                    SearchDetailList(summary);
                    currRow = row;
                }
                else {
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

                this.pagePara1 = new BrandBenefitDayReportsPara()
                { 
                 //   BrandName = (int)this.skinComboBox_Brand.SelectedValue == -1 ? String.Empty : (this.skinComboBox_Brand.SelectedItem as Brand).Name ,
                    IsPos = IsPos,
                    StartReportDate = int.Parse(this.dateTimePicker_Start.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_DATE_FORMAT)),
                    EndReportDate = int.Parse(this.dateTimePicker_End.Value.ToString(CommonGlobalUtil.DEFAULT_SHORT_DATE_FORMAT)),
                       ShopID =!String.IsNullOrEmpty(shopID)? shopID : SystemDefault.Report_Summary
                };
                List<BrandBenefitDayReport> listPage = CommonGlobalCache.ServerProxy.GetBrandBenefitDayReports(this.pagePara1);
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
            shopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_Brand.SelectedValue);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
