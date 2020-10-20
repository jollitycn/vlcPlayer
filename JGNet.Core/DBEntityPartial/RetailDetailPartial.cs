using JGNet.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class RetailDetail
    {
        public string MemberID { get; set; }

        public string GuideName { get; set; }
        
        public string ShopName { get; set; }

        public string SupplierID { get; set; }

        public int BrandID { get; set; }

        public string SupplierName { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        public int StartCount { get; set; }

        public int EndCount { get; set; }
        
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String MatchGiftTickets { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public List<RetailDetail> SingleRetailDetails { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CostumeName { get; set; }

        public Costume Costume { get; set; }

        public String SizeDisplayName { get; set; }

        /// <summary>
        /// 是否允许修改折扣
        /// </summary>
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool AllowReviseDiscount { get; set; }

        private bool m_IsRefund = true;
        /// <summary>
        /// 是否退货
        /// </summary>
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool IsRefund
        {
            get
            {
                return this.m_IsRefund;
            }
            set
            {
                this.m_IsRefund = value;
            }
        }

        /// <summary>
        /// 是否使用优惠券
        /// </summary>
        public bool IsUseTickets { get; set; }

        /// <summary>
        /// 是否在白名单中
        /// </summary>
        public bool CanUseTickets { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public int RefundCount { get; set; }

        public string DisplaySizeName(SizeGroup sizeGroup)
        {
            return CostumeStoreHelper.GetCostumeSizeName(this.SizeName, sizeGroup);
        }

        public String EmThumbnail { get; set; }
        public String EmTitle { get; set; }

        /// <summary>
        /// 优惠券抵用到的金额
        /// 
        /// </summary>
        public Decimal GiftTicketDenomination { get; set; }

        public int Year { get; set; }

        public string YearStr { get; set; }

        public bool EmOnline { get; set; }

        public string ShopID { get; set; }

        public bool IsRefundOrder { get; set; }

        public decimal TotalMoneyReceivedActual { get; set; }

        public int ClassID { get; set; }

        public int OrderCount { get; set; }

        public string OrderID { get; set; }

        public DateTime CreateTime { get; set; }

        public string EntryUserID { get; set; }

        public string OrderRemarks { get; set; }

        public int PrintAutoID { get; set; }

        public bool IsCancel { get; set; }
    }
}
