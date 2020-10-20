using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class PfCustomerRetailDetail
    {
        public String CostumeName { get; set; }
        public String SizeDisplayName { get; set; }
        public String PfCustomerID { get; set; }
        public String PfCustomerName { get; set; }

        public DateTime OrderCreateTime { get; set; }
        
        public int TotalCount { get; set; }

        public bool IsRetail { get; set; }

        public string SupplierName { get; set; }

        public int Year { get; set; }

        public string YearStr { get; set; }

        public string BrandName { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        /// <summary>
        /// 销售额
        /// </summary>
        public decimal RetailMoney { get; set; }

        /// <summary>
        /// 销售成本
        /// </summary>
        public decimal RetailCostPrice { get; set; }

        public int OrderCount { get; set; }

        public string OrderID { get; set; }

        public DateTime CreateTime { get; set; }

        public string EntryUserID { get; set; }

        public string OrderRemarks { get; set; }
    }
}
