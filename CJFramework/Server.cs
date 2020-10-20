using CJBasic;
using CJBasic.Loggers;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus.Advanced;
using CJPlus.Application;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Application.CustomizeInfo.Server;
using CJPlus.Serialization;
using System;
using System.Threading;

internal class Server : GInterface, IProcess, IDateTime
{
    private WorkProcesser class109_0;
    private Class72 class72_0;
    private Class76 class76_0 = new Class76();
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private GInterface8 ginterface8_0;
    private ICustomizeHandler icustomizeHandler_0;
    private int int_0 = 60;
    private int int_1 = 10;
    private int int_2 = 0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private IUserManager iuserManager_0 = null;
    private CustomizeMessageTypeRoom object_0 = null;

    internal event CbGeneric<string, int, byte[], string> Event_0;

    public event CbGeneric<Information> InformationReceived;

    public event CbGeneric<Information> TransmitFailed;

    public bool CanProcess(int int_3)
    {
        return this.object_0.Contains(int_3);
    }

    public DateTime? GetTime(string string_0)
    {
        if (!this.iuserManager_0.IsUserOnLine(string_0))
        {
            return null;
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>("_0", this.object_0.GetClientTimeRequest, null, string_0);
        this.interface40_0.SendMessage(interface2, string_0, ActionTypeOnChannelIsBusy.Continue);
        IMessageHandler interface3 = this.class72_0.PickupResponse(this.object_0.GetClientTimeResponse, interface2.Header.MessageID);
        return new DateTime?(this.interface9_0.imethod_1<ResGetTimeContract>(interface3).Time);
    }

    public void SetStreamContract(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_1(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public int method_10()
    {
        return this.int_1;
    }

    public void method_11(int int_3)
    {
        this.int_1 = int_3;
    }

    public void SetAgileLogger(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        }
    }

    internal WorkProcesser method_13()
    {
        return this.class109_0;
    }

    public void method_14(CustomizeInfoHandleMode customizeInfoHandleMode_0, int int_3)
    {
        this.class72_0 = new Class72(this.int_1, this.int_0);
        this.iuserManager_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.SomeOneDisconnected);
        if (customizeInfoHandleMode_0 == CustomizeInfoHandleMode.TaskQueue)
        {
            this.class109_0 = new WorkProcesser(int_3, new CbGeneric<IMessageHandler>(this.DoProcessMessageToServerInQueue));
        }
    }

    private void SomeOneDisconnected(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        this.class76_0.OnUserOffline(userData_0.UserID);
    }

    private void DoProcessMessageToServerInQueue(IMessageHandler interface37_0)
    {
        try
        {
            this.HandleMessage(interface37_0);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJPlus.Application.CustomizeInfo.Server.DoProcessMessageToServerInQueue", ErrorLevel.Standard);
        }
    }

    private void HandleMessage(IMessageHandler interface37_0)
    {
        BinaryInformationContract contract;
        if ((interface37_0.Header.MessageType == this.object_0.InformationBySend) || (interface37_0.Header.MessageType == this.object_0.InformationByPost))
        {
            contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            this.icustomizeHandler_0.HandleInformation(interface37_0.Header.UserID, contract.InformationType, contract.Content);
        }
        else if ((interface37_0.Header.MessageType == this.object_0.BlobInformation) || (interface37_0.Header.MessageType == this.object_0.BlobByRapidEngine))
        {
            BlobFragmentContract contract3 = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
            Information information = this.class76_0.method_1(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract3);
            if (information != null)
            {
                if (interface37_0.Header.MessageType == this.object_0.BlobInformation)
                {
                    this.icustomizeHandler_0.HandleInformation(interface37_0.Header.UserID, information.InformationType, information.Content);
                }
                else if (this.Event_0 != null)
                {
                    BlobAndTagContract contract4 = CompactPropertySerializer.Default.Deserialize<BlobAndTagContract>(information.Content, 0);
                    this.Event_0(interface37_0.Header.UserID, information.InformationType, contract4.Message, contract4.Tag);
                }
            }
        }
        else
        {
            IHeader interface2;
            IMessageHandler interface3;
            if (interface37_0.Header.MessageType == this.object_0.InformationNeedAck)
            {
                interface2 = this.interface9_0.imethod_7(interface37_0.Header);
                interface2.MessageType = this.object_0.Ack;
                interface3 = this.interface9_0.imethod_2<Class110>(interface2, null);
                this.interface40_0.imethod_0(interface3, ActionTypeOnChannelIsBusy.Continue);
                contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
                this.icustomizeHandler_0.HandleInformation(interface37_0.Header.UserID, contract.InformationType, contract.Content);
            }
            else if (interface37_0.Header.MessageType == this.object_0.Request)
            {
                interface2 = this.interface9_0.imethod_7(interface37_0.Header);
                interface2.MessageType = this.object_0.Response;
                contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
                BinaryInformationContract body = null;
                try
                {
                    body = new BinaryInformationContract(this.icustomizeHandler_0.HandleQuery(interface37_0.Header.UserID, contract.InformationType, contract.Content));
                }
                finally
                {
                    interface3 = this.interface9_0.imethod_2<BinaryInformationContract>(interface2, body);
                    this.interface40_0.PostMessage(interface3, interface37_0.Header.UserID, ActionTypeOnChannelIsBusy.Continue);
                }
            }
        }
    }

    private void method_18(IMessageHandler interface37_0)
    {
        if (this.class109_0 != null)
        {
            this.class109_0.HandleMessage(interface37_0);
        }
        else
        {
            this.HandleMessage(interface37_0);
        }
    } 
    private void HandleMessage(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (this.ginterface8_0.IsUserOnLine(interface37_0.Header.DestUserID))
        {
            if (bool_0)
            {
                this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, actionTypeOnChannelIsBusy_0);
            }
            else
            {
                this.interface40_0.SendMessage(interface37_0, interface37_0.Header.DestUserID, actionTypeOnChannelIsBusy_0);
            }
        }
        else if ((interface37_0.Header.MessageType != this.object_0.BlobByRapidEngine) && (interface37_0.Header.MessageType != this.object_0.BlobInformation))
        {
            BinaryInformationContract contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            Information information = new Information(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract.InformationType, contract.Content);
            if (this.TransmitFailed != null)
            {
                this.TransmitFailed(information);
            }
        }
    }

