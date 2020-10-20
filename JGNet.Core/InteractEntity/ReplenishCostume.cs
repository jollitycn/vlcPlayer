using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class ReplenishCostume
    {
        public ReplenishOrder ReplenishOrder { get; set; }

        public List<ReplenishDetail> ReplenishDetailList { get; set; }
    }
}
