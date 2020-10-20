using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum DistributorType
    {
        /// <summary>
        /// 批发
        /// </summary>
        [Description("批发")]
        Pf = 0,

        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        Member = 1
    }
}
