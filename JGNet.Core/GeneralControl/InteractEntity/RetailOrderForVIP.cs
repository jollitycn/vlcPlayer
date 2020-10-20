using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Dev.InteractEntity
{
    /// <summary>
    /// VIP客户购买统计 分组统计
    /// </summary>
    [Serializable]
    public class RetailOrderForVIP
    {
        public string MemeberID { get; set; }

        public string MemberName { get; set; }

        /// <summary>
        /// 会员头像地址
        /// </summary>
        public string HeadImageUrl { get; set; }

        /// <summary>
        /// 总消费金额
        /// </summary>
        public decimal TotalConsumeMoney { get; set; }

        public decimal MoneyIntegration { get; set; }

        /// <summary>
        /// 总单数
        /// </summary>
        public int TotalOrderCount { get; set; }

        /// <summary>
        /// 总件数
        /// </summary>
        public int TotalCount { get; set; }
    }
    [Serializable]
    public class RetailOrderForVIPPage
    {
        public RetailOrderForVIP RetailOrderForVIPSum { get; set; }

        public List<RetailOrderForVIP> RetailOrderForVIPList { get; set; }
        
        public int VipCount { get; set; }
    }

    /// <summary>
    /// VIP消费记录列表按日期统计 （购买、退货记录）
    /// </summary>
    [Serializable] 
    public class VIPConsumeRecordListByDate
    {
        public int ConsumeDate { get; set; }
        public List<VIPConsumeRecord> VIPConsumeRecordList { get; set; }
    }

    /// <summary>
    /// VIP消费记录 （购买、退货记录）
    /// </summary>
   [Serializable]   
    public class VIPConsumeRecord
    {

        public string OrderTypeName { get; set; }

        public string ShopID { get; set; }

        public string ShopName { get; set; }

        public string GuideID { get; set; }

        public string GuideName { get; set; }
        public string OrderID { get; set; }

        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string CostumeImageUrl { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public int BuyCount { get; set; }

        public decimal Discount { get; set; }

        public decimal SumMoney { get; set; }

    }

    public enum OrderType
    {
        /// <summary>
        /// 销售
        /// </summary>
        Retail = 0,
        /// <summary>
        /// 退货
        /// </summary>
        Refund
    }

    /// <summary>
    /// 衣柜数据
    /// </summary>
    [Serializable] 
    public class WardrobeData
    {
        public string BuyDate { get; set; }

        public string CostumeID { get; set; }

        public decimal Price { get; set; }

        public string CostumeName { get; set; }

        public string CostumeImageUrl { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }

        public int BuyCount { get; set; }
    }
}
