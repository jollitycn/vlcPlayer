namespace CJPlus.Application.Group.Server
{
    using System;
    using System.Collections.Generic;

    public interface IGroupManager
    {
        List<string> GetGroupmates(string userID);
        List<string> GetGroupMembers(string groupID);
    }
}

