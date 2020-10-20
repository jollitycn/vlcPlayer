using CCWin;
using JGNet.Core.InteractEntity;
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
    public partial class SelectMoneyForm : Common.BaseForm
    { 
        public decimal result {
            get { return numericTextBox1.Value; }
            set { numericTextBox1.Value = value; }
        }

        public SelectMoneyForm(decimal result=0)
        {
            InitializeComponent();
            this.result = result;
            this.Initialize();
        }

        private void Initialize()
        {
            //this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
                this.DialogResult = DialogResult.OK;
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
         
    }
}
