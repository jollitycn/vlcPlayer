using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class ReturnCostume
    {
        public PurchaseOrder ReturnOrder { get; set; }

        public OutboundOrder OutboundOrder { get; set; }

        public List<BoundDetail> OutboundDetailList { get; set; }
    }
}
