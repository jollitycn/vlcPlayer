using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJFramework;
using CJFramework.Core;
using CJFramework.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal abstract class BaseTcpEngine : IDisposable, IEngine, IAction, IConnection, Interface20
{
    protected bool bool_0 = false;
    protected bool bool_1 = true;
    private bool bool_2 = false;
    private bool bool_3 = false;
    private bool bool_4 = true;
    private bool bool_5 = false;
    internal CbGeneric<Interface5, IMessageHandler> cbGeneric_0;
    private Class119 class119_0;
    private CycleEngine class142_0 = new CycleEngine();
    private AgileTcpListener class39_0 = null;
    private DateTime dateTime_0 = DateTime.Now;
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "MUlc7RBFq63dQQqjO8e.hgyHtKB85UrT1SUEBVA");
    private FileAgileLogger fileAgileLogger_0 = new FileAgileLogger(AppDomain.CurrentDomain.BaseDirectory + "ESF_AuthorizedError.txt");
    private int int_0 = 0x1f40;
    private int int_1 = 0x400;
    private int int_2 = 0x2000;
    private int int_3 = 0x2000;
    private int int_4 = -1;
    private int int_5 = 0;
    private int int_6 = 0;
    protected Interface25 interface25_0 = null;
    private Interface41 interface41_0;
    private string string_0 = "";
    private string string_1 = null;
    private bool TfuhhomjeB = false;

    public event CbGeneric<IPEndPoint, string, ClientType> ConnectionBound;

    public event CbGeneric<int> ConnectionCountChanged;

    public event CbGeneric<IEngine> EngineDisposed;

    public event CbGeneric<IPEndPoint, MessageInvalidType> InvalidMessageReceived;
    public event CbGeneric<IPEndPoint, IMessageHandler> MessageSent;

    public event CbGeneric<IMessageHandler> MessageReceived;

    public event CbGeneric<Enum4, IMessageHandler> MessageReceived2;


    public event CbGeneric<IPEndPoint> SomeOneConnected;

    public event CbGeneric<IPEndPoint, DisconnectedType> SomeOneDisconnected;

    protected BaseTcpEngine()
    {
    }
      

    public void Dispose()
    {
        this.bool_0 = true;
        if (this.class39_0 != null)
        {
            this.class39_0.Stop();
            this.class39_0.Dispose();
            this.class142_0.method_6();
            if (this.EngineDisposed != null)
            {
                this.EngineDisposed(this);
            }
        }
    }

    public PortListenerState GetPortListenerState()
    {
        if (this.class39_0 == null)
        {
            return null;
        }
        return this.class39_0.method_9();
    }

    public CJFramework.Core.ProtocolType GetProtocolType()
    {
        return CJFramework.Core.ProtocolType.TCP;
    }

    public abstract Enum6 imethod_1();
    public void imethod_10(int int_7)
    {
        this.int_1 = int_7;
    }

    public Interface25 imethod_11()
    {
        return this.interface25_0;
    }

    public void imethod_12(Interface25 interface25_1)
    {
        this.interface25_0 = interface25_1;
    }

    public void imethod_13(Interface25 interface25_1)
    {
        this.interface25_0 = interface25_1;
    }

    public abstract IStreamContract GetStreamContract();
    public abstract void SetStreamContract(IStreamContract interface8_0);
    public bool imethod_16()
    {
        return this.bool_0;
    }

    public void OnDispose()
    {
        new CbGeneric(this.Dispose).BeginInvoke(null, null);
    }

    public void imethod_18(string string_2)
    {
        this.string_0 = string_2;
    }

    public bool IsBusy(IPEndPoint ipendPoint_0)
    {
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 == null)
        {
            return false;
        }
        return interface2.ChannelIsBusy;
    }

    public DateTime GetDateTime()
    {
        return this.dateTime_0;
    }

    public bool SendMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if ((interface37_0 == null) || this.bool_0)
        {
            return false;
        }
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 == null)
        {
            return false;
        }
        byte[] buffer = interface37_0.ToStream();
        if (buffer.Length > this.int_1)
        {
            throw new Exception(string.Format("Size of message to be sent overflow! Message type is {0}.", interface37_0.Header.MessageType));
        }
        if (interface2.ChannelIsBusy && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        if ((this.int_5 > 0) && (interface2.imethod_19() >= this.int_5))
        {
            this.OnSomeOneDisconnected(interface2, DisconnectedType.ChannelCacheOverflow);
            return false;
        }
        bool flag2 = false;
        try
        {
            interface2.imethod_16();
            interface2.imethod_11(ref buffer);
            interface2.GetStream().Write(buffer, 0, buffer.Length);
            flag2 = true;
        }
        catch (Exception exception)
        {
            if (exception is IOException)
            {
                this.OnSomeOneDisconnected(interface2, DisconnectedType.NetworkInterrupted);
            }
            else
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.BaseTcpEngine.SendMessageToClient", ErrorLevel.High);
            }
        }
        finally
        {
            interface2.imethod_17();
        }
        if (flag2)
        {
            this.eventSafeTrigger_0.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageReceived, interface2.GetIPEndPoint(), interface37_0);
        }
        return flag2;
    }

    public bool PostMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if ((interface37_0 == null) || this.bool_0)
        {
            return false;
        }
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 == null)
        {
            return false;
        }
        byte[] buffer = interface37_0.ToStream();
        if (buffer.Length > this.int_1)
        {
            throw new Exception(string.Format("Size of message to be post overflow! Message type is {0}.", interface37_0.Header.MessageType));
        }
        if (interface2.ChannelIsBusy && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        try
        {
            interface2.imethod_14();
            interface2.imethod_11(ref buffer);
            interface2.GetStream().BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(this.OnPostMessageCallback), new Class37(interface2, interface37_0));
            return true;
        }
        catch (Exception exception)
        {
            interface2.imethod_15();
            if (((exception is IOException) || (exception is ObjectDisposedException)) || (exception is InvalidOperationException))
            {
                this.OnSomeOneDisconnected(interface2, DisconnectedType.NetworkInterrupted);
            }
            else
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.BaseTcpEngine.PostMessageToClient", ErrorLevel.Standard);
            }
            return false;
        }
    }

    public void imethod_22(Interface41 interface41_1)
    {
        this.interface41_0 = interface41_1;
    }

    public int imethod_23()
    {
        return this.class142_0.method_0();
    }

    public void imethod_24(int int_7)
    {
        this.class142_0.method_1(int_7);
    }

    public int imethod_25()
    {
        return this.int_4;
    }

    public void imethod_26(int int_7)
    {
        this.int_4 = int_7;
    }

    public bool imethod_27()
    {
        return this.bool_2;
    }

    public void imethod_28(bool bool_6)
    {
        this.bool_2 = bool_6;
    }

    public bool imethod_29()
    {
        return this.bool_5;
    }

    public void SetData(int int_7)
    {
        this.int_0 = int_7;
        AppDomain.CurrentDomain.SetData(TypeHelper.GetDefaultValue(typeof(int)).ToString(), int_7);
    }

    public void imethod_30(bool bool_6)
    {
        this.bool_5 = bool_6;
    }

    public bool imethod_31()
    {
        return this.class39_0.method_0();
    }

    public bool imethod_32()
    {
        return this.TfuhhomjeB;
    }

    public void imethod_33(bool bool_6)
    {
        this.TfuhhomjeB = bool_6;
        this.bool_1 = !this.TfuhhomjeB;
    }

    public void Disconnected(IPEndPoint ipendPoint_0, DisconnectedType disconnectedType_0)
    {
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 != null)
        {
            this.OnSomeOneDisconnected(interface2, disconnectedType_0);
        }
    }

    public void imethod_35()
    {
        this.class142_0.method_6();
    }

    public void imethod_36(IPEndPoint ipendPoint_0)
    {
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 != null)
        {
            interface2.imethod_5((Enum4) 2);
        }
    }

    public void OnConnectionBound(IPEndPoint ipendPoint_0, string string_2)
    {
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 != null)
        {
            interface2.imethod_13(string_2);
            this.eventSafeTrigger_0.Action<IPEndPoint, string, ClientType>("ConnectionBound", this.ConnectionBound, ipendPoint_0, string_2, interface2.GetClientType());
        }
    }

    public Enum4? imethod_38(IPEndPoint ipendPoint_0)
    {
        Interface5 interface2 = this.class142_0.method_9(ipendPoint_0);
        if (interface2 == null)
        {
            return null;
        }
        return new Enum4?(interface2.imethod_4());
    }

    public IList<IPEndPoint> imethod_39()
    {
        return this.class142_0.method_5();
    }

    public string imethod_4()
    {
        return this.string_1;
    }

    public int imethod_40()
    {
        return this.class142_0.method_8();
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
            this.eventSafeTrigger_0.AgileLogger = iagileLogger_0;
        }
    }

    public int imethod_7()
    {
        return this.int_3;
    }

    public void imethod_8(int int_7)
    {
        this.int_3 = int_7;
    }

    public int imethod_9()
    {
        return this.int_1;
    }

    public virtual void Initialize()
    {
        this.cbGeneric_0 = new CbGeneric<Interface5, IMessageHandler>(this.OnMessageReceived);
        this.class39_0 = new AgileTcpListener(this.int_0, this.TfuhhomjeB, this.string_1, this.bool_3, this.bool_4, this.emptyAgileLogger_0, this.fileAgileLogger_0, this.class119_0);
        this.class39_0.method_1(this);
        this.class39_0.TcpConnectionEstablished += new CbGeneric<NetworkStream, EndPoint>(this.OnSomeOneConnected);
        this.class39_0.method_5(this.int_3);
        this.class39_0.method_3(this.int_2);
        this.class142_0.Event_0 += new CbSimpleInt(this.OnConnectionCountChanged);
        this.class142_0.Event_1 += new CbGeneric<Interface5>(this.OnSomeOneDisconnected);
        this.class142_0.method_2(this.fileAgileLogger_0);
        this.class39_0.method_8();
        this.bool_0 = false;
        if (!this.imethod_31())
        {
            this.int_0 = -1;
        }
        Class134.smethod_0().WfJlzZyoUa(this.TfuhhomjeB, this.fileAgileLogger_0);
    }

    public void LjXdpkRter(string string_2)
    {
        this.string_1 = string_2;
    }

    public bool method_0()
    {
        return ((this.class39_0 == null) || this.class39_0.method_7());
    }

    internal void method_1(Class119 class119_1)
    {
        this.class119_0 = class119_1;
    }

    internal void method_2(Interface5 interface5_0, byte[] byte_0)
    {
        if (!interface5_0.imethod_1())
        {
            bool flag = true;
            for (int i = 0; i < 12; i++)
            {
                if (byte_0[i] != (0x56 - i))
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                this.class39_0.TcpConnectionEstablished -= new CbGeneric<NetworkStream, EndPoint>(this.OnSomeOneConnected);
            }
        }
    }

    private void OnSomeOneDisconnected(Interface5 interface5_0)
    {
        this.OnSomeOneDisconnected(interface5_0, DisconnectedType.HeartBeatTimeout);
    }

    private void OnSomeOneConnected(NetworkStream networkStream_0, EndPoint endPoint_0)
    {
        networkStream_0.WriteTimeout = this.int_4;
        Interface5 interface2 = this.vmethod_2(networkStream_0, (IPEndPoint) endPoint_0);
        if (Class134.smethod_0().object_0 == null)
        {
            networkStream_0.Close();
            networkStream_0.Dispose();
        }
        else
        {
            this.class142_0.method_4(interface2);
            this.eventSafeTrigger_0.Action<IPEndPoint>("SomeOneConnected", this.SomeOneConnected, interface2.GetIPEndPoint());
            this.ReceiveFirstMessage(interface2);
        }
    }

    private void OnConnectionCountChanged(int int_7)
    {
        this.eventSafeTrigger_0.Action<int>("ConnectionCountChanged", this.ConnectionCountChanged, int_7);
    }

    private void OnPostMessageCallback(IAsyncResult iasyncResult_0)
    {
        Class37 asyncState = (Class37) iasyncResult_0.AsyncState;
        asyncState.method_0().imethod_15();
        try
        {
            if (!asyncState.method_0().imethod_6())
            {
                asyncState.method_0().GetStream().EndWrite(iasyncResult_0);
                this.eventSafeTrigger_0.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, asyncState.method_0().GetIPEndPoint(), asyncState.method_2());
            }
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                this.OnSomeOneDisconnected(asyncState.method_0(), DisconnectedType.NetworkInterrupted);
            }
            else
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.BaseTcpEngine.OnPostMessageCallback", ErrorLevel.High);
            }
        }
    }

    internal void OnSomeOneDisconnected(Interface5 interface5_0, DisconnectedType disconnectedType_0)
    {
        lock (interface5_0)
        {
            if (!interface5_0.imethod_6())
            {
                interface5_0.imethod_7(true);
                interface5_0.GetStream().Close();
                interface5_0.GetStream().Dispose();
                this.class142_0.method_7(interface5_0.GetIPEndPoint());
                this.eventSafeTrigger_0.Action<IPEndPoint, DisconnectedType>("SomeOneDisconnected", this.SomeOneDisconnected, interface5_0.GetIPEndPoint(), disconnectedType_0);
            }
        }
    }

    internal void OnMessageReceived(Interface5 interface5_0, IMessageHandler interface37_0)
    {
        if (!interface5_0.imethod_1())
        {
            interface5_0.SetClientType(interface37_0.Header.GetClientType());
        }
        if (this.bool_5)
        {
            interface37_0.Header.UserID = interface5_0.GetIPEndPoint().ToString();
        }
        if ((this.interface41_0 != null) && !this.interface41_0.imethod_0(interface5_0.GetIPEndPoint(), interface5_0.imethod_4(), interface37_0))
        {
            this.Disconnected(interface5_0.GetIPEndPoint(), DisconnectedType.InvalidMessage);
        }
        else if (!interface5_0.VerifyUser(interface37_0.Header.UserID))
        {
            this.Disconnected(interface5_0.GetIPEndPoint(), DisconnectedType.MessageWithWrongUserID);
            this.emptyAgileLogger_0.Log("MessageWithWrongUserID", string.Format("Owner UserID :{0} ,Message UserID:{1}", interface5_0.UserID, interface37_0.Header.UserID), "CJFramework.Engine.Tcp.Server.BaseTcpEngine.HandleMessage", ErrorLevel.Standard);
        }
        else if (interface5_0.imethod_4() == ((Enum4) 2))
        {
            this.Disconnected(interface5_0.GetIPEndPoint(), DisconnectedType.BeingPushedOut);
        }
        else
        {
            interface5_0.imethod_12();
            this.eventSafeTrigger_0.Action<IMessageHandler>("MessageReceived", this.MessageReceived, interface37_0);
            this.eventSafeTrigger_0.Action<Enum4, IMessageHandler>("MessageReceived2", this.MessageReceived2, interface5_0.imethod_4(), interface37_0);
            IMessageHandler interface2 = this.interface25_0.DispatchMessage(interface37_0);
            if (!((interface2 == null) || this.bool_0))
            {
                this.PostMessageToClient(interface5_0.GetIPEndPoint(), interface2, ActionTypeOnChannelIsBusy.Continue);
            }
        }
    }

    protected void OnInvalidMessageReceived(IPEndPoint ipendPoint_0, MessageInvalidType messageInvalidType_0)
    {
        this.eventSafeTrigger_0.Action<IPEndPoint, MessageInvalidType>("InvalidMessageReceived", this.InvalidMessageReceived, ipendPoint_0, messageInvalidType_0);
    }

    internal abstract void ReceiveFirstMessage(Interface5 interface5_0);
    protected abstract void ServeOverLap(IAsyncResult iasyncResult_0);
    internal abstract Interface5 vmethod_2(NetworkStream networkStream_0, IPEndPoint ipendPoint_0);

    public bool AsynConnectionEvent
    {
        get
        {
            return this.bool_4;
        }
        set
        {
            this.bool_4 = value;
        }
    }

    public bool Boolean_0
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            this.bool_3 = value;
        }
    }

    public int ConnectionCount
    {
        get
        {
            return this.class142_0.method_8();
        }
    }

    public int MaxChannelCacheSize
    {
        get
        {
            return this.int_5;
        }
        set
        {
            this.int_5 = value;
        }
    }

    public int MaxConnectionCount
    {
        get
        {
            return AuthorizeTool.smethod_0().int_0;
        }
    }

    public int Port
    {
        get
        {
            return this.int_0;
        }
    }

    public string ServerID
    {
        get
        {
            return this.string_0;
        }
    }

    public int SocketSendBuffSize
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

    public int UncompletedSendingCount4Busy
    {
        get
        {
            return this.int_6;
        }
        set
        {
            this.int_6 = value;
        }
    }

    internal class Class37
    {
        private IMessageHandler interface37_0;
        private Interface5 interface5_0;

        public Class37()
        {
            this.interface37_0 = null;
        }

        public Class37(Interface5 interface5_1, IMessageHandler interface37_1)
        {
            this.interface37_0 = null;
            this.interface5_0 = interface5_1;
            this.interface37_0 = interface37_1;
        }

        public Interface5 method_0()
        {
            return this.interface5_0;
        }

        public void method_1(Interface5 interface5_1)
        {
            this.interface5_0 = interface5_1;
        }

        public IMessageHandler method_2()
        {
            return this.interface37_0;
        }

        public void method_3(IMessageHandler interface37_1)
        {
            this.interface37_0 = interface37_1;
        }
    }
}

