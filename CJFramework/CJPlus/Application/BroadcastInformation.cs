namespace CJPlus.Application
{
    using System;

    [Serializable]
    public class BroadcastInformation
    {
        private byte[] byte_0;
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;

        public BroadcastInformation()
        {
            this.string_0 = "";
            this.string_1 = "";
            this.int_0 = 0;
            this.byte_0 = null;
            this.string_2 = null;
        }

        public BroadcastInformation(string _sourceID, string _groupID, int _broadcastType, byte[] _content, string _tag)
        {
            this.string_0 = "";
            this.string_1 = "";
            this.int_0 = 0;
            this.byte_0 = null;
            this.string_2 = null;
            this.string_0 = _sourceID;
            this.string_1 = _groupID;
            this.int_0 = _broadcastType;
            this.byte_0 = _content;
        }

        public int BroadcastType
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

        public string GroupID
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

        public string Tag
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
    }
}

