using CJBasic;
using System;
using System.Net;

internal interface IPv6
{
    event CbGeneric<IPEndPoint, byte[]> DataReceived;

    void Dispose();
    void imethod_0(byte[] byte_0, IPEndPoint ipendPoint_0);
    void Initialize();
    void Send(byte[] byte_0, IPEndPoint ipendPoint_0);
}

