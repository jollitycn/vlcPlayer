using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public enum MemberSortType
    {
        /// <summary>
        /// 开卡时间
        /// </summary>
        CreatedTime = 0,

        /// <summary>
        /// 最后消费时间
        /// </summary>
        LastSpendTime = 1,

        /// <summary>
        /// 累计消费
        /// </summary>
        AccruedSpend = 2,

    }
}
