using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class Brand : IComparable<Brand>
    { 


        //��д��CompareTo����������Id����
        public int CompareTo(Brand other)
        {
            if (null == other)
            {
                return 1;//��ֵ�Ƚϴ󣬷���1
            }
            return this.OrderNo.CompareTo(other.OrderNo);//����
        }

        //��дToString
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
