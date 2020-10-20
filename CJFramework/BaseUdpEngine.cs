using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJFramework.Core;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal abstract class BaseUdpEngine : IDisposable, IEngine, IUdpHelper
{
    protected bool bool_0 = true;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private DateTime dateTime_0 = DateTime.Now;
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private Enum6 enum6_0 = ((Enum6) 0);
    private EventSafeTrigger eventSafeTrigger_0 = new EventSafeTrigger(new EmptyAgileLogger(), "wZcFHWri0qHLPpVwNxg.GMNqXVrZbau0eruOyUO");
    protected int int_0 = 0x1f40;
    private int int_1 = 0x2000;
    private int int_2 = 0x2000;
    private int int_3 = 0x400;
    private int int_4 = 0;
    protected Interface25 interface25_0 = null;
    private Interface44 interface44_0;
    private IStreamContract interface8_0;
    protected IPv6 object_0;
    private string string_0 = "";
    private string string_1;

    public event CbGeneric<IEngine> EngineDisposed;

    public event CbGeneric<IPEndPoint, MessageInvalidType> InvalidMessageReceived;

    public event CbGeneric<IMessageHandler> MessageReceived;

    public event CbGeneric<IPEndPoint, IMessageHandler> MessageSent;

    protected BaseUdpEngine()
    {
    }

    event CbGeneric<IEngine> IEngine.EngineDisposed
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public void Dispose()
    {
        this.bool_2 = true;
        this.object_0.Dispose();
        if (this.EngineDisposed != null)
        {
            this.EngineDisposed(this);
        }
    }

    public CJFramework.Core.ProtocolType GetProtocolType()
    {
        return CJFramework.Core.ProtocolType.UDP;
    }

    public Enum6 imethod_1()
    {
        return this.enum6_0;
    }

    public void imethod_10(int int_5)
    {
        this.int_3 = int_5;
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

    public IStreamContract GetStreamContract()
    {
        return this.interface8_0;
    }

    public void SetStreamContract(IStreamContract interface8_1)
    {
        this.interface8_0 = interface8_1;
    }

    public bool imethod_16()
    {
        return this.bool_2;
    }

    public void OnDispose()
    {
        new CbGeneric(this.Dispose).BeginInvoke(null, null);
    }

    public void imethod_18(string string_2)
    {
        this.string_0 = string_2;
    }

    public void imethod_19(Enum6 enum6_1)
    {
        this.enum6_0 = enum6_1;
    }

    public DateTime GetDateTime()
    {
        return this.dateTime_0;
    }

    public bool imethod_20()
    {
        return this.bool_1;
    }

    public IUdpSessionHelper GetIUdpSessionHelper()
    {
        return (this.object_0 as IUdpSessionHelper);
    }

    public void sendMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0)
    {
        if (interface37_0 != null)
        {
            byte[] buffer = interface37_0.ToStream();
            if (buffer.Length > this.int_3)
            {
                throw new Exception(string.Format("Size of message to be sent overflow! Message type is {0}.", interface37_0.Header.MessageType));
            }
            this.object_0.imethod_0(buffer, ipendPoint_0);
            this.eventSafeTrigger_0.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, ipendPoint_0, interface37_0);
        }
    }

    public void SetData(int int_5)
    {
        this.int_0 = int_5;
    }

    public string imethod_4()
    {
        return this.string_1;
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
        return this.int_2;
    }

    public void imethod_8(int int_5)
    {
        this.int_2 = int_5;
    }

    public int imethod_9()
    {
        return this.int_3;
    }

    public virtual void Initialize()
    {
        this.method_0(this.GetPv6UdpClient(), false, null, "");
    }

    public void LjXdpkRter(string string_2)
    {
        this.string_1 = string_2;
    }

    public void method_0(IPv6UdpClient class164_0, bool bool_3, Interface18 interface18_0, string string_2)
    {
        this.bool_1 = bool_3;
        class164_0.SetAgileLogger(this.emptyAgileLogger_0);
        class164_0.HandleExcetion += new CbGeneric<Exception>(this.OnException);
        class164_0.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, this.int_1);
        class164_0.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, this.int_2);
        class164_0.IOControl(-1744830452, new byte[] { Convert.ToByte(false) }, null);
        this.int_0 = class164_0.method_2();
        if (!this.bool_0)
        {
            this.string_1 = class164_0.GetIPAddress().ToString();
        }
        if (this.bool_1)
        {
            ReliableUdpEngine class2 = new ReliableUdpEngine(class164_0, this.int_3, this.emptyAgileLogger_0, interface18_0, string_2);
            this.object_0 = class2;
        }
        else
        {
            class164_0.Initialize();
            this.object_0 = class164_0;
        }
        this.interface44_0 = Class128.smethod_0(this.enum6_0, this.interface8_0, this.int_3, this.string_0);
        this.object_0.DataReceived += new CbGeneric<IPEndPoint, byte[]>(this.udpClient_DataReceived);
    }

    private void OnException(Exception exception_0)
    {
        if (!this.bool_2)
        {
            this.emptyAgileLogger_0.Log(exception_0, "CJFramework.Engine.Udp.UdpClient.Exception", ErrorLevel.High);
        }
    }

    private void udpClient_DataReceived(IPEndPoint ipendPoint_0, byte[] byte_0)
    {
        try
        {
            Class29 class2 = this.interface44_0.imethod_0(ipendPoint_0, byte_0);
            if ((class2 != null) && class2.method_6())
            {
                this.HandleMessage(class2.method_0(), class2.method_2());
            }
            else
            {
                this.emptyAgileLogger_0.Log("ErrorMessage", string.Format("Source Address:{0} ,MessageInvalidType:{1}", class2.method_0(), class2.method_4()), "CJFramework.Engine.Udp.BaseUdpEngine.udpClient_DataReceived", ErrorLevel.Standard);
                this.eventSafeTrigger_0.Action<IPEndPoint, MessageInvalidType>("InvalidMessageReceived", this.InvalidMessageReceived, class2.method_0(), class2.method_4());
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Udp.BaseUdpEngine.udpClient_DataReceived", ErrorLevel.High);
        }
    }

    protected void HandleMessage(IPEndPoint ipendPoint_0, IMessageHandler interface37_0)
    {
        try
        {
            this.eventSafeTrigger_0.Action<IMessageHandler>("MessageReceived", this.MessageReceived, interface37_0);
            IMessageHandler interface2 = this.interface25_0.DispatchMessage(interface37_0);
            if (interface2 != null)
            {
                byte[] buffer = interface2.ToStream();
                this.object_0.imethod_0(buffer, ipendPoint_0);
                this.eventSafeTrigger_0.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, ipendPoint_0, interface2);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Udp.BaseUdpEngine.HandleMessage", ErrorLevel.High);
        }
    }

    public void SendMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0)
    {
        if (interface37_0 != null)
        {
            byte[] buffer = interface37_0.ToStream();
            if (buffer.Length > this.int_3)
            {
                throw new Exception(string.Format("Size of message to be sent overflow! Message type is {0}.", interface37_0.Header.MessageType));
            }
            this.object_0.Send(buffer, ipendPoint_0);
            this.eventSafeTrigger_0.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, ipendPoint_0, interface37_0);
        }
    }

    protected abstract IPv6UdpClient GetPv6UdpClient();

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
            return this.int_1;
        }
        set
        {
            this.int_1 = value;
        }
    }

    public int UncompletedSendingCount4Busy
    {
        get
        {
            return this.int_4;
        }
        set
        {
            this.int_4 = value;
        }
    }
}

