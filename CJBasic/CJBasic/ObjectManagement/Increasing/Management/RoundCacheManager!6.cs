namespace CJBasic.ObjectManagement.Increasing.Management
{
    using CJBasic;
    using CJBasic.Collections;
    using CJBasic.ObjectManagement.Increasing;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public abstract class RoundCacheManager<TSourceToken, TRoundID, TRoundCache, TRoundIncreasingCache, TKey, TObject> where TRoundCache: class, IRoundCache<TRoundID> where TRoundIncreasingCache: class, IRoundIncreasingCache<TRoundID, TRoundCache, TObject>
    {
        private TRoundIncreasingCache currentRoundCache;
        private IIncreaseAutoRetriever<TSourceToken, TRoundID, TKey, TObject> increaseAutoRetriever;
        private DateTime lastRefreshTime;
        private int maxHistoryCountInMemory;
        private IDictionary<TRoundID, TRoundCache> roundCacheDictionary;
        private IRoundCachePersister<TRoundID, TRoundCache> roundCachePersister;

        public event CbGeneric<TRoundID> NewRoundStarted;

        public RoundCacheManager()
        {
            this.currentRoundCache = default(TRoundIncreasingCache);
            this.roundCacheDictionary = null;
            this.lastRefreshTime = DateTime.Now;
            this.maxHistoryCountInMemory = 1;
            this.NewRoundStarted += delegate {
            };
        }

        public void AddRoundCache(TRoundCache roundCache, bool toPersist)
        {
            if (toPersist)
            {
                this.roundCachePersister.Delete(roundCache.RoundID);
                this.roundCachePersister.Persist(roundCache);
            }
            IDictionary<TRoundID, TRoundCache> dictionary = new Dictionary<TRoundID, TRoundCache>();
            foreach (TRoundID local in this.roundCacheDictionary.Keys)
            {
                dictionary.Add(local, this.roundCacheDictionary[local]);
            }
            if (dictionary.ContainsKey(roundCache.RoundID))
            {
                dictionary.Remove(roundCache.RoundID);
            }
            dictionary.Add(roundCache.RoundID, roundCache);
            this.roundCacheDictionary = dictionary;
            IList<TRoundID> expiredHistoryList = this.GetExpiredHistoryList();
            if (expiredHistoryList != null)
            {
                foreach (TRoundID local2 in expiredHistoryList)
                {
                    this.RemoveRoundCache(local2, false);
                }
            }
        }

        public bool ContainsHistory(TRoundID roundID)
        {
            return this.roundCacheDictionary.ContainsKey(roundID);
        }

        protected abstract TRoundIncreasingCache CreateNewRoundIncreasingCache(TRoundID newRoundID);
        protected abstract IList<TRoundID> GetExpiredHistoryList();
        protected TRoundCache GetHistoryRoundCache(TRoundID roundID)
        {
            if (!this.roundCacheDictionary.ContainsKey(roundID))
            {
                return default(TRoundCache);
            }
            return this.roundCacheDictionary[roundID];
        }

        public IList<TRoundID> GetHistoryRoundIDList()
        {
            return (IList<TRoundID>) CollectionConverter.CopyAllToList<TRoundID>(this.roundCacheDictionary.Keys);
        }

        protected abstract TRoundID GetNextRoundID(TRoundID curRoundID);
        private void increaseAutoRetriever_IncreasementRetrieved(List<TObject> list, TRoundID currentRoundID, bool isLastPhaseOfRound)
        {
            if (this.currentRoundCache == null)
            {
                this.currentRoundCache = this.CreateNewRoundIncreasingCache(currentRoundID);
            }
            this.currentRoundCache.AddIncreasement(list);
            if (isLastPhaseOfRound)
            {
                TRoundCache roundCache = this.currentRoundCache.CreateRoundCache();
                TRoundID nextRoundID = this.GetNextRoundID(currentRoundID);
                this.currentRoundCache = this.CreateNewRoundIncreasingCache(nextRoundID);
                this.AddRoundCache(roundCache, true);
                this.NewRoundStarted(nextRoundID);
            }
            this.lastRefreshTime = DateTime.Now;
        }

        public virtual void Initialize()
        {
            this.increaseAutoRetriever.IncreasementRetrieved += new CbIncreasementRetrieved<TRoundID, TObject>(this.increaseAutoRetriever_IncreasementRetrieved);
            this.roundCacheDictionary = this.roundCachePersister.LoadCaches(this.maxHistoryCountInMemory);
            if (this.roundCacheDictionary == null)
            {
                this.roundCacheDictionary = new Dictionary<TRoundID, TRoundCache>();
            }
        }

        public void RemoveRoundCache(TRoundID targetRoundID, bool removeFromPersist)
        {
            if (removeFromPersist)
            {
                this.roundCachePersister.Delete(targetRoundID);
            }
            if (this.roundCacheDictionary.ContainsKey(targetRoundID))
            {
                IDictionary<TRoundID, TRoundCache> dictionary = new Dictionary<TRoundID, TRoundCache>();
                foreach (TRoundID local in this.roundCacheDictionary.Keys)
                {
                    dictionary.Add(local, this.roundCacheDictionary[local]);
                }
                dictionary.Remove(targetRoundID);
                this.roundCacheDictionary = dictionary;
            }
        }

        protected TRoundIncreasingCache CurrentRoundCache
        {
            get
            {
                return this.currentRoundCache;
            }
        }

        public TRoundID CurrentRoundID
        {
            get
            {
                return this.currentRoundCache.RoundID;
            }
        }

        public IIncreaseAutoRetriever<TSourceToken, TRoundID, TKey, TObject> IncreaseAutoRetriever
        {
            set
            {
                this.increaseAutoRetriever = value;
            }
        }

        public DateTime LastRefreshTime
        {
            get
            {
                return this.lastRefreshTime;
            }
        }

        public int MaxHistoryCountInMemory
        {
            get
            {
                return this.maxHistoryCountInMemory;
            }
            set
            {
                this.maxHistoryCountInMemory = value;
            }
        }

        public IRoundCachePersister<TRoundID, TRoundCache> RoundCachePersister
        {
            set
            {
                this.roundCachePersister = value;
            }
        }
    }
}

