namespace CJBasic.ObjectManagement.Cache
{
    using CJBasic;
    using CJBasic.ObjectManagement;
    using System;
    using System.Collections.Generic;

    public interface IHotCache<TKey, TObject> where TObject: class
    {
        event CbSimple CacheContentChanged;

        void Add(TKey id, TObject obj);
        void Clear();
        TObject Get(TKey id);
        IList<TObject> GetAll();
        void Initialize();
        void Remove(TKey id);

        int Count { get; }

        int DetectSpanInSecs { set; }

        long HitCount { get; }

        DateTime LastReadTime { get; }

        int MaxCachedCount { get; set; }

        int MaxMuteSpanInMinutes { set; }

        IObjectRetriever<TKey, TObject> ObjectRetriever { set; }

        long RequestCount { get; }
    }
}

