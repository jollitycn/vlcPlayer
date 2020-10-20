namespace CJPlus.FileTransceiver
{
    using System;

    public class FoldTransferingNextFileInfo
    {
        private string string_0;
        private ulong ulong_0;

        public FoldTransferingNextFileInfo()
        {
            this.ulong_0 = 0L;
        }

        public FoldTransferingNextFileInfo(string _relativeFilePath, ulong file_len)
        {
            this.ulong_0 = 0L;
            this.string_0 = _relativeFilePath;
            this.ulong_0 = file_len;
        }

        public ulong FileLength
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

        public string RelativeFilePath
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
    }
}

