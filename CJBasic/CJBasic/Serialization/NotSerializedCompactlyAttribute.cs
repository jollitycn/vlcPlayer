namespace CJBasic.Serialization
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NotSerializedCompactlyAttribute : Attribute
    {
    }
}

