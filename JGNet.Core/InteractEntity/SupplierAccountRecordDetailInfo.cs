using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class SupplierAccountRecordDetailInfo
    {
        /// <summary>
        /// 总库存数
        /// </summary>
        public int SummaryCount { get; set; }

        /// <summary>
        /// 总成本价
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// 总吊牌价
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
