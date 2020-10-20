using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Core.Dev.MyEnum
{
    /// <summary>
    /// 分组类型
    /// </summary>
    public enum GroupType
    {
        /// <summary>
        /// 店铺
        /// </summary>
        [Description("店铺")]
        Shop = 0,

        /// <summary>
        /// 大类
        /// </summary>
        [Description("大类")]
        BigClass = 1,

        /// <summary>
        /// 小类
        /// </summary>
        [Description("小类")]
        SmallClass = 2,

        /// <summary>
        /// 次小类
        /// </summary>
        [Description("次小类")]
        SubSmallClass = 5,

        /// <summary>
        /// 品牌
        /// </summary>
        [Description("品牌")]
        Brand = 3,

        /// <summary>
        /// 供应商
        /// </summary>
        [Description("供应商")]
        Supplier = 4,

    }
}
