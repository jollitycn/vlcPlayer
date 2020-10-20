using CJBasic.Loggers;
using CJFramework.Core;
using System;
using System.IO;
using System.Net.Sockets;

internal class PassiveTextTcpEngine : TcpEngine
{
    private Class5 class5_0;
    private ITextContractHelper object_5;

    public override Enum6 imethod_1()
    {
        return (Enum6) 1;
    }

    private void ReceiveCallback(IAsyncResult iasyncResult_0)
    {
        NetworkStream asyncState = (NetworkStream) iasyncResult_0.AsyncState;
        try
        {
            int num = asyncState.EndRead(iasyncResult_0);
            if (num == 0)
            {
                base.method_0(asyncState, true);
            }
            else
            {
                this.class5_0.method_7(num);
                for (string str = this.class5_0.kjfPdghQbi(); str != null; str = this.class5_0.kjfPdghQbi())
                {
                    IHeader4 interface2 = null;
                    MessageInvalidType valid = MessageInvalidType.Valid;
                    if (!this.object_5.imethod_12(str))
                    {
                        valid = MessageInvalidType.InvalidToken;
                    }
                    else
                    {
                        interface2 = this.object_5.imethod_11(str);
                        if (interface2 == null)
                        {
                            valid = MessageInvalidType.InvalidHeader;
                        }
                    }
                    if (valid != MessageInvalidType.Valid)
                    {
                        goto Label_00DF;
                    }
                    IMessageHandler interface3 = new Message1(interface2, str, base.ipendPoint_0);
                    base.AsynHandleMessage(interface3);
                }
                asyncState.BeginRead(this.class5_0.method_4(), this.class5_0.method_5(), this.class5_0.method_6(), new AsyncCallback(this.ReceiveCallback), asyncState);
            }
            return;
        Label_00DF:
            base.OnInvalidMessageReceived(base.ipendPoint_0, MessageInvalidType.InvalidHeader);
            asyncState.Close();
            base.method_0(asyncState, false);
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                base.method_0(asyncState, true);
            }
            else if (!base.imethod_16())
            {
                base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Passive.PassiveTextTcpEngine.ReceiveCallback", ErrorLevel.High);
            }
        }
    }

    protected override void vmethod_0()
    {
        this.object_5 = (ITextContractHelper) base.GetStreamContract();
        Class8 class2 = new Class8((NetworkStream) base.object_0, base.imethod_9(), this.object_5.imethod_10(), (Interface10) this.object_5);
        this.class5_0 = new Class5(class2, base.ipendPoint_0, null, base.UncompletedSendingCount4Busy);
        base.object_0.BeginRead(this.class5_0.method_4(), this.class5_0.method_5(), this.class5_0.method_6(), new AsyncCallback(this.ReceiveCallback), base.object_0);
    }
}

