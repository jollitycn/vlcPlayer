namespace CJBasic.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class FieldChecker
    {
        public static IDictionary<object, IList<string>> CheckFiledNotNull(IList<object> targets)
        {
            IDictionary<object, IList<string>> dictionary = new Dictionary<object, IList<string>>();
            foreach (object obj2 in targets)
            {
                Type type = obj2.GetType();
                if (type.GetCustomAttributes(typeof(FieldNotNullAttribute), false).Length >= 1)
                {
                    foreach (FieldInfo info in type.GetFields(BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                    {
                        if ((info.GetCustomAttributes(typeof(FieldNotNullAttribute), false).Length >= 1) && (!info.FieldType.IsValueType && (info.GetValue(obj2) == null)))
                        {
                            if (!dictionary.ContainsKey(obj2))
                            {
                                dictionary.Add(obj2, new List<string>());
                            }
                            dictionary[obj2].Add(info.Name);
                        }
                    }
                }
            }
            return dictionary;
        }
    }
}

