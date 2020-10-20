
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using static CCWin.SkinControl.SkinChatRichTextBox;

namespace JGNet.Common
{
    public partial class CostumeStoreTrackSearchInForm : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchInForm()
        {
            InitializeComponent();
            dataGridView_RetailDetail.AutoGenerateColumns = false;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(
                this.dataGridView_RetailDetail, new string[] {
            totalCountDataGridViewTextBoxColumn.DataPropertyName
            })
            {
                ShowColumnSetting = false
            };
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();
        }

        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        GetCostumeStoreChangePara para;
        internal void ShowDialog(GetCostumeStoreChangePara changePara)
        {
            para = new GetCostumeStoreChangePara();
            ReflectionHelper.CopyProperty(changePara, para);
            Search();

            if (!String.IsNullOrEmpty(para.CostumeID)) {
                this.Text += ":款号-" + para.CostumeID;
            }
            this.ShowDialog();
        }

        public void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                InReturnTrackChange listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreChange4In(para);
                if (listPage != null && listPage.PurchaseOrders!=null) {
                    foreach (var item in listPage.PurchaseOrders)
                    {
                        item.ShopName = CommonGlobalCache.GetShopName(item.DestShopID);
                        item.UserName = CommonGlobalCache.GetUserName(item.AdminUserID);
                    }
                }
                dataGridViewPagingSumCtrl.BindingDataSource(listPage?.PurchaseOrders, true,listPage?.PurchaseOrderSum);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }

        private void dataGridView_RetailDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try {
                PurchaseOrder item = dataGridView_RetailDetail.Rows[e.RowIndex].DataBoundItem as PurchaseOrder;
                if (e.ColumnIndex == totalCountDataGridViewTextBoxColumn.Index )
                {
                    ShowForm(item);
                }

            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void ShowForm(PurchaseOrder order)
        {
            //采购进货明细
            CostumeStoreTrackSearchInDetailForm form = new CostumeStoreTrackSearchInDetailForm();
                
            form.BaseModifyCostumeID = para.CostumeID;
           // PurchaseOrder changeOrder = CommonGlobalCache.ServerProxy.GetOnePurchaseOrder(order.ID);
            form.ShowDialog(order);
        }

        private void CostumeStoreTrackSearchInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
