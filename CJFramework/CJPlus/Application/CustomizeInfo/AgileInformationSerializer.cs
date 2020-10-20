namespace CJPlus.Application.CustomizeInfo
{
    using CJBasic.Helpers;
    using CJFramework.Engine.ContractStyle.Stream;
    using CJPlus.Serialization;
    using System;

    public static class AgileInformationSerializer
    {
        private static Type type_0 = typeof(BaseSerializeContract);

        public static T Deserialize<T>(byte[] buff, int startIndex) where T: new()
        {
            Type type = typeof(T);
            if (type.IsSubclassOf(type_0))
            {
                return (T) SerializeHelper.DeserializeBytes(buff, startIndex, buff.Length - startIndex);
            }
            return CompactPropertySerializer.Default.Deserialize<T>(buff, startIndex);
        }

        public static byte[] Serialize<T>(T contract)
        {
            BaseSerializeContract contract2 = contract as BaseSerializeContract;
            if (contract2 != null)
            {
                return SerializeHelper.SerializeObject(contract);
            }
            return CompactPropertySerializer.Default.Serialize<T>(contract);
        }
    }
}

