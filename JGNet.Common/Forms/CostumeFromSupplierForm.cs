
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Core;
using JGNet.Core.Tools;
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
    public partial class CostumeFromSupplierForm : BaseForm
    {
        private String SupplierID { get; set; }
        public int BrandID { get; }

        public Costume Result { get; set; }
        private List<Costume> currentCostumes;
        private List<Costume> currentSource = new List<Costume>();
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;

      //  public event CJBasic.Action<Costume, EventArgs> CostumeSelected;
       private bool filterValid { get; set; }
        public CostumeFromSupplierForm(List<Costume> items,   string costumeID, String SupplierID, int brandID, bool filterValid)
        {
            InitializeComponent();
           // MenuPermission(menus);
            this.filterValid = filterValid;
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1);
            dataGridViewPagingSumCtrl.Initialize();
            this.skinTextBox1.SkinTxt.Text = costumeID;
            this.SupplierID = SupplierID;
            this.BrandID = brandID;
            this.SetDataSource(items); 
        }



        private void SetDataSource(List<Costume> items)
        {
            this.dataGridView1.DataSource = null;
            this.currentCostumes = items;
            this.currentSource.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].BrandName = CommonGlobalCache.GetBrandName(items[i].BrandID);
                items[i].SupplierName = CommonGlobalCache.GetSupplierName(items[i].SupplierID);
                this.currentSource.Add(items[i]);
            }

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

                List<Costume> resultList = CommonGlobalCache.CostumeList.FindAll(t => t.SupplierID == this.SupplierID && t.ID.ToUpper().Contains(costumeID.ToUpper()) );
                if (filterValid)
                {
                    resultList = resultList.FindAll(t => t.IsValid);
                }


                if (this.BrandID != -1 && resultList != null)
                {
                    resultList = resultList.FindAll(t => t.BrandID == this.BrandID);
                }

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
                //if (CommonGlobalUtil.EngineUnconnectioned(this))
                //{
                //    return;
                //}
                if (this.dataGridView1.Rows.Count > 0)
                {
                    int index = this.dataGridView1.SelectedCells[0].RowIndex;
                    this.ConfirmSelectCell(this.currentCostumes[index]);
                }
            }
            catch (Exception ee)
            {
                ShowError(ee);
            }

            //finally
            //{
            //    CommonGlobalUtil.UnLockPage(this);
            //}


        }

        private void ConfirmSelectCell(Costume item)
        {
            Result = item;
            this.DialogResult = DialogResult.OK;
            //if (this.CostumeSelected != null)
            //{
            //    this.CostumeSelected(item, null);
            //}
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
            //this.ConfirmSelectCell(this.currentCostumes[e.RowIndex]);
        }


        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BaseButton_OK_Click(null, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            this.ConfirmSelectCell(this.currentCostumes[e.RowIndex]);
            
        }
    }
}
