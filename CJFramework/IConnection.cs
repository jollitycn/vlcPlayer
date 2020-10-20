using CJBasic;
using CJFramework;
using CJFramework.Server;
using System;
using System.Collections.Generic;
using System.Net;

internal interface IConnection : IDisposable, IEngine, IAction
{
    event CbGeneric<IPEndPoint, string, ClientType> ConnectionBound;

    event CbGeneric<int> ConnectionCountChanged;

    event CbGeneric<Enum4, IMessageHandler> MessageReceived2;

    event CbGeneric<IPEndPoint> SomeOneConnected;

    event CbGeneric<IPEndPoint, DisconnectedType> SomeOneDisconnected;

    PortListenerState GetPortListenerState();
    void imethod_22(Interface41 interface41_0);
    int imethod_23();
    void imethod_24(int int_0);
    int imethod_25();
    void imethod_26(int int_0);
    bool imethod_27();
    void imethod_28(bool bool_0);
    bool imethod_29();
    void imethod_30(bool bool_0);
    bool imethod_31();
    bool imethod_32();
    void imethod_33(bool bool_0);
    void Disconnected(IPEndPoint ipendPoint_0, DisconnectedType disconnectedType_0);
    void imethod_35();
    void imethod_36(IPEndPoint ipendPoint_0);
    void OnConnectionBound(IPEndPoint ipendPoint_0, string string_0);
    Enum4? imethod_38(IPEndPoint ipendPoint_0);
    IList<IPEndPoint> imethod_39();

    bool AsynConnectionEvent { get; set; }

    bool Boolean_0 { get; set; }

    int ConnectionCount { get; }

    int MaxChannelCacheSize { get; set; }

    int MaxConnectionCount { get; }
}

