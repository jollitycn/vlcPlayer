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
using JGNet.Core.Const;
using JGNet.Common.Components;
using JGNet.Common.Core;  
using JGNet.Core.Tools;
using JGNet.Manage.Components;
using System.Drawing.Drawing2D;
using ZedGraph;
using CJBasic;
using JieXi.Common;

namespace JGNet.Common
{
    /// <summary>
    ///导购日业绩
    /// </summary>
    public partial class GuideAchievementSummaryManageCtrl : BaseUserControl
    {
        private String shopID;
        private GuideAchievementSummarysPara pagePara;
        private GuideAchievementsPara pagePara2;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        private DataGridViewRow curRow;

        public event CJBasic.Action<RetailListPagePara, BaseUserControl> DetailClick;

        /// <summary>
        /// 点击收货按钮触发
        /// </summary>
        // public event CJBasic.Action<GuideDayAchievement> InboundClick;

        public GuideAchievementSummaryManageCtrl()
        {
            InitializeComponent();

            this.skinComboBoxShopID.SelectedIndexChanged += SkinComboBoxShopID_SelectedIndexChanged;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, new String[] {
            this.dataGridViewTextBoxColumn45.DataPropertyName,
            this.dataGridViewTextBoxColumn46.DataPropertyName,
            this.dataGridViewTextBoxColumn47.DataPropertyName,
            this.dataGridViewTextBoxColumn48.DataPropertyName,
            this.dataGridViewTextBoxColumn49.DataPropertyName,
            this.SalesActualRecvSum.DataPropertyName,
            this.SalesActualRecvShopSum.DataPropertyName,
            this.dataGridViewTextBoxColumn52.DataPropertyName,
            this.dataGridViewTextBoxColumn53.DataPropertyName,
            this.dataGridViewTextBoxColumn54.DataPropertyName,
            this.dataGridViewTextBoxColumn55.DataPropertyName});
            dataGridViewPagingSumCtrl.Initialize();
            // this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridViewPagingSumCtrl.SelectionChanged = dataGridView1_SelectionChanged;
            dataGridViewPagingSumCtrl.ColumnSorting = dataGridViewPagingSumCtrl_ColumnSorting;
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(this.dataGridView2);
            dataGridViewPagingSumCtrl1.Initialize();
            //  this.dataGridView2.CellFormatting += DataGridView2_CellFormatting;
            this.dataGridViewTextBoxColumn38.DefaultCellStyle.Format = "p2";
            this.dataGridViewTextBoxColumn52.DefaultCellStyle.Format = "p2";
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.skinSplitContainer1.Panel2Collapsed = true;
            this.Initialize();
            MenuPermission = RolePermissionMenuEnum.导购业绩;
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void Initialize()
        {
            List<ListItem<int>> stateList = new List<ListItem<int>>();

            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);

            CommonGlobalUtil.SetTime(skinComboBox_Time);
            this.pagePara = new GuideAchievementSummarysPara();
            this.pagePara2 = new GuideAchievementsPara();
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            //  skinLabel4.Visible = !IsPos;
            this.tabControl1.SelectedTab = tabPage1;
           skinComboBoxShopID.Initialize( false,CommonGlobalCache.IsGeneralStoreRetail!="1");
            skinSplitContainer1.Panel2Collapsed = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }
        private bool isMonth = false;
        private int startDate = 0;
        private int endDate = 0;
        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                if (isMonth) {
                    startDate = TimeHelper.GetReportMonth(this.dateTimePicker_Start.Value);
                    endDate = TimeHelper.GetReportMonth(this.dateTimePicker_End.Value);
                }
                else {
                    startDate = TimeHelper.GetReportDay(this.dateTimePicker_Start.Value);
                    endDate = TimeHelper.GetReportDay(this.dateTimePicker_End.Value);
                }

                this.pagePara = new GuideAchievementSummarysPara()
                {
                    IsMonth = isMonth,
                    StartDate = startDate,
                    EndDate = endDate,
                    //PageIndex = 0,
                    //PageSize = this.pageSize,
                    IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1",
                    ShopID = shopID,
                    GuideID = ValidateUtil.CheckEmptyValue(guideComboBox1.SelectedValue),
                    IsOnlyShowNoZero = this.skinCheckBox_IsOnlyShowNoZero.Checked
                };

                //     List<GuideAchievementSummary>

                GuideAchievementSummarys listPage = CommonGlobalCache.ServerProxy.GetGuideAchievementSummarys(this.pagePara);
                SetDisplay();
                if (listPage != null) {
                    foreach (GuideAchievementSummary item in listPage.List)
                    {
                        item.GuideName = CommonGlobalCache.GetUserName(item.GuideID);
                        item.ShopName = CommonGlobalCache.GetShopName(item.ShopID);
                    }
                }

                dataGridViewPagingSumCtrl.BindingDataSource<GuideAchievementSummary>(DataGridViewUtil.ToDataTable<GuideAchievementSummary>(listPage?.List), null, ListSortDirection.Descending, listPage?.Sum);
                skinSplitContainer1.Panel2Collapsed = true;
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

