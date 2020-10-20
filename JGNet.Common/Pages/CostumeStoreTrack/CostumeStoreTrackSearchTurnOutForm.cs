
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Const;
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
    public partial class CostumeStoreTrackSearchTurnOutForm : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchTurnOutForm()
        {
            InitializeComponent();
            dataGridView_RetailDetail.AutoGenerateColumns = false;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(
                this.dataGridView_RetailDetail, new string[] {
            totalCountDataGridViewTextBoxColumn.DataPropertyName
            })
            {
                ShowColumnSetting = false
            }; dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
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
                IntoTurnOutTrackChange listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreChange4TurnOut(para);
                dataGridViewPagingSumCtrl.BindingDataSource(listPage?.AllocateOrders, true,listPage?.AllocateOrderSum);
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
                AllocateOrder item = dataGridView_RetailDetail.Rows[e.RowIndex].DataBoundItem as AllocateOrder;
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

        private void ShowForm(AllocateOrder order)
        {
            if (order.Type == CostumeStoreTrackChangeType.AllocateOutbound)
            {
                //采购进货明细
                CostumeStoreTrackSearchTurnOutDetailForm form
                     = new CostumeStoreTrackSearchTurnOutDetailForm();
                form.BaseModifyCostumeID = para.CostumeID;
                form.ShowDialog(order);
            }
            else
            {
                CostumeStoreTrackSearchTurnOutDetailWholeSaleForm form = new CostumeStoreTrackSearchTurnOutDetailWholeSaleForm();
                form.BaseModifyCostumeID = para.CostumeID;
                form.ShowDialog(order);
            }
        }
    }
}
