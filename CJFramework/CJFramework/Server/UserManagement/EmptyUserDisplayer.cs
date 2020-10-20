namespace CJFramework.Server.UserManagement
{
    using CJFramework;
    using System;

    public sealed class EmptyUserDisplayer : IUserDisplayer
    {
        public void AddUser(string userID, ClientType clientType, string userAddress)
        {
        }

        public void ClearAll()
        {
        }

        public void OnMessageReceived(string userID, int messageType)
        {
        }

        public void OnMessageSent(string userID, int messageType)
        {
        }

        public void RemoveUser(string userID, string cause)
        {
        }
    }
}

