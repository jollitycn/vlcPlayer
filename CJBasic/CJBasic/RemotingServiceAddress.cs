namespace CJBasic
{
    using System;

    [Serializable]
    public class RemotingServiceAddress
    {
        private string iP = "";
        private int port = 0x2328;
        private string protocal = "tcp";
        private string serviceName;

        public override string ToString()
        {
            return this.ServiceUrl;
        }

        public string IP
        {
            get
            {
                return this.iP;
            }
            set
            {
                this.iP = value;
            }
        }

        public int Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        public string Protocal
        {
            get
            {
                return this.protocal;
            }
            set
            {
                this.protocal = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return this.serviceName;
            }
            set
            {
                this.serviceName = value;
            }
        }

        public string ServiceUrl
        {
            get
            {
                return string.Format("{0}://{1}:{2}/{3}", new object[] { this.protocal, this.iP, this.port, this.serviceName });
            }
        }
    }
}

