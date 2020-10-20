using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJBasic.Threading.Engines;
using CJFramework;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class AgileTcpListener : BaseCycleEngine, IDisposable
{
    private bool bool_0 = true;
    private bool bool_1 = false;
    private bool bool_2 = true;
    [CompilerGenerated]
    private static CbGeneric<NetworkStream, EndPoint> cbGeneric_1;
    private Class117 class117_0;
    private DateTime dateTime_0 = DateTime.Now;
    private ClientTimeEnum enum0_0 = ((ClientTimeEnum) 1);
    private EventSafeTrigger eventSafeTrigger_0;
    private IAgileLogger iagileLogger_0;
    private IAgileLogger iagileLogger_1;
    private int int_0 = 11;
    private int int_1 = 0x2000;
    private int int_2 = 0x2000;
    private int int_3 = 0xf423f;
    private int int_4 = 10;
    private Interface20 interface20_0;
    private ListenerSubState listenerSubState_0 = ListenerSubState.IdleSleep;
    private static Mutex mutex_0 = null;
    private int object_0 = 0;
    private string string_0 = "elinkshop";
    private string string_1 = "cc5aa7a882472f2c7497b4f1c8d96a43";
    private TcpListener tcpListener_0 = null;
    private TcpListener tcpListener_1 = null;

    internal event CbGeneric<NetworkStream, EndPoint> TcpConnectionEstablished;

    internal AgileTcpListener(int int_5, bool bool_3, string string_2, bool bool_4, bool bool_5, IAgileLogger iagileLogger_2, IAgileLogger iagileLogger_3, Class119 class119_0)
    {
        if ((!bool_3 && ((this.enum0_0 == ((ClientTimeEnum) 3)) || (this.enum0_0 == ((ClientTimeEnum) 2)))) && smethod_0("ESF-" + this.string_0))
        {
            throw new Exception("CJFramework Error : there's one CJFramework server instance running. AuthorizedUserID is " + this.string_0);
        }
        this.bool_0 = bool_5;
        this.iagileLogger_0 = iagileLogger_2;
        this.iagileLogger_1 = iagileLogger_3;
        this.eventSafeTrigger_0 = new EventSafeTrigger(iagileLogger_2, "Agt5W7B5WBoJhMi3tS0.akDdtXBaxZZh04bUDlN");
        this.class117_0 = new Class117(this.string_0, this.enum0_0, this.iagileLogger_1, class119_0);
        if (!(bool_3 || !this.bool_2))
        {
            this.class117_0.Event_0 += new CbGeneric<bool, bool>(this.method_6);
            this.class117_0.method_2();
        }
        if (cbGeneric_1 == null)
        {
            cbGeneric_1 = new CbGeneric<NetworkStream, EndPoint>(AgileTcpListener.OnTcpConnectionEstablished);
        }
        this.TcpConnectionEstablished += cbGeneric_1;
        this.bool_1 = bool_3;
        this.int_0 = bool_3 ? 0x7fffffff : (this.int_3 + 1);
        if (string_2 != null)
        {
            this.tcpListener_0 = new TcpListener(IPAddress.Parse(string_2), int_5);
        }
        else
        {
            this.tcpListener_0 = new TcpListener(IPAddress.Any, int_5);
            if (Socket.OSSupportsIPv6 && bool_4)
            {
                this.tcpListener_1 = new TcpListener(IPAddress.IPv6Any, int_5);
            }
        }
        this.tcpListener_0.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, bool_3);
        if (this.tcpListener_1 != null)
        {
            this.tcpListener_1.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, bool_3);
        }
    }

    public void Dispose()
    {
        base.Stop();
        this.tcpListener_0.Stop();
        if (this.tcpListener_1 != null)
        {
            this.tcpListener_1.Stop();
        }
        this.object_0 = 0;
        this.class117_0.method_3();
        this.tcpListener_0.Server.Close();
    }

    protected override bool DoDetect()
    {
        try
        {
            this.dateTime_0 = DateTime.Now;
            bool flag = true;
            if (!this.bool_1)
            {
                flag = this.class117_0.method_0() && (this.interface20_0.imethod_40() < this.int_0);
            }
            if (!flag)
            {
                if (this.object_0 != 0)
                {
                    this.object_0 = 0;
                    this.tcpListener_0.Stop();
                    if (this.tcpListener_1 != null)
                    {
                        this.tcpListener_1.Stop();
                    }
                }
                Thread.Sleep(this.int_4);
                return true;
            }
            if (this.object_0 == null)
            {
                this.tcpListener_0.Start();
                if (this.tcpListener_1 != null)
                {
                    this.tcpListener_1.Start();
                }
                this.object_0 = 1;
            }
            Socket socket = null;
            this.listenerSubState_0 = ListenerSubState.ExcutePending;
            if (this.tcpListener_0.Pending())
            {
                this.listenerSubState_0 = ListenerSubState.ExcuteAcceptSocket;
                socket = this.tcpListener_0.AcceptSocket();
            }
            else if (this.tcpListener_1 != null)
            {
                this.listenerSubState_0 = ListenerSubState.ExcutePendingV6;
                if (this.tcpListener_1.Pending())
                {
                    this.listenerSubState_0 = ListenerSubState.ExcuteAcceptSocketV6;
                    socket = this.tcpListener_1.AcceptSocket();
                }
            }
            if (socket == null)
            {
                this.listenerSubState_0 = ListenerSubState.IdleSleep;
                Thread.Sleep(this.int_4);
                return true;
            }
            this.listenerSubState_0 = ListenerSubState.SetSocketOption;
            byte[] optionInValue = smethod_1(1, 0x4e20, 0x7d0);
            socket.IOControl(IOControlCode.KeepAliveValues, optionInValue, null);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, this.int_1);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, this.int_2);
            this.listenerSubState_0 = ListenerSubState.NewNetworkStream;
            NetworkStream stream = new NetworkStream(socket, true);
            this.listenerSubState_0 = ListenerSubState.SpringEstablishedEvent;
            if (this.bool_0)
            {
                this.eventSafeTrigger_0.ActionAsyn<NetworkStream, EndPoint>("TcpConnectionEstablished", this.TcpConnectionEstablished, stream, socket.RemoteEndPoint);
            }
            else
            {
                this.eventSafeTrigger_0.Action<NetworkStream, EndPoint>("TcpConnectionEstablished", this.TcpConnectionEstablished, stream, socket.RemoteEndPoint);
            }
            this.listenerSubState_0 = ListenerSubState.IdleSleep;
            return true;
        }
        catch (Exception exception)
        {
            this.listenerSubState_0 = ListenerSubState.ExitWithException;
            this.iagileLogger_0.Log(exception, "CJFramework.AgileTcpListener.DoDetect - 异常导致监听线程退出。", ErrorLevel.High);
            return false;
        }
    }

    internal bool method_0()
    {
        return  this.object_0==1;
    }

    internal void method_1(Interface20 interface20_1)
    {
        this.interface20_0 = interface20_1;
    }

    internal int method_2()
    {
        return this.int_1;
    }

    internal void method_3(int int_5)
    {
        this.int_1 = int_5;
    }

    internal int method_4()
    {
        return this.int_2;
    }

    internal void method_5(int int_5)
    {
        this.int_2 = int_5;
    }

    private void method_6(bool bool_3, bool bool_4)
    {
        string str = !bool_4 ? " [ SecurityDog ]" : "";
        if (!((!string.IsNullOrEmpty(str) || (this.enum0_0 != ((ClientTimeEnum) 3))) || bool_3))
        {
            str = " [ SN Start Code Expired ]";
        }
        if (!(bool_3 && bool_4))
        {
            this.iagileLogger_1.LogWithTime("Current server instance is not authorized ! " + str);
        }
        else
        {
            this.iagileLogger_1.LogWithTime("Current server instance has been authorized ! " + str);
        }
    }

    public bool method_7()
    {
        return this.class117_0.method_0();
    }

    public void method_8()
    {
        if (!this.bool_1)
        {
            if ((this.enum0_0 == ((ClientTimeEnum) 1)) && !this.class117_0.method_7())
            {
                this.iagileLogger_1.LogWithTime("Current server instance must run on internet ! ");
                return;
            }
            if (this.enum0_0 == ((ClientTimeEnum) 2))
            {
                string str = null;
                if (!Class44.smethod_0(this.string_0, out str))
                {
                    this.iagileLogger_1.LogWithTime("Failed to verify Security Dog for Current server instance. " + str);
                    return;
                }
            }
            if ((this.enum0_0 == ((ClientTimeEnum) 3)) && !Class118.smethod_0(this.string_1))
            {
                this.iagileLogger_1.LogWithTime("SN of current server instance is invalid ! ");
                return;
            }
        }
        this.tcpListener_0.Start();
        if (this.tcpListener_1 != null)
        {
            this.tcpListener_1.Start();
        }
        this.object_0 = 1;
        base.DetectSpanInSecs = 0;
        base.Start();
    }

    public PortListenerState method_9()
    {
        return new PortListenerState(this.dateTime_0,  this.object_0==1, this.class117_0.method_0(), this.interface20_0.imethod_40() >= this.int_0, base.IsRunning, this.listenerSubState_0);
    }

    private static bool smethod_0(string string_2)
    {
        bool createdNew = false;
        mutex_0 = new Mutex(false, string_2, out createdNew);
        return !createdNew;
    }

    internal static byte[] smethod_1(int int_5, int int_6, int int_7)
    {
        byte[] array = new byte[12];
        BitConverter.GetBytes(int_5).CopyTo(array, 0);
        BitConverter.GetBytes(int_6).CopyTo(array, 4);
        BitConverter.GetBytes(int_7).CopyTo(array, 8);
        return array;
    }

    [CompilerGenerated]
    private static void OnTcpConnectionEstablished(object object_1, object object_2)
    {
    }
}

