using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class CostumeStoreChange
    {
        public List<CostumeStoreChangeInfo> CostumeStoreChangeInfos { get; set; }

        public CostumeStoreChangeInfo CostumeStoreChangeInfoSum { get; set; }
    }

    public class CostumeStoreChangeInfo
    {
        public int Date { get; set; }

        /// <summary>
        /// 进货
        /// </summary>
        public int In { get; set; }

        /// <summary>
        /// 转入
        /// </summary>
        public int Into { get; set; }

        /// <summary>
        /// 退货
        /// </summary>
        public int Return { get; set; }

        /// <summary>
        /// 转出
        /// </summary>
        public int TurnOut { get; set; }

        /// <summary>
        /// 销售
        /// </summary>
        public int Retail { get; set; }

        /// <summary>
        /// 报损
        /// </summary>
        public int Scrap { get; set; }

        /// <summary>
        /// 盈亏
        /// </summary>
        public int Profit { get; set; }

        /// <summary>
        /// 结存
        /// </summary>
        public int CostumeStoreCount { get; set; }
    }

    public class GetCostumeStoreChangePara
    {
        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 款号id
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string SizeName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
    }

    public class InReturnTrackChange
    {
        public List<PurchaseOrder> PurchaseOrders { get; set; }

        public PurchaseOrder PurchaseOrderSum { get; set; }
    }

    public class IntoTurnOutTrackChange
    {
        public List<AllocateOrder> AllocateOrders { get; set; }

        public AllocateOrder AllocateOrderSum { get; set; }
    }

    public class RetailTrackChange
    {
        public List<RetailOrder> RetailOrders { get; set; }

        public RetailOrder RetailOrderSum { get; set; }
    }

    public class ScrapTrackChange
    {
        public List<ScrapOrder> ScrapOrders { get; set; }

        public ScrapOrder ScrapOrderSum { get; set; }
    }

    public class ProfitTrackChange
    {
        public List<CheckStoreOrder> CheckStoreOrders { get; set; }

        public CheckStoreOrder CheckStoreOrderSum { get; set; }
    }
}
