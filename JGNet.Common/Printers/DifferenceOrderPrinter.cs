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

namespace JGNet.Common.Core.Util
{
    public class DifferenceOrderPrinter
    {

        //简单打印示例
        public static void Print(DifferenceOrder item, DataGridView dataGridView2, int times = 1)
        { 
            GoldPrinter.MisGoldPrinter misGoldPrinter = new GoldPrinter.MisGoldPrinter(false, new PrinterMargins(20, 20, 20, 20, 787, 1129));
            misGoldPrinter.Title = "差异单";                           //主标题（C#用\n表示换行）	
            misGoldPrinter.Caption = "";
            Header header = new Header(3, 2);                   //行列数基本不受限制，但超过一页失去意义，因为以Body为主，以其它为辅
            header.IsDrawAllPage = true;                        //可以指定每页是否重复打印
            header.SetText(0, 0, "差异单号：" + item.ID);
            header.SetText(0, 1, "来源单号：" + item.SourceOrderID);                      //DataSource可以是字符串、一维数组、二维数组、DataTable、WinDataGrid、WebDataGrid、ListView\ListView、
            header.SetText(1, 0, "发 货 方：" + CommonGlobalCache.GetShopName(item.OutboundShopID));
            header.SetText(1, 1, "收 货 方：" + CommonGlobalCache.GetShopName(item.InboundShopID));      
            header.SetText(2, 0, "差异(盈)：" + item.DiffCountWin.ToString());
            header.SetText(2, 1, "差异(亏)：" + item.DiffCountLost.ToString());      
            misGoldPrinter.Header = header;
            misGoldPrinter.DataSource = DataGridViewUtil.ToStringArray(dataGridView2, true, true);
            if (!Directory.Exists(CommonGlobalUtil.SystemDir + "EXPORTS\\"))
            {
                Directory.CreateDirectory(CommonGlobalUtil.SystemDir + "EXPORTS\\");
            }

            misGoldPrinter.FileName = CommonGlobalUtil.SystemDir + "EXPORTS\\" + item.ID + ".jpg";
            ((GoldPrinter.Body)(misGoldPrinter.Body)).Font = dataGridView2.Font;
            int[] widths = new int[] {
                80,100,40, 50,
                30,30,30,30,30,30,30,30,30,30,30
                ,40,50 
            };
            // int[] widths=  DataGridViewUtil.GetColsWidth(dataGridView2);
            List<int> widthList = new List<int>();
            for (int i = 0; i <
            dataGridView2.Columns.Count; i++)
            {
                if (dataGridView2.Columns[i].Visible)
                {
                    widthList.Add(widths[i]);
                }
            }
            widths = widthList.ToArray();
            int newWidth = 787;
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
            misGoldPrinter = null;
        }
    }
}