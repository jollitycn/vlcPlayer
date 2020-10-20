using JGNet.Common.Core.Util.IO.Print;
using JGNet.Core.InteractEntity;
using JGNet.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;


namespace JGNet.Common.Core.Util
{
    public class SalePayPrintUtil
    {

        private PfAccountRecord suplierRecord;
        private PrintTemplateInfo CurrentPTemplate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RefundCostume"></param>
        /// <param name="times">打印次数</param>
        public void Print(PfAccountRecord suplierRecord,  int times)
        {
            this.suplierRecord = suplierRecord;
           // InteractResult<PfAccountRecord> result = CommonGlobalCache.ServerProxy.GetPrintTemplateInfo(PrintTemplateType.Retail);
          // if (result.ExeResult == ExeResult.Success)
          //  {
             //   PrintTemplateInfo PTemplateInfo = result.Data;
               // this.CurrentPTemplate = PTemplateInfo;
                PrintHelper printer = new PrintHelper(RefundCostume_PrintPage2);
                printer.printDocument.DefaultPageSettings.Margins = new Margins(1, 1, 5, 1);
                printer.printDocument.DefaultPageSettings.PaperSize = new PaperSize(suplierRecord.AutoID.ToString(), PrintHelper.GetInch(8), 600);
                printer.DirectlyPrint(1);
          //  }
        }

