using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class DistributorPage : BasePage
    {
        public List<Distributor> Distributors { get; set; }
    }

    public class GetDistributorPagePara : BasePagePara
    {
        public string IdOrName { get; set; }
    }
}
