
using JGNet.Common.Core.Util.BarCode;
using JGNet.Common.Core.Util.IO.Print;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;


namespace JGNet.Common.Core.Util
{
    public class BarCodePrinter
    {
        private String barCode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="retailCostume"></param>
        /// <param name="times">打印次数</param>
        public void Print(String barCode, int times)
        {
            this.barCode = barCode;

            PrintHelper printer = new PrintHelper(Print_page);
            printer.printDocument.DefaultPageSettings.Margins = new Margins(1, 1, 5, 1);
            printer.printDocument.DefaultPageSettings.PaperSize = new PaperSize(barCode, 140, 60);
            printer.DirectlyPrint(times);
        }

        public void Print_page(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics; //获得绘图对象
            Bitmap map = BarcodeHelper.Generate(ZXing.BarcodeFormat.EAN_13, barCode, 120, 50);
            g.DrawImage(map, new Point(1, 1));
            // BarCodeEAN13.Paint_EAN13(barCode, g, e.MarginBounds);
        }
    }
}
