namespace CJPlus.Application.Friends.Server
{
    using System;
    using System.Collections.Generic;

    public interface IFriendsManager
    {
        List<string> GetFriendsList(string ownerID, string tag);
    }
}

