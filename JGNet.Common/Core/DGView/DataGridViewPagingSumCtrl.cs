using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CJBasic.Widget;
using JGNet.Common.Core.Util;
using CJBasic;
using System.Collections;
using JGNet.Common.Core;
using JGNet.Common;
using CJBasic.Helpers;
using JGNet.Core.InteractEntity;
using static System.Windows.Forms.DataGridView;
using System.Reflection;
using JGNet.Core.Const;
using JGNet.Common.Core.Helpers;
using JGNet.Core;

namespace JGNet.Common.Components
{
    public enum DataGridViewAutoIndexMode
    {
        NewColumn = 1,
        RowHeader = 0,
        None = 2
    }


    public partial class DataGridViewPagingSumCtrl : UserControl
    {


        private bool isAutoResizeColumns = true;
        /// <summary>
        /// 是否自动撑满列宽
        /// </summary>
        public bool IsAutoResizeColumns
        {
            get { return isAutoResizeColumns; }
            set
            {
                isAutoResizeColumns = value;
            }
        }


        public bool Debug { get; set; }

        public bool HideSummaryRowHeader { get; set; }

        /// <summary>
        /// 是否根据系统配置显示0的值，true
        /// </summary>
        private bool showZeroFormatting = true;
        public bool ShowZeroFormatting
        {
            get { return showZeroFormatting; }
            set
            {
                showZeroFormatting = value;
            }
        }

        private bool ReportShowZero = CommonGlobalUtil.OptionIsReportShowZero();
        ///// <summary>
        ///// 切换列头的列名
        ///// </summary>
        ///// <param name="group"></param>
        //public void ChangeSizeGroup(SizeGroup group)
        //{
        //    if (dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible)
        //    {
        //        this.dataGridViewContextMenuStrip1.ChangeSizeGroup(group);
        //    }
        //}

        public static String[] GetColumnDataPropertyNames(List<DataGridViewColumn> columns)
        {
            List<String> columnDataPropertyNames = new List<String>();
            if (columns == null || columns.Count == 0)
            {
                return null;
            }
            foreach (DataGridViewColumn item in columns)
            {
                columnDataPropertyNames.Add(item.DataPropertyName);
            }

            return columnDataPropertyNames.ToArray();
        }
        private bool isShowCostumeColumn = true;
        public bool IsShowCostumeColumn
        {
            get { return isShowCostumeColumn; }
            set { isShowCostumeColumn = value; }
        }
        private bool showColumnSetting = true;
        public bool ShowColumnSetting
        {
            get
            {
                return showColumnSetting;
            }
            set
            {
                showColumnSetting = value;
                SetMenuStrip();
            }
        }

        /// <summary>
        /// 需要分页的
        /// </summary>
        /// <param name="view"></param>
        /// <param name="calculateColumns"></param>
        /// <param name="CurrentPageIndexChanged"></param>
        /// <param name="PageSizeChange"></param>
        /// <param name="pagePara">排序的时候使用</param>
        public DataGridViewPagingSumCtrl(DataGridView view, CbGeneric<int> CurrentPageIndexChanged, CbGeneric<object, EventArgs> PageSizeChange, string[] calculateColumns = null)
        {
            InitializeComponent();
            this.dataGridView = view;
            this.dataGridView.Tag = this;
            this.isPaging = true;
            summaryControlContainer1.DGV = view;
            summaryControlContainer2.DGV = view;
            ColumnDataPropertyNames = calculateColumns;
            this.CurrentPageIndexChanged = CurrentPageIndexChanged;
            //   Initialize();
            baseControl = CommonGlobalUtil.FindBaseControl(view, typeof(BaseForm), typeof(BaseUserControl), typeof(UserControl), typeof(Form));
        }

        ///没有分页的
        public DataGridViewPagingSumCtrl(DataGridView view, string[] calculateColumns = null)
        {
            InitializeComponent();
            this.dataGridView = view;
            this.dataGridView.Tag = this;
            summaryControlContainer1.DGV = view;
            summaryControlContainer2.DGV = view;
            ColumnDataPropertyNames = calculateColumns;
            this.isPaging = false;
            baseControl = CommonGlobalUtil.FindBaseControl(view, typeof(BaseForm), typeof(BaseUserControl), typeof(UserControl), typeof(Form));
        } 

        private bool panelTop = true;
        public bool PanelTop
        {
            get { return panelTop; }
            set
            {
                panelTop = value;
            }
        }

        public Boolean IsCostumeSizeMenuVisible
        {
            get
            {
                return dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible;
            }
            set
            {
                dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible = value;
            }
        }


