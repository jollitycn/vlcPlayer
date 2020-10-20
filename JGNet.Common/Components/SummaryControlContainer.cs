using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using JGNet.Common.Core;
using System.Reflection;
using CJBasic.Helpers;
using System.Threading;

namespace JGNet.Common
{
    public partial class SummaryControlContainer : UserControl

    {
        #region 公有属性


        private string _SumRowHeaderText = "总计";
        /// <summary>
        /// 总计列标题
        /// </summary>
        public string SumRowHeaderText
        {
            get
            {
                return _SumRowHeaderText;

            }
            set
            {

                _SumRowHeaderText = value;
            }
        }


        private string[] _SummaryColumns;
        /// <summary>
        /// 要统计的列名称或数据源绑定列名称
        /// </summary>
        public string[] SummaryColumns
        {
            get { return _SummaryColumns; }
            set
            {
                _SummaryColumns = value;
            }
        }

        private string _FormatString = "F02";
        public string FormatString
        {
            get { return _FormatString; }
            set { _FormatString = value; }
        }
        #endregion

        #region 私有变量
        private Hashtable sumBoxHash;
        public DataGridView DGV { get; set; }
        private Label sumRowHeaderLabel;
        public Object TotalRow { get; set; }
        public int OffsetTop { get; set; }
        #endregion

        #region 构造函数

        public SummaryControlContainer()
        {
            InitializeComponent();
        }
        public bool ReportShowZero{get;set;}


        private void SetEvent()
        {

            ClearEvent();
            if (this.DGV != null)
            {
               this.DGV.Resize += dgv_Resize;
                this.DGV.Scroll += dgv_Scroll;
                this.DGV.ColumnWidthChanged += dgv_ColumnWidthChanged;
                this.DGV.RowHeadersWidthChanged += dgv_RowHeadersWidthChanged;
                //   this.dgv.RowsAdded += new DataGridViewRowsAddedEventHandler(dgv_RowsAdded);
                //    this.dgv.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dgv_RowsRemoved);
              this.DGV.CellValueChanged += dgv_CellValueChanged;
               this.DGV.DataSourceChanged += new EventHandler(dgv_DataSourceChanged);
                //  this.dgv.ColumnAdded += new DataGridViewColumnEventHandler(dgv_ColumnAdded);
                //  this.dgv.ColumnRemoved += new DataGridViewColumnEventHandler(dgv_ColumnRemoved);
                //    this.dgv.ColumnStateChanged += new DataGridViewColumnStateChangedEventHandler(dgv_ColumnStateChanged);
                this.DGV.ColumnDisplayIndexChanged += dgv_ColumnDisplayIndexChanged;
                //
            }

        }

        private void ClearEvent()
        {
            if (this.DGV != null)
            {
            this.DGV.Resize -= dgv_Resize;
                this.DGV.Scroll -= dgv_Scroll;
                this.DGV.ColumnWidthChanged -= dgv_ColumnWidthChanged;
                this.DGV.RowHeadersWidthChanged -= dgv_RowHeadersWidthChanged;
                //   this.dgv.RowsAdded += new DataGridViewRowsAddedEventHandler(dgv_RowsAdded);
                //    this.dgv.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dgv_RowsRemoved);
                this.DGV.CellValueChanged -= dgv_CellValueChanged;
                  //      this.DGV.DataSourceChanged -= new EventHandler(dgv_DataSourceChanged);
                //  this.dgv.ColumnAdded += new DataGridViewColumnEventHandler(dgv_ColumnAdded);
                //  this.dgv.ColumnRemoved += new DataGridViewColumnEventHandler(dgv_ColumnRemoved);
                //    this.dgv.ColumnStateChanged += new DataGridViewColumnStateChangedEventHandler(dgv_ColumnStateChanged);
                this.DGV.ColumnDisplayIndexChanged -= dgv_ColumnDisplayIndexChanged;
              // this.DGV.DataBindingComplete -= Dgv_DataBindingComplete;
            }
        }

        private void Generate()
        {
            try
            {
                this.Visible = true;
                this.Height = DGV.RowTemplate.Height;
                this.Left = DGV.Left;
                this.BackColor = DGV.RowHeadersDefaultCellStyle.BackColor;

                sumBoxHash = new Hashtable();
                sumRowHeaderLabel = new Label();
                sumRowHeaderLabel.Height = this.Height;
                sumRowHeaderLabel.Width = DGV.RowHeadersWidth;
                sumRowHeaderLabel.BackColor = DGV.RowHeadersDefaultCellStyle.BackColor;
                reCreateSumBoxes();
                //处理完再设置datagridview联动事件x
                this.DGV.DataBindingComplete += Dgv_DataBindingComplete;
            }
            catch (Exception ex) {
                CommonGlobalUtil.WriteLog(ex);
            }
        }

