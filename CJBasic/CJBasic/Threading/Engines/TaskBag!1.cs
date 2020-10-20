namespace CJBasic.Threading.Engines
{
    using System;

    internal class TaskBag<TTask>
    {
        private DateTime addedTime;
        private DateTime lastActionTime;
        private int retryCount;
        private int spanInSecsIfRetry;
        private TTask task;

        public TaskBag()
        {
            this.addedTime = DateTime.Now;
            this.lastActionTime = DateTime.Now;
            this.spanInSecsIfRetry = 1;
            this.retryCount = 0;
        }

        public TaskBag(TTask t, int span)
        {
            this.addedTime = DateTime.Now;
            this.lastActionTime = DateTime.Now;
            this.spanInSecsIfRetry = 1;
            this.retryCount = 0;
            this.task = t;
            this.spanInSecsIfRetry = span;
        }

        public DateTime AddedTime
        {
            get
            {
                return this.addedTime;
            }
            set
            {
                this.addedTime = value;
            }
        }

        public DateTime LastActionTime
        {
            get
            {
                return this.lastActionTime;
            }
            set
            {
                this.lastActionTime = value;
            }
        }

        public int RetryCount
        {
            get
            {
                return this.retryCount;
            }
            set
            {
                this.retryCount = value;
            }
        }

        public int SpanInSecsIfRetry
        {
            get
            {
                return this.spanInSecsIfRetry;
            }
            set
            {
                this.spanInSecsIfRetry = value;
            }
        }

        public TTask Task
        {
            get
            {
                return this.task;
            }
            set
            {
                this.task = value;
            }
        }
    }
}

