using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetPfCustomerPagePara : BasePagePara
    {
        public string IdOrName { get; set; }
    }

    public class PfCustomerPage : BasePage
    {
        public List<PfCustomer> PfCustomers { get; set; }
    }

    public class GetPfCustomerPage4DistributorPara : BasePagePara
    {
        public string DistributorID { get; set; }
    }
}
