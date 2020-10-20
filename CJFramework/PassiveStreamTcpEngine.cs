using CJBasic.Loggers;
using CJFramework;
using CJFramework.Core;
using System;
using System.IO;
using System.Net.Sockets;

internal class PassiveStreamTcpEngine : TcpEngine
{
    private IStreamContractHelper1 interface46_0;
    private byte[] LvFuuIfhcm;

    public override Enum6 imethod_1()
    {
        return (Enum6) 0;
    }

    private void ReceiveCallback(IAsyncResult iasyncResult_0)
    {
        NetworkStream asyncState = (NetworkStream) iasyncResult_0.AsyncState;
        try
        {
            int offset = asyncState.EndRead(iasyncResult_0);
            if (offset == 0)
            {
                base.method_0(asyncState, true);
            }
            else
            {
                int num2 = this.interface46_0.imethod_9();
                NetworkHelper.ReceiveData(asyncState, this.LvFuuIfhcm, offset, num2 - offset);
                Interface22 interface2 = this.interface46_0.imethod_10(this.LvFuuIfhcm, 0);
                if (((interface2 == null) || (interface2.imethod_2() != this.interface46_0.imethod_8())) || ((num2 + interface2.imethod_5()) > base.imethod_9()))
                {
                    MessageInvalidType invalidHeader = MessageInvalidType.InvalidHeader;
                    if (interface2 != null)
                    {
                        invalidHeader = (interface2.imethod_2() == this.interface46_0.imethod_8()) ? MessageInvalidType.MessageSizeOverflow : MessageInvalidType.InvalidToken;
                    }
                    base.OnInvalidMessageReceived(base.ipendPoint_0, invalidHeader);
                    asyncState.Close();
                    base.method_0(asyncState, false);
                }
                else
                {
                    byte[] buffer = null;
                    if (interface2.imethod_5() > 0)
                    {
                        buffer = NetworkHelper.ReceiveData(asyncState, interface2.imethod_5());
                    }
                    MessageHandler class2 = new MessageHandler(interface2, buffer, 0, base.ipendPoint_0);
                    base.AsynHandleMessage(class2);
                    asyncState.BeginRead(this.LvFuuIfhcm, 0, this.LvFuuIfhcm.Length, new AsyncCallback(this.ReceiveCallback), asyncState);
                }
            }
        }
        catch (Exception exception)
        {
            if ((exception is IOException) || (exception is ObjectDisposedException))
            {
                base.method_0(asyncState, true);
            }
            else if (!base.imethod_16())
            {
                base.emptyAgileLogger_0.Log(exception, "CJFramework.Engine.Tcp.Passive.PassiveStreamTcpEngine.ReceiveCallback", ErrorLevel.High);
            }
        }
    }

    protected override void vmethod_0()
    {
        this.interface46_0 = (IStreamContractHelper1) base.GetStreamContract();
        this.LvFuuIfhcm = new byte[this.interface46_0.imethod_9()];
        base.object_0.BeginRead(this.LvFuuIfhcm, 0, this.LvFuuIfhcm.Length, new AsyncCallback(this.ReceiveCallback), base.object_0);
    }
}

