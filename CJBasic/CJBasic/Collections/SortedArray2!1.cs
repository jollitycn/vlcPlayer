namespace CJBasic.Collections
{
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable]
    public class SortedArray2<T>
    {
        private T[] array;
        protected IComparer<T> comparer4Key;
        private List<T> lazyCopy;
        private int minCapacityForShrink;
        [NonSerialized]
        private CJBasic.Threading.Synchronize.SmartRWLocker smartRWLocker;
        private int validCount;

        protected SortedArray2()
        {
            this.lazyCopy = null;
            this.minCapacityForShrink = 0x20;
            this.array = new T[0x20];
            this.validCount = 0;
            this.comparer4Key = null;
            this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
        }

        public SortedArray2(IComparer<T> comparer)
        {
            this.lazyCopy = null;
            this.minCapacityForShrink = 0x20;
            this.array = new T[0x20];
            this.validCount = 0;
            this.comparer4Key = null;
            this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
            this.comparer4Key = comparer;
        }

        public SortedArray2(IComparer<T> comparer, ICollection<T> collection)
        {
            this.lazyCopy = null;
            this.minCapacityForShrink = 0x20;
            this.array = new T[0x20];
            this.validCount = 0;
            this.comparer4Key = null;
            this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
            this.comparer4Key = comparer;
            this.Rebuild(collection);
        }

        public void Add(T t)
        {
            int posIndex = 0;
            this.Add(t, out posIndex);
        }

        public void Add(ICollection<T> collection)
        {
            this.Add(collection, true);
        }

        public void Add(T t, out int posIndex)
        {
            if (t == null)
            {
                throw new Exception("Target can't be null !");
            }
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                int num = Array.BinarySearch<T>(this.array, 0, this.validCount, t, this.comparer4Key);
                if (num >= 0)
                {
                    posIndex = num;
                    return;
                }
                this.AdjustCapacity(1);
                posIndex = ~num;
                Array.Copy(this.array, posIndex, this.array, posIndex + 1, this.validCount - posIndex);
                this.array[posIndex] = t;
                this.validCount++;
            }
            this.lazyCopy = null;
        }

        public void Add(ICollection<T> collection, bool checkRepeat)
        {
            if ((collection != null) && (collection.Count != 0))
            {
                using (this.SmartRWLocker.Lock(AccessMode.Write))
                {
                    ICollection<T> keys = collection;
                    if (checkRepeat)
                    {
                        Dictionary<T, T> dictionary = new Dictionary<T, T>();
                        foreach (T local in collection)
                        {
                            if (!dictionary.ContainsKey(local) && !this.Contains(local))
                            {
                                dictionary.Add(local, local);
                            }
                        }
                        keys = dictionary.Keys;
                    }
                    if (keys.Count == 0)
                    {
                        return;
                    }
                    this.AdjustCapacity(keys.Count);
                    foreach (T local in keys)
                    {
                        this.array[this.validCount] = local;
                        this.validCount++;
                    }
                    Array.Sort<T>(this.array, 0, this.validCount, this.comparer4Key);
                }
                this.lazyCopy = null;
            }
        }

        private void AdjustCapacity(int newCount)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                int num = this.validCount + newCount;
                if (this.array.Length < num)
                {
                    int length = this.array.Length;
                    while (length < num)
                    {
                        length *= 2;
                    }
                    T[] destinationArray = new T[length];
                    Array.Copy(this.array, 0, destinationArray, 0, this.validCount);
                    this.array = destinationArray;
                }
            }
        }

        public void Clear()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                this.array = new T[this.minCapacityForShrink];
                this.validCount = 0;
            }
            this.lazyCopy = null;
        }

        public bool Contains(T t)
        {
            return (this.IndexOf(t) >= 0);
        }

        public List<T> GetAll()
        {
            List<T> list = new List<T>();
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                for (int i = 0; i < this.validCount; i++)
                {
                    list.Add(this.array[i]);
                }
            }
            return list;
        }

        public List<T> GetAllReadonly()
        {
            if (this.lazyCopy != null)
            {
                return this.lazyCopy;
            }
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                List<T> list = new List<T>();
                for (int i = 0; i < this.validCount; i++)
                {
                    list.Add(this.array[i]);
                }
                this.lazyCopy = list;
                return this.lazyCopy;
            }
        }

        public T[] GetBetween(int minIndex, int maxIndex)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                minIndex = (minIndex < 0) ? 0 : minIndex;
                maxIndex = (maxIndex >= this.validCount) ? (this.validCount - 1) : maxIndex;
                if (maxIndex < minIndex)
                {
                    return new T[0];
                }
                int length = (maxIndex - minIndex) - 1;
                T[] destinationArray = new T[length];
                Array.Copy(this.array, minIndex, destinationArray, 0, length);
                return destinationArray;
            }
        }

        public T GetMax()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    throw new Exception("SortedArray is Empty !");
                }
                return this.array[this.validCount - 1];
            }
        }

        public T GetMin()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    throw new Exception("SortedArray is Empty !");
                }
                return this.array[0];
            }
        }

        public int IndexOf(T t)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return -1;
                }
                int num = Array.BinarySearch<T>(this.array, 0, this.validCount, t, this.comparer4Key);
                return ((num < 0) ? -1 : num);
            }
        }

        protected void Rebuild(ICollection<T> collection)
        {
            if ((collection != null) && (collection.Count != 0))
            {
                this.array = new T[collection.Count];
                collection.CopyTo(this.array, 0);
                Array.Sort<T>(this.array, this.comparer4Key);
                this.validCount = collection.Count;
            }
        }

        public void Remove(T t)
        {
            if (t != null)
            {
                int index = -1;
                do
                {
                    index = this.IndexOf(t);
                    if (index >= 0)
                    {
                        this.RemoveAt(index);
                    }
                }
                while (index >= 0);
                this.lazyCopy = null;
            }
        }

        public void RemoveAt(int index)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if ((index < 0) || (index >= this.validCount))
                {
                    return;
                }
                if (index == (this.validCount - 1))
                {
                    this.array[index] = default(T);
                }
                else
                {
                    Array.Copy(this.array, index + 1, this.array, index, (this.validCount - index) - 1);
                }
                this.validCount--;
            }
            this.lazyCopy = null;
        }

        public void RemoveBetween(int minIndex, int maxIndex)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                minIndex = (minIndex < 0) ? 0 : minIndex;
                maxIndex = (maxIndex >= this.validCount) ? (this.validCount - 1) : maxIndex;
                if (maxIndex < minIndex)
                {
                    return;
                }
                Array.Copy(this.array, maxIndex + 1, this.array, minIndex, (this.validCount - maxIndex) - 1);
                this.validCount -= (maxIndex - minIndex) + 1;
            }
            this.lazyCopy = null;
        }

        public void Shrink()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (this.array.Length != this.validCount)
                {
                    int num = (this.validCount >= this.minCapacityForShrink) ? this.validCount : this.minCapacityForShrink;
                    T[] destinationArray = new T[num];
                    Array.Copy(this.array, 0, destinationArray, 0, this.validCount);
                    this.array = destinationArray;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Count:{0} ,Capacity:{1}", this.validCount, this.array.Length);
        }

        private int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.validCount;
            }
        }

        public T this[int index]
        {
            get
            {
                using (this.SmartRWLocker.Lock(AccessMode.Read))
                {
                    if ((index < 0) || (index >= this.validCount))
                    {
                        throw new Exception("Index out of the range !");
                    }
                    return this.array[index];
                }
            }
        }

        public DateTime LastReadTime
        {
            get
            {
                return this.SmartRWLocker.LastRequireReadTime;
            }
        }

        public DateTime LastWriteTime
        {
            get
            {
                return this.SmartRWLocker.LastRequireWriteTime;
            }
        }

        private CJBasic.Threading.Synchronize.SmartRWLocker SmartRWLocker
        {
            get
            {
                if (this.smartRWLocker == null)
                {
                    this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
                }
                return this.smartRWLocker;
            }
        }
    }
}

