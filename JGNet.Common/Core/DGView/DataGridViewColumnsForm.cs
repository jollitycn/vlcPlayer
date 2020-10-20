
using CCWin;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Core;
using JGNet.Core.InteractEntity;
using JGNet.Common;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using JGNet.Core.Tools;

namespace JGNet.Common
{
    public partial class DataGridViewColumnsForm : BaseForm
    {


        public static List<ColumnSetting> GetColumnSettings(DataGridView gridView, List<DataGridViewColumn> NotShowColumns)
        {
            //获取尺码设置信息
            List<ColumnSetting> listItems = new List<ColumnSetting>();
            foreach (DataGridViewColumn item in gridView.Columns)
            {
                //如果有显示，如果这个列表这个列是有显示的话，那么加入这个列中
                DataGridViewColumn columnNotShow = NotShowColumns?.Find(t => t == item);
                if (curControl!=null && curControl.ToString() == "JGNet.Common.CustomerInventorySearchCtrl" && !(item is DataGridViewCheckBoxColumn || item is DataGridViewImageColumn))
                {
                    bool isHasCostomerID = false;
                    Control.ControlCollection sonControls = curControl.Controls;
                    //遍历所有控件  
                    foreach (Control control in sonControls) 
                    {
                        if (control.Name == "skinPanel1")
                        {

                            Control.ControlCollection childSonControls = control.Controls;
                            foreach (Control childcontrol in childSonControls)
                            {
                                if (childcontrol.Name == "skinTextBox_costumeID")
                                {
                                    CostumeTextBox c = (CostumeTextBox)childcontrol;
                                    if (c.SkinTxt.Text != "")
                                    {
                                        isHasCostomerID = true;
                                        break;
                                    }
                                }
                            }
                            if (isHasCostomerID)
                            {
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                       // listBox1.Items.Add(control.Name);
                    }

                    if (isHasCostomerID)
                    {
                        if (item.HeaderText != "款号" && item.HeaderText!= "商品名称" && item.HeaderText != "颜色" && item.HeaderText != "尺码")
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (item.HeaderText != "客户" && item.HeaderText != "发货" && item.HeaderText != "销售" && item.HeaderText != "库存")
                        {
                            continue;
                        }
                    }
                    



                    listItems.Add(new ColumnSetting()
                    {
                        HeaderIndex = item.Index,
                        HeaderID = item.DataPropertyName,
                        HeaderText = item.HeaderText,
                        Visible = item.Visible,
                        Width = item.Width,
                        ColWidth = item.Width,
                        Enabled = (columnNotShow == null)
                    });
                }
                else
                if (!(item is DataGridViewLinkColumn  || item is DataGridViewCheckBoxColumn || item is DataGridViewImageColumn))
                {

                    if (item.HeaderText == EnumHelper.GetDescription(RolePermissionEnum.查看_品牌))
                    {
                        if (!PermissonUtil.HasPermission(RolePermissionMenuEnum.不限, RolePermissionEnum.查看_品牌))
                        {
                            continue;
                        }
                    }
                    else if (item.HeaderText == EnumHelper.GetDescription(RolePermissionEnum.查看_成本价))
                    {
                        if (!PermissonUtil.HasPermission(RolePermissionMenuEnum.不限, RolePermissionEnum.查看_成本价))
                        {
                            continue;
                        }
                    }
                    else if (!PermissonUtil.HasPermission(RolePermissionMenuEnum.畅滞排行榜, RolePermissionEnum.查看_备注))
                    {
                        if (item.HeaderText == EnumHelper.GetDescription(RolePermissionEnum.查看_备注))
                        {
                            continue;
                        }
                    }
                    //if (curControl is CostumeRetailAnalysisCtrl && item.Name.Contains("TypeValue"))
                    //{
                    //    continue;
                    //}

                    listItems.Add(new ColumnSetting()
                    {
                        HeaderIndex = item.Index,
                        HeaderID = item.DataPropertyName,
                        HeaderText = item.HeaderText,
                        Visible = item.Visible,
                        Width = item.Width,
                        ColWidth=item.Width, 
                        Enabled = (columnNotShow == null)
                    });
                }

            
            }
            return listItems;
        }

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        private static Control curControl;
        public event CJBasic.Action<List<ColumnSetting>, EventArgs> ItemSelected;
        private DataGridView dataGridView; 

        private List<DataGridViewColumn> NotShowColumns { get; set; }
        public DataGridViewColumnsForm(DataGridView gridView, List<DataGridViewColumn> notShowColumns, Control control)
        {
            InitializeComponent();
            if (notShowColumns != null)
            {
                this.NotShowColumns = notShowColumns;
            }
            curControl = control;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridViewSizeRange)
            {
                PanelTop = false
            };
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewSizeRange.AutoGenerateColumns = false;
            this.dataGridView = gridView;
            List<ColumnSetting> columnSettings = GetColumnSettings(gridView, notShowColumns);
            this.dataGridViewPagingSumCtrl.SetDataSource(columnSettings);
            this.skinCheckBoxSelectAll.CheckedChanged += this.skinCheckBoxSelectAll_CheckedChanged;
        }

        //点击确认按钮
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewSizeRange.DataSource == null)
                {
                    return;
                }
                this.ConfirmSelectCell(dataGridViewSizeRange);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void ConfirmSelectCell(DataGridView dataGridViewSizeRange)
        {
            List<ColumnSetting> list = dataGridViewSizeRange.DataSource as List<ColumnSetting>;
            this.ItemSelected?.Invoke(list, null);
            this.DialogResult = DialogResult.OK;
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void skinCheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            List<ColumnSetting> list = dataGridViewSizeRange.DataSource as List<ColumnSetting>;
            foreach (ColumnSetting detail in list)
            {
                detail.Visible = this.skinCheckBoxSelectAll.Checked;
            }

            this.dataGridViewPagingSumCtrl.Refresh();
        }

        private void dataGridViewSizeRange_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dataGridView.IsCurrentCellDirty)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewSizeRange_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !view.Rows[e.RowIndex].IsNewRow)
                {
                    List<ColumnSetting> list = (List<ColumnSetting>)view.DataSource;
                    ColumnSetting item = (ColumnSetting)list[e.RowIndex];

                    if (Column5.Index == e.ColumnIndex) {
                        item.Visible = (bool)view[e.ColumnIndex, e.RowIndex].Value;
                        CheckBoxSelectAll(view);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void CheckBoxSelectAll(DataGridView dataGridView)
        {
            dataGridView.Refresh();
            this.skinCheckBoxSelectAll.CheckedChanged -= this.skinCheckBoxSelectAll_CheckedChanged;
            skinCheckBoxSelectAll.Checked = true;
            List<ColumnSetting> list = (List<ColumnSetting>)dataGridView.DataSource;
            foreach (var item in list)
            {
                if (!item.Visible && item.Enabled) {

                     skinCheckBoxSelectAll.Checked = false;
                     break;
                }
            }
            this.skinCheckBoxSelectAll.CheckedChanged += this.skinCheckBoxSelectAll_CheckedChanged;

        }
    }
}
