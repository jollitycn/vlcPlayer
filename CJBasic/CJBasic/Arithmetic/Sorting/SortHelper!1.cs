namespace CJBasic.Arithmetic.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class SortHelper<T>
    {
        public static void Swap(IList<T> list, int i, int j)
        {
            T local = list[i];
            list[i] = list[j];
            list[j] = local;
        }
    }
}

