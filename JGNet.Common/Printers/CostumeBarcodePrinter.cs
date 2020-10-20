
using JGNet.Common.Core.Util.BarCode;
using JGNet.Common.Core.Util.IO.Print;
using JGNet.Core;
using JGNet.Core.Tools;
using JGNet.Server.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;


namespace JGNet.Common.Core.Util
{
    public class CostumeBarcodePrinter
    {
        private BarCode4CostumeInfo info;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <param name="times">打印次数</param>
        public void Print(BarCode4CostumeInfo info, int times)
        {
            this.info = info;
            if (info != null)
            {
                PrintHelper printer = new PrintHelper(Print_page);
                printer.printDocument.DefaultPageSettings.Margins = new Margins(1, 1, 5, 1);
                printer.printDocument.DefaultPageSettings.PaperSize = new PaperSize(info.BarCode, 190, 130);
                printer.DirectlyPrint(times);
                //printer.ShowPrintPreviewDialog();
            }
        }

        public void Print(List<BarCode4CostumeInfo> data, int times)
        {
            if (data != null)
            {
                foreach (var item in data)
                {
                    Print(item, times);
                }
            }
        }

        public void Print_page(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics; //获得绘图对象
            Font font = new Font(new FontFamily("微软雅黑"), 8);
            Font boldFont = new Font(new FontFamily("微软雅黑"), 8, FontStyle.Bold);
            Font boldFontBig = new Font(new FontFamily("微软雅黑"), 11);
            float linesPerPage = 0;  
            int count = 0; //行计数器
            float leftMargin = e.MarginBounds.Left+20; //左边距
            float topMargin = e.MarginBounds.Top; //上边距

            string line = null; //行字符串
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            linesPerPage = e.MarginBounds.Height / font.GetHeight(g);
            StringBuilder sb = new StringBuilder();
            float  tabF = leftMargin;



            //获取配置信息
            String template = CommonGlobalCache.GetParameter(ParameterConfigKey.BarCodeTemplate)?.ParaValue;

         List<String> settings=   DataHelper.StringToList(template);
            line = string.Empty;
          String  lineB = string.Empty;
            String lineC = string.Empty;
            if (settings.Contains("BrandName")) {
                    lineB = info.BrandName;
                }
 if (settings.Contains("CostumeID")) {
                    lineC =  info.CostumeID;
                }

            if (!String.IsNullOrEmpty(lineB))
            {
                line += lineB;
                if (!String.IsNullOrEmpty(lineC))
                {
                    line += "/"+lineC;
                }
            }
            else {
                if (!String.IsNullOrEmpty(lineC)) {
                    line = lineC;
                }
            }

            g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            tabF += 100;

            line = string.Empty;
            if (settings.Contains("ClassName"))
            { line = info.ClassName; }
          
               
            g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));

            tabF = leftMargin;



            line = string.Empty;
            if (settings.Contains("Remarks"))
            { line = info.Remarks; }
            g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));

            line = string.Empty;
            if (settings.Contains("BarCode"))
            {
                line = info.BarCode;
                Bitmap map = BarcodeHelper.Generate(ZXing.BarcodeFormat.CODE_128, line, 140, 50);
                g.DrawImage(map, tabF, topMargin + (count++) * font.GetHeight(g));
            }

            tabF = leftMargin;
            count++;
            count++;
            count++;

            line = string.Empty;
            if (settings.Contains("CostumeName"))
            { line = info.CostumeName; } 
            g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            tabF += 100;


            line = string.Empty;
            if (settings.Contains("ColorName"))
            { line = info.ColorName; }
            g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));

            line = string.Empty;
            if (settings.Contains("SalePrice"))
            { line = "￥" + info.SalePrice.ToString(); }
            tabF = leftMargin;
            g.DrawString(line, font, myBrush, tabF, topMargin + (count) * font.GetHeight(g));
            tabF += 100;
            line = string.Empty;
            if (settings.Contains("SizeName"))
            { line = info.SizeName; }
            g.DrawString(line, font, myBrush, tabF, topMargin + (count++) * font.GetHeight(g));

        }
    }
}
