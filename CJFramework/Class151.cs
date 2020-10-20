using System;

internal class Class151 : IBody
{
    private byte[] object_0;

    public Class151(byte[] byte_0)
    {
        this.object_0 = byte_0;
    }

    public byte[] method_0()
    {
        return (byte[]) this.object_0;
    }

    public static Class151 smethod_0(Array array_0, int int_0)
    {
        byte[] dst = new byte[array_0.Length - int_0];
        Buffer.BlockCopy(array_0, int_0, dst, 0, dst.Length);
        return new Class151(dst);
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        Buffer.BlockCopy((Array) this.object_0, 0, stream, startIndex, this.object_0.Length);
    }

    public int BodyTotalLength
    {
        get
        {
            return this.object_0.Length;
        }
    }
}

