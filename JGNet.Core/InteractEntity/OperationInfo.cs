using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class OperationInfo
    {
        /// <summary>
        /// 库存总数
        /// </summary>
        public int SummaryCount { get; set; }

        /// <summary>
        /// 库存货物总价值
        /// </summary>
        public decimal TotalPriceInStore { get; set; }

        /// <summary>
        /// 库存货物总成本
        /// </summary>
        public decimal TotalCostInStore { get; set; }

        /// <summary>
        /// 会员余额总和
        /// </summary>
        public decimal TotalMemberBalance { get; set; }

        /// <summary>
        /// 欠供应商的货款
        /// </summary>
        public decimal PaymentBalanceSum { get; set; }
    }
}
