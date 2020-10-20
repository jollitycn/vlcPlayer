namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class IntContract
    {
        private int theValue;

        public IntContract()
        {
            this.theValue = 0;
        }

        public IntContract(int val)
        {
            this.theValue = 0;
            this.theValue = val;
        }

        public int TheValue
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

