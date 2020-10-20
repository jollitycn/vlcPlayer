using CJBasic;
using CJFramework.Engine.Tcp.Passive;
using System;

internal interface Interface26 : IDisposable, IEngine, ICommitMessageToServer
{
    event CbGeneric ConnectionInterrupted;

    event CbGeneric ConnectionRebuildFailure;

    event CbGeneric ConnectionRebuildStart;

    event CbGeneric ConnectionRebuildSucceed;

    void CloseConnection(bool bool_0);
    bool imethod_21();
    int imethod_22();
    void imethod_23(int int_0);
    CbGeneric imethod_24();
    void imethod_25(CbGeneric cbGeneric_0);
    void imethod_26(int int_0);
    void imethod_27();

    bool AutoReconnect { get; set; }

    bool Connected { get; }

    CJFramework.Engine.Tcp.Passive.Sock5ProxyInfo Sock5ProxyInfo { get; set; }
}

