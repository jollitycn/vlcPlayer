using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;

namespace JGNet.Common
{
    public partial class YearMonthPicker : DateTimePicker
    {
        private DateTime lastSelectDateTime;
        public YearMonthPicker()
        {
            InitializeComponent();
           
        }
         

        public void Initialize()
        {
            this.Focus();
            lastSelectDateTime = this.Value;
         //   CommonGlobalUtil.Debug("old value："+ this.Value.ToLongDateString());
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{UP}");
            SendKeys.SendWait("{DOWN}");
            //CommonGlobalUtil.Debug("new value："+this.Value.ToLongDateString());
            //if (lastSelectDateTime.Year != this.Value.Year)
            //{
            //    //选择的是年份
            //    SendKeys.SendWait("{DOWN}");
            //    SendKeys.SendWait("{RIGHT}");
            //    SendKeys.SendWait("{UP}");
            //    SendKeys.SendWait("{DOWN}");
            //}
            //else {
            //    //选中了月份
            //    SendKeys.SendWait("{DOWN}");
            //}
        }
    }
}
