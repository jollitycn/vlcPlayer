using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Common.Components;
using JGNet.Common;
using JGNet.Core.InteractEntity;
using CCWin.SkinControl;

namespace JGNet.Common.Components
{
    public partial class SupllierComboBox : UserControl
    {

        private object selectedValue;
        public object SelectedValue
        {
            get { return this.skinComboBox.SelectedValue; }
            set
            {
                if (value != null) { this.skinComboBox.SelectedValue = value;
                    selectedValue = value;
                }
            }
        }

        public Supplier SelectedItem
        {
            get { return this.skinComboBox.SelectedItem as Supplier;
            }
            set
            {
                if (value != null) { this.skinComboBox.SelectedItem = value; }
            }
        }

        public Boolean ShowAdd { get { return skinLabelAdd.Visible; } set { skinLabelAdd.Visible = value; } }
        public string Title { get;  set; }

      //  public bool ShowAll { get { return skinComboBox.ShowAll; } set { skinComboBox.ShowAll = value; } }
        public SupllierComboBox()
        {
            InitializeComponent();
            this.Load += SupllierComboBox_Load;
            this.skinComboBox.TextUpdate += SkinComboBox_TextUpdate;
        }
        String str;
        private void SkinComboBox_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                List<Supplier> listNew = new List<Supplier>();
                //  skinComboBox_Brand.Items.Clear();
                SkinComboBox box = (SkinComboBox)sender;
                List<Supplier> boxSource = box.DataSource as List<Supplier>;
                 str = box.Text;
                List<Supplier> brandList = CommonGlobalCache.SupplierList.FindAll(t=>t.Enabled==true);
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

                if (String.IsNullOrEmpty(str) && !hideAll)
                {
                    listNew = new List<Supplier>();
                    listNew.Add(new Supplier() { Name = CommonGlobalUtil.COMBOBOX_ALL, ID = null, Enabled =true });
                    if (brandList != null)
                    {
                        listNew.AddRange(brandList);
                    }
                }

                //box.TextUpdate -= skinComboBox_Brand_TextUpdate;
               // box.SelectedIndex = -1;
                //box.TextUpdate += skinComboBox_Brand_TextUpdate;

                box.DataSource = null;
                //this.skinComboBox.DisplayMember = "Name";
                //this.skinComboBox.ValueMember = "ID";
                if (listNew.Count > 0)
                {

                    if (isEnabledList)
                    {

                        listNew = listNew.FindAll(t => t.Enabled);
                    }
                    //this.skinComboBox.DisplayMember = "Name";
                    //this.skinComboBox.ValueMember = "ID";
                    box.DisplayMember = "Name";
                    box.ValueMember = "ID";
                    box.DataSource = listNew;
                    //box.SelectedIndex = -1; 
                    //box.Text = str;
                }
                else
                {

                    Supplier nullSuplier = new Supplier();
                    nullSuplier.Name = null;
                    nullSuplier.ID = null;
                    listNew.Add(nullSuplier);
                    box.DisplayMember = "Name";
                    box.ValueMember = "ID";
                    box.DataSource = listNew;
                }


              box.Text = str;
              box.SelectionStart = str.Length;

                //  box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.DroppedDown = true;//自动展开下拉框  

               box.Select(box.Text.Length, 0);
                //this.Cursor = Cursors.Default;

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                box.Cursor = System.Windows.Forms.Cursors.Default;

            }
            catch (Exception ex)
            {
                //输入找不到就不报错了

                //   CommonGlobalUtil.ShowError(ex);
            }
        }

        private void SupllierComboBox_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void skinLabelAdd_Click(object sender, EventArgs e)
        {
            try
            {
                    //    if (GlobalUtil.EngineUnconnectioned(this)) { return; }
                    List<Supplier> list = (List<Supplier>)this.skinComboBox.DataSource;
                    NewSupplierComboBoxForm addForm = new NewSupplierComboBoxForm(list);
                    if (addForm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (list == null) { list = new List<Supplier>(); }
                        Supplier item = addForm.Result;
                        Supplier listItem = list.Find(t => t.Name == item.Name || t.ID == item.ID);
                        if (listItem == null)
                        {
                            item.Enabled = true;
                            item.CreateTime = DateTime.Now;
                        InteractResult result = CommonGlobalCache.SupplierList_OnChange(item);
                            switch (result.ExeResult)
                            {
                                case ExeResult.Success:
                                    this.skinComboBox.DataSource = null;
                                    list.Add(item);
                                    this.skinComboBox.DisplayMember = "Name";
                                    this.skinComboBox.ValueMember = "ID";
                                    this.skinComboBox.DataSource = list;
                                    this.skinComboBox.SelectedIndex = list.IndexOf(item);
                                    break; 
                                case ExeResult.Error:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            //   this.skinComboBoxBigClass.SelectedItem = listItem;
                        }
                    } 

            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            finally
            {
                //GlobalUtil.UnLockPage(this);
            }
        }

        private Boolean hideAll;
        private Boolean isEnabledList;
        public bool HideAll
        {
            get {
                return this.hideAll;
            }
            set {
                this.hideAll = value;
            }
        }

        public bool EnabledSupplier
        {
            set
            {
                isEnabledList = value;
                Initialize();
            }
            get {
                return isEnabledList;
            }
        }
         
        public void Initialize()
        { 
            CommonGlobalUtil.SetSupplier(skinComboBox, hideAll, isEnabledList);
            if (selectedValue != null && !String.IsNullOrEmpty(selectedValue.ToString()))
            {
                this.skinComboBox.SelectedValue = selectedValue;
            }
        }

        private void SupllierComboBox_SizeChanged(object sender, EventArgs e)
        {
            skinComboBox.Width = this.Width - 5 - this.skinLabelAdd.Width;
        }

        private void skinComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.skinComboBox.SelectedText == "")
                {
                  //  SkinComboBox_TextUpdate(sender, null);
                }
            }
        }
    }
}
