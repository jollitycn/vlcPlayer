using CJBasic;
using CJFramework;
using CJPlus.Application;
using CJPlus.Application.Contacts;
using CJPlus.Application.Contacts.Passive;
using CJPlus.Serialization;
using System;
using System.Collections.Generic;
using System.Threading;

internal class ContactsOutter : IContactsOutter
{
    private bool bool_0 = false;
    private ContactsMessageTypeRoom contactsMessageTypeRoom_0;
    private int int_0 = 0;
    private IActionType interface31_0 = null;
    private ICommitMessageToServer interface4_0;
    private IStreamContractHelper interface9_0 = null;
    private string string_0 = "";

    public event CbGeneric<string, string, int, byte[], string> BroadcastReceived;

    public event CbGeneric<string> ContactsConnected;

    public event CbGeneric<string> ContactsOffline;



    internal void OnContactsConnected(string string_1)
    {
        if (this.ContactsConnected != null)
        {
            this.ContactsConnected(string_1);
        }
    }

    //public event CbGeneric<string, string, int, byte[], string> BroadcastReceived;

    //public event CbGeneric<string> ContactsConnected;

    //public event CbGeneric<string> ContactsOffline;
    internal void OnContactsOffline(string string_1)
    {
        if (this.ContactsOffline != null)
        {
            this.ContactsOffline(string_1);
        }
    }

    public void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, string tag, ActionTypeOnChannelIsBusy action)
    {
        BroadcastContract body = new BroadcastContract(groupID, broadcastType, broadcastContent, tag, action);
        IMessageHandler interface2 = this.interface9_0.imethod_4<BroadcastContract>(this.string_0, this.contactsMessageTypeRoom_0.BroadcastByServer, body, groupID);
        this.interface31_0.imethod_0(interface2, true, action);
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize)
    {
        if (fragmentSize <= 0)
        {
            throw new ArgumentException("Value of fragmentSize must be greater than 0.");
        }
        BlobAndTagContract contract2 = new BlobAndTagContract(blobContent, tag);
        byte[] src = CompactPropertySerializer.Default.Serialize<BlobAndTagContract>(contract2);
        int num3 = Interlocked.Increment(ref this.int_0);
        int num2 = src.Length / fragmentSize;
        if ((src.Length % fragmentSize) > 0)
        {
            num2++;
        }
        for (int i = 0; i < num2; i++)
        {
            if (!this.interface31_0.Connected.Value)
            {
                throw new Exception("The connection to server is interrupted !");
            }
            byte[] dst = null;
            if (i < (num2 - 1))
            {
                dst = new byte[fragmentSize];
            }
            else
            {
                dst = new byte[src.Length - (i * fragmentSize)];
            }
            Buffer.BlockCopy(src, i * fragmentSize, dst, 0, dst.Length);
            BlobFragmentContract body = new BlobFragmentContract(num3, broadcastType, i, dst, i == (num2 - 1));
            IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>(this.string_0, this.contactsMessageTypeRoom_0.BroadcastBlob, body, groupID);
            if (!this.interface31_0.imethod_0(interface2, false, ActionTypeOnChannelIsBusy.Continue))
            {
                throw new Exception("The connection to server is interrupted !");
            }
        }
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize, ResultHandler handler, object handlerTag)
    {
        new CbGeneric<string, int, byte[], string, int, ResultHandler, object>(this.Broadcast).BeginInvoke(groupID, broadcastType, blobContent, tag, fragmentSize, handler, handlerTag, null, null);
    }

    public List<string> GetAllOnlineContacts()
    {
        return this.method_9(null, true);
    }

    public List<string> GetContacts()
    {
        return this.method_9(null, false);
    }

    public Groupmates GetGroupMembers(string groupID)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_5<GroupContract>(this.string_0, this.contactsMessageTypeRoom_0.GetGroupMembers, new GroupContract(groupID));
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.contactsMessageTypeRoom_0.GetGroupMembers));
        return this.interface9_0.imethod_1<GroupmatesContract>(interface3);
    }

    public void SetMessageType(ContactsMessageTypeRoom contactsMessageTypeRoom_1)
    {
        this.contactsMessageTypeRoom_0 = contactsMessageTypeRoom_1;
    }

    public void SetStreamContract(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    private void Broadcast(string string_1, int int_1, byte[] byte_0, string string_2, int int_2, ResultHandler resultHandler_0, object object_0)
    {
        try
        {
            this.BroadcastBlob(string_1, int_1, byte_0, string_2, int_2);
            if (resultHandler_0 != null)
            {
                resultHandler_0(true, object_0);
            }
        }
        catch (Exception)
        {
            if (resultHandler_0 != null)
            {
                resultHandler_0(false, object_0);
            }
        }
    }

    public void method_2(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public void SetCommitMessageToServer(ICommitMessageToServer interface4_1)
    {
        this.interface4_0 = interface4_1;
    }

    public bool method_4()
    {
        return this.bool_0;
    }

    public void method_5(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }


    internal void OnBroadcastReceived(string string_1, string string_2, int int_1, byte[] byte_0, string string_3)
    {
        if (this.BroadcastReceived != null)
        {
            this.BroadcastReceived(string_1, string_2, int_1, byte_0, string_3);
        }
    }

    private List<string> method_9(string string_1, bool bool_1)
    {
        ReqContactsContract body = new ReqContactsContract(bool_1, string_1);
        IMessageHandler interface2 = this.interface9_0.imethod_5<ReqContactsContract>(this.string_0, this.contactsMessageTypeRoom_0.GetContracts, body);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.contactsMessageTypeRoom_0.GetContracts));
        return this.interface9_0.imethod_1<ResContactsContract>(interface3).UserList;
    }
}

