using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class AllocateOutboundPara
    {
        /// <summary>
        /// 补货申请单id
        /// </summary>
        public string ReplenishOrderID { get; set; }

        public AllocateOrder AllocateOrder { get; set; }

        public OutboundOrder OutboundOrder { get; set; }

        public List<BoundDetail> OutboundDetailList { get; set; }
    }
}
