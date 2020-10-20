using System;

internal interface IUdpHelper : IDisposable, IEngine
{
    Enum6 imethod_1();
    void imethod_19(Enum6 enum6_0);
    bool imethod_20();
    IUdpSessionHelper GetIUdpSessionHelper();
}

