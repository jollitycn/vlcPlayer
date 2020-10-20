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
    public partial class SelectGuideForm : Common.BaseForm
    { 
        public Guide Guide { get; set; }
        public SelectGuideForm(Guide guide=null )
        {
            InitializeComponent();
            
            this.Guide = guide;
            this.Initialize();
        }

        private void Initialize()
        {
            this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            if (this.guideComboBox1.Visible && this.guideComboBox1.SelectedIndex == 0)
            {
                GlobalMessageBox.Show("操作人不能为空");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SelectGuideForm_Load(object sender, EventArgs e)
        {

        }

        private void guideComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Guide = (Guide)this.guideComboBox1.SelectedItem;
        }
    }
}
