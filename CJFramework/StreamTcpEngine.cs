using CJBasic.Loggers;
using CJFramework;
using CJFramework.Core;
using CJFramework.Server;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

internal class StreamTcpEngine : BaseTcpEngine
{
    private IStreamContractHelper1 interface46_0;

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

    private MessageHandler EndReadOneMessage(IAsyncResult iasyncResult_0)
    {
        Class7 asyncState = (Class7) iasyncResult_0.AsyncState;
        int offset = asyncState.GetStream().EndRead(iasyncResult_0);
        if (offset <= 0)
        {
            base.OnSomeOneDisconnected(asyncState, DisconnectedType.NetworkInterrupted);
            return null;
        }
        int num2 = this.interface46_0.imethod_9();
        int size = num2 - offset;
        NetworkHelper.ReceiveData(asyncState.GetStream(), asyncState.method_4(), offset, size);
        base.method_2(asyncState, asyncState.method_4());
        Interface22 interface2 = this.interface46_0.imethod_10(asyncState.method_4(), 0);
        if (((interface2 == null) || (interface2.imethod_2() != this.interface46_0.imethod_8())) || ((num2 + interface2.imethod_5()) > base.imethod_9()))
        {
            MessageInvalidType invalidHeader = MessageInvalidType.InvalidHeader;
            if (interface2 != null)
            {
                invalidHeader = (interface2.imethod_2() == this.interface46_0.imethod_8()) ? MessageInvalidType.MessageSizeOverflow : MessageInvalidType.InvalidToken;
            }
            base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
            base.emptyAgileLogger_0.Log("ErrorMessage", string.Format("Source Address:{0} ,MessageInvalidType:{1}", asyncState.GetIPEndPoint(), invalidHeader), "CJFramework.Engine.Tcp.Server.StreamTcpEngine.EndReadOneMessage", ErrorLevel.Standard);
            base.OnInvalidMessageReceived(asyncState.GetIPEndPoint(), invalidHeader);
            return null;
        }
        byte[] buffer = null;
        if (interface2.imethod_5() > 0)
        {
            if (interface2.imethod_5() > base.imethod_9())
            {
                string msg = string.Format("MessageBodyLength [{0}] exceed the MaxMessageSize! Source address : {1}.", interface2.imethod_5(), asyncState.GetIPEndPoint());
                base.emptyAgileLogger_0.Log("MessageSizeOverflow", msg, "CJFramework.Tcp.Server.StreamTcpEngine.EndReadOneMessage", ErrorLevel.Standard);
                base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
                return null;
            }
            buffer = NetworkHelper.ReceiveData(asyncState.GetStream(), interface2.imethod_5());
        }
        return new MessageHandler(interface2, buffer, 0, asyncState.GetIPEndPoint());
    }

    internal override void ReceiveFirstMessage(Interface5 interface5_0)
    {
        try
        {
            Class7 class2 = (Class7) interface5_0;
            interface5_0.GetStream().BeginRead(class2.method_4(), 0, this.interface46_0.imethod_9(), new AsyncCallback(this.ServeOverLap), interface5_0);
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                base.OnSomeOneDisconnected(interface5_0, DisconnectedType.NetworkInterrupted);
            }
            else
            {
                base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.StreamTcpEngine.ReceiveFirstMessage", ErrorLevel.High);
            }
        }
    }

    protected override void ServeOverLap(IAsyncResult iasyncResult_0)
    {
        Class7 asyncState = (Class7) iasyncResult_0.AsyncState;
        if (!asyncState.imethod_6())
        {
            try
            {
                MessageHandler class3 = this.EndReadOneMessage(iasyncResult_0);
                if (class3 != null)
                {
                    if (base.imethod_27())
                    {
                        asyncState.imethod_10().method_2();
                        if (!(base.bool_0 || asyncState.imethod_6()))
                        {
                            asyncState.GetStream().BeginRead(asyncState.method_4(), 0, this.interface46_0.imethod_9(), new AsyncCallback(this.ServeOverLap), asyncState);
                        }
                        asyncState.imethod_10().method_4(class3);
                    }
                    else
                    {
                        base.OnMessageReceived(asyncState, class3);
                        if (!(base.bool_0 || asyncState.imethod_6()))
                        {
                            asyncState.GetStream().BeginRead(asyncState.method_4(), 0, this.interface46_0.imethod_9(), new AsyncCallback(this.ServeOverLap), asyncState);
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
                    base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.StreamTcpEngine.ServeOverLap", ErrorLevel.High);
                }
            }
        }
    }

    internal override Interface5 vmethod_2(NetworkStream networkStream_0, IPEndPoint ipendPoint_0)
    {
        return new Class7(networkStream_0, ipendPoint_0, this.interface46_0.imethod_9(), base.cbGeneric_0, base.UncompletedSendingCount4Busy);
    }
}

