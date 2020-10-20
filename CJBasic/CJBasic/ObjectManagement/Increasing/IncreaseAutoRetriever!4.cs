namespace CJBasic.ObjectManagement.Increasing
{
    using CJBasic;
    using CJBasic.Collections;
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class IncreaseAutoRetriever<TSourceToken, TRoundID, TKey, TObject> : BaseCycleEngine, IIncreaseAutoRetriever<TSourceToken, TRoundID, TKey, TObject>
    {
        private object locker;
        private IDictionary<TSourceToken, TKey> maxKeyOfLastPhaseDictionary;
        private IPhaseIncreaseAccesser<TSourceToken, TRoundID, TKey, TObject> phaseIncreaseAccesser;

        public event CbException ExceptionOccurred;

        public event CbIncreasementRetrieved<TRoundID, TObject> IncreasementRetrieved;

        public IncreaseAutoRetriever()
        {
            this.locker = new object();
            this.IncreasementRetrieved += delegate {
            };
            this.ExceptionOccurred += delegate {
            };
        }

        protected override bool DoDetect()
        {
            bool flag2;
            try
            {
                lock (this.locker)
                {
                    IList<TObject> list3;
                    DateTime now = DateTime.Now;
                    List<TObject> list = new List<TObject>();
                    IDictionary<TSourceToken, TKey> lastKeyOfRoundDic = null;
                    IList<TSourceToken> list2 = CollectionConverter.CopyAllToList<TSourceToken>(this.maxKeyOfLastPhaseDictionary.Keys);
                    TRoundID currentRoundID = default(TRoundID);
                    bool isLastPhaseOfRound = this.phaseIncreaseAccesser.NextIsLastPhaseOfRound(now, out currentRoundID, out lastKeyOfRoundDic);
                    if (!isLastPhaseOfRound)
                    {
                        foreach (TSourceToken local2 in list2)
                        {
                            TKey maxKey = this.phaseIncreaseAccesser.GetMaxKey(now, local2);
                            list3 = this.phaseIncreaseAccesser.Retrieve(local2, this.maxKeyOfLastPhaseDictionary[local2], maxKey);
                            this.maxKeyOfLastPhaseDictionary[local2] = maxKey;
                            foreach (TObject local4 in list3)
                            {
                                list.Add(local4);
                            }
                        }
                    }
                    else
                    {
                        foreach (TSourceToken local2 in list2)
                        {
                            list3 = this.phaseIncreaseAccesser.Retrieve(local2, this.maxKeyOfLastPhaseDictionary[local2], lastKeyOfRoundDic[local2]);
                            this.maxKeyOfLastPhaseDictionary[local2] = lastKeyOfRoundDic[local2];
                            foreach (TObject local4 in list3)
                            {
                                list.Add(local4);
                            }
                        }
                    }
                    this.IncreasementRetrieved(list, currentRoundID, isLastPhaseOfRound);
                    flag2 = true;
                }
            }
            catch (Exception exception)
            {
                this.ExceptionOccurred(exception);
                flag2 = false;
            }
            return flag2;
        }

        public void Initialize()
        {
            this.maxKeyOfLastPhaseDictionary = this.phaseIncreaseAccesser.GetMaxKeyOfPreviousRound();
            base.Start();
        }

        public void ManualRefresh()
        {
            this.DoDetect();
        }

        public int AutoRetrieveSpanInSecs
        {
            get
            {
                return base.DetectSpanInSecs;
            }
            set
            {
                base.DetectSpanInSecs = value;
            }
        }

        public IPhaseIncreaseAccesser<TSourceToken, TRoundID, TKey, TObject> PhaseIncreaseAccesser
        {
            set
            {
                this.phaseIncreaseAccesser = value;
            }
        }
    }
}

