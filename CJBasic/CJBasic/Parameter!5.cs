namespace CJBasic
{
    using System;

    public class Parameter<T1, T2, T3, T4, T5>
    {
        private T1 arg1;
        private T2 arg2;
        private T3 arg3;
        private T4 arg4;
        private T5 arg5;

        public Parameter()
        {
        }

        public Parameter(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            this.arg1 = t1;
            this.arg2 = t2;
            this.arg3 = t3;
            this.arg4 = t4;
            this.arg5 = t5;
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

        public T3 Arg3
        {
            get
            {
                return this.arg3;
            }
            set
            {
                this.arg3 = value;
            }
        }

        public T4 Arg4
        {
            get
            {
                return this.arg4;
            }
            set
            {
                this.arg4 = value;
            }
        }

        public T5 Arg5
        {
            get
            {
                return this.arg5;
            }
            set
            {
                this.arg5 = value;
            }
        }
    }
}

