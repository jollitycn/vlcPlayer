namespace CJBasic.Helpers
{
    using CJBasic.Emit.ForEntity;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting;

    public static class RemotingHelper
    {
        public static TIParentService GetChildService<TIParentService>(string remotingServiceUrl)
        {
            Dictionary<string, Type> entityPropertyDic = new Dictionary<string, Type>();
            Type type = typeof(TIParentService);
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (info.CanRead)
                {
                    entityPropertyDic.Add(info.Name, info.PropertyType);
                }
            }
            Type type2 = DynamicEntityFactory.CreateEntityType("CT" + TypeHelper.GetClassSimpleName(typeof(TIParentService)), entityPropertyDic, typeof(TIParentService));
            object obj2 = Activator.CreateInstance(type2);
            foreach (PropertyInfo info in type2.GetProperties())
            {
                if (info.CanRead)
                {
                    object obj3 = Activator.GetObject(info.PropertyType, string.Format("{0}/{1}", remotingServiceUrl, info.Name));
                    info.GetSetMethod().Invoke(obj2, new object[] { obj3 });
                }
            }
            return (TIParentService) obj2;
        }

        public static void PublishChildService<TIParentService>(TIParentService parentService)
        {
            Type type = typeof(TIParentService);
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (info.CanRead)
                {
                    MarshalByRefObject property = ReflectionHelper.GetProperty(parentService, info.Name) as MarshalByRefObject;
                    if (property != null)
                    {
                        RemotingServices.Marshal(property, info.Name);
                    }
                }
            }
        }
    }
}

