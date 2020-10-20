namespace CJPlus.Application
{
    using System;

    [Serializable]
    public class Information
    {
        private byte[] byte_0;
        private int int_0;
        private string string_0;
        private string string_1;

        public Information()
        {
            this.string_0 = "";
            this.string_1 = "";
            this.int_0 = 0;
            this.byte_0 = null;
        }

        public Information(string _sourceID, string _destID, int _infoType, byte[] _content)
        {
            this.string_0 = "";
            this.string_1 = "";
            this.int_0 = 0;
            this.byte_0 = null;
            this.string_0 = _sourceID;
            this.string_1 = _destID;
            this.int_0 = _infoType;
            this.byte_0 = _content;
        }

        public byte[] Content
        {
            get
            {
                return this.byte_0;
            }
            set
            {
                this.byte_0 = value;
            }
        }

        public string DestID
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

        public int InformationType
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

        public string SourceID
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

