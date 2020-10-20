using CJFramework;
using CJPlus.Application;
using CJPlus.Application.Contacts;
using CJPlus.Serialization;
using System;

internal class Class20 : IProcess
{
    private ContactsOutter ContactsOutter_0;
    private Class76 class76_0 = new Class76();
    private IStreamContractHelper interface9_0 = null;
    private ContactsMessageTypeRoom object_0;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void SetMessageType(ContactsMessageTypeRoom contactsMessageTypeRoom_0)
    {
        this.object_0 = contactsMessageTypeRoom_0;
    }

    public void SetStreamContract(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void SetOutter(ContactsOutter ContactsOutter_1)
    {
        this.ContactsOutter_0 = ContactsOutter_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        string str;
        UserContract contract2;
        if (interface37_0.Header.MessageType == this.object_0.ContactsConnectedNotify)
        {
            contract2 = this.interface9_0.imethod_1<UserContract>(interface37_0);
            this.ContactsOutter_0.OnContactsConnected(contract2.UserID);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.ContactsOfflineNotify)
        {
            contract2 = this.interface9_0.imethod_1<UserContract>(interface37_0);
            this.ContactsOutter_0.OnContactsOffline(contract2.UserID);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastByServer)
        {
            BroadcastContract contract = this.interface9_0.imethod_1<BroadcastContract>(interface37_0);
            str = (interface37_0.Header.UserID == "_0") ? null : interface37_0.Header.UserID;
            this.ContactsOutter_0.OnBroadcastReceived(str, contract.GroupID, contract.InformationType, contract.Content, contract.Tag);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastBlob)
        {
            str = NetServer.IsServerUser(interface37_0.Header.UserID) ? null : interface37_0.Header.UserID;
            string destUserID = interface37_0.Header.DestUserID;
            BlobFragmentContract contract4 = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
            Information information = this.class76_0.method_1(interface37_0.Header.UserID, interface37_0.Header.DestUserID, contract4);
            if (information != null)
            {
                BlobAndTagContract contract3 = CompactPropertySerializer.Default.Deserialize<BlobAndTagContract>(information.Content, 0);
                this.ContactsOutter_0.OnBroadcastReceived(str, destUserID, information.InformationType, contract3.Message, contract3.Tag);
            }
            return null;
        }
        return null;
    }
}

