using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum PfCustomerOrderState
    {
        [Description("全部")]
        All = -1,

        /// <summary>
        /// 待发货
        /// </summary>
        [Description("待发货")]
        WaitDelivery = 0,

        /// <summary>
        /// 部分发货
        /// </summary>
        [Description("部分发货")]
        PartDelivery = 1,

        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Finish = 2,

        /// <summary>
        /// 已作废
        /// </summary>
        [Description("已作废")]
        Invalid = 3
    }

    public enum StateStrInt
    {
        /// <summary>
        /// 已发货
        /// </summary>
        [Description("已发货")]
        Shipped = 0,

        /// <summary>
        /// 待发货
        /// </summary>
        [Description("待发货")]
        WaitDelivery = 1,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancel = 2
    }
}
