namespace CJPlus.Application.CustomizeInfo
{
    using System;

    public class BinaryInformationContract
    {
        private byte[] byte_0;
        private int int_0;

        public BinaryInformationContract()
        {
            this.int_0 = 0;
        }

        public BinaryInformationContract(byte[] info)
        {
            this.int_0 = 0;
            this.byte_0 = info;
        }

        public BinaryInformationContract(int infoType, byte[] info)
        {
            this.int_0 = 0;
            this.byte_0 = info;
            this.int_0 = infoType;
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
    }
}

