using CJBasic;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    public class UpdateSalesPromotionPara
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        public bool Enabled { get; set; }

        public string Remarks { get; set; }
    }
}
