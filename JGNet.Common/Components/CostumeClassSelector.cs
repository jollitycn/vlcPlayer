using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;
using JGNet.Manage.Components;
using JGNet.Common;
using JGNet.Common.Components;
using CCWin.SkinControl; 
using JGNet.Core.InteractEntity;

namespace JGNet.Common
{
    public partial class CostumeClassSelector : UserControl
    {
        private Costume selectedValue = new Costume { ClassID = -1,BigClassID=-1 };
        public Costume SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                SetText();
            }
        }

        private Boolean showAll;
        public Boolean ShowAll
        {
            set
            {
                showAll = value;
                if (showAll)
                {
                    this.skinTextBox1.Text = "所有";
                }
                else
                {
                    this.skinTextBox1.Text = String.Empty;
                }
            }
        }

        public event Action<Costume> ItemSelected;
        public CostumeClassSelector()
        {
            InitializeComponent();
            skinTextBox1.SkinTxt.DoubleClick += skinTextBox1_DoubleClick;
        }


        private void Form_ItemSelected(TreeNode node, EventArgs t2)
        {
            Costume costume = new Costume();
            costume.ClassID = -1;
            costume.BigClassID = -1;
            if (node.Tag is CostumeClassInfo)
            {
                CostumeClassInfo info = node.Tag as CostumeClassInfo;
                costume.BigClass = info.BigClass;
                costume.BigClassID = info.ID;
                costume.ClassID = info.ID;
            }
            else if (node.Tag is SmallClass)
            {
                CostumeClassInfo infoParent = node.Parent.Tag as CostumeClassInfo;
                SmallClass info = node.Tag as SmallClass;
                costume.BigClass = info.BigClass;
                costume.SmallClass = info.SmallClassStr;
                costume.BigClassID = infoParent.ID;
                costume.ClassID = info.ID;
            }
            else if (node.Tag is SubSmallClass)
            {
                CostumeClassInfo infoBig = node.Parent.Parent.Tag as CostumeClassInfo;
                SubSmallClass info = node.Tag as SubSmallClass;
                costume.BigClass = info.BigClass;
                costume.SmallClass = info.SmallClass;
                costume.SubSmallClass = info.SubSmallClassStr;
                costume.BigClassID = infoBig.ID; 
                costume.ClassID = info.ID;
            }

            SelectedValue = costume;
            ItemSelected?.Invoke(costume);
        }

        private void SetText()
        {
            if (selectedValue != null && !String.IsNullOrEmpty(selectedValue.BigClass))
            {
                String str = string.Empty;
                str = selectedValue.BigClass;
                if (!String.IsNullOrEmpty(selectedValue.SmallClass))
                { str += "-" + selectedValue.SmallClass; }
                if (!String.IsNullOrEmpty(selectedValue.SubSmallClass))
                { str += "-" + selectedValue.SubSmallClass; }
                this.skinTextBox1.Text = str;
            }
            else
            {
                if (showAll)
                {
                    this.skinTextBox1.Text = "所有";
                }
                else
                {
                    this.skinTextBox1.Text = String.Empty;
                }
            }
        }

        private void CostumeClassSelector_SizeChanged(object sender, EventArgs e)
        {
            if (this.baseButton1.Visible)
            {
                this.skinTextBox1.Width = this.Width - 5 - this.baseButton1.Width;
            } 
        }

        private void skinTextBox1_DoubleClick(object sender, EventArgs e)
        {
            ShowClassDialog();
        }

        private void ShowClassDialog()
        {
            CostumeClassSelectForm form = new CostumeClassSelectForm();
            form.ItemSelected += Form_ItemSelected;
            form.ShowDialog();
        }
    }
}
