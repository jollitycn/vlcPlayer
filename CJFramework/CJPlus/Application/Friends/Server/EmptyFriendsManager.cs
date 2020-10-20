namespace CJPlus.Application.Friends.Server
{
    using System;
    using System.Collections.Generic;

    public class EmptyFriendsManager : IFriendsManager
    {
        public List<string> GetFriendsList(string userID, string tag)
        {
            return new List<string>();
        }
    }
}

