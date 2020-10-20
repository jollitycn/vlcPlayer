using CJBasic;
using CJFramework.Engine.Udp.Reliable;
using System;
using System.Net;

internal interface Interface17
{
    event CbGeneric<Interface17, SessionClosedCause> SessionClosed;

    void Close(SessionClosedCause sessionClosedCause_0, bool bool_0);
    bool imethod_0();
    IPEndPoint imethod_1();
    string imethod_2();
}

