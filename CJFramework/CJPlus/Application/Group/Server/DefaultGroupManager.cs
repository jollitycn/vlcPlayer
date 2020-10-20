namespace CJPlus.Application.Group.Server
{
    using CJFramework.Server.UserManagement;
    using System;
    using System.Collections.Generic;

    public class DefaultGroupManager : IGroupManager
    {
        private IUserManager iuserManager_0;

        public DefaultGroupManager()
        {
        }

        public DefaultGroupManager(IUserManager mgr)
        {
            this.iuserManager_0 = mgr;
        }

        public List<string> GetGroupmates(string userID)
        {
            return this.iuserManager_0.GetOnlineUserList();
        }

        public List<string> GetGroupMembers(string groupID)
        {
            if (groupID == "#0")
            {
                return this.iuserManager_0.GetOnlineUserList();
            }
            return new List<string>();
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

