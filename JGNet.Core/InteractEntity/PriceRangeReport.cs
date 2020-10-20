using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PriceRangeReport
    {
        public string ShopID { get; set; }

        public int StartMoney { get; set; }
        public string ShopName { get; set; }
        public string RangeName { get { return StartMoney + " - " + EndMoney; } }

        public int EndMoney { get; set; }

        public int Count { get; set; }

        public decimal CountRate { get; set; }

        public decimal Money { get; set; }

        public decimal MoenyRate { get; set; }
    }

    public class GetPriceRangeReportsPara
    {
        public string ShopId { get; set; }

        public int Range { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public bool IsGetGeneralStore { get; set; }
    }

    public class GetShopPriceRangeReportPara : GetPriceRangeReportsPara
    {
        public int StartMoney { get; set; }
    }
}
