using JGNet.Core.InteractEntity;
using JGNet.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common.Components
{
    public partial class NewSupplierComboBoxForm : 
        BaseForm
    {
        private Supplier result;
        public Supplier Result { get { return result; } }
        private List<Supplier> orgList;
        public NewSupplierComboBoxForm(List<Supplier> suppliers)
        {
            InitializeComponent();
            this.orgList = suppliers; 
        }

        private String GetNewColorID()
        {
            String id = string.Empty;
            InteractResult result = CommonGlobalCache.ServerProxy.GetSupplierId();
            switch (result.ExeResult)
            {
                case ExeResult.Success:
                    id = result.Msg;
                    break;
                case ExeResult.Error:
                    GlobalMessageBox.Show(result.Msg);
                    break;
                default:
                    break;
            }
            return id;
        }

        private void SkinTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BaseButton1_Click(null, null);
            }
        }

        private void BaseButton1_Click(object sender, EventArgs e)
        {
            String name = this.skinTextBoxName.SkinTxt.Text.Trim();
             if (String.IsNullOrEmpty(name))
            {
                this.skinTextBoxName.Focus();
                return;
            }
            this.result = new Supplier()
            {
                ID = GetNewColorID(),
                Name = name,
                OrderNo = Decimal.ToInt32(textBoxSort.Value),
                Enabled =true
            };

            this.DialogResult = DialogResult.OK;
        } 

        private void skinTextBoxName_Leave(object sender, EventArgs e)
        {
            Supplier listItem = orgList?.Find(t => t.Name == skinTextBoxName.Text);
            if (listItem != null)
            {
                GlobalMessageBox.Show("供应商名称已存在");
                skinTextBoxName.Text = string.Empty;
                skinTextBoxName.Focus();
            }
        }
         
    }
}
