namespace CJFramework.Server.UserManagement
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Net;

    public interface IUserManager
    {
        event CbGeneric<string, IPEndPoint> NewConnectionIgnored;

        event CbGeneric<string, P2PAddress> P2PAddressChanged;

        event CbGeneric<UserData> SomeOneBeingPushedOut;

        event CbGeneric<UserData> SomeOneConnected;

        event CbGeneric<UserData, DisconnectedType> SomeOneDisconnected;

        event CbGeneric<UserData> SomeOneTimeOuted;

        event CbGeneric<int> UserCountChanged;

        event CbGeneric<string, object> UserTagChanged;

        List<UserData> GetAllUserData();
        List<string> GetOnlineUserList();
        IPEndPoint GetUserAddress(string userID);
        UserData GetUserData(string userID);
        void Initialize();
        bool IsUserOnLine(string userID);
        void LogonOtherServer(string userID, string newServerID);
        List<string> SelectOnlineUserFrom(IEnumerable<string> users);
        void SetP2PAddress(string userID, P2PAddress addr);

        CJFramework.Server.UserManagement.RelogonMode RelogonMode { get; set; }

        int UserCount { get; }

        IUserDisplayer UserDisplayer { set; }
    }
}

