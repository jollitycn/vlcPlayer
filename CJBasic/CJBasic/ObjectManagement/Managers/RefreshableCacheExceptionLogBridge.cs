namespace CJBasic.ObjectManagement.Managers
{
    using CJBasic.Loggers;
    using System;

    public class RefreshableCacheExceptionLogBridge
    {
        private IAgileLogger agileLogger;
        private IRefreshableCacheManager refreshableCacheManager;

        private void cacheManager_CacheRefreshFailed(IRefreshableCache cache, Exception ee)
        {
            string location = string.Format("CJBasic.ObjectManagement.Managers.RefreshableCacheManager.EngineAction : [{0}]", cache.GetType().ToString());
            this.agileLogger.LogSimple(ee, location, ErrorLevel.Standard);
        }

        public void Initialize()
        {
            this.refreshableCacheManager.CacheRefreshFailed += new CbCacheException(this.cacheManager_CacheRefreshFailed);
        }

        public IAgileLogger AgileLogger
        {
            set
            {
                this.agileLogger = value;
            }
        }

        public IRefreshableCacheManager RefreshableCacheManager
        {
            set
            {
                this.refreshableCacheManager = value;
            }
        }
    }
}

