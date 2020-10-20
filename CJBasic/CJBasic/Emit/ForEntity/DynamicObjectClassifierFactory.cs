namespace CJBasic.Emit.ForEntity
{
    using CJBasic.Emit.Management;
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class DynamicObjectClassifierFactory
    {
        private static DynamicAssemblyManager dynamicAssemblyManager = new DynamicAssemblyManager();
        private static CJBasic.Emit.ForEntity.DynamicObjectClassifierEmitter DynamicObjectClassifierEmitter = new CJBasic.Emit.ForEntity.DynamicObjectClassifierEmitter();
        private static IDictionary<string, Type> NTierDictionaryTypeDic = new Dictionary<string, Type>();

        public static IObjectClassifier<TObject> CreateObjectClassifier<TObject>(params string[] properties4Classify)
        {
            lock (DynamicObjectClassifierEmitter)
            {
                Type type = typeof(TObject);
                Type[] nestedKeyTypes = new Type[properties4Classify.Length];
                string str = type.ToString();
                for (int i = 0; i < properties4Classify.Length; i++)
                {
                    PropertyInfo property = type.GetProperty(properties4Classify[i]);
                    if (property == null)
                    {
                        throw new Exception(string.Format("Property named {0} not found in Type {1} !", properties4Classify[i], type));
                    }
                    nestedKeyTypes[i] = property.PropertyType;
                    str = str + "_" + TypeHelper.GetClassSimpleName(nestedKeyTypes[i]);
                }
                string str2 = string.Format("{0}_Classifier", str);
                if (!NTierDictionaryTypeDic.ContainsKey(str))
                {
                    Type type2 = null;
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    foreach (Assembly assembly in assemblies)
                    {
                        foreach (Type type3 in assembly.GetTypes())
                        {
                            if ((type3.Assembly.FullName.Split(new char[] { ',' })[0] == "DynamicObjectClassifierAssembly") && (type3.FullName == str2))
                            {
                                type2 = type3;
                            }
                        }
                    }
                    if (type2 == null)
                    {
                        type2 = DynamicObjectClassifierEmitter.EmitDynamicNTierDictionaryType<TObject>(nestedKeyTypes);
                    }
                    NTierDictionaryTypeDic.Add(str, type2);
                }
                Type type4 = NTierDictionaryTypeDic[str];
                return (IObjectClassifier<TObject>) Activator.CreateInstance(type4, new object[] { properties4Classify });
            }
        }
    }
}

