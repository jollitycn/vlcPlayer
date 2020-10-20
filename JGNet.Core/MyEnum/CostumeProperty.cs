using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum CostumeProperty
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 首单
        /// </summary>
        [Description("首单")]
        FirstOrder = 0,

        /// <summary>
        /// 追单
        /// </summary>
        [Description("追单")]
        PursuitOrder = 1,

        /// <summary>
        /// 买断
        /// </summary>
        [Description("买断")]
        Buyout = 2,

        /// <summary>
        /// 代卖
        /// </summary>
        [Description("代卖")]
        AgentSell = 3
    }
}
