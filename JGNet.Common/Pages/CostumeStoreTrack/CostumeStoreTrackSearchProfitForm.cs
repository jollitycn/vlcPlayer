
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
    public partial class CostumeStoreTrackSearchProfitForm : BaseForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchProfitForm()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {
                    CheckStoreWinCount.DataPropertyName,
                    CheckStoreLostCount.DataPropertyName
                })
            {
                ShowColumnSetting = false
            };
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
                ProfitTrackChange listPage = CommonGlobalCache.ServerProxy.GetCostumeStoreChange4Profit(para); 
                dataGridViewPagingSumCtrl.BindingDataSource(listPage?.CheckStoreOrders, true,listPage?.CheckStoreOrderSum);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        } 
        private void ShowForm(CheckStoreOrder order)
        {
            //采购进货明细
            CostumeStoreTrackSearchProfitDetailForm form
                 = new CostumeStoreTrackSearchProfitDetailForm();
            form.BaseModifyCostumeID = para.CostumeID;
            form.ShowDialog(order);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                CheckStoreOrder item = dataGridView1.Rows[e.RowIndex].DataBoundItem as CheckStoreOrder;
                if (e.ColumnIndex == iDDataGridViewTextBoxColumn.Index)
                {
                    ShowForm(item);
                }

            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }
    }
}
