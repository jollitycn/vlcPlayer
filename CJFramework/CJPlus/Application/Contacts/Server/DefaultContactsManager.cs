namespace CJPlus.Application.Contacts.Server
{
    using CJFramework.Server.UserManagement;
    using System;
    using System.Collections.Generic;

    public class DefaultContactsManager : IContactsManager
    {
        private IUserManager iuserManager_0;

        public DefaultContactsManager()
        {
        }

        public DefaultContactsManager(IUserManager mgr)
        {
            this.iuserManager_0 = mgr;
        }

        public List<string> GetContacts(string userID)
        {
            return this.iuserManager_0.GetOnlineUserList();
        }

        public List<string> GetGroupMemberList(string groupID)
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

