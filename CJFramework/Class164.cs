using CJBasic;
using CJBasic.Loggers;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal class IPv6UdpClient : IPv6
{
    private bool bool_0;
    private bool bool_1;
    protected EmptyAgileLogger emptyAgileLogger_0;
    private object object_0;
    private UdpClient udpClient_0;
    private UdpClient udpClient_1;

    public event CbGeneric<IPEndPoint, byte[]> DataReceived;

    public event CbGeneric<Exception> HandleExcetion;

    public IPv6UdpClient()
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_0 = false;
        this.bool_1 = false;
        this.object_0 = new object();
        this.udpClient_0 = new UdpClient(AddressFamily.InterNetwork);
        if (Socket.OSSupportsIPv6)
        {
            int port = ((IPEndPoint) this.udpClient_0.Client.LocalEndPoint).Port;
            this.udpClient_1 = new UdpClient(port, AddressFamily.InterNetworkV6);
        }
    }

    public IPv6UdpClient(int int_0)
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_0 = false;
        this.bool_1 = false;
        this.object_0 = new object();
        this.udpClient_0 = new UdpClient(int_0, AddressFamily.InterNetwork);
        if (Socket.OSSupportsIPv6)
        {
            int port = ((IPEndPoint) this.udpClient_0.Client.LocalEndPoint).Port;
            this.udpClient_1 = new UdpClient(port, AddressFamily.InterNetworkV6);
        }
    }

    public IPv6UdpClient(AddressFamily addressFamily_0)
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_0 = false;
        this.bool_1 = false;
        this.object_0 = new object();
        if (addressFamily_0 == AddressFamily.InterNetwork)
        {
            this.udpClient_0 = new UdpClient(AddressFamily.InterNetwork);
        }
        else
        {
            if (!Socket.OSSupportsIPv6)
            {
                throw new NotSupportedException("Current OS doesn't Support IPv6 !");
            }
            this.udpClient_1 = new UdpClient(AddressFamily.InterNetworkV6);
        }
    }

    public IPv6UdpClient(string string_0, int int_0)
    {
        this.emptyAgileLogger_0 = new EmptyAgileLogger();
        this.bool_0 = false;
        this.bool_1 = false;
        this.object_0 = new object();
        IPAddress address = IPAddress.Parse(string_0);
        if (!((address.AddressFamily != AddressFamily.InterNetworkV6) || Socket.OSSupportsIPv6))
        {
            throw new NotSupportedException("The IPAddress is IPv6 ,but current OS doesn't Support IPv6 !");
        }
        if (!((address.AddressFamily != AddressFamily.InterNetwork) || Socket.SupportsIPv4))
        {
            throw new NotSupportedException("The IPAddress is IPv4 ,but current OS doesn't Support IPv4 !");
        }
        if (address.AddressFamily == AddressFamily.InterNetwork)
        {
            this.udpClient_0 = new UdpClient(new IPEndPoint(address, int_0));
        }
        if (address.AddressFamily == AddressFamily.InterNetworkV6)
        {
            this.udpClient_1 = new UdpClient(new IPEndPoint(address, int_0));
        }
    }

    public void Dispose()
    {
        if (this.udpClient_0 != null)
        {
            this.udpClient_0.Close();
        }
        if (this.udpClient_1 != null)
        {
            this.udpClient_1.Close();
        }
    }

    public void imethod_0(byte[] byte_0, IPEndPoint ipendPoint_0)
    {
        if (ipendPoint_0.AddressFamily == AddressFamily.InterNetwork)
        {
            if (this.udpClient_0 == null)
            {
                throw new NotSupportedException("The target IPEndPoint is IPv4 ,but current instance doesn't Support IPv4 !");
            }
            this.udpClient_0.BeginSend(byte_0, byte_0.Length, ipendPoint_0, null, null);
        }
        else
        {
            if (this.udpClient_1 == null)
            {
                throw new NotSupportedException("The target IPEndPoint is IPv6 ,but current instance doesn't Support IPv6 !");
            }
            this.udpClient_1.BeginSend(byte_0, byte_0.Length, ipendPoint_0, null, null);
        }
    }

    public void Initialize()
    {
        lock (this.object_0)
        {
            if (!this.bool_1)
            {
                this.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.Debug, true);
                this.method_1(false);
                if (this.udpClient_0 != null)
                {
                    this.udpClient_0.BeginReceive(new AsyncCallback(this.method_14), this.udpClient_0);
                }
                if (this.udpClient_1 != null)
                {
                    this.udpClient_1.BeginReceive(new AsyncCallback(this.method_14), this.udpClient_1);
                }
                this.bool_1 = true;
            }
        }
    }

    public bool method_0()
    {
        return ((this.udpClient_0 != null) && this.udpClient_0.DontFragment);
    }

    public void method_1(bool bool_2)
    {
        if (this.udpClient_0 != null)
        {
            this.udpClient_0.DontFragment = bool_2;
        }
    }

    public void SetSocketOption(SocketOptionLevel socketOptionLevel_0, SocketOptionName socketOptionName_0, int int_0)
    {
        try
        {
            if (this.udpClient_0 != null)
            {
                this.udpClient_0.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, int_0);
            }
            if (this.udpClient_1 != null)
            {
                this.udpClient_1.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, int_0);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.SetSocketOption", ErrorLevel.Standard);
            }
        }
    }

    public void SetSocketOption(SocketOptionLevel socketOptionLevel_0, SocketOptionName socketOptionName_0, object object_1)
    {
        try
        {
            if (this.udpClient_0 != null)
            {
                this.udpClient_0.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, object_1);
            }
            if (this.udpClient_1 != null)
            {
                this.udpClient_1.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, object_1);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.SetSocketOption", ErrorLevel.Standard);
            }
        }
    }

    public int IOControl(IOControlCode iocontrolCode_0, byte[] byte_0, byte[] byte_1)
    {
        int num = 0;
        try
        {
            if (this.udpClient_0 != null)
            {
                num = this.udpClient_0.Client.IOControl(iocontrolCode_0, byte_0, byte_1);
            }
            if (this.udpClient_1 != null)
            {
                num = this.udpClient_1.Client.IOControl(iocontrolCode_0, byte_0, byte_1);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.IOControl", ErrorLevel.Standard);
            }
        }
        return num;
    }

    public int IOControl(int int_0, byte[] byte_0, byte[] byte_1)
    {
        int num = 0;
        try
        {
            if (this.udpClient_0 != null)
            {
                num = this.udpClient_0.Client.IOControl(int_0, byte_0, byte_1);
            }
            if (this.udpClient_1 != null)
            {
                num = this.udpClient_1.Client.IOControl(int_0, byte_0, byte_1);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.IOControl", ErrorLevel.Standard);
            }
        }
        return num;
    }

    private void method_14(IAsyncResult iasyncResult_0)
    {
        UdpClient asyncState = (UdpClient) iasyncResult_0.AsyncState;
        byte[] buffer = null;
        IPEndPoint remoteEP = null;
        try
        {
            buffer = asyncState.EndReceive(iasyncResult_0, ref remoteEP);
            asyncState.BeginReceive(new AsyncCallback(this.method_14), asyncState);
        }
        catch (Exception exception)
        {
            if (exception is ObjectDisposedException)
            {
                return;
            }
            if (this.HandleExcetion != null)
            {
                this.HandleExcetion(exception);
            }
        }
        if ((buffer != null) && (this.DataReceived != null))
        {
            this.DataReceived(remoteEP, buffer);
        }
    } 

    public int method_2()
    {
        if (this.udpClient_0 != null)
        {
            return ((IPEndPoint) this.udpClient_0.Client.LocalEndPoint).Port;
        }
        if (this.udpClient_1 != null)
        {
            return ((IPEndPoint) this.udpClient_1.Client.LocalEndPoint).Port;
        }
        return 0;
    }

    public IPAddress GetIPAddress()
    {
        if (this.udpClient_0 != null)
        {
            return ((IPEndPoint) this.udpClient_0.Client.LocalEndPoint).Address;
        }
        if (this.udpClient_1 != null)
        {
            return ((IPEndPoint) this.udpClient_1.Client.LocalEndPoint).Address;
        }
        return null;
    }

    public IAgileLogger GetAgileLogger()
    {
        return this.emptyAgileLogger_0;
    }

    public void SetAgileLogger(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        }
    }

    public bool method_6()
    {
        return this.bool_0;
    }

    public void method_7(bool bool_2)
    {
        this.bool_0 = bool_2;
    }

    public void SetSocketOption(SocketOptionLevel socketOptionLevel_0, SocketOptionName socketOptionName_0, bool bool_2)
    {
        try
        {
            if (this.udpClient_0 != null)
            {
                this.udpClient_0.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, bool_2);
            }
            if (this.udpClient_1 != null)
            {
                this.udpClient_1.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, bool_2);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.SetSocketOption", ErrorLevel.Standard);
            }
        }
    }

    public void SetSocketOption(SocketOptionLevel socketOptionLevel_0, SocketOptionName socketOptionName_0, byte[] byte_0)
    {
        try
        {
            if (this.udpClient_0 != null)
            {
                this.udpClient_0.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, byte_0);
            }
            if (this.udpClient_1 != null)
            {
                this.udpClient_1.Client.SetSocketOption(socketOptionLevel_0, socketOptionName_0, byte_0);
            }
        }
        catch (Exception exception)
        {
            if (this.bool_0)
            {
                this.emptyAgileLogger_0.Log(exception, "IPv6UdpClient.SetSocketOption", ErrorLevel.Standard);
            }
        }
    }

    public void Send(byte[] byte_0, IPEndPoint ipendPoint_0)
    {
        if (ipendPoint_0.AddressFamily == AddressFamily.InterNetwork)
        {
            if (this.udpClient_0 == null)
            {
                throw new NotSupportedException("The target IPEndPoint is IPv4 ,but current instance doesn't Support IPv4 !");
            }
            this.udpClient_0.Send(byte_0, byte_0.Length, ipendPoint_0);
        }
        else
        {
            if (this.udpClient_1 == null)
            {
                throw new NotSupportedException("The target IPEndPoint is IPv6 ,but current instance doesn't Support IPv6 !");
            }
            this.udpClient_1.Send(byte_0, byte_0.Length, ipendPoint_0);
        }
    }
}

