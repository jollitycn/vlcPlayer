namespace CJBasic.Arithmetic.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class InsertionSorter<T> where T: IComparable
    {
        public static void Sort(IList<T> list, bool isAsc)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int num;
                T local2;
                T local = list[i];
                if (isAsc)
                {
                    num = i - 1;
                    while ((num >= 0) && ((local2 = list[num]).CompareTo(local) > 0))
                    {
                        list[num + 1] = list[num];
                        num--;
                    }
                }
                else
                {
                    num = i - 1;
                    while ((num >= 0) && ((local2 = list[num]).CompareTo(local) < 0))
                    {
                        list[num + 1] = list[num];
                        num--;
                    }
                }
                list[num + 1] = local;
            }
        }
    }
}

