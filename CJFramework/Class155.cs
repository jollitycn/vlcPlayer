using System;

internal class Class155 : IBody
{
    private int int_0;

    public Class155(int int_1)
    {
        this.int_0 = int_1;
    }

    public int method_0()
    {
        return this.int_0;
    }

    public static Class155 smethod_0(byte[] byte_0, int int_1, int int_2)
    {
        return new Class155(BitConverter.ToInt32(byte_0, int_1));
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_0), 0, stream, startIndex, 4);
    }

    public int BodyTotalLength
    {
        get
        {
            return 4;
        }
    }
}

