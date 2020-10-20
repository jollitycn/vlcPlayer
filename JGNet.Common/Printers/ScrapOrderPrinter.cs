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
    public class ScrapOrderPrinter
    {

        //简单打印示例
        public static void Print(ScrapOrder item, DataGridView dataGridView2, int times = 1)
        {
            //if (times < 0) { times = 0; }

            //for (int i = 0; i < times; i++)
            //{

            GoldPrinter.MisGoldPrinter misGoldPrinter = new GoldPrinter.MisGoldPrinter(false, new PrinterMargins(20, 20, 20, 20, 787, 1129));

            misGoldPrinter.Title = "报损单";                           //主标题（C#用\n表示换行）	
            misGoldPrinter.Caption = "";                                        //副标题
                                                                                //misGoldPrinter.Top = "单号：" + item.AllocateOrder.ID + "|收货方：" + CommonGlobalCache.GetShopName(item.AllocateOrder.DestShopID) + "|开单日期：" + item.AllocateOrder.CreateTime;                                       //抬头，一行三列的文字说明，用|分隔

            Header header = new Header(4, 2);                   //行列数基本不受限制，但超过一页失去意义，因为以Body为主，以其它为辅
            header.IsDrawAllPage = true;                        //可以指定每页是否重复打印
            header.SetText(0, 0, "报损单号：" + item.ID); 
            header.SetText(0, 1, "开单时间：" + item.CreateTime.GetDateTimeFormats('f')[0].ToString());                        //DataSource可以是字符串、一维数组、二维数组、DataTable、WinDataGrid、WebDataGrid、ListView\ListView、
            header.SetText(1, 0, "店    铺：" + CommonGlobalCache.GetShopName(item.ShopID));
            header.SetText(1, 1, "操 作 人：" + CommonGlobalCache.GetUserName(item.OperatorUserID));               //同仁们还可以根据实际应用对GridBase的DataSource进行扩展
            header.SetText(2, 0, "总 数 量：" + item.TotalCount.ToString());
            header.SetText(2, 1, "总 金 额：" + item.TotalPrice.ToString());                //同仁们还可以根据实际应用对GridBase的DataSource进行扩展
            header.SetText(3, 0, "备    注：");
            header.SetText(3, 1, item.Remarks);   

            misGoldPrinter.Header = header;                     //将定制对象，赋给页头	
                                                                // misGoldPrinter.Top = new String[] { "单号：" + item.AllocateOrder.ID + "|收货方：" + CommonGlobalCache.GetShopName(item.AllocateOrder.DestShopID) + "|开单日期：" + item.AllocateOrder.CreateTime,
                                                                //  "发货方：" + CommonGlobalCache.GetShopName(item.AllocateOrder.SourceShopID) + "|操作人：" + CommonGlobalCache.GetUserName(item.AllocateOrder.SourceUserID) + "|打印日期：" + System.DateTime.Now.ToLongDateString()  };                                       //抬头，一行三列的文字说明，用|分隔


            //  misGoldPrinter.Bottom = "发货方：" + CommonGlobalCache.GetShopName(item.AllocateOrder.SourceShopID) + "|操作人：" + CommonGlobalCache.GetUserName(item.AllocateOrder.SourceUserID) + "|打印日期：" + System.DateTime.Now.ToLongDateString() + "|";  //结尾，说明同抬头
            misGoldPrinter.DataSource = DataGridViewUtil.ToStringArray(dataGridView2, true, true);
            if (!Directory.Exists(CommonGlobalUtil.SystemDir + "EXPORTS\\"))
            {
                Directory.CreateDirectory(CommonGlobalUtil.SystemDir + "EXPORTS\\");
            }
            misGoldPrinter.FileName = CommonGlobalUtil.SystemDir + "EXPORTS\\" + item.ID + ".jpg";
            ((GoldPrinter.Body)(misGoldPrinter.Body)).Font = dataGridView2.Font;

            int[] widths = new int[] {
                80,100,40, 30,
                30,30,30,30,30,30,30,30,30,30,30
                ,40,50,50
            };
            List<int> widthList = new List<int>();
            for (int i = 0; i <
            dataGridView2.Columns.Count; i++)
            {
                DataGridViewColumn column= dataGridView2.Columns[i];
                if (column.Visible && !String.IsNullOrEmpty(column.HeaderText))
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