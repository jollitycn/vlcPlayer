namespace CJBasic.Collections
{
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable]
    public class SortedArray2<TKey, TVal>
    {
        protected IComparer<TKey> comparer4Key;
        private TKey[] keyArray;
        private List<TVal> lazyCopy;
        private int minCapacityForShrink;
        [NonSerialized]
        private CJBasic.Threading.Synchronize.SmartRWLocker smartRWLocker;
        private TVal[] valArray;
        private int validCount;

        public SortedArray2()
        {
            this.lazyCopy = null;
            this.comparer4Key = null;
            this.minCapacityForShrink = 0x20;
            this.keyArray = new TKey[0x20];
            this.valArray = new TVal[0x20];
            this.validCount = 0;
            this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
        }

        public SortedArray2(IComparer<TKey> _comparer4Key) : this(_comparer4Key, null)
        {
        }

        public SortedArray2(IComparer<TKey> _comparer4Key, IDictionary<TKey, TVal> dictionary)
        {
            this.lazyCopy = null;
            this.comparer4Key = null;
            this.minCapacityForShrink = 0x20;
            this.keyArray = new TKey[0x20];
            this.valArray = new TVal[0x20];
            this.validCount = 0;
            this.smartRWLocker = new CJBasic.Threading.Synchronize.SmartRWLocker();
            this.comparer4Key = _comparer4Key;
            this.Rebuild(dictionary);
        }

        public void Add(IDictionary<TKey, TVal> dic)
        {
            if ((dic != null) && (dic.Count != 0))
            {
                using (this.SmartRWLocker.Lock(AccessMode.Write))
                {
                    this.lazyCopy = null;
                    if (this.validCount == 0)
                    {
                        this.Rebuild(dic);
                    }
                    else
                    {
                        foreach (TKey local in dic.Keys)
                        {
                            if (this.ContainsKey(local))
                            {
                                throw new Exception(string.Format("The Key [{0}] has existed in SortedArray !", local));
                            }
                        }
                        this.AdjustCapacity(dic.Count);
                        foreach (TKey local in dic.Keys)
                        {
                            this.keyArray[this.validCount] = local;
                            this.valArray[this.validCount] = dic[local];
                            this.validCount++;
                        }
                        Array.Sort<TKey, TVal>(this.keyArray, this.valArray, 0, this.validCount, this.comparer4Key);
                    }
                }
            }
        }

        public void Add(TKey key, TVal val)
        {
            if (key == null)
            {
                throw new Exception("Target Key can't be null !");
            }
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                this.lazyCopy = null;
                int index = Array.BinarySearch<TKey>(this.keyArray, 0, this.validCount, key, this.comparer4Key);
                if (index >= 0)
                {
                    this.valArray[index] = val;
                }
                else
                {
                    this.AdjustCapacity(1);
                    int sourceIndex = ~index;
                    Array.Copy(this.keyArray, sourceIndex, this.keyArray, sourceIndex + 1, this.validCount - sourceIndex);
                    Array.Copy(this.valArray, sourceIndex, this.valArray, sourceIndex + 1, this.validCount - sourceIndex);
                    this.keyArray[sourceIndex] = key;
                    this.valArray[sourceIndex] = val;
                    this.validCount++;
                }
            }
        }

        public void AddSafely(TKey key, TVal val)
        {
            if (key == null)
            {
                throw new Exception("Target Key can't be null !");
            }
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (!this.ContainsKey(key))
                {
                    this.Add(key, val);
                }
            }
        }

        private void AdjustCapacity(int newCount)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                int num = this.validCount + newCount;
                if (this.keyArray.Length < num)
                {
                    int length = this.keyArray.Length;
                    while (length < num)
                    {
                        length *= 2;
                    }
                    TKey[] destinationArray = new TKey[length];
                    TVal[] localArray2 = new TVal[length];
                    Array.Copy(this.keyArray, 0, destinationArray, 0, this.validCount);
                    Array.Copy(this.valArray, 0, localArray2, 0, this.validCount);
                    this.keyArray = destinationArray;
                    this.valArray = localArray2;
                }
            }
        }

        public void Clear()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                this.lazyCopy = null;
                this.keyArray = new TKey[this.minCapacityForShrink];
                this.valArray = new TVal[this.minCapacityForShrink];
                this.validCount = 0;
            }
        }

        public bool ContainsKey(TKey t)
        {
            return (this.IndexOfKey(t) >= 0);
        }

        public TVal Get(TKey key)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                int index = this.IndexOfKey(key);
                if (index < 0)
                {
                    return default(TVal);
                }
                return this.valArray[index];
            }
        }

        public List<TVal> GetAll()
        {
            return this.GetAllValueList();
        }

        public List<TKey> GetAllKeyList()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                List<TKey> list = new List<TKey>();
                for (int i = 0; i < this.validCount; i++)
                {
                    list.Add(this.keyArray[i]);
                }
                return list;
            }
        }

        public List<TVal> GetAllReadonly()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.lazyCopy == null)
                {
                    this.lazyCopy = this.GetAllValueList();
                }
                return this.lazyCopy;
            }
        }

        public List<TVal> GetAllValueList()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                List<TVal> list = new List<TVal>();
                for (int i = 0; i < this.validCount; i++)
                {
                    list.Add(this.valArray[i]);
                }
                return list;
            }
        }

        public KeyValuePair<TKey, TVal> GetAt(int index)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if ((index < 0) || (index >= this.validCount))
                {
                    throw new Exception("Index out of the range !");
                }
                return new KeyValuePair<TKey, TVal>(this.keyArray[index], this.valArray[index]);
            }
        }

        public void GetBetween(int minIndex, int maxIndex, out TKey[] resultKey, out TVal[] resultVal)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                minIndex = (minIndex < 0) ? 0 : minIndex;
                maxIndex = (maxIndex >= this.validCount) ? (this.validCount - 1) : maxIndex;
                if (maxIndex < minIndex)
                {
                    resultKey = new TKey[0];
                    resultVal = new TVal[0];
                }
                else
                {
                    int length = (maxIndex - minIndex) + 1;
                    resultKey = new TKey[length];
                    resultVal = new TVal[length];
                    Array.Copy(this.keyArray, minIndex, resultKey, 0, length);
                    Array.Copy(this.valArray, minIndex, resultVal, 0, length);
                }
            }
        }

        public List<TVal> GetByKeys(IEnumerable<TKey> collection)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (collection == null)
                {
                    return new List<TVal>();
                }
                List<TVal> list = new List<TVal>();
                foreach (TKey local in collection)
                {
                    int index = this.IndexOfKey(local);
                    if (index >= 0)
                    {
                        list.Add(this.valArray[index]);
                    }
                }
                return list;
            }
        }

        public TVal[] GetByKeyScope(TKey minKey, bool minClosed, TKey maxKey, bool maxClosed)
        {
            TKey[] resultKey = null;
            TVal[] resultVal = null;
            this.GetByKeyScope(minKey, minClosed, maxKey, maxClosed, out resultKey, out resultVal);
            return resultVal;
        }

        public void GetByKeyScope(TKey minKey, bool minClosed, TKey maxKey, bool maxClosed, out TKey[] resultKey, out TVal[] resultVal)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.comparer4Key.Compare(minKey, maxKey) > 0)
                {
                    resultKey = new TKey[0];
                    resultVal = new TVal[0];
                }
                else
                {
                    int posIndex = 0;
                    int num2 = 0;
                    bool flag = this.HitKey(minKey, out posIndex);
                    bool flag2 = this.HitKey(maxKey, out num2);
                    posIndex = minClosed ? posIndex : (flag ? (posIndex + 1) : posIndex);
                    num2 = maxClosed ? (flag2 ? num2 : (num2 - 1)) : (num2 - 1);
                    this.GetBetween(posIndex, num2, out resultKey, out resultVal);
                }
            }
        }

        public TVal[] GetGreater(TKey minKey, bool includEqual)
        {
            TKey[] resultKey = null;
            TVal[] resultVal = null;
            this.GetGreater(minKey, includEqual, out resultKey, out resultVal);
            return resultVal;
        }

        public void GetGreater(TKey minKey, bool closed, out TKey[] resultKey, out TVal[] resultVal)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                TKey maxKey = this.GetMaxKey();
                if (this.comparer4Key.Compare(minKey, maxKey) > 0)
                {
                    resultKey = new TKey[0];
                    resultVal = new TVal[0];
                }
                else
                {
                    int posIndex = 0;
                    if (!(!this.HitKey(minKey, out posIndex) || closed))
                    {
                        posIndex++;
                    }
                    this.GetBetween(posIndex, this.validCount - 1, out resultKey, out resultVal);
                }
            }
        }

        public TKey GetMaxKey()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    throw new Exception("SortedArray is Empty !");
                }
                return this.keyArray[this.validCount - 1];
            }
        }

        public TKey GetMinKey()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    throw new Exception("SortedArray is Empty !");
                }
                return this.keyArray[0];
            }
        }

        public TVal[] GetSmaller(TKey maxKey, bool includEqual)
        {
            TKey[] resultKey = null;
            TVal[] resultVal = null;
            this.GetSmaller(maxKey, includEqual, out resultKey, out resultVal);
            return resultVal;
        }

        public void GetSmaller(TKey maxKey, bool closed, out TKey[] resultKey, out TVal[] resultVal)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                TKey minKey = this.GetMinKey();
                if (this.comparer4Key.Compare(minKey, maxKey) > 0)
                {
                    resultKey = new TKey[0];
                    resultVal = new TVal[0];
                }
                else
                {
                    int posIndex = 0;
                    if (!(!this.HitKey(maxKey, out posIndex) || closed))
                    {
                        posIndex--;
                    }
                    this.GetBetween(0, posIndex, out resultKey, out resultVal);
                }
            }
        }

        public List<TVal> GetValNotInKeys(IEnumerable<TKey> collection)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (collection == null)
                {
                    return new List<TVal>();
                }
                List<TKey> list = new List<TKey>(collection);
                list.Sort();
                TKey[] array = list.ToArray();
                List<TVal> list2 = new List<TVal>();
                for (int i = 0; i < this.validCount; i++)
                {
                    if (Array.BinarySearch<TKey>(array, this.keyArray[i], this.comparer4Key) < 0)
                    {
                        list2.Add(this.valArray[i]);
                    }
                }
                return list2;
            }
        }

        public TVal[] GetValNotInKeyScope(TKey minKey, TKey maxKey)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.comparer4Key.Compare(minKey, maxKey) > 0)
                {
                    return new TVal[0];
                }
                int posIndex = 0;
                int num2 = 0;
                bool flag = this.HitKey(minKey, out posIndex);
                bool flag2 = this.HitKey(maxKey, out num2);
                posIndex = flag ? (posIndex - 1) : posIndex;
                num2 = flag2 ? (num2 + 1) : num2;
                int num3 = (posIndex + this.validCount) - num2;
                TVal[] destinationArray = new TVal[num3];
                Array.Copy(this.valArray, destinationArray, posIndex);
                Array.Copy(this.valArray, num2, destinationArray, posIndex, this.validCount - num2);
                return destinationArray;
            }
        }

        private bool HitKey(TKey key, out int posIndex)
        {
            posIndex = Array.BinarySearch<TKey>(this.keyArray, 0, this.validCount, key, this.comparer4Key);
            if (posIndex >= 0)
            {
                return true;
            }
            posIndex = ~posIndex;
            return false;
        }

        public int IndexOfKey(TKey t)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return -1;
                }
                int num = Array.BinarySearch<TKey>(this.keyArray, 0, this.validCount, t, this.comparer4Key);
                return ((num < 0) ? -1 : num);
            }
        }

        public void Rebuild(IDictionary<TKey, TVal> dictionary)
        {
            if ((dictionary != null) && (dictionary.Count != 0))
            {
                this.keyArray = new TKey[dictionary.Count];
                this.valArray = new TVal[dictionary.Count];
                dictionary.Keys.CopyTo(this.keyArray, 0);
                dictionary.Values.CopyTo(this.valArray, 0);
                Array.Sort<TKey, TVal>(this.keyArray, this.valArray, this.comparer4Key);
                this.validCount = dictionary.Count;
            }
        }

        public void Remove(TKey t)
        {
            this.RemoveByKey(t);
        }

        public void RemoveAt(int index)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if ((index >= 0) && (index < this.validCount))
                {
                    this.lazyCopy = null;
                    Array.Copy(this.keyArray, index + 1, this.keyArray, index, (this.validCount - index) - 1);
                    Array.Copy(this.valArray, index + 1, this.valArray, index, (this.validCount - index) - 1);
                    this.validCount--;
                }
            }
        }

        public void RemoveBetween(int minIndex, int maxIndex)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                minIndex = (minIndex < 0) ? 0 : minIndex;
                maxIndex = (maxIndex >= this.validCount) ? (this.validCount - 1) : maxIndex;
                if (maxIndex >= minIndex)
                {
                    this.lazyCopy = null;
                    Array.Copy(this.keyArray, maxIndex + 1, this.keyArray, minIndex, (this.validCount - maxIndex) - 1);
                    Array.Copy(this.valArray, maxIndex + 1, this.valArray, minIndex, (this.validCount - maxIndex) - 1);
                    this.validCount -= (maxIndex - minIndex) + 1;
                }
            }
        }

        public void RemoveBetween(TKey minKey, bool minClosed, TKey maxKey, bool maxClosed)
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (this.comparer4Key.Compare(minKey, maxKey) <= 0)
                {
                    this.lazyCopy = null;
                    int posIndex = 0;
                    int num2 = 0;
                    bool flag = this.HitKey(minKey, out posIndex);
                    bool flag2 = this.HitKey(maxKey, out num2);
                    posIndex = minClosed ? posIndex : (flag ? (posIndex + 1) : posIndex);
                    num2 = maxClosed ? (flag2 ? num2 : (num2 - 1)) : (num2 - 1);
                    this.RemoveBetween(posIndex, num2);
                }
            }
        }

        public void RemoveByKey(TKey t)
        {
            if (t != null)
            {
                int index = this.IndexOfKey(t);
                if (index >= 0)
                {
                    this.RemoveAt(index);
                }
            }
        }

        public void RemoveByKeys(ICollection<TKey> keyCollection)
        {
            if ((keyCollection != null) && (keyCollection.Count != 0))
            {
                this.lazyCopy = null;
                Dictionary<TKey, TKey> dictionary = new Dictionary<TKey, TKey>();
                foreach (TKey local in keyCollection)
                {
                    dictionary.Add(local, local);
                }
                IDictionary<TKey, TVal> dic = new Dictionary<TKey, TVal>();
                for (int i = 0; i < this.validCount; i++)
                {
                    if (!dictionary.ContainsKey(this.keyArray[i]))
                    {
                        dic.Add(this.keyArray[i], this.valArray[i]);
                    }
                }
                this.Clear();
                this.Add(dic);
            }
        }

        public void Shrink()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Write))
            {
                if (this.keyArray.Length != this.validCount)
                {
                    int num = (this.validCount >= this.minCapacityForShrink) ? this.validCount : this.minCapacityForShrink;
                    TKey[] destinationArray = new TKey[num];
                    TVal[] localArray2 = new TVal[num];
                    Array.Copy(this.keyArray, 0, destinationArray, 0, this.validCount);
                    Array.Copy(this.valArray, 0, localArray2, 0, this.validCount);
                    this.keyArray = destinationArray;
                    this.valArray = localArray2;
                }
            }
        }

        public Dictionary<TKey, TVal> ToDictionary()
        {
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                Dictionary<TKey, TVal> dictionary = new Dictionary<TKey, TVal>(this.validCount);
                for (int i = 0; i < this.validCount; i++)
                {
                    dictionary.Add(this.keyArray[i], this.valArray[i]);
                }
                return dictionary;
            }
        }

        public override string ToString()
        {
            return string.Format("Count:{0} ,Capacity:{1}", this.validCount, this.keyArray.Length);
        }

        public bool TryGet(TKey key, out TVal val)
        {
            val = default(TVal);
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                int index = this.IndexOfKey(key);
                if (index < 0)
                {
                    return false;
                }
                val = this.valArray[index];
                return true;
            }
        }

        public bool TryGetMaxKey(out TKey key)
        {
            key = default(TKey);
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return false;
                }
                key = this.keyArray[this.validCount - 1];
                return true;
            }
        }

        public bool TryGetMaxKey(out TKey key, out TVal val)
        {
            key = default(TKey);
            val = default(TVal);
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return false;
                }
                key = this.keyArray[this.validCount - 1];
                val = this.valArray[this.validCount - 1];
                return true;
            }
        }

        public bool TryGetMinKey(out TKey key)
        {
            key = default(TKey);
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return false;
                }
                key = this.keyArray[0];
                return true;
            }
        }

        public bool TryGetMinKey(out TKey key, out TVal val)
        {
            key = default(TKey);
            val = default(TVal);
            using (this.SmartRWLocker.Lock(AccessMode.Read))
            {
                if (this.validCount == 0)
                {
                    return false;
                }
                key = this.keyArray[0];
                val = this.valArray[0];
                return true;
            }
        }

        private int Capacity
        {
            get
            {
                return this.keyArray.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.validCount;
            }
        }

        public TVal this[TKey key]
        {
            get
            {
                using (this.SmartRWLocker.Lock(AccessMode.Read))
                {
                    int index = this.IndexOfKey(key);
                    if (index < 0)
                    {
                        throw new Exception(string.Format("SortedArray doesn't contain the key [{0}]", key));
                    }
                    return this.valArray[index];
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

