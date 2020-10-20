namespace CJFramework.Server.UserManagement
{
    using CJFramework;
    using System;

    public interface IUserDisplayer
    {
        void AddUser(string userID, ClientType clientType, string userAddress);
        void ClearAll();
        void OnMessageReceived(string userID, int messageType);
        void OnMessageSent(string userID, int messageType);
        void RemoveUser(string userID, string cause);
    }
}

