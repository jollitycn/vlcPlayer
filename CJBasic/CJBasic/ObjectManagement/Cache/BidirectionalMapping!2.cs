namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.Collections;
    using CJBasic.Threading.Synchronize;
    using System;
    using System.Collections.Generic;

    public class BidirectionalMapping<T1, T2>
    {
        private IDictionary<T1, T2> dictionary;
        private IDictionary<T2, T1> reversedDictionary;
        private SmartRWLocker smartRWLocker;

        public BidirectionalMapping()
        {
            this.dictionary = new Dictionary<T1, T2>();
            this.reversedDictionary = new Dictionary<T2, T1>();
            this.smartRWLocker = new SmartRWLocker();
        }

        public void Add(T1 t1, T2 t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.dictionary.ContainsKey(t1))
                {
                    this.dictionary.Remove(t1);
                }
                this.dictionary.Add(t1, t2);
                if (this.reversedDictionary.ContainsKey(t2))
                {
                    this.reversedDictionary.Remove(t2);
                }
                this.reversedDictionary.Add(t2, t1);
            }
        }

        public void Clear()
        {
            this.dictionary.Clear();
            this.reversedDictionary.Clear();
        }

        public bool ContainsT1(T1 t1)
        {
            return this.dictionary.ContainsKey(t1);
        }

        public bool ContainsT2(T2 t2)
        {
            return this.reversedDictionary.ContainsKey(t2);
        }

        public IList<T1> GetAllT1ListCopy()
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                return CollectionConverter.CopyAllToList<T1>(this.dictionary.Keys);
            }
        }

        public IList<T2> GetAllT2ListCopy()
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                return (IList<T2>) CollectionConverter.CopyAllToList<T2>(this.reversedDictionary.Keys);
            }
        }

        public T1 GetT1(T2 t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                if (!this.reversedDictionary.ContainsKey(t2))
                {
                    return default(T1);
                }
                return this.reversedDictionary[t2];
            }
        }

        public T2 GetT2(T1 t1)
        {
            using (this.smartRWLocker.Lock(AccessMode.Read))
            {
                if (!this.dictionary.ContainsKey(t1))
                {
                    return default(T2);
                }
                return this.dictionary[t1];
            }
        }

        public void RemoveByT1(T1 t1)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.dictionary.ContainsKey(t1))
                {
                    T2 key = this.dictionary[t1];
                    this.dictionary.Remove(t1);
                    this.reversedDictionary.Remove(key);
                }
            }
        }

        public void RemoveByT2(T2 t2)
        {
            using (this.smartRWLocker.Lock(AccessMode.Write))
            {
                if (this.reversedDictionary.ContainsKey(t2))
                {
                    T1 key = this.reversedDictionary[t2];
                    this.reversedDictionary.Remove(t2);
                    this.dictionary.Remove(key);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.dictionary.Count;
            }
        }
    }
}

