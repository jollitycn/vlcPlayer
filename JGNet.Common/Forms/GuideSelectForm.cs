using CCWin;
using JGNet.Common.Core.Util;
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
    public partial class GuideSelectForm : Common.BaseForm
    { 
        
        public Action<String> ConfirmClick;

        public GuideSelectForm(GuideComboBoxInitializeType type, String  shopID)
        {
            InitializeComponent();

            this.guideComboBox1.Initialize(type, shopID);
            this.Initialize();
        }

        private void Initialize()
        {
           // this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            ConfirmClick?.Invoke(ValidateUtil.CheckEmptyValue(guideComboBox1.SelectedValue));
            //if (ConfirmClickSuccess)
            //{
            //    this.DialogResult = DialogResult.OK;
            //}d
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SelectGuideForm_Load(object sender, EventArgs e)
        {

        } 
    }
}
