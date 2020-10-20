namespace CJBasic.Collections
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class SortedArray<T> : SortedArray2<T>, IComparer<T> where T: IComparable
    {
        public SortedArray()
        {
            base.comparer4Key = this;
        }

        public SortedArray(ICollection<T> collection)
        {
            base.comparer4Key = this;
            base.Rebuild(collection);
        }

        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}

