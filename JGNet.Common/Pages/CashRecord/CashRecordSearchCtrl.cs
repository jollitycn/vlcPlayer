using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Common.Core;  
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using CJBasic;
using JieXi.Common;

namespace JGNet.Common
{
    public partial class CashRecordSearchCtrl : BaseUserControl
    {

        private CashRecordPagePara pagePara;
        public CJBasic.Action<CashRecord, Type> DetailClick;
        public Action<BaseUserControl> NewClick; 
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        ///// <summary>
        ///// 点击查询入库差异单明细
        ///// </summary>
        //public event CJBasic.Action<CashRecord,Type> CashRecordDetailClick;
        public CashRecordSearchCtrl()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl =  new DataGridViewPagingSumCtrl(this.dataGridView1,  dataGridViewPagingSumCtrl_CurrentPageIndexChanged,BaseButton_Search_Click);

            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn });
            dataGridViewPagingSumCtrl.Initialize();

            this.createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT;

            skinComboBox_DestShop.Initialize();
            MenuPermission = RolePermissionMenuEnum.店铺现金管理;
        }

        private void Initialize()
        {

            this.dataGridView1.DataSource = null;
            DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
           
            SetFeeType();
            SetDisplay();
        }

        private void SetDisplay()
        {
           // shopIDDataGridViewTextBoxColumn.Visible = !IsPos;
        }
         

        private void SetFeeType()
        {
            this.skinComboBox_FeeType.DisplayMember = "Key";
            this.skinComboBox_FeeType.ValueMember = "Value";
            this.skinComboBox_FeeType.DataSource = CommonGlobalCache.FeeTypeList;
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (this.pagePara == null)
                {
                    return;
                }
                this.pagePara.PageIndex = index;
                CashRecordPage listPage = CommonGlobalCache.ServerProxy.GetCashRecordPage(this.pagePara);
                this.BindingSource(listPage);
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                pagePara = new CashRecordPagePara()
                {
                    ShopID = ValidateUtil.CheckEmptyValue(this.skinComboBox_DestShop.SelectedValue),
                    StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                    EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                    PageIndex = 0,
                    PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                    CashRecordFeeType = (CashRecordFeeType)this.skinComboBox_FeeType.SelectedValue,

                };
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                CashRecordPage listPage = CommonGlobalCache.ServerProxy.GetCashRecordPage(this.pagePara);
                dataGridViewPagingSumCtrl.Initialize(listPage);
                BindingSource(listPage);
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
        }

        private void BindingSource(CashRecordPage listPage)
        {
            dataGridViewPagingSumCtrl.BindingDataSource(listPage?.CashRecordList, new string[] { "MoneyCash" }, listPage?.TotalEntityCount, listPage?.CashRecordSum);
        }

        #region 点击单元格
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                
                switch (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                    {
                        case "明细":
                            if (this.DetailClick != null)
                            {
                                List<CashRecord> list = (List<CashRecord>)this.dataGridView1.DataSource;
                                this.DetailClick(list[e.RowIndex], this.GetType());
                            }
                            break;
                    }
                } 
            catch (Exception ee)
            {
                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
        }



        #endregion

        public override void RefreshPage()
        {
            if (pagePara != null)
            {
                this.dataGridViewPagingSumCtrl_CurrentPageIndexChanged(pagePara.PageIndex);
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            CashRecord order = (CashRecord)row.DataBoundItem;

            if (shopIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalCache.GetShopName(order.ShopID);
            }
            else if (createTimeDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                createTimeDataGridViewTextBoxColumn.DefaultCellStyle.Format = DateTimeUtil.DEFAULT_DATETIME_FORMAT; 
            }
            else if (operatorUserIDDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
               e.Value = CommonGlobalCache.GetUserName(order.OperatorUserID);
            }
            else if ( feeTypeDataGridViewTextBoxColumn.Index == e.ColumnIndex)
            {
                e.Value = CommonGlobalUtil.GetFeeTypeName(order.FeeType);
            }
            
        }

        private void CashRecordSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }
         

        private void BaseButtonNew_Click(object sender, EventArgs e)
        {
            this.NewClick?.Invoke(this);

        }

        private String path;
        private void baseButton2_Click(object sender, EventArgs e)
        {

            path = CJBasic.Helpers.FileHelper.GetPathToSave("保存文件", "店铺现金管理" + new Date(DateTime.Now).ToDateInteger() + ".xls", Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }

                CJBasic.CbGeneric cb = new CJBasic.CbGeneric(this.DoExport);
                cb.BeginInvoke(null, null);
            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
        }
        private void DoExport()
        {
            try
            {
                if (dataGridView1.DataSource != null && dataGridView1.Rows.Count > 0)
                {
                    List<CashRecord> list = (List<CashRecord>)this.dataGridView1.DataSource;
                    List<String> keys = new List<string>();
                    List<String> values = new List<string>();
                    foreach (DataGridViewColumn item in dataGridView1.Columns)
                    {
                        if (item.Visible)
                        {
                            keys.Add(item.DataPropertyName);
                            values.Add(item.HeaderText);

                        }
                    }



                    NPOIHelper.Keys = keys.ToArray();
                    NPOIHelper.Values = values.ToArray();
                    NPOIHelper.ExportExcel(DataGridViewUtil.ToDataTable(list), path);

                    GlobalMessageBox.Show("导出完毕！");
                }
            }
            catch (Exception ex)
            { ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }
    }
}

