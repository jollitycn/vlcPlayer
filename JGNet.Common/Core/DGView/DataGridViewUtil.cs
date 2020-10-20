using CJBasic;
using CJBasic.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataGridView;

namespace JGNet.Common.Core.Util
{
    public static class DataGridViewUtil
    {

        public static List<T> BindingListToList<T>(Object obj)
        {
            List<T> list = new List<T>((SortableBindingList<T>)obj);
            return list;
        }

        public static IList<T> ListToBindingList<T>(List<T> list)
        {
            if (list == null)
            {
                return null;
            }
            else
            {
                IList<T> sbList = new SortableBindingList<T>(list);
                return sbList;
            }
        }
        public static bool CheckPerMission(Control basecontrol, RolePermissionMenuEnum CurMenuEnum, RolePermissionEnum CurPermissionEnum)
        {
            List<RolePermissionEnum> permissons = JGNet.Core.Tools.EnumHelper.GetEnumList<RolePermissionEnum>();

            if (permissons.Contains(CurPermissionEnum))
            {
                if (basecontrol is BaseUserControl)
                {
                    if (!(basecontrol as BaseUserControl).HasPermission(CurMenuEnum,CurPermissionEnum))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (basecontrol is BaseForm)
                {
                    if (!(basecontrol as BaseForm).HasPermission(CurMenuEnum,CurPermissionEnum))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
                return false;
        }

        public static bool CheckPerrmisson(Control baseControl, object sender, DataGridViewCellEventArgs e)
        {
            bool value = true;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return true; }
            DataGridView view = sender as DataGridView;
            List<RolePermissionEnum> permissons = JGNet.Core.Tools.EnumHelper.GetEnumList<RolePermissionEnum>();
            DataGridViewColumn column = view.Columns[e.ColumnIndex];
            if (column is DataGridViewLinkColumn)
            {
                foreach (RolePermissionEnum p in permissons)
                {
                    if (!CheckWithPermisson(column, p)) {
                        continue;
                    }
                    //column.Tag = p;

                    if (baseControl is BaseUserControl)
                    {
                        if (!(baseControl as BaseUserControl).HasPermission(p))
                        {
                            value = false;
                            GlobalMessageBox.Show("您没有权限进行此操作，请联系管理员授权！");
                            break;
                        }
                    }
                    else if (baseControl is BaseForm)
                    {
                        if (!(baseControl as BaseForm).HasPermission(p))
                        {
                            value = false;
                            GlobalMessageBox.Show("您没有权限进行此操作，请联系管理员授权！");
                            break;
                        }
                    }
                }
            }
            return value;
        }

        private static bool CheckWithPermisson(DataGridViewColumn column, RolePermissionEnum p)
        {
            return ((column.HeaderText == "打印条码" || column.HeaderText == "打印" || column.HeaderText == "打印小票") && p == RolePermissionEnum.打印) ||
                 (( column.HeaderText == "修改密码" || column.HeaderText == "修改") && p == RolePermissionEnum.编辑)||
                     ((column.HeaderText == "设置日目标" ) && p == RolePermissionEnum.编辑) ||
                        ((column.HeaderText == "取消禁用" || column.HeaderText == "禁用" || column.HeaderText == "启用") && p == RolePermissionEnum.编辑) ||
            column.HeaderText == JGNet.Core.Tools.EnumHelper.GetDescription(p);
        }


    public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
            BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        /// <summary> 
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="whiteSmoke"></param>
        /// <param name="white"></param>
        public static void SetAlternatingColor(DataGridView dataGridView1, Color rowColor, Color alternateColor)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = rowColor;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = alternateColor;
        }

        public static List<T> DataTableConvertToList<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        /// <summary>
        /// 内容为0时设置为空字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="reportShowZero"></param>
        public static void CellFormatting_ReportShowZero(DataGridViewCellFormattingEventArgs e, bool reportShowZero)
        {
            if (!reportShowZero)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }
                if (e.Value == null) { return; }
                if (e.Value.ToString().Equals("0")) { e.Value = null; }
            }
        }

        public static List<T> ConvertTo<T>(List<DataRow> rows)
        {
            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }



