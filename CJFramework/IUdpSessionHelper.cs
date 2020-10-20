using CJBasic;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;

internal interface IUdpSessionHelper : IUdpSessionStateViewer, IPv6
{
    event CbGeneric<Interface17, SessionClosedCause> UdpSessionClosed;

    event CbGeneric<Interface17> UdpSessionOpened;

    void imethod_1(IPEndPoint ipendPoint_0);
    bool imethod_2(IPEndPoint ipendPoint_0);
    void imethod_3(IPEndPoint ipendPoint_0);
    void imethod_4();
}

