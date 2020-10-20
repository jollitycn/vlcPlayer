namespace CJPlus.FileTransceiver
{
    using CJBasic.Helpers;
    using System;
    using System.IO;

    public class TransferingProject
    {
        private string aZpUlxOgEg;
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private DateTime dateTime_0;
        private DateTime dateTime_1;
        private object FaoUcqapdQ;
        private SendingFileParas sendingFileParas_0;
        private Stream stream_0;
        private Stream stream_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private ulong ulong_0;

        public TransferingProject()
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.string_0 = "";
            this.ulong_0 = 0L;
            this.string_3 = "";
            this.string_4 = "";
            this.dateTime_1 = DateTime.Now;
            this.sendingFileParas_0 = null;
            this.bool_2 = false;
            this.string_5 = null;
            this.aZpUlxOgEg = null;
            this.FaoUcqapdQ = null;
        }

        public TransferingProject(string _projectID, Stream stream, string name, string accepter, string sender, ulong file_size, bool isSend, string _comment)
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.string_0 = "";
            this.ulong_0 = 0L;
            this.string_3 = "";
            this.string_4 = "";
            this.dateTime_1 = DateTime.Now;
            this.sendingFileParas_0 = null;
            this.bool_2 = false;
            this.string_5 = null;
            this.aZpUlxOgEg = null;
            this.FaoUcqapdQ = null;
            this.string_0 = _projectID;
            this.bool_0 = false;
            this.string_1 = name;
            this.stream_0 = stream;
            this.dateTime_0 = DateTime.Now;
            this.string_3 = accepter;
            this.string_4 = sender;
            this.ulong_0 = file_size;
            this.bool_1 = isSend;
            this.string_5 = _comment;
        }

        public TransferingProject(string _projectID, bool _isFolder, string _originFilePath, DateTime _originFileLastUpdateTime, string accepter, string sender, ulong file_size, bool isSend, string _comment)
        {
            this.bool_0 = false;
            this.bool_1 = false;
            this.string_0 = "";
            this.ulong_0 = 0L;
            this.string_3 = "";
            this.string_4 = "";
            this.dateTime_1 = DateTime.Now;
            this.sendingFileParas_0 = null;
            this.bool_2 = false;
            this.string_5 = null;
            this.aZpUlxOgEg = null;
            this.FaoUcqapdQ = null;
            this.string_0 = _projectID;
            this.bool_0 = _isFolder;
            this.string_1 = _originFilePath;
            this.dateTime_0 = _originFileLastUpdateTime;
            this.string_3 = accepter;
            this.string_4 = sender;
            this.ulong_0 = file_size;
            this.bool_1 = isSend;
            this.string_5 = _comment;
        }

        internal SendingFileParas method_0()
        {
            return this.sendingFileParas_0;
        }

        internal void method_1(SendingFileParas value)
        {
            this.sendingFileParas_0 = value;
        }

        internal void method_2(string string_6)
        {
            this.aZpUlxOgEg = string_6;
        }

        public string AccepterID
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
            }
        }

        public string Comment
        {
            get
            {
                return this.string_5;
            }
            set
            {
                this.string_5 = value;
            }
        }

        public string DestUserID
        {
            get
            {
                if (this.bool_1)
                {
                    return this.string_3;
                }
                return this.string_4;
            }
        }

        public string FileTransDisrupttedCause
        {
            get
            {
                return this.aZpUlxOgEg;
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

        public bool IsSender
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

        public bool IsTransfering
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
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

        public Stream LocalSaveStream
        {
            get
            {
                return this.stream_1;
            }
            set
            {
                this.stream_1 = value;
            }
        }

        public object LocalTag
        {
            get
            {
                return this.FaoUcqapdQ;
            }
            set
            {
                this.FaoUcqapdQ = value;
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

        public Stream OriginStream
        {
            get
            {
                return this.stream_0;
            }
            set
            {
                this.stream_0 = value;
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

        public string ProjectName
        {
            get
            {
                if (this.bool_0)
                {
                    string[] strArray = null;
                    if (this.bool_1 || (this.string_2 == null))
                    {
                        strArray = this.string_1.Trim().Split(new char[] { '\\' });
                    }
                    else
                    {
                        strArray = this.string_2.Trim().Split(new char[] { '\\' });
                    }
                    return strArray[strArray.Length - 1];
                }
                if (this.bool_1 || (this.string_2 == null))
                {
                    return FileHelper.GetFileNameNoPath(this.string_1);
                }
                return FileHelper.GetFileNameNoPath(this.string_2);
            }
        }

        public string SenderID
        {
            get
            {
                return this.string_4;
            }
            set
            {
                this.string_4 = value;
            }
        }

        public DateTime TimeStarted
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

