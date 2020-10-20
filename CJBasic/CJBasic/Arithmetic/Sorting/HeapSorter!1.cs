namespace CJBasic.Arithmetic.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class HeapSorter<T> where T: IComparable
    {
        private static void Adjust(IList<T> list, int nodeIndx, int maxAdjustIndx, bool isAsc)
        {
            T local = list[nodeIndx];
            T local2 = list[nodeIndx];
            int num = (2 * nodeIndx) + 1;
            while (num <= maxAdjustIndx)
            {
                T local3;
                if (isAsc)
                {
                    if ((num < maxAdjustIndx) && ((local3 = list[num]).CompareTo(list[num + 1]) < 0))
                    {
                        num++;
                    }
                    if (local.CompareTo(list[num]) > 0)
                    {
                        break;
                    }
                    list[(num - 1) / 2] = list[num];
                    num = (2 * num) + 1;
                }
                else
                {
                    if ((num < maxAdjustIndx) && ((local3 = list[num]).CompareTo(list[num + 1]) > 0))
                    {
                        num++;
                    }
                    if (local.CompareTo(list[num]) < 0)
                    {
                        break;
                    }
                    list[(num - 1) / 2] = list[num];
                    num = (2 * num) + 1;
                }
            }
            list[(num - 1) / 2] = local2;
        }

        public static void Sort(IList<T> list, bool isAsc)
        {
            int num;
            for (num = (list.Count / 2) - 1; num >= 0; num--)
            {
                HeapSorter<T>.Adjust(list, num, list.Count - 1, isAsc);
            }
            for (num = list.Count - 1; num > 0; num--)
            {
                SortHelper<T>.Swap(list, 0, num);
                HeapSorter<T>.Adjust(list, 0, num - 1, isAsc);
            }
        }
    }
}

