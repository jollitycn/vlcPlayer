namespace CJPlus.Serialization
{
    using System;

    [Serializable]
    public class SerializeException : Exception
    {
        public SerializeException()
        {
        }

        public SerializeException(string msg) : base(msg)
        {
        }

        public SerializeException(string msg, Exception ee) : base(msg, ee)
        {
        }
    }
}

