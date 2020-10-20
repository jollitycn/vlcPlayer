
using JGNet.Common.Components;
using JGNet.Core;
using JGNet.Core.Tools;
using CJBasic.Helpers;
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
    public partial class PfCostumeFromShopForm : BaseForm
    {

        private String ShopID { get; set; }
        private List<CostumeItem> currentCostumeitems;
        private List<Costume> currentSource=new List<Costume>();
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
          
        private String curSuplierId { get; set; }
     //   public event CJBasic.Action<CostumeItem, EventArgs> CostumeSelected;
        private bool filterValid { get; set; }
        public CostumeItem Result { get; private set; }
         
        public PfCostumeFromShopForm(List<CostumeItem> items, string costumeID, String shopID,bool filterValid)
        {
            InitializeComponent();
            this.filterValid = filterValid;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            this.skinTextBox1.SkinTxt.Text = costumeID;
            this.ShopID = shopID;
            this.SetDataSource(items);
        }
        private String CustomerID { get; set; }
        public PfCostumeFromShopForm(List<Costume> items, string costumeID, String CustomerID, bool filterValid)
        {
            InitializeComponent();
            this.filterValid = filterValid;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            this.skinTextBox1.SkinTxt.Text = costumeID;
            this.CustomerID = CustomerID;
            this.SetDataSource(items);
        }
        public PfCostumeFromShopForm(List<Costume> items, string costumeID, String shopID, bool filterValid,String SuplierID)
        {
            InitializeComponent();
            this.filterValid = filterValid;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            this.skinTextBox1.SkinTxt.Text = costumeID;
            this.ShopID = shopID;
            this.curSuplierId = SuplierID;
            this.SetDataSource(items);
        }

        private void SetDataSource(List<CostumeItem> items)
        {
            this.currentCostumeitems = items;
            this.currentSource.Clear();
            for (int i = 0; i < items.Count; i++)
            {
               
                items[i].Costume.BrandName = CommonGlobalCache.GetBrandName(items[i].Costume.BrandID);
                //items[i].Costume.SupplierName = CommonGlobalCache.GetSupplierName(items[i].Costume.SupplierID);
                //if (items[i].CostumeStoreList != null)
                //{
                //    foreach (var item in items[i].CostumeStoreList)
                //    {
                //        item.CostumeName = items[i].Costume.Name;
                //        item.BrandName = items[i].Costume.BrandName;
                //        item.Price = items[i].Costume.Price;
                //        item.CostPrice = items[i].Costume.CostPrice;
                //    }
                //}
                this.currentSource.Add(items[i].Costume);
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.currentSource;
        }

        private void SetDataSource(List<Costume> items)
        {
            //this.currentSource = items;

          this.currentSource.Clear();
            for (int i = 0; i < items.Count; i++)
            {

                items[i].BrandName = CommonGlobalCache.GetBrandName(items[i].BrandID);
                //items[i].Costume.SupplierName = CommonGlobalCache.GetSupplierName(items[i].Costume.SupplierID);
                //if (items[i].CostumeStoreList != null)
                //{
                //    foreach (var item in items[i].CostumeStoreList)
                //    {
                //        item.CostumeName = items[i].Costume.Name;
                //        item.BrandName = items[i].Costume.BrandName;
                //        item.Price = items[i].Costume.Price;
                //        item.CostPrice = items[i].Costume.CostPrice;
                //    }
                //}

                this.currentSource.Add(items[i]);
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.currentSource;
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string costumeID = this.skinTextBox1.SkinTxt.Text.Trim();
                if (string.IsNullOrEmpty(costumeID))
                {
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
                //    this.skinTextBox1.SkinTxt.Text = barCodes[0].BarCodeValue;
                //}    
                if (costumeID.Length == 15)
                {
                    BarCode4Costume costume = CommonGlobalUtil.GetBarCode(costumeID);
                    if (costume != null)
                    {
                        costumeID = costume.CostumeID;
                        skinTextBox1.SkinTxt.Text = costume.BarCode;
                        //  isBarCode = true;
                    }
                }
                /*  List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => (t.ID.ToUpper().Contains(costumeID.ToUpper())));
                  if (filterValid)
                  {
                      resultList = resultList.FindAll(t => t.IsValid);
                  }*/
                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.ID.ToUpper().Contains(costumeID.ToUpper()) && t.IsValid == true);
              //  List<CostumeItem> resultList = currentCostumeitems.FindAll(t => t.Costume.ID.ToUpper().Contains(costumeID.ToUpper()));
                /*   List<CostumeItem> resultList = CommonGlobalCache.ServerProxy.GetCostumeStoreList(
                       new CostumeStoreListPara() { CostumeID = costumeID, ShopID = this.ShopID,
                           IsOnlyShowValid = filterValid,
                          // IsAccurateQuery = true,
                       });*/

               // this.currentSource.Clear();
               // this.currentSource = resultList;
               /* foreach (CostumeItem cItem in resultList)
                {
                    currentSource.Add(cItem.Costume);
                }*/

                this.SetDataSource(resultList);
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

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    int index = this.dataGridView1.SelectedCells[0].RowIndex;
                    Costume curCostume = currentSource[index];
                    List<CostumeItem> selectResultItem = CommonGlobalCache.ServerProxy.GetPfCustomerStores(CustomerID, curCostume.ID,true);
                    /*   List<CostumeItem> selectResultItem = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara()
                       {
                           CostumeID = curCostume.ID,
                           ShopID = this.ShopID,
                           IsOnlyShowValid = filterValid,
                           IsAccurateQuery = true,

                       });
                       */
                    if (curSuplierId != null && curCostume != null)
                    {
                        selectResultItem = selectResultItem.FindAll(i => i.Costume.SupplierID == curSuplierId);
                    }
                    if (selectResultItem.Count > 0) { this.ConfirmSelectCell(selectResultItem[0]); }
                    else
                    {
                        CostumeItem pfCostumeItem = new CostumeItem();
                        List < CostumeStore> cStore = new List<CostumeStore>();
                        pfCostumeItem.Costume = curCostume;

                        String[] colors = CommonGlobalUtil.GetStringSplit(pfCostumeItem.Costume.Colors, ',');
                        //创建虚拟库存信息
                        foreach (var color in colors)
                        {
                            //color not existed,then add one 
                            cStore.Add(SetupStores(pfCostumeItem, color));
                        }

                        pfCostumeItem.CostumeStoreList = cStore;
                        this.ConfirmSelectCell(pfCostumeItem);
                        //curCostume.ColorList
                        //pfCostumeItem.CostumeStoreList = cStore;
                        //  ShowMessage("该店铺不存在该商品！");
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
        private static CostumeStore SetupStores(CostumeItem costumeItem, String color)
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

        private void ConfirmSelectCell(CostumeItem item)
        {
            //if (this.CostumeSelected!=null)
            //{
            //    this.CostumeSelected(item,null);
            //}
            Result = item;
            this.DialogResult = DialogResult.OK;
        }

        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0)
            //{
            //    return;
            //}
            //this.ConfirmSelectCell(this.currentCostumeitems[e.RowIndex]);
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // BaseButton_OK_Click(null, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            Costume cItem = this.currentSource[e.RowIndex];
            List<CostumeItem> selectResultItem = CommonGlobalCache.ServerProxy.GetPfCustomerStores(CustomerID, cItem.ID,true);
             
         /*   List<CostumeItem> selectResultItem = CommonGlobalCache.ServerProxy.GetCostumeStoreList(new CostumeStoreListPara()
                {
                    CostumeID = cItem.ID,
                    ShopID =null,
                    IsOnlyShowValid = filterValid,
                    IsAccurateQuery = true,
                });
                */
                if (selectResultItem.Count > 0) { this.ConfirmSelectCell(selectResultItem[0]); }
                else
                {
                CostumeItem pfCostumeItem = new CostumeItem();
                List<CostumeStore> cStore = new List<CostumeStore>();
                pfCostumeItem.Costume = cItem;

                String[] colors = CommonGlobalUtil.GetStringSplit(pfCostumeItem.Costume.Colors, ',');
                //创建虚拟库存信息
                foreach (var color in colors)
                {
                    //color not existed,then add one 
                    cStore.Add(SetupStores(pfCostumeItem, color));
                }
                pfCostumeItem.CostumeStoreList = cStore;
                this.ConfirmSelectCell(pfCostumeItem);
                // ShowMessage("该店铺不存在该商品！");
            }
            
        }
    }
}
