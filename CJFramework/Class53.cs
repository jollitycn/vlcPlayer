using System;

internal class Class53
{
    public int int_0;
    public int int_1;
    public int int_10;
    public int int_2;
    public int int_3;
    public int int_4;
    public int int_5;
    public int int_6;
    public int int_7;
    public int int_8;
    public int int_9;

    public Class53()
    {
        DateTime now = DateTime.Now;
        this.int_1 = now.Month;
        this.int_2 = now.Day;
        this.int_3 = now.Hour;
        this.int_4 = now.Minute;
        this.int_5 = now.Second;
    }

    public byte[] method_0()
    {
        byte[] dst = new byte[0x2c];
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_0), 0, dst, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_1), 0, dst, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_2), 0, dst, 8, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_3), 0, dst, 12, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_4), 0, dst, 0x10, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_5), 0, dst, 20, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_6), 0, dst, 0x18, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_7), 0, dst, 0x1c, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_8), 0, dst, 0x20, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_9), 0, dst, 0x24, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_10), 0, dst, 40, 4);
        return dst;
    }

    public static Class53 smethod_0(byte[] byte_0, int int_11)
    {
        int startIndex = int_11;
        Class53 class2 = new Class53 {
            int_0 = BitConverter.ToInt32(byte_0, startIndex)
        };
        startIndex += 4;
        class2.int_1 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_2 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_3 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_4 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_5 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_6 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_7 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_8 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        class2.int_9 = BitConverter.ToInt32(byte_0, startIndex);
        startIndex += 4;
        return class2;
    }
}

