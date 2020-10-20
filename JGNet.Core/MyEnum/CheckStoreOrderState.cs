using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace JGNet
{
    public enum CheckStoreOrderState
    {
        All = -1,

        /// <summary>
        /// 待审核
        /// </summary>
        [Description("待审核")]
        PendingReview = 0,

        /// <summary>
        /// 已审核
        /// </summary>
        [Description("已审核")]
        Approved=1,

        /// <summary>
        /// 已退回（无效）
        /// </summary>
        Canceled = 2,

        /// <summary>
        /// 已失效（无效）
        /// </summary>
        Expired = 3,

        /// <summary>
        /// 挂单
        /// </summary>
        [Description("挂单")]
        Suspend = 4,
        
        /// <summary>
        /// （无效）
        /// </summary>
        Checking = 5,

        /// <summary>
        /// 任务取消（无效）
        /// </summary>
        TaskIsCancel = 6,

        /// <summary>
        /// 冲单
        /// </summary>
        [Description("冲单")]
        OverrideOrder = 7,

        /// <summary>
        /// 子盘点
        /// </summary>
        [Description("子盘点")]
        ChildOrder = 8
    }
}
