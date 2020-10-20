using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JGNet.Common.Core.Util
{
    /// <summary>
    /// creator Jason Hong 
    /// 20190103
    /// </summary>
    public class ReflectUtil
    {
        /// <summary>
        /// 获取该类型的属性 getset那种
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<object> GetProperties(Type type, Object source = null) {
            List<Object> objects = new List<object>();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                String value = prop.GetValue(source, null)?.ToString();
                objects.Add( value);
            }
            return objects;
        }

        public static string GetModelValue(string fieldName, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(fieldName).GetValue(obj, null);
                string Value = CommonGlobalUtil.ConvertToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 获取所有字段，包括常量等
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="source">对应对象</param>
        /// <returns></returns>
        public static List<object> GetFields(Type type, Object source = null)
        {
            List<Object> objects = new List<object>();
            FieldInfo[] props = type.GetFields(); 
                foreach (FieldInfo prop in props)
                { 
                    String value = prop.GetValue(source)?.ToString();
                    objects.Add(value);
                }
            return objects;
        }
    }
}
