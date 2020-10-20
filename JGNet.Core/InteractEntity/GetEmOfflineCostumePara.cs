using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class GetEmOfflineCostumePara
    {
        public string IdOrName { get; set; }
        
        public int PageIndex { get; set; }
        
        public List<string> SupplierIDs { get; set; }

        public List<int> BrandIDs { get; set; }

        public List<int> BigClassIDs { get; set; }

        public List<string> Seasons { get; set; }

        public List<int> Years { get; set; }
    }
}
