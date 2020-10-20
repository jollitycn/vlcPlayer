using CJFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

internal sealed class Class85 : IDisposable
{
    private int int_0;
    private int int_1;
    private int int_2;
    private int int_3;
    private string string_0;
    private string string_1;
    private TcpClient tcpClient_0;

    public Class85()
    {
        this.tcpClient_0 = null;
        this.string_0 = "";
        this.int_0 = 0;
        this.int_1 = 0;
        this.string_1 = null;
        this.int_2 = 0x2000;
        this.int_3 = 0x2000;
    }

    public Class85(string string_2, int int_4) : this(string_2, int_4, 0, null)
    {
    }

    public Class85(string string_2, int int_4, int int_5) : this(string_2, int_4, int_5, null)
    {
    }

    public Class85(string string_2, int int_4, int int_5, string string_3)
    {
        this.tcpClient_0 = null;
        this.string_0 = "";
        this.int_0 = 0;
        this.int_1 = 0;
        this.string_1 = null;
        this.int_2 = 0x2000;
        this.int_3 = 0x2000;
        this.string_0 = string_2;
        this.int_0 = int_4;
        this.int_1 = int_5;
        this.string_1 = string_3;
    }

    public void Dispose()
    {
        if (this.tcpClient_0 != null)
        {
            this.tcpClient_0.Close();
        }
    }

    public string method_0()
    {
        return this.string_0;
    }

    public void method_1(string string_2)
    {
        this.string_0 = string_2;
    }

    public int method_10()
    {
        return this.int_3;
    }

    public void method_11(int int_4)
    {
        this.int_3 = int_4;
    }

    public NetworkStream method_12()
    {
        NetworkStream stream;
        try
        {
            if (!NetworkHelper.smethod_3(this.string_0))
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(this.string_0);
                if (hostEntry.AddressList.Length > 0)
                {
                    this.string_0 = hostEntry.AddressList[0].ToString();
                }
            }
            IPAddress address = IPAddress.Parse(this.string_0);
            if (!((address.AddressFamily != AddressFamily.InterNetworkV6) || Socket.OSSupportsIPv6))
            {
                throw new NotSupportedException("The IPAddress Server listened is IPv6 ,but current OS doesn't Support IPv6 !");
            }
            if (!((address.AddressFamily != AddressFamily.InterNetwork) || Socket.SupportsIPv4))
            {
                throw new NotSupportedException("The IPAddress Server listened is IPv4 ,but current OS doesn't Support IPv4 !");
            }
            if ((this.int_1 <= 0) && (this.string_1 == null))
            {
                this.tcpClient_0 = new TcpClient(address.AddressFamily);
            }
            else
            {
                if (this.string_1 == null)
                {
                    List<string> list = NetworkHelper.smethod_1(address.AddressFamily);
                    this.string_1 = list[0];
                }
                this.tcpClient_0 = new TcpClient(new IPEndPoint(IPAddress.Parse(this.string_1), this.int_1));
            }
            this.tcpClient_0.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            this.tcpClient_0.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, this.int_2);
            this.tcpClient_0.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, this.int_3);
            this.tcpClient_0.Connect(this.string_0, this.int_0);
            this.int_1 = ((IPEndPoint) this.tcpClient_0.Client.LocalEndPoint).Port;
            this.string_1 = ((IPEndPoint) this.tcpClient_0.Client.LocalEndPoint).Address.ToString();
            stream = this.tcpClient_0.GetStream();
        }
        catch (Exception exception)
        {
            if (this.tcpClient_0 != null)
            {
                this.tcpClient_0.Close();
            }
            throw exception;
        }
        return stream;
    }

    public int method_2()
    {
        return this.int_0;
    }

    public void method_3(int int_4)
    {
        this.int_0 = int_4;
    }

    public int method_4()
    {
        return this.int_1;
    }

    public void method_5(int int_4)
    {
        this.int_1 = int_4;
    }

    public string method_6()
    {
        return this.string_1;
    }

    public void method_7(string string_2)
    {
        this.string_1 = string_2;
    }

    public int method_8()
    {
        return this.int_2;
    }

    public void method_9(int int_4)
    {
        this.int_2 = int_4;
    }
}

