
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
    public partial class CostumeStoreTrackSearchRetailDetailForm : BaseDialogCostumeIDForm
    {

        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public CostumeStoreTrackSearchRetailDetailForm()
        {
            InitializeComponent(); 
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(
                this.dataGridView_RetailDetail, new string[] {
                    buyCountDataGridViewTextBoxColumn.DataPropertyName,
                    sumMoneyDataGridViewTextBoxColumn.DataPropertyName
    })  ;
            dataGridViewPagingSumCtrl.Initialize();
        }
        

        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
         
        internal void ShowDialog(RetailOrder order)
        { 
            this.Initialize(order);
            this.ShowDialog();
        }    


    private void Initialize(RetailOrder order)
    {
        if (order == null || String.IsNullOrEmpty(order.ID))
        {
            return;
        }
        try
        {
            this.Text += "-"+ order.ID;


                List<RetailDetail> list = CommonGlobalCache.ServerProxy.GetRetailDetailList(order?.ID);
               
                this.BindingOutboundDetailSource(list);
        }
        catch (Exception ee)
        {
            CommonGlobalUtil.ShowError(ee);
        }

    }
        private void BindingOutboundDetailSource(List<RetailDetail> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (RetailDetail detail in list)
                {
                    detail.CostumeName = CommonGlobalCache.GetCostumeName(detail.CostumeID);
                    detail.SizeDisplayName = CommonGlobalUtil.GetCostumeSizeName(detail.CostumeID, detail.SizeName);
                }
            }
            this.dataGridViewPagingSumCtrl.BindingDataSource(list);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        } 

        public override void HighlightCostume()
        {
            if (dataGridView_RetailDetail.DataSource != null)
            {
                if (!String.IsNullOrEmpty(BaseModifyCostumeID))
                {
                    foreach (DataGridViewRow row in dataGridView_RetailDetail.Rows)
                    {
                        RetailDetail detail = row.DataBoundItem as RetailDetail;
                        HighlightCostume(row, detail?.CostumeID);
                    }
                }
                dataGridView_RetailDetail.Refresh();
            }
        }

        private void dataGridView_RetailDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
                DataGridViewUtil.CellFormatting_ReportShowZero(e, ReportShowZero);
        }

        private void CostumeStoreTrackSearchRetailDetailForm_Load(object sender, EventArgs e)
        {
            HighlightCostume();
        }
    }
}
