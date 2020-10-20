using System;

internal class Class153 : IBody
{
    private DateTime dateTime_0;
    private int int_0;
    private uint uint_0;
    private ulong ulong_0;
    private ulong ulong_1;

    public Class153()
    {
        this.dateTime_0 = DateTime.Now;
        this.ulong_0 = 0L;
        this.uint_0 = 0;
        this.int_0 = 0;
    }

    public Class153(DateTime dateTime_1, ulong ulong_2, ulong ulong_3, uint uint_1, int int_1)
    {
        this.dateTime_0 = DateTime.Now;
        this.ulong_0 = 0L;
        this.uint_0 = 0;
        this.int_0 = 0;
        this.dateTime_0 = dateTime_1;
        this.ulong_0 = ulong_2;
        this.ulong_1 = ulong_3;
        this.uint_0 = uint_1;
        this.int_0 = int_1;
    }

    public DateTime BeMngkPph6()
    {
        return this.dateTime_0;
    }

    public ulong method_0()
    {
        return this.ulong_0;
    }

    public ulong method_1()
    {
        return this.ulong_1;
    }

    public uint method_2()
    {
        return this.uint_0;
    }

    public int method_3()
    {
        return this.int_0;
    }

    public static Class153 smethod_0(byte[] byte_0, int int_1, int int_2)
    {
        double num = BitConverter.ToDouble(byte_0, int_1);
        DateTime time2 = DateTime.Parse("2010-01-01 00:00:00").AddMilliseconds(num);
        ulong num2 = BitConverter.ToUInt64(byte_0, int_1 + 8);
        ulong num3 = BitConverter.ToUInt64(byte_0, int_1 + 0x10);
        uint num4 = BitConverter.ToUInt32(byte_0, int_1 + 0x18);
        return new Class153(time2, num2, num3, num4, BitConverter.ToInt32(byte_0, int_1 + 0x1c));
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        TimeSpan span = (TimeSpan) (this.dateTime_0 - DateTime.Parse("2010-01-01 00:00:00"));
        Buffer.BlockCopy(BitConverter.GetBytes(span.TotalMilliseconds), 0, stream, startIndex, 8);
        Buffer.BlockCopy(BitConverter.GetBytes(this.ulong_0), 0, stream, startIndex + 8, 8);
        Buffer.BlockCopy(BitConverter.GetBytes(this.ulong_1), 0, stream, startIndex + 0x10, 8);
        Buffer.BlockCopy(BitConverter.GetBytes(this.uint_0), 0, stream, startIndex + 0x18, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_0), 0, stream, startIndex + 0x1c, 4);
    }

    public int BodyTotalLength
    {
        get
        {
            return 0x20;
        }
    }
}

