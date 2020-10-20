using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum OnlineType
    {
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 零售
        /// </summary>
        [Description("零售")]
        Retail = 1,

        /// <summary>
        /// 批发
        /// </summary>
        [Description("批发")]
        Pf = 2
    }
}
