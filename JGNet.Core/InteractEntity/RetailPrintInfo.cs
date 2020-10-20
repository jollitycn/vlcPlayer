using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class RetailPrintInfo
    {
        public Shop Shop { get; set; }

        public RetailOrder RetailOrder { get; set; }

        public List<RetailDetail> RetailDetails { get; set; }

        public Member Member { get; set; }

        public string AdditionalText { get; set; }
    }
}
