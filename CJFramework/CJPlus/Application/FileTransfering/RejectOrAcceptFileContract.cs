namespace CJPlus.Application.FileTransfering
{
    using System;

    public class RejectOrAcceptFileContract
    {
        private bool bool_0;
        private string string_0;
        private string string_1;
        private ulong ulong_0;
        private ulong ulong_1;
        private ulong ulong_2;
        private string ytYlpxMfvQ;

        public RejectOrAcceptFileContract()
        {
            this.string_1 = null;
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
        }

        public RejectOrAcceptFileContract(string _fileID, bool _agree, ulong _receivedCount, string _cause)
        {
            this.string_1 = null;
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
            this.string_0 = _fileID;
            this.bool_0 = _agree;
            this.ulong_0 = _receivedCount;
            this.string_1 = _cause;
        }

        public RejectOrAcceptFileContract(string _fileID, bool _agree, ulong _receivedCount, string _cause, string _disrupttedFileRelativePath, ulong _disrupttedFileSize, ulong _disrupttedFileReceivedCount)
        {
            this.string_1 = null;
            this.ulong_0 = 0L;
            this.ulong_1 = 0L;
            this.ulong_2 = 0L;
            this.string_0 = _fileID;
            this.bool_0 = _agree;
            this.ulong_0 = _receivedCount;
            this.string_1 = _cause;
            this.ytYlpxMfvQ = _disrupttedFileRelativePath;
            this.ulong_2 = _disrupttedFileReceivedCount;
            this.ulong_1 = _disrupttedFileSize;
        }

        public bool Agree
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

        public ulong DisrupttedFileReceivedCount
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

        public string DisrupttedFileRelativePath
        {
            get
            {
                return this.ytYlpxMfvQ;
            }
            set
            {
                this.ytYlpxMfvQ = value;
            }
        }

        public ulong DisrupttedFileSize
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

        public ulong ReceivedCount
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

        public string RejectCause
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
    }
}

