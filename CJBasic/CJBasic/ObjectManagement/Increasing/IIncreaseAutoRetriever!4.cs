namespace CJBasic.ObjectManagement.Increasing
{
    using CJBasic;
    using System;

    public interface IIncreaseAutoRetriever<TSourceToken, TRoundID, TKey, TObject>
    {
        event CbException ExceptionOccurred;

        event CbIncreasementRetrieved<TRoundID, TObject> IncreasementRetrieved;

        void Initialize();
        void ManualRefresh();

        int AutoRetrieveSpanInSecs { get; set; }

        IPhaseIncreaseAccesser<TSourceToken, TRoundID, TKey, TObject> PhaseIncreaseAccesser { set; }
    }
}

