namespace CJPlus.Application.Basic
{
    using System;

    public class NotifyContract
    {
        private int int_0;
        private int int_1;

        public NotifyContract()
        {
        }

        public NotifyContract(int n1, int n2)
        {
            this.int_0 = n1;
            this.int_1 = n2;
        }

        public int Num1
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

        public int Num2
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }
    }
}

