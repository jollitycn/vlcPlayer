namespace CJBasic.Arithmetic
{
    using System;
    using System.Collections.Generic;

    public static class BinarySearcher<T> where T: IComparable
    {
        public static int Search(IList<T> list, T value)
        {
            int num = 0;
            int count = list.Count;
            while (count >= num)
            {
                int num3 = (num + count) / 2;
                T local = list[num3];
                if (local.CompareTo(value) == 0)
                {
                    return num3;
                }
                local = list[num3];
                if (local.CompareTo(value) > 0)
                {
                    count = num3 - 1;
                }
                else
                {
                    num = num3 + 1;
                }
            }
            return -1;
        }
    }
}

