namespace CJFramework.Engine.ContractStyle.Stream
{
    using CJBasic.Helpers;
    using System;

    [Serializable]
    public abstract class BaseSerializeContract : ICloneable
    {
        protected BaseSerializeContract()
        {
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        internal static TBody smethod_0<TBody>(MessageHandler class114_0)
        {
            try
            {
                return (TBody) SerializeHelper.DeserializeBytes(class114_0.Body.Data, class114_0.Body.Offset, class114_0.method_0().imethod_5());
            }
            catch (Exception)
            {
                return default(TBody);
            }
        }

        public byte[] ToStream()
        {
            return SerializeHelper.SerializeObject(this);
        }
    }
}

