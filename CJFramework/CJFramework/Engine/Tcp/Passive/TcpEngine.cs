using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using CJFramework;
using CJFramework.Core;
using CJFramework.Engine.Tcp.Passive;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal abstract class TcpEngine : IDisposable, IEngine, ICommitMessageToServer, Interface26
{
    private AgileIPE agileIPE_0;
    internal static bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = false;
    private bool bool_3 = false;
    private bool bool_4 = false;
    private CbGeneric cbGeneric_0 = null;
    private Class85 class85_0;
    private DateTime dateTime_0 = DateTime.Now;
    private Delegate delegate_0;
    private Delegate delegate_1;
    private Delegate delegate_2;
    private Delegate delegate_3;
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private EventSafeTrigger EodfwttmVK = new EventSafeTrigger(new EmptyAgileLogger(), "CJFramework.Engine.Tcp.Passive.TcpEngine");
    private int int_0 = 0x2000;
    private int int_1 = 0x2000;
    private int int_2 = 0x400;
    private int int_3 = 0;
    private int int_4 = 0;
    private int int_5 = 0;
    private int int_6 = 0;
    private int int_7 = -1;
    protected Interface25 interface25_0 = null;
    private IStreamContract interface8_0;
    protected IPEndPoint ipendPoint_0;
    protected NetworkStream object_0;
    private int isConnected = 0;
    private object object_2 = new object();
    private object object_3 = new object();
    private object object_4 = 0;
    private CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo sock5ProxyInfo_0;
    private string string_0 = null;

    public event CbGeneric ConnectionInterrupted
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_0;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_0;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric ConnectionRebuildFailure
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_2;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_2;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric ConnectionRebuildStart
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_1;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_1;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric ConnectionRebuildSucceed
    {
        add
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_3;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Combine(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
        remove
        {
            CbGeneric generic2;
            CbGeneric generic = (CbGeneric) this.delegate_3;
            do
            {
                generic2 = generic;
                CbGeneric generic3 = (CbGeneric) Delegate.Remove(generic2, value);
                generic = Interlocked.CompareExchange<CbGeneric>(ref generic, generic3, generic2);
            }
            while (generic != generic2);
        }
    }

    public event CbGeneric<IEngine> EngineDisposed;

    public event CbGeneric<IPEndPoint, MessageInvalidType> InvalidMessageReceived;

    public event CbGeneric<IMessageHandler> MessageReceived;

    public event CbGeneric<IPEndPoint, IMessageHandler> MessageSent;

    protected TcpEngine()
    {
    }

    public void CloseConnection(bool bool_5)
    {
        if (this.isConnected != null)
        {
            if (this.object_0 != null)
            {
                this.object_0.Close();
                this.object_0.Dispose();
            }
            this.method_0((NetworkStream) this.object_0, !bool_5);
            if (bool_5)
            {
                this.imethod_26(0x1388);
            }
        }
    }

    public void Dispose()
    {
        if (!this.bool_3)
        {
            this.bool_3 = true;
            this.bool_2 = false;
            if (this.object_0 != null)
            {
                this.object_0.Close();
                this.object_0.Dispose();
                this.object_0 = null;
            }
            this.method_0((NetworkStream) this.object_0, false);
            if (this.EngineDisposed != null)
            {
                this.EngineDisposed(this);
            }
        }
    }

    public CJFramework.Core.ProtocolType GetProtocolType()
    {
        return CJFramework.Core.ProtocolType.TCP;
    }

    public abstract Enum6 imethod_1();
    public void imethod_10(int int_8)
    {
        this.int_2 = int_8;
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
        return this.bool_3;
    }

    public void OnDispose()
    {
        new CbGeneric(this.Dispose).BeginInvoke(null, null);
    }

    public AgileIPE GetAgileIPE()
    {
        return this.agileIPE_0;
    }

    public void SetAgileIPE(AgileIPE agileIPE_1)
    {
        this.agileIPE_0 = agileIPE_1;
    }

    public DateTime GetDateTime()
    {
        return this.dateTime_0;
    }

    public bool CommitMessageToServer(IMessageHandler interface37_0, bool bool_5, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (((interface37_0 == null) ? 0 : this.isConnected) == null)
        {
            return false;
        }
        if (this.ChannelIsBusy && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        byte[] buffer = interface37_0.ToStream();
        if (buffer.Length > this.int_2)
        {
            string msg = string.Format("Size of message to be sent overflow! Message type is {0}.", interface37_0.Header.MessageType);
            this.emptyAgileLogger_0.Log("MessageSizeOverFlow", msg, "CJFramework.Engine.Tcp.Passive.TcpEngine.CommitMessageToServer", ErrorLevel.High);
            return false;
        }
        if (bool_5)
        {
            return this.PostMessageToServer(buffer, interface37_0);
        }
        return this.SendMessageToServer(buffer, interface37_0);
    }

    public bool imethod_21()
    {
        return this.bool_1;
    }

    public int imethod_22()
    {
        return this.int_7;
    }

    public void imethod_23(int int_8)
    {
        this.int_7 = int_8;
        if (this.int_7 <= 0)
        {
            this.int_7 = -1;
        }
    }

    public CbGeneric imethod_24()
    {
        return this.cbGeneric_0;
    }

    public void imethod_25(CbGeneric cbGeneric_5)
    {
        this.cbGeneric_0 = cbGeneric_5;
    }

    public void imethod_26(int int_8)
    {
        if (((this.object_4 == null) && (this.isConnected == null)) && !this.bool_3)
        {
            lock (this.object_3)
            {
                if (this.isConnected != 0)
                {
                    return;
                }
                this.object_4 = 1;
                this.EodfwttmVK.Action("ConnectionRebuildStart", this.delegate_1);
                this.int_3 = 0;
                while (!this.bool_3)
                {
                    try
                    {
                        this.Initialize();
                        this.object_4 = 0;
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(int_8);
                        continue;
                    }
                }
            }
            if (this.isConnected != 0)
            {
                if (this.cbGeneric_0 != null)
                {
                    try
                    {
                        this.cbGeneric_0();
                    }
                    catch
                    {
                    }
                }
                this.EodfwttmVK.Action("ConnectionRebuildSucceed", this.delegate_3);
            }
            else
            {
                this.EodfwttmVK.Action("ConnectionRebuildFailure", this.delegate_2);
            }
        }
    }

    public void imethod_27()
    {
        this.bool_1 = true;
    }

    public void SetData(int int_8)
    {
        this.int_3 = int_8;
    }

    public string imethod_4()
    {
        return this.string_0;
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
            this.EodfwttmVK.AgileLogger = iagileLogger_0;
        }
    }

    public int imethod_7()
    {
        return this.int_1;
    }

    public void imethod_8(int int_8)
    {
        this.int_1 = int_8;
    }

    public int imethod_9()
    {
        return this.int_2;
    }

    public void Initialize()
    {
        if (!this.bool_4)
        {
            this.string_0 = null;
        }
        this.int_6 = 0;
        this.int_5 = 0;
        if (this.sock5ProxyInfo_0 != null)
        {
            this.object_0 = this.sock5ProxyInfo_0.method_0(this.agileIPE_0.String_0, this.agileIPE_0.Port, this.int_1, this.int_0, out this.class85_0);
        }
        else
        {
            this.class85_0 = new Class85(this.agileIPE_0.String_0, this.agileIPE_0.Port, this.int_3, this.string_0);
            this.class85_0.method_11(this.int_1);
            this.class85_0.method_9(this.int_0);
            this.object_0 = this.class85_0.method_12();
        }
        this.object_0.WriteTimeout = this.int_7;
        this.string_0 = this.class85_0.method_6();
        this.int_3 = this.class85_0.method_4();
        this.ipendPoint_0 = this.agileIPE_0.IPEndPoint_0;
        this.isConnected = 1;
        this.vmethod_0();
        bool_0 = true;
    }

    public void LjXdpkRter(string string_1)
    {
        this.string_0 = string_1;
        this.bool_4 = string_1 != null;
    }

    protected void method_0(NetworkStream networkStream_0, bool bool_5)
    {
        if ((networkStream_0 == this.object_0) && (this.isConnected != null))
        {
            lock (this.object_2)
            {
                if (this.isConnected == null)
                {
                    return;
                }
                this.isConnected = 0;
                this.bool_1 = false;
            }
            this.class85_0.Dispose();
            this.EodfwttmVK.ActionAsyn("ConnectionInterrupted", this.delegate_0);
            if (!((!this.bool_2 || !bool_5) || this.bool_3))
            {
                Thread.Sleep(0x1388);
                new CbGeneric<int>(this.imethod_26).BeginInvoke(0x1388, null, null);
            }
        }
    }

    protected void AsynHandleMessage(IMessageHandler interface37_0)
    {
        try
        {
            this.EodfwttmVK.Action<IMessageHandler>("MessageReceived", this.MessageReceived, interface37_0);
            IMessageHandler interface2 = this.interface25_0.DispatchMessage(interface37_0);
            if (interface2 != null)
            {
                this.CommitMessageToServer(interface2, true, ActionTypeOnChannelIsBusy.Continue);
            }
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception.GetType().ToString(), exception.Message, "CJFramework.Engine.Tcp.Passive.Stream.StreamTcpEngine.AsynHandleMessage", ErrorLevel.High);
        }
    }

    private bool SendMessageToServer(byte[] byte_0, IMessageHandler interface37_0)
    {
        bool flag = false;
        NetworkStream stream = (NetworkStream) this.object_0;
        try
        {
            Interlocked.Increment(ref this.int_6);
            stream.Write(byte_0, 0, byte_0.Length);
            flag = true;
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                this.method_0(stream, true);
            }
            else
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Passive.TcpEngine.SendMessageToServer", ErrorLevel.Standard);
            }
        }
        finally
        {
            Interlocked.Decrement(ref this.int_6);
            if (this.int_6 < 0)
            {
                this.int_6 = 0;
            }
        }
        if (flag)
        {
            this.EodfwttmVK.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, this.agileIPE_0.IPEndPoint_0, interface37_0);
        }
        return flag;
    }

    private bool PostMessageToServer(byte[] byte_0, IMessageHandler interface37_0)
    {
        NetworkStream stream = (NetworkStream) this.object_0;
        try
        {
            Interlocked.Increment(ref this.int_5);
            stream.BeginWrite(byte_0, 0, byte_0.Length, new AsyncCallback(this.SendMessageToServer), new Parameter<NetworkStream, IMessageHandler>(stream, interface37_0));
            return true;
        }
        catch (Exception exception)
        {
            Interlocked.Decrement(ref this.int_5);
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                this.method_0(stream, true);
            }
            else
            {
                this.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Passive.TcpEngine.PostMessageToServer", ErrorLevel.Standard);
            }
            return false;
        }
    }

    private void SendMessageToServer(IAsyncResult iasyncResult_0)
    {
        Parameter<NetworkStream, IMessageHandler> asyncState = (Parameter<NetworkStream, IMessageHandler>) iasyncResult_0.AsyncState;
        if ((this.isConnected != null) && (asyncState.Arg1 == this.object_0))
        {
            try
            {
                asyncState.Arg1.EndWrite(iasyncResult_0);
                this.EodfwttmVK.Action<IPEndPoint, IMessageHandler>("MessageSent", this.MessageSent, this.agileIPE_0.IPEndPoint_0, asyncState.Arg2);
            }
            catch (Exception exception)
            {
                if ((exception is IOException) || (exception is ObjectDisposedException))
                {
                    this.method_0(asyncState.Arg1, true);
                }
            }
            finally
            {
                if (this.isConnected != 0)
                {
                    Interlocked.Decrement(ref this.int_5);
                    if (this.int_5 < 0)
                    {
                        this.int_5 = 0;
                    }
                }
            }
        }
    }

    protected void OnInvalidMessageReceived(IPEndPoint ipendPoint_1, MessageInvalidType messageInvalidType_0)
    {
        this.EodfwttmVK.Action<IPEndPoint, MessageInvalidType>("InvalidMessageReceived", this.InvalidMessageReceived, ipendPoint_1, messageInvalidType_0);
    }

    protected abstract void vmethod_0();

    public bool AutoReconnect
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            this.bool_2 = value;
        }
    }

    public bool ChannelIsBusy
    {
        get
        {
            if (this.int_4 < 0)
            {
                return false;
            }
            return ((this.int_6 + this.int_5) > this.int_4);
        }
    }

    public bool Connected
    {
        get
        {
            return this.isConnected == 1;
        }
    }

    public int Port
    {
        get
        {
            return this.int_3;
        }
    }

    public CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo Sock5ProxyInfo
    {
        get
        {
            return this.sock5ProxyInfo_0;
        }
        set
        {
            this.sock5ProxyInfo_0 = value;
        }
    }

    public int SocketSendBuffSize
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

