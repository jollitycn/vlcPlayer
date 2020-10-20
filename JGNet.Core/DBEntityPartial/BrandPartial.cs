using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class Brand : IComparable<Brand>
    { 


        //重写的CompareTo方法，根据Id排序
        public int CompareTo(Brand other)
        {
            if (null == other)
            {
                return 1;//空值比较大，返回1
            }
            return this.OrderNo.CompareTo(other.OrderNo);//升序
        }

        //重写ToString
        public override string ToString()
        {
            return "AutoID:" + AutoID + "   Name:" + Name;
        }
        private bool _emable = false;
        public bool IsEnable
        {
            get {
              
                return _emable; }

            set {
                _emable = value;
            }

        }

    }
}
