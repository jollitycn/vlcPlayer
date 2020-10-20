namespace CJBasic.Threading.Application
{
    using CJBasic;
    using CJBasic.Threading.Engines;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class HeartBeatChecker : BaseCycleEngine, IHeartBeatChecker
    {
        private IDictionary<string, DateTime> dicIDTime;
        private object locker;
        private int surviveSpanInSecs;

        public event CbSimpleStr SomeOneTimeOuted;

        public HeartBeatChecker()
        {
            this.dicIDTime = new Dictionary<string, DateTime>();
            this.locker = new object();
            this.surviveSpanInSecs = 10;
            this.SomeOneTimeOuted += delegate {
            };
            base.DetectSpanInSecs = 5;
        }

        public HeartBeatChecker(int detectSpanInSecs, int _surviveSpanInSecs)
        {
            this.dicIDTime = new Dictionary<string, DateTime>();
            this.locker = new object();
            this.surviveSpanInSecs = 10;
            this.SomeOneTimeOuted += delegate {
            };
            base.DetectSpanInSecs = detectSpanInSecs;
            this.surviveSpanInSecs = _surviveSpanInSecs;
        }

        public void Clear()
        {
            lock (this.locker)
            {
                this.dicIDTime.Clear();
            }
        }

        protected override bool DoDetect()
        {
            IList<string> list = new List<string>();
            DateTime now = DateTime.Now;
            lock (this.locker)
            {
                foreach (string str in this.dicIDTime.Keys)
                {
                    TimeSpan span = (TimeSpan) (now - this.dicIDTime[str]);
                    if (span.TotalSeconds >= this.surviveSpanInSecs)
                    {
                        list.Add(str);
                    }
                }
                foreach (string str2 in list)
                {
                    this.dicIDTime.Remove(str2);
                }
            }
            foreach (string str2 in list)
            {
                this.SomeOneTimeOuted(str2);
            }
            return true;
        }

        public void Initialize()
        {
            if (this.surviveSpanInSecs > 0)
            {
                base.Start();
            }
        }

        public void RegisterOrActivate(string id)
        {
            lock (this.locker)
            {
                if (this.dicIDTime.ContainsKey(id))
                {
                    this.dicIDTime.Remove(id);
                }
                this.dicIDTime.Add(id, DateTime.Now);
            }
        }

        public void Unregister(string id)
        {
            lock (this.locker)
            {
                if (this.dicIDTime.ContainsKey(id))
                {
                    this.dicIDTime.Remove(id);
                }
            }
        }

        public int SurviveSpanInSecs
        {
            get
            {
                return this.surviveSpanInSecs;
            }
            set
            {
                this.surviveSpanInSecs = value;
            }
        }
    }
}

