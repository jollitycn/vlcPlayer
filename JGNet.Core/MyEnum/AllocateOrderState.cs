using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public enum AllocateOrderState
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = -100,

        /// <summary>
        /// 已发货
        /// </summary>
        [Description("已发货")]
        Delivery = 0,

        /// <summary>
        /// 已收货
        /// </summary>
        [Description("已收货")]
        Receipt = 1,

        /// <summary>
        /// 冲单
        /// </summary>
        [Description("已冲单")]
        OverrideOrder = 2,

        /// <summary>
        /// 挂单
        /// </summary>
        [Description("挂单")]
        HangUp = 3,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 4
    }
}
