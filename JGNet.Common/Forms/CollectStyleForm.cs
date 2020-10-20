using CCWin;
using JGNet.Common.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class CollectStyleForm : BaseForm
    {

        //private List<Member> currentLeftMembers;
        //private List<Member> currentRightMembers = new List<Member>();
        private List<ListItem<string>> currentRightMembers = new List<ListItem<string>>();

        private List<string> getContent = new List<string>();
        private List<string> leftThings = new List<string>();
        List<ListItem<string>> currentLeftMembers = new List<ListItem<string>>();
        List<ListItem<string>> list = new List<ListItem<string>>();

        /// <summary>
        /// 多款服装被选择时触发
        /// </summary>
        public event System.Action<List<Member>> MemberMultiSelected;

        public CollectStyleForm()
        {
            InitializeComponent(); new DataGridViewPagingSumCtrl(this.dataGridView1).Initialize();
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.MultiSelect = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            new DataGridViewPagingSumCtrl(this.dataGridView2).Initialize();
            this.dataGridView2.MultiSelect = true; this.dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.MemberMultiSelected += delegate { };

            SetLeftDataSource();

        }
        //绑定左边数据源
        private void SetLeftDataSource()
        {
            currentLeftMembers.Add(new ListItem<string>("款号", "款号"));
            currentLeftMembers.Add(new ListItem<string>("商品名称", "商品名称"));
            currentLeftMembers.Add(new ListItem<string>("日期", "日期"));
            currentLeftMembers.Add(new ListItem<string>("供应商", "供应商"));
            currentLeftMembers.Add(new ListItem<string>("品牌", "品牌"));
            currentLeftMembers.Add(new ListItem<string>("单号", "单号"));
            this.dataGridView1.DataSource = currentLeftMembers;
            this.dataGridView1.Refresh();
        }

    

        private void BaseButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.currentRightMembers == null)
                {
                    return;
                }
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewCell item in this.dataGridView1.SelectedCells)
                {          
                        rows.Add(item.OwningRow);           
                }
                IEnumerable<DataGridViewRow> selectedRows = rows;
                foreach (DataGridViewRow item in selectedRows)
                {
                    if (currentRightMembers.Count >= 3)
                    {
                        GlobalMessageBox.Show("一次最多3条！");
                        break;
                    }
                    this.RightListAddItem(this.list[item.Index]);
                }
                this.RefreshDataGridView();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void RightListAddItem(ListItem<string> Member)
        {        
                this.currentRightMembers.Add(Member);
        }

        private void RefreshDataGridView()
        {
            this.SetLeftDataSource();
            this.SetRightDataSource();
        }

        /// <summary>
        /// 设置并绑定右边的Member源
        /// </summary>
        private void SetRightDataSource()
        {
            this.dataGridView2.DataSource = null;
            if (this.currentRightMembers != null && this.currentRightMembers.Count > 0)
            {
                List<ListItem<String>> currentRightSource = new List<ListItem<String>>();
                for (int i = 0; i < this.currentRightMembers.Count; i++)
                {
                    currentRightSource.Add(this.currentRightMembers[i]);
                }
                this.dataGridView2.DataSource = currentRightSource;
            }
            this.dataGridView2.Refresh();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BaseButton3_Click(sender, e);
        }
    }
}
