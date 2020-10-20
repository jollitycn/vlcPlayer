
using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Dev.MyEnum;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using JieXi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using static CCWin.SkinControl.SkinChatRichTextBox;

namespace JGNet.Common
{
    public partial class MemberRechargeRecordForm : BaseForm
    {

        private MemberBalanceChange Memberitem;
        private string memberPhone;
        private DataGridViewPagingSumCtrl dataGridViewPagingSumCtrl;
        public MemberRechargeRecordForm()
        {
            InitializeComponent();
            this.dataGridViewPagingSumCtrl = new DataGridViewPagingSumCtrl(this.dataGridView1,
                new string[] {
                   this.donateMoneyDataGridViewTextBoxColumn.DataPropertyName,
            this.balanceOldDataGridViewTextBoxColumn.DataPropertyName,
            this.rechargeMoneyDataGridViewTextBoxColumn.DataPropertyName,
            this.balanceNewDataGridViewTextBoxColumn.DataPropertyName
                })
            {
                ShowColumnSetting = false
            };
            dataGridViewPagingSumCtrl.Initialize();

        }
        private void BaseButton_Quit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
        internal void ShowDialog(MemberBalanceChange item, string memberId)
        {
            this.Memberitem = item;
            this.memberPhone = memberId; 
            Search();
            this.ShowDialog();
        }

        public void Search()
        {
            try
            {
                InteractResult<List<RechargeRecord>> memberList = CommonGlobalCache.ServerProxy.GetRechargeRecords4Day(this.memberPhone, Memberitem.DateInt);
                dataGridViewPagingSumCtrl.BindingDataSource(memberList.Data);

            }
            catch (Exception ex) { CommonGlobalUtil.ShowError(ex); }
            finally
            {
                UnLockPage();
            }
        }  
    }
}
