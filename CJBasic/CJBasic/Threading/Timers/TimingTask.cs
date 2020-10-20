namespace CJBasic.Threading.Timers
{
    using CJBasic;
    using System;

    [Serializable]
    public class TimingTask
    {
        private int day = 1;
        private System.DayOfWeek dayOfWeek = System.DayOfWeek.Monday;
        private ShortTime excuteTime = new ShortTime();
        [NonSerialized]
        private DateTime lastRightTime = DateTime.Parse("2000-01-01 00:00:00");
        private ITimingTaskExcuter timingTaskExcuter;
        private CJBasic.Threading.Timers.TimingTaskType timingTaskType = CJBasic.Threading.Timers.TimingTaskType.PerDay;

        public bool IsOnTime(int checkSpanSeconds, DateTime now)
        {
            TimeSpan span = (TimeSpan) (now - this.lastRightTime);
            if (span.TotalMilliseconds < ((checkSpanSeconds * 0x3e8) * 2))
            {
                return false;
            }
            bool flag = false;
            switch (this.timingTaskType)
            {
                case CJBasic.Threading.Timers.TimingTaskType.PerHour:
                    flag = new ShortTime(now.Hour, this.excuteTime.Minute, this.excuteTime.Second).IsOnTime(now, checkSpanSeconds);
                    if (!flag)
                    {
                        flag = new ShortTime(now.AddHours(1.0).Hour, this.excuteTime.Minute, this.excuteTime.Second).IsOnTime(now, checkSpanSeconds);
                    }
                    if (!flag)
                    {
                        flag = new ShortTime(now.AddHours(-1.0).Hour, this.excuteTime.Minute, this.excuteTime.Second).IsOnTime(now, checkSpanSeconds);
                    }
                    break;

                case CJBasic.Threading.Timers.TimingTaskType.PerDay:
                    flag = this.excuteTime.IsOnTime(now, checkSpanSeconds);
                    break;

                case CJBasic.Threading.Timers.TimingTaskType.PerWeek:
                    if (now.DayOfWeek == this.dayOfWeek)
                    {
                        flag = this.excuteTime.IsOnTime(now, checkSpanSeconds);
                        break;
                    }
                    flag = false;
                    break;

                case CJBasic.Threading.Timers.TimingTaskType.PerMonth:
                    if (now.Day == this.day)
                    {
                        flag = this.excuteTime.IsOnTime(now, checkSpanSeconds);
                        break;
                    }
                    flag = false;
                    break;
            }
            if (flag)
            {
                this.lastRightTime = now;
            }
            return flag;
        }

        public int Day
        {
            get
            {
                return this.day;
            }
            set
            {
                this.day = value;
            }
        }

        public System.DayOfWeek DayOfWeek
        {
            get
            {
                return this.dayOfWeek;
            }
            set
            {
                this.dayOfWeek = value;
            }
        }

        public ShortTime ExcuteTime
        {
            get
            {
                return this.excuteTime;
            }
            set
            {
                this.excuteTime = value;
            }
        }

        public ITimingTaskExcuter TimingTaskExcuter
        {
            get
            {
                return this.timingTaskExcuter;
            }
            set
            {
                this.timingTaskExcuter = value;
            }
        }

        public CJBasic.Threading.Timers.TimingTaskType TimingTaskType
        {
            get
            {
                return this.timingTaskType;
            }
            set
            {
                this.timingTaskType = value;
            }
        }
    }
}

