using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using CCWin;
using CJBasic.Loggers;
using JGNet.Core;
using JGNet.Core.InteractEntity;
using JGNet.Common.Core;  
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class EditRechargeFrom : Common.BaseForm
    {
        private RechargeDonateRule shopRule = new RechargeDonateRule();
        private Shop shop;
      // private Member member;
        private string guideID;
        //   private bool isClose;
        RechargeRecord curRechargeRecord;
        public EditRechargeFrom(RechargeRecord Record)
        {
            InitializeComponent();
            curRechargeRecord = Record;
            this.skinTextBox_MoneyAlipay.ValueChanged+= skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyBankCard.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyCash.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyWeiXin.ValueChanged += skinTextBox_Money_ValueChanged;
           // this.member = _member;
          //  this.isClose = isClose;
        }
        public EditRechargeFrom()
        {
            InitializeComponent();
            this.skinTextBox_MoneyAlipay.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyBankCard.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyCash.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyWeiXin.ValueChanged += skinTextBox_Money_ValueChanged;
      
        } 

       /* public Member Member
        {
            get { return this.member; }
            set
            {
                this.member = value;
                this.SetMemberLabel();
            }
        }*/

        private void Initialize()
        {

            CleanRechargeTextBox();
           /* if (!IsPos)
            {
                this.member = null;
            }*/
            this.SetMemberLabel();

           /* if (IsPos)
            {
                this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
            }
            else
            {
                this.guideComboBox1.Visible = false;
                skinLabel_Operator.Visible = false;
            }*/

           /* guideID = IsPos ? string.Empty : CommonGlobalCache.CurrentUserID;
            this.shop = CommonGlobalCache.CurrentShop;*/
          //  this.memberIDTextBox1.MemberSelected += MemberIDTextBox1_MemberSelected;
           // this.memberIDTextBox1.CheckMember = true;
            string rules = "";
            //if (IsPos)
            //{

                shopRule = CommonGlobalCache.RechargeDonateRule;
            //}
            //else
            //{
            //    shopRule = CommonGlobalCache.RechargeDonateRule(shop.RechargeRuleID);
            //}

           /* CommonGlobalUtil.RechargeDonateRuleSort(shopRule);
            if (shopRule != null)
            {
                if (shopRule.Rules != null && shopRule.Rules.Count > 0)
                {
                    foreach (Rule rule in shopRule.Rules)
                    {
                        rules += rule.ToString() + "\r\n";
                    }
                }
            }*/
         //   this.skinLabel_Rules.Text = rules;

        }
         

        private void MemberIDTextBox1_MemberSelected(Member member)
        {
          /*  try
            {
                this.member = member;
                //if (this.member == null)
                //{
                //    GlobalMessageBox.Show("该会员不存在");
                //}
                this.SetMemberLabel();
            }
            catch (Exception ee)
            {
                ShowError(ee);
            } */
        }

        private void SetMemberLabel()
        {
            if (this.curRechargeRecord != null)
            {
                //  this.memberIDTextBox1.SkinTxt.Text = string.Empty;
                this.skinLabel5.Text = curRechargeRecord.MemberID;
                this.skinLabel_MemberName.Text = curRechargeRecord.MemberName;
                this.skinTextBox_MoneyCash.Text = curRechargeRecord.MoneyCash.ToString();
                this.skinTextBox_MoneyBankCard.Text = curRechargeRecord.MoneyBankCard.ToString();
                this.skinTextBox_MoneyAlipay.Text=curRechargeRecord.MoneyAlipay.ToString();
                this.skinTextBox_MoneyWeiXin.Text = curRechargeRecord.MoneyWeiXin.ToString();
                this.numericTextBox1.Text = curRechargeRecord.DonateMoney.ToString();
                this.skinTextBox_Remark.Text = curRechargeRecord.Remarks.ToString();
               // this.skinTextBox_RechargeMoney.Text = (curRechargeRecord.MoneyCash + curRechargeRecord.MoneyBankCard + curRechargeRecord.MoneyAlipay + curRechargeRecord.MoneyWeiXin).ToString();
                this.BaseButton_OK.Enabled = true;


            }
            else
            {
              //  this.memberIDTextBox1.SkinTxt.Text = member.PhoneNumber.ToString();
            /*    this.skinLabel_MemberName.Text = this.member.Name.ToString();
                this.skinLabel_Money.Text = this.member.Balance.ToString();
                this.skinLabel_JiFen.Text = this.member.CurrentIntegration.ToString();
               */
            }
        }

        private int GetDonateMoney(int rechargeMoney)
        {
            if (shopRule==null || shopRule.Rules == null || shopRule.Rules.Count == 0)
            {
                return 0;
            }
            Rule tempRule = null;
            for (int i = 0; i < shopRule.Rules.Count; i++)
            {
                if (rechargeMoney < shopRule.Rules[i].RechargeMoney)
                {
                    break;
                }
                tempRule = shopRule.Rules[i];
            }
            if (tempRule == null)
            {
                return 0;
            }
            return tempRule.DonateMoney;

        }
        

        private void BaseButton_OK_Click(object sender, EventArgs e)
        {
           // RechargeResult result = RechargeResult.Error;
            try
            {
              /*  if (this.guideComboBox1.SelectedIndex == 0)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }*/
              /*  if (this.member == null)
                {
                    GlobalMessageBox.Show("充值会员不能为空！");
                    return;
                }*/
                //if (this.member.CardType != 1)
                //{
                //    GlobalMessageBox.Show("该会员不是充值卡会员！");
                //    return;
                //}
                //  int rechargeMoney = int.Parse(this.skinTextBox_RechargeMoney.SkinTxt.Text);
                int moneyCash =  Decimal.ToInt32( this.skinTextBox_MoneyCash.Value);
                int moneyBankCard = Decimal.ToInt32(this.skinTextBox_MoneyBankCard.Value);
                int moneyAlipay = Decimal.ToInt32(this.skinTextBox_MoneyAlipay.Value);
                int moneyWeiXin  = Decimal.ToInt32(this.skinTextBox_MoneyWeiXin.Value);
                int rechargeMoney = moneyCash + moneyBankCard + moneyAlipay + moneyWeiXin;
               decimal  donateM=Decimal.ToInt32(numericTextBox1.Value);
                string remarks = this.skinTextBox_Remark.Text;
                if (rechargeMoney <= 0)
                {
                    GlobalMessageBox.Show("充值金额应为正整数,充值失败");
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                int donateMoney=0;//= int.Parse(this.skinLabel_GiveMoney.Text);
                                  //  decimal balanceNew = this.member.Balance + donateMoney + rechargeMoney;
                InteractResult result = CommonGlobalCache.ServerProxy.UpdateRechargeRecord(new UpdateRechargeRecordPara() {
                    ID = curRechargeRecord.ID,
                    DonateMoney = donateM,
                    MoneyAlipay = moneyAlipay,
                    MoneyBankCard = moneyBankCard,
                    MoneyCash = moneyCash,
                    MoneyWeiXin = moneyWeiXin,
                    Remarks = remarks,
                     
                });

           
                UnLockPage();
                switch (result.ExeResult)
                { 
                    case ExeResult.Success:
                        //   RechargeDialogForm form = new RechargeDialogForm(member, rechargeMoney, donateMoney, balanceNew);
                        /*  if (form.ShowDialog() == DialogResult.OK)
                          {

                          }*/
                        GlobalMessageBox.Show("修改成功！");
                        this.DialogResult = DialogResult.OK;
                      //  this.ParentForm.Refresh();
                      // this.Close();
                        //   this.member = CommonGlobalCache.ServerProxy.GetOneMember(this.member.PhoneNumber);
                        /* this.SetMemberLabel();
                         this.CleanRechargeTextBox();*/
                        //20180616充值完成自动关闭！
                        //  if (isClose) {
                        //只给POS端收银充值用
                        /*   TabPageClose(this.CurrentTabPage, this);*/
                        break;
                    case ExeResult.Error:
                    GlobalMessageBox.Show(result.Msg);
                        break;
                    default:
                        break;
                }  
            }
            catch (Exception ee)
            {
                WriteLog(ee);
            }
            finally
            {
                UnLockPage();
            }
        }

        private void CleanRechargeTextBox()
        {
            //this.skinTextBox_RechargeMoney.Text = "";
            //this.skinLabel_GiveMoney.Text = "";
            this.skinTextBox_MoneyAlipay.Text = string.Empty;
            this.skinTextBox_MoneyBankCard.Text = string.Empty;
            this.skinTextBox_MoneyCash.Text = string.Empty;
            this.skinTextBox_MoneyWeiXin.Text = string.Empty;
            this.skinTextBox_Remark.SkinTxt.Text = string.Empty;
            this.numericTextBox1.Text = string.Empty;
            this.BaseButton_OK.Enabled = false;
        }

        private void RechargeCtrl_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void skinTextBox_RechargeMoney_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.skinTextBox_RechargeMoney.Text))
            {
               // skinLabel_GiveMoney.Text = this.GetDonateMoney(int.Parse(this.skinTextBox_RechargeMoney.Text)).ToString();
            }
        }

        private void skinTextBox_Money_ValueChanged(object sender)
        {
            try
            {
                int moneyCash = Decimal.ToInt32(this.skinTextBox_MoneyCash.Value);
                int moneyBankCard = Decimal.ToInt32(this.skinTextBox_MoneyBankCard.Value);
                int moneyAlipay = Decimal.ToInt32(this.skinTextBox_MoneyAlipay.Value);
                int moneyWeiXin = Decimal.ToInt32(this.skinTextBox_MoneyWeiXin.Value);

                if (moneyCash == 0 && moneyBankCard == 0 && moneyAlipay == 0 && moneyWeiXin == 0)
                {
                    skinTextBox_RechargeMoney.Text = "0";
                  //  skinLabel_GiveMoney.Text = "0";
                }

                int rechargeMoney = moneyCash + moneyBankCard + moneyAlipay + moneyWeiXin;
                this.skinTextBox_RechargeMoney.Text = rechargeMoney.ToString();
            }
            catch (Exception ex) {
                WriteLog(ex);
            }
        }
        public void ShowNew(Control parent)
        {
            try
            {
                this.TopMost = true;
                this.ShowDialog(parent);
                //ctrl.Search(para);
                this.TopMost = false;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void baseButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
