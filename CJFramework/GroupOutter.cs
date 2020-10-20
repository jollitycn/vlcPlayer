using CJBasic;
using CJBasic.ObjectManagement;
using CJBasic.Threading.Engines;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus.Application;
using CJPlus.Application.Group;
using CJPlus.Application.Group.Server;
using System;
using System.Collections.Generic;
using System.Threading;

internal class GroupOutter : IEngineActor, IProcess, IGroupOutter
{
    private AgileCycleEngine agileCycleEngine_0;
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = true;
    private bool bool_3 = false;
    private bool bool_4 = false;
    private CircleQueue<string> circleQueue_0 = new CircleQueue<string>(0x2710);
    private CircleQueue<string> circleQueue_1 = new CircleQueue<string>(0x2710);
    private Class76 class76_0 = new Class76();
    private GInterface8 ginterface8_0;
    private IGroupManager igroupManager_0;
    private int int_0 = 0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private IUserManager iuserManager_0 = null;
    private GroupMessageTypeRoom object_0;

    public event CbGeneric<string, string, int, byte[]> BroadcastReceived;

    public GroupOutter()
    {
        this.agileCycleEngine_0 = new AgileCycleEngine(this);
        this.agileCycleEngine_0.DetectSpanInSecs = 0;
    }

    public void Broadcast(string groupID, int broadcastType, byte[] broadcastContent, ActionTypeOnChannelIsBusy action)
    {
        List<string> groupMembers = this.igroupManager_0.GetGroupMembers(groupID);
        if ((groupMembers != null) && (groupMembers.Count > 0))
        {
            BroadcastContract body = new BroadcastContract(groupID, broadcastType, broadcastContent, action);
            IMessageHandler interface2 = this.interface9_0.imethod_5<BroadcastContract>("_0", this.object_0.BroadcastByServer, body);
            this.interface40_0.PostMessage(interface2, groupMembers, action);
        }
    }

