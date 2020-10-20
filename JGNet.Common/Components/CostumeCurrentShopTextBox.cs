using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;
using JGNet.Core.Tools;

namespace JGNet.Common
{
    public partial class CostumeCurrentShopTextBox :  JGNet.Common.TextBox
    {

        
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event System.Action<CostumeItem> CostumeSelected;
        private bool isBarCode = false;

        private bool filterValid = true;
        public bool FilterValid { get { return filterValid; }set { filterValid = value; } }


        public CostumeCurrentShopTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
            base.SkinTxt.Text = "";
            base.Text = "";
            base.WaterText = "输入款号或条形码回车";
            base.SkinTxt.WaterText = "输入款号或条形码回车";
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.SkinTxt.Text))
            {
                if (this.CostumeSelected != null)
                {
                    this.CostumeSelected(null);
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
            try
            {
                isBarCode = false;
                string costumeID = this.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(costumeID))
                {
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(null);
                    }
                    return;
                }
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                //条形码，先根据条形码获取款号
                //List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

                ////，条形码为一条，找到这个款号
                //if (barCodes != null && barCodes.Count == 1)
                //{
                //    costumeID = barCodes[0].CostumeID;
                //    SkinTxt.Text = barCodes[0].BarCodeValue;
                //    isBarCode = true;
                //}
                if (costumeID.Length == 15)
                {
                    BarCode4Costume costume = CommonGlobalUtil.GetBarCode(costumeID);
                    if (costume != null)
                    {
                        costumeID = costume.CostumeID;
                        SkinTxt.Text = costume.BarCode;
                        isBarCode = true;
                    }
                }


                List<CostumeItem> resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(
                    new CostumeStoreListPara() {
                        CostumeID = costumeID,
                        ShopID = CommonGlobalCache.CurrentShopID,
                        IsOnlyShowValid = filterValid
                });

                if (resultList == null || resultList.Count == 0)
                {
                    this.CostumeSelected?.Invoke(null);
                    this.SkinTxt.Text = "";
                    return;
                }

                if (resultList.Count == 1)
                {
                    resultList[0].Costume.BrandName = CommonGlobalCache.GetBrandName(resultList[0].Costume.BrandID);
                    resultList[0].Costume.SupplierName = CommonGlobalCache.GetSupplierName(resultList[0].Costume.SupplierID);
                    if (resultList[0].CostumeStoreList != null)
                    {
                        foreach (var item in resultList[0].CostumeStoreList)
                        {
                            item.CostumeName = resultList[0].Costume.Name;
                            item.BrandName = resultList[0].Costume.BrandName;
                            item.Price = resultList[0].Costume.Price;
                            item.CostPrice = resultList[0].Costume.CostPrice;
                        }
                    }


                    if (!isBarCode)
                    {
                        this.SkinTxt.Text = resultList[0].Costume.ID;
                    } 
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(resultList[0]);
                    }
                }
                else
                {
                    CostumeFromShopForm costumeForm = new CostumeFromShopForm(resultList, costumeID, CommonGlobalCache.CurrentShopID,filterValid);
                    //   costumeForm.Hide();
                    // costumeForm.CostumeSelected += CostumeForm_CostumeSelected;
                    if (costumeForm.ShowDialog() == DialogResult.OK)
                    {
                        if (costumeForm.Result == null)
                        {
                            return;
                        }
                        this.SkinTxt.Text = costumeForm.Result.Costume.ID;
                        CostumeSelected?.Invoke(costumeForm.Result);
                    }
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

        private void CostumeForm_CostumeSelected(CostumeItem costumeItem, EventArgs args)
        {
            if (costumeItem == null)
            {
                return;
            }
            this.SkinTxt.Text = costumeItem.Costume.ID;
            if (this.CostumeSelected != null)
            {
                this.CostumeSelected(costumeItem);
            }
        }
        #endregion
    }
}
