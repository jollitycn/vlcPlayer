namespace CJBasic
{
    using System;

    [Serializable]
    public class Week
    {
        private Date monday;

        public Week() : this(DateTime.Now)
        {
        }

        public Week(Date _monday)
        {
            this.monday = _monday;
        }

        public Week(DateTime dt)
        {
            this.monday = this.GetLastMondayDate(dt);
        }

        public static Week Current()
        {
            return new Week();
        }

        private Date GetLastMondayDate(DateTime dt)
        {
            DateTime time = dt;
            while (time.DayOfWeek != DayOfWeek.Monday)
            {
                time = time.AddDays(-1.0);
            }
            return new Date(time);
        }

        public Week GetNextWeek()
        {
            return new Week(this.monday.AddDays(7));
        }

        public Week GetPreviousWeek()
        {
            return new Week(this.monday.AddDays(-7));
        }

        public override string ToString()
        {
            return string.Format("Monday:{0}", this.monday);
        }

        public Date Monday
        {
            get
            {
                return this.monday;
            }
        }
    }
}

