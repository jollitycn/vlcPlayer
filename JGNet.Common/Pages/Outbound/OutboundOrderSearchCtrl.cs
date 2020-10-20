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
using JGNet.Common.Components;
using JGNet.Common.Core.Util;

namespace JGNet.Common
{ 
   /// <summary>
   /// 出库单查询，
   /// 管理端：查询所有店铺
   /// POS端：本店出库单
   /// </summary>
    public partial class OutboundOrderSearchCtrl : BaseUserControl
    {
        private OutboundOrderPagePara pagePara;
        
        /// <summary>
        /// 点击出库单明细触发
        /// </summary>
        public event CJBasic.Action<OutboundOrder, Panel> OutboundDetailClick;
        public event CJBasic.Action<String, BaseUserControl,Panel> SourceDetailClick;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

        public OutboundOrderSearchCtrl()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1, dataGridViewPagingSumCtrl_CurrentPageIndexChanged,BaseButton_Search_Click, new string[] { totalCountDataGridViewTextBoxColumn1.DataPropertyName, totalPriceDataGridViewTextBoxColumn1.DataPropertyName });
            dataGridViewPagingSumCtrl.SpecAutoSizeModeColumns(new DataGridViewColumn[] {
                 remarksDataGridViewTextBoxColumn1 });
            dataGridViewPagingSumCtrl.Initialize(); 
      
            dataGridViewPagingSumCtrl.ColumnSorting += dataGridViewPagingSumCtrl_ColumnSorting;
        }

        private void dataGridViewPagingSumCtrl_ColumnSorting(String columnName, bool aesc)
        {
            this.skinSplitContainer1.Panel2Collapsed = true;
        }

        private void dataGridViewPagingSumCtrl_CurrentPageIndexChanged(int index)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (this.pagePara == null)
                    {
                        return;
                    }
                    this.pagePara.PageIndex = index;
                    OutboundOrderPage listPage = CommonGlobalCache.ServerProxy.GetOutboundOrderPage(this.pagePara);
                    this.BindingOutboundOrderSource(listPage);
               
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

        private void Initialize()
        {
            skinToolTip1.SetToolTip(this.skinTextBox_OrderID.SkinTxt, this.skinTextBox_OrderID.WaterText);
            this.CostumeCurrentShopTextBox1.Text = string.Empty;
            this.skinTextBox_OrderID.SkinTxt.Text = string.Empty;
            this.dataGridView1.DataSource = null; DateTimeUtil.DateTimePicker_SetDateTimePicker(dateTimePicker_Start, dateTimePicker_End);
            this.skinSplitContainer1.Panel2Collapsed = true;

        }

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                string orderID = string.IsNullOrEmpty(this.skinTextBox_OrderID.SkinTxt.Text) ? null : this.skinTextBox_OrderID.SkinTxt.Text;
                    string costumeID = string.IsNullOrEmpty(this.CostumeCurrentShopTextBox1.SkinTxt.Text) ? null : this.CostumeCurrentShopTextBox1.SkinTxt.Text;

                    this.pagePara = new OutboundOrderPagePara()
                    {
                        OrderID = orderID,
                        CostumeID = costumeID,
                        IsOpenDate = true,
                        StartDate = new CJBasic.Date(this.dateTimePicker_Start.Value),
                        EndDate = new CJBasic.Date(this.dateTimePicker_End.Value),
                        PageIndex = 0,
                        PageSize = this.dataGridViewPagingSumCtrl.PageSize,
                        ShopID = IsPos ? CommonGlobalCache.CurrentShopID : null
                    };
                    OutboundOrderPage listPage = CommonGlobalCache.ServerProxy.GetOutboundOrderPage(this.pagePara);
                dataGridViewPagingSumCtrl.OrderPara = pagePara;
                this.dataGridViewPagingSumCtrl.Initialize(listPage);
                    this.BindingOutboundOrderSource(listPage);
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

        #region 绑定OutboundOrder源
        private void BindingOutboundOrderSource(OutboundOrderPage listPage)
        {
            if (listPage != null && listPage.OutboundOrderList != null && listPage.OutboundOrderList.Count > 0)
            {
                //将名称赋值，用于显示
                foreach (OutboundOrder order in listPage.OutboundOrderList)
                {
                    order.GuideName = CommonGlobalCache.GetUserName(order.OperatorUserID);
                    order.SourceShopName = CommonGlobalCache.GetShopName(order.ShopID);
                }
            }
        
            this.dataGridViewPagingSumCtrl.BindingDataSource(listPage?.OutboundOrderList, null, listPage?.TotalEntityCount, listPage?.OutboundOrderSum);

            this.skinSplitContainer1.Panel2Collapsed = true;
        }
        #endregion

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
                List<OutboundOrder> list = (List<OutboundOrder>)this.dataGridView1.DataSource;
                OutboundOrder item  = list[e.RowIndex];
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.DataPropertyName == iDDataGridViewTextBoxColumn1.DataPropertyName)
                {

                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.OutboundDetailClick?.Invoke(item,
            this.skinSplitContainer1.Panel2 ); 
                }

                if (sourceOrderIDDataGridViewTextBoxColumn1.Index == e.ColumnIndex)
                {
                    this.skinSplitContainer1.Panel2Collapsed = false;
                    this.SourceDetailClick?.Invoke(item.SourceOrderID, this, this.skinSplitContainer1.Panel2);
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }
        #endregion

        private void OutboundOrderSearchCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }
         
        private void CostumeCurrentShopTextBox1_CostumeSelected(Costume costume, bool isEnter)
        {
            if (costume != null && isEnter)
            {
                BaseButton_Search_Click(null, null);
            }
        }
    }
}
