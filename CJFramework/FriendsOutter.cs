using CJBasic;
using CJPlus.Application.Friends;
using CJPlus.Application.Friends.Passive;
using System;
using System.Collections.Generic;
using System.Threading;

internal class FriendsOutter : IFriendsOutter
{
    private bool bool_0 = false;
    private FriendsMessageTypeRoom friendsMessageTypeRoom_0 = null;
    private IActionType interface31_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private string string_0 = "";

    public event CbGeneric<string> FriendConnected;

    public event CbGeneric<string> FriendOffline;

    public List<string> GetAllOnlineFriends()
    {
        return this.method_5(null, true);
    }

    public List<string> GetFriends(string tag)
    {
        return this.method_5(tag, false);
    }

    public bool method_0()
    {
        return this.bool_0;
    }

    public void method_1(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }

    public void method_2(FriendsMessageTypeRoom friendsMessageTypeRoom_1)
    {
        this.friendsMessageTypeRoom_0 = friendsMessageTypeRoom_1;
    }

    public void method_3(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_4(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    private List<string> method_5(string string_1, bool bool_1)
    {
        ReqFriendsContract body = new ReqFriendsContract(bool_1, string_1);
        IMessageHandler interface2 = this.interface9_0.imethod_5<ReqFriendsContract>(this.string_0, this.friendsMessageTypeRoom_0.GetFriends, body);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.friendsMessageTypeRoom_0.GetFriends));
        return this.interface9_0.imethod_1<ResFriendsContract>(interface3).UserList;
    }

    internal void method_6(string string_1)
    {
        if (this.FriendConnected != null)
        {
            this.FriendConnected(string_1);
        }
    }

    internal void method_7(string string_1)
    {
        if (this.FriendOffline != null)
        {
            this.FriendOffline(string_1);
        }
    }
}

