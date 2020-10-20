using CJBasic;
using CJBasic.ObjectManagement;
using CJBasic.Threading.Engines;
using CJFramework;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using CJPlus.Application.Friends;
using CJPlus.Application.Friends.Server;
using System;
using System.Collections.Generic;
using System.Threading;

internal class Class25 : IEngineActor, IProcess, GInterface4
{
    private AgileCycleEngine agileCycleEngine_0;
    private bool bool_0 = false;
    private bool bool_1 = false;
    private bool bool_2 = true;
    private bool bool_3 = false;
    private CircleQueue<string> circleQueue_0 = new CircleQueue<string>(0x2710);
    private CircleQueue<string> circleQueue_1 = new CircleQueue<string>(0x2710);
    private GInterface8 ginterface8_0;
    private IFriendsManager ifriendsManager_0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private IUserManager iuserManager_0 = null;
    private FriendsMessageTypeRoom object_0 = null;

    public Class25()
    {
        this.agileCycleEngine_0 = new AgileCycleEngine(this);
        this.agileCycleEngine_0.DetectSpanInSecs = 0;
    }

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public bool EngineAction()
    {
        try
        {
            string str;
            if (this.circleQueue_0.Count > 0)
            {
                str = this.circleQueue_0.Dequeue();
                this.method_8(false, str, true);
            }
            else if (this.circleQueue_1.Count > 0)
            {
                str = this.circleQueue_1.Dequeue();
                this.method_8(false, str, false);
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

    public FriendsMessageTypeRoom method_0()
    {
        return (FriendsMessageTypeRoom) this.object_0;
    }

    public void method_1(FriendsMessageTypeRoom friendsMessageTypeRoom_0)
    {
        this.object_0 = friendsMessageTypeRoom_0;
    }

    private void method_10(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        if (this.bool_1)
        {
            if (this.bool_3)
            {
                this.circleQueue_1.Enqueue(userData_0.UserID);
            }
            else
            {
                this.method_8(true, userData_0.UserID, false);
            }
        }
    }

    private void method_11(UserData userData_0)
    {
        if (this.bool_1 && this.bool_2)
        {
            if (this.bool_3)
            {
                this.circleQueue_0.Enqueue(userData_0.UserID);
            }
            else
            {
                this.method_8(true, userData_0.UserID, true);
            }
        }
    }

    public void method_2(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_3(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public Interface40 method_4()
    {
        return this.interface40_0;
    }

    public void method_5(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public void method_6(IFriendsManager ifriendsManager_1)
    {
        this.ifriendsManager_0 = ifriendsManager_1;
    }

    public void method_7(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
        this.bool_0 = !(this.ginterface8_0 is Class135);
    }

    private void method_8(bool bool_4, string string_0, bool bool_5)
    {
        if ((this.ifriendsManager_0 != null) && (this.iuserManager_0.IsUserOnLine(string_0) == bool_5))
        {
            List<string> friendsList = this.ifriendsManager_0.GetFriendsList(string_0, null);
            List<string> list = friendsList;
            if (this.bool_0)
            {
                list = this.ginterface8_0.SelectOnlineUserFrom(friendsList);
            }
            IMessageHandler interface2 = this.interface9_0.imethod_4<FriendNotifyContract>("_0", this.object_0.FriendNotify, new FriendNotifyContract(string_0, bool_5), "*");
            if (bool_4)
            {
                this.interface40_0.PostMessage(interface2, list, ActionTypeOnChannelIsBusy.Continue);
            }
            else
            {
                this.interface40_0.SendMessage(interface2, list, ActionTypeOnChannelIsBusy.Continue);
            }
        }
    }

    public void method_9()
    {
        if (this.ifriendsManager_0 != null)
        {
            this.iuserManager_0.SomeOneConnected += new CbGeneric<UserData>(this.method_11);
            this.iuserManager_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.method_10);
        }
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        if (interface37_0.Header.MessageType == this.object_0.GetFriends)
        {
            ReqFriendsContract contract2 = this.interface9_0.imethod_1<ReqFriendsContract>(interface37_0);
            List<string> users = new List<string>();
            if (this.ifriendsManager_0 != null)
            {
                users = this.ifriendsManager_0.GetFriendsList(interface37_0.Header.UserID, contract2.Tag);
                if (contract2.JustOnline)
                {
                    users = this.ginterface8_0.SelectOnlineUserFrom(users);
                }
            }
            ResFriendsContract body = new ResFriendsContract(users);
            IHeader interface2 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<ResFriendsContract>(interface2, body);
        }
        return null;
    }

    public bool FriendConnectedNotifyEnabled
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

    public bool FriendNotifyEnabled
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

    public bool UseFriendNotifyThread
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
                    throw new InvalidOperationException("Can't Use Friend Notify Thread because FriendNotifyEnabled is false.");
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

