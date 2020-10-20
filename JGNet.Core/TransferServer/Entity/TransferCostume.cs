using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.TransferServer.Entity
{
    [Serializable]
    public class TransferCostume
    {
        public string CostumeID { get; set; }

        public decimal CostPrice { get; set; }

        public List<string> SizeNames { get; set; }
    }
}
