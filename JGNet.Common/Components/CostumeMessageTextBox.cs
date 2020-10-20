using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;

namespace JGNet.Common
{
    public partial class CostumeMessageTextBox :  JGNet.Common.TextBox
    {

       
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event ESBasic.Action<Costume,bool> CostumeSelected;
        private bool isBarCode = false;
        private bool filterValid = true;
         
        public bool FilterValid
        {
            get { return filterValid; }
            set
            {
                filterValid = value;
            }
        }

       // public bool CheckTextChanged { get; set; }
      

        public CostumeMessageTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
            this.SkinTxt.Text = "";
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Text))
            {
                this.CostumeSelected?.Invoke(null,false);
            }
            else
            {
                
                    string costumeID = this.Text.Trim();

                //条形码，先根据条形码获取款号
                //List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

                ////，条形码为一条，找到这个款号
                //if (barCodes != null && barCodes.Count == 1)
                //{
                //    costumeID = barCodes[0].CostumeID;
                //    isBarCode = true;
                //}
                //BarCode4Costume costume = CommonGlobalUtil.GetBarCode(costumeID);
                //if (costume != null)
                //{
                //    costumeID = costume.CostumeID;
                //    SkinTxt.Text = costume.BarCode;
                //    isBarCode = true;
                //}

                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.ID.ToUpper().Equals(costumeID.ToUpper()));

                    if (filterValid)
                    {
                        resultList = resultList.FindAll(t => t.IsValid);
                    }

                    if (resultList == null || resultList.Count == 0)
                    {

                        this.CostumeSelected?.Invoke(null, false);

                        return;
                    }
                    if (resultList.Count == 1)
                    {
                        resultList[0].BrandName = CommonGlobalCache.GetBrandName(resultList[0].BrandID);
                        resultList[0].SupplierName = CommonGlobalCache.GetSupplierName(resultList[0].SupplierID);
                        CostumeSelected?.Invoke(resultList[0], false);
                    }
          
            }
        }

        public void Search()
        {
            try
            {
                isBarCode = false;

                string costumeID = this.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(costumeID))
                {
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(null,true);
                    }
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                //条形码，先根据条形码获取款号
                //List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

                ////，条形码为一条，找到这个款号
                //if (barCodes != null && barCodes.Count == 1)
                //{
                //    costumeID = barCodes[0].CostumeID;
                //    this.SkinTxt.Text = barCodes[0].BarCodeValue;
                //    isBarCode = true;
                //}
                //String barCode=  
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

                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.ID.ToUpper().Contains(costumeID.ToUpper()));
                if (filterValid)
                {
                    resultList = resultList.FindAll(t => t.IsValid);
                }
                if (resultList == null || resultList.Count == 0)
                {
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(null,true);
                    }
                    this.SkinTxt.Text = "";
                    return;
                }
                if (resultList.Count == 1)
                {
                    resultList[0].BrandName = CommonGlobalCache.GetBrandName(resultList[0].BrandID);
                    resultList[0].SupplierName = CommonGlobalCache.GetSupplierName(resultList[0].SupplierID);
                    if (!isBarCode)
                    {
                        this.SkinTxt.Text = resultList[0].ID;
                    }
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(resultList[0],true);
                    }
                }
                else
                {
                    CostumeForm costumeForm = new CostumeForm(resultList, costumeID, filterValid);
                    //   costumeForm.CostumeSelected += CostumeForm_CostumeSelected;
                    if (costumeForm.ShowDialog() == DialogResult.OK)
                    {
                        this.SkinTxt.Text = costumeForm.Result.ID;
                        CostumeSelected?.Invoke(costumeForm.Result,true);
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
                BeginInvoke(new ESBasic.CbGeneric(this.UnLockPage));
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
                BeginInvoke(new ESBasic.CbGeneric<Exception>(this.ShowError), ex);
            }
            else
            {
                CommonGlobalUtil.ShowError(ex);
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

        private void CostumeForm_CostumeSelected(Costume costumeItem,EventArgs args)
        {
            this.SkinTxt.Text = costumeItem.ID;
            if (this.CostumeSelected!=null)
            {
                this.CostumeSelected(costumeItem,true);
            }
        }
        #endregion
    }
}
