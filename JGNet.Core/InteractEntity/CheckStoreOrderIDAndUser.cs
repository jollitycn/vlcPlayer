using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CheckStoreOrderIDAndUser
    {
        public string CheckStoreOrderID { get; set; }

        public string CheckUserID { get; set; }

        public string Remarks { get; set; }
    }
}
