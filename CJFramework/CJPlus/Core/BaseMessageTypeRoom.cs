namespace CJPlus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public abstract class BaseMessageTypeRoom : IMessageTypeRoom
    {
        private int int_0 = 0;
        private int int_1 = 0;

        protected BaseMessageTypeRoom()
        {
        }

        public bool Contains(int messageType)
        {
            return ((this.int_0 <= messageType) && (this.int_1 >= messageType));
        }

        public virtual void Initialize()
        {
            this.int_1 = this.int_0;
            foreach (PropertyInfo info in base.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if ((info.CanWrite && (info.PropertyType == typeof(int))) && (info.Name != "StartKey"))
                {
                    int num2 = (int) info.GetValue(this, null);
                    int num3 = num2 + this.int_0;
                    if (num3 > this.int_1)
                    {
                        this.int_1 = num3;
                    }
                    info.SetValue(this, num3, null);
                }
            }
        }

        public int MaxKeyValue
        {
            get
            {
                return this.int_1;
            }
        }

        public virtual IList<int> PushKeyList
        {
            get
            {
                return new List<int>();
            }
        }

        public int StartKey
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }
    }
}

