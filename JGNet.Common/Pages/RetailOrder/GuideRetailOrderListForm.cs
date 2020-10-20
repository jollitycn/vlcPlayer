using JGNet.Common;
using JGNet.Common.Core.Util;
using JGNet.Core.InteractEntity;
using JGNet.Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Manage.Components
{
    public partial class GuideRetailOrderListForm :
        BaseForm
    {
        GuideRetailOrderListCtrl ctrl;

        public GuideRetailOrderListForm()
        {
            InitializeComponent();
            ctrl = new GuideRetailOrderListCtrl();
            ctrl.BackColor = System.Drawing.Color.Transparent;
            ctrl.Dock = DockStyle.Fill;
            this.Controls.Add(ctrl);
        }
        

        public void ShowDialog(GetGuideAchievementDetailsPara para)
        {
            try
            {
                this.TopMost = true;
                this.Show();
                ctrl.Search(para);
                this.TopMost = false;
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }

        }

        private void SupplierAccountRecordSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
