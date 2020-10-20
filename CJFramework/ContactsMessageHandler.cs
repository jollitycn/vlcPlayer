using CJBasic;
using CJBasic.ObjectManagement;
using CJBasic.Threading.Engines;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus.Application;
using CJPlus.Application.Contacts;
using CJPlus.Application.Contacts.Server;
using CJPlus.Serialization;
using System;
using System.Collections.Generic;
using System.Threading;

internal class ContactsMessageHandler : IEngineActor, IProcess, IContactsOutter
{
    private AgileCycleEngine agileCycleEngine_0;
    private bool bool_0 = false;
    private bool bool_1 = true;
    private bool bool_2 = true;
    private bool bool_3 = false;
    private bool bool_4 = false;
    private CircleQueue<string> circleQueue_0 = new CircleQueue<string>(0x2710);
    private CircleQueue<string> circleQueue_1 = new CircleQueue<string>(0x2710);
    private Class76 class76_0 = new Class76();
    private GInterface8 ginterface8_0;
    private IContactsManager icontactsManager_0;
    private int int_0 = 0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private IUserManager iuserManager_0 = null;
    private ContactsMessageTypeRoom object_0;

    public event CbGeneric<string, BroadcastInformation> BroadcastFailed;

    public event CbGeneric<string, string, int, byte[], string> BroadcastReceived;

    public ContactsMessageHandler()
    {
        this.agileCycleEngine_0 = new AgileCycleEngine(this);
        this.agileCycleEngine_0.DetectSpanInSecs = 0;
    }

