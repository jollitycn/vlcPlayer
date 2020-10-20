using CCWin.SkinControl;
using JGNet.Common.Core.Util;
using CJBasic;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class ExportButton<T> : BaseButton
    {

        public String FileName { get; set; }
        
        public DataGridView DataGridView { get; set; }
        public ExportButton()
        {
            InitializeComponent();
            this.Click += Button_Click;
            this.Text = "导出";
        }

        private String path;
        private void Button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FileName)) {
                GlobalMessageBox.Show("请设置FileName属性！");
                return;
            }
            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", FileName + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (String.IsNullOrEmpty(path))
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoExport);
                cb.BeginInvoke(null, null);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
        }

        private void DoExport()
        {
            try
            {
                if (DataGridView==null)
                {
                    ShowMessage("请设置FileName属性！");
                    return;
                }
                List<T> list = DataGridView.DataSource as List<T>;
                List<String> keys = new List<string>();
                List<String> values = new List<string>();
                foreach (DataGridViewColumn item in DataGridView.Columns)
                {
                    if (item.Visible)
                    {
                        keys.Add(item.DataPropertyName);
                        values.Add(item.HeaderText);
                    }
                }

                NPOIHelper.Keys = keys.ToArray();
                NPOIHelper.Values = values.ToArray();//new System.Collections.SortedList();
                NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);
                ShowMessage("导出完毕！");
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }

       

    }
}
