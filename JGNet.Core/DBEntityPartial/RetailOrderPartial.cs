using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class RetailOrder
    {
        public decimal RetailMoneyDeductedByTicket { get; set; }

        public string OrderType
        {
            get
            {
                return this.IsRefundOrder ? "退货" : "销售";
            }
        }

        /// <summary>
        /// 调拨状态名称
        /// </summary>
        public string StateName
        {
            get {
                String value = "";

                if (this.IsCancel)
                {
                    value = "已冲单";
                }
                //else if (!String.IsNullOrEmpty(this.RefundOrderID))
                //{
                //    value = "已退货";
                //}
                else
                {
                    value = "正常";
                }
                return value;
            }
        }
        /// <summary>
        /// 店铺名称
        /// </summary
        public string ShopName { get; set; }

        /// <summary>
        /// 导购员名称
        /// </summary>
        public string GuideName { get; set; } 

        public int DateInt { get { return new Date(this.CreateTime).ToDateInteger(); } }

        /// <summary>
        /// 制单人
        /// </summary>
        public string EntryUserName { get; set; }
        
        /// <summary>
        /// 界面现金展示
        /// </summary>
        public decimal ShowCash
        {
            get;set;
        }
    }
}
