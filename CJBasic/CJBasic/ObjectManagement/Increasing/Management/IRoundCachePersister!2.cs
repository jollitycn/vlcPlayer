namespace CJBasic.ObjectManagement.Increasing.Management
{
    using System;
    using System.Collections.Generic;

    public interface IRoundCachePersister<TRoundID, TRoundCache> where TRoundCache: IRoundCache<TRoundID>
    {
        void Delete(TRoundID roundID);
        IDictionary<TRoundID, TRoundCache> LoadCaches(int maxHistoryCountInMemory);
        void Persist(TRoundCache roundCache);
    }
}

