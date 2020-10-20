using System;

internal class Class145
{
    private byte[] byte_0;
    private DateTime dateTime_0 = DateTime.Now;
    private DateTime dateTime_1 = DateTime.Now;
    private int int_0 = 0;
    private ulong ulong_0 = 0L;

    public Class145(byte[] byte_1, ulong ulong_1)
    {
        this.byte_0 = byte_1;
        this.ulong_0 = ulong_1;
    }

    public ulong method_0()
    {
        return this.ulong_0;
    }

    public byte[] method_1()
    {
        return this.byte_0;
    }

    public DateTime method_2()
    {
        return this.dateTime_1;
    }

    public int method_3()
    {
        return this.int_0;
    }

    public void method_4()
    {
        this.int_0++;
    }
}

