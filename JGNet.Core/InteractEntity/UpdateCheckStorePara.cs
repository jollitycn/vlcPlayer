using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class UpdateCheckStorePara
    {
        public string CheckStoreOrderID { get; set; }

        public string OperatorUserID { get; set; }

        public string Remarks { get; set; }

        public List<CheckStoreDetail> CheckStoreDetails { get; set; }
    }
}
