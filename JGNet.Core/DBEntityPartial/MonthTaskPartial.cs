using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{ 
	public partial class MonthTask
	{
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 店铺名称
        /// </summary>
        public String ShopName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 导购员
        /// </summary>
        public String GuideName { get; set; }

        public bool IsReadonly { get; set; }
    }
}
