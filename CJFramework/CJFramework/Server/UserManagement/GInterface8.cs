namespace CJFramework.Server.UserManagement
{
    using System;
    using System.Collections.Generic;

    public interface GInterface8
    {
        List<string> GetOnlineUserList();
        UserData GetUserData(string userID);
        bool IsUserOnLine(string userID);
        List<string> SelectOnlineUserFrom(IEnumerable<string> users);

        int UserCount { get; }
    }
}

