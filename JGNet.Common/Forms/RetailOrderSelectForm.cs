
using CCWin;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Core.InteractEntity;
using JGNet.Manage;
using CJBasic.Loggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Manage
{
    public partial class RetailOrderSelectForm : BaseForm
    {


        private List<Member> memberList;//当前被绑定的源
        private List<RetailOrder> retailOrderList;
        private bool isRetailOrderIDQuery;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            if (this.para == null)
            {
                return;
            }
            para.PageIndex = index;
            InteractResult<RetailListPage> result = null;
            if (this.isRetailOrderIDQuery)
            {
              result = CommonGlobalCache.ServerProxy.GetRetailPageLikeID(para);
            }
            else
            {
                result = CommonGlobalCache.ServerProxy.GetRetailPageAdvance(para);
            }
            this.BindingDataSource(result.Data);
        }


        private String shopID;
        public RetailOrderSelectForm(string costumeID, String shopID, bool isRetailOrderIDQuery = true)
        {
            InitializeComponent();
            this.shopID = shopID;
            CostumeCurrentShopTextBox1.ShopID = shopID;
            retailOrderIDTextBox1.ShopID = shopID;
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged, this.baseButton3_Click);
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();
            //  dataGridViewPagingSumCtrl.SpecAutoSizeMode(new TKeyValue<DataGridViewColumn, DataGridViewAutoSizeColumnMode>(remarksDataGridViewTextBoxColumn, DataGridViewAutoSizeColumnMode.ColumnHeader));


            this.isRetailOrderIDQuery = isRetailOrderIDQuery;
            if (this.isRetailOrderIDQuery)
            {
                this.retailOrderIDTextBox1.SkinTxt.Text = costumeID;
                this.CostumeCurrentShopTextBox1.Visible = false;
                this.skinLabel_CostumeID.Visible = false;
            }
            else
            {
                this.CostumeCurrentShopTextBox1.SkinTxt.Text = costumeID;
                this.retailOrderIDTextBox1.Visible = false;
                this.skinLabel_OrderID.Visible = false;
            }
            baseButton3_Click(null, null);
        }


        //绑定数据源
        private void BindingDataSource(RetailListPage page)
        {
            if (page != null)
            {
                retailOrderList = page.ResultList;
            }
            if (this.retailOrderList != null && this.retailOrderList.Count != 0)
            {
                foreach (RetailOrder order in this.retailOrderList)
                {
                    order.GuideName = CommonGlobalCache.GetUserName(order.GuideID);
                    order.ShopName = CommonGlobalCache.GetShopName(order.ShopID);
                }
            }
            if (page != null)
            {
                retailOrderList = page.ResultList;
            }
            dataGridViewPagingSumCtrl.BindingDataSource(this.retailOrderList, null, page.TotalEntityCount, page.RetailOrderSum);
        }

        //双击单元格

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) {
                return;
            }
            this.ConfirmSelectCell(this.retailOrderList[e.RowIndex]);
        }
         

        //提交选择的会员
        private void ConfirmSelectCell(RetailOrder retailOrder)
        {
            if (this.RetailOrderSelected != null)
            {
                this.RetailOrderSelected(retailOrder);
            }
            this.DialogResult = DialogResult.OK;
        }

        /// </summary>
        public event System.Action<RetailOrder> RetailOrderSelected;
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
                this.ConfirmSelectCell(this.retailOrderList[index]);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
            }
        }

        //点击取消按钮
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        RetailPageAdvancePara para = null;

        private void baseButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }


                para = new RetailPageAdvancePara()
                {
                    Advance = 90,
                    CostumeID = this.CostumeCurrentShopTextBox1.Text.Trim(),
                    OrderID = this.retailOrderIDTextBox1.Text.Trim(),
                    ShopID = shopID,
                    PageIndex = 0,
                    PageSize = dataGridViewPagingSumCtrl.PageSize
                };
                InteractResult<RetailListPage> result = null;
                if (this.isRetailOrderIDQuery)
                {

                    result = CommonGlobalCache.ServerProxy.GetRetailPageLikeID(para);
                }
                else
                {
                    result = CommonGlobalCache.ServerProxy.GetRetailPageAdvance(para);
                }
                dataGridViewPagingSumCtrl.OrderPara = para;
                dataGridViewPagingSumCtrl.Initialize(result.Data);
                this.BindingDataSource(result.Data);
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

        private void CostumeCurrentShopTextBox1_CostumeSelected(CostumeItem obj)
        {
            if (obj != null) {
                baseButton3_Click(null,null);
            }
        } 
    }
}
