using CJFramework;
using CJPlus.Application;
using CJPlus.Application.Group;
using System;

internal class Class140 : IProcess
{
    private GroupOutter2 class19_0;
    private Class76 class76_0 = new Class76();
    private IStreamContractHelper interface9_0 = null;
    private GroupMessageTypeRoom object_0;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void method_0(GroupMessageTypeRoom groupMessageTypeRoom_0)
    {
        this.object_0 = groupMessageTypeRoom_0;
    }

    public void method_1(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_2(GroupOutter2 class19_1)
    {
        this.class19_0 = class19_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        string str;
        UserContract contract3;
        if (interface37_0.Header.MessageType == this.object_0.GroupmateConnectedNotify)
        {
            contract3 = this.interface9_0.imethod_1<UserContract>(interface37_0);
            this.class19_0.GroupmateConnectedNotify(contract3.UserID);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.GroupmateOfflineNotify)
        {
            contract3 = this.interface9_0.imethod_1<UserContract>(interface37_0);
            this.class19_0.GroupmateOfflineNotify(contract3.UserID);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastByServer)
        {
            BroadcastContract contract2 = this.interface9_0.imethod_1<BroadcastContract>(interface37_0);
            str = (interface37_0.Header.UserID == "_0") ? null : interface37_0.Header.UserID;
            this.class19_0.method_6(str, contract2.GroupID, contract2.InformationType, contract2.Content);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastBlob)
        {
            str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
            string destUserID = interface37_0.Header.DestUserID;
            BlobFragmentContract contract = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
            Information information = this.class76_0.method_1(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract);
            if (information != null)
            {
                this.class19_0.method_6(str, destUserID, information.InformationType, information.Content);
            }
            return null;
        }
        return null;
    }
}

