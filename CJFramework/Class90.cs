using System;
using System.Runtime.CompilerServices;

internal class Class90
{
    [CompilerGenerated]
    private int int_0;
    [CompilerGenerated]
    private int int_1;
    [CompilerGenerated]
    private int int_2;
    [CompilerGenerated]
    private int int_3;
    [CompilerGenerated]
    private int int_4;

    [CompilerGenerated]
    public int method_0()
    {
        return this.int_0;
    }

    [CompilerGenerated]
    public void SetPlatform(int int_5)
    {
        this.int_0 = int_5;
    }

    public byte[] method_10()
    {
        byte[] dst = new byte[0x18];
        byte[] bytes = BitConverter.GetBytes((int) (dst.Length - 4));
        byte[] src = BitConverter.GetBytes(this.method_0());
        byte[] buffer4 = BitConverter.GetBytes(this.method_2());
        byte[] buffer5 = BitConverter.GetBytes(this.method_4());
        byte[] buffer6 = BitConverter.GetBytes(this.method_6());
        byte[] buffer7 = BitConverter.GetBytes(this.method_8());
        Buffer.BlockCopy(bytes, 0, dst, 0, 4);
        Buffer.BlockCopy(src, 0, dst, 4, 4);
        Buffer.BlockCopy(buffer4, 0, dst, 8, 4);
        Buffer.BlockCopy(buffer5, 0, dst, 12, 4);
        Buffer.BlockCopy(buffer6, 0, dst, 0x10, 4);
        Buffer.BlockCopy(buffer7, 0, dst, 20, 4);
        return dst;
    }

    [CompilerGenerated]
    public int method_2()
    {
        return this.int_1;
    }

    [CompilerGenerated]
    public void method_3(int int_5)
    {
        this.int_1 = int_5;
    }

    [CompilerGenerated]
    public int method_4()
    {
        return this.int_2;
    }

    [CompilerGenerated]
    public void method_5(int int_5)
    {
        this.int_2 = int_5;
    }

    [CompilerGenerated]
    public int method_6()
    {
        return this.int_3;
    }

    [CompilerGenerated]
    public void method_7(int int_5)
    {
        this.int_3 = int_5;
    }

    [CompilerGenerated]
    public int method_8()
    {
        return this.int_4;
    }

    [CompilerGenerated]
    public void method_9(int int_5)
    {
        this.int_4 = int_5;
    }
}

