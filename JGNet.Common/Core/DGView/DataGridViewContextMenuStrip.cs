using JGNet.Common.Core;
using JGNet.Core.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class DataGridViewContextMenuStrip : ContextMenuStrip
    {


        public bool Debug { get; set; }
      public bool Disabled { get; set; }
        private void View_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ShowMenu(sender, e);
        }

        public event CJBasic.Action<SizeGroup, Control> SizeGroupChanged;
        public DataGridViewContextMenuStrip()
        {
            InitializeComponent();
            List<ToolStripItem> stripItems = new List<ToolStripItem>();
            foreach (var item in CommonGlobalCache.SizeGroupList)
            {
                if (item.Enabled)
                {
                    stripItems.Add(new ToolStripMenuItem(item.DisplayName, null, toolStripMenuItem1_Click) { Tag = item });
                }
            }
            toolStripMenuItem1.DropDownItems.AddRange(stripItems.ToArray());
            toolStripMenuItem1.Visible = false;
        }

        internal void ChangeSizeGroup(SizeGroup group)
        {
            sizeGroup = group;
            CommonGlobalUtil.ChangeSizeGroup(view, sizeGroup);
            SizeGroupChanged?.Invoke(sizeGroup, view);
        }

        public void ShowMenu(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                view = sender as DataGridView;
                this.Show(view, new Point(1, 1));
            }
        }

        private DataGridView view;
        public DataGridView DataGridView
        {
            get { return view; }
            set
            {
                if (value != null)
                {
                    view = value;
                    view.CellClick -= View_CellClick;
                    view.CellClick += View_CellClick;
                    if (IsCostumeSizeMenuVisible)
                    {

                        //注释 complete 在 DataGridViewPagingSumCtrl 有处理

                        //  view.DataSourceChanged -= View_DataSourceChanged;
                        //  view.DataSourceChanged += View_DataSourceChanged;
                      view.DataBindingComplete -= View_DataBindingComplete;
                        view.DataBindingComplete += View_DataBindingComplete;
                        // CommonGlobalUtil.ChangeSizeGroup(view, sizeGroup);
                    }
                } 
            }
        }

   

        public bool IsCostumeSizeMenuVisible { get; set; }

        /// <summary>
        /// 绑定完成的时候，记录哪些列的显示状态，供给工具中使用的状态切换时可以判断显示的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Debug)
            {
                CommonGlobalUtil.Debug("Begin View_DataBindingComplete" + DateTime.Now);
            }
            if (!Disabled)
            {
                CommonGlobalUtil.ChangeSizeGroup(view, sizeGroup, true);
            }
            // CheckCommonSize();
            // CheckAtmSize();
            if (Debug)
            {
                CommonGlobalUtil.Debug("End View_DataBindingComplete" + DateTime.Now);
            }
        }

        //private void CheckAtmSize()
        //{
        //    int fromColumnIndex = -1;
        //    int toColumnIndex = -1;
        //    foreach (DataGridViewColumn item in view.Columns)
        //    {
        //        if (item.DataPropertyName.ToUpper() == CostumeSize.F + "ATM")
        //        {
        //            fromColumnIndex = item.Index;
        //        }
        //        else if (item.DataPropertyName.ToUpper() == CostumeSize.XL6 + "ATM")
        //        {
        //            toColumnIndex = item.Index;
        //        }
        //    }
        //    if (fromColumnIndex > -1 && toColumnIndex > -1)
        //    {
        //        foreach (DataGridViewRow row in view.Rows)
        //        {
        //            for (int i = fromColumnIndex; i < toColumnIndex + 1; i++)
        //            {
        //                if (!view.Columns[i].Visible && row.Cells[i].Value?.ToString() != "0")
        //                {
        //                    view.Columns[i].Visible = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}

        //private void CheckCommonSize()
        //{
        //    int fromColumnIndex = -1;
        //    int toColumnIndex = -1;
        //    foreach (DataGridViewColumn item in view.Columns)
        //    {
        //        if (item.DataPropertyName == CostumeSize.F)
        //        {
        //            fromColumnIndex = item.Index;
        //        }
        //        else if (item.DataPropertyName == CostumeSize.XL6)
        //        {
        //            toColumnIndex = item.Index;
        //        }
        //    }

        //    if (fromColumnIndex > -1 && toColumnIndex > -1)
        //    {
        //        foreach (DataGridViewRow row in view.Rows)
        //        {
        //            for (int i = fromColumnIndex; i < toColumnIndex + 1; i++)
        //            {
        //                if (!view.Columns[i].Visible && row.Cells[i].Value?.ToString() != "0")
        //                {
        //                    view.Columns[i].Visible = true;
        //                    break;
        //                    //这个时候就要切换设置选项
        //                }
        //            }
        //        }
        //    }
        //}

        private SizeGroup sizeGroup = CommonGlobalCache.DefaultSizeGroup;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null && menuItem.Tag != null)
            {
                if (menuItem.Tag is SizeGroup)
                {
                    sizeGroup = menuItem.Tag as SizeGroup;
                    //  menuItem.Owner;
                    CommonGlobalUtil.ChangeSizeGroup(view, sizeGroup,false);
                    SizeGroupChanged?.Invoke(sizeGroup, view);
                    return;
                }
            }
        }

        internal void RefreshSizeGroup()
        {
            CommonGlobalUtil.ChangeSizeGroup(view, sizeGroup, false);
            SizeGroupChanged?.Invoke(sizeGroup, view);
        }
    }
}
