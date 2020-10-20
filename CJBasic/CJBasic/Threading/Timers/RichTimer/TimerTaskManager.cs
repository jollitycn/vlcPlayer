namespace CJBasic.Threading.Timers.RichTimer
{
    using CJBasic.Loggers;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class TimerTaskManager : ITimerTaskManager, IDisposable
    {
        private IDictionary<string, TimerTask> dicTimerContent = new Dictionary<string, TimerTask>();
        private ILogger logger = new EmptyLogger();
        private Timer timer;
        private int timerSpanSecs = 1;

        public event CbTimerTask TimerTaskExpired;

        public TimerTaskManager()
        {
            this.TimerTaskExpired += delegate {
            };
        }

        public void AddTimerTask(TimerTask task)
        {
            lock (this.dicTimerContent)
            {
                if (this.dicTimerContent.ContainsKey(task.Name))
                {
                    this.dicTimerContent.Remove(task.Name);
                }
                this.dicTimerContent.Add(task.Name, task);
            }
        }

        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
            }
        }

        public TimerTask GetTimerTask(string timerName)
        {
            lock (this.dicTimerContent)
            {
                if (this.dicTimerContent.ContainsKey(timerName))
                {
                    return this.dicTimerContent[timerName];
                }
                return null;
            }
        }

        public void Initialize()
        {
            this.timer = new Timer(new TimerCallback(this.Worker), null, this.timerSpanSecs * 0x3e8, this.timerSpanSecs * 0x3e8);
        }

        public void RemoveTimerTask(string timerName)
        {
            lock (this.dicTimerContent)
            {
                this.dicTimerContent.Remove(timerName);
            }
        }

        protected void Worker(object state)
        {
            DateTime now = DateTime.Now;
            IList<TimerTask> list = new List<TimerTask>();
            lock (this.dicTimerContent)
            {
                foreach (TimerTask task in this.dicTimerContent.Values)
                {
                    if (task.IsExpired(now))
                    {
                        list.Add(task);
                    }
                    else
                    {
                        try
                        {
                            task.HaveATry(this.timerSpanSecs, now);
                        }
                        catch (Exception exception)
                        {
                            this.logger.LogWithTime("TimerTaskManager.Worker -- " + exception.Message);
                        }
                    }
                }
                foreach (TimerTask task in list)
                {
                    this.dicTimerContent.Remove(task.Name);
                }
            }
            foreach (TimerTask task in list)
            {
                try
                {
                    this.TimerTaskExpired(task);
                }
                catch
                {
                }
            }
        }

        public ILogger Logger
        {
            set
            {
                this.logger = value ?? new EmptyLogger();
            }
        }

        public int TimerSpanSecs
        {
            get
            {
                return this.timerSpanSecs;
            }
            set
            {
                this.timerSpanSecs = value;
            }
        }

        public IList<TimerTask> TimerTaskList
        {
            get
            {
                IList<TimerTask> list = new List<TimerTask>();
                lock (this.dicTimerContent)
                {
                    foreach (TimerTask task in this.dicTimerContent.Values)
                    {
                        list.Add(task);
                    }
                }
                return list;
            }
        }
    }
}

