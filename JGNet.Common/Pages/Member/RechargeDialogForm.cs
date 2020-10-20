using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;

namespace JGNet.Common
{
    /// <summary>
    /// JGNet.Common中所有Form的基类。使其拥有一致的皮肤和Icon。
    /// </summary>
    public partial class RechargeDialogForm : BaseForm
    {
        public RechargeDialogForm(Member member, int rechargeMoney, int donateMoney, decimal balanceNew)
        {
            InitializeComponent();
            this.skinLabelMemberId.Text = member.PhoneNumber;
            this.skinLabelRechargeMoney.Text = rechargeMoney.ToString();
            this.skinLabelGivenMoney.Text = donateMoney.ToString();
            this.skinLabelFinalMoney.Text = balanceNew.ToString();
        }
         
        private void BaseButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
