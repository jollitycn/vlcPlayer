namespace CJPlus.FileTransceiver
{
    using System;

    public class ResumedProjectItem
    {
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private ulong ulong_0;
        private ulong ulong_1;
        private ulong ulong_2;
        private ulong ulong_3;
        private string uqagVhogLL;
        private string ztIgfjeilr;

        public ResumedProjectItem()
        {
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
            this.ulong_3 = 0L;
            this.dateTime_1 = DateTime.Now;
        }

        public ResumedProjectItem(string _senderID, string _originPath, ulong _originSize, DateTime _originLastUpdateTime, string _localTempSavePath, string _localSavePath, ulong _receivedCount)
        {
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
            this.ulong_3 = 0L;
            this.dateTime_1 = DateTime.Now;
            this.uqagVhogLL = _senderID;
            this.string_1 = _originPath;
            this.ulong_2 = _originSize;
            this.dateTime_0 = _originLastUpdateTime;
            this.ztIgfjeilr = _localTempSavePath;
            this.string_2 = _localSavePath;
            this.ulong_3 = _receivedCount;
        }

        public ResumedProjectItem(string _senderID, string _originPath, ulong _originSize, DateTime _originLastUpdateTime, string _localTempSavePath, string _localSavePath, ulong _receivedCount, string _disrupttedFileRelativePath, ulong _disrupttedFileSize, ulong _disrupttedFileReceivedCount)
        {
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
            this.ulong_3 = 0L;
            this.dateTime_1 = DateTime.Now;
            this.uqagVhogLL = _senderID;
            this.string_1 = _originPath;
            this.ulong_2 = _originSize;
            this.dateTime_0 = _originLastUpdateTime;
            this.ztIgfjeilr = _localTempSavePath;
            this.string_2 = _localSavePath;
            this.ulong_3 = _receivedCount;
            this.string_0 = _disrupttedFileRelativePath;
            this.ulong_1 = _disrupttedFileReceivedCount;
            this.ulong_0 = _disrupttedFileSize;
        }

        public ulong DisrupttedFileReceivedCount
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

        public string DisrupttedFileRelativePath
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

        public ulong DisrupttedFileSize
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

        public DateTime DisrupttedTime
        {
            get
            {
                return this.dateTime_1;
            }
            set
            {
                this.dateTime_1 = value;
            }
        }

        public string LocalSavePath
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }

        public string LocalTempFileSavePath
        {
            get
            {
                return this.ztIgfjeilr;
            }
            set
            {
                this.ztIgfjeilr = value;
            }
        }

        public DateTime OriginLastUpdateTime
        {
            get
            {
                return this.dateTime_0;
            }
            set
            {
                this.dateTime_0 = value;
            }
        }

        public string OriginPath
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }

        public ulong OriginSize
        {
            get
            {
                return this.ulong_2;
            }
            set
            {
                this.ulong_2 = value;
            }
        }

        public ulong ReceivedCount
        {
            get
            {
                return this.ulong_3;
            }
            set
            {
                this.ulong_3 = value;
            }
        }

        public string SenderID
        {
            get
            {
                return this.uqagVhogLL;
            }
            set
            {
                this.uqagVhogLL = value;
            }
        }
    }
}

