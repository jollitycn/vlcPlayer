using System;

internal class Class54
{
    public byte[] byte_0;
    public int int_0;
    public int int_1;
    public int int_2;
    public int int_3;
    public int int_4;
    public int int_5;

    public byte[] method_0()
    {
        byte[] dst = new byte[40];
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_0), 0, dst, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_1), 0, dst, 4, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_2), 0, dst, 8, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_3), 0, dst, 12, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_4), 0, dst, 0x10, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(this.int_5), 0, dst, 20, 4);
        Buffer.BlockCopy(this.byte_0, 0, dst, 0x18, this.byte_0.Length);
        return dst;
    }

    public static Class54 smethod_0(object object_0, int int_6)
    {
        int startIndex = int_6;
        Class54 class2 = new Class54 {
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
        class2.byte_0 = new byte[class2.int_5];
        Buffer.BlockCopy((Array) object_0, startIndex, class2.byte_0, 0, class2.int_5);
        startIndex += class2.int_5;
        return class2;
    }
}

