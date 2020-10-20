using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;

using CCWin;
using JGNet.Common.Components;

namespace JGNet.Common
{
    public partial class CheckConnectionButton : BaseButton
    { 
        public CheckConnectionButton()
        {
            InitializeComponent();
             
           // this.Click += CheckConnectionButton_Click;
        } 

        private  bool ConnectionCheck()
        {
            bool value = true;
            if (!CommonGlobalUtil.Engine.Connected)
            {
                GlobalMessageBox.Show("网络已断开！");
                value = false;
            }
            return value;
        }

        //private void CheckConnectionButton_Click(object sender, EventArgs e)
        //{
        //    if (!ConnectionCheck()) {
        //        this.Events.;
        //        this.Click += CheckConnectionButton_Click;
        //        return;
        //    }
        //}
    }
}
