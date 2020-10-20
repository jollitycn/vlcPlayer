using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using CJBasic.Helpers;
using JGNet.Common.Components;

namespace JGNet.Common.Core.Helpers
{
    /// <summary>
    /// 数据报表帮助类。
    /// 2018.04.17
    /// </summary>
    public class DataGridViewHelper
    {
        public const string EMPTY_ROW_HEADER = "无";

        /// <summary>
        /// 为数据报表增加一个汇总行。
        /// </summary>
        /// <typeparam name="T">报表记录对象的类型</typeparam>
        /// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        /// <param name="statColumns">需要进行统计的列</param>
        /// <param name="abs4Column">对目标列进行统计时，是否取其绝对值进行统计</param>
        /// <param name="isDisplayColumn">是否显示列</param>
        /// <param name="DistinguishSize">区分是否是尺码列</param>
        public static void AddSumRow1<T>(DataGridView dgw, IList<T> list, IList<T> calList, string[] statColumns, bool[] abs4Column,bool isDisplayColumn=true,bool DistinguishSize=true) where T : new()
        {
            T sum = new T();
            try
            {
                IStatisticabled obj = sum as IStatisticabled;
                if (obj != null)
                {
                    obj.IsStatistics = true;
                }

                for (int i = 0; i < statColumns.Length; i++) //针对每一个汇总项
                {
                    string column = statColumns[i];
                    decimal total = 0;

                    if (list != null)
                    {
                        foreach (T t in list) //统计
                        {
                            object val = ReflectionHelper.GetProperty(t, column);
                            if (abs4Column == null || abs4Column.Length == 0 || !abs4Column[i])
                            {
                                total += decimal.Parse(val.ToString());
                            }
                            else
                            {
                                total += Math.Abs(decimal.Parse(val.ToString()));
                            }
 
                        }
                    }
                    //648 销售单查询：总计中销售额出现计算错误。
                    total = Math.Round(total, 2, MidpointRounding.AwayFromZero);
                    Type type = typeof(T);
                    PropertyInfo info = type.GetProperty(column);
                    object newTotal = TypeHelper.ChangeType(info.PropertyType, total);
                    ReflectionHelper.SetProperty(sum, column, newTotal);

                    foreach (DataGridViewColumn item in dgw.Columns)
                    {
                        if (item.DataPropertyName == column)
                        {
                            if (DistinguishSize == false)
                            {
                                if (total == 0 && isDisplayColumn == false)
                                {
                                    item.Visible = false;
                                    break;

                                }
                                else
                                {
                                    item.Visible = true;
                                    break;
                                }
                            }
                        }
                    }
                  
                    
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.WriteLog(ex);
            }
            calList.Add(sum);
        }



        ///// <summary>
        ///// 为数据报表增加一个汇总行。
        ///// </summary>
        ///// <typeparam name="T">报表记录对象的类型</typeparam>
        ///// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        ///// <param name="statColumns">需要进行统计的列</param>
        ///// <param name="abs4Column">对目标列进行统计时，是否取其绝对值进行统计</param>
        //public static void AddSumRow<T>(List<T> list, string[] statColumns ,bool[] abs4Column) where T : new()
        //{
        //    T sum = new T();
        //    IStatisticabled obj = sum as IStatisticabled;
        //    if (obj != null)
        //    {
        //        obj.IsStatistics = true;
        //    }

        //    for (int i=0;i<statColumns.Length;i++) //针对每一个汇总项
        //    {
        //        string column = statColumns[i];
        //        double total = 0;
        //        foreach (T t in list) //统计
        //        {
        //            object val = ReflectionHelper.GetProperty(t, column);
        //            if (abs4Column == null || abs4Column.Length ==0 || !abs4Column[i])
        //            {
        //                total += double.Parse(val.ToString());
        //            }
        //            else
        //            {
        //                total += Math.Abs(double.Parse(val.ToString()));
        //            }
        //        }
        //        object newTotal = TypeHelper.ChangeType(typeof(T).GetProperty(column).PropertyType, total);
        //        ReflectionHelper.SetProperty(sum, column, newTotal);
        //    }           
        //    list.Add(sum);
        //}

        ///// <summary>
        ///// 为数据报表增加一个汇总行。
        ///// </summary>
        ///// <typeparam name="T">报表记录对象的类型</typeparam>
        ///// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        ///// <param name="statColumns">需要进行统计的列</param>
        //public static void AddSumRow<T>(List<T> list, params string[] statColumns) where T : new()
        //{
        //    DataGridViewHelper.AddSumRow<T>(list, statColumns, null);
        //}

        public static void SetCellContentEmpty(DataGridViewRow row, string[] cols, DataGridViewCellStyle emptyStyle)
        {
            List<string> statColumns = new List<string>(cols);
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (!statColumns.Contains(row.DataGridView.Columns[cell.ColumnIndex].DataPropertyName))
                {
                    cell.Value = null;
                    cell.Style = emptyStyle;
                }

                DataGridViewLinkCell link = cell as DataGridViewLinkCell;
                if (link != null)
                {
                    link.UseColumnTextForLinkValue = false;
                }
            }
        }

