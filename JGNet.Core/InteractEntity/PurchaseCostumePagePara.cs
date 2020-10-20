using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class PurchaseCostumePagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string PurchaseOrderID { get; set; }

        /// <summary>
        /// 是否根据编号模糊查询
        /// </summary>
        public bool IsLikeSearch { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        public string SupplierID { get; set; }        

        /// <summary>
        /// 店铺id
        /// </summary>
        public string ShopID { get; set; }

        /// <summary>
        /// 是否仅显示本店的商品
        /// </summary>
        public bool OnlyShowOwnShop { get; set; }

        /// <summary>
        /// 是否开启限制日期查询
        /// </summary>
        public bool IsOpenDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }
        
        public PurchaseQueryType PurchaseQueryType { get; set; }

        public PurchaseType PurchaseType { get; set; }
    }

    public enum PurchaseQueryType
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = 0,

        /// <summary>
        /// 已采购
        /// </summary>
        Purchase,

        /// <summary>
        /// 挂单
        /// </summary>
        HangUp,

        /// <summary>
        /// 已冲单
        /// </summary>
        Cancel
    }

    public enum PurchaseType
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = 0,

        /// <summary>
        /// 采购进货
        /// </summary>
        Purchase = 1,

        /// <summary>
        /// 采购退货
        /// </summary>
        Refund = 2,
    }

    [Serializable]
    public class PurchaseCostumePage : BasePage
    {
        public List<PurchaseOrder> PurchaseOrderList { get; set; }
         

        public PurchaseOrder PurchaseOrderSum { get; set; }

    }
}
