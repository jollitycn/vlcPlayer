using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    public class GetBarCodesPara
    {
        public string CostumeID { get; set; }

        public string BarCodeValue { get; set; }

        public BarCodeTemplateEnum BarCodeTemplateEnum { get; set; }
    }
}
