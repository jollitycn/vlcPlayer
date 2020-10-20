using System;
using System.Text;

internal class StringBody : IBody
{
    private string string_0 = "";

    public StringBody(string string_1)
    {
        this.string_0 = string_1;
    }

    public string method_0()
    {
        return this.string_0;
    }

    public void method_1(string string_1)
    {
        this.string_0 = string_1;
    }

    public static StringBody smethod_0(byte[] byte_0, int int_0, int int_1)
    {
        if ((byte_0.Length - int_0) <= 0)
        {
            return new StringBody("");
        }
        return new StringBody(Encoding.UTF8.GetString(byte_0, int_0, byte_0.Length - int_0));
    }

    public void ToStream(byte[] stream, int startIndex)
    {
        if (!string.IsNullOrEmpty(this.string_0))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(this.string_0);
            Buffer.BlockCopy(bytes, 0, stream, startIndex, bytes.Length);
        }
    }

    public int BodyTotalLength
    {
        get
        {
            if (string.IsNullOrEmpty(this.string_0))
            {
                return 0;
            }
            return Encoding.UTF8.GetBytes(this.string_0).Length;
        }
    }
}

