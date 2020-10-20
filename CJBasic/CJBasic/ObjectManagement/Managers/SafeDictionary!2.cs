namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class SafeDictionary<TPKey, TObject> : IObjectManager<TPKey, TObject>
    {
        [NonSerialized]
        protected object locker;
        protected IDictionary<TPKey, TObject> objectDictionary;
        [NonSerialized]
        private List<TObject> readonlyCopy;

        public SafeDictionary()
        {
            this.objectDictionary = new Dictionary<TPKey, TObject>();
            this.readonlyCopy = null;
            this.locker = null;
        }

        public virtual void Add(TPKey key, TObject obj)
        {
            lock (this.Locker)
            {
                if (this.objectDictionary.ContainsKey(key))
                {
                    this.objectDictionary.Remove(key);
                }
                this.objectDictionary.Add(key, obj);
                this.readonlyCopy = null;
            }
        }

        public virtual void Clear()
        {
            lock (this.Locker)
            {
                this.objectDictionary.Clear();
                this.readonlyCopy = null;
            }
        }

        public bool Contains(TPKey id)
        {
            lock (this.Locker)
            {
                return this.objectDictionary.ContainsKey(id);
            }
        }

        public TObject Get(TPKey id)
        {
            lock (this.Locker)
            {
                if (this.objectDictionary.ContainsKey(id))
                {
                    return this.objectDictionary[id];
                }
            }
            return default(TObject);
        }

        public List<TObject> GetAll()
        {
            lock (this.Locker)
            {
                return CollectionConverter.CopyAllToList<TObject>(this.objectDictionary.Values);
            }
        }

        public List<TObject> GetAllReadonly()
        {
            lock (this.Locker)
            {
                if (this.readonlyCopy == null)
                {
                    this.readonlyCopy = new List<TObject>(this.objectDictionary.Values);
                }
                return this.readonlyCopy;
            }
        }

        public List<TPKey> GetKeyList()
        {
            lock (this.Locker)
            {
                return CollectionConverter.CopyAllToList<TPKey>(this.objectDictionary.Keys);
            }
        }

        public List<TPKey> GetKeyListByObj(TObject obj)
        {
            lock (this.Locker)
            {
                List<TPKey> list = new List<TPKey>();
                foreach (TPKey local in this.GetKeyList())
                {
                    TObject local2 = this.objectDictionary[local];
                    if (local2.Equals(obj))
                    {
                        list.Add(local);
                    }
                }
                return list;
            }
        }

        public virtual void Remove(TPKey id)
        {
            TObject local = default(TObject);
            lock (this.Locker)
            {
                if (this.objectDictionary.ContainsKey(id))
                {
                    local = this.objectDictionary[id];
                    this.objectDictionary.Remove(id);
                    this.readonlyCopy = null;
                }
            }
        }

        public void RemoveByPredication(Predicate<TObject> predicate)
        {
            lock (this.Locker)
            {
                List<TPKey> list = new List<TPKey>(this.objectDictionary.Keys);
                foreach (TPKey local in list)
                {
                    if (predicate(this.objectDictionary[local]))
                    {
                        this.objectDictionary.Remove(local);
                    }
                }
                this.readonlyCopy = null;
            }
        }

        public virtual void RemoveByValue(TObject val)
        {
            lock (this.Locker)
            {
                List<TPKey> list = new List<TPKey>(this.objectDictionary.Keys);
                foreach (TPKey local in list)
                {
                    TObject local2 = this.objectDictionary[local];
                    if (local2.Equals(val))
                    {
                        this.objectDictionary.Remove(local);
                    }
                }
                this.readonlyCopy = null;
            }
        }

        public Dictionary<TPKey, TObject> ToDictionary()
        {
            lock (this.Locker)
            {
                return new Dictionary<TPKey, TObject>(this.objectDictionary);
            }
        }

        public int Count
        {
            get
            {
                return this.objectDictionary.Count;
            }
        }

        protected object Locker
        {
            get
            {
                if (this.locker == null)
                {
                    this.locker = new object();
                }
                return this.locker;
            }
        }
    }
}

