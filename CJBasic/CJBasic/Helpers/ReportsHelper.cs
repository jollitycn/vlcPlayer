namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    public static class ReportsHelper
    {
        public static void AddSumRow<T>(List<T> list, params string[] statColumns) where T: new()
        {
            AddSumRow<T>(list, statColumns, null);
        }

        public static void AddSumRow<T>(List<T> list, string[] statColumns, bool[] abs4Column) where T: new()
        {
            T local = new T();
            IStatisticabled statisticabled = local as IStatisticabled;
            if (statisticabled != null)
            {
                statisticabled.IsStatistics = true;
            }
            for (int i = 0; i < statColumns.Length; i++)
            {
                string propertyName = statColumns[i];
                double val = 0.0;
                foreach (T local2 in list)
                {
                    object property = ReflectionHelper.GetProperty(local2, propertyName);
                    if (!(((abs4Column != null) && (abs4Column.Length != 0)) && abs4Column[i]))
                    {
                        val += double.Parse(property.ToString());
                    }
                    else
                    {
                        val += Math.Abs(double.Parse(property.ToString()));
                    }
                }
                object proValue = TypeHelper.ChangeType(typeof(T).GetProperty(propertyName).PropertyType, val);
                ReflectionHelper.SetProperty(local, propertyName, proValue);
            }
            list.Add(local);
        }

        public static void BindSource4Reports<T>(DataGridView dgw, List<T> list, params string[] statColumns) where T: class, new()
        {
            BindSource4Reports<T>(dgw, list, statColumns, default(T), null);
        }

        public static void BindSource4Reports<T>(DataGridView dgw, List<T> list, string[] statColumns, T totalRow) where T: class, new()
        {
            BindSource4Reports<T>(dgw, list, statColumns, totalRow, null);
        }

        public static void BindSource4Reports<T>(DataGridView dgw, List<T> list, string[] statColumns, T totalRow, bool[] abs4Column) where T: class, new()
        {
            if ((((list != null) && (list.Count != 0)) && (statColumns != null)) && (statColumns.Length != 0))
            {
                System.Type t = typeof(T);
                foreach (string str in statColumns)
                {
                    PropertyInfo property = t.GetProperty(str);
                    if (property == null)
                    {
                        throw new Exception(string.Format("Class [{0}] does not contain property [{1}] .", TypeHelper.GetClassSimpleName(t), str));
                    }
                    if (!(property.CanRead && property.CanWrite))
                    {
                        throw new Exception(string.Format("Property [{0}] of class [{1}] must be readable and writable.", str, TypeHelper.GetClassSimpleName(t)));
                    }
                }
                AddSumRow<T>(list, statColumns, abs4Column);
                if (totalRow != null)
                {
                    IStatisticabled statisticabled = totalRow as IStatisticabled;
                    if (statisticabled != null)
                    {
                        statisticabled.IsStatistics = true;
                    }
                    list.Add(totalRow);
                }
                if (dgw.RowHeadersWidth < 0x41)
                {
                    dgw.RowHeadersWidth = 0x41;
                }
                dgw.DataSource = list;
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Font = new Font(dgw.DefaultCellStyle.Font.Name, dgw.DefaultCellStyle.Font.Size, FontStyle.Bold);
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgw.RowHeadersDefaultCellStyle = style;
                dgw.Rows[list.Count - 1].HeaderCell.Value = "总计";
                dgw.Rows[list.Count - 1].DefaultCellStyle = style;
                DataGridViewCellStyle emptyStyle = new DataGridViewCellStyle();
                emptyStyle.ForeColor = Color.Transparent;
                emptyStyle.SelectionForeColor = Color.Transparent;
                SetCellContentEmpty<T>(dgw.Rows[list.Count - 1], statColumns, emptyStyle);
                if (totalRow != null)
                {
                    dgw.Rows[list.Count - 2].HeaderCell.Value = "小计";
                    dgw.Rows[list.Count - 2].DefaultCellStyle = style;
                    SetCellContentEmpty<T>(dgw.Rows[list.Count - 2], statColumns, emptyStyle);
                }
            }
        }

        private static void SetCellContentEmpty<T>(DataGridViewRow row, string[] cols, DataGridViewCellStyle emptyStyle)
        {
            List<string> list = new List<string>(cols);
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (!list.Contains(row.DataGridView.Columns[cell.ColumnIndex].DataPropertyName))
                {
                    cell.Value = null;
                    cell.Style = emptyStyle;
                }
                DataGridViewLinkCell cell2 = cell as DataGridViewLinkCell;
                if (cell2 != null)
                {
                    cell2.UseColumnTextForLinkValue = false;
                }
            }
        }
    }
}

