using JGNet.Common.Core.Util.IO.Print;
using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;


namespace JGNet.Common.Core.Util
{
    public class DayReportPrintUtil
    {

        private DayReport retailCostume;
        DayReport cz; DayReport sr; DayReport total;
        private PrintTemplateInfo CurrentPTemplate;
        public void Print(DayReport retailCostume, DayReport czmx, DayReport yysr, DayReport total)
        {
            InteractResult<PrintTemplateInfo> result = CommonGlobalCache.ServerProxy.GetPrintTemplateInfo(PrintTemplateType.DayReport);
            if (result.ExeResult == ExeResult.Success)
            {
                PrintTemplateInfo PTemplateInfo = result.Data;
                this.CurrentPTemplate = PTemplateInfo;
                this.retailCostume = retailCostume;
                this.cz = czmx;
                this.sr = yysr;
                this.total = total;
                PrintHelper printer = new PrintHelper(RetailCostume_PrintPage2);
                printer.printDocument.DefaultPageSettings.Margins = new Margins(1, 1, 5, 1);
                printer.printDocument.DefaultPageSettings.PaperSize = new PaperSize(retailCostume.ReportDate.ToString(), PrintHelper.GetInch(8), 800);
                printer.DirectlyPrint(CurrentPTemplate.PrintCount);
            }
        }

        public void RetailCostume_PrintPage2(object sender, PrintPageEventArgs e)
        {

            Graphics g = e.Graphics; //获得绘图对象
            Font font = new Font(new FontFamily("黑体"), 9);
            Font boldFont = new Font(new FontFamily("黑体"), 9, FontStyle.Bold);
            Font boldFontBig = new Font(new FontFamily("黑体"), 12);
            float linesPerPage = 0; //页面的行号
                                    //  float yPosition = 0;   //绘制字符串的纵向位置
            int count = 0; //行计数器
            float leftMargin = e.MarginBounds.Left; //左边距
            float topMargin = e.MarginBounds.Top; //上边距

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
            String seperator_line = "-----------------------------------------------------------------";
            String underLine = "____________________";




            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (CurrentPTemplate.OrderName!="")
            {
                line = "\t\t" +  CurrentPTemplate.OrderName  + "\t\t";
                g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
             
            }
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (CurrentPTemplate.SystemVariables.Contains("日结时间#0"))
            {
                line = "日结时间: " + (retailCostume.ManualConfirm ? retailCostume.CreateTime.ToString(DateTimeUtil.FULL_DATETIME_FORMAT) : string.Empty);
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("日结日期#0"))
            {
                line = "日结日期: " + retailCostume.ReportDate;
                //  g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("店铺名称#0"))
            {
                line = "店铺名称: " + CommonGlobalCache.CurrentShop?.Name;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            line = "";
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            if (CurrentPTemplate.SystemVariables.Contains("期初库存#0"))
            {
                line = "期初库存: " + retailCostume.PreTotalCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("采购进货#0"))
            {
                line = "采购进货: " + retailCostume.PurchaseInCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("采购退货#0"))
            {
                line = "采购退货: " + retailCostume.ReturnCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("调拨入库#0"))
            {
                line = "调拨入库: " + retailCostume.AllocateInCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            }
            if (CurrentPTemplate.SystemVariables.Contains("调拨#0"))
            {
                line = "    调拨: " + retailCostume.AllocateOutCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("报损出库#0"))
            {
                line = "报损出库: " + retailCostume.ScrapOutCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("盘盈数#0"))
            {
                line = "  盘盈数: " + retailCostume.CheckStoreWinCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("盘亏数#0"))
            {
                line = "  盘亏数: " + retailCostume.CheckStoreLostCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("批发发货#0"))
            {
                line = "批发发货: " + retailCostume.PfDeliveryCount;


                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }

            if (CurrentPTemplate.SystemVariables.Contains("批发退货#0"))
            {
                line = "批发退货: " + retailCostume.PfReturnCount;

                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("当日销售#0"))
            {
                line = "当日销售: " + (retailCostume.QuantityOfSale + retailCostume.EmQuantityOfSale).ToString();
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("顾客退货#0"))
            {
                line = "顾客退货: " + (retailCostume.QuantityOfRefund + retailCostume.EmQuantityOfRefund).ToString();
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("差异调整#0"))
            {
                line = "差异调整: " + retailCostume.DiffAdjustCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("期末库存#0"))
            {
                line = "期末库存: " + retailCostume.TotalCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            line = String.Empty;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = seperator_line;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

                line = "本日营业收入";

            g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = seperator_line;





                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (CurrentPTemplate.SystemVariables.Contains("现金#0"))
            {
                line = "现  金: " + "\t￥" + sr.SalesInCash;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("银联卡#0"))
            {
                line = "银联卡: " + "\t￥" + sr.SalesInBankCard;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("微信#0"))
            {
                line = "微  信: " + "\t￥" + sr.SalesInWeiXin;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("支付宝#0"))
            {
                line = "支付宝: " + "\t￥" + sr.SalesInAlipay;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("VIP卡余额#0"))
            {
                line = "VIP卡余额: " + "\t￥" + sr.SalesInVipBalance;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("VIP卡积分返现#0"))
            {
                line = "VIP卡积分返现: " + "\t￥" + sr.SalesInVipIntegration;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("优惠券金额#0"))
            {
                line = "优惠券金额: " + "\t￥" + sr.SalesInGiftTicket;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }

            line = String.Empty;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            line = seperator_line;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            line = "本日充值明细";

            g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = seperator_line;
            g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (CurrentPTemplate.SystemVariables.Contains("现金#1"))
            {
                line = "现  金: " + "\t￥" + cz.SalesInCash;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("银联卡#1"))
            {
                line = "银联卡: " + "\t￥" + cz.SalesInBankCard;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("微信#1"))
            {
                line = "微  信: " + "\t￥" + cz.SalesInWeiXin;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("支付宝#1"))
            {
                line = "支付宝: " + "\t￥" + cz.SalesInAlipay;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("其他#1"))
            {
                line = "其他: " + "\t￥" + cz.SalesInMoneyOther;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            line = String.Empty;
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            line = seperator_line;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            if (CurrentPTemplate.SystemVariables.Contains("零售单数#0"))
            {
                line = "零售单数: " + "\t" + retailCostume.SalesCount;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("营收金额#0"))
            {
                line = "营收金额: " + "\t￥" + total.TotalRecharge;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            if (CurrentPTemplate.SystemVariables.Contains("当日现金结余#0"))
            {
                line = "当日现金结余: " + "\t￥" + retailCostume.CashCurrent;
                g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            line = String.Empty;

            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            if (CurrentPTemplate.SystemVariables.Contains("营业员签名#0"))
            {
                line = "营业员（签）" + "\t" + underLine;
                g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
            line = String.Empty;
            g.DrawString(line, font, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));

            if (CurrentPTemplate.SystemVariables.Contains("财务签名#0"))
            {
                line = "财  务（签）" + "\t" + underLine;
                g.DrawString(line, boldFontBig, myBrush, leftMargin, topMargin + (count++) * font.GetHeight(g));
            }
        }
    }
}
