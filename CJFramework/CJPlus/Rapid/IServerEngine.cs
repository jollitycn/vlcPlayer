namespace CJPlus.Rapid
{
    using CJBasic;
    using CJFramework.Server.UserManagement;
    using CJPlus.Advanced;
    using CJPlus.Application.Basic.Server;
    using CJPlus.Application.Contacts.Server;
    using CJPlus.Application.CustomizeInfo;
    using CJPlus.Application.CustomizeInfo.Server;
    using CJPlus.Application.FileTransfering.Server;
    using CJPlus.Application.Friends.Server;
    using CJPlus.Application.Group.Server;
    using CJPlus.Core;
    using System;

    public interface IRapidServerEngine : IRapidEngine
    {
        event CbGeneric<string, int, byte[], string> MessageReceived;

        void Close();
        void Initialize(int port, ICustomizeHandler customizeHandler);
        void Initialize(int port, ICustomizeHandler customizeHandler, IBasicHandler basicHandler);
        void SendMessage(string targetUserID, int informationType, byte[] message, string tag);
        void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize);

        GInterface3 Advanced { get; }

        bool AutoRespondHeartBeat { get; set; }

        IBasicController BasicController { get; }

        int ConnectionCount { get; }

        IContactsOutter ContactsController { get; }

        IContactsManager ContactsManager { set; }

        GInterface CustomizeController { get; }

        IFileController FileController { get; }

        GInterface4 FriendsController { get; }

        IFriendsManager FriendsManager { set; }

        IGroupOutter GroupController { get; }

        IGroupManager GroupManager { set; }

        int HeartbeatTimeoutInSecs { get; set; }

        string IPAddressBinding { get; set; }

        int MaxConnectionCount { get; }

        GInterface8 PlatformUserManager { get; }

        int Port { get; }

        string ServerID { get; }

        IServiceTypeNameMatcher ServiceTypeNameMatcher { get; }

        bool UseAsP2PServer { get; set; }

        IUserManager UserManager { get; }

        int WaitResponseTimeoutInSecs { get; set; }

        int WriteTimeoutInSecs { get; set; }

        CJPlus.Rapid.WssOptions WssOptions { get; set; }
    }
}

