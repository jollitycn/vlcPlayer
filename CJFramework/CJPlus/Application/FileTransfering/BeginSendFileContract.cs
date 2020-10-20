namespace CJPlus.Application.FileTransfering
{
    using System;

    [Serializable]
    public class BeginSendFileContract
    {
        private bool bool_0;
        private DateTime dateTime_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private ulong ulong_0;

        public BeginSendFileContract()
        {
            this.bool_0 = false;
            this.ulong_0 = 0L;
            this.string_1 = "";
            this.string_2 = null;
        }

        public BeginSendFileContract(string _originFilePath, bool _isFolder, ulong file_len, DateTime _lastUpdateTime, string _comment, string file_ID)
        {
            this.bool_0 = false;
            this.ulong_0 = 0L;
            this.string_1 = "";
            this.string_2 = null;
            this.string_0 = _originFilePath;
            this.bool_0 = _isFolder;
            this.ulong_0 = file_len;
            this.dateTime_0 = _lastUpdateTime;
            this.string_2 = _comment;
            this.string_1 = file_ID;
        }

        public string Comment
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

        public bool IsFolder
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

        public DateTime LastUpdateTime
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
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }

        public string ProjectID
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

        public ulong TotalSize
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
    }
}

