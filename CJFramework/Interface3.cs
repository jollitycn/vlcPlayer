using CJBasic;
using CJBasic.Loggers;
using CJFramework.Core;
using System;
using System.Net;

internal interface IEngine : IDisposable
{
    event CbGeneric<IEngine> EngineDisposed;

    event CbGeneric<IPEndPoint, MessageInvalidType> InvalidMessageReceived;

    event CbGeneric<IMessageHandler> MessageReceived;

    event CbGeneric<IPEndPoint, IMessageHandler> MessageSent;

    ProtocolType GetProtocolType();
    Enum6 imethod_1();
    void imethod_10(int int_0);
    Interface25 imethod_11();
    void imethod_12(Interface25 interface25_0);
    void imethod_13(Interface25 interface25_0);
    IStreamContract GetStreamContract();
    void SetStreamContract(IStreamContract interface8_0);
    bool imethod_16();
    void OnDispose();
    DateTime GetDateTime();
    void SetData(int int_0);
    string imethod_4();
    IAgileLogger GetAgileLogger();
    void SetAgileLogger(IAgileLogger iagileLogger_0);
    int imethod_7();
    void imethod_8(int int_0);
    int imethod_9();
    void Initialize();
    void LjXdpkRter(string string_0);

    int Port { get; }

    int SocketSendBuffSize { get; set; }

    int UncompletedSendingCount4Busy { get; set; }
}

