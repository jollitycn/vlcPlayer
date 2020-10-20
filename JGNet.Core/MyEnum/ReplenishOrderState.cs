using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public enum ReplenishOrderState
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = -100,

        /// <summary>
        /// 未处理
        /// </summary>
        [Description("未处理")]
        NotProcessing = 0,

        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Processing,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        Refused,

        /// <summary>
        /// 已取消 （负数无法转byte）
        /// </summary>
        [Description("已取消")]
        Cancel,

        /// <summary>
        /// 冲单
        /// </summary>
        [Description("冲单")]
        OverrideOrder,

        /// <summary>
        /// 挂单
        /// </summary>
        [Description("挂单")]
        HangUp
    }
}
