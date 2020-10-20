using CCWin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Core.Util.IO.Print
{
    public class PrintHelper
    {
        /// <summary>
        /// 静态重复使用
        /// </summary>
        public PrintDocument printDocument = new PrintDocument();
        private PrintDialog printDialog = new PrintDialog();
        private String content= string.Empty;
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private StringReader lineReader;

        public Font PrintFont { get; set; }//当前的打印字体

        public PrintHelper()
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }
        public PrintHelper(PrintPageEventHandler printPageEventHandler)
        {  
            printDocument.PrintPage += printPageEventHandler;
        }

        public void PrintPreview() {
            ShowPageSetup();
            ShowPrintDialog();
        }

        /// <summary>
        /// 直接打印
        /// </summary>
        /// <param name="times"></param>
        public void DirectlyPrint(int times)
        {  //打印事件设置            
            //printPreviewDialog.Document = printDocument;
            //printPreviewDialog.WindowState = FormWindowState.Maximized;
            //if (printPreviewDialog.ShowDialog() == DialogResult.OK || autoPrint)
            //{
                try
                {
                    for (int i = 0; i < times; i++)
                    {
                        printDocument.Print();
                    }
                }
                catch (Exception ex)
                {
                    GlobalMessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());

                }
           // }

        }

        //预览后关闭就打印
        public void Print(bool autoPrint,int times)
        {  //打印事件设置            
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            if (printPreviewDialog.ShowDialog() == DialogResult.OK || autoPrint)
            {
                try
                {
                    for (int i = 0; i < times; i++)
                    {
                        printDocument.Print();
                    }
                }
                catch (Exception ex)
                {
                    GlobalMessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());

                }
            }

        }


        /// <summary>
        /// 根据毫米转英寸
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public static int GetInch(double cm)

        {

            return (int)(cm / 2.54) * 100;

        }




        /// <summary>
        /// 页面设置和打印预览与打印设置原理相同都是构造对话框将用户在对话框中的设置保存到相应的类的属性中
        /// </summary>
        public DialogResult ShowPageSetup()
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            return pageSetupDialog.ShowDialog();
        }


        /// <summary>
        /// 打印设置，构造打印对话框 将对话框中设置的Document属性赋给printDocument这样会将用户的设置自动保存到printDocument 
        /// 的PrinterSettings属性中
        /// </summary>
        public DialogResult ShowPrintDialog()
        {
            printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            return printDialog.ShowDialog();
        }


        /// <summary>
        /// 打印和绘图类似都是调用Graphics 类的方法进行画图 不同的是一个在显示器上一个在打印纸上并且打印要进行一些复杂的计算         如换行、分页等。 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics; //获得绘图对象
            float linesPerPage = 0; //页面的行号
            float yPosition = 0;   //绘制字符串的纵向位置
            int count = 0; //行计数器
            float leftMargin = e.MarginBounds.Left; //左边距
            float topMargin = e.MarginBounds.Top; //上边距
            string line = null; //行字符串
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            linesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(g);//每页可打印的行数
                                                                          //逐行的循环打印一页
            while (count < linesPerPage && ((line = lineReader.ReadLine()) != null))
            {
                yPosition = topMargin + (count * PrintFont.GetHeight(g));
                g.DrawString(line, PrintFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            // 注意：使用本段代码前，要在该窗体的类中定义lineReader对象：
            //       StringReader lineReader = null;
            //如果本页打印完成而line不为空,说明还有没完成的页面,这将触发下一次的打印事件。在下一次的打印中lineReader会
            //自动读取上次没有打印完的内容，因为lineReader是这个打印方法外的类的成员，它可以记录当前读取的位置
            if (line != null)
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                // 重新初始化lineReader对象，不然使用打印预览中的打印按钮打印出来是空白页
                lineReader = new StringReader(content); // textBox是你要打印的文本框的内容
            }
        }


        /// <summary>
        /// 打印预览
        /// </summary>
        public void ShowPrintPreviewDialog()
        {
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            lineReader = new StringReader(content);
            try
            {
                printPreviewDialog.ShowDialog();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
