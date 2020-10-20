namespace CJPlus.Application.Basic.Passive
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Net;

    public interface IBasicOutter
    {
        event CbGeneric BeingKickedOut;

        event CbGeneric BeingPushedOut;

        List<string> GetAllOnlineUsers();
        IPEndPoint GetMyIPE();
        IPEndPoint GetIPEndPoint(string userID);
        Dictionary<string, bool> IsUserOnline(List<string> list_0);
        bool IsUserOnline(string userID);
        void KickOut(string targetUserID);
        int Ping();
        int PingByP2PChannel(string targetUserID);
        int PingByServer(string targetUserID);
        void SendHeartBeatMessage();
    }
}

