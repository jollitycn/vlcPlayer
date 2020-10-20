namespace CJPlus.Application.Friends.Server
{
    using CJFramework.Server.UserManagement;
    using System;
    using System.Collections.Generic;

    public class DefaultFriendsManager : IFriendsManager
    {
        private IUserManager iuserManager_0;

        public DefaultFriendsManager()
        {
        }

        public DefaultFriendsManager(IUserManager mgr)
        {
            this.iuserManager_0 = mgr;
        }

        public List<string> GetFriendsList(string userID, string tag)
        {
            List<string> onlineUserList = this.iuserManager_0.GetOnlineUserList();
            onlineUserList.Remove(userID);
            return onlineUserList;
        }

        public IUserManager UserManager
        {
            set
            {
                this.iuserManager_0 = value;
            }
        }
    }
}

