using CCWin.Win32;
using CCWin.Win32.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class InformationForm : BaseForm
    {
        /// <summary>
        /// 点击linkLabel触发
        /// </summary>
        public event CJBasic.Action<bool,EventArgs> LinkClicked;
        public InformationForm(string labelText)
        {
            InitializeComponent();
            this.label_message.Text = labelText;
            this.LinkClicked += delegate { };
        }

        //窗口加载时
        private void FrmInformation_Load(object sender, EventArgs e)
        {
            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            NativeMethods.AnimateWindow(this.Handle, 130, AW.AW_SLIDE + AW.AW_VER_NEGATIVE);//开始窗体动画

          //  this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        
        //倒计时6秒关闭弹出窗
        private void timer1_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }

        private void BaseButton2_Click(object sender, EventArgs e)
        {
            this.LinkClicked?.Invoke(true, null);
            this.Close();
        }
    }
}
