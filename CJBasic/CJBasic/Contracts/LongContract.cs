namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class LongContract
    {
        private long theValue;

        public LongContract()
        {
            this.theValue = 0L;
        }

        public LongContract(long val)
        {
            this.theValue = 0L;
            this.theValue = val;
        }

        public long TheValue
        {
            get
            {
                return this.theValue;
            }
            set
            {
                this.theValue = value;
            }
        }
    }
}