        private void SetMenuStrip()
        {
            dataGridViewContextMenuStrip1.Debug = this.Debug;
            try
            {
                if (!CheckCostumeSizeColumns())
                {
                    dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible = false;
                    dataGridViewContextMenuStrip1.Items.Clear();
                }
                else
                {
                    if (showColumnSetting)
                    {
                        dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible = true;
                    }
                    else
                    {

                        dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible = false;
                    }
                }

                dataGridViewContextMenuStrip1.DataGridView = dataGridView;
                if (ShowColumnSetting)
                {

                    dataGridViewContextMenuStrip1.Items.Remove(字段显示ToolStripMenuItem);
                    if (baseControl.ToString() != "JGNet.Manage.GetPurchaseSummaryCtrl" && baseControl.ToString() != "JGNet.Common.CostumeRetailAnalysisCtrl"
                        && baseControl.ToString() != "JGNet.Common.PfCostumeRetailAnalysisCtrl")
                    {
                       // this.字段显示ToolStripMenuItem.Visible = false;
                        dataGridViewContextMenuStrip1.Items.Insert(0, 字段显示ToolStripMenuItem);
                    }

                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private bool CheckCostumeSizeColumns()
        {
            bool hasCostumeSizeColumn = false;
            if (dataGridView.Columns != null)
            {
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (CommonGlobalUtil.IsCostumeSizeColumn(item))
                    {

                        hasCostumeSizeColumn = true;
                        break;
                    }
                }
            }

            return hasCostumeSizeColumn;
        }



        private void SetCostumeSizeColumnSpecical()
        {
            if (dataGridView.Columns != null)
            {
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (CommonGlobalUtil.IsCostumeSizeColumn(item))
                    {
                        // item.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                        //item.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        //   item.Width = 50;
                        item.Resizable = DataGridViewTriState.True;
                        // SpecSizeGroupColumns(item);
                    }
                }
            }
        }

        private Boolean isColumnFirstConfig;
        private bool isPageSet=false;
        public bool IsPageSet
        {
            get { return isPageSet; }
            set { IsPageSet = value; }
        }
        int GdWidth = 0;
        private void LoadColumnsConfig()
        {
            configColumns = ColumnSettingsConfiguration.Load(GetConfigPath()) as ColumnSettingsConfiguration;
            string Str = "";
            if (configColumns == null)
            {
                isColumnFirstConfig = true;
                configColumns = new ColumnSettingsConfiguration();
                configColumns.Columns = DataGridViewColumnsForm.GetColumnSettings(dataGridView, NotShowInColumnSettings);
            }
            else
            {
                isPageSet = true;

            }

            if (configColumns.Columns == null || configColumns.Columns.Count == 0)
            {
                CommonGlobalUtil.WriteLog("没有读取配置文件的ConfigColumns");
                configColumns.Columns = DataGridViewColumnsForm.GetColumnSettings(dataGridView, NotShowInColumnSettings);
            }
            else
            {
                List<ColumnSetting> listCol = configColumns.Columns;
                CommonGlobalUtil.WriteLog("\r\n配置信息：");
                foreach (ColumnSetting ColCur in listCol)
                {
                    CommonGlobalUtil.WriteLog("ColumnText=" + ColCur.HeaderText + "\rVisible=" + ColCur.Visible + "\r");
                }
            }
              
            //加载并设置 
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                ColumnSetting setting = configColumns.Columns.Find(t => t.HeaderText == item.HeaderText);
                if (setting != null && setting.Enabled)
                {
                    item.Visible = setting.Visible;  
                }
            }

           

        }
        private void LoadConfig()
        {

            config = ColumnSettingsConfiguration.Load(GetConfigWidthPath()) as ColumnSettingsConfiguration;

          
            string Str = "";
            if (config == null)
            {
                isColumnFirstConfig = true;
                config = new ColumnSettingsConfiguration();
                config.Columns = DataGridViewColumnsForm.GetColumnSettings(dataGridView, NotShowInColumnSettings);
            }
            else
            {
                isPageSet = true;

            }

          /*  if (config.Columns == null || config.Columns.Count == 0)
            {
              //  CommonGlobalUtil.WriteLog("没有读取配置文件的ConfigColumns");
                config.Columns = DataGridViewColumnsForm.GetColumnSettings(dataGridView, NotShowInColumnSettings);
            }
            else
            {
                List<ColumnSetting> listCol = config.Columns;
                //CommonGlobalUtil.WriteLog("\r\n配置信息：");
                //foreach (ColumnSetting ColCur in listCol)
                //{
                //    CommonGlobalUtil.WriteLog("ColumnText="+ColCur.HeaderText+"\rVisible="+ColCur.Visible+"\r");
                //}
            }*/

            //this.dataGridView.ScrollBars = ScrollBars.Horizontal;
            CommonGlobalUtil.WriteLog("DataGridView宽度="+this.dataGridView.Width+"\r\n"+ "表格AutoSizeColumnsMode样式=" + dataGridView.AutoSizeColumnsMode);
            //加载并设置
            int i = 0;
            //this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            bool hasRows = dataGridView.Rows.Count > 0 ? true : false;
           
            foreach (DataGridViewColumn item in dataGridView.Columns)
            { 
                ColumnSetting setting = config.Columns.Find(t => t.HeaderText == item.HeaderText);
                if (setting != null && setting.Enabled)
                {
                    item.Visible = setting.Visible;
                    //  item.Width = setting.Width;
                    //  item.HeaderText = getSpaceStr(item.HeaderText, setting.ColWidth);
                  
                        item.Width = setting.ColWidth;
                   
                    
                   /* if (this.dataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.None)
                    {*/
                   //     dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                   // }
                  //  this.dataGridView.Columns[item.Index].Width= setting.ColWidth;
                    /*item.MinimumWidth = setting.Width;
                   if (item.HeaderText.Contains("打印条码") || item.HeaderText.Contains("编辑")|| item.HeaderText.Contains("删除") || item.HeaderText.Contains("打印")) {
                        dataGridView.AutoResizeColumn(i);
                    }
                    else
                    {
                        dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                    }*/

                    //  dataGridView.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                    // item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    GdWidth += item.Width;
                    /* if (setting.ColWidth < 2) { item.MinimumWidth = setting.Width; }
                     else
                     {
                         item.MinimumWidth = setting.ColWidth;
                     }*/
                    //
                /*    if (hasRows)
                    {
                        getSpaceStr(dataGridView.Rows[0].Cells[item.Name].ToString(), item.Width);
                    }
                    else
                    {

                    }*/


                    Str +=item.HeaderText + "Width=" + item.Width+ "\r AutoSizeMode=" + item.AutoSizeMode+ "\r MinimumWidth=" + item.MinimumWidth+"\r\n";
                    i++;
                }
            }

            this.dataGridView.ScrollBars = ScrollBars.Both;
            if (GdWidth > this.dataGridView.Width)
            {
                /*dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;*/
              /*  dataGridView.Columns[dataGridView.Columns.Count - 1].MinimumWidth = GdWidth - this.dataGridView.Width;*/
            }
            //else
            //{
            //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}

            // dataGridView.Columns[dataGridView.Columns.Count-1].Frozen = true;

            CommonGlobalUtil.WriteLog("DataGridView总宽度GdWidth=" + GdWidth+"详细："+ Str);
        }
        private string getSpaceStr(string TextStr,int width)
        {
            string resultStr = string.Empty;
            int spaceNum = (width - TextStr.Length) / 2;
            resultStr = getSpace(spaceNum) + TextStr + getSpace(spaceNum);
            return resultStr;
        }
        private string getSpace(int len)
        {
            string Str = string.Empty;
            for (int i = 0; i < len; i++)
            {
                Str += " ";
            }
            return Str;
        }
        private String GetConfigPath()
        {
            String configPath = string.Empty;
            configPath = CommonGlobalUtil.AgileConfiguration("Manage//"  + "ColumnSettings//" + baseControl.GetType() + "_" + this.dataGridView.Name);

            CommonGlobalUtil.WriteLog("页面控件："+ baseControl.GetType());
            return configPath;
        }
        private String GetConfigWidthPath()
        {
            String configPath = string.Empty;
            configPath = CommonGlobalUtil.AgileConfiguration("Manage//" + "ColumnWidthSettings//" + baseControl.GetType() + "_" + this.dataGridView.Name);

            CommonGlobalUtil.WriteLog("页面控件：" + baseControl.GetType());
            return configPath;
        }

        ColumnSettingsConfiguration config = null;
        public DataGridView DataGridView { get { return dataGridView; } }
        ColumnSettingsConfiguration configColumns = null;
        public void SetDataSource<T>(IList<T> list,bool isDisplay=true,bool DistinguishSize=true) where T : new()
        {
            DisableEvents();
            DisableColumnsResizeEvent();

            this.dataGridView.DataSource = null;
            // this.dataGridView.Refresh();

            SetColumnsResizeEvent();
            if (list != null && list.Count > 0)
            {
                DataSource = list;
            }

            ClearSummary();
            if (ColumnDataPropertyNames != null)
            {
                List<T> calList = new List<T>();
                DataGridViewHelper.AddSumRow1(dataGridView, list, calList, ColumnDataPropertyNames, abs4Column, isDisplay,DistinguishSize);
                ShowSummary(dataGridView, calList, ColumnDataPropertyNames);
            }

            EnableEvents();
        }

        public void RemoveNotShowInColumnSettings(params DataGridViewColumn[] columns)
        {
            if (NotShowInColumnSettings != null)
            {
                foreach (var item in columns)
                {
                    if (NotShowInColumnSettings.Contains(item))
                    {
                        NotShowInColumnSettings.Remove(item);
                    }
                    item.Visible = true;
                }
            }
            SetStyle();
        }

        public void AppendNotShowInColumnSettings(params DataGridViewColumn[] columns)
        {
            if (NotShowInColumnSettings != null)
            {
                foreach (var item in columns)
                {
                    if (!NotShowInColumnSettings.Contains(item))
                    {
                        NotShowInColumnSettings.Add(item);
                    }
                    item.Visible = false;
                }
            }
            SetStyle();
        }

        /// <summary>
        /// 返回菜单组件
        /// </summary>
        public ContextMenuStrip InnerContextMenuStrip
        {
            get
            {
                return this.contextMenuStripDataGridViewH;
            }
        }

        public DataGridViewContextMenuStrip ToolContextMenuStrip
        {
            get
            {
                return this.dataGridViewContextMenuStrip1;
            }
        }

        private List<DataGridViewColumn> notShowInColumnSettings = new List<DataGridViewColumn>();
        private List<DataGridViewColumn> NotShowInColumnSettings
        {
            get { return notShowInColumnSettings; }
            set { notShowInColumnSettings = value; }
        }


        /// <summary>
        /// 初始化之前设置
        /// </summary>
        /// <param name="columns"></param>
        private void SetNotShowInColumnSettings(params DataGridViewColumn[] columns)
        {
            NotShowInColumnSettings = new List<DataGridViewColumn>(columns);
        }

        public CJBasic.Action<String, bool> ColumnSorting;
        /// <summary>
        /// 检查是否显示统计信息，默认不显示
        /// </summary>
      //  private Boolean showSummaryRows = false;
        private const string NEW_COLUMN_NAME_DATETIME_TO_STR = "_DATETIME_TO_STR";

        private bool showRowCounts = true;
        /// <summary>
        /// 是否显示行数
        /// </summary>
        public bool ShowRowCounts
        {
            get
            {
                return showRowCounts;
            }
            set
            {
                showRowCounts = value;
                skinLabelTotalCount.Visible = value;
                SetVisible();
            }
        }
        /// <summary>
        /// 增加序号
        /// </summary>
        public bool AutoIndex
        {
            get { return dataGridView.Columns.Contains(autoIndexColumn); }
            set
            {
                if (value)
                {
                    if (!dataGridView.Columns.Contains(autoIndexColumn))
                    {
                        AddIndexRow();
                        SetStyle();
                    }
                }
                else
                {
                    if (dataGridView.Columns.Contains(autoIndexColumn))
                    {
                        dataGridView.Columns.Remove(autoIndexColumn);
                    }
                }
            }
        }

        //这个要在调用初始化的时候先使用，否则字段模式会变成NOSET,或者直接使用SpecAutoSizeMode设置即可
        /// <summary>
        /// 在初始化之前，AppendNotShowInColumnSettings之前 new之后
        /// </summary>
        /// <param name="dataGridViewColumn"></param>
        public void SpecAutoSizeModeColumns(params DataGridViewColumn[] dataGridViewColumn)
        {
            foreach (var item in dataGridViewColumn)
            {
                SpecAutoSizeMode(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(item, item.AutoSizeMode));
            }
        }

