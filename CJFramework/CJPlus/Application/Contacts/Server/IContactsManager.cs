namespace CJPlus.Application.Contacts.Server
{
    using System;
    using System.Collections.Generic;

    public interface IContactsManager
    {
        List<string> GetContacts(string userID);
        List<string> GetGroupMemberList(string groupID);
    }
}

