
using CCWin;
using JGNet.Common;
using JGNet.Common.cache.Wholesale;
using JGNet.Common.Components; 
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class PfCustomerSelectForm : BaseForm
    {


        private List<PfCustomer> PfCustomerList;//当前被绑定的源

        /// <summary>
        /// 会员被选择时触发
        /// </summary>
        public event CJBasic.Action<PfCustomer, EventArgs> ItemSelected;

        public PfCustomerSelectForm(string PfCustomerID, List<PfCustomer> PfCustomers)
        {
            InitializeComponent();
            new DataGridViewPagingSumCtrl(dataGridView1).Initialize();
            this.skinTextBox1.SkinTxt.Text = PfCustomerID;
            this.PfCustomerList = PfCustomers;
            this.BindingDataSource();
        }

        //点击按钮查询
        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string PfCustomerID = this.skinTextBox1.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(PfCustomerID))
                {
                    return;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                this.PfCustomerList = PfCustomerCache.PfCustomerList.FindAll(t => t.ID.ToUpper().Contains(PfCustomerID.ToUpper())); // CommonGlobalCache.ServerProxy.GetPfCustomersLike4IDOrName(PfCustomerID);
                this.BindingDataSource();
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

        //绑定数据源
        private void BindingDataSource()
        {
            //if (this.PfCustomerList != null && this.PfCustomerList.Count != 0)
            //{
            //    foreach (PfCustomer PfCustomer in this.PfCustomerList)
            //    {
            //        PfCustomer.GuideName = CommonGlobalCache.GetUserName(PfCustomer.GuideID);
            //    }
            //}
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.PfCustomerList;
        }
         

        //提交选择的会员
        private void ConfirmSelectCell(PfCustomer PfCustomer)
        {
            if (this.ItemSelected != null)
            {
                this.ItemSelected(PfCustomer, null);
            }
            this.DialogResult = DialogResult.OK;
        }

        //点击确认按钮
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.DataSource == null)
                {
                    return;
                }
                int index = this.dataGridView1.SelectedCells[0].RowIndex;
                this.ConfirmSelectCell(this.PfCustomerList[index]);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
                GlobalMessageBox.Show("确认失败！");
            }
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
         
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            this.ConfirmSelectCell(this.PfCustomerList[e.RowIndex]);
             
        }
    }
}
