namespace CJPlus.Application.P2PSession.Passive
{
    using CJBasic;
    using CJFramework.Engine.Udp.Reliable;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class GClass0 : IP2PController
    {
        public event CbGeneric AllP2PChannelClosed;

        public event CbGeneric<P2PChannelState> P2PChannelClosed;

        public event CbGeneric<P2PChannelState> P2PChannelOpened;

        public event CbGeneric<string> P2PConnectFailed;

        public Dictionary<string, P2PChannelState> GetP2PChannelState()
        {
            return new Dictionary<string, P2PChannelState>();
        }

        public P2PChannelState GetP2PChannelState(string destUserID)
        {
            return null;
        }

        public object GetPassiveServerHelper()
        {
            return null;
        }

        public IUdpSessionStateViewer GetUdpSessionStateViewer()
        {
            return null;
        }

        public bool IsP2PChannelExist(string destUserID)
        {
            return false;
        }

        public bool? P2PChannelIsBusy(string destUserID)
        {
            return null;
        }

        public void P2PConnectAsyn(string destUserID)
        {
        }

        public CJPlus.Application.P2PSession.Passive.P2PChannelMode P2PChannelMode
        {
            get
            {
                return CJPlus.Application.P2PSession.Passive.P2PChannelMode.TcpAndUdp;
            }
            set
            {
            }
        }

        public bool PMTUDiscoveryEnabled
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}

