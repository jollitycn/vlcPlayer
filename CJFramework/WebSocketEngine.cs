using CJBasic.Loggers;
using CJFramework.Core;
using CJFramework.Server;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

internal class WebSocketEngine : BaseTcpEngine
{
    private Class38 class38_0 = new Class38();
    private bool heHhGnOsoo = false;
    private IStreamContractHelper1 interface46_0;
    private object object_0 = null;
    private SslProtocols sslProtocols_0 = SslProtocols.None;

    public WebSocketEngine(X509Certificate2 x509Certificate2_0, SslProtocols sslProtocols_1, bool bool_6)
    {
        this.object_0 = x509Certificate2_0;
        this.sslProtocols_0 = sslProtocols_1;
        this.heHhGnOsoo = bool_6;
    }

    public override Enum6 imethod_1()
    {
        return (Enum6) 0;
    }

    public override IStreamContract GetStreamContract()
    {
        return this.interface46_0;
    }

    public override void SetStreamContract(IStreamContract interface8_0)
    {
        IStreamContractHelper1 interface2 = interface8_0 as IStreamContractHelper1;
        if (interface2 == null)
        {
            throw new ArgumentException("The type of value is not IStreamContractHelper.");
        }
        this.interface46_0 = interface2;
    }

    public override void Initialize()
    {
        string str = null;
        if (base.bool_1)
        {
            str = AuthorizeTool.smethod_0().Authorize();
        }
        if (str != null)
        {
            throw new Exception(string.Format("Unauthorized user ,Error Code: {0} ! please contact to www.jollitycn.com", str));
        }
        base.Initialize();
    }

    internal override void ReceiveFirstMessage(Interface5 interface5_0)
    {
        try
        {
            Class6 state = (Class6) interface5_0;
            state.GetStream().BeginRead(state.method_7(), state.method_8(), state.method_9(), new AsyncCallback(this.ServeOverLap), state);
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                base.OnSomeOneDisconnected(interface5_0, DisconnectedType.NetworkInterrupted);
            }
            else
            {
                base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.WebSocketEngine.ReceiveFirstMessage", ErrorLevel.High);
            }
        }
    }

    protected override void ServeOverLap(IAsyncResult iasyncResult_0)
    {
        Class6 asyncState = (Class6) iasyncResult_0.AsyncState;
        if (!asyncState.imethod_6())
        {
            try
            {
                int num = asyncState.GetStream().EndRead(iasyncResult_0);
                if (num <= 0)
                {
                    base.OnSomeOneDisconnected(asyncState, DisconnectedType.NetworkInterrupted);
                }
                else
                {
                    if (!(((this.object_0 == null) || this.heHhGnOsoo) || asyncState.imethod_1()) && (asyncState.method_7()[0] != Class41.byte_0))
                    {
                        string str = asyncState.GetIPEndPoint().Address.ToString();
                        if (!this.class38_0.method_1(str))
                        {
                            this.class38_0.method_0(str);
                            base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
                            return;
                        }
                    }
                    asyncState.method_10(num);
                    base.method_2(asyncState, asyncState.method_7());
                    for (MessageHandler class3 = asyncState.method_11(); class3 != null; class3 = asyncState.method_11())
                    {
                        if (base.imethod_27())
                        {
                            asyncState.imethod_10().method_2();
                            asyncState.imethod_10().method_4(class3);
                        }
                        else
                        {
                            base.OnMessageReceived(asyncState, class3);
                        }
                    }
                    if (asyncState.method_6())
                    {
                        base.OnSomeOneDisconnected(asyncState, DisconnectedType.NetworkInterrupted);
                    }
                    else if (!base.bool_0 && !asyncState.imethod_6())
                    {
                        if (asyncState.method_13())
                        {
                            base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
                            base.emptyAgileLogger_0.Log("ErrorMessage", string.Format("Source Address:{0} ,MessageInvalidType:{1}", asyncState.GetIPEndPoint(), MessageInvalidType.MessageSizeOverflow), "CJFramework.Engine.Tcp.Server.WebSocketEngine.ServeOverLap", ErrorLevel.Standard);
                            base.OnInvalidMessageReceived(asyncState.GetIPEndPoint(), MessageInvalidType.MessageSizeOverflow);
                        }
                        else
                        {
                            asyncState.GetStream().BeginRead(asyncState.method_7(), asyncState.method_8(), asyncState.method_9(), new AsyncCallback(this.ServeOverLap), asyncState);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if ((exception is IOException) || (exception is ObjectDisposedException))
                {
                    base.OnSomeOneDisconnected(asyncState, DisconnectedType.NetworkInterrupted);
                }
                else
                {
                    base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.WebSocketEngine.ServeOverLap", ErrorLevel.High);
                }
            }
        }
    }

    internal override Interface5 vmethod_2(NetworkStream networkStream_0, IPEndPoint ipendPoint_0)
    {
        Stream stream = networkStream_0;
        if ((this.object_0 != null) && (this.heHhGnOsoo || this.class38_0.method_1(ipendPoint_0.Address.ToString())))
        {
            try
            {
                SslStream stream2 = new SslStream(networkStream_0, false);
                stream2.AuthenticateAsServer((X509Certificate) this.object_0, false, this.sslProtocols_0, false);
                stream = stream2;
            }
            catch (Exception)
            {
            }
        }
        return new Class6(stream, base.imethod_9(), this.interface46_0.imethod_9(), ipendPoint_0, base.cbGeneric_0, base.UncompletedSendingCount4Busy);
    }
}

