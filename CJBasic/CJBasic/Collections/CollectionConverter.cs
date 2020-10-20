namespace CJBasic.Collections
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public static class CollectionConverter
    {
        public static List<TResult> ConvertAll<TObject, TResult>(IEnumerable<TObject> source, Func<TObject, TResult> converter)
        {
            return ConvertSpecification<TObject, TResult>(source, converter, null);
        }

        public static List<TElement> ConvertArrayToList<TElement>(TElement[] ary)
        {
            if (ary == null)
            {
                return null;
            }
            return CollectionHelper.Find<TElement>(ary, null);
        }

        public static TResult ConvertFirstSpecification<TObject, TResult>(IEnumerable<TObject> source, Func<TObject, TResult> converter, Predicate<TObject> predicate)
        {
            TObject local = CollectionHelper.FindFirstSpecification<TObject>(source, predicate);
            if (local == null)
            {
                return default(TResult);
            }
            return converter(local);
        }

        public static List<T> ConvertListDown<TBase, T>(IList<TBase> baseList) where T: TBase
        {
            List<T> list = new List<T>(baseList.Count);
            for (int i = 0; i < baseList.Count; i++)
            {
                list.Add((T) baseList[i]);
            }
            return list;
        }

        public static TElement[] ConvertListToArray<TElement>(IList<TElement> list)
        {
            if (list == null)
            {
                return null;
            }
            TElement[] localArray = new TElement[list.Count];
            for (int i = 0; i < localArray.Length; i++)
            {
                localArray[i] = list[i];
            }
            return localArray;
        }

        public static List<TBase> ConvertListUpper<TBase, T>(IList<T> list) where T: TBase
        {
            List<TBase> list2 = new List<TBase>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                list2.Add(list[i]);
            }
            return list2;
        }

        public static List<TResult> ConvertSpecification<TObject, TResult>(IEnumerable<TObject> source, Func<TObject, TResult> converter, Predicate<TObject> predicate)
        {
            List<TResult> list = new List<TResult>();
            CollectionHelper.ActionOnSpecification<TObject>(source, delegate (TObject ele) {
                list.Add(converter(ele));
            }, predicate);
            return list;
        }

        public static List<TObject> CopyAllToList<TObject>(IEnumerable<TObject> source)
        {
            List<TObject> copy = new List<TObject>();
            CollectionHelper.ActionOnEach<TObject>(source, delegate (TObject t) {
                copy.Add(t);
            });
            return copy;
        }

        public static List<TObject> CopySpecificationToList<TObject>(IEnumerable<TObject> source, Predicate<TObject> predicate)
        {
            List<TObject> copy = new List<TObject>();
            CollectionHelper.ActionOnSpecification<TObject>(source, delegate (TObject t) {
                copy.Add(t);
            }, predicate);
            return copy;
        }
    }
}

