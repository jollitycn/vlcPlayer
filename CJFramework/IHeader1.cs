using System;

internal class IHeader1
{
    private byte byte_0 = 2;
    private byte byte_1 = 0;
    private ushort ushort_0 = 0;

    public IHeader1(byte byte_2, byte byte_3, ushort ushort_1)
    {
        this.byte_0 = byte_2;
        this.byte_1 = byte_3;
        this.ushort_0 = ushort_1;
    }

    public byte method_0()
    {
        return this.byte_0;
    }

    public void method_1(byte byte_2)
    {
        this.byte_0 = byte_2;
    }

    public byte method_2()
    {
        return this.byte_1;
    }

    public void method_3(byte byte_2)
    {
        this.byte_1 = byte_2;
    }

    public ushort method_4()
    {
        return this.ushort_0;
    }

    public void method_5(ushort ushort_1)
    {
        this.ushort_0 = ushort_1;
    }

    public void method_6(byte[] byte_2)
    {
        byte[] bytes = BitConverter.GetBytes(this.ushort_0);
        byte_2[0] = this.byte_0;
        byte_2[1] = this.byte_1;
        byte_2[2] = bytes[0];
        byte_2[3] = bytes[1];
    }

    public static IHeader1 smethod_0(byte[] byte_2)
    {
        if (byte_2.Length < 4)
        {
            return null;
        }
        byte num = byte_2[0];
        byte num2 = byte_2[1];
        ushort num3 = BitConverter.ToUInt16(byte_2, 2);
        if ((num3 + 4) > byte_2.Length)
        {
            return null;
        }
        return new IHeader1(num, num2, num3);
    }
}

