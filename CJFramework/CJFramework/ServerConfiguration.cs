namespace CJFramework
{
    using System;

    [Serializable]
    public class ServerConfiguration
    {
        private int int_0;
        private string string_0;
        private string string_1;
        private string string_2;

        public ServerConfiguration()
        {
            this.string_0 = NetworkHelper.GetFirstIP();
            this.int_0 = 0x198f;
            this.string_1 = "";
            this.string_2 = "";
        }

        public ServerConfiguration(string _ip, int _port, string _serverID)
        {
            this.string_0 = NetworkHelper.GetFirstIP();
            this.int_0 = 0x198f;
            this.string_1 = "";
            this.string_2 = "";
            this.string_0 = _ip;
            this.int_0 = _port;
            this.string_1 = _serverID;
        }

        public override string ToString()
        {
            return string.Format("ServerID:{0},ServerName:{1},IP:{2},Port:{3}", new object[] { this.string_1, this.string_2, this.string_0, this.int_0 });
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

        public string ServerID
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

        public string ServerName
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

