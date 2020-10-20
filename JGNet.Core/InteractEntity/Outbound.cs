using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class Outbound
    {
        public OutboundOrder OutboundOrder { get; set; }

        public List<BoundDetail> OutboundDetails { get; set; }

        /// <summary>
        /// 原补货申请单id，OutboundOrder的SourceOrderID与该字段不用，则以SourceOrderID为补货申请id重做一笔补货申请单(没有重做功能)
        /// </summary>
        //public string ReplenishOrderId { get; set; }
    }
}
