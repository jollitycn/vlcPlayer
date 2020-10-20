namespace CJBasic
{
    using System;

    public class Parameter<T1, T2>
    {
        private T1 arg1;
        private T2 arg2;

        public Parameter()
        {
        }

        public Parameter(T1 t1, T2 t2)
        {
            this.arg1 = t1;
            this.arg2 = t2;
        }

        public T1 Arg1
        {
            get
            {
                return this.arg1;
            }
            set
            {
                this.arg1 = value;
            }
        }

        public T2 Arg2
        {
            get
            {
                return this.arg2;
            }
            set
            {
                this.arg2 = value;
            }
        }
    }
}

