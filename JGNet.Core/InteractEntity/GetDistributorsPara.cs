using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetDistributorsPara : BasePagePara
    {
        public string DistributorIDOrName { get; set; }

        public Date StartTime { get; set; }

        public Date EndTime { get; set; }
    }

    public class DistributorCommissionPage : BasePage
    {
        public List<Distributor> Distributors { get; set; }

        public Distributor Sum { get; set; }
    }
}
