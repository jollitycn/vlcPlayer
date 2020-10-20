using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CostumeClassInfo
    {
        public int ID { get; set; }

        public string Name { get { return this.BigClass; } }//小程序用于组件显示字段

        public string BigClass { get; set; }

        public List<SmallClass> SmallClass { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }
    }

    [Serializable]
    public class SmallClass
    {
        public int ID { get; set; }

        public string BigClass { get; set; }

        public string SmallClassStr { get; set; }

        public List<SubSmallClass> SubSmallClass { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }
    }

    [Serializable]
    public class SubSmallClass
    {
        public int ID { get; set; }

        public string BigClass { get; set; }

        public string SmallClass { get; set; }

        public string SubSmallClassStr { get; set; }

        public int OrderNo { get; set; }

        public string ClassCode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}^{1}^{2}", this.SubSmallClassStr, this.ClassCode, this.OrderNo);
        }
    }
}
