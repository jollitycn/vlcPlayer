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
using JGNet.Core.MyEnum;
using JGNet.Core.Util;

namespace JGNet.Common
{
    public partial class PfCustomerComboBox : SkinComboBox
    {
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event System.Action<PfCustomer> ItemSelected;
        public bool HideEmpty { get; set; }

        public int CustomerTypeValue { get; set; }

        /// <summary>
        /// 判断是否需要作会员检查
        /// </summary> 
        public bool CheckPfCustomer { get; set; }
        //public override ComboBoxStyle  DropDownStyle { get { return this.DropDownStyle; }
        //    set { this.DropDownStyle = value; } }
        public PfCustomerComboBox()
        {
            InitializeComponent();
            CustomerTypeValue = (int)CustomerType.All;
            SelectedIndexChanged += Combbox_SelectedIndexChanged;
            if (this.DropDownStyle == ComboBoxStyle.DropDown || this.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                //如果是下拉则textupdate模式
                TextUpdate += skinComboBox_TextUpdate;
            }
            else if (this.DropDownStyle == ComboBoxStyle.Simple)
            {
                PreviewKeyDown += SkinTxt_PreviewKeyDown;
                //如果是普通输入模式的话则TEXTCHANGED
                TextChanged += SkinTxt_TextChanged;
            }


            Leave += SkinTxt_Leave;
            Text = "";
            WaterText = "输入编号/名称并回车";
        }

        private void Combbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectedItem != null)
                {
                    ItemSelected?.Invoke(this.SelectedItem as PfCustomer);
                }
                else
                {
                    ItemSelected?.Invoke(null);
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }


        private void skinComboBox_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                List<PfCustomer> listNew = new List<PfCustomer>();
                //  skinComboBox_Brand.Items.Clear();
                SkinComboBox box = (SkinComboBox)sender;
                List<PfCustomer> temp = (List<PfCustomer>)box.DataSource;
                if (temp != null && temp.Count == 0)
                {

                    List<PfCustomer> tempList = new List<PfCustomer>();
                    tempList[0].ID =null;
                    tempList[0].Name = null;
                    box.DisplayMember = "Name";
                    box.ValueMember = "ID";
                    box.DataSource = tempList;
                    return;
                }

                String str = box.Text;
                curSelectStr = str;

                List<PfCustomer> pfCustomerList = PfCustomerCache.PfCustomerList;
                if (pfCustomerList != null && CustomerTypeValue != -1)
                {
                    pfCustomerList = pfCustomerList.FindAll(t => t.CustomerType == CustomerTypeValue);
                }

                if (String.IsNullOrEmpty(str))
                {
                    if (!hideAll)
                    {
                        listNew.Add(new PfCustomer() {
                            Name = CommonGlobalUtil.COMBOBOX_ALL,
                            FirstCharSpell = DisplayUtil.GetPYString(CommonGlobalUtil.COMBOBOX_ALL),
                            ID = null
                        });
                    }
                    if (isEnableList)
                    {
                        listNew.AddRange(pfCustomerList?.FindAll(t => t.Enabled));
                    }
                    else
                    {
                        listNew.AddRange(pfCustomerList);
                    }
                }
                else
                {
                    if (!hideAll)
                    {
                        listNew.Add(new PfCustomer()
                        {
                            Name = CommonGlobalUtil.COMBOBOX_ALL,
                            FirstCharSpell = DisplayUtil.GetPYString(CommonGlobalUtil.COMBOBOX_ALL),
                            ID = null
                        });
                    }
                    List<PfCustomer> list = new List<PfCustomer>();
                    if (isEnableList)
                    {
                        list.AddRange(pfCustomerList?.FindAll(t => t.Enabled));
                    }
                    else
                    {
                        list.AddRange(pfCustomerList);
                    }

                    foreach (var item in list)
                    {
                        if ((item.FirstCharSpell).ToUpper().Contains(str.ToUpper()) || (item.ID).ToUpper().Contains(str.ToUpper()) || (item.Name).ToUpper().Contains(str.ToUpper()))
                        {
                            listNew.Add(item);
                        }
                    }
                }

                if (listNew.Count == 0)
                {
                    if (!HideEmpty)
                    {

                        listNew.Add(new PfCustomer()
                        {
                            ID = null,
                            Name = "（无）",
                            FirstCharSpell = DisplayUtil.GetPYString("（无）")
                        });
                    }
                }

                //box.DataSource = null; 
                if (isEnableList)
                {
                    listNew = listNew.FindAll(t => t.Enabled);
                }

