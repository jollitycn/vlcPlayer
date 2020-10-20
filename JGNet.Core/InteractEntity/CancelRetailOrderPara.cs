using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CancelRetailOrderPara
    {
        public string RetailOrderID { get; set; }

        public string CancelGuideID { get; set; }

        public bool isRefundOrder { get; set; }
    }
}
