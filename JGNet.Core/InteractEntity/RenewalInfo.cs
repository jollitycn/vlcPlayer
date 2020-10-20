using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class RenewalInfo
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public DateTime ExpiredDate { get; set; }

        public List<RenewalDetail> Details { get; set; }
    }

    public class RenewalDetail
    {
        public decimal Money { get; set; }

        public string TimeStr { get; set; }

        public DateTime ExpiredDate { get; set; }
    }
}
