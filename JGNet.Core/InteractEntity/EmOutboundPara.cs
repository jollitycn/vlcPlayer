using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class EmOutboundPara
    {
        /// <summary>
        /// 选择发货店铺
        /// </summary>
        public string ShopID { get; set; }

        public string EmRetailOrderID { get; set; }

        public string ExpressCompany { get; set; }

        public string ExpressOrderID { get; set; }
    }
}
