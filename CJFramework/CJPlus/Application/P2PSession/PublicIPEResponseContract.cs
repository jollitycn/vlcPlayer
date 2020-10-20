namespace CJPlus.Application.P2PSession
{
    using System;

    public class PublicIPEResponseContract
    {
        private int int_0;
        private string string_0;

        public PublicIPEResponseContract()
        {
        }

        public PublicIPEResponseContract(string theIP, int _publicPort)
        {
            this.string_0 = theIP;
            this.int_0 = _publicPort;
        }

        public string IP
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

        public int PublicPort
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

