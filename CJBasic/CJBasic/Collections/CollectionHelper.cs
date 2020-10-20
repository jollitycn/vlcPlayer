namespace CJBasic.Collections
{
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public static class CollectionHelper
    {
        public static void ActionOnEach<TObject>(IEnumerable<TObject> collection, Action<TObject> action)
        {
            ActionOnSpecification<TObject>(collection, action, null);
        }

        public static void ActionOnSpecification<TObject>(IEnumerable<TObject> collection, Action<TObject> action, Predicate<TObject> predicate)
        {
            if (collection != null)
            {
                if (predicate == null)
                {
                    foreach (TObject local in collection)
                    {
                        action(local);
                    }
                }
                else
                {
                    foreach (TObject local in collection)
                    {
                        if (predicate(local))
                        {
                            action(local);
                        }
                    }
                }
            }
        }

        public static bool BinarySearch<T>(IList<T> sortedList, T target, out int minIndex) where T: IComparable
        {
            if (target.CompareTo(sortedList[0]) == 0)
            {
                minIndex = 0;
                return true;
            }
            if (target.CompareTo(sortedList[0]) < 0)
            {
                minIndex = -1;
                return false;
            }
            if (target.CompareTo(sortedList[sortedList.Count - 1]) == 0)
            {
                minIndex = sortedList.Count - 1;
                return true;
            }
            if (target.CompareTo(sortedList[sortedList.Count - 1]) > 0)
            {
                minIndex = sortedList.Count - 1;
                return false;
            }
            int num2 = 0;
            int num3 = sortedList.Count - 1;
            while ((num3 - num2) > 1)
            {
                int num4 = (num2 + num3) / 2;
                if (target.CompareTo(sortedList[num4]) == 0)
                {
                    minIndex = num4;
                    return true;
                }
                if (target.CompareTo(sortedList[num4]) < 0)
                {
                    num3 = num4;
                }
                else
                {
                    num2 = num4;
                }
            }
            minIndex = num2;
            return false;
        }

        public static bool ContainsSpecification<TObject>(IEnumerable<TObject> source, Predicate<TObject> predicate)
        {
            TObject local;
            return ContainsSpecification<TObject>(source, predicate, out local);
        }

        public static bool ContainsSpecification<TObject>(IEnumerable<TObject> source, Predicate<TObject> predicate, out TObject specification)
        {
            specification = default(TObject);
            foreach (TObject local in source)
            {
                if (predicate(local))
                {
                    specification = local;
                    return true;
                }
            }
            return false;
        }

        public static List<TObject> Find<TObject>(IEnumerable<TObject> source, Predicate<TObject> predicate)
        {
            List<TObject> list = new List<TObject>();
            ActionOnSpecification<TObject>(source, delegate (TObject ele) {
                list.Add(ele);
            }, predicate);
            return list;
        }

        public static TObject FindFirstSpecification<TObject>(IEnumerable<TObject> source, Predicate<TObject> predicate)
        {
            foreach (TObject local in source)
            {
                if (predicate(local))
                {
                    return local;
                }
            }
            return default(TObject);
        }

        public static List<T> GetIntersection<T>(List<T> list1, List<T> list2) where T: IComparable
        {
            List<T> sortedList = (list1.Count > list2.Count) ? list1 : list2;
            List<T> list3 = (sortedList == list1) ? list2 : list1;
            sortedList.Sort();
            int minIndex = 0;
            List<T> list4 = new List<T>();
            foreach (T local in list3)
            {
                if (BinarySearch<T>(sortedList, local, out minIndex))
                {
                    list4.Add(local);
                }
            }
            return list4;
        }

        public static T[] GetPart<T>(T[] ary, int startIndex, int count)
        {
            return GetPart<T>(ary, startIndex, count, false);
        }

        public static T[] GetPart<T>(T[] ary, int startIndex, int count, bool reverse)
        {
            int num;
            if (startIndex >= ary.Length)
            {
                return null;
            }
            if (ary.Length < (startIndex + count))
            {
                count = ary.Length - startIndex;
            }
            T[] localArray = new T[count];
            if (!reverse)
            {
                for (num = 0; num < count; num++)
                {
                    localArray[num] = ary[startIndex + num];
                }
                return localArray;
            }
            for (num = 0; num < count; num++)
            {
                localArray[num] = ary[((ary.Length - startIndex) - 1) - num];
            }
            return localArray;
        }

        public static List<T> GetUnion<T>(List<T> list1, List<T> list2)
        {
            SortedDictionary<T, int> dictionary = new SortedDictionary<T, int>();
            foreach (T local in list1)
            {
                if (!dictionary.ContainsKey(local))
                {
                    dictionary.Add(local, 0);
                }
            }
            foreach (T local in list2)
            {
                if (!dictionary.ContainsKey(local))
                {
                    dictionary.Add(local, 0);
                }
            }
            return CollectionConverter.CopyAllToList<T>(dictionary.Keys);
        }

        public static Dictionary<TGroupBy, List<TObject>> GroupBy<TGroupBy, TObject>(ICollection<TObject> list, string propertyName)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy, List<TObject>> dictionary = new Dictionary<TGroupBy, List<TObject>>();
            foreach (TObject local in list)
            {
                TGroupBy property = (TGroupBy) ReflectionHelper.GetProperty(local, propertyName);
                if (!dictionary.ContainsKey(property))
                {
                    dictionary.Add(property, new List<TObject>());
                }
                dictionary[property].Add(local);
            }
            return dictionary;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, List<TObject>>> GroupBy<TGroupBy1, TGroupBy2, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, List<TObject>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, List<TObject>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, List<TObject>> dictionary3 = GroupBy<TGroupBy2, TObject>(dictionary[local], propertyName2);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, List<TObject>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, List<TObject>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, List<TObject>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, List<TObject>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TObject>(dictionary[local], propertyName2, propertyName3);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, List<TObject>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, List<TObject>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, List<TObject>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, List<TObject>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, List<TObject>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, List<TObject>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, List<TObject>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, List<TObject>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, List<TObject>>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5, string propertyName6)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, List<TObject>>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, List<TObject>>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, List<TObject>>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5, propertyName6);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, List<TObject>>>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5, string propertyName6, string propertyName7)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, List<TObject>>>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, List<TObject>>>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, List<TObject>>>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5, propertyName6, propertyName7);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, List<TObject>>>>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5, string propertyName6, string propertyName7, string propertyName8)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, List<TObject>>>>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, List<TObject>>>>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, List<TObject>>>>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5, propertyName6, propertyName7, propertyName8);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, List<TObject>>>>>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TGroupBy9, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5, string propertyName6, string propertyName7, string propertyName8, string propertyName9)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, List<TObject>>>>>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, List<TObject>>>>>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, List<TObject>>>>>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TGroupBy9, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5, propertyName6, propertyName7, propertyName8, propertyName9);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }

        public static Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, Dictionary<TGroupBy10, List<TObject>>>>>>>>>>> GroupBy<TGroupBy1, TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TGroupBy9, TGroupBy10, TObject>(ICollection<TObject> list, string propertyName1, string propertyName2, string propertyName3, string propertyName4, string propertyName5, string propertyName6, string propertyName7, string propertyName8, string propertyName9, string propertyName10)
        {
            if (list == null)
            {
                return null;
            }
            Dictionary<TGroupBy1, List<TObject>> dictionary = GroupBy<TGroupBy1, TObject>(list, propertyName1);
            Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, Dictionary<TGroupBy10, List<TObject>>>>>>>>>>> dictionary2 = new Dictionary<TGroupBy1, Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, Dictionary<TGroupBy10, List<TObject>>>>>>>>>>>();
            foreach (TGroupBy1 local in dictionary.Keys)
            {
                Dictionary<TGroupBy2, Dictionary<TGroupBy3, Dictionary<TGroupBy4, Dictionary<TGroupBy5, Dictionary<TGroupBy6, Dictionary<TGroupBy7, Dictionary<TGroupBy8, Dictionary<TGroupBy9, Dictionary<TGroupBy10, List<TObject>>>>>>>>>> dictionary3 = GroupBy<TGroupBy2, TGroupBy3, TGroupBy4, TGroupBy5, TGroupBy6, TGroupBy7, TGroupBy8, TGroupBy9, TGroupBy10, TObject>(dictionary[local], propertyName2, propertyName3, propertyName4, propertyName5, propertyName6, propertyName7, propertyName8, propertyName9, propertyName10);
                dictionary2.Add(local, dictionary3);
            }
            return dictionary2;
        }
    }
}

