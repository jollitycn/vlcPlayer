using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet
{
    public partial class PfAccountRecord
    {
        /// <summary>
        /// 收款方式
        /// </summary>
        //public PfAccountRecordType PfAccountRecordType { get; set; }

        public String PfCustomerName { get; set; }
        public String AccountTypeName { get; set; }
        public String AdminUserName { get; set; }

        public string PayTypeName
        {
            get
            {
                return EnumHelper.GetDescription((PfAccountRecordType)this.PayType);
            }
        }
    }

    public enum PfAccountRecordType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 微信
        /// </summary>
        [Description("微信")]
        WeiXin = 0,

        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        Alipay = 1,

        /// <summary>
        /// 银联卡
        /// </summary>
        [Description("银联卡")]
        BankCard = 2,

        /// <summary>
        /// 现金
        /// </summary>
        [Description("现金")]
        Cash = 3,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 4,

        /// <summary>
        /// 余额
        /// </summary>
        [Description("余额")]
        Balance = 5
    }
} 
