using CJBasic;
using System;

internal class DataFragmentBody : IBody
{
    private DataBuffer dataBuffer_0;
    private DataFragmentType enum8_0 = ((DataFragmentType) 0);
    public static int int_0 = 12;
    private ulong YftnfpjycP;

    public DataFragmentBody(ulong ulong_0, DataBuffer dataBuffer_1, DataFragmentType enum8_1)
    {
        this.YftnfpjycP = ulong_0;
        this.dataBuffer_0 = dataBuffer_1;
        this.enum8_0 = enum8_1;
    }

    public ulong method_0()
    {
        return this.YftnfpjycP;
    }

    public DataFragmentType GetDataFragmentType()
    {
        return this.enum8_0;
    }

    public DataBuffer method_2()
    {
        return this.dataBuffer_0;
    }

    public static DataFragmentBody smethod_0(byte[] byte_0, int int_1, int int_2)
    {
        ulong num = BitConverter.ToUInt64(byte_0, int_1);
        DataFragmentType enum2 = (DataFragmentType) byte_0[int_1 + 8];
        return new DataFragmentBody(num, new DataBuffer(byte_0, int_1 + 12, int_2 - 12), enum2);
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        Buffer.BlockCopy(BitConverter.GetBytes(this.YftnfpjycP), 0, stream, startIndex, 8);
        stream[startIndex + 8] = (byte) this.enum8_0;
        Buffer.BlockCopy(this.dataBuffer_0.Data, this.dataBuffer_0.Offset, stream, startIndex + 12, this.dataBuffer_0.Length);
    }

    public int BodyTotalLength
    {
        get
        {
            return (this.dataBuffer_0.Length + int_0);
        }
    }
}

