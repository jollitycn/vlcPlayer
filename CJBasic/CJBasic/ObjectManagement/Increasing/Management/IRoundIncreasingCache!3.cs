namespace CJBasic.ObjectManagement.Increasing.Management
{
    using System;
    using System.Collections.Generic;

    public interface IRoundIncreasingCache<TRoundID, TRoundCache, TObject> where TRoundCache: IRoundCache<TRoundID>
    {
        void AddIncreasement(IList<TObject> list);
        TRoundCache CreateRoundCache();

        TRoundID RoundID { get; }
    }
}

