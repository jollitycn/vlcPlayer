namespace CJBasic.ObjectManagement
{
    using System;

    public class MinMaxContainer
    {
        private IComparable max = null;
        private IComparable min = null;

        public void Insert(IComparable t)
        {
            IComparable comparable = t;
            if (comparable != null)
            {
                if (this.Empty)
                {
                    this.min = comparable;
                    this.max = comparable;
                }
                else
                {
                    if (this.min.CompareTo(comparable) > 0)
                    {
                        this.min = comparable;
                    }
                    if (this.max.CompareTo(comparable) < 0)
                    {
                        this.max = comparable;
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Min:{0} ,Max:{1}", this.min, this.max);
        }

        public bool Empty
        {
            get
            {
                return (this.min == null);
            }
        }

        public IComparable Max
        {
            get
            {
                return this.max;
            }
        }

        public IComparable Min
        {
            get
            {
                return this.min;
            }
        }
    }
}

