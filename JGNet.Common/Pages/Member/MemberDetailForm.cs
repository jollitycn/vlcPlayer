using CCWin.SkinControl;
using JGNet.Common;
using JGNet.Common.Core;  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace JGNet.Common
{
    public partial class MemberDetailForm : Common.BaseForm
    {

        private NewMemberCtrl ctrl = null;
        public Member member { get; set; }
        public MemberDetailForm()
        {

            InitializeComponent();

        }


        public void ShowDialog(Member member)
        {
            try
            {
                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }
                this.member = member;
                this.skinPanel1.Controls.Remove(ctrl);
                ctrl = new NewMemberCtrl();
                ctrl.Dock = DockStyle.Fill;
                this.skinPanel1.Controls.Add(ctrl);
                Display();
            }
            catch (Exception ee)
            {

                ShowError(ee);
            }
            finally
            {
                UnLockPage();
                this.TopMost = true;
                this.Show();
                this.TopMost = false;
            }
        }
        private void Display()
        {
          //  ctrl.Hide();
            ctrl.DisplayMember(member);
            this.skinLabel_CurrentIntegration.Text = this.member.CurrentIntegration.ToString();
            this.skinLabel_AccruedIntegration.Text = this.member.AccruedIntegration.ToString();
            this.skinLabelRemainMoney.Text = this.member.Balance.ToString();
            this.skinLabel_AccruedSpend.Text = this.member.AccruedSpend.ToString();
            this.skinLabel_QuantityOfBuy.Text = member.QuantityOfBuy.ToString();
            this.skinLabel_BuyCount.Text = member.BuyCount.ToString();
            this.skinLabel_Donate.Text = member.Donate.ToString();
            this.skinLabel_AccruedRecharge.Text = member.AccruedRecharge.ToString();
        }

        private void MemberDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel =true;
            this.Hide();
        }
         
    }
}
