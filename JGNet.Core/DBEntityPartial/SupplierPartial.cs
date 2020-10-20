using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class Supplier : IComparable<Supplier>
    {
        private List<Brand> brands = new List<Brand>();
        [CJPlus.Serialization.NotSerializedCompactlyAttribute]
        public List<Brand> Brands
        {
            get { return this.brands; }
            set { this.brands = value; }
        }

        public int CompareTo(Supplier other)
        {
            if (null == other)
            {
                return 1;
            }
            return this.OrderNo.CompareTo(other.OrderNo);
        }

        //重写ToString
      /*  public override string ToString()
        {
            return "ID:" + this.ID + "   Name:" + Name;
        }*/
    }
}