        private void SearchDetailList(String guideID)
        {
            this.skinSplitContainer1.Panel2Collapsed = false;
            try
            {

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.pagePara2 = new GuideAchievementsPara()
                {
                    ShopID = null,
                    IsMonth = isMonth,
                    StartDate = startDate,
                    EndDate = endDate,
                    GuideID = guideID,
                    IsOnlyShowNoZero = this.skinCheckBox_IsOnlyShowNoZero.Checked,
                    //IsGetGeneralStore = CommonGlobalCache.IsGeneralStoreRetail == "1",
                };

                List<GuideDayAchievement> listPage = CommonGlobalCache.ServerProxy.GetGuideAchievements(this.pagePara2);
                // this.BindingSource(dataGridView2, listPage);
                this.dataGridViewPagingSumCtrl1.BindingDataSource<GuideDayAchievement>(DataGridViewUtil.ToDataTable<GuideDayAchievement>(listPage), dataGridViewTextBoxColumn1);

                this.tabPage2.Invalidate();
                zedGraphControl1.Invalidate();
                CreateChart(zedGraphControl1,pagePara2, listPage);
                //  pictureBox1.Image = GetImage(pagePara2,listPage);

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



        private void CreateChart(ZedGraphControl zgc, GuideAchievementsPara pagePara, List<GuideDayAchievement> list)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.CurveList.Clear();
            myPane.GraphItemList.Clear();
            zgc.AxisChange();
            zgc.Refresh();


            //   zgc.AxisChange();

            // Set the titles and axis labels
            myPane.Title = "导购业绩";
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
                    GuideDayAchievement achievement = list.Find(t => Int32.Parse(t.ReportDate.ToString().Substring(4, 2)) == (i + 1));
                    if (achievement != null)
                    {
                        points[i] = decimal.ToDouble(achievement.MoneyOfSale);
                    }
                }
            }
            else
            {

                //获取月份对应的数量
                if (list!=null &&  list.Count > 0)
                {
                    GuideDayAchievement achievement = list[0];
                    int days = TimeHelper.GetReportMonthMaxDay(achievement.ReportDate);
                    labels = new string[days];
                    points = new double[days];
                    for (int i = 0; i < days; i++)
                    {
                        labels[i] = (i + 1).ToString();
                         achievement = list.Find(t => Int32.Parse(t.ReportDate.ToString().Substring(6, 2)) == (i + 1));
                        if (achievement != null)
                        {
                            points[i] = decimal.ToDouble(achievement.MoneyOfSale);
                        }
                    }
                }
            }


 



            //y轴
            //double[] y = new double[11];
            //decimal maxAccount = 0;
            //foreach (var item in list)
            //{
            //    if (maxAccount < item.MoneyOfSale)
            //    {
            //        maxAccount = item.MoneyOfSale;
            //    }
            //}

            //int step = decimal.ToInt32(Math.Round(maxAccount / 1100) * 100);

            //for (int j = 10; j >= 0; j--)
            //{
            //    y[j] = step * j;
            //}


            // Generate a red bar with "Curve 1" in the legend
            BarItem myBar = myPane.AddBar("销售总额", null, points, Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);

            //// Generate a blue bar with "Curve 2" in the legend
            //myBar = myPane.AddBar("Curve 2", null, y2, Color.Blue);
            //myBar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);

            //// Generate a green bar with "Curve 3" in the legend
            //myBar = myPane.AddBar("Curve 3", null, y3, Color.Green);
            //myBar.Bar.Fill = new Fill(Color.Green, Color.White, Color.Green);

            //// Generate a black line with "Curve 4" in the legend
            //LineItem myCurve = myPane.AddCurve("Curve 4",
            //     null, y4, Color.Black, SymbolType.Circle);
            //myCurve.Line.Fill = new Fill(Color.White, Color.LightSkyBlue, -45F);

            // Fix up the curve attributes a little
            //myCurve.Symbol.Size = 8.0F;
            //myCurve.Symbol.Fill = new Fill(Color.White);
            //myCurve.Line.Width = 2.0F;

            // Draw the X tics between the labels instead of at the labels
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
            this.tabPage2.Invalidate();
            this.Invalidate();
        } 
         

        GuideRetailOrderListForm form = new GuideRetailOrderListForm();

        #region 点击单元格
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                DataGridView view = (DataGridView)sender;

                //List < GuideDayAchievement > curGuideDayAchievementListSource = (List<GuideDayAchievement>)view.DataSource;
                DataTable curGuideDayAchievementListSource =  view.DataSource as DataTable;
              DataRow row=  curGuideDayAchievementListSource.Rows[e.RowIndex];
                //   GuideDayAchievement item = curGuideDayAchievementListSource[e.RowIndex];
                switch (view.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText)
                {
                    case "时间":
                        if (!isMonth)
                        {
                            form.ShowDialog(new GetGuideAchievementDetailsPara()
                            {
                                Date = Int32.Parse( row["ReportDate"].ToString()),
                                GuideID = row["GuideID"].ToString()
                            });
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }


        #endregion

        private void SkinComboBoxShopID_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            shopID = ValidateUtil.CheckEmptyValue(this.skinComboBoxShopID.SelectedValue);
            guideComboBox1.Initialize(Common.GuideComboBoxInitializeType.All, shopID);
        }

        private void GuideDayAchievementSummaryManageCtrl_Load(object sender, EventArgs e)
        {
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow row = view.CurrentRow;
            if (row != null && row.Index != -1 && curRow != row)
            {
                DataRowView summary = (DataRowView)row.DataBoundItem;
                SearchDetailList(summary["GuideID"].ToString());
                curRow = row;
            }
        } 
       

        private void SetDisplay()
        {
            //后台不显示？
           dataGridViewTextBoxColumn38.Visible = (pagePara.ShopID != null);
            dataGridViewTextBoxColumn52.Visible = (pagePara.ShopID != null);
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

        private void skinCheckBox_IsOnlyShowNoZero_CheckedChanged(object sender, EventArgs e)
        {

        }

        private String path;
        private void baseButton2_Click(object sender, EventArgs e)
        {

            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "导购业绩" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
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
                    DataTable list = dataGridView1.DataSource as DataTable; 
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
                    NPOIHelper.ExportExcel(list, path);

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
    }
}
