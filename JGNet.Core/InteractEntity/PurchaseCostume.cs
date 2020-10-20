using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class PurchaseCostume
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        public InboundOrder InboundOrder { get; set; }

        public List<BoundDetail> InboundDetailList { get; set; }

        /// <summary>
        /// 是否自动入库
        /// </summary>
        public bool IsAutoAllocateIn { get; set; }
    }
}
