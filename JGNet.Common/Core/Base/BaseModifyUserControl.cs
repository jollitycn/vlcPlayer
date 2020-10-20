using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common;

namespace JGNet.Common.Core
{
    public partial class BaseModifyUserControl : BaseUserControl
    {


        /// <summary>
        /// 串码调整，查询一个，直接点击一个的解决20181217
        /// 页面是否只允许打开一个，这个页面最后是会自动关闭的
        /// </summary>
        public bool IsShowOnePage { get; set; }
        public bool HasInvokeTabClose { get; set; }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}

        public CJBasic.Action<TabPage, BaseUserControl> TabPage_Close;
        protected void TabPageClose(TabPage currentTabPage, BaseUserControl sourceCtrlType)
        {
            HasInvokeTabClose = true;
            TabPage_Close?.Invoke(currentTabPage, sourceCtrlType);
            //以下是POS端使用
            SaveSuccess();
        }

        public BaseModifyUserControl()
        {
            InitializeComponent();
        }
 
    }
}
