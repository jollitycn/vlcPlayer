namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic.Collections;
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;

    public class SmartDictionaryCache<Tkey, TVal> : ISmartDictionaryCache<Tkey, TVal>
    {
        private IDictionary<Tkey, TVal> ditionary;
        private bool enabled;
        private object locker;
        private IObjectRetriever<Tkey, TVal> objectRetriever;

        public SmartDictionaryCache()
        {
            this.ditionary = new Dictionary<Tkey, TVal>();
            this.locker = new object();
            this.enabled = true;
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.ditionary.Clear();
            }
        }

        public TVal Get(Tkey id)
        {
            if (id == null)
            {
                return default(TVal);
            }
            if (!this.enabled)
            {
                return this.objectRetriever.Retrieve(id);
            }
            lock (this.locker)
            {
                if (this.ditionary.ContainsKey(id))
                {
                    return this.ditionary[id];
                }
                TVal local = this.objectRetriever.Retrieve(id);
                if (local != null)
                {
                    this.ditionary.Add(id, local);
                }
                return local;
            }
        }

        public IList<Tkey> GetAllKeyListCopy()
        {
            lock (this.locker)
            {
                return CollectionConverter.CopyAllToList<Tkey>(this.ditionary.Keys);
            }
        }

        public IList<TVal> GetAllValListCopy()
        {
            lock (this.locker)
            {
                return new List<TVal>(this.ditionary.Values);
            }
        }

        public bool HaveContained(Tkey id)
        {
            if (id == null)
            {
                return false;
            }
            return this.ditionary.ContainsKey(id);
        }

        public void Initialize()
        {
            if (this.enabled)
            {
                this.ditionary = this.objectRetriever.RetrieveAll() ?? new Dictionary<Tkey, TVal>();
            }
        }

        public int Count
        {
            get
            {
                return this.ditionary.Count;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public IObjectRetriever<Tkey, TVal> ObjectRetriever
        {
            set
            {
                this.objectRetriever = value;
            }
        }
    }
}

