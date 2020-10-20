using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class PfCustomerDetails
    {
        public Dictionary<PfOrder, List<PfCustomerDetail>> DeliveryDict { get; set; }

        public List<PfCustomerDetail> NotDeliverys { get; set; }

        public PfCustomerOrder PfCustomerOrder { get; set; }
    }
}