        internal static void CellValidated_setSumRows(DataGridView sender, DataGridViewCellEventArgs e, bool isMutiplePage)
        {
            DataGridView dv = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dv.RowCount < 0) { return; }
            int rows = isMutiplePage ? 2 : 1;
            if ((dv.RowCount - rows) == e.RowIndex)
            {
                DataGridViewRow row = null;
                if (isMutiplePage)
                {
                    row = dv.Rows[dv.RowCount - 2];
                    row.HeaderCell.Value = "小计";
                    row.HeaderCell.Style.Font = new Font(dv.Font, FontStyle.Bold);
                    row.DefaultCellStyle.Font = new Font(dv.Font, FontStyle.Bold);
                    //row.Frozen = true;
                }
                row = dv.Rows[dv.RowCount - 1];
                row.HeaderCell.Value = "总计";
                row.HeaderCell.Style.Font = new Font(dv.Font, FontStyle.Bold);
                row.DefaultCellStyle.Font = new Font(dv.Font, FontStyle.Bold);
                // row.Frozen = true;
            }
        }


        /// <summary>
        /// 获取VS.Net 2005 DataGridView控件的列宽。
        /// </summary>
        /// <param name="dataGridView">VS.Net 2005 DataGridView控件。</param>
        /// <returns>列宽数组。</returns>
        public static int[] GetColsMinimumWidth(DataGridView dataGridView)
        {
            #region 实现...

            int[] arrReturn = null;

            int colsCount = dataGridView.ColumnCount;

            arrReturn = new int[colsCount];
            for (int i = 0; i < colsCount; i++)
            {
                arrReturn[i] = dataGridView.Columns[i].MinimumWidth;
            }

            return arrReturn;

            #endregion 实现
        }

        /// <summary>
        /// 获取VS.Net 2005 DataGridView控件的列宽。
        /// </summary>
        /// <param name="dataGridView">VS.Net 2005 DataGridView控件。</param>
        /// <returns>列宽数组。</returns>
        public static int[] GetColsWidth(DataGridView dataGridView)
        {
            #region 实现...

            int[] arrReturn = null;

            int colsCount = dataGridView.ColumnCount;

            arrReturn = new int[colsCount];
            for (int i = 0; i < colsCount; i++)
            {
                arrReturn[i] = dataGridView.Columns[i].Width;
            }

            return arrReturn;

            #endregion 实现
        }

        /// <summary>
        /// 将VS.Net 2005 DataGridView控件的数据导出到二维数组。
        /// </summary>
        /// <param name="dataGridView">VS.Net 2005 DataGridView控件。</param>
        /// <param name="includeColumnText">是否要把列标题文本也导到数组中。</param>
        /// <remarks>
        ///  <作者>长江支流</作者>
        ///  <日期>2005-12-14</日期>
        ///  <修改></修改>
        /// </remarks>
        /// <returns>二维数组。</returns>
        public static string[,] ToStringArray(DataGridView dataGridView, bool includeColumnText, bool zeroToEmpty)
        {
            #region 实现...

            string[,] arrReturn = null;

            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {

                if (item is DataGridViewTextBoxColumn && item.Visible)
                {
                    columns.Add(item);
                }
            }

            int rowsCount = dataGridView.Rows.Count;
            int colsCount = columns.Count;

            if (rowsCount > 0)
            {
                //最后一行是供输入的行时，不用读数据。
                if (dataGridView.Rows[rowsCount - 1].IsNewRow)
                {
                    rowsCount--;
                }

            }

            if (rowsCount > 1)
            {
                if (dataGridView.Rows[rowsCount - 1].HeaderCell.Value == null) {
                    dataGridView.Rows[rowsCount - 1].HeaderCell.Value = 0;
                }
                //增加去除统计信息
                if ("总计" == dataGridView.Rows[rowsCount - 1].HeaderCell.Value.ToString())
                {
                    rowsCount--;
                }
                if (rowsCount > 2)
                {
                    if (dataGridView.Rows[rowsCount - 2].HeaderCell.Value == null) {
                        dataGridView.Rows[rowsCount - 2].HeaderCell.Value = 0;
                    }
                    if ("小计" == dataGridView.Rows[rowsCount - 2].HeaderCell.Value.ToString())
                    {
                        rowsCount--;
                    }
                }
            }

            int i = 0;

            //包括列标题
            if (includeColumnText)
            {
                rowsCount++;
                arrReturn = new string[rowsCount, colsCount];
                for (i = 0; i < colsCount; i++)
                {
                    arrReturn[0, i] = columns[i].HeaderText;
                }

                i = 1;
            }
            else
            {
                arrReturn = new string[rowsCount, colsCount];
            }

            //读取单元格数据
            int rowIndex = 0;
            for (; i < rowsCount; i++, rowIndex++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells[columns[j].Index];
                    object obj = cell.Value;


                    if (cell.ValueType == typeof(System.Int32) || cell.ValueType == typeof(System.Int16) ||
                        cell.ValueType == typeof(System.Int64) || cell.ValueType == typeof(System.Single) ||
                        cell.ValueType == typeof(System.Double) ||
                        cell.ValueType == typeof(System.Decimal))
                    {
                        obj = obj?.ToString();
                        if (zeroToEmpty && obj.Equals("0"))
                        {
                            arrReturn[i, j] = String.Empty;
                        }
                        else
                        {
                            arrReturn[i, j] = obj?.ToString();
                        }
                    }
                    else
                    {
                        arrReturn[i, j] = obj?.ToString();
                    }
                }
            }

            return arrReturn;

            #endregion 实现
        }


        /// <summary>
        /// 根据datagridview转换为datagridview对应列的ToDataTable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView2"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(DataGridView dataGridView) where T : new()
        {
            IEnumerable<T> collection = (IEnumerable<T>)dataGridView.DataSource;
            if (collection == null) { return null; }

            //过滤掉
            var props = typeof(T).GetProperties();
            List<PropertyInfo> orgProps = new List<PropertyInfo>(props);
            List<PropertyInfo> properties = new List<PropertyInfo>();

            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                if (item is DataGridViewTextBoxColumn && item.Visible)
                {
                    PropertyInfo prop = orgProps.Find(p => p.Name == item.DataPropertyName);
                    properties.Add(prop);
                    //头只能是字符串
                    // ReflectionHelper.SetProperty(titles, prop.Name, item.HeaderText); 
                    //   ReflectionHelper.SetProperty(titles, "m_Price", item.HeaderText);
                }
            }
            var dt = new DataTable();
            //包括标题所以只使用字符串类型
            properties.ForEach(p => dt.Columns.Add(new DataColumn(p.Name, typeof(String))));
            //添加头
            ArrayList titles = new ArrayList();
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {

                if (item is DataGridViewTextBoxColumn && item.Visible)
                {
                    titles.Add(item.HeaderText);
                }
            }

            object[] arrayTitles = titles.ToArray();
            dt.LoadDataRow(arrayTitles, true);
            List<T> cols = new List<T>(collection);
            if (cols.Count > 0)
            {
                for (int i = 0; i < cols.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in properties)
                    {
                        object obj = pi.GetValue(cols[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        public static void ScrollToRowIndex(DataGridView dataGridView, int index)
        {
            try
            {
                if (dataGridView != null && dataGridView.RowCount > 0)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = index;
                    // dataGridView.Rows[dataGridView.Rows.Count - 1].Index;
                    dataGridView.Rows[0].Selected = false;
                    dataGridView.Rows[index].Selected = true;
                    // 强制显示当前行
                    dataGridView.CurrentCell = dataGridView[0, index];
                    dataGridView.CurrentCell.Selected = true;
                    dataGridView.Rows[index].Selected = true;
                }
            }
            catch (Exception ex) {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        public static void AutoFocusToFirstWritableCell(DataGridView dataGridView, int rowIndex)
        {
            DataGridViewCell writableCell = null;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.ReadOnly && cell.Visible)
                    {
                        if (row.Index == rowIndex)
                        {
                            writableCell = cell;
                            break;
                        }
                    }
                }
                if (writableCell != null)
                {
                    break;
                }
            }
            if (writableCell != null)
            {
                // dataGridView.BeginEdit(true); //设置可编辑状态
                dataGridView.Focus();
                dataGridView.CurrentCell = writableCell; //设置当前单元格
                dataGridView.BeginEdit(true);
            }
        }

        /// <summary>
        /// 自动定焦点到指定的可写单元格内
        /// </summary>
        public static void AutoFocusToFirstWritableCell(DataGridView dataGridView)
        {

            DataGridViewCell writableCell = null;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.ReadOnly && cell.Visible)
                    {

                        writableCell = cell;
                        break;
                    }

                }
                if (writableCell != null)
                {
                    break;
                }
            }
            if (writableCell != null)
            {
                // dataGridView.BeginEdit(true); //设置可编辑状态
                dataGridView.Focus();
                dataGridView.CurrentCell = writableCell; //设置当前单元格
                dataGridView.BeginEdit(true);
            }
        }


        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {  //You can log something here     
                       //throw;    
                    }
                }
            }

            return obj;
        }

        public static DataRow GetSumRow(DataTable dt, String[] columnNames)
        {
            DataRow dr = null;

            if (dt != null)
            {
                dr = dt.NewRow();
                // dr[0] = "合计";
                //小计
                foreach (var c in columnNames)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dc = dt.Columns[i];
                        if (dc.ColumnName.ToUpper().Equals(c.ToUpper()))
                        {
                            object value = dt.Compute("Sum(" + dc.ColumnName + ")", "");
                            if (value is double)
                            {

                                dr[i] = Math.Round((double)value, 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dr[i] = value;
                            }
                        }
                    }
                }
            }
            return dr;

        }
        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            if (collection == null) { return null; }
            var props = typeof(T).GetProperties();

            List<PropertyInfo> orgProps = new List<PropertyInfo>(props);
            var dt = new DataTable(typeof(T).Name);
            orgProps.ForEach(p =>
               dt.Columns.Add(new DataColumn(p.Name, p.PropertyType)));
            List<T> cols = new List<T>(collection);
            if (cols.Count > 0)
            {
                for (int i = 0; i < cols.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        //每一列的值
                        object obj = pi.GetValue(cols[i], null);
                        tempList.Add(obj);
                    }

                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }



            return dt;
        }


        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// 调用这个selectIndexChange的时候需要使用CELL来获取row
        /// </summary>
        /// <param name="view"></param>
        public static void SelectLastRow(DataGridView view)
        {
            if (view != null && view.Rows.Count > 0)
            {
                view.CurrentCell = view.Rows[view.Rows.Count - 1].Cells[0];
            }
        }

        public static void ColumnHeaderMouseClick_Sort(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView gridView = (DataGridView)sender;


            //取得点击列的索引

            HitTestInfo test = gridView.HitTest(e.X, e.Y);
            int nColumnIndex = test.ColumnIndex;
            if (nColumnIndex != -1)
            {
                if (gridView.Columns[nColumnIndex].SortMode != DataGridViewColumnSortMode.Programmatic)
                {
                    return;
                }
                switch (gridView.Columns[nColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.None:
                    case SortOrder.Ascending:
                        //在这里加入排序的逻辑
                        //设置列标题的状体 
                        gridView.Columns[nColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                        break;
                    default:
                        gridView.Columns[nColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                        break;
                }
            }
        }

        internal static void CellFormatting_Style(DataGridView view, DataGridViewCellFormattingEventArgs e)
        {
            int i = e.ColumnIndex;
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || view.RowCount < 0) { return; }

            //   
            if (view.Columns[i].ValueType == typeof(String))
            {
                view.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
                if (view.Columns[i].ValueType == typeof(DateTime))
            {
                view.Columns[i].DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;
                view.Columns[i].ValueType = typeof(String);
            }
            else
                if (view.Columns[i].ValueType == typeof(Date))
            {
                view.Columns[i].DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATE_FORMAT;
            }
            else
                if (view.Columns[i].ValueType == typeof(decimal) || view.Columns[i].ValueType == typeof(int) || view.Columns[i].ValueType == typeof(Double))
            {
                view.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        public static void CellPainting_SetCellFont(DataGridView dataGridView, DataGridViewCell cell, int columnIndexFrom, int columnIndexTo, Color foreColor, FontStyle fontStyle)
        {
            if (cell.ColumnIndex >= columnIndexFrom && cell.ColumnIndex <= columnIndexTo)
            {
                if (cell.Value == null || String.IsNullOrEmpty(cell.Value.ToString()))
                {

                    return;
                }
                if (cell.Value is Int16)
                {
                    int newCount = int.Parse(cell.Value.ToString());
                    if (newCount == 0)
                    {
                        cell.Style.ForeColor = Color.Black;
                        cell.Style.Font = new Font(
                        dataGridView.DefaultCellStyle.Font, FontStyle.Regular);
                    }
                    else
                    {

                        cell.Style.ForeColor = foreColor;
                        cell.Style.Font = new Font(
                  dataGridView.DefaultCellStyle.Font, fontStyle);
                    }
                }
            }

        }


        internal static void RowPostPaint_SetAlternatingRowHeader(DataGridView dataGridView1, int rowIndex, string defaultRowHeader, string alternatingRowHeader)
        {
            if (rowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[rowIndex];


            if (row.Index % 2 == 0)
            {
                row.ReadOnly = true;
                row.HeaderCell.Value = defaultRowHeader;


            }
            else
            {
                row.ReadOnly = false;
                row.HeaderCell.Value = alternatingRowHeader;

            }
        }

        internal static void CellFormatting_setSumRows(DataGridView view, DataGridViewCellFormattingEventArgs e)
        {
            if (view.RowCount > 2 && view.RowCount - 2 == e.RowIndex)
            {
                DataGridViewRow row1 = view.Rows[view.RowCount - 2];
                row1.HeaderCell.Value = "小计";
                row1.DefaultCellStyle.Font = new Font(view.Font, FontStyle.Bold);
                row1.HeaderCell.Style.Font = new Font(view.Font, FontStyle.Bold);
                //   row1.Frozen = true;
                row1 = view.Rows[view.RowCount - 1];
                row1.HeaderCell.Value = "总计";
                row1.HeaderCell.Style.Font = new Font(view.Font, FontStyle.Bold);
                row1.DefaultCellStyle.Font = new Font(view.Font, FontStyle.Bold);
                //   row1.Frozen = true;
            }
        }

        internal static void AddDataRow<T>(DataTable dt, T pageSumEntity) where T : new()
        {
            if (pageSumEntity == null) { return; }
            DataRow dr = dt.NewRow();
            var props = typeof(T).GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                PropertyInfo pi = props[i];
                dr[i] = pi.GetValue(pageSumEntity, null);

            }
            dt.Rows.Add(dr);
        }

        internal static DataRow ToDataRow<T>(T pageSumEntity) where T : new()
        {
            throw new NotImplementedException();
        }
    }
}