        public void SpecSizeGroupColumns(params DataGridViewColumn[] dataGridViewColumn)
        {
            foreach (var item in dataGridViewColumn)
            {
                SpecSizeGroupColumn(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(item, item.AutoSizeMode));
            }
        }


        /// <summary>
        /// 解决排序时闪烁的问题，多次变更当前行，致使页面多次刷新,还有重新排序时，禁用刷新页面
        ///</summary>
        public EventHandler SelectionChanged
        {
            get { return selectionChanged; }
            set
            {

                selectionChanged = value;
                //  dataGridView.SelectionChanged
            }
        }

        // internal Delegate selectionChanged;
        private EventHandler selectionChanged;



        public static String ROW_HEADERS_ONE = "小计";
        public static String ROW_HEADERS_TWO = "总计";
        private DataGridView dataGridView;
        private bool isPaging;
        //   private int calRowsCount;
        private PageControlPanel PageControlPanel { get; set; }
        private List<TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>> specAutoSizeMode;
        private List<TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>> specSizeGroupColumn;


        //private List<DataGridViewColumn> excludedAutoSizeMode;
        //public void ExcludedAutoSizeMode(params DataGridViewColumn[] columns) {
        //    if (excludedAutoSizeMode == null) {
        //        excludedAutoSizeMode = new List<DataGridViewColumn>();
        //    }
        //    excludedAutoSizeMode.AddRange(columns);
        //}
        /// <summary>
        /// 设定特定列的显示方式
        /// </summary>
        /// <param name="keyValue"></param>
        private void SpecAutoSizeMode(TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode> keyValue)
        {
            if (specAutoSizeMode == null)
            {
                specAutoSizeMode = new List<TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>>();
            }
            specAutoSizeMode.Add(keyValue);
        }

        private void SpecSizeGroupColumn(TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode> keyValue)
        {
            if (specSizeGroupColumn == null)
            {
                specSizeGroupColumn = new List<TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>>();
            }
            specSizeGroupColumn.Add(keyValue);
        }


        /// <summary>
        /// 总页数
        /// </summary>
        private int pageCount;
        /// <summary>
        /// 当前页数
        /// </summary>
        private int currentPageIndex;
        private DataTable SourceDataTable { get; set; }
        /// <summary>
        /// 要进行统计的列绑定字段
        /// </summary>
     //   public List<DataGirdViewCalculateColumn> CalculateColumns { get; internal set; }
        public string[] ColumnDataPropertyNames { get; internal set; }
        private CbGeneric<int> CurrentPageIndexChanged;
        public CbGeneric<int> SelectionChange;
        internal void Change_Color(int rowIndex, int columnIndex)
        {
            dataGridView.Rows[rowIndex].Cells[columnIndex].ReadOnly = true;
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Style.BackColor = Color.Wheat;
            //cell.ReadOnly = true;
            cell.Value = "N";
            cell.Style.BackColor = Color.White;
            dataGridView.Rows[rowIndex].Cells[columnIndex] = cell;
            dataGridView.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = Color.White;
            dataGridView.Rows[rowIndex].Cells[columnIndex].Style.SelectionBackColor = Color.White;
            dataGridView.Rows[rowIndex].Cells[columnIndex].Style.SelectionForeColor = Color.White;
        }

        /// <summary>
        /// 在第一次传参时设置排序参数的默认查询结果，供OrderSearch调用，这个跟服务端功能关系有点多
        /// </summary>
        public BaseOrderPara OrderPara { get; set; }
        public CbGeneric<Object, EventArgs> PageSizeChange { get; set; }
        public int PageSize
        {
            get
            {
                int value = 0;
                try
                {
                    value = int.Parse(this.skinComboBoxPageSize.Text);
                }
                catch
                {
                    if (this.skinComboBoxPageSize.SelectedValue == null && skinComboBoxPageSize.DataSource != null)
                    {
                        this.skinComboBoxPageSize.SelectedIndex = 0;
                        value = (int)this.skinComboBoxPageSize.SelectedValue;
                    } else if (this.skinComboBoxPageSize.SelectedValue != null) {
                        value = (int)this.skinComboBoxPageSize.SelectedValue;
                    }
                }
                return value;

            }
            set
            {
                try
                {
                    this.skinComboBoxPageSize.SelectedValue = value;
                }
                catch
                {
                }
            }
        }

        public bool[] abs4Column { get; internal set; }

        /// <summary>
        /// 初始化后调用Search事件调用服务端查询 dataGridViewPagingSumCtrl.OrderSearch += Search;
        /// </summary>
        public CJBasic.Action<Object, EventArgs> OrderSearch;
        internal void Clear()
        {
            this.dataGridView.DataSource = null;
            //  this.dataGridView.Refresh();
            this.pageControlPanel21.Initialize(1);
        }

        private void DisableColumnsResizeEvent()
        {
            DisableDataGridViewResizeEvent();
            DisableColumnResizeEvent();
            DisableCellFormattingEvent();
        }

        private void SetColumnsResizeEvent()
        {
            SetDataGridViewResizeEvent();
            SetColumnResizeEvent();
            SetCellFormattingEvent();
        }

        private void SetDataGridViewResizeEvent()
        {
            DisableDataGridViewResizeEvent();
            dataGridView.Resize += DataGridView_Resize;
            dataGridView.RowHeadersWidthChanged += DataGridView_RowHeadersWidthChanged;
        }
        private void SetCellFormattingEvent()
        {
            dataGridView.CellFormatting += DataGridView_CellFormatting;
        }

        private void DisableCellFormattingEvent()
        {
            dataGridView.CellFormatting -= DataGridView_CellFormatting;
        }

        private void DisableDataGridViewResizeEvent()
        {
            dataGridView.Resize -= DataGridView_Resize;
            dataGridView.RowHeadersWidthChanged -= DataGridView_RowHeadersWidthChanged;
        }

        private void SetColumnResizeEvent()
        {
            DisableColumnResizeEvent();
            dataGridView.ColumnWidthChanged += DataGridView_ColumnWidthChanged;
        }

        private void DisableColumnResizeEvent()
        {
            dataGridView.ColumnWidthChanged -= DataGridView_ColumnWidthChanged;
        }

