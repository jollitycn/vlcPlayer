using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin; 
using JGNet.Common;
using JGNet.Common.cache.Wholesale;

namespace JGNet.Common
{
    public partial class PfCustomerTextBox : TextBox
    {
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event System.Action<PfCustomer> ItemSelected;
        public bool HideEmpty { get; set; }
        /// <summary>
        /// 判断是否需要作会员检查
        /// </summary> 
        public bool CheckPfCustomer { get; set; } 
        public PfCustomerTextBox()
        {
            InitializeComponent(); 
            Text = "";
            WaterText = "输入编号/名称并回车";
            Leave += SkinTxt_Leave; 
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Text))
            {
                this.ItemSelected?.Invoke(null);
            }
            else
            {
                resultList = PfCustomerCache.PfCustomerList.FindAll(t => t.ID.Equals(this.Text)); //CommonGlobalCache.ServerProxy.GetPfCustomersLike4IDOrName(PfCustomerID);
                if (resultList == null || resultList.Count == 0)
                {
                    if (this.ItemSelected != null)
                    {
                        this.ItemSelected(null);
                    }
                    return;
                }
                if (resultList.Count == 1)
                {
                    this.Text = resultList[0].ID;
                    // this.SkinTxt.Focus();
                    if (this.ItemSelected != null)
                    {
                        this.ItemSelected(resultList[0]);
                    }
                }
            }
        }

        private void SkinTxt_Leave(object sender, EventArgs e)
        {
            if (CheckPfCustomer)
            {
                String value = this.Text.Trim();
                if (!String.IsNullOrEmpty(value))
                {
                    if (resultList == null)
                    {
                        Search();
                    }
                    if (resultList == null || !resultList.Exists(t => t.ID == value))
                    {
                        GlobalMessageBox.Show("客户不存在，请重新输入！");
                        this.Focus();
                    }
                }
            }
        }

        List<PfCustomer> resultList = null;
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
                string PfCustomerID = this.Text.Trim();
                if (string.IsNullOrEmpty(PfCustomerID))
                {
                    this.ItemSelected?.Invoke(null);
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                    resultList = PfCustomerCache.PfCustomerList.FindAll(t => t.ID.Contains(PfCustomerID));

                if (resultList == null || resultList.Count == 0)
                {
                    if (this.ItemSelected != null)
                    {
                        this.ItemSelected(null);
                    }
                    //  this.SkinTxt.Text = "";
                    return;
                }
                if (resultList.Count == 1)
                {
                  
                        this.Text = resultList[0].ID;
         
                    this.ItemSelected?.Invoke(resultList[0]);
                }
                else
                {
                    PfCustomerSelectForm PfCustomerForm = new PfCustomerSelectForm(PfCustomerID, resultList);
                    PfCustomerForm.ItemSelected += PfCustomerForm_PfCustomerSelected;
                    PfCustomerForm.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                CommonGlobalUtil.WriteLog(ee);
                GlobalMessageBox.Show("查询失败！");
            }
            finally
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        private void PfCustomerForm_PfCustomerSelected(PfCustomer PfCustomer, EventArgs args)
        {
            this.Text = PfCustomer.ID;
            this.ItemSelected?.Invoke(PfCustomer);
        }

        private bool hideAll;
        private bool isEnableList;
        public void Initialize(bool hideAll, bool isEnableList)
        {
            this.hideAll = hideAll;
            this.isEnableList = isEnableList;
        }
             

        #endregion
    }
}