        public void Init(DataGridView dgv, String sumRowHeaderText, Object totalRow, string[] summaryColumns)
        {
            ClearEvent();
            if (totalRow != null)
            {
                this.DGV = dgv;
                _SumRowHeaderText = sumRowHeaderText;
                _SummaryColumns = summaryColumns;
                this.TotalRow = totalRow;
                Generate();

            }
            SetEvent();
        }
         
        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        { 
            calcSummaries1(); 
        }
         
        #endregion

        #region 私有方法

        /// <summary>
        /// Checks if passed object is of type of integer
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsInteger(object o)
        {
            if (o is Int64)
            {
                return true;
            }
            if (o is Int32)
            {
                return true;
            }
            if (o is Int16)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if passed object is of type of decimal/ double
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>true/ false</returns>
        protected bool IsDecimal(object o)
        {
            if (o is Decimal)
            {
                return true;
            }
            if (o is Single)
            {
                return true;
            }
            if (o is Double)
            {
                return true;
            }
            return false;
        }

        private void calcSummaries1()
        {
            if (TotalRow != null)
            {
                foreach (ReadOnlyTextBox roTextBox in sumBoxHash.Values)
                {
                    if (roTextBox.IsSummary)
                    {
                        roTextBox.Tag = 0;
                        roTextBox.Text = "0";
                        roTextBox.Invalidate();
                    }
                }

                if (SummaryColumns != null && SummaryColumns.Length > 0 && sumBoxHash.Count > 0)
                {
                    foreach (DataGridViewColumn dgvColumn in sumBoxHash.Keys)
                    {

                        ReadOnlyTextBox sumBox = (ReadOnlyTextBox)sumBoxHash[dgvColumn];

                        if (sumBox != null && sumBox.IsSummary)
                        {
                            if (TotalRow is DataRow)
                            {
                                DataRow dataRow = TotalRow as DataRow;
                                sumBox.Tag = dataRow[dgvColumn.DataPropertyName];
                            }
                            else
                            {
                                sumBox.Tag = ReflectionHelper.GetProperty(TotalRow, dgvColumn.DataPropertyName);
                            }
                           
                                sumBox.Text = string.Format("{0}", sumBox.Tag);
                            if (sumBox.Text=="0" && !ReportShowZero)
                            {
                                sumBox.Text = String.Empty;
                            } 
                            sumBox.Invalidate();

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the Sums of the summary columns
        /// </summary>
        private void calcSummaries()
        {
            foreach (ReadOnlyTextBox roTextBox in sumBoxHash.Values)
            {
                if (roTextBox.IsSummary)
                {
                    roTextBox.Tag = 0;
                    roTextBox.Text = "0";
                    roTextBox.Invalidate();
                }
            }
            
            if (SummaryColumns != null && SummaryColumns.Length > 0 && sumBoxHash.Count > 0)
            {
                foreach (DataGridViewRow dgvRow in DGV.Rows)
                {
                    foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                    {
                        foreach (DataGridViewColumn dgvColumn in sumBoxHash.Keys)
                        {
                            if (dgvCell.OwningColumn.Equals(dgvColumn))
                            {
                                ReadOnlyTextBox sumBox = (ReadOnlyTextBox)sumBoxHash[dgvColumn];

                                if (sumBox != null && sumBox.IsSummary)
                                {
                                    if (dgvCell.Value != null && !(dgvCell.Value is DBNull))
                                    {
                                        if (IsInteger(dgvCell.Value))
                                        {
                                            sumBox.Tag = Convert.ToInt64(sumBox.Tag) + Convert.ToInt64(dgvCell.Value);
                                        }
                                        else if (IsDecimal(dgvCell.Value))
                                        {
                                            sumBox.Tag = Convert.ToDecimal(sumBox.Tag) + Convert.ToDecimal(dgvCell.Value);
                                        } 
                                        sumBox.Text = string.Format("{0}", sumBox.Tag); 
                                        if (sumBox.Text == "0" && !ReportShowZero)
                                        {
                                            sumBox.Text = String.Empty;
                                        }
                                        sumBox.Invalidate();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create summary boxes for each Column of the DataGridView        
        /// </summary>
        private void reCreateSumBoxes()
        {
            foreach (Control control in sumBoxHash.Values)
            {
                this.Controls.Remove(control);
                control.Dispose();
            }
            sumBoxHash = new Hashtable();
            this.Controls.Clear();

            int iCnt = 0;

            ReadOnlyTextBox sumBox;
            List<DataGridViewColumn> sortedColumns = SortedColumns;
            foreach (DataGridViewColumn dgvColumn in sortedColumns)
            {
                sumBox = new ReadOnlyTextBox();
                sumBoxHash.Add(dgvColumn, sumBox);

                sumBox.Top = 0;
                sumBox.Height = DGV.RowTemplate.Height;
                sumBox.BorderColor = DGV.GridColor;
                sumBox.BackColor = DGV.DefaultCellStyle.BackColor;
                sumBox.ForeColor = DGV.DefaultCellStyle.ForeColor;
                sumBox.Width = dgvColumn.Width;
                sumBox.Font = CommonGlobalUtil.DEFAULT_FONT;
                sumBox.BringToFront();

                if (DGV.ColumnCount - iCnt == 1)
                {
                    sumBox.IsLastColumn = true;
                }

                if (SummaryColumns != null && SummaryColumns.Length > 0)
                {
                    for (int iCntX = 0; iCntX < SummaryColumns.Length; iCntX++)
                    {
                        if (SummaryColumns[iCntX] == dgvColumn.DataPropertyName ||
                            SummaryColumns[iCntX] == dgvColumn.Name)
                        {
                            //  sumBox.TextAlign = TextHelper.TranslateGridColumnAligment(dgvColumn.DefaultCellStyle.Alignment);

                            sumBox.TextAlign = HorizontalAlignment.Center;
                            sumBox.IsSummary = true;
                            // sumBox.Font =CommonGlobalUtil.DEFAULT_FONT;
                            sumBox.FormatString = dgvColumn.DefaultCellStyle.Format;

                            if (dgvColumn.ValueType == typeof(System.Int32) || dgvColumn.ValueType == typeof(System.Int16) ||
                                dgvColumn.ValueType == typeof(System.Int64) || dgvColumn.ValueType == typeof(System.Single) ||
                                dgvColumn.ValueType == typeof(System.Double) || dgvColumn.ValueType == typeof(System.Single) ||
                                dgvColumn.ValueType == typeof(System.Decimal))
                            {
                                sumBox.TextAlign = HorizontalAlignment.Right;
                                sumBox.Tag = System.Activator.CreateInstance(dgvColumn.ValueType);
                            }
                        }
                    }
                }

                sumBox.BringToFront();
                this.Controls.Add(sumBox);

                iCnt++;
            }

            sumRowHeaderLabel.Font = new Font(DGV.DefaultCellStyle.Font, FontStyle.Bold);
            sumRowHeaderLabel.Anchor = AnchorStyles.Left;
            sumRowHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            sumRowHeaderLabel.Height = this.Height;
            sumRowHeaderLabel.Width = DGV.RowHeadersWidth;
            sumRowHeaderLabel.Top = 0;
            sumRowHeaderLabel.Text = SumRowHeaderText;
            sumRowHeaderLabel.ForeColor = DGV.DefaultCellStyle.ForeColor;
            sumRowHeaderLabel.Margin = new Padding(0);
            sumRowHeaderLabel.Padding = new Padding(0);
            this.Controls.Add(sumRowHeaderLabel);
            calcSummaries1();
            adjustSumControlToGrid();
            resizeSumBoxes();
        }

        /// <summary>
        /// Order the columns in the way they are displayed
        /// </summary>
        private List<DataGridViewColumn> SortedColumns
        {
            get
            {
                List<DataGridViewColumn> result = new List<DataGridViewColumn>();
                DataGridViewColumn column = DGV.Columns.GetFirstColumn(DataGridViewElementStates.None);
                if (column == null)
                {
                    return result;
                }
                result.Add(column);
                while ((column = DGV.Columns.GetNextColumn(column, DataGridViewElementStates.None, DataGridViewElementStates.None)) != null)
                {
                    result.Add(column);
                }

                return result;
            }
        }

        /// <summary>
        /// Resize the summary Boxes depending on the 
        /// width of the Columns of the DataGridView
        /// </summary>
        private void resizeSumBoxes()
        {
            try
            {
                 this.SuspendLayout();
                if (sumBoxHash != null && sumBoxHash.Count > 0)
                {
                    try
                    {
                        int rowHeaderWidth = DGV.RowHeadersVisible ? DGV.RowHeadersWidth - 1 : 0;
                        int sumLabelWidth = DGV.RowHeadersVisible ? DGV.RowHeadersWidth - 1 : 0;
                        int curPos = rowHeaderWidth;

                        if (sumLabelWidth > 0)
                        {
                            sumRowHeaderLabel.Visible = true;
                            sumRowHeaderLabel.Width = sumLabelWidth;
                            if (DGV.RightToLeft == RightToLeft.Yes)
                            {
                                if (sumRowHeaderLabel.Dock != DockStyle.Right)
                                {
                                    sumRowHeaderLabel.Dock = DockStyle.Right;
                                }
                            }
                            else
                            {
                                if (sumRowHeaderLabel.Dock != DockStyle.Left)
                                {
                                    sumRowHeaderLabel.Dock = DockStyle.Left;
                                }
                            }
                        }
                        else
                        {
                            if (sumRowHeaderLabel.Visible)
                            {
                                sumRowHeaderLabel.Visible = false;
                            }
                        }

                        int iCnt = 0;
                        Rectangle oldBounds;

                        foreach (DataGridViewColumn dgvColumn in SortedColumns)
                        {
                            ReadOnlyTextBox sumBox = (ReadOnlyTextBox)sumBoxHash[dgvColumn];
                            if (sumBox != null)
                            {
                                oldBounds = sumBox.Bounds;
                                if (!dgvColumn.Visible)
                                {
                                    sumBox.Visible = false;
                                    continue;
                                }

                                int from = dgvColumn.Frozen ? curPos : curPos - DGV.HorizontalScrollingOffset;
                                int width = dgvColumn.Width + (iCnt == 0 ? 0 : 0);
                                if (from < rowHeaderWidth)
                                {
                                    width -= rowHeaderWidth - from;
                                    from = rowHeaderWidth;
                                }
                                if (sumBox.IsLastColumn)
                                { 
                                    String test = string.Empty;
                                } 

                                if (width < 4)
                                {
                                    if (sumBox.Visible)
                                    {
                                        sumBox.Visible = false;
                                    }
                                }
                                else
                                {
                                    if (this.RightToLeft == RightToLeft.Yes)
                                    {
                                        from = this.Width - from - width;
                                    }

                                    if (sumBox.Left != from || sumBox.Width != width)
                                    {
                                        sumBox.SetBounds(from, 0, width, 0, BoundsSpecified.X | BoundsSpecified.Width);
                                    }

                                    if (!sumBox.Visible)
                                    {
                                        sumBox.Visible = true;
                                    }
                                }

                                curPos += dgvColumn.Width + (iCnt == 0 ? 0 : 0);
                                if (oldBounds != sumBox.Bounds)
                                {
                                    sumBox.Invalidate();
                                }
                            }
                            iCnt++;
                        }
                    }
                    finally
                    {
                         this.ResumeLayout();
                    }
                }
            }
#if (DEBUG)
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                System.Diagnostics.Debug.WriteLine(ee.ToString());
            }

#else
            catch
            { }
#endif
        }

        #endregion

        #region 事件处理程序
        void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            //     CommonGlobalUtil.Debug("dgv_DataSourceChanged");
            calcSummaries();

        }
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //201 采购进货、采购退货、报损、调拨、补货：修改表中的数量，总计没有跟着改变
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; } 
            calcSummaries();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
         //   CommonGlobalUtil.Debug("dgv_RowsAdded");
            calcSummaries1();
        }
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        //    CommonGlobalUtil.Debug("dgv_RowsRemoved");
            calcSummaries1();
        }

        private void dgv_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
        //    CommonGlobalUtil.Debug("dgv_ColumnDisplayIndexChanged");
            //resizeSumBoxes();
            reCreateSumBoxes();
        }
        private void dgv_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
          //  CommonGlobalUtil.Debug("dgv_ColumnStateChanged");
            resizeSumBoxes();
        }
        private void dgv_Scroll(object sender, ScrollEventArgs e)
        {
          //  CommonGlobalUtil.Debug("dgv_Scroll");
            resizeSumBoxes();
        }
        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
           // CommonGlobalUtil.Debug("dgv_ColumnWidthChanged");
            resizeSumBoxes();
        }
        private void dgv_RowHeadersWidthChanged(object sender, EventArgs e)
        { 
            resizeSumBoxes();
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
          //  CommonGlobalUtil.Debug("dgv_Resize");
            adjustSumControlToGrid();
            resizeSumBoxes();
        }
        private void adjustSumControlToGrid()
        {
            ScrollBar horizontalScrollBar = (ScrollBar)typeof(DataGridView).GetProperty("HorizontalScrollBar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(DGV, null);
            ScrollBar verticalScrollBar = (ScrollBar)typeof(DataGridView).GetProperty("VerticalScrollBar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(DGV, null);
             
            this.Left = DGV.Left; 
            this.Width = DGV.Width;
        }


        private void dgv_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
          //  CommonGlobalUtil.Debug("dgv_ColumnRemoved");
            reCreateSumBoxes();
        }
        private void dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
          //  CommonGlobalUtil.Debug("dgv_ColumnAdded");
            reCreateSumBoxes();
        }

        internal void Unable()
        {
            this.Visible = false;
            this.ClearEvent();
this.DGV.DataSourceChanged -= new EventHandler(dgv_DataSourceChanged);
        }
        #endregion
    }

}
