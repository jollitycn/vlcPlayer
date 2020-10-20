namespace CJPlus.Rapid
{
    using CJBasic;
    using CJFramework;
    using CJFramework.Engine.Tcp.Passive;
    using CJPlus.Advanced;
    using CJPlus.Application;
    using CJPlus.Application.Basic;
    using CJPlus.Application.Basic.Passive;
    using CJPlus.Application.Contacts.Passive;
    using CJPlus.Application.CustomizeInfo;
    using CJPlus.Application.CustomizeInfo.Passive;
    using CJPlus.Application.FileTransfering.Passive;
    using CJPlus.Application.Friends.Passive;
    using CJPlus.Application.Group.Passive;
    using CJPlus.Application.P2PSession.Passive;
    using System;

    public interface IRapidPassiveEngine : IRapidEngine
    {
        event CbGeneric ConnectionInterrupted;

        event CbGeneric ConnectionRebuildStart;

        event CbGeneric<string, int, byte[], string> MessageReceived;

        event CbGeneric<LogonResponse> RelogonCompleted;

        void Close();
        void CloseConnection(bool reconnectNow);
        LogonResponse Initialize(string userID, string logonPassword, string serverIP, int serverPort, ICustomizeHandler customizeHandler);
        void SendMessage(string targetUserID, int informationType, byte[] message, string tag);
        void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize);
        void SendMessage(string targetUserID, int informationType, byte[] message, string tag, int fragmentSize, ResultHandler handler, object handlerTag);

        AdvancedOptions Advanced { get; }

        bool AutoReconnect { get; set; }

        IBasicOutter BasicOutter { get; }

        bool ChannelIsBusy { get; }

        bool Connected { get; }

        IContactsOutter ContactsOutter { get; }

        string CurrentUserID { get; }

        ICustomizeOutter CustomizeOutter { get; }

        IFileOutter FileOutter { get; }

        IFriendsOutter FriendsOutter { get; }

        IGroupOutter GroupOutter { get; }

        int HeartBeatSpanInSecs { get; set; }

        IP2PController P2PController { get; }

        AgileIPE P2PServerAddress { get; set; }

        AgileIPE ServerAddress { get; }

        CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo Sock5ProxyInfo { get; set; }

        bool StressTesting { get; set; }

        string SystemToken { get; set; }

        int WaitResponseTimeoutInSecs { get; set; }
    }
}

