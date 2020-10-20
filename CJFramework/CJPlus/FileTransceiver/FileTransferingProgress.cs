namespace CJPlus.FileTransceiver
{
    using System;

    public class FileTransferingProgress
    {
        private string string_0;
        private ulong ulong_0;
        private ulong ulong_1;

        public FileTransferingProgress()
        {
            this.string_0 = "";
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
        }

        public FileTransferingProgress(string proID, ulong _total, ulong _transfered)
        {
            this.string_0 = "";
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.string_0 = proID;
            this.ulong_0 = _total;
            this.ulong_1 = _transfered;
        }

        public string ProjectID
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public ulong Total
        {
            get
            {
                return this.ulong_0;
            }
            set
            {
                this.ulong_0 = value;
            }
        }

        public ulong Transfered
        {
            get
            {
                return this.ulong_1;
            }
            set
            {
                this.ulong_1 = value;
            }
        }
    }
}

