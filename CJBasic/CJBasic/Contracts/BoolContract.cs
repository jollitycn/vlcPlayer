namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class BoolContract
    {
        private bool theValue;

        public BoolContract()
        {
            this.theValue = true;
        }

        public BoolContract(bool val)
        {
            this.theValue = true;
            this.theValue = val;
        }

        public bool TheValue
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

