using CJPlus.Serialization;
using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public static class SerializeHelper
    {
        public static byte[] IntToByteArray(int result)
        {
            return BitConverter.GetBytes(result);
        }

        public static byte[] StringToByteArray(string result)
        {
            return Encoding.UTF8.GetBytes(result);
        }

        public static string ByteArrayToString(byte[] result)
        {
            return Encoding.UTF8.GetString(result);
        }

        public static int ByteArrayToInt(byte[] result)
        {
            return BitConverter.ToInt32(result, 0);
        }

        public static byte[] ResultToSerialize<T>(T t)
        {
            return CompactPropertySerializer.Default.Serialize(t);
        }

    }
}