        public void RefundCostume_PrintPage2(object sender, PrintPageEventArgs e)
        {
             

                Graphics g = e.Graphics; //获得绘图对象
                Font font = new Font(new FontFamily("黑体"), 11);
                Font boldFont = new Font(new FontFamily("黑体"), 11, FontStyle.Bold);
                Font boldFontBig = new Font(new FontFamily("黑体"), 15);
                float linesPerPage = 0; //页面的行号
                                        //  float yPosition = 0;   //绘制字符串的纵向位置
                int count = 0; //行计数器
                float leftMargin = e.MarginBounds.Left; //左边距
                float topMargin = e.MarginBounds.Top; //上边距
            float rightMargin = e.MarginBounds.Right;
                string line = null; //行字符串
             
                SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
                linesPerPage = e.MarginBounds.Height / font.GetHeight(g);//每页可打印的行数
                                                                         //逐行的循环打印一页
                                                                         //while (count < linesPerPage && ((line = lineReader.ReadLine()) != null))
                                                                 //  {
                                                                         //    yPosition = topMargin + (count * PrintFont.GetHeight(g));
                                                                         //    g.DrawString(line, PrintFont, myBrush, leftMargin, yPosition);
                                                                         //    count++;
                                                                         //  }


            StringBuilder sb = new StringBuilder();
                String seperator_line = "-------------------------------------------------";


            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
            strFormat.Trimming = StringTrimming.EllipsisWord;

            line = "";
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            int splitSize = 0;
            /*  if (RefundCostume.RefundOrder.ShopID == "_online") {
                  splitSize = (seperator_line.Length - RefundCostume.RefundOrder.ShopName.Length) / 2;
              }
              else
              {*/
            string str = "  收 款 凭 证";

                splitSize = Convert.ToInt32(rightMargin -leftMargin-160- str.Length) /2  ;
          //  }

                String strShop = String.Empty;
                for (int i = 0; i < splitSize/2 ; i++)
                {
                    strShop += " ";
                }
            //if (CurrentPTemplate.SystemVariables.Contains("店铺"))
            //{
            /*  if (RefundCostume.RefundOrder.ShopID == "_online") {
                  line = strShop + RefundCostume.RefundOrder.ShopName;
              }
              else
              {
                  line = strShop + CommonGlobalCache.GetShop(RefundCostume.RefundOrder.ShopID).Name;
              }*/
            string titleStr = string.Empty;
            for (int i = 0; i < splitSize/2; i++)
            {
                titleStr += " ";
            }

            float yy = topMargin + (count++) * font.GetHeight(g);
            line = titleStr + "  收 款 凭 证" + "             " ;
            g.DrawString(line, boldFontBig, myBrush, leftMargin, yy);
            float StartLeft = leftMargin;
            StartLeft += leftMargin+500;
            line =  "             " + "NO:" + suplierRecord.SourceOrderID;
            g.DrawString(line, font, myBrush, StartLeft, yy);

            line = " ";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            //  }
            //line = "\t\t" + CommonGlobalCache.CurrentShop?.Name + "\t\t";
            //g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = strShop + strShop + "             " + suplierRecord.CreateTime.ToLongDateString();
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            //  line = seperator_line;
            //if (CurrentPTemplate.SystemVariables.Contains("单号"))
            //{
            line = " ";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            Font fontnew = new Font("宋体", 11, FontStyle.Underline, GraphicsUnit.Point);

            float newtabF = leftMargin+80;
            float y = topMargin + (count++) * font.GetHeight(g);
            line = "交款单位: "  ;
                g.DrawString(line, font, myBrush, newtabF, y, strFormat);

            int lenSupStr = System.Text.Encoding.Default.GetBytes(suplierRecord.PfCustomerName).Length;

            int spacelen = Convert.ToInt32((e.MarginBounds.Width - 140));

                String spaceStr = String.Empty;

            for (int i = 0; i < spacelen/2 - lenSupStr; i++)
            {
                spaceStr += " ";
            }
             
             line = "_"+suplierRecord.PfCustomerName+ spaceStr + "_"; 
            g.DrawString(line, fontnew, myBrush, newtabF + 80, y);
            // g.DrawString(line, fontnew, myBrush, leftMargin + 80, topMargin + (count++) * font.GetHeight(g), strFormat);
           int CurWidth = e.MarginBounds.Width - Convert.ToInt32(newtabF);
            //newtabF+=
             line = " ";
            g.DrawString(line, fontnew, myBrush, newtabF+ CurWidth-2, y);

            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            //  }
            //if (CurrentPTemplate.SystemVariables.Contains("日期"))
            //{
            y = topMargin + (count++) * font.GetHeight(g);
            newtabF = leftMargin+80;
            line = "人民币（大写）：";
            g.DrawString(line, font, myBrush, newtabF, y, strFormat);
            newtabF += 120;
            MoneyConvertChinese MConvertC = new MoneyConvertChinese();
            int lenChinaStr = System.Text.Encoding.Default.GetBytes(MConvertC.MoneyToChinese(suplierRecord.AccountMoney.ToString())).Length;
            spacelen = Convert.ToInt32(e.MarginBounds.Width - (rightMargin - leftMargin )/2 )-80;

            spaceStr = "";
            for (int i = 0; i < spacelen/2 - lenChinaStr; i++)
            {
                spaceStr += " ";
            }
            line = MConvertC.MoneyToChinese(suplierRecord.AccountMoney.ToString()) + spaceStr + "_";          
                g.DrawString(line, fontnew, myBrush, newtabF , y);

            newtabF +=260;
            line = "（小写）：";
            g.DrawString(line, font, myBrush, newtabF, y, strFormat);

            newtabF += 80;

            spacelen = 0;
            spacelen = Convert.ToInt32(e.MarginBounds.Width-(rightMargin - leftMargin) / 2)-90;

             spaceStr = "";
            for (int i = 0; i < spacelen/2 - suplierRecord.AccountMoney.ToString().Length; i++)
            {
                spaceStr += " ";
            }

            line = "¥" + suplierRecord.AccountMoney + spaceStr+  "_";
            g.DrawString(line, fontnew, myBrush, newtabF , y, strFormat);




            //line = suplierRecord.AccountMoney + spaceStr + "_";
            //g.DrawString(line, fontnew, myBrush, newtabF + 120, y);

            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            // }
            //if (CurrentPTemplate.SystemVariables.Contains("电话"))
            //{
            line = "附注: ";
                g.DrawString(line, font, myBrush, leftMargin+80, topMargin + (count++) * font.GetHeight(g));

            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            // }
            //if (CurrentPTemplate.SystemVariables.Contains("地址"))
            //{
            spaceStr = "";
            int lenStr = System.Text.Encoding.Default.GetBytes(suplierRecord.Remarks).Length;
            spacelen = Convert.ToInt32((e.MarginBounds.Width -120) );
            spaceStr = "";
            for (int i = 0; i < spacelen/2 - lenStr; i++)
            {
                spaceStr += " ";
            }

            line = "_" + suplierRecord.Remarks + spaceStr+"_";
             g.DrawString(line, fontnew, myBrush, leftMargin + 80, topMargin + (count++) * font.GetHeight(g));

            //  }
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            float tabF = leftMargin;
            float curAllwidth = rightMargin - leftMargin;


      




        

                count++;
              

                tabF = leftMargin+80;
            //if (CurrentPTemplate.SystemVariables.Contains("数量"))
            //{
                line = "单位盖章: "  ;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                tabF += 200;
           // }
            //if (CurrentPTemplate.SystemVariables.Contains("折扣优惠"))
            //{
                line = "会计：" ;
                g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
                tabF += 150;
            //  }
            //if (CurrentPTemplate.SystemVariables.Contains("应收"))
            //{

            line = "出纳：";
            g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            tabF += 150;
            // }


            line = "收款人：";
            g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
           


            /* line = "1、凡商品售出7日内，在商品保持原样情况下，凭购物";
             g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
             line = "  凭证可调换同类产品";
             g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
             line = "2、本店商品，请您注意洗涤说明和保养";
             g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g)); */
            line = "";
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

          /*  if (this.CurrentPTemplate.IsPrintQRCode)
            {
               
                    if (CommonGlobalCache.EMallMiniProgramImg != null)
                    {
                        g.DrawImage(CommonGlobalCache.EMallMiniProgramImg, leftMargin + 20, topMargin + (count++) * font.GetHeight(g));
                    }
              //  }
            }*/
            
        }
         
    }
}
