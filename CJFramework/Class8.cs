using System;
using System.Net.Sockets;

internal sealed class Class8
{
    private byte[] byte_0;
    private int int_0;
    private Interface10 interface10_0;
    private NetworkStream networkStream_0;

    public Class8()
    {
    }

    public Class8(NetworkStream networkStream_1, int int_1, byte[] byte_1, Interface10 interface10_1)
    {
        this.networkStream_0 = networkStream_1;
        this.int_0 = int_1;
        this.byte_0 = byte_1;
        this.interface10_0 = interface10_1;
    }

    public int cXkPpBiZo7()
    {
        return this.int_0;
    }

    public Interface10 method_0()
    {
        return this.interface10_0;
    }

    public void method_1(Interface10 interface10_1)
    {
        this.interface10_0 = interface10_1;
    }

    public NetworkStream method_2()
    {
        return this.networkStream_0;
    }

    public void method_3(NetworkStream networkStream_1)
    {
        this.networkStream_0 = networkStream_1;
    }

    public byte[] method_4()
    {
        return this.byte_0;
    }

    public void method_5(byte[] byte_1)
    {
        this.byte_0 = byte_1;
    }

    public void method_6(int int_1)
    {
        this.int_0 = int_1;
    }
}

