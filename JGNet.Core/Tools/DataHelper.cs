using JGNet.Core.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Server.Tools
{
    public static class DataHelper
    {
        public static List<T> GetListT<T, IT>(List<IT> itList) where T:class
        {
            List<T> ts = new List<T>();
            foreach (IT item in itList)
            {
                if (item is T)
                {
                    ts.Add(item as T);
                }
            }
            return ts;
        }

        public static List<IT> GetListIT<T, IT>(List<T> tList) where IT : class where T :class
        {
            List<IT> ts = new List<IT>();
            foreach (T item in tList)
            {
                if (item is IT)
                {
                    ts.Add(item as IT);
                }
            }
            return ts;
        }

        public static List<T> GetPage<T>(List<T> datas, int pageSize, int pageIndex)
        {
            List<T> results = new List<T>();
            int length = datas.Count;

            //根据index 获取 对应页数据
            int size = 0;
            for (int i = pageIndex * pageSize; i < length; i++)
            {
                if (size <= pageSize - 1)
                {
                    results.Add(datas[i]);
                }
                else
                {
                    break;
                }
                size++;
            }

            return results;

        }

        public static string ListToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in list)
            {
                sb.Append(str).Append(SystemDefault.SPLIT_CHAR_COMMA);
            }
            string value = sb.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Substring(0, value.Length - 1);
        }

        public static List<string> StringToList(String str)
        {
            List<string> list = new List<string>();
            if (!String.IsNullOrEmpty(str))
            {
                list.AddRange(str.Split(SystemDefault.SPLIT_CHAR_COMMA));
            }
            return list;
        }
    }
}
