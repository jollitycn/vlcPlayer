namespace CJBasic.Arithmetic.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class QuickSorter<T> where T: IComparable
    {
        public static void Sort(IList<T> list, bool isAsc)
        {
            QuickSorter<T>.Sort(list, 0, list.Count - 1, isAsc);
        }

        private static void Sort(IList<T> list, int left, int right, bool isAsc)
        {
            if (left < right)
            {
                T local;
                T local2;
                int i = left;
                int j = right + 1;
                if (!isAsc)
                {
                    while (i < j)
                    {
                        i++;
                        local = list[left];
                        while ((i < right) && ((local2 = list[i]).CompareTo(local) > 0))
                        {
                            i++;
                        }
                        j--;
                        while ((j >= left) && ((local2 = list[j]).CompareTo(local) < 0))
                        {
                            j--;
                        }
                        if (i < j)
                        {
                            SortHelper<T>.Swap(list, i, j);
                        }
                    }
                }
                else
                {
                    while (i < j)
                    {
                        i++;
                        local = list[left];
                        while ((i < right) && ((local2 = list[i]).CompareTo(local) < 0))
                        {
                            i++;
                        }
                        j--;
                        while ((j >= left) && ((local2 = list[j]).CompareTo(local) > 0))
                        {
                            j--;
                        }
                        if (i < j)
                        {
                            SortHelper<T>.Swap(list, i, j);
                        }
                    }
                }
                SortHelper<T>.Swap(list, left, j);
                QuickSorter<T>.Sort(list, left, j - 1, isAsc);
                QuickSorter<T>.Sort(list, j + 1, right, isAsc);
            }
        }
    }
}

