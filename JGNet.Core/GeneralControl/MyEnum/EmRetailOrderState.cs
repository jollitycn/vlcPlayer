using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet
{
    public enum EmRetailOrderState
    {
        [Description("所有")]
        All = -1,

        /// <summary>
        /// 待付款
        /// </summary>
        [Description("待付款")]
        WaitPay = 0,

        /// <summary>
        /// 待发货
        /// </summary>
        [Description("待发货")]
        WaitDelivery,

        /// <summary>
        /// 待收货
        /// </summary>
        [Description("已发货")]
        WaitSign,

        /// <summary>
        /// 待评价
        /// </summary>
        [Description("待评价")]
        WaitEvaluation,

        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        Finish,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancel,

        [Description("已关闭")]
        Closed
    }

    public enum CancelOrRefund
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel,

        /// <summary>
        /// 退货退款
        /// </summary>
        [Description("退货退款")]
        RefundReturn,

        /// <summary>
        /// 仅退款
        /// </summary>
        [Description("仅退款")]
        OnlyRefund
    }
    
    /// <summary>
    /// 退款状态
    /// </summary>
    public enum RefundStateEnum
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None = -1,

        /// <summary>
        /// 退款申请
        /// </summary>
        [Description("退款申请")]
        RefundApplication = 0,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("拒绝退款")]
        Refused = 1,

        /// <summary>
        /// 待填写物流
        /// </summary>
        [Description("待填写物流")]
        WriteExpress = 2,

        /// <summary>
        /// 退款中
        /// </summary>
        [Description("退款中")]
        Refunding = 3,

        /// <summary>
        /// 已退款
        /// </summary>
        [Description("已退款")]
        Refunded = 4,

        [Description("所有")]
        All
    }

    public enum RefundTrackType
    {
        /// <summary>
        /// 申请退款
        /// </summary>
        [Description("申请退款")]
        RefundApplication = 0,

        /// <summary>
        /// 拒绝退款
        /// </summary>
        [Description("拒绝退款")]
        Refused = 1,

        /// <summary>
        /// 同意退款
        /// </summary>
        [Description("同意退款")]
        Agree = 2,

        /// <summary>
        /// 确认退款
        /// </summary>
        [Description("确认退款")]
        Confirm = 3
    }
}
