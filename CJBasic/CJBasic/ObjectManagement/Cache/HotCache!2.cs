namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic;
    using CJBasic.Collections;
    using CJBasic.ObjectManagement;
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class HotCache<TKey, TObject> : IEngineActor, IHotCache<TKey, TObject> where TObject: class
    {
        private AgileCycleEngine agileCycleEngine;
        private int detectSpanInSecs;
        private IDictionary<TKey, CachePackage<TKey, TObject>> dictionary;
        private long hitCount;
        private DateTime lastReadTime;
        private object locker;
        private int maxCachedCount;
        private int maxMuteSpanInMinutes;
        private long nonexistentCount;
        private IObjectRetriever<TKey, TObject> objectRetriever;
        private long requestCount;

        public event CbSimple CacheContentChanged;

        public HotCache()
        {
            this.dictionary = new Dictionary<TKey, CachePackage<TKey, TObject>>();
            this.locker = new object();
            this.objectRetriever = new EmptyObjectRetriever<TKey, TObject>();
            this.maxCachedCount = 0x7fffffff;
            this.maxMuteSpanInMinutes = 10;
            this.detectSpanInSecs = 600;
            this.requestCount = 0L;
            this.hitCount = 0L;
            this.nonexistentCount = 0L;
            this.lastReadTime = DateTime.Now;
            this.CacheContentChanged += delegate {
            };
        }

        public void Add(TKey id, TObject obj)
        {
            lock (this.locker)
            {
                if (this.dictionary.ContainsKey(id))
                {
                    this.dictionary.Remove(id);
                }
                this.dictionary.Add(id, new CachePackage<TKey, TObject>(id, obj));
                this.CacheContentChanged();
            }
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.dictionary.Clear();
                this.CacheContentChanged();
            }
        }

        public bool EngineAction()
        {
            lock (this.locker)
            {
                DateTime now = DateTime.Now;
                IList<TKey> list = new List<TKey>();
                foreach (CachePackage<TKey, TObject> package in this.dictionary.Values)
                {
                    TimeSpan span = (TimeSpan) (now - package.LastAccessTime);
                    if (span.TotalMinutes > this.maxMuteSpanInMinutes)
                    {
                        list.Add(package.ID);
                    }
                }
                foreach (TKey local in list)
                {
                    this.dictionary.Remove(local);
                }
                if (list.Count > 0)
                {
                    this.CacheContentChanged();
                }
            }
            return true;
        }

        public TObject Get(TKey id)
        {
            lock (this.locker)
            {
                this.lastReadTime = DateTime.Now;
                this.requestCount += 1L;
                if (this.dictionary.ContainsKey(id))
                {
                    this.hitCount += 1L;
                    return this.dictionary[id].Target;
                }
                TObject local = this.objectRetriever.Retrieve(id);
                if (local == null)
                {
                    this.nonexistentCount += 1L;
                }
                if ((local != null) && (this.dictionary.Count < this.maxCachedCount))
                {
                    this.dictionary.Add(id, new CachePackage<TKey, TObject>(id, local));
                    this.CacheContentChanged();
                }
                return local;
            }
        }

        public IList<TObject> GetAll()
        {
            this.lastReadTime = DateTime.Now;
            return CollectionConverter.ConvertAll<CachePackage<TKey, TObject>, TObject>(this.dictionary.Values, delegate (CachePackage<TKey, TObject> package) {
                return package.Target;
            });
        }

        public void Initialize()
        {
            if (this.maxMuteSpanInMinutes > 0)
            {
                this.agileCycleEngine = new AgileCycleEngine(this);
                this.agileCycleEngine.DetectSpanInSecs = this.detectSpanInSecs;
                this.agileCycleEngine.Start();
            }
        }

        public void Remove(TKey id)
        {
            lock (this.locker)
            {
                if (this.dictionary.ContainsKey(id))
                {
                    this.dictionary.Remove(id);
                    this.CacheContentChanged();
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

        public int DetectSpanInSecs
        {
            set
            {
                this.detectSpanInSecs = value;
            }
        }

        public long HitCount
        {
            get
            {
                return this.hitCount;
            }
        }

        public DateTime LastReadTime
        {
            get
            {
                return this.lastReadTime;
            }
        }

        public int MaxCachedCount
        {
            get
            {
                return this.maxCachedCount;
            }
            set
            {
                this.maxCachedCount = value;
            }
        }

        public int MaxMuteSpanInMinutes
        {
            set
            {
                this.maxMuteSpanInMinutes = value;
            }
        }

        public long NonexistentCount
        {
            get
            {
                return this.nonexistentCount;
            }
        }

        public IObjectRetriever<TKey, TObject> ObjectRetriever
        {
            set
            {
                this.objectRetriever = value;
            }
        }

        public long RequestCount
        {
            get
            {
                return this.requestCount;
            }
        }

        private sealed class CachePackage<TKey, TObject>
        {
            private TKey iD;
            private DateTime lastAccessTime;
            private TObject target;

            public CachePackage(TKey _iD, TObject _target)
            {
                this.lastAccessTime = DateTime.Now;
                this.iD = _iD;
                this.target = _target;
            }

            public TKey ID
            {
                get
                {
                    return this.iD;
                }
            }

            public DateTime LastAccessTime
            {
                get
                {
                    return this.lastAccessTime;
                }
            }

            public TObject Target
            {
                get
                {
                    this.lastAccessTime = DateTime.Now;
                    return this.target;
                }
            }
        }
    }
}

