using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class AllocateOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string AllocateOrderID { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 发货店铺ID
        /// </summary>
        public string SourceShopID { get; set; }

        /// <summary>
        /// 收货店铺ID
        /// </summary>
        public string DestShopID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public AllocateOrderState AllocateOrderState { get; set; }

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
        
    }
    
    public class GetAllocateOrdersPara : BasePagePara
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string AllocateOrderID { get; set; }

        /// <summary>
        /// 模糊查询款号
        /// </summary>
        public bool IsLike { get; set; }

        /// <summary>
        /// 款号
        /// </summary>
        public string CostumeID { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public AllocateOrderType Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public AllocateOrderState AllocateOrderState { get; set; }

        /// <summary>
        /// 收货状态
        /// </summary>
        public ReceiptState ReceiptState { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public Date StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public Date EndDate { get; set; }

        /// <summary>
        /// 是否仅显示本店的商品
        /// </summary>
        public bool OnlyShowOwnShop { get; set; }

        /// <summary>
        /// 锁定本店
        /// </summary>
        public bool LockShop { get; set; }

        /// <summary>
        /// 发货店铺id
        /// </summary>
        public string SourceShopID { get; set; }

        /// <summary>
        /// 收货店铺id
        /// </summary>
        public string DestShopID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }

    public enum ReceiptState
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 待收货
        /// </summary>
        [Description("待收货")]
        WaitReceipt = 1,

        /// <summary>
        /// 已收货
        /// </summary>
        [Description("已收货")]
        Received = 2
    }

    public enum AllocateOrderType
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        [Description("所有")]
        All = 0,

        /// <summary>
        /// 调拨入库
        /// </summary>
        [Description("调拨入库")]
        In = 1,

        /// <summary>
        /// 调拨出库
        /// </summary>
        [Description("调拨出库")]
        Out = 2
    }

    [Serializable]
    public class AllocateOrderPage : BasePage
    {
        public List<AllocateOrder> AllocateOrderList { get; set; }
         
        public AllocateOrder AllocateOrderSum { get; set; }
    }
}
