namespace CJBasic.ObjectManagement.Increasing
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public interface IPhaseIncreaseAccesser<TSourceToken, TRoundID, TKey, TObject>
    {
        TKey GetMaxKey(DateTime now, TSourceToken token);
        IDictionary<TSourceToken, TKey> GetMaxKeyOfPreviousRound();
        bool NextIsLastPhaseOfRound(DateTime now, out TRoundID currentRoundID, out IDictionary<TSourceToken, TKey> lastKeyOfRoundDic);
        IList<TObject> Retrieve(TSourceToken token, TKey maxKeyOfPrePhase, TKey maxKeyOfThisPhase);
    }
}

