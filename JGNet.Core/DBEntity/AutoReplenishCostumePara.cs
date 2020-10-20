using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.DBEntity
{
    public class AutoReplenishCostumePara
    {
        public string ShopID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }
    }
}
