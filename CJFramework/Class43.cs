using CJFramework;
using CJFramework.Passive;
using CJPlus.Application;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Application.CustomizeInfo.Passive;
using CJPlus.Serialization;
using System;
using System.Threading;

internal class Class43 : ICustomizeOutter
{
    private bool bool_0 = false;
    private CustomizeMessageTypeRoom customizeMessageTypeRoom_0 = null;
    private int eycfKeykKx = 0;
    private IActionType interface31_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private string string_0 = "";

    public bool method_0()
    {
        return this.bool_0;
    }

    public void method_1(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }

    public CustomizeMessageTypeRoom method_2()
    {
        return this.customizeMessageTypeRoom_0;
    }

    public void method_3(CustomizeMessageTypeRoom customizeMessageTypeRoom_1)
    {
        this.customizeMessageTypeRoom_0 = customizeMessageTypeRoom_1;
    }

    public void method_4(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_5(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    private void method_6(Exception exception_0, IMessageHandler interface37_0, object object_0)
    {
        CallbackState<ResultHandler> state = (CallbackState<ResultHandler>) object_0;
        if (state.Handler != null)
        {
            state.Handler(exception_0 == null, state.Tag);
        }
    }

    private void method_7(string string_1, int int_0, byte[] byte_0, int int_1, ChannelMode channelMode_0, int int_2)
    {
        if ((byte_0 != null) && (byte_0.Length != 0))
        {
            if (int_1 <= 0)
            {
                throw new ArgumentException("Value of fragmentSize must be greater than 0.");
            }
            if (string_1 == null)
            {
                string_1 = "_0";
            }
            int num3 = Interlocked.Increment(ref this.eycfKeykKx);
            int num2 = byte_0.Length / int_1;
            if ((byte_0.Length % int_1) > 0)
            {
                num2++;
            }
            for (int i = 0; i < num2; i++)
            {
                if (!(this.interface31_0.Connected.Value || (channelMode_0 == ChannelMode.ByP2PChannel)))
                {
                    throw new Exception("The connection to server is interrupted !");
                }
                byte[] dst = null;
                if (i < (num2 - 1))
                {
                    dst = new byte[int_1];
                }
                else
                {
                    dst = new byte[byte_0.Length - (i * int_1)];
                }
                Buffer.BlockCopy(byte_0, i * int_1, dst, 0, dst.Length);
                BlobFragmentContract body = new BlobFragmentContract(num3, int_0, i, dst, i == (num2 - 1));
                IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>(this.string_0, int_2, body, string_1);
                bool flag = true;
                if ((string_1 == "_0") || (channelMode_0 == ChannelMode.TransferByServer))
                {
                    flag = this.interface31_0.imethod_0(interface2, false, ActionTypeOnChannelIsBusy.Continue);
                }
                else if (channelMode_0 == ChannelMode.P2PChannelFirst)
                {
                    flag = this.interface31_0.Send(interface2, false, ActionTypeOnChannelIsBusy.Continue);
                }
                else
                {
                    flag = this.interface31_0.SendByP2PChannel(interface2, ActionTypeOnNoP2PChannel.Discard, false, string_1, ActionTypeOnChannelIsBusy.Continue);
                }
                if (!flag)
                {
                    throw new Exception("The connection is interrupted !");
                }
            }
        }
    }

    private void method_8(Exception exception_0, IMessageHandler interface37_0, object object_0)
    {
        CallbackState<CallbackHandler> state = (CallbackState<CallbackHandler>) object_0;
        byte[] response = null;
        if (exception_0 == null)
        {
            BinaryInformationContract contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            if (contract == null)
            {
                exception_0 = new HandingException("There is an exception occured when server handing the query.");
            }
            else
            {
                response = contract.Content;
            }
        }
        if (state.Handler != null)
        {
            state.Handler(exception_0, response, state.Tag);
        }
    }

    internal void method_9(string string_1, int int_0, byte[] byte_0, string string_2, int int_1)
    {
        if (string_1 == null)
        {
            string_1 = "_0";
        }
        BlobAndTagContract contract = new BlobAndTagContract(byte_0, string_2);
        byte[] buffer = CompactPropertySerializer.Default.Serialize<BlobAndTagContract>(contract);
        this.method_7(string_1, int_0, buffer, int_1, ChannelMode.P2PChannelFirst, this.customizeMessageTypeRoom_0.BlobByRapidEngine);
    }

    public byte[] Query(int informationType, byte[] info)
    {
        return this.Query(null, informationType, info);
    }

    public byte[] Query(string targetUserID, int informationType, byte[] info)
    {
        if (targetUserID == null)
        {
            targetUserID = "_0";
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, this.customizeMessageTypeRoom_0.Request, new BinaryInformationContract(informationType, info), targetUserID);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.customizeMessageTypeRoom_0.Response));
        BinaryInformationContract contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface3);
        if (contract == null)
        {
            throw new HandingException(string.Format("There is an exception occured when {0} handing the query of {1}.", targetUserID, informationType));
        }
        return contract.Content;
    }

    public void Query(string targetUserID, int informationType, byte[] info, CallbackHandler handler, object tag)
    {
        if (targetUserID == null)
        {
            targetUserID = "_0";
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, this.customizeMessageTypeRoom_0.Request, new BinaryInformationContract(informationType, info), targetUserID);
        this.interface31_0.imethod_2(interface2, this.customizeMessageTypeRoom_0.Response, new Delegate0(this.method_8), new CallbackState<CallbackHandler>(handler, tag));
    }

    public void Send(int informationType, byte[] info)
    {
        this.Send(null, informationType, info);
    }

    public void Send(string targetUserID, int informationType, byte[] info)
    {
        this.Send(targetUserID, informationType, info, false, ActionTypeOnChannelIsBusy.Continue);
    }

    public bool Send(string targetUserID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action)
    {
        return this.Send(targetUserID, informationType, info, post, action, ChannelMode.P2PChannelFirst);
    }

    public bool Send(string targetUserID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action, ChannelMode mode)
    {
        if (targetUserID == null)
        {
            targetUserID = "_0";
        }
        int num = post ? this.customizeMessageTypeRoom_0.InformationByPost : this.customizeMessageTypeRoom_0.InformationBySend;
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, num, new BinaryInformationContract(informationType, info), targetUserID);
        if ((targetUserID == "_0") || (mode == ChannelMode.TransferByServer))
        {
            return this.interface31_0.imethod_0(interface2, post, action);
        }
        if (mode == ChannelMode.P2PChannelFirst)
        {
            return this.interface31_0.Send(interface2, post, action);
        }
        return this.interface31_0.SendByP2PChannel(interface2, ActionTypeOnNoP2PChannel.Discard, post, targetUserID, action);
    }

    public void SendBlob(string targetUserID, int informationType, byte[] blobInfo, int fragmentSize)
    {
        this.SendBlob(targetUserID, informationType, blobInfo, fragmentSize, ChannelMode.P2PChannelFirst);
    }

    public void SendBlob(string targetUserID, int informationType, byte[] blobInfo, int fragmentSize, ChannelMode mode)
    {
        this.method_7(targetUserID, informationType, blobInfo, fragmentSize, mode, this.customizeMessageTypeRoom_0.BlobInformation);
    }

    public bool SendByP2PChannel(string targetUserID, int informationType, byte[] info, ActionTypeOnNoP2PChannel actionType, bool post, ActionTypeOnChannelIsBusy action)
    {
        int num = post ? this.customizeMessageTypeRoom_0.InformationByPost : this.customizeMessageTypeRoom_0.InformationBySend;
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, num, new BinaryInformationContract(informationType, info), targetUserID);
        return this.interface31_0.SendByP2PChannel(interface2, actionType, post, targetUserID, action);
    }

    public void SendCertainly(string targetUserID, int informationType, byte[] info)
    {
        if (targetUserID == null)
        {
            targetUserID = "_0";
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, this.customizeMessageTypeRoom_0.InformationNeedAck, new BinaryInformationContract(informationType, info), targetUserID);
        this.interface31_0.imethod_1(interface2, new int?(this.customizeMessageTypeRoom_0.Ack));
    }

    public void SendCertainly(string targetUserID, int informationType, byte[] info, ResultHandler ackHandler, object tag)
    {
        if (targetUserID == null)
        {
            targetUserID = "_0";
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, this.customizeMessageTypeRoom_0.InformationNeedAck, new BinaryInformationContract(informationType, info), targetUserID);
        this.interface31_0.imethod_2(interface2, this.customizeMessageTypeRoom_0.Ack, new Delegate0(this.method_6), new CallbackState<ResultHandler>(ackHandler, tag));
    }

    public void TransferByServer(string targetUserID, int informationType, byte[] info)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>(this.string_0, this.customizeMessageTypeRoom_0.InformationBySend, new BinaryInformationContract(informationType, info), targetUserID);
        this.interface31_0.imethod_3(interface2, null);
    }
}

