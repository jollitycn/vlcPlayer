using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
	public partial class InventoryDayReport
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String CostumeName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        /// <summary>
        /// 入库店铺名称
        /// </summary>
        public string  ShopName { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public bool IsSetData { get; set; }

        public string BigClass { get; set; }

        public int ClassID { get; set; }
    }
}
