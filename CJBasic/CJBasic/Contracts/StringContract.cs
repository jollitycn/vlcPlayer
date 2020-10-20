namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class StringContract
    {
        private string theValue;

        public StringContract()
        {
            this.theValue = "";
        }

        public StringContract(string val)
        {
            this.theValue = "";
            this.theValue = val;
        }

        public string TheValue
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

