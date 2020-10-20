namespace CJFramework.Engine.Tcp.Passive
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;

    public class Sock5ProxyInfo
    {
        private string hiUlFldbZG;
        private int int_0;
        private string string_0;
        private string string_1;

        public Sock5ProxyInfo()
        {
            this.string_0 = "";
            this.string_1 = "";
        }

        public Sock5ProxyInfo(string _proxyServerIP, int _proxyServerPort)
        {
            this.string_0 = "";
            this.string_1 = "";
            this.hiUlFldbZG = _proxyServerIP;
            this.int_0 = _proxyServerPort;
        }

        public Sock5ProxyInfo(string _proxyServerIP, int _proxyServerPort, string _userName, string _password)
        {
            this.string_0 = "";
            this.string_1 = "";
            this.hiUlFldbZG = _proxyServerIP;
            this.int_0 = _proxyServerPort;
            this.string_0 = _userName;
            this.string_1 = _password;
        }

        internal NetworkStream method_0(string string_2, int int_1, int int_2, int int_3, out Class85 class85_0)
        {
            class85_0 = new Class85(this.hiUlFldbZG, this.int_0);
            class85_0.method_11(int_2);
            class85_0.method_9(int_3);
            NetworkStream stream = class85_0.method_12();
            byte[] buffer = new byte[3];
            buffer[0] = 5;
            buffer[1] = 1;
            byte[] buffer2 = buffer;
            stream.Write(buffer2, 0, buffer2.Length);
            byte[] buffer3 = new byte[2];
            int num = stream.Read(buffer3, 0, buffer3.Length);
            if (num < 2)
            {
                throw new Exception("Error occurred when shake hand with proxy server.");
            }
            if (buffer3[1] != 0)
            {
                throw new Exception("Error occurred when shake hand with proxy server.");
            }
            byte[] destinationArray = new byte[10];
            destinationArray[0] = 5;
            destinationArray[1] = 1;
            destinationArray[2] = 0;
            destinationArray[3] = 1;
            Array.Copy(IPAddress.Parse(string_2).GetAddressBytes(), 0, destinationArray, 4, 4);
            Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(int_1)), 2, destinationArray, 8, 2);
            stream.Write(destinationArray, 0, destinationArray.Length);
            byte[] buffer5 = new byte[0x200];
            stream.Read(buffer5, 0, buffer5.Length);
            if (num == 0)
            {
                throw new Exception("Error occurred when request connection from proxy server .");
            }
            if (buffer5[1] != 0)
            {
                throw new Exception("Error occurred when request connection from proxy server .");
            }
            return stream;
        }

        public string Password
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

        public string ProxyServerIP
        {
            get
            {
                return this.hiUlFldbZG;
            }
            set
            {
                this.hiUlFldbZG = value;
            }
        }

        public int ProxyServerPort
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

        public string UserName
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

