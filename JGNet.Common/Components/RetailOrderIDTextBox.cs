using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;
using JGNet.Manage;
using JGNet.Common;

namespace JGNet.Manage
{
    public partial class RetailOrderIDTextBox : JGNet.Common.TextBox
    {
        /// <summary>
        /// 被选中时触发
        /// </summary>
        public event System.Action<RetailOrder> OrderSelected;
        public String ShopID { get; set; }
        public RetailOrderIDTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
            base.SkinTxt.KeyPress += SkinTxt_KeyPress;
            base.SkinTxt.Text = "";
            base.Text = "";
            base.WaterText = "输入单号并回车";
            base.SkinTxt.WaterText = "输入单号并回车";
        }
        public void PerformClick()
        {
            Search();
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.SkinTxt.Text))
            {
                if (this.OrderSelected != null)
                {
                    this.OrderSelected(null);
                }
            }
        }

        private void SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //取消登登登
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }

        #region 回车后选择款号
        private void SkinTxt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            Search();
        }

        private void Search()
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                string orderID = this.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(orderID))
                {
                    if (this.OrderSelected != null)
                    {
                        this.OrderSelected(null);
                    }
                    return;
                }
                if (String.IsNullOrEmpty(ShopID)) {
                    ShopID = CommonGlobalCache.CurrentShopID;
                }
                List<RetailOrder> resultList = CommonGlobalCache.ServerProxy.GetRetailOrder4ID(orderID, ShopID);
                if (resultList == null || resultList.Count == 0)
                {
                    if (this.OrderSelected != null)
                    {
                        this.OrderSelected(null);
                    }
                    this.SkinTxt.Text = "";
                    return;
                }
                if (resultList.Count == 1)
                {
                    this.SkinTxt.Text = resultList[0].ID;
                    if (this.OrderSelected != null)
                    {
                        this.OrderSelected(resultList[0]);
                    }
                }
                else
                {
                    RetailOrderSelectForm orderSelectForm = new RetailOrderSelectForm(orderID, ShopID);
                    orderSelectForm.RetailOrderSelected += OrderSelectForm_RetailOrderSelected;
                    orderSelectForm.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.ShowError(ee);
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        private void OrderSelectForm_RetailOrderSelected(RetailOrder retailOrder)
        {
            this.SkinTxt.Text = retailOrder.ID;
            OrderSelected?.Invoke(retailOrder);
        }

        #endregion
    }
}
