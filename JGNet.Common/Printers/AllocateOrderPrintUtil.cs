using JGNet.Common.Core.Util.IO.Print;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using JGNet.Common;
using GoldPrinter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;
using System.Windows.Forms;
using System.Data;

namespace JGNet.Common.Core.Util
{
    public class AllocateOrderPrintUtil
    {
        public static String PrinterNoCount = "PrinterNoCount";

        //简单打印示例
        public static void Print(AllocateOrder item, DataGridView dataGridView2, int times = 1)
        {
            InteractResult<PrintTemplateInfo> result = CommonGlobalCache.ServerProxy.GetPrintTemplateInfo(PrintTemplateType.AllocateOrder);

            //GoldPrinter.MisGoldPrinter misGoldPrinter = new GoldPrinter.MisGoldPrinter(false, new PrinterMargins(20, 20, 20, 20, 800, 1129));
            //misGoldPrinter.Title = "调拨单";                           //主标题（C#用\n表示换行）	
            //misGoldPrinter.Caption = "";
            if (result.ExeResult == ExeResult.Success)
            {
                PrintTemplateInfo CurrentPTemplate = result.Data;
                for (int c = 0; c < CurrentPTemplate.PrintCount; c++)
                {
                    GoldPrinter.MisGoldPrinter misGoldPrinter = new GoldPrinter.MisGoldPrinter(false, new PrinterMargins(20, 20, 20, 20, 800, 1129));
                    if (CurrentPTemplate.OrderName != "")
                    {
                        misGoldPrinter.Title = CurrentPTemplate.OrderName; //主标题（C#用\n表示换行）	}

                        misGoldPrinter.Caption = "";

                        double headRow = Math.Round(Convert.ToSingle(CurrentPTemplate.SystemVariables.Count / 2));

                        Header header = new Header(Convert.ToInt32(headRow) + 1, 2);
                        header.IsDrawAllPage = true;

                        CommonGlobalUtil.WriteLog("变量总数=" + CurrentPTemplate.SystemVariables.Count + "\r\n" + "应显示行号=" + headRow + 1);
                        for (int i = 0; i < CurrentPTemplate.SystemVariables.Count; i++)
                        {
                            int curR = 0;
                            if (i < 2)
                            {
                                curR = 0;
                            }
                            else
                            {
                                double resRow = i / 2;
                                curR = Convert.ToInt32(Math.Round(resRow));
                            }
                            string KeyStr = "";
                            if (CurrentPTemplate.SystemVariables[i] == "单号")
                            {
                                KeyStr = "调拨单号：";
                                header.SetText(curR, i % 2, CurrentPTemplate.SystemVariables[i] + item.ID);
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "开单员")
                            {
                                KeyStr = "开 单 员：";
                                header.SetText(curR, i % 2, KeyStr + CommonGlobalCache.GetUserName(item.SourceUserID));
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "开单时间")
                            {
                                KeyStr = "开单时间：";
                                header.SetText(curR, i % 2, KeyStr + item.CreateTime.GetDateTimeFormats('f')[0].ToString());
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "发货方")
                            {
                                KeyStr = "发 货 方：";
                                header.SetText(curR, i % 2, KeyStr + CommonGlobalCache.GetShopName(item.SourceShopID));
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "收货方")
                            {
                                KeyStr = "收 货 方：";
                                header.SetText(curR, i % 2, KeyStr + CommonGlobalCache.GetShopName(item.DestShopID));
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "总数量")
                            {
                                KeyStr = "总 数 量：";
                                header.SetText(curR, i % 2, KeyStr + item.TotalCount.ToString());
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "总金额")
                            {
                                KeyStr = "总 金 额：";
                                header.SetText(curR, i % 2, KeyStr + item.TotalPrice.ToString());
                            }
                            else if (CurrentPTemplate.SystemVariables[i] == "单据备注")
                            {
                                KeyStr = "备    注：";
                                header.SetText(curR, i % 2, KeyStr + item.Remarks.ToString());
                            }

                        }

                        //行列数基本不受限制，但超过一页失去意义，因为以Body为主，以其它为辅
                        //header.IsDrawAllPage = true;                        //可以指定每页是否重复打印
                        //header.SetText(0, 0, "调拨单号：" + item.ID);
                        //header.SetText(0, 1, "开 单 员：" + CommonGlobalCache.GetUserName(item.SourceUserID));
                        //header.SetText(0, 2, "开单时间：" + item.CreateTime.GetDateTimeFormats('f')[0].ToString());                        //DataSource可以是字符串、一维数组、二维数组、DataTable、WinDataGrid、WebDataGrid、ListView\ListView、

                        //header.SetText(1, 0, "发 货 方：" + CommonGlobalCache.GetShopName(item.SourceShopID));
                        //header.SetText(1, 1, "收 货 方：" + CommonGlobalCache.GetShopName(item.DestShopID));               //同仁们还可以根据实际应用对GridBase的DataSource进行扩展
                        //header.SetText(1, 2, String.Empty);

                        //header.SetText(2, 0, "总 数 量：" + item.TotalCount.ToString());
                        //header.SetText(2, 1, "总 金 额：" + item.TotalPrice.ToString());                //同仁们还可以根据实际应用对GridBase的DataSource进行扩展
                        //header.SetText(2, 2, "备    注："+item.Remarks);


                        misGoldPrinter.Header = header;
                        List<PrintColumnInfo> dataGV = CurrentPTemplate.PrintColumnInfos;
                        string ColumnsList = string.Empty;
                        foreach (PrintColumnInfo itemC in dataGV)
                        {
                            ColumnsList += itemC.Name + ",";
                        }
                        CommonGlobalUtil.WriteLog("模板设置打印列表头为=" + ColumnsList + "\r\n");
                        bool isflag = false;
                        if (dataGV.Count == 0)
                        {
                            isflag = true;
                        }
                        //   DataTable dt = dataGridView2.DataSource as DataTable;
                        //  DataTable newDt = new DataTable();
                        List<int> columnCount = new List<int>();
                        int pinrtColNum = 0;
                        string dataGridColumnsList = string.Empty;
                        for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        {
                            DataGridViewColumn column = dataGridView2.Columns[i];
                           /* if (column.DataPropertyName == "FAtm" || column.DataPropertyName == "XSAtm" || column.DataPropertyName == "SAtm" || column.DataPropertyName == "MAtm"
                                || column.DataPropertyName == "LAtm" || column.DataPropertyName == "XLAtm" || column.DataPropertyName == "XL2Atm" || column.DataPropertyName == "XL3Atm" ||
                                column.DataPropertyName == "XL4Atm" || column.DataPropertyName == "XL5Atm" || column.DataPropertyName == "XL6Atm")
                            {
                                continue;
                            }*/
                            if (dataGV.FindAll(t => t.Name == column.HeaderText).Count > 0)
                            {
                                columnCount.Add(i);
                                dataGridColumnsList += column.HeaderText + ",";
                                pinrtColNum++;
                            }
                            else
                            {
                                if (dataGV.FindAll(t => t.Name == column.DataPropertyName).Count > 0)
                                {
                                    columnCount.Add(i);
                                    column.HeaderText = column.HeaderText.Replace("\r\n", " ");
                                    dataGridColumnsList += column.DataPropertyName + ",";
                                    pinrtColNum++;
                                }
                                else
                                {
                                    if (column.DataPropertyName.Contains("XL"))
                                    {
                                        string name = column.DataPropertyName;  //XL3
                                                                                //3XL
                                        string newname = name.Replace("XL", "");
                                        string checkstr = newname + "XL";
                                        if (dataGV.FindAll(t => t.Name == checkstr).Count > 0)
                                        {
                                            columnCount.Add(i);
                                            column.HeaderText = column.HeaderText.Replace("\r\n", " ");
                                            dataGridColumnsList += column.DataPropertyName + ",";
                                            pinrtColNum++;
                                        }
                                        else
                                        {
                                            column.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        column.Visible = false;
                                    }
                                }
                            }
                            if (isflag)
                            {
                                if (i == 0)
                                {
                                    columnCount.Add(i);
                                    column.Visible = true;
                                    column.HeaderText = "";

                                    DataTable dt = new DataTable();
                                    DataColumn c1 = new DataColumn();
                                    c1.ColumnName = "HeaderText";

                                    dt.Columns.Add(c1);
                                    dataGridView2.DataSource = null;
                                    dataGridView2.DataSource = dt;

                                }
                            }
                        }

                        CommonGlobalUtil.WriteLog("DataGridView能打印的列为=" + dataGridColumnsList);

                        misGoldPrinter.DataSource = DataGridViewUtil.ToStringArray(dataGridView2, true, true);
                        if (!Directory.Exists(CommonGlobalUtil.SystemDir + "EXPORTS\\"))
                        {
                            Directory.CreateDirectory(CommonGlobalUtil.SystemDir + "EXPORTS\\");
                        }
                        misGoldPrinter.FileName = CommonGlobalUtil.SystemDir + "EXPORTS\\" + item.ID + ".jpg";
                        ((GoldPrinter.Body)(misGoldPrinter.Body)).Font = dataGridView2.Font;
                         
                        int[] widths = new int[CurrentPTemplate.PrintColumnInfos.Count];
                        for (int j = 0; j < CurrentPTemplate.PrintColumnInfos.Count; j++)
                        {
                            widths[j] = Convert.ToInt32(CurrentPTemplate.PrintColumnInfos[j].Rate);
                        }

                        List<int> widthList = new List<int>();
                        for (int i = 0; i < CurrentPTemplate.PrintColumnInfos.Count; i++)
                        {
                            DataGridViewColumn column = dataGridView2.Columns[columnCount[i]];
                            if (column.Visible && !String.IsNullOrEmpty(column.HeaderText))
                            {
                                widthList.Add(widths[i]);
                            }
                        }
                        if (isflag)
                        {
                            widths = new int[1];
                            widths[0] = 100;
                            widthList.Add(widths[0]);
                        }
                        widths = widthList.ToArray();
                        int newWidth = 800; 
                        for (int i = 0; i < widths.Length; i++)
                        {
                            widths[i] = decimal.ToInt32(Math.Round((widths[i] * newWidth * (decimal)0.1), 0, MidpointRounding.AwayFromZero)); 
                        }

                        CommonGlobalUtil.WriteLog("实际打印数量=" + pinrtColNum + "\r\n" + "设置能打印的列数量=" + widths.Length.ToString());
                        ((GoldPrinter.Body)(misGoldPrinter.Body)).ColsWidth = widths;
                        misGoldPrinter.Preview();
                        misGoldPrinter.Dispose();
                        misGoldPrinter = null;
                        /*   misGoldPrinter.DataSource = DataGridViewUtil.ToStringArray(dataGridView2, true, true);
                         if (!Directory.Exists(CommonGlobalUtil.SystemDir + "EXPORTS\\"))
                         {
                             Directory.CreateDirectory(CommonGlobalUtil.SystemDir + "EXPORTS\\");
                         }
                         misGoldPrinter.FileName = CommonGlobalUtil.SystemDir + "EXPORTS\\" + item.ID + ".jpg";
                         ((GoldPrinter.Body)(misGoldPrinter.Body)).Font = dataGridView2.Font;
                         int[] widths = new int[] {
                             80,100,40,50,50,50,50,
                             30,30,30,30,30,30,30,30,30,30,30
                             ,40,50,50
                         };
                         List<int> widthList = new List<int>();
                         List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
                         foreach (DataGridViewColumn col in dataGridView2.Columns)
                         {
                             if (col.Tag?.ToString() != PrinterNoCount)
                             {
                                 columns.Add(col);
                             }
                         }

                         for (int i = 0; i < columns.Count; i++)
                         {
                             DataGridViewColumn column = columns[i];
                             if (column.Visible)
                             {
                                 widthList.Add(widths[i]);
                             }
                         }
                         widths = widthList.ToArray();
                         int newWidth = 800;
                         int totalWidth = 0;
                         for (int i = 0; i < widths.Length; i++)
                         {
                             totalWidth += widths[i];
                         }
                         for (int i = 0; i < widths.Length; i++)
                         {

                             widths[i] = decimal.ToInt32(Math.Round((widths[i] * newWidth * (decimal)1.0 / totalWidth), 0, MidpointRounding.AwayFromZero));
                         }
                         ((GoldPrinter.Body)(misGoldPrinter.Body)).ColsWidth = widths;
                         misGoldPrinter.Preview();
                         misGoldPrinter.Dispose();
                         misGoldPrinter = null;*/
                    }
                }
            }
        }
    }
}