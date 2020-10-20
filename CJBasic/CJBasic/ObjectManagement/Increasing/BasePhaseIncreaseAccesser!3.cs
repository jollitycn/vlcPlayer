namespace CJBasic.ObjectManagement.Increasing
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public abstract class BasePhaseIncreaseAccesser<TSourceToken, TKey, TObject> : IPhaseIncreaseAccesser<TSourceToken, int, TKey, TObject>
    {
        private DateTime currentRoundStartTime;
        private ShortTime dayOriginTime;
        private int manyDaysInOneRound;
        private IList<TSourceToken> sourceTokenList;
        private bool todayIsFirstDay;

        protected BasePhaseIncreaseAccesser()
        {
            this.currentRoundStartTime = DateTime.Now;
            this.dayOriginTime = new ShortTime(0, 0, 0);
            this.manyDaysInOneRound = 1;
            this.todayIsFirstDay = false;
            this.sourceTokenList = new List<TSourceToken>();
        }

        public TKey GetMaxKey(DateTime now, TSourceToken token)
        {
            return this.GetMaxKey(now, token, true);
        }

        protected abstract TKey GetMaxKey(DateTime endTime, TSourceToken token, bool containsEndTime);
        protected IDictionary<TSourceToken, TKey> GetMaxKeyBefore(DateTime endTime)
        {
            Dictionary<TSourceToken, TKey> dictionary = new Dictionary<TSourceToken, TKey>();
            foreach (TSourceToken local in this.sourceTokenList)
            {
                TKey local2 = this.GetMaxKey(endTime, local, false);
                dictionary.Add(local, local2);
            }
            return dictionary;
        }

        public IDictionary<TSourceToken, TKey> GetMaxKeyOfPreviousRound()
        {
            return this.GetMaxKeyBefore(this.currentRoundStartTime);
        }

        public virtual void Initialize()
        {
            if ((this.sourceTokenList == null) || (this.sourceTokenList.Count == 0))
            {
                throw new Exception("There is no any SourceToken object in SourceTokenList !");
            }
            DateTime now = DateTime.Now;
            DateTime time = DateTime.Now;
            if (this.dayOriginTime.CompareTo(new ShortTime(time)) <= 0)
            {
                now = this.dayOriginTime.GetDateTime(time.Year, time.Month, time.Day);
            }
            else
            {
                DateTime time3 = time.AddDays(-1.0);
                now = this.dayOriginTime.GetDateTime(time3.Year, time3.Month, time3.Day);
            }
            this.currentRoundStartTime = this.todayIsFirstDay ? now : now.AddDays((double) (1 - this.manyDaysInOneRound));
        }

        public bool NextIsLastPhaseOfRound(DateTime now, out int currentRoundID, out IDictionary<TSourceToken, TKey> lastKeyOfRoundDic)
        {
            currentRoundID = new Date(this.currentRoundStartTime).ToDateInteger();
            lastKeyOfRoundDic = null;
            TimeSpan span = (TimeSpan) (now - this.currentRoundStartTime);
            bool flag = span.TotalDays >= this.manyDaysInOneRound;
            if (flag)
            {
                DateTime endTime = this.dayOriginTime.GetDateTime(now.Year, now.Month, now.Day);
                lastKeyOfRoundDic = this.GetMaxKeyBefore(endTime);
                this.currentRoundStartTime = endTime;
            }
            return flag;
        }

        public abstract IList<TObject> Retrieve(TSourceToken token, TKey maxKeyOfPrePhase, TKey maxKeyOfThisPhase);

        public DateTime CurrentRoundStartTime
        {
            get
            {
                return this.currentRoundStartTime;
            }
        }

        public ShortTime DayOriginTime
        {
            get
            {
                return this.dayOriginTime;
            }
            set
            {
                this.dayOriginTime = value;
            }
        }

        public int ManyDaysInOneRound
        {
            get
            {
                return this.manyDaysInOneRound;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("The value of Property [ManyDaysInOneRound] must be greater than 1.");
                }
                this.manyDaysInOneRound = value;
            }
        }

        public IList<TSourceToken> SourceTokenList
        {
            set
            {
                this.sourceTokenList = value;
            }
        }

        public bool TodayIsFirstDay
        {
            get
            {
                return this.todayIsFirstDay;
            }
            set
            {
                this.todayIsFirstDay = value;
            }
        }
    }
}

