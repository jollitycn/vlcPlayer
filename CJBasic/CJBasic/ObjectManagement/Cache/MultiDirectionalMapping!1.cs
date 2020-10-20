namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.Collections;
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    public class MultiDirectionalMapping<T> where T: IComparable
    {
        private Dictionary<T, SortedArray<T>> mapping;
        private SmartRWLocker smartRWLocker;

        public MultiDirectionalMapping()
        {
            this.mapping = new Dictionary<T, SortedArray<T>>();
            this.smartRWLocker = new SmartRWLocker();
        }

        public void Add(T t1, T t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (!this.mapping.ContainsKey(t1))
                {
                    this.mapping.Add(t1, new SortedArray<T>());
                }
                this.mapping[t1].Add(t2);
                if (!this.mapping.ContainsKey(t2))
                {
                    this.mapping.Add(t2, new SortedArray<T>());
                }
                this.mapping[t2].Add(t1);
            }
        }

        public void Clear()
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                this.mapping.Clear();
            }
        }

        public List<T> GetMappingList(T t)
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                if (this.mapping.ContainsKey(t))
                {
                    return this.mapping[t].GetAll();
                }
                return new List<T>();
            }
        }

        public bool Map(T t1, T t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                if (!this.mapping.ContainsKey(t1))
                {
                    return false;
                }
                return this.mapping[t1].Contains(t2);
            }
        }

        public void Remove(T t)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.mapping.ContainsKey(t))
                {
                    this.mapping.Remove(t);
                }
                foreach (SortedArray<T> array in this.mapping.Values)
                {
                    array.Remove(t);
                }
            }
        }

        public void Remove(T t1, T t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.mapping.ContainsKey(t1))
                {
                    this.mapping[t1].Remove(t2);
                }
                if (this.mapping.ContainsKey(t2))
                {
                    this.mapping[t2].Remove(t1);
                }
            }
        }
    }
}

