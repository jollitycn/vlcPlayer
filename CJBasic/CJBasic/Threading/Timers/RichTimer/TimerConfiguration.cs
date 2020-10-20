namespace CJBasic.Threading.Timers.RichTimer
{
    using CJBasic;
    using CJBasic.Helpers;
    using System;

    [Serializable]
    public class TimerConfiguration
    {
        private int day = 1;
        private int dayOfWeek = 1;
        private int hour = 0;
        [NonSerialized]
        private DateTime lastRightTime = DateTime.Parse("2000-01-01 00:00:00");
        private int minute = 0;
        private CJBasic.Threading.Timers.RichTimer.RichTimerType richTimerType = CJBasic.Threading.Timers.RichTimer.RichTimerType.PerDay;
        private int second = 0;
        private CJBasic.ShortTimeScope shortTimeScope = new CJBasic.ShortTimeScope();
        private DateTime targetTimeForJustOnce = DateTime.Now;
        private DateScope validityDateScope = new DateScope();

        private bool CheckOnTime(int checkSpanSeconds, DateTime now)
        {
            if (this.IsExpired(now))
            {
                return false;
            }
            ShortTime target = new ShortTime(now);
            if (!this.ShortTimeScope.Contains(target))
            {
                return false;
            }
            DateTime requiredTime = new DateTime();
            switch (this.richTimerType)
            {
                case CJBasic.Threading.Timers.RichTimer.RichTimerType.PerHour:
                    requiredTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, this.minute, this.second);
                    break;

                case CJBasic.Threading.Timers.RichTimer.RichTimerType.PerDay:
                    requiredTime = new DateTime(now.Year, now.Month, now.Day, this.hour, this.minute, this.second);
                    break;

                case CJBasic.Threading.Timers.RichTimer.RichTimerType.PerWeek:
                    requiredTime = new DateTime(now.Year, now.Month, now.Day, this.hour, this.minute, this.second);
                    break;

                case CJBasic.Threading.Timers.RichTimer.RichTimerType.PerMonth:
                    requiredTime = new DateTime(now.Year, now.Month, this.Day, this.hour, this.minute, this.second);
                    break;

                case CJBasic.Threading.Timers.RichTimer.RichTimerType.EverySpan:
                {
                    int cycleSpanInSecs = ((this.hour * 0xe10) + (this.minute * 60)) + this.second;
                    return ((cycleSpanInSecs > 0) && TimeHelper.IsOnTime(this.shortTimeScope.ShortTimeStart.GetDateTime(), now, cycleSpanInSecs, checkSpanSeconds));
                }
                case CJBasic.Threading.Timers.RichTimer.RichTimerType.JustOnce:
                    requiredTime = this.targetTimeForJustOnce;
                    break;
            }
            return TimeHelper.IsOnTime(requiredTime, now, checkSpanSeconds);
        }

        public override bool Equals(object obj)
        {
            TimerConfiguration configuration = obj as TimerConfiguration;
            if (configuration == null)
            {
                return false;
            }
            return (this == configuration);
        }

        public bool IsExpired(DateTime now)
        {
            if (this.richTimerType == CJBasic.Threading.Timers.RichTimer.RichTimerType.JustOnce)
            {
                TimeSpan span = (TimeSpan) (now - this.targetTimeForJustOnce);
                return (span.TotalMilliseconds >= 10000.0);
            }
            return !this.validityDateScope.Contains(now);
        }

        public bool IsOnTime(int checkSpanSeconds, DateTime now)
        {
            TimeSpan span = (TimeSpan) (now - this.lastRightTime);
            if (span.TotalMilliseconds < ((checkSpanSeconds * 0x3e8) * 2))
            {
                return false;
            }
            bool flag = this.CheckOnTime(checkSpanSeconds, now);
            if (flag)
            {
                this.lastRightTime = now;
            }
            return flag;
        }

        public static bool operator ==(TimerConfiguration left, TimerConfiguration right)
        {
            if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null))
            {
                return true;
            }
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            bool flag = left.day == right.day;
            bool flag2 = left.dayOfWeek == right.dayOfWeek;
            bool flag3 = left.hour == right.hour;
            bool flag4 = left.minute == right.minute;
            bool flag5 = left.richTimerType == right.richTimerType;
            bool flag6 = left.second == right.second;
            bool flag7 = left.shortTimeScope == right.shortTimeScope;
            bool flag8 = left.validityDateScope == right.validityDateScope;
            return ((((flag && flag2) && (flag3 && flag4)) && ((flag5 && flag6) && flag7)) && flag8);
        }

        public static bool operator !=(TimerConfiguration left, TimerConfiguration right)
        {
            return !(left == right);
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

        public int DayOfWeek
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

        public int Hour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
            }
        }

        public int Minute
        {
            get
            {
                return this.minute;
            }
            set
            {
                this.minute = value;
            }
        }

        public CJBasic.Threading.Timers.RichTimer.RichTimerType RichTimerType
        {
            get
            {
                return this.richTimerType;
            }
            set
            {
                this.richTimerType = value;
            }
        }

        public int Second
        {
            get
            {
                return this.second;
            }
            set
            {
                this.second = value;
            }
        }

        public CJBasic.ShortTimeScope ShortTimeScope
        {
            get
            {
                return this.shortTimeScope;
            }
            set
            {
                this.shortTimeScope = value ?? new CJBasic.ShortTimeScope();
            }
        }

        public DateTime TargetTimeForJustOnce
        {
            get
            {
                return this.targetTimeForJustOnce;
            }
            set
            {
                this.targetTimeForJustOnce = value;
            }
        }

        public DateScope ValidityDateScope
        {
            get
            {
                return this.validityDateScope;
            }
            set
            {
                this.validityDateScope = value ?? new DateScope();
            }
        }
    }
}

