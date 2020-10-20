namespace CJBasic.Helpers
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class EnumHelper
    {
        public static IList<string> ConvertEnumToFieldDescriptionList(Type enumType)
        {
            IList<string> list = new List<string>();
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo info in fields)
            {
                object[] customAttributes = info.GetCustomAttributes(typeof(EnumDescription), false);
                if ((customAttributes != null) && (customAttributes.Length > 0))
                {
                    EnumDescription description = (EnumDescription) customAttributes[0];
                    list.Add(description.Description);
                }
                else if (info.Name != "value__")
                {
                    list.Add(info.Name);
                }
            }
            return list;
        }

        public static IList<string> ConvertEnumToFieldTextList(Type enumType)
        {
            IList<string> list = new List<string>();
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo info in fields)
            {
                if (info.Name != "value__")
                {
                    list.Add(info.Name);
                }
            }
            return list;
        }

        public static object ParseEnumValue(Type enumType, string filedValOrDesc)
        {
            if ((enumType == null) || (filedValOrDesc == null))
            {
                return null;
            }
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo info in fields)
            {
                object[] customAttributes = info.GetCustomAttributes(typeof(EnumDescription), false);
                if ((customAttributes != null) && (customAttributes.Length > 0))
                {
                    EnumDescription description = (EnumDescription) customAttributes[0];
                    if (filedValOrDesc == description.Description)
                    {
                        return Enum.Parse(enumType, info.Name);
                    }
                }
            }
            return Enum.Parse(enumType, filedValOrDesc);
        }
    }
}

