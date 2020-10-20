namespace CJBasic.Contracts
{
    using System;

    [Serializable]
    public class FloatContract
    {
        private float theValue;

        public FloatContract()
        {
            this.theValue = 0f;
        }

        public FloatContract(float val)
        {
            this.theValue = 0f;
            this.theValue = val;
        }

        public float TheValue
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

