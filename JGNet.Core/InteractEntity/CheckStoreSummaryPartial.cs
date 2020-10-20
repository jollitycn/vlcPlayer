using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class CheckStoreSummary
    {
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String CostumeName { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public String ShopName { get; set; }

        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal CostPrice { get; set; }
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public decimal Price { get; set; }

        public List<string> CheckStoreOrderIDs { get; set; }
    }
}
