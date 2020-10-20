using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public enum AllocateType
    {
        /// <summary>
        /// 铺货
        /// </summary>
        Distribution=0,

        /// <summary>
        /// 退货
        /// </summary>
        Return=1,

        /// <summary>
        /// 店间调拨
        /// </summary>
        Allocate=2
    }
}
