using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class UpdateCostumeStorePricePara
    {
        public List<string> shopIDs { get; set; }

        public string CostumeID { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }
    }
}
