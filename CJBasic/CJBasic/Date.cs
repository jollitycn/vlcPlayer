namespace CJBasic
{
    using System;

    [Serializable]
    public class Date : IComparable<Date>
    {
        private int day;
        private int month;
        private int year;

        public Date() : this(DateTime.Now)
        {
        }

        public Date(DateTime dt)
        {
            this.year = 0x76c;
            this.month = 1;
            this.day = 1;
            this.Year = dt.Year;
            this.Month = dt.Month;
            this.day = dt.Day;
        }

        public Date(string date)
        {
            this.year = 0x76c;
            this.month = 1;
            this.day = 1;
            string[] strArray = date.Split(new char[] { '-' });
            DateTime time = new DateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]));
            this.Year = time.Year;
            this.Month = time.Month;
            this.day = time.Day;
        }

        public Date(int y, int m, int d) : this(new DateTime(y, m, d))
        {
        }

        public Date AddDays(int days)
        {
            DateTime time = new DateTime(this.year, this.month, this.day);
            return new Date(time.AddDays((double) days));
        }

        public int CompareTo(Date other)
        {
            if (((this.year != other.year) || (this.month != other.month)) || (this.day != other.day))
            {
                int num = this.year - other.year;
                int num2 = this.month - other.month;
                int num3 = this.day - other.day;
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

        public static Date FromDateInteger(int theDate)
        {
            int y = theDate / 0x2710;
            int m = (theDate % 0x2710) / 100;
            return new Date(y, m, (theDate % 0x2710) % 100);
        }

        public bool IsSameDate(DateTime dt)
        {
            return (this.CompareTo(new Date(dt)) == 0);
        }

        public int ToDateInteger()
        {
            return (((this.Year * 0x2710) + (this.Month * 100)) + this.Day);
        }

        public DateTime ToDateTime()
        {
            return this.ToDateTime(0, 0, 0);
        }

        public DateTime ToDateTime(int hour, int minute, int second)
        {
            return new DateTime(this.year, this.month, this.day, hour, minute, second);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", this.year, this.month, this.day);
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

        public DateTime DayEndTime
        {
            get
            {
                return this.ToDateTime(0, 0, 0).AddDays(1.0);
            }
        }

        public DateTime DayStartTime
        {
            get
            {
                return this.ToDateTime(0, 0, 0);
            }
        }

        public int Month
        {
            get
            {
                return this.month;
            }
            set
            {
                this.month = value;
                if (this.month > 12)
                {
                    this.month = 12;
                }
                if (this.month < 1)
                {
                    this.month = 1;
                }
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
    }
}

