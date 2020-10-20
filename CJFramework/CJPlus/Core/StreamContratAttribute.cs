namespace CJPlus.Core
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple=false)]
    public class StreamContratAttribute : Attribute
    {
        private CJPlus.Core.SerializeStrategy serializeStrategy_0;

        public StreamContratAttribute()
        {
            this.serializeStrategy_0 = CJPlus.Core.SerializeStrategy.Property;
        }

        public StreamContratAttribute(CJPlus.Core.SerializeStrategy strategy)
        {
            this.serializeStrategy_0 = CJPlus.Core.SerializeStrategy.Property;
            this.serializeStrategy_0 = strategy;
        }

        public CJPlus.Core.SerializeStrategy SerializeStrategy
        {
            get
            {
                return this.serializeStrategy_0;
            }
            set
            {
                this.serializeStrategy_0 = value;
            }
        }
    }
}

