using CJBasic.Loggers;
using CJFramework.Core;
using CJFramework.Server;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

internal class TextTcpEngine : BaseTcpEngine
{
    private ITextContractHelper object_0;

    public override Enum6 imethod_1()
    {
        return (Enum6) 1;
    }

    public override IStreamContract GetStreamContract()
    {
        return (IStreamContract) this.object_0;
    }

    public override void SetStreamContract(IStreamContract interface8_0)
    {
        ITextContractHelper interface2 = interface8_0 as ITextContractHelper;
        if (interface2 == null)
        {
            throw new ArgumentException("The type of value is not ITextContractHelper.");
        }
        this.object_0 = interface2;
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
            Class5 state = (Class5) interface5_0;
            state.GetStream().BeginRead(state.method_4(), state.method_5(), state.method_6(), new AsyncCallback(this.ServeOverLap), state);
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                base.OnSomeOneDisconnected(interface5_0, DisconnectedType.NetworkInterrupted);
            }
            else
            {
                base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.TextTcpEngine.ReceiveFirstMessage", ErrorLevel.High);
            }
        }
    }

    protected override void ServeOverLap(IAsyncResult iasyncResult_0)
    {
        Class5 asyncState = (Class5) iasyncResult_0.AsyncState;
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
                    asyncState.method_7(num);
                    for (string str = asyncState.kjfPdghQbi(); str != null; str = asyncState.kjfPdghQbi())
                    {
                        IHeader4 interface2 = this.object_0.imethod_11(str);
                        if (interface2 == null)
                        {
                            goto Label_011D;
                        }
                        Message1 class3 = new Message1(interface2, str, asyncState.GetIPEndPoint());
                        base.OnMessageReceived(asyncState, class3);
                    }
                    if (!base.bool_0 && !asyncState.imethod_6())
                    {
                        if (asyncState.method_9())
                        {
                            base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
                            base.emptyAgileLogger_0.Log("ErrorMessage", string.Format("Source Address:{0} ,MessageInvalidType:{1}", asyncState.GetIPEndPoint(), MessageInvalidType.MessageSizeOverflow), "CJFramework.Engine.Tcp.Server.TextTcpEngine.ServeOverLap", ErrorLevel.Standard);
                            base.OnInvalidMessageReceived(asyncState.GetIPEndPoint(), MessageInvalidType.MessageSizeOverflow);
                        }
                        else
                        {
                            asyncState.GetStream().BeginRead(asyncState.method_4(), asyncState.method_5(), asyncState.method_6(), new AsyncCallback(this.ServeOverLap), asyncState);
                        }
                    }
                }
                return;
            Label_011D:
                base.OnSomeOneDisconnected(asyncState, DisconnectedType.InvalidMessage);
                base.emptyAgileLogger_0.Log("ErrorMessage", string.Format("Source Address:{0} ,MessageInvalidType:{1}", asyncState.GetIPEndPoint(), MessageInvalidType.InvalidHeader), "CJFramework.Engine.Tcp.Server.TextTcpEngine.ServeOverLap", ErrorLevel.Standard);
                base.OnInvalidMessageReceived(asyncState.GetIPEndPoint(), MessageInvalidType.InvalidHeader);
            }
            catch (Exception exception)
            {
                if ((exception is IOException) || (exception is ObjectDisposedException))
                {
                    base.OnSomeOneDisconnected(asyncState, DisconnectedType.NetworkInterrupted);
                }
                else
                {
                    base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Server.TextTcpEngine.ServeOverLap", ErrorLevel.High);
                }
            }
        }
    }

    internal override Interface5 vmethod_2(NetworkStream networkStream_0, IPEndPoint ipendPoint_0)
    {
        return new Class5(new Class8(networkStream_0, base.imethod_9(), this.object_0.imethod_10(), (Interface10) this.object_0), ipendPoint_0, base.cbGeneric_0, base.UncompletedSendingCount4Busy);
    }
     
}