                if (listNew == null || listNew.Count==0)
                {

                    List<PfCustomer> tempList = new List<PfCustomer>();
                    PfCustomer firstPC = new PfCustomer();
                    firstPC.ID = null;
                    firstPC.Name = null;
                    tempList.Add(firstPC);
                    box.DisplayMember = "Name";
                    box.ValueMember = "ID";
                    box.DataSource = tempList;
                     
                } else
                {
                    List<PfCustomer> PfList = new List<PfCustomer>();

                    if (!hideAll && this.Text=="")
                    {
                        PfList.Add(new PfCustomer()
                        {
                            Name = CommonGlobalUtil.COMBOBOX_ALL,
                            FirstCharSpell = DisplayUtil.GetPYString(CommonGlobalUtil.COMBOBOX_ALL),
                            ID = null
                        });
                    }
                    PfList.AddRange(listNew);
                    box.DisplayMember = "Name";
                    box.ValueMember = "ID";
                    box.DataSource = PfList;
                }
                box.DroppedDown = true;//自动展开下拉框 
                box.Text = str;
                curSelectStr = str;
                //box.sele = str;
                box.Select(box.Text.Length, 0);
                //滚动到控件光标处 
               // box.ScrollToCaret();
                //box.SelectionStart = str.Length;
               // box.Cursor = Cursors.Default;

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                box.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (Exception ex)
            {
                //  CommonGlobalUtil.ShowError(ex);
            }

        }
        public String curSelectStr { get; set; }
        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(curSelectStr))
                {
                    this.ItemSelected?.Invoke(null);
                }
                else
                {

                    List<PfCustomer> pfCustomerList = PfCustomerCache.PfCustomerList;
                    if (pfCustomerList != null && CustomerTypeValue != -1)
                    {
                        pfCustomerList = pfCustomerList.FindAll(t => t.CustomerType == CustomerTypeValue);
                    }

                    resultList = pfCustomerList.FindAll(t => t.ID.Equals(curSelectStr)); //CommonGlobalCache.ServerProxy.GetPfCustomersLike4IDOrName(PfCustomerID);
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
            catch (Exception ex)
            {

                ShowError(ex);
            }
        }

        private void SkinTxt_Leave(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {

                ShowError(ex);
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
                string PfCustomerID = curSelectStr.Trim();
                if (string.IsNullOrEmpty(PfCustomerID))
                {
                    this.ItemSelected?.Invoke(null);
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                List<PfCustomer> pfCustomerList = PfCustomerCache.PfCustomerList;
                if (pfCustomerList != null && CustomerTypeValue != -1)
                {
                    pfCustomerList = pfCustomerList.FindAll(t => t.CustomerType == CustomerTypeValue);
                }

                if (this.DropDownStyle == ComboBoxStyle.DropDown || this.DropDownStyle == ComboBoxStyle.DropDownList)
                {
                    resultList = pfCustomerList.FindAll(t => t.ID.Contains(PfCustomerID) || t.Name.Contains(PfCustomerID));
                }
                else
                {
                    resultList = pfCustomerList.FindAll(t => t.ID.Contains(PfCustomerID));
                }

              
                //CommonGlobalCache.ServerProxy.GetPfCustomersLike4IDOrName(PfCustomerID);



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
                    if (this.DropDownStyle == ComboBoxStyle.DropDown || this.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        this.SelectedValue = resultList[0].ID;
                    }
                    else
                    {
                        this.Text = resultList[0].ID;
                    }
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
                ShowError(ee);
            }
            finally
            {
                UnLockPage();
            }
        }
        protected void UnLockPage()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric(this.UnLockPage));
            }
            else
            {
                CommonGlobalUtil.UnLockPage(this);
            }
        }

        protected void ShowError(Exception ex)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CJBasic.CbGeneric<Exception>(this.ShowError), ex);
            }
            else
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private void PfCustomerForm_PfCustomerSelected(PfCustomer PfCustomer, EventArgs args)
        {
            this.Text = PfCustomer.ID;
            this.ItemSelected?.Invoke(PfCustomer);
        }

        private bool hideAll;
        private bool isEnableList;
        public void Initialize(bool hideAll, bool isEnableList, int customerTypeValue = -1)
        {
            this.hideAll = hideAll;
            this.isEnableList = isEnableList;
            CustomerTypeValue = customerTypeValue;
            List<PfCustomer> list = new List<PfCustomer>();
            if (!hideAll)
            {
                list.Add(new PfCustomer() {
                    Name = CommonGlobalUtil.COMBOBOX_ALL,
                    FirstCharSpell = DisplayUtil.GetPYString(CommonGlobalUtil.COMBOBOX_ALL),
                    ID = null
                });
            }
            List<PfCustomer> pfCustomerList = PfCustomerCache.PfCustomerList;

            if (pfCustomerList != null && CustomerTypeValue != -1)
            {
                pfCustomerList = pfCustomerList.FindAll(t => t.CustomerType == CustomerTypeValue);
            }

            if (isEnableList)
            {
                List<PfCustomer> pfs = pfCustomerList?.FindAll(t => t.Enabled);
                if (pfs != null)
                {
                    list.AddRange(pfs);
                }
            }
            else
            {
                List<PfCustomer> pfs = pfCustomerList;
                if (pfs != null)
                {
                    list.AddRange(pfs);
                }
            }
            DisplayMember = "Name";
            ValueMember = "ID";
            DataSource = list;
        }

        #endregion
    }
}
