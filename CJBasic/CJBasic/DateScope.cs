namespace CJBasic
{
    using System;

    [Serializable]
    public class DateScope
    {
        private Date end;
        private Date start;

        public DateScope()
        {
            this.start = new Date(0x7d0, 1, 1);
            this.end = new Date(0x834, 12, 0x1f);
        }

        public DateScope(Date s, Date e)
        {
            this.start = new Date(0x7d0, 1, 1);
            this.end = new Date(0x834, 12, 0x1f);
            this.start = s;
            this.end = e;
        }

        public bool Contains(Date target)
        {
            bool flag = this.start.CompareTo(target) <= 0;
            bool flag2 = this.end.CompareTo(target) >= 0;
            return (flag && flag2);
        }

        public bool Contains(DateTime target)
        {
            return this.Contains(new Date(target));
        }

        public override bool Equals(object obj)
        {
            DateScope scope = obj as DateScope;
            if (scope == null)
            {
                return false;
            }
            return (this == scope);
        }

        public static bool operator ==(DateScope left, DateScope right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            bool flag = left.Start.CompareTo(right.Start) == 0;
            bool flag2 = left.End.CompareTo(right.End) == 0;
            return (flag && flag2);
        }

        public static bool operator !=(DateScope left, DateScope right)
        {
            return !(left == right);
        }

        public Date End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }

        public Date Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }
    }
}

