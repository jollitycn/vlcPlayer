using System;
using System.Text;

internal class Class84 : Interface10
{
    private static Class84 lJyolYquvc = new Class84();

    private Class84()
    {
    }

    public string imethod_8(byte[] byte_0, int int_0, int int_1)
    {
        if (byte_0 == null)
        {
            return null;
        }
        return Encoding.UTF8.GetString(byte_0, int_0, int_1);
    }

    public byte[] imethod_9(string string_0)
    {
        if (string_0 == null)
        {
            return new byte[0];
        }
        return Encoding.UTF8.GetBytes(string_0);
    }

    public static Interface10 smethod_0()
    {
        return lJyolYquvc;
    }
}

