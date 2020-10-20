using CJBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class EmOrderPage : BasePage
    {
        public List<EmRetailOrder> ResultList { get; set; }
    }

    public class EmRefundOrderPage : BasePage
    {
        public List<EmRefundOrder> ResultList { get; set; }
    }

    /// <summary>
    /// 订单管理
    /// </summary>
    public class GetEmOrderPagePara : BasePagePara
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 收货人手机号、姓名 精确
        /// </summary>
        public string MemberPhoneOrName { get; set; }
        /// <summary>
        /// 商品款号、名称 精确
        /// </summary>
        public string CostumeIDOrName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public EmRetailOrderState OrderState { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public RefundStatus RefundStatus { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public Date StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public Date EndDate { get; set; }
    }

    public enum RefundStatus
    {
        /// <summary>
        /// 暂不选择
        /// </summary>
        [Description("暂不选择")]
        NotSelect = 0,

        /// <summary>
        /// 退款中+退款成功
        /// </summary>
        [Description("退款中+退款成功")]
        RefundingRefundSuccess,

        /// <summary>
        /// 退款中
        /// </summary>
        [Description("退款中")]
        Refunding,

        /// <summary>
        /// 退款成功
        /// </summary>
        [Description("退款成功")]
        RefundSuccess
    }

    [Serializable]
    public class OrderCount
    {
        /// <summary>
        /// 待付款
        /// </summary>
        public int WaitPayCount { get; set; }

        /// <summary>
        /// 待发货
        /// </summary>
        public int WaitDeliveryCount { get; set; }

        /// <summary>
        /// 待收货
        /// </summary>
        public int WaitSignCount { get; set; }

        /// <summary>
        /// 待评价
        /// </summary>
        public int WaitEvaluationCount { get; set; }

        /// <summary>
        /// 退货/售后
        /// </summary>
        public int RefundCount { get; set; }
    }
}
