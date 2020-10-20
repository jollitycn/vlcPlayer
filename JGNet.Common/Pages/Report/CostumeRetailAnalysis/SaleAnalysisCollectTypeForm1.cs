using CCWin;
using CCWin.SkinControl;
using JGNet.Core.InteractEntity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JGNet.Core; 
using JGNet.Core.Tools;
using CJBasic.Loggers; 
using System.Reflection;
using JGNet.Common.Components;
using JGNet.Common;

namespace JGNet.Manage.Pages
{
    //继承DIALOGform,设置界面不闪动
    public partial class SaleAnalysisCollectTypeForm1 : BaseForm
    {


        private List<ListItem<String>> targets;
        private List<ListItem<String>> queryResults;

        private CostumeListPagePara pagePara;

        private bool filterValid { get; set; }
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public   List<ListItem<String>> Result
        {
            get
            { 
                return targets;
            }
        }

        public SaleAnalysisCollectTypeForm1()
        {
            try
            {
                InitializeComponent();
                this.filterValid = filterValid;
                dataGridViewQueryResults.AutoGenerateColumns = false;
                dataGridViewTarget.AutoGenerateColumns = false;
                dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridViewQueryResults);
                dataGridViewPagingSumCtrl.Initialize();
                dataGridViewQueryResults.MultiSelect = true;
                this.dataGridViewQueryResults.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                new DataGridViewPagingSumCtrl(this.dataGridViewTarget).Initialize();
                dataGridViewTarget.MultiSelect = true;
                this.dataGridViewTarget.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    queryResults = new List<ListItem<string>>();
                    queryResults.Add(new ListItem<string>("店铺", "店铺"));
                    queryResults.Add(new ListItem<string>("供应商", "供应商"));
                    queryResults.Add(new ListItem<string>("品牌", "品牌"));
                    queryResults.Add(new ListItem<string>("大类", "大类"));
                    queryResults.Add(new ListItem<string>("小类", "小类"));
                queryResults.Add(new ListItem<string>("款号", "款号"));
                queryResults.Add(new ListItem<string>("名称", "名称"));
                queryResults.Add(new ListItem<string>("年份", "年份"));
                dataGridViewQueryResults.DataSource = queryResults;
               
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void BaseButtonRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.targets = null;
                this.dataGridViewTarget.DataSource = null;

            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void BaseButtonAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                CheckTargets();
                if (queryResults != null)
                {
                    
                    foreach (var item in queryResults)
                    {
                        if (targets.Count >= 10)
                        {
                            GlobalMessageBox.Show("一次最多10条！");
                            break;
                        }
                        if (!targets.Exists(x => x.Key == item.Key))
                        {
                            targets.Add(item);
                        }
                    }
                }

                this.dataGridViewTarget.DataSource = null;
                this.dataGridViewTarget.DataSource = targets;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void CheckTargets()
        {
            if (targets == null)
            {
                targets = new List<ListItem<String>>();
            }
            else
            {
                targets = (List<ListItem<String>>)this.dataGridViewTarget.DataSource;
            }

        }

        private void BaseButtonAddSingle_Click(object sender, EventArgs e)
        {

            try
            {
                CheckTargets();

                List<DataGridViewRow> rows = new List<DataGridViewRow>();
               
                foreach (DataGridViewCell item in this.dataGridViewQueryResults.SelectedCells)
                {
                   
                    if (!rows.Exists(t => t == item.OwningRow))
                    {
                        rows.Add(item.OwningRow);
                    }

                }
                IEnumerable<DataGridViewRow> selectedRows = rows;
                foreach (DataGridViewRow item in selectedRows)
                {
                    if (targets.Count >= 10)
                    {
                        GlobalMessageBox.Show("一次最多10条！");
                        break;
                    }
                    ListItem<String> c = (ListItem<String>)item.DataBoundItem;

                    if (!targets.Exists(x => x.Key == c.Key))
                    {
                        targets.Add(c);
                    }
                }



                this.dataGridViewTarget.DataSource = null;

                this.dataGridViewTarget.DataSource = targets;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void BaseButtonRemoveSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.targets == null)
                {
                    return;
                }

                List<ListItem<String>> costumes = new List<ListItem<String>>();
                foreach (DataGridViewCell item in this.dataGridViewTarget.SelectedCells)
                {
                    if (!costumes.Exists(t => t == item.OwningRow.DataBoundItem))
                    {
                        costumes.Add(item.OwningRow.DataBoundItem as ListItem<String>);
                    }
                }

                foreach (var item in costumes)
                {
                    this.targets.Remove(item);
                }

                this.dataGridViewTarget.DataSource = null;

                this.dataGridViewTarget.DataSource = targets;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

        }
         

        private List<ListItem<String>> ParameterConfigList(List<ListItem<String>> listItems)
        {
            List<ListItem<String>> list = new List<ListItem<String>>();
            list.Add(new ListItem<String>(CommonGlobalUtil.COMBOBOX_ALL, null));
            list.AddRange(listItems);
            return list;
        }
          


        /// <summary>
        /// 将集合中GuideName赋值
        /// </summary>
        /// <param name="memberList"></param>
        private void SetOtherValue(List<Costume> list)
        {
            foreach (Costume item in list)
            {
                String name = CommonGlobalCache.GetSupplierName(item.SupplierID);
                item.SupplierName = name;
                item.BrandName = CommonGlobalCache.GetBrandName(item.BrandID);
            }
        } 

        private void BaseButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
        private void dataGridViewQueryResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonAddSingle_Click(sender, e);
        }

        private void dataGridViewTarget_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonRemoveSingle_Click(sender, e);
        } 
    }
}
