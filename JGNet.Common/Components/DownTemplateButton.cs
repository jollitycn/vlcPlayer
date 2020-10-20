using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

using System.Text;


namespace JGNet.Common.Components
{
    public partial class DownTemplateButton : BaseButton
    {

        public String FileName { get; set; }
        public String DownName { get; set; }
        public DownTemplateButton()
        {
            InitializeComponent();
            this.Click += DownTemplateButton_Click;
            this.Text = "下载模板";
        }

        private void DownTemplateButton_Click(object sender, EventArgs e)
        {  //找到EXCEL模板文件
            String sourceFile = System.Environment.CurrentDirectory + "\\Templates\\" + FileName;
            String path = "";
            path = FileUtil.BrowseFolder("请选择保存模板的位置");
            if (String.IsNullOrEmpty(path))
            {
                return;
            }


            if (String.IsNullOrEmpty(DownName)) {
                DownName = FileName;
            }

            String toPath = path + "\\" + DownName;
            System.IO.File.Copy(sourceFile, toPath, true);
            GlobalMessageBox.Show("模板保存" + toPath + "！");
        }
    }
}
