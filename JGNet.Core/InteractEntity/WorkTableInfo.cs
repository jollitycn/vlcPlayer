using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class WorkTableInfo
    {
        /// <summary>
        /// 差异单未确认数量
        /// </summary>
        public int DifferenceOrderConfirmedIsFalseCount { get; set; }

        /// <summary>
        /// 补货申请单申请已发货的数量
        /// </summary>
        public int ReplenishOrderStateIsDeliveryCount { get; set; }

        /// <summary>
        /// 补货申请单申请未发货的数量
        /// </summary>
        public int ReplenishOrderStateIsNotDeliveryCount { get; set; }

        /// <summary>
        /// 调拨单已发货的数量
        /// </summary>
        public int AllocateOrderStateIsDeliveryCount { get; set; }

        ///// <summary>
        ///// 库存是否锁定
        ///// </summary>
        //public bool CostumeStoreLocked { get; set; }

        /// <summary>
        /// 盘点单待审核的数量
        /// </summary>
        public int CheckStoreOrderStateIsPendingReviewCount { get; set; }

        /// <summary>
        /// 库存存在负数
        /// </summary>
        public bool IsCostumeStoreHaveNegative { get; set; }

        /// <summary>
        /// 盘点数量
        /// </summary>
        public int CheckStoreTaskCount { get; set; }

        /// <summary>
        /// 今日新增会员数
        /// </summary>
        public long TodayAddMemberCount { get; set; }

        /// <summary>
        /// 线上订单待发货数量
        /// </summary>
        public long EmRetailDeliveryCount { get; set; }

        /// <summary>
        /// 退款订单待处理数量
        /// </summary>
        public long EmRefundProcessingCount { get; set; }
    }
}
