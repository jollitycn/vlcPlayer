namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class TimingTaskManager
    {
        private object locker = new object();
        private IList<TimingTask> taskList = new List<TimingTask>();
        private Timer timer;
        private int timerSpanInSecs = 1;

        public void Initialize()
        {
            this.timer = new Timer(new TimerCallback(this.Worker), null, this.timerSpanInSecs * 0x3e8, this.timerSpanInSecs * 0x3e8);
        }

        private void RegisterTask(TimingTask task)
        {
            lock (this.locker)
            {
                this.taskList.Add(task);
            }
        }

        private void UnRegisterTask(TimingTask task)
        {
            lock (this.locker)
            {
                this.taskList.Remove(task);
            }
        }

        private void Worker(object state)
        {
            DateTime now = DateTime.Now;
            lock (this.locker)
            {
                foreach (TimingTask task in this.taskList)
                {
                    if (task.IsOnTime(this.timerSpanInSecs, now))
                    {
                        ITimingTaskExcuter timingTaskExcuter = task.TimingTaskExcuter;
                        new CbDateTime(timingTaskExcuter.ExcuteOnTime).BeginInvoke(now, null, null);
                    }
                }
            }
        }

        public IList<TimingTask> TaskList
        {
            get
            {
                return this.taskList;
            }
            set
            {
                this.taskList = value ?? new List<TimingTask>();
            }
        }

        public int TimerSpanInSecs
        {
            get
            {
                return this.timerSpanInSecs;
            }
            set
            {
                this.timerSpanInSecs = value;
                if (this.timerSpanInSecs < 1)
                {
                    this.timerSpanInSecs = 1;
                }
            }
        }
    }
}

