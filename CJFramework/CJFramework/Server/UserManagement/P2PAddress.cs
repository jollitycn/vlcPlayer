namespace CJFramework.Server.UserManagement
{
    using System;

    [Serializable]
    public class P2PAddress
    {
        private int int_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private string string_0;
        private string string_1;

        public P2PAddress()
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.int_2 = 0;
            this.int_3 = 0;
        }

        public P2PAddress(string pubIP, string privIP, int privTcpPort, int pubTcpPort, int privUdpPort, int pubUdpPort)
        {
            this.int_0 = 0;
            this.int_1 = 0;
            this.int_2 = 0;
            this.int_3 = 0;
            this.string_0 = pubIP;
            this.string_1 = privIP;
            this.int_2 = privTcpPort;
            this.int_3 = pubTcpPort;
            this.int_0 = privUdpPort;
            this.int_1 = pubUdpPort;
        }

        public override string ToString()
        {
            return string.Format("PrivateIP:{0},PublicIP:{1},PrivateTcpPort:{2},PublicTcpPort:{3},PrivateUdpPort:{4},PublicUdpPort:{5}", new object[] { this.string_1, this.string_0, this.int_2, this.int_3, this.int_0, this.int_1 });
        }

        public string PrivateIP
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

        public int PrivateTcpPort
        {
            get
            {
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
            }
        }

        public int PrivateUdpPort
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

        public string PublicIP
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

        public int PublicTcpPort
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        public int PublicUdpPort
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
            }
        }
    }
}

