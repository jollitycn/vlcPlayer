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
using JGNet.Manage;
using JGNet.Core.Tools;
using CJBasic.Helpers;
using JGNet.Manage.Components;
using ZedGraph;
using TimeHelper = JGNet.Core.Tools.TimeHelper;

namespace JGNet.Common
{/// <summary>
/// 营业日报
/// </summary>
    public partial class BenefitReportDetailListCtrl : BaseModifyUserControl
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private GetBenefitReportsPara para; 

        /// <summary>
        /// 点击补货申请单明细触发
        /// </summary>
        public event CJBasic.Action<RetailListPagePara, BaseUserControl> DetailClick;
       
        public event CJBasic.Action<DayBenefitReportDetailPara, BaseUserControl> SaleDetailClick;

        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        // public event CJBasic.Action<DayBenefitReport> InboundClick;

        public BenefitReportDetailListCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.OrderSearch += Search;

            this.dataGridView1.AutoGenerateColumns = false;
            this.Initialize();
            MenuPermission = RolePermissionMenuEnum.店铺营业报表;
        }

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();
            this.dataGridView1.DataSource = null;
            this.tabControl1.SelectedTab = tabPage1;
            
            //if (!HasPermission( RolePermissionEnum.查看_销售成本))
            //{
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(salesTotalCostDataGridViewTextBoxColumn);

            //}
            //if (!HasPermission(RolePermissionEnum.查看_毛利 ))
            //{
            //    dataGridViewPagingSumCtrl.AppendNotShowInColumnSettings(SalesBenefit);
            //} 
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void Search(object sender, EventArgs args)
        {
            List<DayBenefitReport> listPage = null;
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                listPage = CommonGlobalCache.ServerProxy.GetBenefitReports(para);
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
                this.BindingSource(dataGridView1, listPage);
               CreateChart(zedGraphControl1, para, listPage);
                UnLockPage();
            }
        }
        public void SearchDetailList(GetBenefitReportsPara para)
        { 
            this.para = para;
            this.para.IsShowNotZero = skinCheckBox_IsOnlyShowNoZero.Checked;
            Search(null, null);
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="view"></param>
        /// <param name="dayBenefitReportList"></param>
        private void BindingSource(DataGridView view, List<DayBenefitReport> dayBenefitReportList)
        {
            if (dayBenefitReportList != null)
            {
                foreach (var item in dayBenefitReportList)
                {
                    item.ShopName = CommonGlobalCache.GetShopName(item.ShopID);
                    item.RefundRate = Math.Abs(item.RefundRate);
                    item.QuantityOfRefund = Math.Abs(item.QuantityOfRefund);
                }
            }
            dataGridViewPagingSumCtrl.BindingDataSource< DayBenefitReport>(DataGridViewUtil.ToDataTable(dayBenefitReportList));
        }


        private void DayBenefitReportDetailListCtrl_Load(object sender, EventArgs e)
        {
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                DataGridView view = (DataGridView)sender;
             //  List<DayBenefitReport> curDayBenefitReportListSource = (List<DayBenefitReport>)view.DataSource;
              //  DayBenefitReport item = curDayBenefitReportListSource[e.RowIndex];
                
                DataRowView item = (DataRowView)view.Rows[e.RowIndex].DataBoundItem;
                 
                switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                { 
                    case "明细":
                        if (!para.IsMonth)
                        {
                            form.ShowDialog(new DayBenefitReportDetailPara()
                            {
                                StartDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item["ReportDate"].ToString()),
                                EndDate = JGNet.Core.Tools.TimeHelper.GetReportDate(item["ReportDate"].ToString()),
                                ShopID = item["ShopID"].ToString() == SystemDefault.Report_Summary ? null : item["ShopID"].ToString(),
                            });
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        BenefitReportSailDetailListForm form = new BenefitReportSailDetailListForm();
        private void skinCheckBox_IsOnlyShowNoZero_CheckedChanged(object sender, EventArgs e)
        {
            SearchDetailList(this.para);
        }

        private void CreateChart(ZedGraphControl zgc, GetBenefitReportsPara pagePara, List<DayBenefitReport> list)
        {
            GraphPane myPane = zgc.GraphPane;
            if (myPane == null) { return; }
            myPane?.CurveList?.Clear();
            myPane?.GraphItemList?.Clear();
            zgc.AxisChange();
            zgc.Refresh();


            //   zgc.AxisChange();

            // Set the titles and axis labels
            myPane.Title = "营业报表";
            myPane.XAxis.Title = "时间";
            myPane.YAxis.Title = "销售额";

            // Make up some random data points
            //   string[] labels = { "Panther", "Lion", "Cheetah", "Cougar", "Tiger", "Leopard" };


            String[] labels = null;
            double[] points = null;
            if (pagePara.IsMonth)
            {
                labels = new string[12];
                points = new double[12];
                for (int i = 0; i <= 11; i++)
                {
                    labels[i] = (i + 1).ToString();
                    DayBenefitReport achievement = list.Find(t => Int32.Parse(t.ReportDate.ToString().Substring(4, 2)) == (i + 1));
                    if (achievement != null)
                    {
                        points[i] = decimal.ToDouble(achievement.SalesTotalMoney);
                    }
                }
            }
            else
            {

                //获取月份对应的数量
                if (list.Count > 0)
                {
                    DayBenefitReport achievement = list[0];
                    int days = TimeHelper.GetReportMonthMaxDay(achievement.ReportDate);
                    labels = new string[days];
                    points = new double[days];
                    for (int i = 0; i < days; i++)
                    {
                        labels[i] = (i + 1).ToString();
                        achievement = list.Find(t => Int32.Parse(t.ReportDate.ToString().Substring(6, 2)) == (i + 1));
                        if (achievement != null)
                        {
                            points[i] = decimal.ToDouble(achievement.SalesTotalMoney);
                        }
                    }
                }
            } 

            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("销售总额", null, points, Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue); 
            myPane.XAxis.IsTicsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.TextLabels = labels;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the axis area with a gradient
            myPane.AxisFill = new Fill(Color.White,
                 Color.FromArgb(255, 255, 166), 90F);
            // Fill the pane area with a solid color
            myPane.PaneFill = new Fill(Color.FromArgb(250, 250, 255));

            zgc.AxisChange();
            zgc.Invalidate();
         //   this.skinTabPage2.Invalidate();
          //  this.Invalidate();
        }

    }
}
