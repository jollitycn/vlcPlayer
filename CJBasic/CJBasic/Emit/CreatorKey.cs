namespace CJBasic.Emit
{
    using System;

    internal class CreatorKey
    {
        private Type[] paramTypeArray;
        private Type targetType;

        public CreatorKey()
        {
        }

        public CreatorKey(Type type, Type[] paraTypeAry)
        {
            this.targetType = type;
            this.paramTypeArray = paraTypeAry;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(CreatorKey))
            {
                return false;
            }
            CreatorKey key = (CreatorKey) obj;
            if (key.targetType != this.targetType)
            {
                return false;
            }
            if ((key.paramTypeArray == null) && (this.paramTypeArray != null))
            {
                return false;
            }
            if ((key.paramTypeArray != null) && (this.paramTypeArray == null))
            {
                return false;
            }
            if (key.paramTypeArray.Length != this.paramTypeArray.Length)
            {
                return false;
            }
            for (int i = 0; i < this.paramTypeArray.Length; i++)
            {
                if (this.paramTypeArray[i] != key.paramTypeArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            string str = this.targetType.ToString();
            if (this.paramTypeArray != null)
            {
                for (int i = 0; i < this.paramTypeArray.Length; i++)
                {
                    str = str + "_" + this.paramTypeArray[i].ToString();
                }
            }
            return str.GetHashCode();
        }

        public Type[] ParamTypeArray
        {
            get
            {
                return this.paramTypeArray;
            }
            set
            {
                this.paramTypeArray = value;
            }
        }

        public Type TargetType
        {
            get
            {
                return this.targetType;
            }
            set
            {
                this.targetType = value;
            }
        }
    }
}

