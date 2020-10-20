using System;
using System.Text;

internal class IPEndPointBody : IBody
{
    private int int_0;
    private string string_0;
    private string string_1;

    public IPEndPointBody(string string_2, string string_3, int int_1)
    {
        this.string_0 = string_2;
        this.string_1 = string_3;
        this.int_0 = int_1;
    }

    public string method_0()
    {
        return this.string_0;
    }

    public void method_1(string string_2)
    {
        this.string_0 = string_2;
    }

    public string method_2()
    {
        return this.string_1;
    }

    public void method_3(string string_2)
    {
        this.string_1 = string_2;
    }

    public int method_4()
    {
        return this.int_0;
    }

    public void method_5(int int_1)
    {
        this.int_0 = int_1;
    }

    public static IPEndPointBody smethod_0(byte[] byte_0, int int_1, int int_2)
    {
        int num = BitConverter.ToInt32(byte_0, int_1);
        int count = BitConverter.ToInt32(byte_0, int_1 + 4);
        string str = Encoding.UTF8.GetString(byte_0, int_1 + 8, count);
        int num3 = BitConverter.ToInt32(byte_0, (int_1 + 8) + count);
        return new IPEndPointBody(Encoding.UTF8.GetString(byte_0, ((int_1 + 8) + count) + 4, num3), str, num);
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        byte[] bytes = BitConverter.GetBytes(this.int_0);
        byte[] src = Encoding.UTF8.GetBytes(this.string_1);
        byte[] buffer3 = BitConverter.GetBytes(src.Length);
        byte[] buffer4 = Encoding.UTF8.GetBytes(this.string_0);
        byte[] buffer5 = BitConverter.GetBytes(buffer4.Length);
        Buffer.BlockCopy(bytes, 0, stream, startIndex, 4);
        Buffer.BlockCopy(buffer3, 0, stream, startIndex + 4, 4);
        Buffer.BlockCopy(src, 0, stream, startIndex + 8, src.Length);
        Buffer.BlockCopy(buffer5, 0, stream, (startIndex + 8) + src.Length, 4);
        Buffer.BlockCopy(buffer4, 0, stream, (startIndex + 12) + src.Length, buffer4.Length);
    }

    public int BodyTotalLength
    {
        get
        {
            byte[] bytes = Encoding.UTF8.GetBytes(this.string_1);
            byte[] buffer2 = Encoding.UTF8.GetBytes(this.string_0);
            return ((12 + bytes.Length) + buffer2.Length);
        }
    }
}