    public void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, string tag, ActionTypeOnChannelIsBusy action)
    {
        List<string> groupMemberList = this.icontactsManager_0.GetGroupMemberList(groupID);
        if ((groupMemberList != null) && (groupMemberList.Count > 0))
        {
            BroadcastContract body = new BroadcastContract(groupID, broadcastType, broadcastContent, tag, action);
            IMessageHandler interface2 = this.interface9_0.imethod_5<BroadcastContract>("_0", this.object_0.BroadcastByServer, body);
            this.interface40_0.PostMessage(interface2, groupMemberList, action);
        }
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize)
    {
        if (fragmentSize <= 0)
        {
            throw new ArgumentException("Value of fragmentSize must be greater than 0.");
        }
        List<string> groupMemberList = this.icontactsManager_0.GetGroupMemberList(groupID);
        if ((groupMemberList != null) && (groupMemberList.Count != 0))
        {
            BlobAndTagContract contract = new BlobAndTagContract(blobContent, tag);
            byte[] src = CompactPropertySerializer.Default.Serialize<BlobAndTagContract>(contract);
            int num2 = Interlocked.Increment(ref this.int_0);
            int num3 = src.Length / fragmentSize;
            if ((src.Length % fragmentSize) > 0)
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
                    dst = new byte[src.Length - (i * fragmentSize)];
                }
                Buffer.BlockCopy(src, i * fragmentSize, dst, 0, dst.Length);
                BlobFragmentContract body = new BlobFragmentContract(num2, broadcastType, i, dst, i == (num3 - 1));
                IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>("_0", this.object_0.BroadcastBlob, body, groupID);
                this.interface40_0.PostMessage(interface2, groupMemberList, ActionTypeOnChannelIsBusy.Continue);
            }
        }
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, string tag, int fragmentSize, ResultHandler handler, object handlerTag)
    {
        new CbGeneric<string, int, byte[], string, int, ResultHandler, object>(this.method_11).BeginInvoke(groupID, broadcastType, blobContent, tag, fragmentSize, handler, handlerTag, null, null);
    }

    public bool CanProcess(int int_1)
    {
        return this.object_0.Contains(int_1);
    }

    public bool EngineAction()
    {
        try
        {
            string str;
            if (this.circleQueue_0.Count > 0)
            {
                str = this.circleQueue_0.Dequeue();
                this.method_10(false, str, true);
            }
            else if (this.circleQueue_1.Count > 0)
            {
                str = this.circleQueue_1.Dequeue();
                this.method_10(false, str, false);
            }
            else
            {
                Thread.Sleep(10);
            }
        }
        catch
        {
        }
        return true;
    }

    public void method_0(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_1(ContactsMessageTypeRoom contactsMessageTypeRoom_0)
    {
        this.object_0 = contactsMessageTypeRoom_0;
    }

    private void method_10(bool bool_5, string string_0, bool bool_6)
    {
        if (this.iuserManager_0.IsUserOnLine(string_0) == bool_6)
        {
            List<string> contacts = this.icontactsManager_0.GetContacts(string_0);
            if (this.bool_0)
            {
                this.ginterface8_0.SelectOnlineUserFrom(contacts);
            }
            int num = bool_6 ? this.object_0.ContactsConnectedNotify : this.object_0.ContactsOfflineNotify;
            IMessageHandler interface2 = this.interface9_0.imethod_4<UserContract>("_0", num, new UserContract(string_0), "*");
            if (bool_5)
            {
                foreach (string str in contacts)
                {
                    if (str != string_0)
                    {
                        this.interface40_0.PostMessage(interface2, str, ActionTypeOnChannelIsBusy.Continue);
                    }
                }
            }
            else
            {
                foreach (string str in contacts)
                {
                    if (str != string_0)
                    {
                        this.interface40_0.SendMessage(interface2, str, ActionTypeOnChannelIsBusy.Continue);
                    }
                }
            }
        }
    }

    private void method_11(string string_0, int int_1, byte[] byte_0, string string_1, int int_2, ResultHandler resultHandler_0, object object_1)
    {
        try
        {
            this.BroadcastBlob(string_0, int_1, byte_0, string_1, int_2);
            if (resultHandler_0 != null)
            {
                resultHandler_0(true, object_1);
            }
        }
        catch (Exception)
        {
            if (resultHandler_0 != null)
            {
                resultHandler_0(false, object_1);
            }
        }
    }

    public void method_2(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public Interface40 method_3()
    {
        return this.interface40_0;
    }

    public void method_4(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public void method_5(IContactsManager icontactsManager_1)
    {
        this.icontactsManager_0 = icontactsManager_1;
    }

    public void method_6(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
        this.bool_0 = !(this.ginterface8_0 is Class135);
    }

    public void method_7()
    {
        if (this.icontactsManager_0 != null)
        {
            this.iuserManager_0.SomeOneConnected += new CbGeneric<UserData>(this.method_9);
            this.iuserManager_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.method_8);
        }
    }

    private void method_8(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        if (this.bool_1)
        {
            if (this.bool_3)
            {
                this.circleQueue_1.Enqueue(userData_0.UserID);
            }
            else
            {
                this.method_10(true, userData_0.UserID, false);
            }
        }
    }

    private void method_9(UserData userData_0)
    {
        if (this.bool_2)
        {
            if (this.bool_3)
            {
                this.circleQueue_0.Enqueue(userData_0.UserID);
            }
            else
            {
                this.method_10(true, userData_0.UserID, true);
            }
        }
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        string destUserID;
        List<string> groupMemberList;
        IHeader interface3;
        if (interface37_0.Header.MessageType == this.object_0.GetContracts)
        {
            ReqContactsContract contract4 = this.interface9_0.imethod_1<ReqContactsContract>(interface37_0);
            List<string> users = new List<string>();
            if (this.icontactsManager_0 != null)
            {
                users = this.icontactsManager_0.GetContacts(interface37_0.Header.UserID);
                if (contract4.JustOnline)
                {
                    users = this.ginterface8_0.SelectOnlineUserFrom(users);
                }
            }
            ResContactsContract body = new ResContactsContract(users);
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<ResContactsContract>(interface3, body);
        }
        if (interface37_0.Header.MessageType == this.object_0.GetGroupMembers)
        {
            GroupContract contract7 = this.interface9_0.imethod_1<GroupContract>(interface37_0);
            groupMemberList = this.icontactsManager_0.GetGroupMemberList(contract7.GroupID);
            GroupmatesContract contract = null;
            if (groupMemberList != null)
            {
                List<string> online = new List<string>();
                List<string> offline = new List<string>();
                foreach (string str2 in groupMemberList)
                {
                    if (this.iuserManager_0.IsUserOnLine(str2))
                    {
                        online.Add(str2);
                    }
                    else
                    {
                        offline.Add(str2);
                    }
                }
                contract = new GroupmatesContract(online, offline);
            }
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<GroupmatesContract>(interface3, contract);
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastByServer)
        {
            bool flag1 = interface37_0.Header.MessageType == this.object_0.BroadcastByServer;
            destUserID = interface37_0.Header.DestUserID;
            BroadcastContract contract2 = this.interface9_0.imethod_1<BroadcastContract>(interface37_0);
            if (this.BroadcastReceived != null)
            {
                this.BroadcastReceived(interface37_0.Header.UserID, destUserID, contract2.InformationType, contract2.Content, contract2.Tag);
            }
            groupMemberList = this.icontactsManager_0.GetGroupMemberList(destUserID);
            if (groupMemberList != null)
            {
                BroadcastInformation information = new BroadcastInformation(interface37_0.Header.UserID, destUserID, contract2.InformationType, contract2.Content, contract2.Tag);
                foreach (string str3 in groupMemberList)
                {
                    if (str3 != interface37_0.Header.UserID)
                    {
                        if (this.ginterface8_0.IsUserOnLine(str3))
                        {
                            this.interface40_0.PostMessage(interface37_0, str3, contract2.ActionTypeOnChannelIsBusy);
                        }
                        else if (this.BroadcastFailed != null)
                        {
                            this.BroadcastFailed(str3, information);
                        }
                    }
                }
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastBlob)
        {
            destUserID = interface37_0.Header.DestUserID;
            if (this.bool_4 && (this.BroadcastReceived != null))
            {
                BlobFragmentContract contract5 = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
                Information information2 = this.class76_0.method_1(interface37_0.Header.UserID, destUserID, contract5);
                if (information2 != null)
                {
                    BlobAndTagContract contract6 = CompactPropertySerializer.Default.Deserialize<BlobAndTagContract>(information2.Content, 0);
                    this.BroadcastReceived(interface37_0.Header.UserID, destUserID, contract5.InformationType, contract6.Message, contract6.Tag);
                }
            }
            groupMemberList = this.icontactsManager_0.GetGroupMemberList(destUserID);
            if (groupMemberList != null)
            {
                foreach (string str3 in groupMemberList)
                {
                    if (str3 != interface37_0.Header.UserID)
                    {
                        this.interface40_0.PostMessage(interface37_0, str3, ActionTypeOnChannelIsBusy.Continue);
                    }
                }
            }
            return null;
        }
        return null;
    }

    public bool BroadcastBlobListened
    {
        get
        {
            return this.bool_4;
        }
        set
        {
            this.bool_4 = value;
            if (!this.bool_4)
            {
                this.class76_0.Clear();
            }
        }
    }

    public bool ContactsConnectedNotifyEnabled
    {
        get
        {
            return this.bool_2;
        }
        set
        {
            this.bool_2 = value;
        }
    }

    public bool ContactsDisconnectedNotifyEnabled
    {
        get
        {
            return this.bool_1;
        }
        set
        {
            this.bool_1 = value;
        }
    }

    public bool UseContactsNotifyThread
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            if (this.bool_3 != value)
            {
                if (!((!value || this.bool_2) || this.bool_1))
                {
                    throw new InvalidOperationException("Can't Use Group Notify Thread because NotifyEnabled is false.");
                }
                this.bool_3 = value;
                if (this.bool_3)
                {
                    this.agileCycleEngine_0.Start();
                }
                else
                {
                    this.agileCycleEngine_0.Stop();
                }
            }
        }
    }
}

