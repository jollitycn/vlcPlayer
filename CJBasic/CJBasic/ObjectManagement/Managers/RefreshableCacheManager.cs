namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class RefreshableCacheManager : IRefreshableCacheManager, IEngineActor
    {
        private AgileCycleEngine agileCycleEngine;
        private IList<IRefreshableCache> cacheList = new List<IRefreshableCache>();
        private object locker = new object();
        private int refreshSpanInSecs = 60;

        public event CbCacheException CacheRefreshFailed;

        public RefreshableCacheManager()
        {
            this.CacheRefreshFailed += delegate {
            };
        }

        public void AddCache(IRefreshableCache cache)
        {
            lock (this.locker)
            {
                this.cacheList.Add(cache);
            }
        }

        public bool EngineAction()
        {
            lock (this.locker)
            {
                foreach (IRefreshableCache cache in this.cacheList)
                {
                    try
                    {
                        int refreshSpanInSecs = cache.RefreshSpanInSecs;
                        if (refreshSpanInSecs <= 0)
                        {
                            refreshSpanInSecs = this.refreshSpanInSecs;
                        }
                        TimeSpan span = (TimeSpan) (DateTime.Now - cache.LastRefreshTime);
                        if (span.TotalSeconds >= refreshSpanInSecs)
                        {
                            cache.Refresh();
                            cache.LastRefreshTime = DateTime.Now;
                        }
                    }
                    catch (Exception exception)
                    {
                        this.CacheRefreshFailed(cache, exception);
                    }
                }
                return true;
            }
        }

        public void Initialize()
        {
            if (this.refreshSpanInSecs <= 0)
            {
                throw new Exception("RefreshSpanInSecs Property must be greater than 0 !");
            }
            foreach (IRefreshableCache cache in this.cacheList)
            {
                cache.LastRefreshTime = DateTime.Now;
            }
            this.agileCycleEngine = new AgileCycleEngine(this);
            this.agileCycleEngine.DetectSpanInSecs = 1;
            this.agileCycleEngine.Start();
        }

        public void RefreshNow()
        {
            this.EngineAction();
        }

        public void RemoveCache(IRefreshableCache cache)
        {
            lock (this.locker)
            {
                this.cacheList.Remove(cache);
            }
        }

        public IList<IRefreshableCache> CacheList
        {
            set
            {
                this.cacheList = value ?? new List<IRefreshableCache>();
            }
        }

        public int RefreshSpanInSecs
        {
            set
            {
                this.refreshSpanInSecs = value;
            }
        }
    }
}

