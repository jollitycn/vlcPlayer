using CJBasic;
using CJFramework;
using CJPlus.Application;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Serialization;
using System;
using System.Threading;

internal class CustomizeProcess : IProcess
{
    private Class76 class76_0 = new Class76();
    private ICustomizeHandler icustomizeHandler_0;
    private IActionType interface31_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private CustomizeMessageTypeRoom object_0 = null;

    internal event CbGeneric<string, int, byte[], string> Event_0;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void SetStreamContractHelper(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public CustomizeMessageTypeRoom GetCustomizeMessageTypeRoom()
    {
        return (CustomizeMessageTypeRoom) this.object_0;
    }

    public void SetCustomizeMessageTypeRoom(CustomizeMessageTypeRoom customizeMessageTypeRoom_0)
    {
        this.object_0 = customizeMessageTypeRoom_0;
    }

    public void SetCustomizeHandler(ICustomizeHandler icustomizeHandler_1)
    {
        this.icustomizeHandler_0 = icustomizeHandler_1;
    }

    public void SetActionType(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        string str;
        IHeader interface3;
        IMessageHandler interface4;
        BinaryInformationContract contract3;
        if ((interface37_0.Header.MessageType == this.object_0.InformationBySend) || (interface37_0.Header.MessageType == this.object_0.InformationByPost))
        {
            contract3 = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
            this.icustomizeHandler_0.HandleInformation(str, contract3.InformationType, contract3.Content);
            return null;
        }
        if ((interface37_0.Header.MessageType == this.object_0.BlobInformation) || (interface37_0.Header.MessageType == this.object_0.BlobByRapidEngine))
        {
            BlobFragmentContract contract2 = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
            Information information = this.class76_0.method_1(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract2);
            if (information != null)
            {
                str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
                if (interface37_0.Header.MessageType == this.object_0.BlobInformation)
                {
                    this.icustomizeHandler_0.HandleInformation(str, information.InformationType, information.Content);
                }
                else if (this.Event_0 != null)
                {
                    BlobAndTagContract contract = CompactPropertySerializer.Default.Deserialize<BlobAndTagContract>(information.Content, 0);
                    this.Event_0(str, information.InformationType, contract.Message, contract.Tag);
                }
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.InformationNeedAck)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            interface3.MessageType = this.object_0.Ack;
            interface4 = this.interface9_0.imethod_2<Class110>(interface3, null);
            this.interface31_0.Send(interface4, false, ActionTypeOnChannelIsBusy.Continue);
            contract3 = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
            this.icustomizeHandler_0.HandleInformation(str, contract3.InformationType, contract3.Content);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Request)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            interface3.MessageType = this.object_0.Response;
            contract3 = this.interface9_0.imethod_1<BinaryInformationContract>(interface37_0);
            BinaryInformationContract body = null;
            try
            {
                str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
                body = new BinaryInformationContract(this.icustomizeHandler_0.HandleQuery(str, contract3.InformationType, contract3.Content));
            }
            finally
            {
                interface4 = this.interface9_0.imethod_2<BinaryInformationContract>(interface3, body);
                this.interface31_0.Send(interface4, true, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.GetClientTimeRequest)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            interface3.MessageType = this.object_0.GetClientTimeResponse;
            ResGetTimeContract contract4 = new ResGetTimeContract(DateTime.Now);
            return this.interface9_0.imethod_2<ResGetTimeContract>(interface3, contract4);
        }
        return null;
    }
}

