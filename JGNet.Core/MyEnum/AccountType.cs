using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    /// <summary>
    /// 改得和批发一样
    /// </summary>
    public enum AccountType
    {
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 进货(正)
        /// </summary>
        [Description("进货")]
        Purchase = 0,

        /// <summary>
        /// 退货（负）
        /// </summary>
        [Description("退货")]
        Return,

        /// <summary>
        /// 采购付款
        /// </summary>
        [Description("采购付款")]
        PurchaseCollection,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other
    }

    public enum PfAccountType
    {
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 批发收款
        /// </summary>
        [Description("批发收款")]
        Collection = 0,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other,

        /// <summary>
        /// 发货（正）
        /// </summary>
        [Description("发货")]
        Delivery,

        /// <summary>
        /// 退货（负）
        /// </summary>
        [Description("退货")]
        Return
    }

    public enum PfCustomerBalanceType
    {
        [Description("全部")]
        All = -1,

        /// <summary>
        /// 充值
        /// </summary>
        [Description("充值")]
        Recharge = 0,

        /// <summary>
        /// 订货单付款
        /// </summary>
        [Description("订货单付款")]
        PayPfCustomerOrder,

        /// <summary>
        /// 发货付款
        /// </summary>
        [Description("发货付款")]
        PayPfOrderDelivery,

        /// <summary>
        /// 退货退款
        /// </summary>
        [Description("退货退款")]
        PayPfOrderReturn,

        /// <summary>
        /// 后台记账收款
        /// </summary>
        [Description("后台记账收款")]
        AccountCollection,

        /// <summary>
        /// 后台记账其他
        /// </summary>
        [Description("后台记账其他")]
        AccountOther
    }
}
