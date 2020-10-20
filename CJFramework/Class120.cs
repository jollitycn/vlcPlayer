using CJBasic.Security;
using System;
using System.Text;

internal class Class120
{
    public string string_0;
    public string string_1;

    public Class120()
    {
    }

    public Class120(string string_2, string string_3)
    {
        this.string_0 = string_2;
        this.string_1 = string_3;
    }

    public DateTime method_0()
    {
        return DateTime.Parse(string.Format("{0}-{1}-{2}", this.string_1.Substring(0, 4), this.string_1.Substring(4, 2), this.string_1.Substring(6, 2))).AddDays(1.0);
    }

    public static Class120 smethod_0(string string_2)
    {
        byte[] encrypted = Convert.FromBase64String(string_2);
        byte[] bytes = new DesEncryption(DesStrategy.Des3, "LoveOraycn").Decrypt(encrypted);
        string[] strArray = Encoding.UTF8.GetString(bytes).Split(new char[] { '-' });
        return new Class120(strArray[0], strArray[1]);
    }

    public static string smethod_1(Enum5 enum5_0)
    {
        if (enum5_0 == ((Enum5) 0))
        {
            return "Succeed";
        }
        if (enum5_0 == ((Enum5) 1))
        {
            return "ParseFail";
        }
        if (enum5_0 == ((Enum5) 2))
        {
            return "ErrorSN";
        }
        if (enum5_0 == ((Enum5) 3))
        {
            return "Expired";
        }
        return "";
    }
}

