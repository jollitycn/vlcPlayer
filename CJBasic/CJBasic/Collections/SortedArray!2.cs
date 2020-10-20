namespace CJBasic.Collections
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class SortedArray<TKey, TVal> : SortedArray2<TKey, TVal>, IComparer<TKey> where TKey: IComparable
    {
        public SortedArray()
        {
            base.comparer4Key = this;
        }

        public SortedArray(IDictionary<TKey, TVal> dictionary)
        {
            base.comparer4Key = this;
            base.Rebuild(dictionary);
        }

        public int Compare(TKey x, TKey y)
        {
            return x.CompareTo(y);
        }
    }
}

