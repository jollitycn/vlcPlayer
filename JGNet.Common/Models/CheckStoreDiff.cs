using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Common.Models
{
    public class CheckStoreDiff
    {
        public String CostumeID{ get; set; }
        public String CostumeName { get; set; }
        public String BrandName { get; set; }
        public String ColorName { get; set; }
        public String SizeName { get; set; }
        public int ChangeCount { get; set; }
        public int RealCount { get; set; }
        public int QuickCount { get; set; }
        public int DiffCount { get; set; }
    }
}
