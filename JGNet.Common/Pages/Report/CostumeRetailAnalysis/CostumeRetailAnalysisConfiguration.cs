using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Common
{
    public class CostumeRetailAnalysisConfiguration : CJBasic.Serialization.AgileConfiguration
    { 
        public List<String> Types{ get; set; }
    }
    public class CostumePfAnalysisConfiguration : CJBasic.Serialization.AgileConfiguration
    {
        public List<String> Types { get; set; }
    }
}
