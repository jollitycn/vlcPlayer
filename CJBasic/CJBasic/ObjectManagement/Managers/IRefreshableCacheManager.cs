namespace CJBasic.ObjectManagement.Managers
{
    using System;
    using System.Collections.Generic;

    public interface IRefreshableCacheManager
    {
        event CbCacheException CacheRefreshFailed;

        void AddCache(IRefreshableCache cache);
        void Initialize();
        void RefreshNow();
        void RemoveCache(IRefreshableCache cache);

        IList<IRefreshableCache> CacheList { set; }

        int RefreshSpanInSecs { set; }
    }
}

