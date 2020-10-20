using System;

internal class Class52
{
    public byte[] byte_0;
    public int int_0;
    public int int_1;
    public int int_2;
    public int int_3;
    public int int_4;
    public int int_5;
    public int int_6;
    public int int_7;

    public Class52()
    {
        DateTime now = DateTime.Now;
        this.int_0 = now.Year;
        this.int_1 = now.Month;
        this.int_2 = now.Day;
        this.int_3 = now.Hour;
        this.int_4 = now.Minute;
        this.int_5 = now.Second;
    }

    public byte[] method_0()
    {
        byte[] dst = new byte[0x20 + this.byte_0.Length];
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_0), 0, dst, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_1), 0, dst, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_2), 0, dst, 8, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_3), 0, dst, 12, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_4), 0, dst, 0x10, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_5), 0, dst, 20, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_6), 0, dst, 0x18, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_7), 0, dst, 0x1c, 4);
        Buffer.BlockCopy(this.byte_0, 0, dst, 0x20, this.byte_0.Length);
        return dst;
    }

    public static Class52 smethod_0(object object_0, int int_8)
    {
        int startIndex = int_8;
        Class52 class2 = new Class52 {
            int_0 = BitConverter.ToInt32((byte[]) object_0, startIndex)
        };
        startIndex += 4;
        class2.int_1 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_2 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_3 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_4 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_5 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_6 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.int_7 = BitConverter.ToInt32((byte[]) object_0, startIndex);
        startIndex += 4;
        class2.byte_0 = new byte[class2.int_7];
        Buffer.BlockCopy((Array) object_0, startIndex, class2.byte_0, 0, class2.int_7);
        startIndex += class2.int_7;
        return class2;
    }
}

