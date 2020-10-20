using System;
using System.Runtime.CompilerServices;

internal class Class163
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
    public int lXarmdDqDo()
    {
        return this.int_0;
    }

    [CompilerGenerated]
    public void SetPlatform(int int_5)
    {
        this.int_0 = int_5;
    }

    [CompilerGenerated]
    public int method_1()
    {
        return this.int_1;
    }

    [CompilerGenerated]
    public void method_2(int int_5)
    {
        this.int_1 = int_5;
    }

    [CompilerGenerated]
    public int method_3()
    {
        return this.int_2;
    }

    [CompilerGenerated]
    public void method_4(int int_5)
    {
        this.int_2 = int_5;
    }

    [CompilerGenerated]
    public int method_5()
    {
        return this.int_3;
    }

    [CompilerGenerated]
    public void method_6(int int_5)
    {
        this.int_3 = int_5;
    }

    [CompilerGenerated]
    public int method_7()
    {
        return this.int_4;
    }

    [CompilerGenerated]
    public void method_8(int int_5)
    {
        this.int_4 = int_5;
    }

    public byte[] method_9()
    {
        byte[] dst = new byte[0x18];
        byte[] bytes = BitConverter.GetBytes((int) (dst.Length - 4));
        byte[] src = BitConverter.GetBytes(this.lXarmdDqDo());
        byte[] buffer4 = BitConverter.GetBytes(this.method_1());
        byte[] buffer5 = BitConverter.GetBytes(this.method_3());
        byte[] buffer6 = BitConverter.GetBytes(this.method_5());
        byte[] buffer7 = BitConverter.GetBytes(this.method_7());
        Buffer.BlockCopy(bytes, 0, dst, 0, 4);
        Buffer.BlockCopy(src, 0, dst, 4, 4);
        Buffer.BlockCopy(buffer4, 0, dst, 8, 4);
        Buffer.BlockCopy(buffer5, 0, dst, 12, 4);
        Buffer.BlockCopy(buffer6, 0, dst, 0x10, 4);
        Buffer.BlockCopy(buffer7, 0, dst, 20, 4);
        return dst;
    }
}

