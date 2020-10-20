using System;
using System.Net;

internal interface IMessageHandler
{
    IPEndPoint imethod_0();
    int imethod_1();
    byte[] ToStream();

    IHeader Header { get; }
}

