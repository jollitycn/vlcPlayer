using System;
using System.Runtime.InteropServices;
using System.Text;

internal class Class44
{
    internal static int int_0 = 0x2712;

    internal static bool smethod_0(string string_0, out string string_1)
    {
        if ((Platform.string_0 == "CJPlatform") && (string_0 == "bjguoyao_ESF"))
        {
            string_0 = "bjguoyao_ESP";
        }
        return smethod_1(string_0, out string_1);
    }

    internal static bool smethod_1(string string_0, out string string_1)
    {
        string_1 = "";
        for (int i = 0; i < 3; i++)
        {
            string str = "";
            if (smethod_2(i, string_0, out str))
            {
                return true;
            }
            if (i == 0)
            {
                string_1 = str;
            }
            else if (!str.Contains("FIND_DEVICE_FAILED"))
            {
                string_1 = str;
            }
        }
        return false;
    }

    private static bool smethod_2(int int_1, string string_0, out string string_1)
    {
        bool flag;
        string_1 = "";
        IntPtr zero = IntPtr.Zero;
        try
        {
            string s = "20110401";
            Enum2 sUCCESS = Enum2.SUCCESS;
            Struct1 struct2 = new Struct1();
            sUCCESS = (Enum2) SDog.LIV_get_software_info(ref struct2);
            sUCCESS = (Enum2) SDog.LIV_open(0, int_1, ref zero);
            if (sUCCESS != Enum2.SUCCESS)
            {
                throw new Exception("打开加密狗失败！ " + sUCCESS.ToString());
            }
            Struct0 struct3 = new Struct0();
            sUCCESS = (Enum2) SDog.LIV_get_hardware_info(zero, ref struct3);
            if (sUCCESS != Enum2.SUCCESS)
            {
                throw new Exception("获取加密狗信息失败！ " + sUCCESS.ToString());
            }
            if (SDog.LIV_passwd(zero, 1, Encoding.UTF8.GetBytes(s)) != 0)
            {
                throw new Exception("加密狗信息无法验证！ ");
            }
            byte[] buffer = new byte[0x200];
            if (SDog.LIV_read(zero, 0, buffer) != 0)
            {
                throw new Exception("从加密狗读取数据失败！ ");
            }
            string str2 = Encoding.UTF8.GetString(buffer);
            int index = str2.IndexOf('\0');
            str2 = str2.Substring(0, index);
            if (string_0 != str2.Trim())
            {
                throw new Exception("加密狗授权验证失败！ ");
            }
            flag = true;
        }
        catch (Exception exception)
        {
            string_1 = exception.Message;
            flag = false;
        }
        finally
        {
            try
            {
                SDog.LIV_close(zero);
            }
            catch
            {
            }
        }
        return flag;
    }
}

