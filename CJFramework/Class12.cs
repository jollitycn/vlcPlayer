using System;
using System.Runtime.InteropServices;

internal class Class12
{
    private byte[] byte_0;
    private byte[] byte_1;
    private byte[] byte_2;
    private Class11 class11_0;

    public Class12()
    {
        this.byte_0 = new byte[0];
        this.byte_1 = new byte[0];
        this.byte_2 = new byte[0];
    }

    public Class12(byte[] byte_3, bool bool_0)
    {
        this.byte_0 = new byte[0];
        this.byte_1 = new byte[0];
        this.byte_2 = new byte[0];
        sbyte num2 = bool_0 ? ((sbyte) 2) : ((sbyte) 1);
        this.byte_2 = byte_3;
        int length = this.byte_2.Length;
        if (length < 0x7e)
        {
            this.byte_0 = new byte[0];
            this.class11_0 = new Class11(true, false, false, false, num2, false, length);
        }
        else if (length < 0x10000)
        {
            this.byte_0 = new byte[2];
            this.class11_0 = new Class11(true, false, false, false, num2, false, 0x7e);
            this.byte_0[0] = (byte) (length / 0x100);
            this.byte_0[1] = (byte) (length % 0x100);
        }
        else
        {
            this.byte_0 = new byte[8];
            this.class11_0 = new Class11(true, false, false, false, num2, false, 0x7f);
            int num3 = length;
            int num4 = 0x100;
            for (int i = 7; i > 1; i--)
            {
                this.byte_0[i] = (byte) (num3 % num4);
                num3 /= num4;
                if (num3 == 0)
                {
                    break;
                }
            }
        }
    }

    public Class12(Class11 class11_1, byte[] byte_3, byte[] byte_4, byte[] byte_5)
    {
        this.byte_0 = new byte[0];
        this.byte_1 = new byte[0];
        this.byte_2 = new byte[0];
        this.class11_0 = class11_1;
        this.byte_0 = byte_3;
        this.byte_1 = byte_4;
        this.byte_2 = byte_5;
    }

    public byte[] method_0()
    {
        byte[] dst = new byte[((2 + this.byte_0.Length) + this.byte_1.Length) + this.byte_2.Length];
        Buffer.BlockCopy(this.class11_0.method_7(), 0, dst, 0, 2);
        Buffer.BlockCopy(this.byte_0, 0, dst, 2, this.byte_0.Length);
        Buffer.BlockCopy(this.byte_1, 0, dst, 2 + this.byte_0.Length, this.byte_1.Length);
        Buffer.BlockCopy(this.byte_2, 0, dst, (2 + this.byte_0.Length) + this.byte_1.Length, this.byte_2.Length);
        return dst;
    }

    public byte[] method_1()
    {
        return this.byte_2;
    }

    public static Class12 smethod_0(object object_0, int int_0, out int int_1)
    {
        int_1 = 0;
        if (int_0 < 2)
        {
            return null;
        }
        Class11 class2 = new Class11((byte[]) object_0);
        byte[] dst = new byte[0];
        byte[] buffer = new byte[0];
        byte[] buffer3 = new byte[0];
        if (class2.method_6() == 0x7e)
        {
            dst = new byte[2];
            if (int_0 < 4)
            {
                return null;
            }
            Buffer.BlockCopy((Array) object_0, 2, dst, 0, 2);
        }
        else if (class2.method_6() == 0x7f)
        {
            dst = new byte[8];
            if (int_0 < 10)
            {
                return null;
            }
            Buffer.BlockCopy((Array) object_0, 2, dst, 0, 8);
        }
        if (class2.method_5())
        {
            buffer = new byte[4];
            if (int_0 < (dst.Length + 6))
            {
                return null;
            }
            Buffer.BlockCopy((Array) object_0, dst.Length + 2, buffer, 0, 4);
        }
        if (dst.Length == 0)
        {
            if (int_0 < (((dst.Length + buffer.Length) + 2) + class2.method_6()))
            {
                return null;
            }
            buffer3 = new byte[class2.method_6()];
            Buffer.BlockCopy((Array) object_0, (dst.Length + buffer.Length) + 2, buffer3, 0, buffer3.Length);
        }
        else if (dst.Length == 2)
        {
            int num = (dst[0] * 0x100) + dst[1];
            if (int_0 < (((dst.Length + buffer.Length) + 2) + num))
            {
                return null;
            }
            buffer3 = new byte[num];
            Buffer.BlockCopy((Array) object_0, (dst.Length + buffer.Length) + 2, buffer3, 0, buffer3.Length);
        }
        else
        {
            long num2 = 0L;
            int num4 = 1;
            for (int i = 7; i >= 0; i--)
            {
                num2 += dst[i] * num4;
                num4 *= 0x100;
            }
            if (int_0 < (((dst.Length + buffer.Length) + 2) + ((int) num2)))
            {
                return null;
            }
            buffer3 = new byte[num2];
            Buffer.BlockCopy((Array) object_0, (dst.Length + buffer.Length) + 2, buffer3, 0, buffer3.Length);
        }
        if (class2.method_5())
        {
            buffer3 = smethod_1(buffer3, buffer);
        }
        int_1 = ((dst.Length + buffer.Length) + 2) + buffer3.Length;
        return new Class12(class2, dst, buffer, buffer3);
    }

    private static byte[] smethod_1(byte[] byte_3, byte[] object_0)
    {
        for (int i = 0; i < byte_3.Length; i++)
        {
            byte_3[i] ^= object_0[i % 4];
        }
        return byte_3;
    }

    private static byte[] smethod_2(Array array_0, int int_0, int int_1)
    {
        byte[] dst = new byte[int_1];
        Buffer.BlockCopy(array_0, int_0, dst, 0, int_1);
        return dst;
    }

    internal Class11 Header
    {
        get
        {
            return this.class11_0;
        }
    }
}

