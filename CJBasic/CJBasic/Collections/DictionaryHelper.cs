namespace CJBasic.Collections
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public static class DictionaryHelper
    {
        public static Dictionary<TKey, TObject> ConvertToDictionary<TKey, TObject>(IEnumerable<TObject> source, Func<TObject, TKey> func)
        {
            return ConvertToDictionary<TKey, TObject>(source, func, delegate (TObject obj) {
                return true;
            });
        }

        public static Dictionary<TKey, TObject> ConvertToDictionary<TKey, TObject>(IEnumerable<TObject> source, Func<TObject, TKey> func, Predicate<TObject> predicate)
        {
            Dictionary<TKey, TObject> dictionary = new Dictionary<TKey, TObject>();
            foreach (TObject local in source)
            {
                if (predicate(local))
                {
                    dictionary.Add(func(local), local);
                }
            }
            return dictionary;
        }

        public static TKey GetOneByValue<TKey, TValue>(IDictionary<TKey, TValue> dic, TValue val) where TKey: class where TValue: IEquatable<TValue>
        {
            return CollectionHelper.FindFirstSpecification<TKey>(dic.Keys, delegate (TKey cur) {
                TValue local = dic[cur];
                return local.Equals(val);
            });
        }

        public static void RemoveOneByValue<TKey, TValue>(IDictionary<TKey, TValue> dic, TValue val) where TKey: class where TValue: IEquatable<TValue>
        {
            TKey oneByValue = GetOneByValue<TKey, TValue>(dic, val);
            if (oneByValue != null)
            {
                dic.Remove(oneByValue);
            }
        }
    }
}

