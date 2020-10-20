namespace CJBasic.Addins
{
    using System;
    using System.Collections.Generic;

    public static class AddinUtil
    {
        private static IDictionary<string, object> DicUtil = new Dictionary<string, object>();

        public static void Clear()
        {
            lock (DicUtil)
            {
                DicUtil.Clear();
            }
        }

        public static object GetObject(string name)
        {
            lock (DicUtil)
            {
                if (DicUtil.ContainsKey(name))
                {
                    return DicUtil[name];
                }
                return null;
            }
        }

        public static void RegisterObject(string name, object obj)
        {
            lock (DicUtil)
            {
                if (DicUtil.ContainsKey(name))
                {
                    Remove(name);
                }
                DicUtil.Add(name, obj);
            }
        }

        public static void Remove(string name)
        {
            lock (DicUtil)
            {
                if (DicUtil.ContainsKey(name))
                {
                    DicUtil.Remove(name);
                }
            }
        }
    }
}