    public CustomizeMessageTypeRoom GetCustomizeMessageTypeRoom()
    {
        return (CustomizeMessageTypeRoom) this.object_0;
    }

    // string targetUserID, int informationType, byte[] message, string tag, int fragmentSize
    internal void Send(string string_0, int int_3, byte[] byte_0, string string_1, int int_4)
    {
        BlobAndTagContract contract = new BlobAndTagContract(byte_0, string_1);
        byte[] buffer = CompactPropertySerializer.Default.Serialize<BlobAndTagContract>(contract);
        this.method_23(string_0, int_3, buffer, int_4, this.object_0.BlobByRapidEngine);
    }
   
    private void method_21(Exception exception_0, IMessageHandler interface37_0, object object_1)
    {
        CallbackState<ResultHandler> state = (CallbackState<ResultHandler>) object_1;
        if (state.Handler != null)
        {
            state.Handler(exception_0 == null, state.Tag);
        }
    }

    private void query(Exception exception_0, IMessageHandler interface37_0, object object_1)
    {
        CallbackState<CallbackHandler> state = (CallbackState<CallbackHandler>) object_1;
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

    public void method_23(string string_0, int int_3, byte[] byte_0, int fragmentSize, int int_5)
    {
        if ((((byte_0 != null) && (byte_0.Length != 0)) && (string_0 != null)) && this.iuserManager_0.IsUserOnLine(string_0))
        {
            if (fragmentSize == 0)
            {
                throw new ArgumentException("Value of fragmentSize must be greater than 0.");
            }
            int num2 = Interlocked.Increment(ref this.int_2);
            int num3 = byte_0.Length / fragmentSize;
            if ((byte_0.Length % fragmentSize) > 0)
            {
                num3++;
            }
            for (int i = 0; i < num3; i++)
            {
                byte[] dst = null;
                if (i < (num3 - 1))
                {
                    dst = new byte[fragmentSize];
                }
                else
                {
                    dst = new byte[byte_0.Length - (i * fragmentSize)];
                }
                Buffer.BlockCopy(byte_0, i * fragmentSize, dst, 0, dst.Length);
                BlobFragmentContract body = new BlobFragmentContract(num2, int_3, i, dst, i == (num3 - 1));
                IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>("_0", int_5, body, string_0);
                this.interface40_0.SendMessage(interface2, string_0, ActionTypeOnChannelIsBusy.Continue);
            }
        }
    }

    public void SetCustomizeMessageTypeRoom(CustomizeMessageTypeRoom customizeMessageTypeRoom_0)
    {
        this.object_0 = customizeMessageTypeRoom_0;
    }

    public void SetICustomizeHandler(ICustomizeHandler icustomizeHandler_1)
    {
        this.icustomizeHandler_0 = icustomizeHandler_1;
    }

    public IUserManager GetUserManager()
    {
        return this.iuserManager_0;
    }

    public void SetUserManager(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public int method_7()
    {
        return this.int_0;
    }

    public void method_8(int int_3)
    {
        this.int_0 = int_3;
    }

    public void method_9(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        //InformationReceived
        if ((this.InformationReceived != null) && (((interface37_0.Header.MessageType != this.object_0.Ack) && (interface37_0.Header.MessageType != this.object_0.BlobInformation)) && (interface37_0.Header.MessageType != this.object_0.BlobByRapidEngine)))
        {
            BinaryInformationContract contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            Information information = new Information(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract.InformationType, contract.Content);
            this.InformationReceived(information);
        }
        if ((interface37_0.Header.MessageType == this.object_0.InformationBySend) || (interface37_0.Header.MessageType == this.object_0.InformationByPost))
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.method_18(interface37_0);
            }
            else
            {
                bool flag = interface37_0.Header.MessageType == this.object_0.InformationByPost;
                this.HandleMessage(interface37_0, flag, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if ((interface37_0.Header.MessageType == this.object_0.BlobInformation) || (interface37_0.Header.MessageType == this.object_0.BlobByRapidEngine))
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.method_18(interface37_0);
            }
            else
            {
                this.HandleMessage(interface37_0, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.InformationNeedAck)
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.method_18(interface37_0);
            }
            else
            {
                this.HandleMessage(interface37_0, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Response)
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.class72_0.PushResponse(interface37_0);
            }
            else
            {
                this.HandleMessage(interface37_0, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Ack)
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.class72_0.PushResponse(interface37_0);
            }
            else
            {
                this.HandleMessage(interface37_0, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Request)
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.method_18(interface37_0);
            }
            else
            {
                this.HandleMessage(interface37_0, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.GetClientTimeResponse)
        {
            this.class72_0.PushResponse(interface37_0);
            return null;
        }
        return null;
    }

    public byte[] QueryLocalClient(string userID, int informationType, byte[] info)
    {
        if (!this.iuserManager_0.IsUserOnLine(userID))
        {
            throw new Exception(string.Format("Target User {0} is not on current server !", userID));
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", this.object_0.Request, new BinaryInformationContract(informationType, info), userID);
        this.interface40_0.SendMessage(interface2, userID, ActionTypeOnChannelIsBusy.Continue);
        IMessageHandler interface3 = this.class72_0.PickupResponse(this.object_0.Response, interface2.Header.MessageID);
        BinaryInformationContract contract = this.interface9_0.imethod_1<BinaryInformationContract>(interface3);
        if (contract == null)
        {
            throw new HandingException(string.Format("There is an exception occured when {0} handing the query of {1}.", userID, informationType));
        }
        return contract.Content;
    }

    public void QueryLocalClient(string userID, int informationType, byte[] info, CallbackHandler handler, object tag)
    {
        if (!this.iuserManager_0.IsUserOnLine(userID))
        {
            throw new Exception(string.Format("Target User {0} is not on current server !", userID));
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", this.object_0.Request, new BinaryInformationContract(informationType, info), userID);
        this.class72_0.RegisterCallback(this.object_0.Response, interface2.Header.MessageID, new Delegate0(this.query), new CallbackState<CallbackHandler>(handler, tag));
        this.interface40_0.SendMessage(interface2, userID, ActionTypeOnChannelIsBusy.Continue);
    }

    public void Send(string userID, int informationType, byte[] info)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", this.object_0.InformationBySend, new BinaryInformationContract(informationType, info), userID);
        this.interface40_0.SendMessage(interface2, userID, ActionTypeOnChannelIsBusy.Continue);
    }

    public bool Send(string userID, int informationType, byte[] info, bool post, ActionTypeOnChannelIsBusy action)
    {
        int num = post ? this.object_0.InformationByPost : this.object_0.InformationBySend;
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", num, new BinaryInformationContract(informationType, info), userID);
        if (post)
        {
            return this.interface40_0.PostMessage(interface2, userID, action);
        }
        return this.interface40_0.SendMessage(interface2, userID, action);
    }

    public void SendBlob(string userID, int informationType, byte[] blobInfo, int fragmentSize)
    {
        this.method_23(userID, informationType, blobInfo, fragmentSize, this.object_0.BlobInformation);
    }

    public void SendCertainlyToLocalClient(string userID, int informationType, byte[] info)
    {
        if (!this.iuserManager_0.IsUserOnLine(userID))
        {
            throw new Exception(string.Format("Target User {0} is not on current server !", userID));
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", this.object_0.InformationNeedAck, new BinaryInformationContract(informationType, info), userID);
        this.interface40_0.SendMessage(interface2, userID, ActionTypeOnChannelIsBusy.Continue);
        this.class72_0.PickupResponse(this.object_0.Ack, interface2.Header.MessageID);
    }

    public void SendCertainlyToLocalClient(string userID, int informationType, byte[] info, ResultHandler handler, object tag)
    {
        if (!this.iuserManager_0.IsUserOnLine(userID))
        {
            throw new Exception(string.Format("Target User {0} is not on current server !", userID));
        }
        IMessageHandler interface2 = this.interface9_0.imethod_4<BinaryInformationContract>("_0", this.object_0.InformationNeedAck, new BinaryInformationContract(informationType, info), userID);
        this.class72_0.RegisterCallback(this.object_0.Ack, interface2.Header.MessageID, new Delegate0(this.method_21), new CallbackState<ResultHandler>(handler, tag));
        this.interface40_0.SendMessage(interface2, userID, ActionTypeOnChannelIsBusy.Continue);
    }
}

