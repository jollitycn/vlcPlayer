namespace CJPlus.Application.Basic
{
    using System;

    public class UserIpeResContract
    {
        private int int_0;
        private string string_0;

        public UserIpeResContract()
        {
            this.string_0 = "";
            this.int_0 = 0;
        }

        public UserIpeResContract(string theIP, int thePort)
        {
            this.string_0 = "";
            this.int_0 = 0;
            this.string_0 = theIP;
            this.int_0 = thePort;
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

        public int Port
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

