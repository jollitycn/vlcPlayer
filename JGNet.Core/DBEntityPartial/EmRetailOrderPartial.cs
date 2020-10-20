using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class EmRetailOrder
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 总数量
        /// </summary>
        public int SaleCount { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        

        /// <summary>
        /// 订单状态
        /// </summary>
        public EmRetailOrderState OrderState
        {
            get
            {
                return  (EmRetailOrderState)this.State;
            }
        }
        //[CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 退款状态
        /// </summary>
        public RefundStateEnum RefundStateEnum { get; set; }


        public static string GetRefundState(RefundStateEnum refundState)
        {
            return EnumHelper.GetDescription(refundState);
        }
        public static String GetOrderState(EmRetailOrderState orderState)
        {
            return EnumHelper.GetDescription(orderState);
        }

        public String OrderStateName
        {
            get
            {
                return GetOrderState(this.OrderState);
            }
        }

        /// <summary>
        /// 退款状态
        /// </summary>
        public String RefundStateName
        {
            get
            {
                return GetRefundState(this.RefundStateEnum);
            }
        }

        public decimal TotalEmOnlinePrice { get; set; }

        public List<SimpleEmRetailDetail> SimpleEmRetailDetails { get; set; }

        public string ShopName { get; set; }

        public int OrderProcessIndex { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }

    [Serializable]
    public class SimpleEmRetailDetail
    {
        public string CostumeID { get; set; }

        public string CostumeName { get; set; }

        public string PhotoThumbnailUrl { get; set; }

        public string ColorName { get; set; }

        /// <summary>
        /// 用于显示的尺码名称
        /// </summary>
        public string DisplaySizeName { get; set; }


        public string SizeName { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyCount { get; set; }

        /// <summary>
        /// 线上价
        /// </summary>
        public decimal EmOnlinePrice { get; set; }

        /// <summary>
        /// 小计金额
        /// </summary>
        public decimal SumMoney { get; set; }
    }
}
