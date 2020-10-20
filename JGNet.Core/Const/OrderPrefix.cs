using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core
{
    /// <summary>
    /// 单据编号前缀。
    /// </summary>
    public static class OrderPrefix
    {
        /// <summary>
        /// 销售单。
        /// </summary>
        public const string RetailOrder = "X";

        /// <summary>
        /// 退货单。
        /// </summary>
        public const string RefundOrder = "T";

        /// <summary>
        /// 入库单
        /// </summary>
        public const string InboundOrder = "R";

        /// <summary>
        /// 差异单
        /// </summary>
        public const string DifferenceOrder = "Y";

        /// <summary>
        /// 补货申请单
        /// </summary>
        public const string ReplenishOrder = "B";

        /// <summary>
        /// 调拨单
        /// </summary>
        public const string AllocateOrder = "D";

        /// <summary>
        /// 出库单
        /// </summary>
        public const string OutboundOrder = "C";

        /// <summary>
        /// 充值
        /// </summary>
        public const string RechargeRecordOrder = "M";

        /// <summary>
        /// 促销单
        /// </summary>
        public const string SalesPromotion = "S";

        /// <summary>
        /// 采货单
        /// </summary>
        public const string PurchaseOrder = "A";

        /// <summary>
        /// 采购退货
        /// </summary>
        public const string ReturnOrder = "U";

        /// <summary>
        /// 盘点
        /// </summary>
        public const string CheckStoreOrder = "P";

        /// <summary>
        /// 报损单
        /// </summary>
        public const string ScrapOrder = "E";

        /// <summary>
        /// 串码调整
        /// </summary>
        public const string ConfusedStoreAdjustRecord = "F";

        /// <summary>
        /// 线上销售单
        /// </summary>
        public const string EmRetailOrder = "V";

        /// <summary>
        /// 线上退货单
        /// </summary>
        public const string EmRefundOrder = "H";

        /// <summary>
        /// 电子优惠券
        /// </summary>
        public const string GiftTicketID = "Q";

        /// <summary>
        /// 批发发货
        /// </summary>
        public const string PfDelivery = "PF";

        /// <summary>
        /// 批发退货
        /// </summary>
        public const string PfReturn = "PT";

        /// <summary>
        /// 批发订货单
        /// </summary>
        public const string PfCustomerOrder = "PD";

        /// <summary>
        /// 批发客户销售单
        /// </summary>
        public const string PfCustomerRetailOrder = "PX";

        /// <summary>
        /// 批发客户充值
        /// </summary>
        public const string PfCustomerRechargeRecord = "PC";

        /// <summary>
        /// 批发客户往来账
        /// </summary>
        public const string PfAccountRecordSource = "PM";

        /// <summary>
        /// 供应商往来账
        /// </summary>
        public const string SupplierAccountRecordSource = "AM";

        /// <summary>
        /// 自助续费
        /// </summary>
        public const string PaymentRecord = "XF";

        /// <summary>
        /// 后台自动编号标识
        /// </summary>
        public const int ShopCode4Admin = 0;
    }


    public class IDHelper
    {       
        /// <summary>
        /// 生成I
        /// </summary>
        /// <param name="orderPrefix">单据编号前缀</param>
        /// <param name="shopAutoCode">店铺代码</param>
        /// <returns></returns>
        public static string GetID(string orderPrefix, int shopAutoCode )
        {            
            return orderPrefix + shopAutoCode + CJBasic.Helpers.StringHelper.CreateDateTimeString();
        }

        /// <summary>
        /// 生成I
        /// </summary>
        /// <param name="orderPrefix">单据编号前缀</param>
        /// <param name="shopAutoCode">店铺代码</param>
        /// <returns></returns>
        public static string GetID(string orderPrefix, int shopAutoCode ,int num)
        {
            return orderPrefix + shopAutoCode + CJBasic.Helpers.StringHelper.CreateDateTimeString() + num.ToString();
        }
    }
}
