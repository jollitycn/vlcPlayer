using CCWin;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.InteractEntity;
using CJBasic.Loggers;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class GlobalErrorMessageBox : Common.BaseForm
    {
        public GlobalErrorMessageBox()
        {
            InitializeComponent();
            //this.Text = "期初库存导入"; 
            this.Initialize();
        }

        private void Initialize()
        {
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String path = FileUtil.BrowseFolder("请选择保存的位置");
            if (String.IsNullOrEmpty(path))
            {
                return;
            }
            path += "\\错误报告" + DateTime.Now.ToString(DateTimeUtil.File_DATETIME_FORMAT) + ".txt";
            System.IO.File.WriteAllText(path, this.labelContent.Text);
            GlobalMessageBox.Show("已保存到" + path + "！");
        }

        private static GlobalErrorMessageBox messageBox;
        public static DialogResult Show(Form form, string content, string title)
        {
                messageBox?.Dispose();
                messageBox = new GlobalErrorMessageBox();
                messageBox.labelContent.Text = content;
                messageBox.Text = title;
            return messageBox.ShowDialog(form);
        
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
