using System;

internal class Class154 : IBody
{
    private byte[] byte_0;

    public Class154(ushort ushort_0)
    {
        this.byte_0 = new byte[ushort_0];
    }

    public byte[] method_0()
    {
        return this.byte_0;
    }

    public static Class154 smethod_0(byte[] object_0, int int_0, int int_1)
    {
        return new Class154((ushort) (object_0.Length - int_0));
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        Buffer.BlockCopy(this.byte_0, 0, stream, startIndex, this.byte_0.Length);
    }

    public int BodyTotalLength
    {
        get
        {
            return this.byte_0.Length;
        }
    }
}

