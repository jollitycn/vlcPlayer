namespace CJPlus.Application.Basic
{
    using System;

    public class CallClientContract
    {
        private int int_0;

        public CallClientContract()
        {
        }

        public CallClientContract(int id)
        {
            this.int_0 = id;
        }

        public int InstanceID
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }
    }
}

