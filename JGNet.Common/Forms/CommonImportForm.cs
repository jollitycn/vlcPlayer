using CCWin;
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
    public partial class CommonImportForm : Common.BaseForm
    {
       
        public String Path
        {
            get
            {
                return path;
            }
        }

        private String path;


        public Action<String> ConfirmClick;

        public CommonImportForm(String title, String fileName, String downName = null)
        {
            InitializeComponent();
            baseButtonDownTemplate.FileName = fileName;
            if (!String.IsNullOrEmpty(downName))
            {
                baseButtonDownTemplate.DownName = downName;
            }
            this.Text = title;
            this.Initialize();
        }

        private void Initialize()
        { 
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            this.skinPanel2.Enabled = false;
            if (string.IsNullOrEmpty(path))
            {
                GlobalMessageBox.Show("请选择文件!");
                this.UseWaitCursor = false;
                this.skinPanel2.Enabled = true;
                return;
            }

            ConfirmClick?.Invoke(path);
        }

        public void SetDialogResult(DialogResult result)
        {
            this.skinPanel2.Enabled = true;
            this.DialogResult = result;
            this.UseWaitCursor = false;
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void Cancel()
        {
            this.skinPanel2.Enabled = true;
            this.UseWaitCursor = false;
        }

        private void baseButtonChooseFile_Click(object sender, EventArgs e)
        {
            path = CJBasic.Helpers.FileHelper.GetFileToOpen("请选择导入文件");
            textBoxPath.Text = path;
            if (String.IsNullOrEmpty(path))
            {
                //      GlobalMessageBox.Show("请选择文件！");
                return;
            }
            else
            {
                string fileExt =System.IO.Path.GetExtension(path);
                if (fileExt != ".xlsx" && fileExt != ".xls")
                {
                    ShowMessage("你所选择文件格式不正确，请重新上传文件！");
                    return;
                }
            }
        }

    }
}