    public void BroadcastBlob(string groupID, int broadcastType, byte[] blobContent, int fragmentSize)
    {
        if (fragmentSize <= 0)
        {
            throw new ArgumentException("Value of fragmentSize must be greater than 0.");
        }
        List<string> groupMembers = this.igroupManager_0.GetGroupMembers(groupID);
        if ((groupMembers != null) && (groupMembers.Count != 0))
        {
            int num3 = Interlocked.Increment(ref this.int_0);
            int num2 = blobContent.Length / fragmentSize;
            if ((blobContent.Length % fragmentSize) > 0)
            {
                num2++;
            }
            for (int i = 0; i < num2; i++)
            {
                byte[] dst = null;
                if (i < (num2 - 1))
                {
                    dst = new byte[fragmentSize];
                }
                else
                {
                    dst = new byte[blobContent.Length - (i * fragmentSize)];
                }
                Buffer.BlockCopy(blobContent, i * fragmentSize, dst, 0, dst.Length);
                BlobFragmentContract body = new BlobFragmentContract(num3, broadcastType, i, dst, i == (num2 - 1));
                IMessageHandler interface2 = this.interface9_0.imethod_4<BlobFragmentContract>("_0", this.object_0.BroadcastBlob, body, groupID);
                this.interface40_0.PostMessage(interface2, groupMembers, ActionTypeOnChannelIsBusy.Continue);
            }
        }
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

    public void SetMessageTypeRoom(GroupMessageTypeRoom groupMessageTypeRoom_0)
    {
        this.object_0 = groupMessageTypeRoom_0;
    }

    private void method_10(bool bool_5, string string_0, bool bool_6)
    {
        if (this.iuserManager_0.IsUserOnLine(string_0) == bool_6)
        {
            List<string> groupmates = this.igroupManager_0.GetGroupmates(string_0);
            if (this.bool_0)
            {
                this.ginterface8_0.SelectOnlineUserFrom(groupmates);
            }
            int num = bool_6 ? this.object_0.GroupmateConnectedNotify : this.object_0.GroupmateOfflineNotify;
            IMessageHandler interface2 = this.interface9_0.imethod_4<UserContract>("_0", num, new UserContract(string_0), "*");
            if (bool_5)
            {
                foreach (string str in groupmates)
                {
                    if (str != string_0)
                    {
                        this.interface40_0.PostMessage(interface2, str, ActionTypeOnChannelIsBusy.Continue);
                    }
                }
            }
            else
            {
                foreach (string str in groupmates)
                {
                    if (str != string_0)
                    {
                        this.interface40_0.SendMessage(interface2, str, ActionTypeOnChannelIsBusy.Continue);
                    }
                }
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

    public void SetGroupManager(IGroupManager igroupManager_1)
    {
        this.igroupManager_0 = igroupManager_1;
    }

    public void method_6(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
        this.bool_0 = !(this.ginterface8_0 is Class135);
    }

    public void Init()
    {
        if (this.igroupManager_0 != null)
        {
            this.iuserManager_0.SomeOneConnected += new CbGeneric<UserData>(this.OnSomeOneConnected);
            this.iuserManager_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.OnSomeOneDisconnected);
        }
    }

    private void OnSomeOneDisconnected(UserData userData_0, DisconnectedType disconnectedType_0)
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

    private void OnSomeOneConnected(UserData userData_0)
    {
        if (this.bool_1 && this.bool_2)
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
        List<string> groupMembers;
        string destUserID;
        if (interface37_0.Header.MessageType == this.object_0.GetGroupMembers)
        {
            GroupContract contract4 = this.interface9_0.imethod_1<GroupContract>(interface37_0);
            groupMembers = this.igroupManager_0.GetGroupMembers(contract4.GroupID);
            GroupmatesContract body = null;
            if (groupMembers != null)
            {
                List<string> online = new List<string>();
                List<string> offline = new List<string>();
                foreach (string str in groupMembers)
                {
                    if (this.iuserManager_0.IsUserOnLine(str))
                    {
                        online.Add(str);
                    }
                    else
                    {
                        offline.Add(str);
                    }
                }
                body = new GroupmatesContract(online, offline);
            }
            IHeader interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<GroupmatesContract>(interface3, body);
        }
        if (interface37_0.Header.MessageType == this.object_0.BroadcastByServer)
        {
            bool flag1 = interface37_0.Header.MessageType == this.object_0.BroadcastByServer;
            destUserID = interface37_0.Header.DestUserID;
            BroadcastContract contract2 = this.interface9_0.imethod_1<BroadcastContract>(interface37_0);
            if (this.BroadcastReceived != null)
            {
                this.BroadcastReceived(interface37_0.Header.UserID, destUserID, contract2.InformationType, contract2.Content);
            }
            groupMembers = this.igroupManager_0.GetGroupMembers(destUserID);
            if (groupMembers != null)
            {
                foreach (string str2 in groupMembers)
                {
                    if (str2 != interface37_0.Header.UserID)
                    {
                        this.interface40_0.PostMessage(interface37_0, str2, contract2.ActionTypeOnChannelIsBusy);
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
                BlobFragmentContract contract3 = this.interface9_0.imethod_1<BlobFragmentContract>(interface37_0);
                Information information = this.class76_0.method_1(interface37_0.Header.UserID, destUserID, contract3);
                if (information != null)
                {
                    this.BroadcastReceived(interface37_0.Header.UserID, destUserID, contract3.InformationType, information.Content);
                }
            }
            groupMembers = this.igroupManager_0.GetGroupMembers(destUserID);
            if (groupMembers != null)
            {
                foreach (string str2 in groupMembers)
                {
                    if (str2 != interface37_0.Header.UserID)
                    {
                        this.interface40_0.PostMessage(interface37_0, str2, ActionTypeOnChannelIsBusy.Continue);
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

    public bool GroupmateConnectedNotifyEnabled
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

    public bool GroupNotifyEnabled
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

    public bool UseGroupNotifyThread
    {
        get
        {
            return this.bool_3;
        }
        set
        {
            if (this.bool_3 != value)
            {
                if (!(!value || this.bool_1))
                {
                    throw new InvalidOperationException("Can't Use Group Notify Thread because GroupNotifyEnabled is false.");
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