        private void SetPrivateEvent()
        {
            dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;
            pageControlPanel21.CurrentPageIndexChanged += PageControlPanel21_CurrentPageIndexChanged;
            dataGridView.DataError += DataGridView_DataError;
            dataGridView.CellMouseDown += DataGridView_CellMouseDown;
            dataGridView.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            dataGridView.KeyDown += DataGridView_KeyDown;
            dataGridView.CellValidating += DataGridView_CellValidating;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (Debug)
            //{
            //    CommonGlobalUtil.Debug("Begin DataGridView_CellValueChanged" + DateTime.Now);
            //}
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridView view = sender as DataGridView;

            //右键选中单元格

            //如果当前选中的有款号，则显示图片的按钮
            //613 任何地方的表格内，右键款号，都能显示图片。
            if (view.Columns[e.ColumnIndex].HeaderText == "款号")
            {
                if (imageCtrl.Visible)
                {
                    DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    costumeID = cell.Value.ToString();
                    imageCtrl.Text = "款号：" + costumeID;
                    imageCtrl.OnLoadingState();
                    CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoCostumePhoto);
                    cb.BeginInvoke(null, null);
                    imageCtrl?.BringToFront();
                }
            }
            //if (Debug)
            //{
            //    CommonGlobalUtil.Debug("End DataGridView_CellValueChanged" + DateTime.Now);
            //}
        }

        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("End DataGridView_CellValidating" + DateTime.Now);
            }
            if (ValidateUtil.IsNumericType(dataGridView.Columns[e.ColumnIndex].ValueType))
            {
                if (String.IsNullOrEmpty(CommonGlobalUtil.ConvertToString(e.FormattedValue)))
                {
                    using (DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex])
                    {
                        if (!cell.ReadOnly)
                        {
                            orgValue = cell.Value;
                        }
                    }
                }
            }
            if (Debug)
            {
                CommonGlobalUtil.Debug("End DataGridView_CellValidating" + DateTime.Now);
            }
        }

        //定义一个变量用来储存为空时的原值
        object orgValue = -1;
        public new void DoubleBuffered(bool buffered)
        {
            if (dataGridView != null)
            {
                dataGridView.DoubleBuffered(buffered);
            }
        }

        /// <summary>
        /// 自动定焦点到指定的可写单元格内
        /// </summary>
        public void AutoFocusToWritableCell()
        {
            DataGridViewUtil.AutoFocusToFirstWritableCell(this.dataGridView);
        }

        //自动滚动到最后一行
        public void ScrollToEnd()
        {
            if (dataGridView != null && dataGridView.RowCount > 0)
            {
                int index = dataGridView.RowCount - 1;
                DataGridViewUtil.ScrollToRowIndex(dataGridView, index);
            }
        }

        public void ScrollToRowIndex(int index)
        {
            DataGridViewUtil.ScrollToRowIndex(dataGridView, index);
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                CommonGlobalUtil.WriteLog(e.Exception);
            }

            if (e.Exception is FormatException || e.Exception is ArgumentException)
            {
                //如果是转换有问题的话，那么将值赴·
                if (ValidateUtil.IsNumericType(dataGridView.Columns[e.ColumnIndex].ValueType))
                {
                    if (orgValue != (object)-1)
                    {
                        DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        if (!cell.ReadOnly)
                        {
                            cell.Value = ValidateUtil.GetNumericType(dataGridView.Columns[e.ColumnIndex].ValueType);
                            orgValue = -1;
                            // return;
                        }
                    }
                }
            }

            e.Cancel = false;
        }

        private void DataGridView_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin DataGridView_RowHeadersWidthChanged" + DateTime.Now);
            }
            SetStyle();
            if (Debug)
            {
                CommonGlobalUtil.Debug("End DataGridView_RowHeadersWidthChanged" + DateTime.Now);
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ShowZeroFormatting)
            {
                DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
            }

            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }

                if (dataGridView.Columns[e.ColumnIndex].ValueType == typeof(DateTime))
                {
                    if (String.IsNullOrEmpty(e?.Value.ToString()) || SystemDefault.DateTimeNull == (DateTime)e?.Value)
                    {
                        e.Value = null;
                    }
                }

                switch (AutoIndexMode)
                {
                    case DataGridViewAutoIndexMode.NewColumn:
                        if (e.ColumnIndex == autoIndexColumn.Index)
                        {
                            String item = dataGridView.Rows[e.RowIndex].HeaderCell.Value?.ToString();

                            if (!this.IsUnSelectedableRow(dataGridView.Rows[e.RowIndex]))
                            {
                                e.Value = (e.RowIndex + 1) + currentPageIndex * PageSize;
                            }
                            if (IsEmptyRowHeader(dataGridView.Rows[e.RowIndex]))
                            {
                                e.Value = String.Empty;
                            }
                        }
                        break;
                    case DataGridViewAutoIndexMode.RowHeader:
                        break;
                    case DataGridViewAutoIndexMode.None:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }

        }

        private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                //如果当前选中的有款号，则显示图片的按钮
                //613 任何地方的表格内，右键款号，都能显示图片。
                if (view.Columns[e.ColumnIndex].HeaderText == "款号")
                {
                    显示图片ToolStripMenuItem.Visible = true;
                }
                else
                {
                    显示图片ToolStripMenuItem.Visible = false;
                }

                contextMenuStripDataGridViewH.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示
            }
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //查找下一个tab控件
                this.TopLevelControl.SelectNextControl(this, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (ValidateUtil.IsNumericType(dataGridView.CurrentCell.ValueType))
                {
                    if (!dataGridView.CurrentCell.ReadOnly)
                    {
                        dataGridView.CurrentCell.Value = 0;
                    }
                }
            }
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin DataGridView_DataBindingComplete" + DateTime.Now);
            }
            DisableColumnsResizeEvent();
            switch (AutoIndexMode)
            {
                case DataGridViewAutoIndexMode.NewColumn:
                    break;
                case DataGridViewAutoIndexMode.RowHeader:
                    foreach (DataGridViewRow item in this.dataGridView.Rows)
                    {
                        if (!this.IsUnSelectedableRow(item))
                        {
                            this.dataGridView.RowHeadersWidthChanged -= DataGridView_RowHeadersWidthChanged;
                            item.HeaderCell.Value = string.Format("{0}", (item.Index + 1) + currentPageIndex * PageSize);
                            this.dataGridView.RowHeadersWidthChanged += DataGridView_RowHeadersWidthChanged;
                        }

                        if (IsEmptyRowHeader(item))
                        {
                            this.dataGridView.RowHeadersWidthChanged -= DataGridView_RowHeadersWidthChanged;
                            item.HeaderCell.Value = String.Empty;
                            this.dataGridView.RowHeadersWidthChanged += DataGridView_RowHeadersWidthChanged;
                        }

                    }
                    break;
                case DataGridViewAutoIndexMode.None:
                    break;
                default:
                    break;
            }

            //if (!isSorting)
            //{
            //     isSorting = false;
            //}
           // else { isSorting = false; }
            //if (dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible)
            //{
            //    this.dataGridViewContextMenuStrip1.RefreshSizeGroup();
            //}
            if (DataSource != null)
            {
                SetStyle();
                SetColumnDisplaySettings(false);
            }

            if (!isPaging)
            {
                skinLabelTotalCount.Text = "共" + dataGridView.Rows.Count.ToString() + "行";
                skinLabelTotalCount.Visible = dataGridView.Visible;
            }
            else
            {
                pageControlPanel21.Enabled = true;
            }



            SetColumnsResizeEvent();
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin DataGridView_DataBindingComplete" + DateTime.Now);
            }
        }

        private void SetColumnDisplaySettings(bool supportEmptyRows)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin SetColumnDisplaySettings" + DateTime.Now);
            }
            SetColumnDisplayCommonSettings(supportEmptyRows);
            SetColumnDisplayAtmSettings(supportEmptyRows);
            if (Debug)
            {
                CommonGlobalUtil.Debug("End SetColumnDisplayCommonSettings" + DateTime.Now);
            }
        }

        private void SetColumnDisplayAtmSettings(bool supportEmptyRows)
        {
            if (dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible)
            {
                int fromColumnIndex = -1;
                int toColumnIndex = -1;
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (item.DataPropertyName == CostumeSize.F + "Atm")
                    {
                        fromColumnIndex = item.Index;
                    }
                    else if (item.DataPropertyName == CostumeSize.XL6 + "Atm")
                    {
                        toColumnIndex = item.Index;
                    }
                }
                if (fromColumnIndex < 0 || toColumnIndex < 0)
                {
                    return;
                }
                List<DataGridViewColumn> columnList = new List<DataGridViewColumn>();

                if (NotShowInColumnSettings != null)
                {
                    columnList = new List<DataGridViewColumn>(NotShowInColumnSettings);
                }
                if (dataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = fromColumnIndex; i < toColumnIndex + 1; i++)
                        {
                            if (row.Cells[i].Value?.ToString() != "0")
                            {
                                DataGridViewColumn column = dataGridView.Columns[i];
                                column.Visible = true;
                                //这个时候就要切换设置选项，不为0则显示，显示在列表中
                                if (columnList.Contains(column))
                                {
                                    columnList.Remove(column);
                                }
                            }
                        }
                    }

                    SetNotShowInColumnSettings(columnList.ToArray());
                }
                else if (supportEmptyRows)
                {


                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (i >= fromColumnIndex && i <= toColumnIndex)
                        {
                            DataGridViewColumn column = dataGridView.Columns[i];
                            List<String> sizeNameList = CommonGlobalCache.GetShowSizeNames();
                            if (sizeNameList.Count > 0)
                            {
                                String sizeNames = sizeNameList.Find(t => t + "Atm" == column.DataPropertyName);

                                if (String.IsNullOrEmpty(sizeNames))
                                {
                                    columnList.Add(column);
                                }
                                else
                                {
                                    columnList.Remove(column);
                                }
                            }
                        }
                    }
                }

                SetNotShowInColumnSettings(columnList.ToArray());
            }
        }

        private void SetColumnDisplayCommonSettings(bool supportEmptyRows)
        {

            if (dataGridViewContextMenuStrip1.IsCostumeSizeMenuVisible)
            {
                int fromColumnIndex = -1;
                int toColumnIndex = -1;
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (item.DataPropertyName == CostumeSize.F)
                    {
                        fromColumnIndex = item.Index;
                    }
                    else if (item.DataPropertyName == CostumeSize.XL6)
                    {
                        toColumnIndex = item.Index;
                    }
                }

                if (fromColumnIndex < 0 || toColumnIndex < 0)
                {
                    return;
                }
                List<DataGridViewColumn> columnList = new List<DataGridViewColumn>();

                if (NotShowInColumnSettings != null)
                {
                    columnList = new List<DataGridViewColumn>(NotShowInColumnSettings);
                }
                if (dataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        for (int i = fromColumnIndex; i < toColumnIndex + 1; i++)
                        {
                            if (row.Cells[i].Value?.ToString() != "0")
                            {
                                DataGridViewColumn column = dataGridView.Columns[i];
                                column.Visible = true;
                                //这个时候就要切换设置选项，不为0则显示，显示在列表中
                                if (columnList.Contains(column))
                                {
                                    columnList.Remove(column);
                                }
                            }
                        }
                    }

                    SetNotShowInColumnSettings(columnList.ToArray());
                }
                else if (supportEmptyRows)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (i >= fromColumnIndex && i <= toColumnIndex)
                        {
                            DataGridViewColumn column = dataGridView.Columns[i];
                            List<String> sizeNameList = CommonGlobalCache.GetShowSizeNames();
                            if (sizeNameList.Count > 0)
                            {
                                String sizeNames = sizeNameList.Find(t => t == column.DataPropertyName);

                                if (String.IsNullOrEmpty(sizeNames))
                                {
                                    columnList.Add(column);
                                }
                                else
                                {
                                    columnList.Remove(column);
                                }
                            }
                        }
                    }

                    SetNotShowInColumnSettings(columnList.ToArray());
                }
            }
        }

        private int lastWidth;
        private int lastHeight;
        private void DataGridView_Resize(object sender, EventArgs e)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin DataGridView_Resize" + DateTime.Now);
            }

            if (lastWidth != dataGridView.Width || lastHeight != dataGridView.Height)
            {
                lastWidth = dataGridView.Width;
                lastHeight = dataGridView.Height;
                SetStyle();
            }

            if (Debug)
            {
                CommonGlobalUtil.Debug(" End DataGridView_Resize" + DateTime.Now);
            }
        }

        private Boolean setStyle = true;
        public void DisableStyle()
        {
            setStyle = false;
        }

        public void EnableStyle()
        {
            setStyle = true;
            SetStyle();
        }

        /// <summary>
        /// 重新调用界面重刷,有头标题改变时也要重调
        /// </summary>
        /// <param name="isInitialize"></param>
        private void SetStyle(Boolean isInitialize = false, DataGridViewAutoSizeColumnsMode mode = DataGridViewAutoSizeColumnsMode.DisplayedCells)
        {
            DisableColumnResizeEvent();
            if (Debug)
            {
                CommonGlobalUtil.WriteLog("Begin SetStyle" + DateTime.Now);
            }

            if (!setStyle) { return; }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                //20180531 界面根据内容全部显示...除了备注
                //不能使用allcells 一般尽量使用NONE,实在不行就用AllCells
                dataGridView.AutoSizeColumnsMode = mode;
                int width = this.dataGridView.Size.Width;
                //去掉头宽度，剩余比例分配
                width = width - this.dataGridView.RowHeadersWidth;
                //获取列数和列标题长度
                int columnCount = this.dataGridView.ColumnCount;
                int columnHeaderCount = 0;

                if (IsAutoResizeColumns)
                {
                    if (config == null)
                    {
                        AutoResizeColumns(isInitialize, mode, columnHeaderCount, width);
                    }
                    else
                    {
                        this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    }

                }
                else
                {
                    if (config == null)
                    {
                        LoadConfig();
                    }
                    //根据设置加载宽度
                    //如果之前没有设置过的话，那第一次是以前自动匹配的模式
                    //第一次是这个配置文件没有 
                    if (isColumnFirstConfig)
                    {
                        if (config == null)
                        {
                            AutoResizeColumns(isInitialize, mode, columnHeaderCount, width);
                            DisableDataGridViewResizeEvent();
                        }
                        else
                        {
                            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }
                    }
                    else
                    {

                        if (config == null )
                        {
                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                            //加载并设置
                            foreach (DataGridViewColumn item in dataGridView.Columns)
                            {
                                ColumnSetting setting = config.Columns.Find(t => t.HeaderText == item.HeaderText);
                                if (setting != null && setting.Enabled)
                                {
                                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                                    item.Width = setting.Width;
                                }
                            }
                        }
                        else
                        {
                            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }

            if (Debug)
            {
                CommonGlobalUtil.WriteLog("End SetStyle" + DateTime.Now);
            }
            SetColumnResizeEvent();
        }

        private void AutoResizeColumns(Boolean isInitialize, DataGridViewAutoSizeColumnsMode mode, decimal columnHeaderCount, decimal width)
        {
            //if (config == null)
            //{
                foreach (DataGridViewColumn item in this.dataGridView.Columns)
                {

                    if (item.Visible)
                    {
                        SetAlignment(item);
                        if (!this.dataGridView.AllowUserToOrderColumns)
                        {
                            item.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        //设置长度为标题的长相关
                      //  item.Resizable = DataGridViewTriState.True;


                        //20180531新增判断，如果有特定的列格式，则以这个格式计算适应长度
                        if (specAutoSizeMode != null && specAutoSizeMode.Exists(t => t.Key == item))
                        {
                            TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode> keyValue = specAutoSizeMode.Find(t => t.Key == item);
                            if (keyValue != null)
                            {
                                item.AutoSizeMode = keyValue.Value;

                                //noset,none,fill会报错20180614,修改盘点时
                                switch (keyValue.Value)
                                {
                                    case DataGridViewAutoSizeColumnMode.NotSet:
                                    case DataGridViewAutoSizeColumnMode.None:
                                    case DataGridViewAutoSizeColumnMode.Fill:
                                        item.Width = item.GetPreferredWidth(GetDataGridViewAutoSizeColumnMode(mode), true);
                                        // keyValue.Value = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                        break;
                                    default:
                                        item.Width = item.GetPreferredWidth(keyValue.Value, true);
                                        break;
                                }
                                //不能是noset/none/fill
                                //20190319
                                //item.Width = item.GetPreferredWidth(keyValue.Value, true);

                            }
                            item.FillWeight = item.Width;
                            item.MinimumWidth = item.Width;

                        }
                        else if (specSizeGroupColumn != null && specSizeGroupColumn.Exists(t => t.Key == item))
                        {
                            //dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSiz;
                            TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode> keyValue = specSizeGroupColumn.Find(t => t.Key == item);
                            if (keyValue != null)
                            {
                                item.AutoSizeMode = keyValue.Value;
                                item.Width = item.GetPreferredWidth(keyValue.Value, true);
                            }
                        }
                        else if (ValidateUtil.IsNumericType(item.ValueType))
                        {
                            item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            //根据类型判断 数字
                            int headerWidth = item.GetPreferredWidth(DataGridViewAutoSizeColumnMode.ColumnHeader, true);
                            //数字默认撑满，但是计算肯定慢，初始的时候不需要撑满，拉动的时候也不需要
                            if (isInitialize)
                            {
                                int AllCellsWidth = item.GetPreferredWidth(GetDataGridViewAutoSizeColumnMode(mode), true);
                                item.Width = AllCellsWidth > headerWidth ? AllCellsWidth : headerWidth;
                            }
                            else
                            {
                                int AllCellsWidth = item.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                                item.Width = AllCellsWidth > headerWidth ? AllCellsWidth : headerWidth;
                            }
                        }
                        else
                        {
                            item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            item.Width = item.GetPreferredWidth(GetDataGridViewAutoSizeColumnMode(mode), true);
                          
                          //  item.FillWeight = item.Width;
                          // item.MinimumWidth = item.Width;
                        }

                        columnHeaderCount += item.Width;
                        //标题总长度
                        SetColumnAutoSizeMode(item);
                    }
                }
            //}
            // 行标题宽度会影响整个datagridview的长度20180524，数据加载前没有标题，加载后标题长了。
            if (columnHeaderCount <= width)
            {
                //if (config == null)  
                //{
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               /* }
                else {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }*/
               // dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            }
            if (isInitialize)
            {
                //特殊字段，以他的自定义形式，其他都是NOSET，默认FILL.
                //748 pos端收银页面，没有数据时表格没有撑开
                //if (specAutoSizeMode != null && specAutoSizeMode.Count > 0)
                //{
                //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //}
                //else
                //{
                //if (config == null) 
                //{
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
              /*  }
                else
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }*/
              //  dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                // }
            }
            else
            {
                //定义了列类型后，NONE使得其他字段列没有显示完全
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        private void CheckRowHeader()
        {

            switch (this.autoIndexMode)
            {
                case DataGridViewAutoIndexMode.NewColumn:
                    break;
                case DataGridViewAutoIndexMode.RowHeader:
                    ////加上序号
                    dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
                    dataGridView.RowHeadersWidth = 70;
                    dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dataGridView.RowHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Regular);
                    //  dataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                case DataGridViewAutoIndexMode.None:
                    break;
                default:
                    break;
            }
            this.dataGridView.Refresh();
        }

        private DataGridViewAutoSizeColumnMode GetDataGridViewAutoSizeColumnMode(DataGridViewAutoSizeColumnsMode mode)
        {
            DataGridViewAutoSizeColumnMode columnMode = DataGridViewAutoSizeColumnMode.NotSet;
            switch (mode)
            {
                case DataGridViewAutoSizeColumnsMode.AllCells:
                    columnMode = DataGridViewAutoSizeColumnMode.AllCells;
                    break;
                case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
                    columnMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    break;
                case DataGridViewAutoSizeColumnsMode.DisplayedCells:
                    columnMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    break;
                case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
                    columnMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    break;
                case DataGridViewAutoSizeColumnsMode.None:
                    columnMode = DataGridViewAutoSizeColumnMode.None;
                    break;
                case DataGridViewAutoSizeColumnsMode.ColumnHeader:
                    columnMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    break;
                case DataGridViewAutoSizeColumnsMode.Fill:
                    columnMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                default:
                    break;
            }
            return columnMode;
        }

        private void SetColumnAutoSizeMode(DataGridViewColumn item)
        {
            if (!item.Frozen)
            {
                if (specAutoSizeMode != null && specAutoSizeMode.Exists(t => t.Key == item))
                {
                    return;
                }

                if (item.GetType() == typeof(DataGridViewLinkColumn))
                {
                    //  item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet; ;
                }
                else if (item.ValueType == typeof(DateTime))
                {
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }
                else
                {
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }
            }
        }

        private void SetAlignment(DataGridViewColumn item)
        {
            item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (item.ValueType == typeof(DateTime))
            {
                if (String.IsNullOrEmpty(item.DefaultCellStyle.Format))
                {
                    item.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
                }
                // item.ValueType = typeof(String);
            }
            else if (item.ValueType == typeof(Date))
            {
                if (String.IsNullOrEmpty(item.DefaultCellStyle.Format))
                {
                    item.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
                }
            }
            else if (ValidateUtil.IsNumericType(item.ValueType))
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private EventHandlerList GetEventHandlerList()
        {
            PropertyInfo propertyInfo = dataGridView.GetType().GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            EventHandlerList eventList = null;
            if (propertyInfo != null)
            {
                eventList = (EventHandlerList)propertyInfo.GetValue(dataGridView, null);
            }
            return eventList;
        }

        public void Initialize()
        {
            try
            {
                //增加判断
                DisableEvents();

                LoadConfig();
                LoadColumnsConfig();
                if (PanelTop)
                {
                    SetMenuStrip();
                }
                /* 下面的代码是用来获取btnDemo的Click事件注册的方法的 */
                panel5.Visible = false;
                switch (this.autoIndexMode)
                {
                    case DataGridViewAutoIndexMode.NewColumn:
                        ////加上序号 
                        AddIndexRow();
                        break;
                    case DataGridViewAutoIndexMode.RowHeader:
                        //放在SETSTYLE链接界面会闪
                        CheckRowHeader();
                        break;
                    case DataGridViewAutoIndexMode.None:
                        break;
                    default:
                        break;
                }
                this.pageControlPanel21.Visible = false;
                List<ListItem<int>> list = new List<ListItem<int>>();
                for (int i = 1; i < 11; i++)
                {
                    int value = i * 10;
                    list.Add(new ListItem<int>(value.ToString(), value));
                }
                list.Add(new ListItem<int>("最大", int.MaxValue));
                skinComboBoxPageSize.DisplayMember = "Key";
                skinComboBoxPageSize.ValueMember = "Value";
                this.skinComboBoxPageSize.DataSource = list;
                skinComboBoxPageSize.SelectedIndex = 1;
                //设置单选 20190326 删除默认设置
                // this.dataGridView.MultiSelect = false;
                // this.dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                this.dataGridView.AllowUserToResizeRows = false;

                //设置字体
                //  dataGridView.RowsDefaultCellStyle.Font = new Font(Font., FontStyle.Strikeout);
                dataGridView.RowsDefaultCellStyle.Font = CommonGlobalUtil.DEFAULT_FONT;
                dataGridView.RowHeadersDefaultCellStyle.Font = CommonGlobalUtil.DEFAULT_FONT;
                //已优化：
                //先设置AutoSizeRowsMode = none; 很重要，
                //我的就是因为是allcell所以很慢，修改后快多了。
                DoubleBufferedGridView();
                //列头自动换行
                dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

                this.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //设置列头样式
                this.dataGridView.AllowUserToResizeColumns = true;
                this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                this.dataGridView.BackgroundColor = Color.White;
                //设置列自适应
                //如果是linkcolumn那么就是allCell mode
                //this.dataGridView.= false;
                //设置右键菜单
                this.dataGridView.ContextMenuStrip = this.contextMenuStripDataGridViewH;
                Control parent = this.dataGridView.Parent;
                ControlCollection collection = parent.Controls;
                int index = 0;
                for (int i = 0; i < collection.Count; i++)
                {
                    Control ctrl = collection[i];

                    if (ctrl == this.dataGridView)
                    {
                        index = i;
                        break;
                    }
                }
                // this.panel1.Dock = this.DataGridView.Dock; 
                this.Dock = this.dataGridView.Dock;
                this.Anchor = this.dataGridView.Anchor;
                if (this.dataGridView.Dock == DockStyle.None)
                {
                    this.Size = this.dataGridView.Size;
                    this.Location = this.dataGridView.Location;
                }
                this.dataGridView.Dock = DockStyle.Fill;
                this.panel4.Controls.Add(this.dataGridView);
                parent.Controls.Add(this);
                parent.Controls.SetChildIndex(this, index);
                this.TabIndex = dataGridView.TabIndex;
                this.BringToFront();
                this.dataGridView.BringToFront();

                this.dataGridView.AccessibleName = "DataGridViewPagingSumCtrl";
                this.PageSizeChange = PageSizeChange;

                SetVisible();
                ClearSummary();

                SetCostumeSizeColumnSpecical();

                SetStyle(true);
                SetPrivateEvent();
                SetColumnDisplaySettings(true);
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        Control baseControl;
        private void SetVisible()
        {
            this.pageControlPanel21.Visible = isPaging;
            this.skinComboBoxPageSize.Visible = isPaging;
            this.skinLabel1.Visible = isPaging;
            this.skinPanel2.Visible = this.showRowCounts || isPaging;
        }

        private DataGridViewTextBoxColumn autoIndexColumn = null;
        public DataGridViewTextBoxColumn AutoIndexColumn { get { return autoIndexColumn; } }
        private DataGridViewAutoIndexMode autoIndexMode = DataGridViewAutoIndexMode.RowHeader;

        /// <summary>
        /// 设置是否添加序列
        /// </summary>
        public DataGridViewAutoIndexMode AutoIndexMode { get { return autoIndexMode; } set { autoIndexMode = value; } }

        private Object DataSource
        {
            get { return this.dataGridView?.DataSource; }
            set
            {
                DisableEvents();
                if (this.dataGridView != null)
                {
                    this.dataGridView.DataSource = value;
                    if (this.dataGridView.Visible==false)
                    {
                        this.dataGridView.Visible = true;
                    }
                }
                EnableEvents();
            }
        }

        public bool Paging { get { return isPaging; } set { isPaging = value; } }

        private void AddIndexRow()
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "序号";
            column.Name = "AutoIndexColumn";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            autoIndexColumn = column;
            column.Frozen = true;
            dataGridView.Columns.Insert(0, column);
        }

        private void DoubleBufferedGridView()
        {
            Type dgvType = this.dataGridView.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridView, true, null);
        }
        //private bool isSorting = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                DataGridView dgv = sender as DataGridView;

                if (dgv.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    string columnBindingName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                    switch (dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                    {
                        case System.Windows.Forms.SortOrder.None:
                        case System.Windows.Forms.SortOrder.Ascending:

                            CustomSort(columnBindingName, dgv.Columns[e.ColumnIndex].HeaderCell, false);
                            break;
                        case System.Windows.Forms.SortOrder.Descending:

                            CustomSort(columnBindingName, dgv.Columns[e.ColumnIndex].HeaderCell, true);

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        /// <summary>
        /// 关闭一些界面显示影响的事件
        /// </summary>
        private void DisableEvents()
        {
            if (selectionChanged != null)
            {
                dataGridView.SelectionChanged -= selectionChanged;
            }
        }

        /// <summary>
        /// 开启一些界面显示影响的事件
        /// </summary>
        private void EnableEvents()
        {
            if (selectionChanged != null)
            {
                dataGridView.SelectionChanged -= selectionChanged;
                dataGridView.SelectionChanged += selectionChanged;
            }
        }

        /// <summary>
        /// 自定义排序
        /// </summary> 
        private void CustomSort(string columnBindingName, DataGridViewColumnHeaderCell headerCell, bool ascend)
        {   //isSorting = true;
            bool hasSort = false;
            ColumnSorting?.Invoke(columnBindingName, ascend);
            //   CommonGlobalUtil.Debug("排序开始:" + columnBindingName);
            DisableEvents();
            List<DataGridViewRow> rowHeaders = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                if (!String.IsNullOrEmpty(ValidateUtil.CheckEmptyValue(row.HeaderCell.Value)) && IsUnSelectedableRow(row))
                {

                    rowHeaders.Add(row);
                }
            }
            if (DataSource is DataTable)
            {
              //  dataGridViewContextMenuStrip1.Disabled = true;
                foreach (var item in rowHeaders)
                {
                    dataGridView.Rows.Remove(item);
                }
                if (this.DataSource != null)
                {

                    DataTable dt = this.DataSource as DataTable;
                    DataView dv = dt.DefaultView;
                    dv.Sort = columnBindingName + " " + (ascend ? "ASC" : "DESC");
                    this.DataSource = dv.ToTable();
                    hasSort = true;
                    //this.BindingDataSource();
                }

             //   dataGridViewContextMenuStrip1.Disabled = false;
            }
            else if (DataSource is IList)
            {
                if (isPaging)
                {
                    //重新调用服务端查询
                    if (OrderPara != null)
                    {
                        //483 报表：所有报表都需要排序功能
                        //增加反序字段处理，通过cellFormat渲染显示的值，排序依照指定字段排序
                        if (columnBindingName.Contains("#Revert"))
                        {
                            OrderPara.Ascend = !ascend;
                            OrderPara.ColumnOrderby = columnBindingName.Substring(0, columnBindingName.IndexOf("#Revert"));
                        }
                        else
                        {
                            OrderPara.Ascend = ascend;
                            OrderPara.ColumnOrderby = columnBindingName;
                        }
                        if (isPaging)
                        {
                            PageControlPanel21_CurrentPageIndexChanged(0);
                        }
                        else
                        {
                            OrderSearch.Invoke(null, null);
                        }
                    }
                    hasSort = true;
                } 
            }



            if (hasSort)
            {
                if (ascend)
                {
                    headerCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                }
                else
                {
                    headerCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                }
            } 
           // dataGridViewContextMenuStrip1.Disabled = true;
            //else {
            //    if (headerCell.SortGlyphDirection == SortOrder.None)
            //    {
            //        headerCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
            //    }
            //}
            EnableEvents();
            // CommonGlobalUtil.Debug("排序结束:" + columnBindingName);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void PageControlPanel21_CurrentPageIndexChanged(int obj)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                ///20180618,如果是分页刷新，总数还是有问题，总数只是在初始化查询给的，数据有变也获取 
                currentPageIndex = obj;
                pageControlPanel21.Enabled = false;
                this.CurrentPageIndexChanged?.Invoke(obj);
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
                pageControlPanel21.Enabled = true;
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }


        /// <summary>
        /// 分页查询时触发， 序号、总行数相关显示调用
        /// </summary>
        /// <param name="listPage"></param>
        public void Initialize(BasePage listPage)
        {
            if (listPage != null)
            {
                UpdatePageCount(listPage.TotalEntityCount);
                Initialize(pageCount);
            }
            else
            {
                Initialize(1);
            }
        }

        public void Initialize(int index)
        {
            this.pageCount = index;
            this.pageControlPanel21.Initialize(index);
            this.currentPageIndex = 0;
        }

        private void UpdatePageCount(int totalEntityCount)
        {
            int pageCount = 1;
            //if (totalEntityCount != 0)
            //{
            if (PageSize != 0)
            {
                pageCount = (int)Math.Ceiling((double)totalEntityCount / PageSize);
                if (pageCount == 0) {
                    pageCount = 1;
                }
            }

            // }
            this.skinLabelTotalCount.Text = "共" + totalEntityCount + "行";
            InitializePageControl(pageCount);
        }

        private void InitializePageControl(int pageCount)
        {
            this.pageCount = pageCount;
            this.pageControlPanel21.Initialize(pageCount);
            //必须指定跳转到指定页面，否则初始化会重置
            pageControlPanel21.GotoPage(this.currentPageIndex, false);
            // this.currentPageIndex = 0;
        }

        public void ClearSummary()
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin ClearSummary" + DateTime.Now);
            }
            summaryControlContainer1.Unable();
            summaryControlContainer2.Unable();
            if (panel5.Visible == true)
            {
                panel5.Visible = false;
            }
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin ClearSummary" + DateTime.Now);
            }

        }

        private void ShowSummary(DataRow dr, string[] columnDataPropertyNames)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin ShowSummary" + DateTime.Now);
            }
            if (dr != null)
            {
                panel5.Visible = true;
                // summaryControlContainer2 = new SummaryControlContainer();
                panel5.Controls.Add(summaryControlContainer2);
                summaryControlContainer1.Dock = DockStyle.Top;
                if (HideSummaryRowHeader)
                {
                    summaryControlContainer2.Init(dataGridView, string.Empty, dr, columnDataPropertyNames);
                }
                else
                {
                    summaryControlContainer2.Init(dataGridView, ROW_HEADERS_TWO, dr, columnDataPropertyNames);
                }
                summaryControlContainer2.Visible = true;
            }
            if (Debug)
            {
                CommonGlobalUtil.Debug("End ShowSummary" + DateTime.Now);
            }
        }

        public void ShowSummary<T>(DataGridView dataGridView, IList<T> list, string[] columnDataPropertyNames)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin ShowSummary" + DateTime.Now);
            }
            if (list != null && list.Count > 0)
            {
                panel5.Visible = true;
                panel5.Controls.Add(summaryControlContainer1);
                summaryControlContainer1.ReportShowZero = ReportShowZero;
                if (HideSummaryRowHeader)
                {
                    summaryControlContainer1.Init(dataGridView, string.Empty, list[0], columnDataPropertyNames);
                }
                else
                {
                    summaryControlContainer1.Init(dataGridView, list.Count > 1 ? ROW_HEADERS_ONE : ROW_HEADERS_TWO, list[0], columnDataPropertyNames);
                }

                summaryControlContainer1.Visible = true;
                if (list.Count > 1)
                {

                    //   summaryControlContainer2 = new SummaryControlContainer();

                    panel5.Controls.Add(summaryControlContainer2);
                    summaryControlContainer1.Dock = DockStyle.Top;
                    summaryControlContainer2.Dock = DockStyle.Bottom;
                    summaryControlContainer2.ReportShowZero = ReportShowZero;

                    if (HideSummaryRowHeader)
                    {
                        summaryControlContainer2.Init(dataGridView, string.Empty, list[1], columnDataPropertyNames);
                    }
                    else
                    {
                        summaryControlContainer2.Init(dataGridView, ROW_HEADERS_TWO, list[1], columnDataPropertyNames);
                    }
                    summaryControlContainer2.Visible = true;
                }
            }
            if (Debug)
            {
                CommonGlobalUtil.Debug(" End ShowSummary" + DateTime.Now);
            }
        }

        public void BindingDataSource<T>(IList<T> list, string[] columns, int? totalCount, T totalRow = default(T), bool[] abs4Column = null, bool isPaging = true,bool isDisplayCol=true,bool DistinguishSize=true) where T : class, new()
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin BindingDataSource" + DateTime.Now);
            }
            DisableEvents();
            if (columns == null)
            {
                if (ColumnDataPropertyNames != null)
                {
                    columns = ColumnDataPropertyNames;
                }
            }
            int count = 0;
            if (totalCount == null)
            {
                count = 0;
            }
            else
            {
                count = (int)totalCount;
            }
            UpdatePageCount(count);
            DataGridViewHelper.BindSource4Reports<T>(this, dataGridView, list, columns, pageCount > 1 ? totalRow : null, abs4Column, isPaging,isDisplayCol, DistinguishSize);
            if (isPaging) {
                this.dataGridView.AllowUserToOrderColumns = true;
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (item.SortMode != DataGridViewColumnSortMode.NotSortable)
                    {
                        //在点击列标题可作为判断是否排序
                        item.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
            }
            EnableEvents();
            if (Debug)
            {
                CommonGlobalUtil.Debug(" End BindingDataSource" + DateTime.Now);
            }
        }

        public void BindingDataSource<T>(DataTable dt, DataGridViewColumn sortColumn = null, ListSortDirection listSortDirection = ListSortDirection.Descending, T totalRow = default(T))
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin BindingDataSource" + DateTime.Now);
            }

            DisableEvents();
            DataRow dr = null;
            this.dataGridView.AllowUserToOrderColumns = true;
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                if (item.SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    //在点击列标题可作为判断是否排序
                    item.SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            ClearSummary();
            if (ColumnDataPropertyNames != null)
            {
                //小计

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.DataSource = dt;
                    if (totalRow != null)
                    {
                        List<T> list = new List<T>();
                        list.Add(totalRow);
                        ShowSummary(dataGridView, list, ColumnDataPropertyNames);
                    }
                    else
                    {
                        dr = DataGridViewUtil.GetSumRow(dt, ColumnDataPropertyNames);
                        ShowSummary(dr, ColumnDataPropertyNames);
                    }
                }
                else
                {
                    this.DataSource = null;
                }
            }
            else
            {
                if (dt != null)
                {
                    this.DataSource = null;
                }
                this.DataSource = dt;
            }


            if (sortColumn != null)
            {
                dataGridView1_ColumnHeaderMouseClick(dataGridView, new DataGridViewCellMouseEventArgs(sortColumn.Index, 0, 0, 0, new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0)));
            }
            else
            {
                EnableEvents();
            }

            if (Debug)
            {
                CommonGlobalUtil.Debug(" End BindingDataSource" + DateTime.Now);
            }
        }

        /// <summary>
        /// 需要统计的时候调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageSumEntity"></param>
        /// <param name="toDataTable"></param>
        public void BindingDataSource<T>(IList<T> list,  bool isPaging = false,T totalRow = default(T),bool isDisplayCol =true,bool DistinguishSize=true) where T : class, new()
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug(" Begin BindingDataSource" + DateTime.Now);
            }
            DisableEvents();
            T t = new T();
            if (isPaging)
            {
               // this.dataGridView.AllowUserToOrderColumns = true;
                foreach (DataGridViewColumn item in dataGridView.Columns)
                {
                    if (item.SortMode != DataGridViewColumnSortMode.NotSortable)
                    {
                        //在点击列标题可作为判断是否排序
                        item.SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
                t = pageCount > 1 ? totalRow : null;
            }
            else
            {
                t = totalRow;
            }
            if (list != null)
            {
                UpdatePageCount(list.Count);
            }
            else
            {
                UpdatePageCount(0);
            }
            // DisableColumnsResizeEvent();
            DataGridViewHelper.BindSource4Reports<T>(this, dataGridView, list, this.ColumnDataPropertyNames, t, isPaging,isDisplayCol, DistinguishSize);
            //    SetColumnsResizeEvent();
            //  SetStyle();
            EnableEvents();
            if (Debug)
            {
                CommonGlobalUtil.Debug(" End BindingDataSource" + DateTime.Now);
            }
        }

        /// <summary>
        /// 判断是否为统计行
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool IsUnSelectedableRow(DataGridViewRow row)
        {
            if (row != null)
            {
                return (ROW_HEADERS_ONE == (row.HeaderCell.Value?.ToString())) || (ROW_HEADERS_TWO
                    == (row.HeaderCell.Value?.ToString()));
            }
            else { return false; }
        }

        public bool IsEmptyRowHeader(DataGridViewRow row)
        {
            if (row != null)
            {
                return (DataGridViewHelper.EMPTY_ROW_HEADER == (row.HeaderCell.Value?.ToString()));
            }
            else { return false; }
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(this.dataGridView.GetClipboardContent());
            }
            catch {
                CommonGlobalUtil.ShowError("无数据");
            }
        }

        #region 显示款号图片

        SingleImageForm imageCtrl = null;
        /// <summary>
        /// 613 任何地方的表格内，右键款号，都能显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                imageCtrl?.Close();
                imageCtrl = null;
                imageCtrl = new SingleImageForm();
                DataObject clipboardContent = this.dataGridView.GetClipboardContent();
                imageCtrl.Text = "款号：" + clipboardContent.GetText();
                costumeID = clipboardContent?.GetText();
                imageCtrl.OnLoadingState();

                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoCostumePhoto);
                cb.BeginInvoke(null, null);
                imageCtrl?.BringToFront();
                imageCtrl?.Show();
            }
            catch { CommonGlobalUtil.ShowError("无数据"); }
        }

        // DataObject clipboardContent;
        String costumeID;
        private void DoCostumePhoto()
        {
            try
            {
                byte[] bytes = CommonGlobalCache.ServerProxy.GetCostumePhoto(costumeID);
                if (bytes != null)
                {
                    Image image = CCWin.SkinControl.ImageHelper.Convert(bytes);
                    SetImage(image);
                }
                else
                {
                    SetImage(null);
                }
            }
            catch (Exception ex) {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void SetImage(Image image)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CJBasic.CbGeneric<Image>(this.SetImage), image);
            }
            else
            {
                //using (imageCtrl)
                //{
                if (imageCtrl != null)
                {
                    imageCtrl.Image = image;
                    imageCtrl?.BringToFront();
                }
                //}
            }
        }
        #endregion

        private void Form_ItemSelected(List<ColumnSetting> listItems, EventArgs args)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                ColumnSetting item = listItems.Find(t => t.HeaderText == column.HeaderText &&  t.HeaderID== column.DataPropertyName);
                if (item != null && item.Enabled)
                {
                    column.Visible = item.Visible;
                    column.Width = item.Width;
                    column.Width = item.ColWidth;
                }
            }

            config.Columns = listItems;
            config.Save(GetConfigPath());
            SetStyle();
        }

        private void 字段显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             CommonGlobalUtil.WriteLog("当前控件=" + baseControl);
            //if (baseControl.ToString() != "JGNet.Manage.GetPurchaseSummaryCtrl" && baseControl.ToString() != "SaleAnalysisTabControlCtrl")
            //{
              //  this.字段显示ToolStripMenuItem.Visible = false;
                DataGridViewColumnsForm form = new DataGridViewColumnsForm(this.dataGridView, NotShowInColumnSettings, baseControl);
                form.ItemSelected += Form_ItemSelected;
                form.ShowDialog(this);
          //  }
        }

        private void DataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                 
                DataGridViewColumn column = e.Column;
                int SetWidth = 0;
                ColumnSetting item = config.Columns.Find(t => t.HeaderID == column.DataPropertyName || t.HeaderText == column.HeaderText);
                //if (column.MinimumWidth < column.Width)
                //{
                //    column.MinimumWidth = 2;
                //}
                if (item != null)
                {
                    if (item.Enabled)
                    {
                        item.Visible = column.Visible;
                        item.ColWidth = column.Width;
                        item.Width = column.Width;
                        SetWidth += column.Width;
                         

                    }
                }
                else
                {
                    item = new ColumnSetting()
                    {
                        Enabled = true,
                        HeaderID = column.DataPropertyName,
                        HeaderIndex = column.Index,
                        HeaderText = column.HeaderText,
                         ColWidth=column.Width,
                        Width = column.Width,
                        Visible = column.Visible,
                         
                };
                   // column.MinimumWidth = column.Width;
                  //  GdWidth += item.Width;
                    SetWidth += item.Width;

                    //foreach (DataGridViewColumn itemCol in dataGridView.Columns)
                    //{

                    //    GdWidth += itemCol.Width;

                    //}

                    //if (GdWidth < this.Width)
                    //{
                    //    dataGridView.Columns[dataGridView.Columns.Count - 1].MinimumWidth = this.Width - GdWidth;

                    //    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //}

                    config.Columns.Add(item);
                }


             //   dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;




                // this.dataGridView.ScrollBars = ScrollBars.Both;





                CommonGlobalUtil.WriteLog("设置时DataGridView宽度=" + this.dataGridView.Width+"实际拖拉宽度="+ SetWidth);
                config.Save(GetConfigWidthPath());
                 
            }
            catch (Exception ex) {
                CommonGlobalUtil.ShowError(ex);
            }
        }

    }
}
