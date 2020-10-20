namespace CJBasic
{
    using CJBasic.Helpers;
    using System;

    [Serializable]
    public class ShortTime : IComparable<ShortTime>
    {
        private int hour;
        private int minute;
        private int second;

        public ShortTime()
        {
            this.hour = 0;
            this.minute = 0;
            this.second = 0;
        }

        public ShortTime(DateTime time)
        {
            this.hour = 0;
            this.minute = 0;
            this.second = 0;
            this.Hour = time.Hour;
            this.Minute = time.Minute;
            this.Second = time.Second;
        }

        public ShortTime(int h, int m, int s)
        {
            this.hour = 0;
            this.minute = 0;
            this.second = 0;
            this.Hour = h;
            this.Minute = m;
            this.Second = s;
        }

        public int CompareTo(ShortTime other)
        {
            if (((this.hour != other.hour) || (this.minute != other.minute)) || (this.second != other.second))
            {
                int num = this.hour - other.hour;
                int num2 = this.minute - other.minute;
                int num3 = this.second - other.second;
                if (num > 0)
                {
                    return 1;
                }
                if (num < 0)
                {
                    return -1;
                }
                if (num2 > 0)
                {
                    return 1;
                }
                if (num2 < 0)
                {
                    return -1;
                }
                if (num3 > 0)
                {
                    return 1;
                }
                if (num3 < 0)
                {
                    return -1;
                }
            }
            return 0;
        }

        public DateTime GetDateTime()
        {
            DateTime now = DateTime.Now;
            return this.GetDateTime(now.Year, now.Month, now.Day);
        }

        public DateTime GetDateTime(int year, int month, int day)
        {
            DateTime now = DateTime.Now;
            return new DateTime(year, month, day, this.hour, this.minute, this.second);
        }

        public bool IsOnTime(DateTime target, int maxToleranceInSecs)
        {
            DateTime requiredTime = this.GetDateTime(target.Year, target.Month, target.Day);
            return (TimeHelper.IsOnTime(requiredTime, target, maxToleranceInSecs) || (TimeHelper.IsOnTime(requiredTime.AddDays(1.0), target, maxToleranceInSecs) || TimeHelper.IsOnTime(requiredTime.AddDays(-1.0), target, maxToleranceInSecs)));
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", this.hour, this.minute, this.second);
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
                this.hour = (this.hour > 0x17) ? 0x17 : this.hour;
                this.hour = (this.hour < 0) ? 0 : this.hour;
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
                this.minute = (this.minute > 0x3b) ? 0x3b : this.minute;
                this.minute = (this.minute < 0) ? 0 : this.minute;
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
                this.second = (this.second > 0x3b) ? 0x3b : this.second;
                this.second = (this.second < 0) ? 0 : this.second;
            }
        }

        public string ShortTimeString
        {
            set
            {
                string[] strArray = value.Split(new char[] { ':' });
                this.Hour = int.Parse(strArray[0]);
                this.Minute = int.Parse(strArray[1]);
                this.Second = int.Parse(strArray[2]);
            }
        }
    }
}

