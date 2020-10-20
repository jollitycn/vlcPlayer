using CJBasic;
using System;
using System.Net;
using System.Net.Sockets;

internal sealed class Class7 : Class4
{
    private byte[] byte_0;

    public Class7(NetworkStream networkStream_0, IPEndPoint ipendPoint_1, int int_3, CbGeneric<Interface5, IMessageHandler> pointer, int int_4) : base(networkStream_0, ipendPoint_1, pointer, int_4)
    {
        this.byte_0 = new byte[int_3];
    }

    public byte[] method_4()
    {
        return this.byte_0;
    }
}

