using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using CCWin.SkinControl;
using CJPlus; 
using System.Runtime.InteropServices;
using JGNet.Core.InteractEntity;

namespace JGNet.Common
{
    public partial class BrandComboBox : SkinComboBox
    {

        public BrandComboBox()
        {
            InitializeComponent();
            this.Width = 80;
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.TextUpdate += skinComboBox_Brand_TextUpdate;
            
        }

        public String SupplierID { get; set; }
        private bool showAll = true;
        public bool ShowAll { get { return showAll; } set { showAll = value; } }
        public String SelectStr { get; set; }
        private void skinComboBox_Brand_TextUpdate(object sender, EventArgs e)
        {
            SkinComboBox box = null; 
            try
            {
                List<Brand> listNew = new List<Brand>();
                //  skinComboBox_Brand.Items.Clear();

                  box = (SkinComboBox)sender;

                List<Brand> boxSource = box.DataSource as List<Brand>;
                if (boxSource != null && boxSource.Count == 0)
                {
                     List<Brand> nullList = new List<Brand>();
                     Brand b = new Brand();
                    b.AutoID =-2;
                    b.Name = "";
                    nullList.Add(b);
                     box.DisplayMember = "Name";
                     box.ValueMember = "AutoID";
                    box.DataSource = nullList;
                   // box.Cursor = Cursors.Default;
                    
                    /* box.DisplayMember = null;
                     box.ValueMember =null;
                     box.DataSource = null;*/
                    return;
                }
                String str = box.Text;
                SelectStr = box.Text;
                // List<Brand> brandList = CommonGlobalCache.BrandList.FindAll(t=>t.IsDisable=true);
                List<Brand> brandList = null;
                 InteractResult<List<Brand>> result=CommonGlobalCache.ServerProxy.GetEnableBrands();
                if (result.ExeResult == ExeResult.Success)
                {
                    brandList = result.Data;
                }
                if (!String.IsNullOrEmpty(SupplierID))
                {
                    brandList = brandList?.FindAll(t => t.SupplierID == SupplierID);
                }

                if (brandList != null)
                {
                    foreach (var item in brandList)
                    {
                        if ((item.Name + item.FirstCharSpell).ToUpper().Contains(str.ToUpper()))
                        {
                            listNew.Add(item);
                        }
                    }
                }



                //品牌下拉框：输入内容没有先列出开头为这个内容的品牌；输入品牌文字数为3个以上的，跳至“所有”，没有列出输入的品牌
                listNew.Sort((x, y) =>
                {
                    int xi = x.Name.ToUpper().IndexOf(str.ToUpper()) + x.FirstCharSpell.ToUpper().IndexOf(str.ToUpper());
                    int yi = y.Name.ToUpper().IndexOf(str.ToUpper()) + y.FirstCharSpell.ToUpper().IndexOf(str.ToUpper());
                    return xi.CompareTo(yi);
                });

                if (String.IsNullOrEmpty(str) && showAll)
                {
                    listNew = new List<Brand>();
                    listNew.Add(new Brand() { Name = CommonGlobalUtil.COMBOBOX_ALL, AutoID = -1 });
                    if (brandList != null)
                    {
                        listNew.AddRange(brandList);
                    }
                }

                //box.TextUpdate -= skinComboBox_Brand_TextUpdate;
                //box.SelectedIndex = 0;
                //box.TextUpdate += skinComboBox_Brand_TextUpdate;

                //box.SelectedIndexChanged -= box.SelectedIndexChanged;

                //更新的時候不要觸發SelectedIndexChanged
                if (listNew == null || listNew.Count == 0)
                {
                    /*box.DataSource=new List<Brand>();
                    box.DisplayMember = "Name"; ;
                    box.ValueMember = "AutoID";*/
                   
                    List<Brand> nullList = new List<Brand>();
                    Brand b = new Brand();
                    b.AutoID = -2;
                    b.Name = "";
                    nullList.Add(b);
                    box.DisplayMember = "Name";
                    box.ValueMember = "AutoID"; 

                    //box.DisplayMember = "Name"; ;
                    //box.ValueMember = "AutoID";
                    box.DataSource = nullList; 

                }
                else
                {
                    box.DisplayMember = "Name";
                    box.ValueMember = "AutoID";
                    box.DataSource = listNew;
                }

                box.Text = str;
                SelectStr = str;
                box.SelectionStart = str.Length;
                //  box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.DroppedDown = true;//自动展开下拉框  

             //   box.Cursor = Cursors.Default;
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                box.Cursor = System.Windows.Forms.Cursors.Default;
               // Console.CursorVisible = true;
            }
            catch (Exception ex)
            {
                //输入找不到就不报错了
               // box.Cursor = Cursors.Default;
                 // CommonGlobalUtil.ShowError(ex);
            }
        }

        private void BrandComboBox_TextChanged(object sender, EventArgs e)
        {
          //  this.Cursor = Cursors.Default;
        }
    }
}
