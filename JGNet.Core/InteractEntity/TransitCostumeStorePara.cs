using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class TransitCostumeStorePara
    {
        public string ShopID { get; set; }

        public string CostumeID { get; set; }
    }

    public class TransitCostumeStore : BoundDetail
    {
        public string ShopID { get; set; }
    }
}
