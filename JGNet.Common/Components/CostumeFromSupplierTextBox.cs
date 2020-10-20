using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using JGNet.Core.Tools;
using CJBasic.Helpers;

namespace JGNet.Common
{
    public partial class CostumeFromSupplierTextBox :  JGNet.Common.TextBox
    {

        public static List<CostumeStore> GetCostumeStores(Costume costume)
        {

            List<CostumeStore> storeList = new List<CostumeStore>();
            try
            {
                String[] colors = CommonGlobalUtil.GetStringSplit(costume.Colors, ',');
                if (colors != null && colors.Length > 0)
                {

                    //创建虚拟库存信息
                    foreach (var color in colors)
                    {
                        CostumeStore costumeStore = GetCostumeStore(costume);
                        costumeStore.ColorName = color;
                        storeList.Add(costumeStore);
                    }
                }
                else
                {
                    CostumeStore costumeStore = GetCostumeStore(costume);
                    costumeStore.ColorName = string.Empty;
                    storeList.Add(costumeStore);
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
             
            return storeList;
        }

        private static CostumeStore GetCostumeStore(Costume costume)
        {//color not existed,then add one 
            CostumeStore costumeStore = new CostumeStore();
            ReflectionHelper.CopyProperty(costume, costumeStore);
            costumeStore.CostumeName = costume.Name;
            costumeStore.CostumeID = costume.ID;
            costumeStore.F = 0;
            costumeStore.L = 0;
            costumeStore.XS = 0;
            costumeStore.M = 0;
            costumeStore.S = 0;
            costumeStore.XL = 0;
            costumeStore.XL2 = 0;
            costumeStore.XL3 = 0;
            costumeStore.XL4 = 0;
            costumeStore.XL5 = 0;
            costumeStore.XL6 = 0;
            return costumeStore;
        }

        public String SupplierID { get; set; }
        private int brandID = -1;
        public int BrandID { get { return brandID; }set { brandID = value; } }

        private bool filterValid = true;
        public bool FilterValid { get { return filterValid; } set { filterValid = value; } }
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event Action<Costume> CostumeSelected;
        public CostumeFromSupplierTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
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
        private bool isBarCode = false;

        #region 回车后选择款号
        private void SkinTxt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            Search();

        }
        public void Search() {

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
                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.SupplierID == this.SupplierID
                    && t.ID.ToUpper().Contains(costumeID.ToUpper())  );
                if (filterValid)
                {
                    resultList = resultList.FindAll(t => t.IsValid);
                }

                if (this.BrandID != -1 && resultList != null)
                {
                    resultList = resultList.FindAll(t => t.BrandID == this.BrandID);
                }

                if (resultList == null || resultList.Count == 0)
                {
                    if (this.CostumeSelected != null)
                    {
                        this.CostumeSelected(null);
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
                        this.CostumeSelected(resultList[0]);
                    }
                }
                else
                {
                    CostumeFromSupplierForm costumeForm = new CostumeFromSupplierForm(resultList, costumeID, SupplierID, BrandID,filterValid);
                    //  costumeForm.Hide();
                    //   costumeForm.CostumeSelected += CostumeForm_CostumeSelected;
                    if (costumeForm.ShowDialog() == DialogResult.OK)
                    {
                        this.SkinTxt.Text = costumeForm.Result.ID;
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

        //private void CostumeForm_CostumeSelected(Costume costume, EventArgs args)
        //{
        //   // this.SkinTxt.Text = costume.ID;
        //    if (this.CostumeSelected!=null)
        //    {
        //        this.CostumeSelected(costume);
        //    }
        //}
        #endregion
    }
}
