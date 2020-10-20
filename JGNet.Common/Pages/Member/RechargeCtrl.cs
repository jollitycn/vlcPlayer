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
using JGNet.Common.Core;  
using JGNet.Common.Core.Util;

namespace JGNet.Common
{
    public partial class RechargeCtrl : BaseModifyUserControl
    {
        private RechargeDonateRule shopRule = new RechargeDonateRule();
        private Shop shop;
        private Member member;
        private string guideID;
        private bool isClose;

        public RechargeCtrl(Member _member = null, bool isClose = false)
        {
            InitializeComponent();

            this.skinTextBox_MoneyAlipay.ValueChanged+= skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyBankCard.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyCash.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyWeiXin.ValueChanged += skinTextBox_Money_ValueChanged;
            this.member = _member;
            this.isClose = isClose;
        }
        public RechargeCtrl()
        {
            InitializeComponent();
            this.skinTextBox_MoneyAlipay.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyBankCard.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyCash.ValueChanged += skinTextBox_Money_ValueChanged;
            this.skinTextBox_MoneyWeiXin.ValueChanged += skinTextBox_Money_ValueChanged;
      
        } 

        public Member Member
        {
            get { return this.member; }
            set
            {
                this.member = value;
                this.SetMemberLabel();
            }
        }

        private void Initialize()
        {



            CleanRechargeTextBox();
           /* if (!IsPos)
            {
                this.member = null;
            }*/
            this.SetMemberLabel();

            if (IsPos)
            {
                this.guideComboBox1.Initialize(GuideComboBoxInitializeType.Null, CommonGlobalCache.CurrentShopID);
                this.guideComboBox1.Visible = false;
                this.skinlblUserName.Text =CommonGlobalCache.GetUserName(CommonGlobalCache.CurrentUserID);
                this.skinLabel_Operator.Visible = false;
                this.skinlblUserName.Visible = false;
                //this.skinLabel_Operator.Size(Height += skinLabel_Rules.Height;
                // this.skinLabel_Operator.Size = new System.Drawing.Size(this.skinLabel_Operator.Size.Width, this.skinLabel_Operator.Height+ skinLabel_Rules.Height* shopRule.Rules.Count);
                // this.skinLabel_Operator.Location = new System.Drawing.Point(this.skinLabel_Operator.Location.X, this.skinLabel_Operator.Location.Y- skinLabel_Rules.Height * shopRule.Rules.Count);
                // GlobalMessageBox.Show(skinLabel_Rules.Height.ToString());
            }
            else
            {
                this.guideComboBox1.Visible = false;
                skinLabel_Operator.Visible = false;
              //  this.skinlblUserID.Visible = false;
                this.skinlblUserName.Visible = false;
            }

            guideID = IsPos ? CommonGlobalCache.CurrentUserID : CommonGlobalCache.CurrentUserID;
            this.shop = CommonGlobalCache.CurrentShop;
            this.memberIDTextBox1.MemberSelected += MemberIDTextBox1_MemberSelected;
            this.memberIDTextBox1.CheckMember = true;
            string rules = "";
            //if (IsPos)
            //{

                shopRule = CommonGlobalCache.RechargeDonateRule;
            //}
            //else
            //{
            //    shopRule = CommonGlobalCache.RechargeDonateRule(shop.RechargeRuleID);
            //}

            CommonGlobalUtil.RechargeDonateRuleSort(shopRule);
            if (shopRule != null)
            {
                if (shopRule.Rules != null && shopRule.Rules.Count > 0)
                {
                    foreach (Rule rule in shopRule.Rules)
                    {
                        rules += rule.ToString() + "\r\n";
                    }
                }
            }
            this.skinLabel_Rules.Text = rules;

        }
         

        private void MemberIDTextBox1_MemberSelected(Member member)
        {
            try
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
            } 
        }

