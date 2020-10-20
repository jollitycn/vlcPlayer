namespace CJPlus.Application.CustomizeInfo
{
    using System;
    using System.Reflection;

    public abstract class BaseInformationTypes
    {
        private int int_0 = 0;
        private int int_1 = 0;

        protected BaseInformationTypes()
        {
        }

        public bool Contains(int informationType)
        {
            return ((this.int_0 <= informationType) && (this.int_1 >= informationType));
        }

        public void Initialize()
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

        public void Initialize(int _startKey)
        {
            this.int_0 = _startKey;
            this.Initialize();
        }

        public int MaxKeyValue
        {
            get
            {
                return this.int_1;
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

