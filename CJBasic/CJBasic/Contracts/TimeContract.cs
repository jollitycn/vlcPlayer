namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class TimeContract
    {
        private DateTime theValue;

        public TimeContract()
        {
            this.theValue = DateTime.Now;
        }

        public TimeContract(DateTime val)
        {
            this.theValue = DateTime.Now;
            this.theValue = val;
        }

        public DateTime TheValue
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