        private void SetMemberLabel()
        {
            if (this.member == null)
            {
                this.memberIDTextBox1.SkinTxt.Text = string.Empty;
                this.skinLabel_MemberName.Text = string.Empty;
                this.skinLabel_Money.Text = string.Empty;
                this.skinLabel_JiFen.Text = string.Empty;
            }
            else
            {
                this.memberIDTextBox1.SkinTxt.Text = member.PhoneNumber.ToString();
                this.skinLabel_MemberName.Text = this.member.Name.ToString();
                this.skinLabel_Money.Text = this.member.Balance.ToString();
                this.skinLabel_JiFen.Text = this.member.CurrentIntegration.ToString();
                this.BaseButton_OK.Enabled = true;
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
            RechargeResult result = RechargeResult.Error;
            try
            {
               /* if (this.guideComboBox1.SelectedIndex == 0)
                {
                    GlobalMessageBox.Show("操作人不能为空");
                    return;
                }*/
                if (this.member == null)
                {
                    GlobalMessageBox.Show("充值会员不能为空！");
                    return;
                }
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
                if (rechargeMoney <= 0)
                {
                    GlobalMessageBox.Show("充值金额应为正整数,充值失败");
                    return;
                }

                if (CommonGlobalUtil.EngineUnconnectioned(this))
                {
                    return;
                }

                int donateMoney = int.Parse(this.skinLabel_GiveMoney.Text);
                decimal balanceNew = this.member.Balance + donateMoney + rechargeMoney;
                 result = CommonGlobalCache.ServerProxy.Recharge(new RechargeRecord()
                {
                    ID = IDHelper.GetID(OrderPrefix.RechargeRecordOrder, shop.AutoCode),
                    BalanceOld = this.member.Balance,
                    BalanceNew = balanceNew,
                    DonateMoney = donateMoney,
                    MemberID = this.member.PhoneNumber,
                    GuideID = this.guideID,
                    MoneyAlipay = moneyAlipay,
                    MoneyBankCard = moneyBankCard,
                    MoneyCash = moneyCash,
                    MoneyWeiXin = moneyWeiXin,
                    RechargeMoney = rechargeMoney,
                    CreateTime = DateTime.Now,
                    Remarks = this.skinTextBox_Remark.Text,
                    MemberName = this.member.Name,
                    ShopID = shop.ID
                    
                }
                );
                UnLockPage();
                switch (result)
                { 
                    case RechargeResult.Success:
                        RechargeDialogForm form = new RechargeDialogForm(member, rechargeMoney, donateMoney, balanceNew);
                        if (form.ShowDialog() == DialogResult.OK)
                        {

                        }
                        this.member = CommonGlobalCache.ServerProxy.GetOneMember(this.member.PhoneNumber);
                        this.SetMemberLabel();
                        this.CleanRechargeTextBox();
                        //20180616充值完成自动关闭！
                        //  if (isClose) {
                        //只给POS端收银充值用
                        TabPageClose(this.CurrentTabPage, this);
                        break;
                    case RechargeResult.MemberIsNotExist:
                        GlobalMessageBox.Show("会员不存在！");
                        break;
                    case RechargeResult.Error:
                    GlobalMessageBox.Show("内部错误！");
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
                skinLabel_GiveMoney.Text = this.GetDonateMoney(int.Parse(this.skinTextBox_RechargeMoney.Text)).ToString();
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
                    skinLabel_GiveMoney.Text = "0";
                }

                int rechargeMoney = moneyCash + moneyBankCard + moneyAlipay + moneyWeiXin;
                this.skinTextBox_RechargeMoney.Text = rechargeMoney.ToString();
            }
            catch (Exception ex) {
                CommonGlobalUtil.WriteLog(ex);
            }
        }

        private void guideComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.guideID = ValidateUtil.CheckEmptyValue(this.guideComboBox1.SelectedValue);
        }

        public void BindingSource(Member member)
        {
            this.member = member;
            SetMemberLabel();
        }

        private void skinlblUserName_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel_Operator_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel9_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel_Rules_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel8_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel10_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel11_Click(object sender, EventArgs e)
        {

        }

        private void skinTextBox_Remark_Paint(object sender, PaintEventArgs e)
        {

        }

        private void skinLabel_GiveMoney_Click(object sender, EventArgs e)
        {

        }

        private void skinTextBox_RechargeMoney_Click(object sender, EventArgs e)
        {

        }
    }
}
