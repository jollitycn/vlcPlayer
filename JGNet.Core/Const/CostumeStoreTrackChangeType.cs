using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Const
{
    public static class CostumeStoreTrackChangeType
    {
        public const string Retail = "销售";

        public const string Refund = "退货";

        public const string ReplenishOutbound = "补货申请出库";

        public const string ReplenishInbound = "补货申请入库";

        public const string AllocateOutbound = "调拨出库";

        public const string AllocateInbound = "调拨入库";

        public const string CheckStore = "盘点";

        public const string PurchaseInbound = "采购进货";

        public const string ReturnOutbound = "采购退货";

        public const string DifferenceOrderConfirmed = "差异单确认";

        public const string ScrapOutbound = "报损出库";

        public const string OverrideAllocateOrder = "调拨冲单";

        public const string OverrideReplenishOrder = "补货冲单";

        public const string CancelRetailOrder = "销售冲单";

        public const string ConfusedStoreAdjust = "串码调整";

        public const string CancelRefundOrder = "退货冲单";

        public const string PfDelivery = "批发发货";

        public const string PfReturn = "批发退货";
    }
}
