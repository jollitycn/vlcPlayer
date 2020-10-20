using CCWin;
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
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

namespace JGNet.Common
{
    public partial class AllocateOrderPickForm : Common.BaseForm
    {
        AllocateOrder curOrder;
        List<AllocateOrder> orders;
        public event System.Action<AllocateOrder> HangedOrderSelected;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        public AllocateOrderPickForm()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            dataGridViewPagingSumCtrl.ShowRowCounts = false;
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(this.dataGridView2);
            dataGridViewPagingSumCtrl1.Initialize();
            dataGridViewPagingSumCtrl1.ShowRowCounts = false;
            string SourceShopStr = string.Empty;
            if (HasPermission(RolePermissionMenuEnum.调拨, RolePermissionEnum.查看_只看本店))
            {
                SourceShopStr = CommonGlobalCache.CurrentShopID;
            }
                AllocateOrderPagePara para = new AllocateOrderPagePara()
            {
                SourceShopID = SourceShopStr,
                AllocateOrderState = AllocateOrderState.HangUp,
                IsOpenDate = true,
                PageIndex = 0,
                   
                PageSize = Int32.MaxValue
            };
            AllocateOrderPage page = CommonGlobalCache.ServerProxy.GetAllocateOrderPage(para);
            if (page != null )
            {
                orders = page.AllocateOrderList;
                if (orders != null)
                {
                    foreach (var item in orders)
                    { 
                        item.DestShopName = CommonGlobalCache.GetShopName(item.DestShopID);
                        item.SourceShopName = CommonGlobalCache.GetShopName(item.SourceShopID);
                    }
                }
            }

            dataGridViewPagingSumCtrl.BindingDataSource(orders);

            MenuPermission = Core.RolePermissionMenuEnum.调拨;
        }


        //点击选择按钮
        private void BaseButton_Select_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.HangedOrderSelected != null)
                {
                    this.HangedOrderSelected(curOrder);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
                GlobalMessageBox.Show("选择失败！");
            }
        }

        //点击取消按钮
        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void dataGridView_HangedOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (!DataGridViewUtil.CheckPerrmisson(this, sender, e)) { return; } 
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    List<PurchaseOrder> orders = dataGridView1.DataSource as List<PurchaseOrder>;
                    if (e.ColumnIndex== operationColumn.Index)
                    {
                        DialogResult dialogResult = GlobalMessageBox.Show("确定删除该条数据？", "提示", MessageBoxButtons.OKCancel);
                        if (dialogResult != DialogResult.OK)
                        {
                            return;
                        }
                        AllocateOrder order = dataGridView1.Rows[e.RowIndex].DataBoundItem as AllocateOrder;
                        InteractResult result = CommonGlobalCache.ServerProxy.DeleteUpAllocateOrder(order?.ID);

                        switch (result.ExeResult)
                        {
                            case ExeResult.Success:
                                GlobalMessageBox.Show("删除成功！");
                                CommonGlobalUtil.WriteLog(order.ID);
                                DeleteSelectedHangedOrder(order);
                                break;
                            case ExeResult.Error:
                                GlobalMessageBox.Show(result.Msg);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
        }

        bool flag = false;
        private void DeleteSelectedHangedOrder(AllocateOrder order)
        {
            if (orders.Contains(order)) { 
            orders.Remove(order);
            }
            flag = true;
            dataGridViewPagingSumCtrl.BindingDataSource(orders);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        { 
            try
            {
                if (flag == false)
                {
                    if (this.dataGridView1.CurrentRow.DataBoundItem != null && this.dataGridView1.Rows.Count > 0)
                    {
                        AllocateOrder order = (AllocateOrder)this.dataGridView1.CurrentRow.DataBoundItem;
                        if (order != null && order != curOrder)
                        {

                            List<BoundDetail> list = CommonGlobalCache.ServerProxy.GetOutboundDetail(order.OutboundOrderID);
                            if (list != null && list.Count > 0)
                            {
                                foreach (var item in list)
                                {
                                    Costume costume = CommonGlobalCache.GetCostume(item.CostumeID);
                                    item.SupplierName = CommonGlobalCache.GetSupplierName(item.SupplierID);
                                    item.BrandName = CommonGlobalCache.GetBrandName(costume.BrandID);
                                    item.CostumeName = costume.Name;
                                }
                            }
                            dataGridViewPagingSumCtrl1.BindingDataSource(list);
                            curOrder = order;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
             //   CommonGlobalUtil.ShowError(ex);
            }
        } 

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) { return; }
            try
            {
                DataGridView view = sender as DataGridView;
                AllocateOrder order = view.CurrentRow.DataBoundItem as AllocateOrder;
                curOrder = order;
                BaseButton_Select_Click(null, null);
            }
            catch (Exception ex)
            {
               // CommonGlobalUtil.ShowError(ex);
            }

        }
    }
}
