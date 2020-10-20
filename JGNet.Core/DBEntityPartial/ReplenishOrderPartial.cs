using CJBasic.Helpers;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class ReplenishOrder: IStatisticabled

    {

        public string SumMoney {
            get {
                return Convert.ToString( this.TotalPrice * this.TotalCount);
            }
        }
        //[CJPlus.Serialization.NotSerializedCompactlyAttribute]
        //public String Operation { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StateName
        {
            get
            {
                if(this.IsStatistics)
                {
                    return "";
                }
                return JGNet.Core.Tools.EnumHelper.GetDescription((ReplenishOrderState)this.State);
            }
        }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 店名
        /// </summary>
        public String ShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 开单员姓名
        /// </summary>
        public string GuideName { get; set; }


        /// <summary>
        /// 能否收货名称  （不能收货为string.Empty，可以收货为“收货”）
        /// </summary>
        public string ReceiptDetailName
        {
            get
            {
                return string.Empty;
            }
        }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool IsStatistics { get; set; }
      

        /// <summary>
        /// 该单是否重做
        /// </summary>
     public bool IsRedo { get; set; }
    }
}
