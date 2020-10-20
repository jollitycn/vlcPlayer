namespace CJPlus.Rapid
{
    using System;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;

    public class WssOptions
    {
        private bool bool_0;
        private System.Security.Authentication.SslProtocols sslProtocols_0;
        private System.Security.Cryptography.X509Certificates.X509Certificate2 x509Certificate2_0;

        public WssOptions()
        {
            this.sslProtocols_0 = System.Security.Authentication.SslProtocols.Default;
            this.bool_0 = false;
        }

        public WssOptions(System.Security.Cryptography.X509Certificates.X509Certificate2 cer, System.Security.Authentication.SslProtocols pro, bool onlyWss)
        {
            this.sslProtocols_0 = System.Security.Authentication.SslProtocols.Default;
            this.bool_0 = false;
            this.x509Certificate2_0 = cer;
            this.sslProtocols_0 = pro;
            this.bool_0 = onlyWss;
        }

        public bool OnlyWssClient
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public System.Security.Authentication.SslProtocols SslProtocols
        {
            get
            {
                return this.sslProtocols_0;
            }
            set
            {
                this.sslProtocols_0 = value;
            }
        }

        public System.Security.Cryptography.X509Certificates.X509Certificate2 X509Certificate2
        {
            get
            {
                return this.x509Certificate2_0;
            }
            set
            {
                this.x509Certificate2_0 = value;
            }
        }
    }
}

