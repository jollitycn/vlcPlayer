using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public enum CostumeSortType
    {
        /// <summary>
        /// 新品：上架时间倒序。
        /// </summary>
        New = 0,

        /// <summary>
        /// 销量：销量降序。
        /// </summary>
        QuantityOfSale,

        /// <summary>
        /// 价格：升序
        /// </summary>
        EmOnlinePriceAsc,

        /// <summary>
        /// 价格：降序
        /// </summary>
        EmOnlinePriceDesc
    }
}
