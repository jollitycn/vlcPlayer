using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CheckStore
    {
        public Date Date { get; set; }

        public CheckStoreOrder CheckStoreOrder { get; set; }

        public List<CheckStoreDetail> CheckStoreDetailList { get; set; }
    }
}
