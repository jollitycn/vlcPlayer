using CJBasic;
using CJBasic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetRetailSummaryPara
    {
        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }

    public class RetailSummary
    {
        public List<RetailSummaryInfo> RetailSummaryInfos { get; set; }

        public RetailSummaryInfo Sum { get; set; }
    }

    public class RetailSummaryInfo
    {
        public int Date { get; set; }

        public decimal MoneyWeiXin { get; set; }

        public decimal MoneyAlipay { get; set; }

        public decimal MoneyCash { get; set; }

        public decimal MoneyCash2 { get; set; }

        public decimal MoneyBankCard { get; set; }

        public decimal MoneyChange { get; set; }

        public decimal MoneyVipCard { get; set; }

        public decimal MoneyOther { get; set; }

        public decimal MoneyIntegration { get; set; }

        public decimal MoneyDeductedByTicket { get; set; }
        
        /// <summary>
        /// 界面现金展示
        /// </summary>
        public decimal ShowCash
        {
            get;set;
        }
        
        public decimal Sum
        {
            get;set;
        }
    }
}
