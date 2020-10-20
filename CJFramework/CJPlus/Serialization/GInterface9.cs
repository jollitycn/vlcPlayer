namespace CJPlus.Serialization
{
    using System;

    public interface GInterface9
    {
        T Deserialize<T>(byte[] buff, int startIndex) where T: new();
        byte[] Serialize<T>(T obj);
        byte[] Serialize(Type type, object obj);
    }
}

