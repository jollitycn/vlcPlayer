namespace CJPlus.Application
{
    using System;

    public class BlobAndTagContract
    {
        private byte[] byte_0;
        private string string_0;

        public BlobAndTagContract()
        {
        }

        public BlobAndTagContract(byte[] msg, string _tag)
        {
            this.byte_0 = msg;
            this.string_0 = _tag;
        }

        public byte[] Message
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

        public string Tag
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

