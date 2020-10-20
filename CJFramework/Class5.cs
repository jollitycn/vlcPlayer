using CJBasic;
using CJBasic.Arithmetic;
using System;
using System.Net;

internal sealed class Class5 : Class4
{
    private byte[] byte_0;
    private Class8 class8_0;
    private int int_3;
    private int[] int_4;

    public Class5(Class8 class8_1, IPEndPoint ipendPoint_1, CbGeneric<Interface5, IMessageHandler> pointer, int int_5) : base(class8_1.method_2(), ipendPoint_1, pointer, int_5)
    {
        this.int_3 = 0;
        this.class8_0 = class8_1;
        this.byte_0 = new byte[this.class8_0.cXkPpBiZo7()];
        this.int_4 = GenericKMP.Next<byte>(class8_1.method_4());
    }

    public string kjfPdghQbi()
    {
        int num = GenericKMP.ExecuteKMP<byte>(this.byte_0, 0, this.int_3, this.class8_0.method_4(), this.int_4);
        if (num < 0)
        {
            return null;
        }
        byte[] dst = new byte[num + this.class8_0.method_4().Length];
        Buffer.BlockCopy(this.byte_0, 0, dst, 0, dst.Length);
        if (this.int_3 != dst.Length)
        {
            Buffer.BlockCopy(this.byte_0, dst.Length, this.byte_0, 0, this.int_3 - dst.Length);
        }
        this.int_3 -= dst.Length;
        return this.class8_0.method_0().imethod_8(dst, 0, dst.Length);
    }

    public void method_10()
    {
        this.int_3 = 0;
    }

    public byte[] method_4()
    {
        return this.byte_0;
    }

    public int method_5()
    {
        return this.int_3;
    }

    public int method_6()
    {
        return (this.class8_0.cXkPpBiZo7() - this.int_3);
    }

    public void method_7(int int_5)
    {
        this.int_3 += int_5;
    }

    public string method_8()
    {
        return null;
    }

    public bool method_9()
    {
        return (this.class8_0.cXkPpBiZo7() == this.int_3);
    }
}

