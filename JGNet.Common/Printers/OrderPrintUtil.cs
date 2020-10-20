using JGNet.Common.Core.Util.IO.Print;
using JGNet.Core;
using JGNet.Core.InteractEntity;
using GoldPrinter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Core.Util
{
    public class OrderPrintUtil
    {

        private RetailCostume retailCostume;

        private PrintTemplateInfo CurrentPTemplate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <param name="times">打印次数</param>
        public void Print(RetailCostume retailCostume, int times, DataGridView dataGridView)
        {
            this.retailCostume = retailCostume;
            InteractResult<RetailPrintType> rPrintType = CommonGlobalCache.ServerProxy.GetRetailPrintType();
            if (rPrintType.ExeResult == ExeResult.Success)
            {
                if (rPrintType.Data == RetailPrintType.SmallTickets)
                {
                    InteractResult<PrintTemplateInfo> result = CommonGlobalCache.ServerProxy.GetPrintTemplateInfo(PrintTemplateType.Retail);
                    if (result.ExeResult == ExeResult.Success)
                    {
                        PrintTemplateInfo PTemplateInfo = result.Data;
                        this.CurrentPTemplate = PTemplateInfo;
                        PrintHelper printer = new PrintHelper(RetailCostume_PrintPage2);
                        printer.printDocument.DefaultPageSettings.Margins = new Margins(1, 1, 5, 1);
                        printer.printDocument.DefaultPageSettings.PaperSize = new PaperSize(retailCostume.RetailOrder.ID, PrintHelper.GetInch(8), 600);
                        printer.DirectlyPrint(this.CurrentPTemplate.PrintCount);
                    }
                }
                else
                {

                    setPrintDataGridView(retailCostume, dataGridView, PrintTemplateType.RetailOrder);
                }
            }
            else
            {

            }
            /**/
        }



        private static void setPrintDataGridView(RetailCostume item, DataGridView dataGridView2, PrintTemplateType type)
        {
            InteractResult<PrintTemplateInfo> result = CommonGlobalCache.ServerProxy.GetPrintTemplateInfo(type);
            //行列数基本不受限制，但超过一页失去意义，因为以Body为主，以其它为辅
            //   Header header = new Header(4, 2);
            //可以指定每页是否重复打印
            if (result.ExeResult == ExeResult.Success)
            {
                PrintTemplateInfo CurrentPTemplate = result.Data;
                for (int c = 0; c < CurrentPTemplate.PrintCount; c++)
                {

                    MisGoldPrinterOfReWrite misGoldPrinter = new MisGoldPrinterOfReWrite(false, new PrinterMargins(20, 20, 20, 20, 800, 1129));


                    misGoldPrinter.Title = CurrentPTemplate.OrderName; //主标题（C#用\n表示换行）	}

                    misGoldPrinter.Caption = "";

                    double headRow = Math.Round(Convert.ToSingle(CurrentPTemplate.SystemVariables.Count / 2));

                    Header header = new Header(Convert.ToInt32(headRow) + 1, 2);
                    // CommonGlobalUtil.WriteLog("变量总数=" + CurrentPTemplate.SystemVariables.Count + "\r\n" + "应显示行号=" + headRow);
                    header.IsDrawAllPage = true;
                    #region
                    Member _member = null;
                    if (item.RetailOrder.MemeberID != null)
                    {

                        _member = CommonGlobalCache.ServerProxy.GetOneMember(item.RetailOrder.MemeberID);
                    }
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
                        if (CurrentPTemplate.SystemVariables[i] == "销售单号")
                        {
                            KeyStr = "销售单号：";
                            header.SetText(curR, i % 2, CurrentPTemplate.SystemVariables[i] +"："+item.RetailOrder.ID);
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "单据日期")
                        {
                            KeyStr = "单据日期：";
                            header.SetText(curR, i % 2, KeyStr + item.RetailOrder.CreateTime.GetDateTimeFormats('f')[0].ToString());
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "客户名称")
                        {
                            KeyStr = "客户名称：";
                            if (_member != null)
                            {
                                header.SetText(curR, i % 2, KeyStr + _member.Name);
                            }
                            else
                            {

                                header.SetText(curR, i % 2, KeyStr );
                            }
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "客户电话")
                        {
                            KeyStr = "客户电话：";
                            if (_member != null)
                            {
                                header.SetText(curR, i % 2, KeyStr + _member.PhoneNumber);
                            }
                            else
                            {
                                header.SetText(curR, i % 2, KeyStr);
                            }
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "客户地址")
                        {
                            KeyStr = "客户地址：";
                            if (_member != null)
                            {
                                header.SetText(curR, i % 2, KeyStr + _member.DetailAddress);
                            }
                            else
                            {

                                header.SetText(curR, i % 2, KeyStr);
                            }
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "操作人")
                        {
                            KeyStr = "操 作 人：";
                            header.SetText(curR, i % 2, KeyStr + CommonGlobalCache.GetUserName(item.RetailOrder.GuideID));
                        }
                        else if (CurrentPTemplate.SystemVariables[i] == "单据备注")
                        {
                            KeyStr = "备    注：";
                            header.SetText(curR, i % 2, KeyStr + item.RetailOrder.Remarks.ToString());
                        }
                    }
                    #endregion

                    misGoldPrinter.Header = header;

                   // List<PrintColumnInfo> allPrintColumnInfos=new List<PrintColumnInfo>();

                    List<PrintColumnInfo> dataGV =new List<PrintColumnInfo>();
                    PrintColumnInfo prinAutoIDColumn = new PrintColumnInfo();
                    prinAutoIDColumn.Name = "序列号";
                    prinAutoIDColumn.Rate = 5;
                    dataGV.Add(prinAutoIDColumn);
                    dataGV.AddRange(CurrentPTemplate.PrintColumnInfos);
                  //  allPrintColumnInfos = dataGV;

                    string ColumnsList = string.Empty;
                    foreach (PrintColumnInfo itemC in dataGV)
                    {
                        ColumnsList += itemC.Name + ",";
                    }
                    CommonGlobalUtil.WriteLog("模板设置打印列表头为=" + ColumnsList + "\r\n");
                    //表格是否为零条记录
                    bool isflag = false;
                    if (dataGV.Count == 0)
                    {
                        isflag = true;
                    }

                    List<int> columnCount = new List<int>();
                    int pinrtColNum = 0;
                    string dataGridColumnsList = string.Empty;
                    if (dataGridView2.Columns.Count > 0)
                    {
                        for (int i = 0; i < dataGridView2.Columns.Count; i++)
                        {
                            DataGridViewColumn column = dataGridView2.Columns[i];

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
                                    //打印设置模板不设置任何列，但由于MisGoldPrinter这个类的打印主体为DataGridView，所有必须设置一列默认空的
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
                            //}
                        }

                        CommonGlobalUtil.WriteLog("DataGridView能打印的列为=" + dataGridColumnsList);


                        MultiHeader multiHeader = new MultiHeader(1, dataGV.Count);
                        for (int a = 0; a < dataGV.Count; a++)
                        {
                            multiHeader.SetText(0, a, dataGV[a].Name);
                        }

                        misGoldPrinter.IsTotalIsDrawAllPage = false;


                        misGoldPrinter.DataSource = DataGridViewUtil.ToStringArray(dataGridView2, false, true);
                        
                        misGoldPrinter.RowsPerPage = CurrentPTemplate.Rows+1; //根据设置传值
                        misGoldPrinter.IsSubTotalPerPage = true;

                        int footerRowsNum = 0;
                        if (((GoldPrinter.Body)(misGoldPrinter.Body)).Rows >= 2)
                        {
                            footerRowsNum = ((GoldPrinter.Body)(misGoldPrinter.Body)).Rows;
                        }
                        else
                        {
                            footerRowsNum = 2;
                        }

                        Footer footer = new Footer(footerRowsNum, dataGV.Count);
                        int colIndex = -1;
                        int colIndexSecond = -1; 
                        for (int b = 0; b < dataGV.Count; b++)
                        {
                            if (dataGV[b].Name == "金额")
                            {
                                colIndex = b;
                            }
                            if (dataGV[b].Name == "数量")
                            {
                                colIndexSecond = b;
                            }
                        }

                        string addressStr = string.Empty;
                        for (int a = 0; a < CurrentPTemplate.SystemVariables.Count; a++)
                        {
                            //if (dataGridView2.Rows.Count >= 2)
                            //{
                            if (CurrentPTemplate.SystemVariables[a] == "店铺地址")
                            {
                                Shop curShop = CommonGlobalCache.GetShop(item.RetailOrder.ShopID);
                                if (curShop != null)
                                {
                                    footer.SetText(0, 0, "店铺地址：" + curShop.Address);
                                }
                            }
                            if (CurrentPTemplate.SystemVariables[a] == "联系电话")
                            {
                                Shop curShop = CommonGlobalCache.GetShop(item.RetailOrder.ShopID);
                                if (curShop != null)
                                {
                                    footer.SetText(1, 0, "联系电话：" + curShop.PhoneNumber);
                                }
                            }
                            //}
                            //else if(dataGridView2.Rows.Count >= 1)
                            //{
                            //    if (CurrentPTemplate.SystemVariables[a] == "店铺地址")
                            //    {
                            //        if (item.RetailOrder.ShopID != null && item.RetailOrder.ShopID != "_online")
                            //        {
                            //            addressStr += "店铺地址：" + CommonGlobalCache.GetShop(item.RetailOrder.ShopID).Address;
                            //        }
                            //    }
                            //    if (CurrentPTemplate.SystemVariables[a] == "联系电话")
                            //    {
                            //        if (addressStr != string.Empty)
                            //        {
                            //            addressStr += "       ";
                            //        }
                            //        if (item.RetailOrder.ShopID != null && item.RetailOrder.ShopID != "_online")
                            //        {
                            //            addressStr += "联系电话：" + CommonGlobalCache.GetShop(item.RetailOrder.ShopID).PhoneNumber;
                            //        }
                            //    }
                            //}
                        }
                        //if (dataGridView2.Rows.Count == 1)
                        //{
                        //    footer.SetText(0, 0, addressStr);
                        //}

                        MoneyConvertChinese MConvertC = new MoneyConvertChinese();
                      /*  if (dataGridView2.Rows.Count > 1)
                        {
                            footer.SetText(0, 0, "合计 金额大写 " + MConvertC.MoneyToChinese(item.RetailOrder.TotalMoneyReceived.ToString()));

                        }
                        else
                        {
                            footer.SetText(0, 0, addressStr + " 合计 金额大写 " + MConvertC.MoneyToChinese(item.RetailOrder.TotalMoneyReceived.ToString()));

                        }*/
                        misGoldPrinter.EndSubTotalColsList = MConvertC.MoneyToChinese(item.RetailOrder.TotalMoneyReceived.ToString()) + ":" + item.RetailOrder.TotalMoneyReceived.ToString();
                       // footer.SetText(0, 1, "合计：" + item.RetailOrder.TotalMoneyReceived);
                       
                        //  PrinterBase pbase = footer.CalculatePageInfo();

                        /* if (Math.Ceiling((decimal)dataGridView2.Rows.Count / CurrentPTemplate.Rows) > 1)
                           {
                               footer.IsDrawAllPage = false;
                           }
                           else
                           {

                               footer.IsDrawAllPage = true;
                           }*/

                        footer.IsDrawAllPage = false;

                        Bottom bottom = new Bottom();
                        
                        bottom.IsDrawAllPage = true;
                        misGoldPrinter.SubTotalColsList = (colIndex).ToString() + ";" + (colIndexSecond).ToString();      //用分号分隔的要求小计的列	
                        /*   if (!Directory.Exists(CommonGlobalUtil.SystemDir + "EXPORTS\\"))
                        {
                            Directory.CreateDirectory(CommonGlobalUtil.SystemDir + "EXPORTS\\");
                        }
                            misGoldPrinter.FileName = CommonGlobalUtil.SystemDir + "EXPORTS\\" + item.RetailOrder.ID + ".jpg";*/
                        ((GoldPrinter.Body)(misGoldPrinter.Body)).Font = dataGridView2.Font;
                         
                        int[] widths = new int[dataGV.Count];
                        for (int j = 0; j < dataGV.Count; j++)
                        {
                            widths[j] = Convert.ToInt32(dataGV[j].Rate);
                        }

                        List<int> widthList = new List<int>();
                        /*   for (int i = 0; i < dataGV.Count; i++)
                           {
                               DataGridViewColumn column = dataGridView2.Columns[columnCount[i]];
                               if (column.Visible && !String.IsNullOrEmpty(column.HeaderText))
                               {
                                   widthList.Add(widths[i]);
                               }

                           }*/
                        if (isflag)
                        {
                            widths = new int[1];
                            widths[0] = 100;
                            // widthList.Add(widths[0]);
                        }

                        //   widths = widthList.ToArray();
                        int newWidth = 800;
                        /*  int totalWidth = 0;
                          for (int i = 0; i < widths.Length; i++)
                          {
                              totalWidth += widths[i];
                          }*/
                        //if (dataGridView2.Columns.Count > 0)
                        //{
                        for (int i = 0; i < widths.Length; i++)
                        {
                            widths[i] = decimal.ToInt32(Math.Round((widths[i] * newWidth * (decimal)0.1), 0, MidpointRounding.AwayFromZero));
                            // widths[i] = decimal.ToInt32(Math.Round((widths[i] * newWidth * (decimal)1.0 / totalWidth), 0, MidpointRounding.AwayFromZero));
                        }
                        CommonGlobalUtil.WriteLog("实际打印数量=" + pinrtColNum + "\r\n" + "设置能打印的列数量=" + widths.Length.ToString());

                         /*   bottomFooter.ColsWidth = widths;*/
                        footer.ColsWidth = widths;
                        misGoldPrinter.Footer = footer;
                       /*  misGoldPrinter.BottomFooter = bottomFooter;*/
                        misGoldPrinter.Bottom = bottom;
                        multiHeader.ColsWidth = widths;
                        misGoldPrinter.MultiHeader = multiHeader;
                        multiHeader.ColsWidth = widths;
                        ((GoldPrinter.Body)(misGoldPrinter.Body)).IsAverageColsWidth = false;
                       ((GoldPrinter.Body)(misGoldPrinter.Body)).ColsWidth = widths;
                        misGoldPrinter.Preview();
                        misGoldPrinter.Dispose();
                        misGoldPrinter = null;

                    }

                }
            }

        }


        /// <summary>
        /// 小票格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RetailCostume_PrintPage2(object sender, PrintPageEventArgs e)
        {

            Graphics g = e.Graphics; //获得绘图对象
            Font font = new Font(new FontFamily("黑体"), 8);
            Font boldFont = new Font(new FontFamily("黑体"), 8, FontStyle.Bold);
            Font boldFontBig = new Font(new FontFamily("黑体"), 11);
            float linesPerPage = 0; //页面的行号
                                    //  float yPosition = 0;   //绘制字符串的纵向位置
            int count = 0; //行计数器
            float leftMargin = e.MarginBounds.Left; //左边距
            float topMargin = e.MarginBounds.Top; //上边距

            float rightMargin = e.MarginBounds.Right;

            string line = null; //行字符串
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            linesPerPage = e.MarginBounds.Height / font.GetHeight(g);



            StringBuilder sb = new StringBuilder();
            String seperator_line = "-------------------------------------------------";
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            Shop curShop = CommonGlobalCache.GetShop(retailCostume.RetailOrder.ShopID);
            int splitSize = 0;
            int NameLen = 0;
            if (retailCostume.RetailOrder.ShopID == "_online")
            {
                NameLen = retailCostume.RetailOrder.ShopName.Length;
            }
            else
            {

                NameLen = curShop.Name.Length;
            }
            splitSize = (seperator_line.Length - NameLen) / 2;
            String strShop = String.Empty;
            for (int i = 0; i < splitSize / 2; i++)
            {
                strShop += " ";
            }

            if (CurrentPTemplate.SystemVariables.Contains("店铺"))
            {
                if (retailCostume.RetailOrder.ShopID == "_online") { line = strShop + retailCostume.RetailOrder.ShopName; }
                else
                {
                    line = strShop + CommonGlobalCache.GetShop(retailCostume.RetailOrder.ShopID).Name;
                }
                g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            //line = "\t\t" + CommonGlobalCache.CurrentShop?.Name + "\t\t";
            //g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            //  line = seperator_line;
            if (CurrentPTemplate.SystemVariables.Contains("单号"))
            {
                line = "单号: " + retailCostume.RetailOrder.ID;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("日期"))
            {
                line = "日期: " + retailCostume.RetailOrder.CreateTime.GetDateTimeFormats('f')[0].ToString();
                //  g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("电话"))
            {
                line = "电话: " + CommonGlobalCache.CurrentShop?.PhoneNumber;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("地址"))
            {
                line = "地址: " + CommonGlobalCache.CurrentShop?.Address;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("顾问"))
            {
                line = "顾问: " + CommonGlobalCache.GetUserName(retailCostume.RetailOrder.GuideID);
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }

            line = seperator_line;
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            List<PrintColumnInfo> columnInfo = CurrentPTemplate.PrintColumnInfos;

            float tabF = leftMargin;
            float curAllwidth = rightMargin - leftMargin;


            foreach (PrintColumnInfo curColumn in columnInfo)
            {
                line = curColumn.Name;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));

                decimal curWidth = Convert.ToDecimal(curAllwidth) * curColumn.Rate / 100;
                tabF += Convert.ToSingle(curWidth);
            }




            /*   float tabF = leftMargin;
               line = "款号";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
               tabF += 75;
               line = "颜色";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
               tabF += 40;
               line = "尺码";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
               tabF += 40;
               line = "数量";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
               tabF += 40;
               line = "吊牌价";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
               tabF += 40;
               line = "金额";
               g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));*/

            count++;
            if (retailCostume.RetailDetailList != null)
            {
                foreach (var detail in retailCostume.RetailDetailList)
                {
                    tabF = leftMargin;
                    PrintColumnInfo columnIDInfo = columnInfo.Find(t => t.Name == "款号");
                    if (columnIDInfo != null)
                    {
                        line = detail.CostumeID;
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnIDInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }


                    PrintColumnInfo columnColorInfo = columnInfo.Find(t => t.Name == "颜色");
                    if (columnColorInfo != null)
                    {
                        line = detail.ColorName;
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnColorInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }
                    PrintColumnInfo columnSizeInfo = columnInfo.Find(t => t.Name == "尺码");
                    if (columnSizeInfo != null)
                    {
                        line = detail.SizeDisplayName;
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));

                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnSizeInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }
                    PrintColumnInfo columnCountInfo = columnInfo.Find(t => t.Name == "数量");
                    if (columnCountInfo != null)
                    {
                        line = detail.BuyCount.ToString();
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnCountInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }

                    PrintColumnInfo columnPriceInfo = columnInfo.Find(t => t.Name == "吊牌价");
                    if (columnPriceInfo != null)
                    {
                        line = detail.Price.ToString();
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnPriceInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }
                    PrintColumnInfo columnSumMoneyInfo = columnInfo.Find(t => t.Name == "金额");
                    if (columnSumMoneyInfo != null)
                    {
                        line = detail.SumMoney.ToString();
                        g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                        decimal curWidth = Convert.ToDecimal(curAllwidth) * columnSumMoneyInfo.Rate / 100;
                        tabF += Convert.ToSingle(curWidth);
                    }

                    count++;

                }
            }

            line = seperator_line;
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            tabF = leftMargin;
            if (CurrentPTemplate.SystemVariables.Contains("数量"))
            {
                line = "数量: " + retailCostume.RetailOrder.TotalCount;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                tabF += 80;
            }
            if (CurrentPTemplate.SystemVariables.Contains("折扣优惠"))
            {
                line = "折扣优惠：" + retailCostume.RetailOrder.MoneyDiscounted;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                tabF += 120;
            }
            if (CurrentPTemplate.SystemVariables.Contains("应收"))
            {
                line = "应收：" + retailCostume.RetailOrder.TotalMoneyReceived;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            //会员信息
            line = "VIP：";
            g.DrawString(line, boldFont, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            tabF = leftMargin;
            Member member = new Member();
            decimal orderIntegration = 0;
            if (!String.IsNullOrEmpty(retailCostume.RetailOrder.MemeberID))
            {
                member = CommonGlobalCache.ServerProxy.GetOneMember(retailCostume.RetailOrder.MemeberID);
                orderIntegration = retailCostume.RetailOrder.TotalMoneyReceived - retailCostume.RetailOrder.MoneyIntegration;
            }
            if (CurrentPTemplate.SystemVariables.Contains("卡号"))
            {
                line = "卡号：" + retailCostume.RetailOrder.MemeberID;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));

            }
            if (CurrentPTemplate.SystemVariables.Contains("姓名"))
            {
                tabF += 150;
                line = "姓名：" + member.Name;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("本次积分"))
            {
                tabF = leftMargin;
                line = "本次积分：" + orderIntegration;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("当前积分"))
            {
                tabF = leftMargin;
                line = "当前积分：" + member.CurrentIntegration;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            tabF = leftMargin;
            if (CurrentPTemplate.SystemVariables.Contains("累计积分"))
            {
                line = "累计积分：" + member.AccruedIntegration;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("余额"))
            {
                line = "余额：" + member.Balance;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            tabF = leftMargin;
            line = "付款：";
            g.DrawString(line, boldFont, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));


            if (CurrentPTemplate.SystemVariables.Contains("银联卡"))
            {
                tabF = leftMargin;
                line = "银联卡：" + retailCostume.RetailOrder.MoneyBankCard;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("现金"))
            {
                tabF += 100;
                line = "现金：" + retailCostume.RetailOrder.MoneyCash;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("VIP卡"))
            {
                tabF += 97;
                line = "VIP卡：" + retailCostume.RetailOrder.MoneyVipCard;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("支付宝"))
            {
                tabF = leftMargin;
                line = "支付宝：" + retailCostume.RetailOrder.MoneyAlipay;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("微信"))
            {
                tabF += 100;
                line = "微信：" + retailCostume.RetailOrder.MoneyWeiXin;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("积分兑现"))
            {
                tabF += 80;
                line = "积分兑现：" + retailCostume.RetailOrder.MoneyIntegration;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));
            }
            //line = " ";
            //g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            tabF = leftMargin;
            if (CurrentPTemplate.SystemVariables.Contains("优惠券"))
            {


                line = "优惠券：" + retailCostume.RetailOrder.MoneyDeductedByTicket;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("其他"))
            {
                tabF += 100;
                line = "其他：" + retailCostume.RetailOrder.MoneyOther;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            }
            tabF += 80;
            line = " ";
            g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));


            if (CurrentPTemplate.SystemVariables.Contains("找零"))
            {
                line = "找零：" + retailCostume.RetailOrder.MoneyChange;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }

            line = seperator_line;
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            if (this.CurrentPTemplate.AdditionalText != "")
            {
                decimal countText = this.CurrentPTemplate.AdditionalText.Length;
                decimal sumRow = Math.Ceiling(countText / 25);
                for (int i = 0; i < sumRow; i++)
                {
                    if (i + 1 == sumRow)
                    {
                        line = this.CurrentPTemplate.AdditionalText.Substring(0 + i * 25, this.CurrentPTemplate.AdditionalText.Length - 25 * i);
                        g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
                    }
                    else
                    {
                        line = this.CurrentPTemplate.AdditionalText.Substring(0 + i * 25, 25);
                        g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
                    }
                }
            }

            /*  line = "1、凡商品售出7日内，在商品保持原样情况下，凭购物";
              g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
              line = "  凭证可调换同类产品";
              g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
              line = "2、本店商品，请您注意洗涤说明和保养";
              g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));  */
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (this.CurrentPTemplate.IsPrintQRCode)
            {
                //if (CommonGlobalCache.BusinessAccount.OnlineEnabled)
                //{
                if (CommonGlobalCache.EMallMiniProgramImg != null)
                {
                    g.DrawImage(CommonGlobalCache.EMallMiniProgramImg, leftMargin + 20, topMargin + (count++) * font.GetHeight(g));
                }
                // }
            }
        }
    }
}
