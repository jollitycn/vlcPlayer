using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public enum CashRecordFeeType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 上缴销售款
        /// </summary>
        [Description("上缴销售款")]
        Remittances = 0,

        /// <summary>
        /// 收入
        /// </summary>
        [Description("收入")]
        Income,

        /// <summary>
        /// 支出
        /// </summary>
        [Description("支出")]
        Spending
    }
}
