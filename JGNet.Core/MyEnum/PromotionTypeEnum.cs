using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public enum PromotionTypeEnum
    {

        /// <summary>
        /// 满减
        /// </summary>
        [Description("满减")]
        MJ = 0,

        /// <summary>
        /// 折扣
        /// </summary>
        [Description("折扣")]
        Discount,

        /// <summary>
        /// 一口价
        /// </summary>
        [Description("一口价")]
        YKJ,

        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        Null
    }

    public enum SalesPromotionState
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All,

        /// <summary>
        /// 进行中
        /// </summary>
        [Description("进行中")]
        Start,

        /// <summary>
        /// 未开始
        /// </summary>
        [Description("未开始")]
        NotStart,

        /// <summary>
        /// 已结束
        /// </summary>
        [Description("已结束")]
        End,

        /// <summary>
        /// 已撤销
        /// </summary>
        [Description("已撤销")]
        Invalid
    }
}
