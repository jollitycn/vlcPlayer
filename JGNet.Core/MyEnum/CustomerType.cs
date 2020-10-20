using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum CustomerType
    {
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 买断
        /// </summary>
        [Description("买断")]
        Buyout = 0,

        /// <summary>
        /// 代卖
        /// </summary>
        [Description("代卖")]
        AgentSell = 1
    }
}
