namespace CJPlus.Application.P2PSession.Passive
{
    using CJBasic;
    using CJFramework.Engine.Udp.Reliable;
    using System;
    using System.Collections.Generic;

    public interface IP2PController
    {
        event CbGeneric AllP2PChannelClosed;

        event CbGeneric<P2PChannelState> P2PChannelClosed;

        event CbGeneric<P2PChannelState> P2PChannelOpened;

        event CbGeneric<string> P2PConnectFailed;

        Dictionary<string, P2PChannelState> GetP2PChannelState();
        P2PChannelState GetP2PChannelState(string destUserID);
        IUdpSessionStateViewer GetUdpSessionStateViewer();
        bool IsP2PChannelExist(string destUserID);
        bool? P2PChannelIsBusy(string destUserID);
        void P2PConnectAsyn(string destUserID);

        CJPlus.Application.P2PSession.Passive.P2PChannelMode P2PChannelMode { get; set; }
    }
}

