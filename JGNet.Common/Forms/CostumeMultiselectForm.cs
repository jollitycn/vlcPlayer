using CCWin;
using JGNet.Common.Components;
using JGNet.Core;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class CostumeMultiselectForm : BaseForm
    {

    //    private List<CostumeItem> currentLeftCostumeitems;
        private List<CostumeItem> currentRightCostumeitems = new List<CostumeItem>();

        public string ShopID { get; set; }
        private bool filterValid = true;
        public bool FilterValid { get { return filterValid; } set { filterValid = value; } }
        private List<Costume> currentCostume=new List<Costume>();
        private List<Costume> RightCostume = new List<Costume>();

        /// <summary>
        /// 多款服装被选择时触发
        /// </summary>
        public event System.Action<List<CostumeItem>> CostumeMultiSelected;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl1;
        public CostumeMultiselectForm()
        {
            InitializeComponent();
            dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            this.dataGridView1.MultiSelect = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridViewPagingSumCtrl1 = new DataGridViewPagingSumCtrl(this.dataGridView2);
            dataGridViewPagingSumCtrl1.Initialize();
            this.dataGridView2.MultiSelect = true; this.dataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.CostumeMultiSelected += delegate { };
            this.skinTextBox1.SkinTxt.KeyDown += SkinTxt_KeyDown;
             
        }
         

        private void SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BaseButton_Search_Click(null, null);
            }
        }
        private bool isBarCode = false;

        private void BaseButton_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                isBarCode = false;
                string costumeID = this.skinTextBox1.SkinTxt.Text.Trim();
                //if (string.IsNullOrEmpty(costumeID))
                //{
                //    return;
                //}

                //条形码，先根据条形码获取款号
                //List<BarCode> barCodes = CommonGlobalCache.BarCodeList?.FindAll(t => t.BarCodeValue.ToUpper().Equals(costumeID.ToUpper()));

                ////，条形码为一条，找到这个款号
                //if (barCodes != null && barCodes.Count == 1)
                //{
                //    costumeID = barCodes[0].CostumeID;
                //    this.skinTextBox1.SkinTxt.Text = barCodes[0].BarCodeValue;
                //    isBarCode = true;
                //}
                if (costumeID.Length == 15)
                {
                    BarCode4Costume costume = CommonGlobalUtil.GetBarCode(costumeID);
                    if (costume != null)
                    {
                        costumeID = costume.CostumeID;
                        skinTextBox1.SkinTxt.Text = costume.BarCode;
                        isBarCode = true;
                    }
                }

                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => (t.ID.ToUpper().Contains(costumeID.ToUpper())));
                if (filterValid)
                {
                    resultList = resultList.FindAll(t => t.IsValid);
                }

                /* this.currentLeftCostumeitems = CommonGlobalCache.ServerProxy.GetCostumeStores(new CostumeStoreListPara() {
                     CostumeID = costumeID,
                     ShopID = this.ShopID,
                     IsOnlyShowValid = filterValid
                 });*/
                this.currentCostume = resultList;
                this.SetLeftDataSource();
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

        /// <summary>
        /// 设置并绑定左边的Costume源
        /// </summary>
        private void SetLeftDataSource()
        {
            this.dataGridView1.DataSource = null;
            /*  if (this.currentLeftCostumeitems != null && this.currentLeftCostumeitems.Count > 0)
              {
                  List<Costume> currentLeftSource = new List<Costume>();
                  for (int i = 0; i < this.currentLeftCostumeitems.Count; i++)
                  { 
                      this.currentLeftCostumeitems[i].Costume.BrandName = CommonGlobalCache.GetBrandName(this.currentLeftCostumeitems[i].Costume.BrandID);
                      if (this.currentLeftCostumeitems[i].CostumeStoreList != null)
                      {
                          foreach (var item in this.currentLeftCostumeitems[i].CostumeStoreList)
                          {
                              item.CostumeName = this.currentLeftCostumeitems[i].Costume.Name;
                              item.BrandName = this.currentLeftCostumeitems[i].Costume.BrandName;

                              item.CostPrice = this.currentLeftCostumeitems[i].Costume.CostPrice;  
                          }
                      }
                      currentLeftSource.Add(this.currentLeftCostumeitems[i].Costume);
                  }
                  this.dataGridView1.DataSource = currentLeftSource;
              }*/
            //if (this.currentCostume != null && this.currentCostume.Count > 0)
                this.dataGridView1.DataSource = currentCostume;
           this.dataGridView1.Refresh();
        }

        /// <summary>
        /// 设置并绑定右边的Costume源
        /// </summary>
        private void SetRightDataSource()
        {
            this.dataGridView2.DataSource = null;
           if (this.RightCostume != null && this.RightCostume.Count > 0)
            {
                List<Costume> currentRightSource = new List<Costume>();
                for (int i = 0; i < this.RightCostume.Count; i++)
                {
                    //this.currentRightCostumeitems[i].Costume.BrandName = CommonGlobalCache.GetBrandName(this.currentRightCostumeitems[i].Costume.BrandID);
                    currentRightSource.Add(this.RightCostume[i]);
                }
                this.dataGridView2.DataSource = currentRightSource;
            }
            
            this.dataGridView2.Refresh();
        }

        /// <summary>
        /// 刷新左右两边的DataGridView
        /// </summary>
        private void RefreshDataGridView()
        {
            this.SetLeftDataSource();
            this.SetRightDataSource();
        }

        //点击左边部分服装移动到右边
        private void BaseButtonAddSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RightCostume == null || this.currentCostume == null)
                {
                    return;
                }
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewCell item in this.dataGridView1.SelectedCells)
                {
                    if (!rows.Exists(t => t == item.OwningRow))
                    {
                        rows.Add(item.OwningRow);
                    }

                }
                IEnumerable<DataGridViewRow> selectedRows = rows;
                foreach (DataGridViewRow item in selectedRows)
                {
                    if (currentRightCostumeitems.Count >= 100)
                    {
                        GlobalMessageBox.Show("一次最多100条！");
                        break;
                    }
                    this.RightListAddItem(this.currentCostume[item.Index]);
                }
                this.RefreshDataGridView();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        /// <summary>
        /// 将服装移动到右边
        /// </summary>
        /// <param name="costume"></param>
        private void RightListAddItem(Costume costume)
        {
         
            if (!this.RightCostume.Exists(x => x.ID == costume.ID))
            {
                this.RightCostume.Add(costume);
            }

        }

        //点击按钮移动左边的全部到右边列表中
        private void BaseButtonAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RightCostume == null || this.currentCostume == null)
                {
                    return;
                }
               
                foreach (Costume item in this.currentCostume)
                {
                    if (RightCostume.Count >= 100)
                    {
                        GlobalMessageBox.Show("一次最多100条！");
                        break;
                    }
                    this.RightListAddItem(item);
                }
               // this.currentLeftCostumeitems.Clear();
                this.RefreshDataGridView();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        //点击按钮移除右边所有服装
        private void BaseButtonRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.RightCostume.Clear();
                this.SetRightDataSource();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            }

        }

        //点击按钮移除右边部分服装
        private void BaseButtonRemoveSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RightCostume == null)
                {
                    return;
                }
                

                List<Costume> costumes = new List<Costume>();
                foreach (DataGridViewCell item in this.dataGridView2.SelectedCells)
                {
                    if (!costumes.Exists(t => t == item.OwningRow.DataBoundItem))
                    {
                        costumes.Add(item.OwningRow.DataBoundItem as Costume);
                    }
                }

                foreach (var item in costumes)
                {
                    this.RightCostume.Remove(item);
                }




                this.SetRightDataSource();
            }
            catch (Exception ee)
            {

                CommonGlobalUtil.ShowError(ee);
            } 
        }

        //点击按钮 选中服装提交
        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this)) { return; }
                //this.Hide();
                //this.currentRightCostumeitems = new List<CostumeItem>();
                //根据当前获取的商品获取库存信息  this.RightCostume
                foreach (Costume Item in this.RightCostume)
                {
                 List< CostumeItem > curCostumeItem = CommonGlobalCache.ServerProxy.GetCostumeStores(new CostumeStoreListPara()
                    {
                        CostumeID = Item.ID,
                        ShopID = this.ShopID,
                        IsOnlyShowValid = filterValid,
                        IsAccurateQuery = true,
                    });
                    if (curCostumeItem.Count > 0)
                    {
                        this.currentRightCostumeitems.Add(curCostumeItem[0]);
                    }
                }
                this.CostumeMultiSelected(this.currentRightCostumeitems);
                this.DialogResult = DialogResult.OK;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonAddSingle_Click(sender, e);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaseButtonRemoveSingle_Click( sender,  e);
        } 
    }
}
