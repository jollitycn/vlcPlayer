namespace CJPlus.Advanced
{
    using System;
    using System.Threading;

    public class ThreadPoolInfo
    {
        private int int_0 = 0;
        private int int_1 = 0;
        private int int_2 = 0;
        private int int_3 = 0;

        public ThreadPoolInfo()
        {
            ThreadPool.GetMaxThreads(out this.int_0, out this.int_2);
            ThreadPool.GetAvailableThreads(out this.int_1, out this.int_3);
        }

        public override string ToString()
        {
            return string.Format("MaxWorkThreadCount : {0}, AvailableWorkThreadCount : {1}, MaxIocpThreadCount : {2}, AvailableIocpThreadCount : {3}", new object[] { this.int_0, this.int_1, this.int_2, this.int_3 });
        }

        public int AvailableIocpThreadCount
        {
            get
            {
                return this.int_3;
            }
        }

        public int AvailableWorkThreadCount
        {
            get
            {
                return this.int_1;
            }
        }

        public int MaxIocpThreadCount
        {
            get
            {
                return this.int_2;
            }
        }

        public int MaxWorkThreadCount
        {
            get
            {
                return this.int_0;
            }
        }
    }
}

