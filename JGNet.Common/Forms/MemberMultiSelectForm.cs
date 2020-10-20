using CCWin;
using JGNet.Common.Components;
using JGNet.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class MemberMultiSelectForm : BaseForm
    {

        private List<Member> currentLeftMembers;
        private List<Member> currentRightMembers = new List<Member>();
         

        /// <summary>
        /// 多款服装被选择时触发
        /// </summary>
        public event System.Action<List<Member>> MemberMultiSelected;

        public MemberMultiSelectForm()
        {
            InitializeComponent();
            new DataGridViewPagingSumCtrl(this.dataGridView1).Initialize();
            this.dataGridView1.MultiSelect = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            new DataGridViewPagingSumCtrl(this.dataGridView2).Initialize();
            this.dataGridView2.MultiSelect = true; this.dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.MemberMultiSelected+= delegate { };
            this.skinTextBox1.SkinTxt.KeyDown += SkinTxt_KeyDown;
        }
         

        private void SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BaseButton_Search_Click(null, null);
            }
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string memberID = this.skinTextBox1.SkinTxt.Text.Trim();
                //if (string.IsNullOrEmpty(memberID))
                //{
                //    return;
                //}
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                this.currentLeftMembers = CommonGlobalCache.ServerProxy.GetMembers4PhoneNumber(memberID);
                if (currentLeftMembers != null && HasPermission(RolePermissionMenuEnum.会员管理, RolePermissionEnum.查看_只看本店))
                {
                    currentLeftMembers = currentLeftMembers.FindAll(t => t.ShopID == CommonGlobalCache.CurrentShopID);
                }

                this.SetLeftDataSource();
            }
            catch (Exception ee)
            {
                WriteLog(ee);
            }
            finally
            {
                UnLockPage();
            }
        }

        /// <summary>
        /// 设置并绑定左边的Member源
        /// </summary>
        private void SetLeftDataSource()
        {
            this.dataGridView1.DataSource = null;
            if (this.currentLeftMembers != null && this.currentLeftMembers.Count > 0)
            {
                foreach (var member in currentLeftMembers)
                {
                    member.GuideName = CommonGlobalCache.GetUserName(member.GuideID);
                }

                this.dataGridView1.DataSource = currentLeftMembers;
            }
            this.dataGridView1.Refresh();
        }

        /// <summary>
        /// 设置并绑定右边的Member源
        /// </summary>
        private void SetRightDataSource()
        {
            this.dataGridView2.DataSource = null;
            if (this.currentRightMembers != null && this.currentRightMembers.Count > 0)
            {
                List<Member> currentRightSource = new List<Member>();
                for (int i = 0; i < this.currentRightMembers.Count; i++)
                {
                    currentRightSource.Add(this.currentRightMembers[i]);
                }
                this.dataGridView2.DataSource = currentRightSource;
            }
            this.dataGridView2.Refresh();
        }

        /// <summary>
        /// 刷新左右两边的DataGridView
        /// </summary>
        private void RefreshDataGridView()
        {
            this.SetLeftDataSource();
            this.SetRightDataSource();
        }

        //点击左边部分服装移动到右边
        private void BaseButtonAddSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.currentRightMembers == null || this.currentLeftMembers == null)
                {
                    return;
                }
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewCell item in this.dataGridView1.SelectedCells)
                {
                    if (!rows.Exists(t => t == item.OwningRow))
                    {
                        rows.Add(item.OwningRow);
                    }

                }
                IEnumerable<DataGridViewRow> selectedRows = rows;
                foreach (DataGridViewRow item in selectedRows)
                {
                    if (currentRightMembers.Count >= 100)
                    {
                        GlobalMessageBox.Show("一次最多100条！");
                        break;
                    }
                    this.RightListAddItem(this.currentLeftMembers[item.Index]);
                }
                this.RefreshDataGridView();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        /// <summary>
        /// 将服装移动到右边
        /// </summary>
        /// <param name="Member"></param>
        private void RightListAddItem(Member Member)
        {
         
            if (!this.currentRightMembers.Exists(x => x.PhoneNumber == Member.PhoneNumber))
            {
                this.currentRightMembers.Add(Member);
            }

        }

        //点击按钮移动左边的全部到右边列表中
        private void BaseButtonAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.currentRightMembers == null || this.currentLeftMembers == null)
                {
                    return;
                }
               
                foreach (Member item in this.currentLeftMembers)
                {
                    if (currentRightMembers.Count >= 100)
                    {
                        GlobalMessageBox.Show("一次最多100条！");
                        break;
                    }
                    this.RightListAddItem(item);
                }
               // this.currentLeftMembers.Clear();
                this.RefreshDataGridView();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        //点击按钮移除右边所有服装
        private void BaseButtonRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.currentRightMembers.Clear();
                this.SetRightDataSource();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        //点击按钮移除右边部分服装
        private void BaseButtonRemoveSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.currentRightMembers == null)
                {
                    return;
                } 

                List<Member> costumes = new List<Member>(); 
                foreach (DataGridViewCell item in this.dataGridView2.SelectedCells)
                {
                    if (!costumes.Exists(t => t == item.OwningRow.DataBoundItem))
                    {
                        costumes.Add(item.OwningRow.DataBoundItem as Member);
                    }
                }

                foreach (var item in costumes)
                {
                    this.currentRightMembers.Remove(item);
                }
                this.SetRightDataSource();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            } 
        }

        //点击按钮 选中服装提交
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                //this.Hide();
                this.MemberMultiSelected(this.currentRightMembers);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally { UnLockPage(); }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonAddSingle_Click(sender, e);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonRemoveSingle_Click( sender,  e);
        } 
    }
}
