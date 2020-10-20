
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
    public partial class CostumeStoreTrackSearchRetailForm : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchRetailForm()
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
                RetailTrackChange listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreChange4Retail(para);
                dataGridViewPagingSumCtrl.BindingDataSource(listPage?.RetailOrders,false, listPage?.RetailOrderSum);
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
                RetailOrder item = dataGridView_RetailDetail.Rows[e.RowIndex].DataBoundItem as RetailOrder;
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

        private void ShowForm(RetailOrder order)
        {
            //采购进货明细
            CostumeStoreTrackSearchRetailDetailForm form
                 = new CostumeStoreTrackSearchRetailDetailForm();
            form.BaseModifyCostumeID = para.CostumeID;
            form.ShowDialog(order);
        }
    }
}
