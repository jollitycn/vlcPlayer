using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class TabControl : System.Windows.Forms.TabControl
    {
        public TabControl()
        {
            InitializeComponent();
            this.DrawItem += TabControl_DrawItem;
        }

      

        const int CLOSE_SIZE = 15;
        //tabPage标签图片   
        Bitmap image =  global::JGNet.Common.Properties.Resources.skinTabControl1_PageCloseNormal;

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            try
            {
                Rectangle myTabRect = GetTabRect(e.Index);

                //先添加TabPage属性      
                e.Graphics.DrawString(TabPages[e.Index].Text,
this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);
                //再画一个矩形框   
                using (Pen p = new Pen(Color.White))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框   
                Color recColor = e.State == DrawItemState.Selected
                          ? Color.White : Color.White;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //画关闭符号   
                using (Pen objpen = new Pen(Color.Black))
                {
                    //使用图片   
                    Bitmap bt = new Bitmap(image);
                    Point p5 = new Point(myTabRect.X, 4);
                    e.Graphics.DrawImage(bt, p5);
                }
                e.Graphics.Dispose();
            }
            catch (Exception)
            { }
        }

        //关闭按钮功能   
        private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域      
                Rectangle myTabRect = GetTabRect(SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡      
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y >
myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    TabPages.Remove(SelectedTab);
                }
            }
        }
    }
}
