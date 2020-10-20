namespace CJBasic
{
    using System;

    [Serializable]
    public class ShortTimeScope
    {
        private ShortTime shortTimeEnd;
        private ShortTime shortTimeStart;

        public ShortTimeScope()
        {
            this.shortTimeStart = new ShortTime(0, 0, 0);
            this.shortTimeEnd = new ShortTime(0x18, 0, 0);
        }

        public ShortTimeScope(ShortTime first, ShortTime later)
        {
            this.shortTimeStart = new ShortTime(0, 0, 0);
            this.shortTimeEnd = new ShortTime(0x18, 0, 0);
            this.shortTimeStart = first;
            this.shortTimeEnd = later;
            if (first.CompareTo(later) >= 0)
            {
                throw new Exception("the parameter later must be greatter than first!");
            }
        }

        public bool Contains(ShortTime target)
        {
            bool flag = this.shortTimeStart.CompareTo(target) <= 0;
            bool flag2 = this.shortTimeEnd.CompareTo(target) >= 0;
            return (flag && flag2);
        }

        public bool Contains(DateTime target)
        {
            return this.Contains(new ShortTime(target));
        }

        public override bool Equals(object obj)
        {
            ShortTimeScope scope = obj as ShortTimeScope;
            if (scope == null)
            {
                return false;
            }
            return (this == scope);
        }

        public static bool operator ==(ShortTimeScope left, ShortTimeScope right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }
            bool flag = left.ShortTimeStart.CompareTo(right.ShortTimeStart) == 0;
            bool flag2 = left.ShortTimeEnd.CompareTo(right.ShortTimeEnd) == 0;
            return (flag && flag2);
        }

        public static bool operator !=(ShortTimeScope left, ShortTimeScope right)
        {
            return !(left == right);
        }

        public ShortTime ShortTimeEnd
        {
            get
            {
                return this.shortTimeEnd;
            }
            set
            {
                this.shortTimeEnd = value;
            }
        }

        public ShortTime ShortTimeStart
        {
            get
            {
                return this.shortTimeStart;
            }
            set
            {
                this.shortTimeStart = value;
            }
        }
    }
}

