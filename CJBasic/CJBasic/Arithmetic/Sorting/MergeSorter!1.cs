namespace CJBasic.Arithmetic.Sorting
{
    using System;
    using System.Collections.Generic;

    public static class MergeSorter<T> where T: IComparable
    {
        private static void Merge(IList<T> list, int startIndx, int splitIndx, int endIndx, IList<T> sortedList, bool isASC)
        {
            int num4;
            int num = splitIndx + 1;
            int num2 = startIndx;
            int num3 = startIndx;
            while ((num2 <= splitIndx) && (num <= endIndx))
            {
                T local;
                if (isASC)
                {
                    local = list[num2];
                    if (local.CompareTo(list[num]) <= 0)
                    {
                        sortedList[num3++] = list[num2++];
                    }
                    else
                    {
                        sortedList[num3++] = list[num++];
                    }
                }
                else
                {
                    local = list[num2];
                    if (local.CompareTo(list[num]) >= 0)
                    {
                        sortedList[num3++] = list[num2++];
                    }
                    else
                    {
                        sortedList[num3++] = list[num++];
                    }
                }
            }
            if (num2 > splitIndx)
            {
                for (num4 = num; num4 <= endIndx; num4++)
                {
                    sortedList[(num3 + num4) - num] = list[num4];
                }
            }
            else
            {
                for (num4 = num2; num4 <= splitIndx; num4++)
                {
                    sortedList[(num3 + num4) - num2] = list[num4];
                }
            }
        }

        private static void MergePass(IList<T> list, IList<T> sortedList, int length, bool isASC)
        {
            int startIndx = 0;
            while (startIndx <= (list.Count - (2 * length)))
            {
                MergeSorter<T>.Merge(list, startIndx, (startIndx + length) - 1, (startIndx + (2 * length)) - 1, sortedList, isASC);
                startIndx += 2 * length;
            }
            if ((startIndx + length) < list.Count)
            {
                MergeSorter<T>.Merge(list, startIndx, (startIndx + length) - 1, list.Count - 1, sortedList, isASC);
            }
            else
            {
                for (int i = startIndx; i < list.Count; i++)
                {
                    sortedList[i] = list[i];
                }
            }
        }

        public static void Sort(IList<T> list, bool isAsc)
        {
            int length = 1;
            IList<T> sortedList = new List<T>(list.Count);
            foreach (T local in list)
            {
                sortedList.Add(local);
            }
            while (length < list.Count)
            {
                MergeSorter<T>.MergePass(list, sortedList, length, isAsc);
                length *= 2;
                MergeSorter<T>.MergePass(sortedList, list, length, isAsc);
                length *= 2;
            }
        }
    }
}

