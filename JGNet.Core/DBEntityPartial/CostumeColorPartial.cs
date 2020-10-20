using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class CostumeColor : IComparable<CostumeColor>
    {
        public int CompareTo(CostumeColor other)
        {
            if (null == other)
            {
                return 1;
            }
            return this.FirstCharSpell.CompareTo(other.FirstCharSpell);
        }

        //重写ToString
        public override string ToString()
        {
            return "ID:" + this.ID + "   Name:" + Name;
        }
    }
}
