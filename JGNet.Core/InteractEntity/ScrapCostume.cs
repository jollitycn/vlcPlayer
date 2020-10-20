using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class ScrapCostume
    {
        public ScrapOrder ScrapOrder { get; set; }

        public List<ScrapDetail> ScrapDetails { get; set; }

        public OutboundOrder OutboundOrder { get; set; }

        public List<BoundDetail> OutboundDetails { get; set; }
    }
}
