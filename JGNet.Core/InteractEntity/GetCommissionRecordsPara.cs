using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetCommissionRecordsPara
    {
        public string DistributorID { get; set; }

        public Date StartDate { get; set; }

        public Date EndDate { get; set; }

        /// <summary>
        /// -1:所有
        /// </summary>
        public int Level { get; set; }
    }
}
