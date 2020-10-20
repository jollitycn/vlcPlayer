namespace CJPlus.Advanced
{
    using System;

    public class BaseOptions
    {
        private bool bool_0 = true;
        private bool bool_1 = true;
        private int int_0 = 0;
        private int int_1 = 0x2000;
        private int int_2 = 300;
        private int int_3 = 20;
        private int int_4 = 0;

        public int CheckFileZeroSpeedSpanInSecs
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public bool CheckResponseTTL4Query
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public int SocketSendBuffSize
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

        public int TempFile4ResumedTTL
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public int UncompletedSendingCount4Busy
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public bool UseWorkThreadPool
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public int WriteTimeoutInSecs
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

