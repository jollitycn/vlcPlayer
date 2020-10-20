namespace CJPlus.FileTransceiver
{
    using System;

    public class SendingFileParas
    {
        private int int_0;
        private int int_1;

        public SendingFileParas()
        {
            this.int_0 = 0;
            this.int_1 = 0x800;
        }

        public SendingFileParas(int packageSize, int sendSpanInMSecs)
        {
            this.int_0 = 0;
            this.int_1 = 0x800;
            this.int_1 = packageSize;
            this.int_0 = sendSpanInMSecs;
        }

        public int FilePackageSize
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

        public int SendingSpanInMSecs
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