        /// <summary>
        /// 绑定数据报表。并为其增加【小计】【总计】行。
        /// </summary>
        /// <typeparam name="T">报表记录对象的类型</typeparam>
        /// <param name="dgw">要绑定的DataGridView</param>        
        /// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        /// <param name="statColumns">需要进行统计的列</param>
        /// <param name="totalRow">在有分页的情况下，【总计】的行对象</param>
        /// <param name="abs4Column">对目标列进行统计时，是否取其绝对值进行统计</param>
        /// <param name="isDisplayCol">是否显示列</param>
        /// <param name="DistinguishSize">区分是否是尺码列</param>
        public static void BindSource4Reports<T>(DataGridViewPagingSumCtrl ctrl,DataGridView dgw, IList<T> orgList, string[] statColumns, T totalRow, bool[] abs4Column,bool isPaging,bool isDisplayCol=true,bool DistinguishSize=true) where T : class, new()
        {

            ctrl.ClearSummary();
            ctrl.abs4Column = abs4Column;
            if (orgList == null || orgList.Count == 0 )
            {
                orgList = null;
                ctrl.SetDataSource(orgList, isDisplayCol, DistinguishSize);
                return;
            }
            if (statColumns == null || statColumns.Length == 0)
            {
                ctrl.SetDataSource(orgList, isDisplayCol, DistinguishSize);
                return;
            }

           // List<T> list = new List<T>();
            List<T> calList = new List<T>();

          //  list.AddRange(orgList); 
            Type type = typeof(T);
            foreach (string column in statColumns)
            {
                PropertyInfo pro = type.GetProperty(column);
                if (pro == null)
                {
                    throw new Exception(string.Format("Class [{0}] does not contain property [{1}] .", CJBasic.Helpers.TypeHelper.GetClassSimpleName(type), column));
                }

                if (!pro.CanRead || !pro.CanWrite)
                {
                    throw new Exception(string.Format("Property [{0}] of class [{1}] must be readable and writable.", column, CJBasic.Helpers.TypeHelper.GetClassSimpleName(type)));
                }
            }

            if (isPaging) { 
                AddSumRow1(dgw, orgList, calList, statColumns, abs4Column);
            }
            if (totalRow != null)
            {
                IStatisticabled obj = totalRow as IStatisticabled;
                if (obj != null)
                {
                    obj.IsStatistics = true;
                }
                calList.Add(totalRow);
            }

            if (dgw.RowHeadersWidth < 70)
            {
                dgw.RowHeadersWidth = 70;
            }

            ctrl.SetDataSource(orgList, isDisplayCol, DistinguishSize);
            ctrl.ShowSummary(dgw, calList, statColumns);
        }

        /// <summary>
        /// 绑定数据报表。并为其增加【小计】【总计】行。
        /// </summary>
        /// <typeparam name="T">报表记录对象的类型</typeparam>
        /// <param name="dgw">要绑定的DataGridView</param>        
        /// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        /// <param name="statColumns">需要进行统计的列</param>     
        /// <param name="totalRow">在有分页的情况下，【总计】的行对象</param>
        public static void BindSource4Reports<T>(DataGridViewPagingSumCtrl ctrl, DataGridView dgw, IList<T> list, string[] statColumns, T totalRow, bool isPaging,bool isDisplayCol=true,bool DistinguishSize =true) where T : class ,new()
        {
            DataGridViewHelper.BindSource4Reports<T>(ctrl,dgw, list, statColumns, totalRow, null, isPaging, isDisplayCol, DistinguishSize);
        }

        /// <summary>
        /// 绑定数据报表。并为其增加【小计】【总计】行。
        /// </summary>
        /// <typeparam name="T">报表记录对象的类型</typeparam>
        /// <param name="dgw">要绑定的DataGridView</param>        
        /// <param name="list">数据行对象列表。执行完成后，将在该列表的最后添加一个【小计】对象。</param>
        /// <param name="statColumns">需要进行统计的列</param>     
        public static void BindSource4Reports<T>(DataGridViewPagingSumCtrl ctrl, DataGridView dgw, IList<T> list, bool isPaging,params string[] statColumns ) where T : class, new()
        {
            DataGridViewHelper.BindSource4Reports<T>(ctrl, dgw, list, statColumns, null, null, isPaging);
        }
    }

    ///// <summary>
    ///// 可被统计的对象的基础接口。
    ///// </summary>
    //public interface IStatisticabled
    //{
    //    /// <summary>
    //    /// 是否为统计行对象。
    //    /// </summary>
    //    bool IsStatistics { set; get; }
    //}
}
