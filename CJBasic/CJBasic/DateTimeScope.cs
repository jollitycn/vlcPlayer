namespace CJBasic
{
    using System;

    [Serializable]
    public class DateTimeScope
    {
        private DateTime endDate;
        private DateTime startDate;

        public DateTimeScope()
        {
            this.startDate = DateTime.MinValue;
            this.endDate = DateTime.MaxValue;
        }

        public DateTimeScope(DateTime start, DateTime end)
        {
            this.startDate = DateTime.MinValue;
            this.endDate = DateTime.MaxValue;
            this.StartDate = start;
            this.EndDate = end;
        }

        public bool Contains(DateTime target)
        {
            return ((target >= this.startDate) && (target <= this.endDate));
        }

        public override bool Equals(object obj)
        {
            DateTimeScope scope = obj as DateTimeScope;
            if (scope == null)
            {
                return false;
            }
            return (this == scope);
        }

        public static bool operator ==(DateTimeScope left, DateTimeScope right)
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
            bool flag = left.startDate == right.startDate;
            bool flag2 = left.endDate == right.endDate;
            return (flag && flag2);
        }

        public static bool operator !=(DateTimeScope left, DateTimeScope right)
        {
            return !(left == right);
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }
    }
}

