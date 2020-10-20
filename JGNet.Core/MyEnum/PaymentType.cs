using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.MyEnum
{
    public enum PaymentType
    {
        /// <summary>
        /// 开户
        /// </summary>
        CreateBusinessAccount = 0,

        /// <summary>
        /// 续期
        /// </summary>
        Renewal = 1,

        /// <summary>
        /// 升级店铺数量
        /// </summary>
        AddShopCount = 2
    }
}
