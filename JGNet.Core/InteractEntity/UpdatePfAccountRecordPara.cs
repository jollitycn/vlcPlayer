using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class UpdatePfAccountRecordPara
    {
        public int ID { get; set; }

        public string PfCustomerID { get; set; }

        public PfAccountType PfAccountType { get; set; }

        /// <summary>
        /// 收款方式
        /// </summary>
        public PfAccountRecordType PayType { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal AccountMoney { get; set; }

        public string Remarks { get; set; }
    }

    public class UpdateSupplierAccountRecordPara
    {
        public int ID { get; set; }

        public string SupplierID { get; set; }

        public AccountType AccountType { get; set; }

        public SupplierAccountRecordPayType PayType { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal AccountMoney { get; set; }

        public string Remarks { get; set; }
    }

    public enum SupplierAccountRecordPayType
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
        Other = 4

    }
}
