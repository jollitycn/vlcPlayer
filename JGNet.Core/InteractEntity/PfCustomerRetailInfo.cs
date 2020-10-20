using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfCustomerRetailInfo
    {
        public PfCustomerRetailOrder PfCustomerRetailOrder { get; set; }

        public List<PfCustomerRetailDetail> PfCustomerRetailDetails { get; set; }
    }
}
