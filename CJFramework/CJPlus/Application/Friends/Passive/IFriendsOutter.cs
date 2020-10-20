namespace CJPlus.Application.Friends.Passive
{
    using CJBasic;
    using System;
    using System.Collections.Generic;

    public interface IFriendsOutter
    {
        event CbGeneric<string> FriendConnected;

        event CbGeneric<string> FriendOffline;

        List<string> GetAllOnlineFriends();
        List<string> GetFriends(string tag);
    }
}

