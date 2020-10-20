using CJBasic;
using CJPlus.Application.P2PSession;
using CJPlus.Application.P2PSession.Passive;
using System;
using System.Collections.Generic;

internal interface Interface24 : IDisposable, IP2PChannel
{
    event CbGeneric<P2PChannelState> P2PChannelClosed;

    event CbGeneric<P2PChannelState> P2PChannelOpened;

    Dictionary<string, P2PChannelState> GetP2PChannelState();
    P2PChannelState GetP2PChannelState(string string_0);
    void imethod_10();
    int GetPort();
    bool imethod_5();
    void imethod_6(bool bool_0);
    void imethod_7(UserAddressInfo userAddressInfo_0);
    void Close(string string_0);
    void imethod_9();
    bool IsP2PChannelExist(string destUserID);
    void P2PConnectAsyn(UserAddressInfo userAddressInfo_0);
}

