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
    public partial class CreateAllReportSelectForm : Common.BaseForm
    { 
        public DateTime Result
        {
            get
            {
                return dateTimePicker_Start.Value;
            }
        }
         
        public CJBasic.Action<DateTime,String, CreateAllReportSelectForm> ConfirmClick;

        public CreateAllReportSelectForm(String title, String dateLabel ,DateTime dateTime, String progressMsg="")
        {
            InitializeComponent();

            //  this.Result = dateTime;
            this.Text = title;
            this.skinLabel4.Text = dateLabel;
            this.dateTimePicker_Start.Value = dateTime;
            this.skinLabel1.Text = progressMsg;
            this.skinLabel1.Visible = false;
            this.Initialize();
            MenuPermission = Core.RolePermissionMenuEnum.重结;
        }

        private void Initialize()
        {
           skinComboBoxShopID.Initialize(  true, false);
            //if (HasPermission(Core.RolePermissionEnum.查看_只看本店))
            //{
            //    skinComboBoxShopID.Enabled = false;
            //    skinComboBoxShopID.SelectedValue = CommonGlobalCache.CurrentShopID;
            //}
           // this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
        }

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
            this.skinLabel1.Visible = true;
            this.UseWaitCursor = true;
            this.skinPanel2. Enabled = false;
            ConfirmClick?.Invoke(dateTimePicker_Start.Value, ValidateUtil.CheckEmptyValue( skinComboBoxShopID.SelectedValue), this);
            //if (ConfirmClickSuccess)
            //{
            //    this.DialogResult = DialogResult.OK;
            //}
        }

        public void SetDialogResult(DialogResult result)
        {
            this.skinPanel2.Enabled = true;
            this.DialogResult = result;
            this.skinLabel1.Visible = false;
            this.UseWaitCursor = false;
        }

        private void BaseButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SelectGuideForm_Load(object sender, EventArgs e)
        {

        }

        public void Cancel()
        {
            this.skinPanel2.Enabled = true;
            this.skinLabel1.Visible = false;
            this.UseWaitCursor = false;
        }
    }
}
