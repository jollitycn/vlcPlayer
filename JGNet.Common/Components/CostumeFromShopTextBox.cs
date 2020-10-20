using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CJBasic.Helpers;
using JGNet.Core.Tools;

namespace JGNet.Common
{
    public partial class CostumeFromShopTextBox :  JGNet.Common.TextBox
    {

        public static List<CostumeStore> GetCostumeStores(CostumeItem costumeItem, bool addEmptyStore)
        {

            List<CostumeStore> storeList = new List<CostumeStore>();
            try
            {

                String[] colors = CommonGlobalUtil.GetStringSplit(costumeItem.Costume.Colors, ',');
                if (colors != null && colors.Length > 0)
                {
                    //判断颜色是否有库存信息
                    if (costumeItem.CostumeStoreList != null)
                    {
                        storeList.AddRange(costumeItem.CostumeStoreList);

                        if (colors.Length > costumeItem.CostumeStoreList.Count)
                        {
                            if (addEmptyStore)
                            {
                                foreach (var color in colors)
                                {
                                    if (!costumeItem.CostumeStoreList.Exists(t => t.ColorName == color))
                                    {
                                        storeList.Add(SetupStores(costumeItem, color));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (addEmptyStore)
                        {
                            //创建虚拟库存信息
                            foreach (var color in colors)
                            {
                                //color not existed,then add one 
                                storeList.Add(SetupStores(costumeItem, color));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            foreach (var item in storeList)
            {
                item.CostumeName = CommonGlobalCache.GetCostumeName(item.CostumeID);
            }
            return storeList;
        }

        private static CostumeStore SetupStores(CostumeItem costumeItem ,String color)
        {
            CostumeStore store = new CostumeStore();
            ReflectionHelper.CopyProperty(costumeItem.Costume, store);
            store.ColorName = color;
            store.F = 0;
            store.L = 0;
            store.XS = 0;
            store.M = 0;
            store.S = 0;
            store.XL = 0;
            store.XL2 = 0;
            store.XL3 = 0;
            store.XL4 = 0;
            store.XL5 = 0;
            store.XL6 = 0;
            return store;
        }

        private Boolean reload;
        internal void Reload()
        {
            reload = true;
            this.SkinTxt_TextChanged(null,null);
            reload = false;
        }

        public String ShopID { get; set; }
        /// <summary>
        /// 增加供应商
        /// </summary>
        public String SupplierID { get; set; }
        private bool isBarCode = false;
        private bool filterValid = true;
        public bool FilterValid { get { return filterValid; }set { filterValid = value; } }

       // public bool EnableTextChanged { get; set; }

        private CostumeItem curItem;
        /// <summary>
        /// 款号被选中时触发
        /// </summary>
        public event CJBasic.Action<CostumeItem,bool> CostumeSelected;
        public CostumeFromShopTextBox()
        {
            InitializeComponent();
            base.SkinTxt.PreviewKeyDown += SkinTxt_PreviewKeyDown;
            base.SkinTxt.TextChanged += SkinTxt_TextChanged;
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
        {
            //if (EnableTextChanged)
            //{
                if (String.IsNullOrEmpty(this.Text))
                {
                    if (this.CostumeSelected != null)
                    {
                        curItem = null;
                        this.CostumeSelected(curItem, false);
                    }
                }
                else
                {

                    string costumeID = this.Text.Trim();
                ////条形码，先根据条形码获取款号
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
                //    isBarCode = true;
                //}

                List<CostumeItem> resultList = null;
                try
                {
                  //  this.ReadOnly = true;
                    resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(
                        new CostumeStoreListPara()
                        {
                            CostumeID = costumeID,
                            ShopID = this.ShopID,
                            IsOnlyShowValid = filterValid
                        });
                }
                catch (Exception ex)
                {
                    CommonGlobalUtil.ShowError(ex);
                }
                finally
                {
                  //  this.ReadOnly = false;
                }

                    //有供应商则过滤供应商
                    if (SupplierID != null && resultList != null)
                    {
                        resultList = resultList.FindAll(i => i.Costume.SupplierID == SupplierID);
                    }
                    if (resultList == null || resultList.Count == 0)
                    {
                        if (this.CostumeSelected != null)
                        {
                            curItem = null;
                            this.CostumeSelected(curItem, false);

                        }
                        return;
                    }
                    else
                    {
                        if (reload)
                        {
                            resultList = resultList.FindAll(t => t.Costume.ID.ToUpper() == costumeID.ToUpper());
                        }
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

                        if (this.CostumeSelected != null)
                        {
                            curItem = resultList[0];
                            if (reload)
                            {
                                this.CostumeSelected(curItem, true);
                            }
                            else
                            {
                                this.CostumeSelected(curItem, false);
                            }
                        }
                    }
                }
           // }
        }

        private void SkinTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //取消登登登
            if (e.KeyChar ==Convert.ToChar(13))
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

        private void CostumeForm_CostumeSelected(CostumeItem costumeItem, EventArgs args)
        {
            this.Text = costumeItem.Costume.ID;
            if (this.CostumeSelected!=null)
                    
            {
                curItem = costumeItem;
                this.CostumeSelected(costumeItem, true);
            }
        }

        public void Search()
        {
            try
            {
                isBarCode = false;
                string costumeID = this.Text.Trim();
                if (string.IsNullOrEmpty(costumeID))
                {
                    if (this.CostumeSelected != null)
                    {
                        curItem = null;
                        this.CostumeSelected(curItem, true);
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
                //    this.Text = barCodes[0].BarCodeValue;
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

                  List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => (t.ID.ToUpper().Contains(costumeID.ToUpper())));
                  if (filterValid)
                  {
                      resultList = resultList.FindAll(t => t.IsValid);
                  }
              /*  CostumeItem t = new CostumeItem();
                
                List<CostumeItem> resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara()
                { 
                    CostumeID = costumeID,
                    ShopID = this.ShopID,
                    IsOnlyShowValid = filterValid
                });
                

                //有供应商则过滤供应商
                if (SupplierID != null && resultList != null)
                {
                    resultList = resultList.FindAll(i => i.Costume.SupplierID == SupplierID);
                }*/
                if (resultList == null || resultList.Count == 0)
                {
                    if (this.CostumeSelected != null)
                    {
                        curItem = null;
                        this.CostumeSelected(curItem, true);
                    }
                    this.Text = "";
                    return;
                }
                if (resultList.Count == 1)
                {
                    if (!isBarCode)
                    {
                        this.Text = resultList[0].ID;
                    }
                    if (this.CostumeSelected != null)
                    {
                        Costume curCostume=resultList[0];
                        curItem = null; //根据条件获取库存信息

                        List<CostumeItem> selectResultItem = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara()
                        {
                            CostumeID = resultList[0].ID,
                            ShopID = this.ShopID,
                            IsOnlyShowValid = filterValid,
                            IsAccurateQuery = true,
                        });

                        if (SupplierID != null && resultList != null)
                        {
                            selectResultItem = selectResultItem.FindAll(i => i.Costume.SupplierID == SupplierID);
                        }
                        if (selectResultItem.Count > 0)
                        {
                            this.CostumeSelected(selectResultItem[0], true);
                        }
                        else
                        {
                            this.Text = "";
                        }

                        
                    }
                }
                else
                {

                    CostumeFromShopForm costumeForm = new CostumeFromShopForm(resultList, costumeID, ShopID, FilterValid,SupplierID);
                  
                    if (costumeForm.ShowDialog() == DialogResult.OK)
                    {
                        if (costumeForm.Result == null)
                        {
                            return;
                        }
                        this.Text = costumeForm.Result.Costume.ID;
                        curItem = costumeForm.Result;
                        CostumeSelected?.Invoke(curItem, true);
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
        #endregion
    }
}
