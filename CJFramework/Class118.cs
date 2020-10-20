using CJBasic.Security;
using System;
using System.Management;

internal class Class118
{
    public static bool smethod_0(string string_0)
    {
        try
        {
            string str = smethod_1();
            string str2 = smethod_2();
            if (str.Length < 8)
            {
                str = "ABCDEFGHK";
            }
            if (str2.Length < 8)
            {
                str2 = "88:53:2E:11:AB:ED";
            }
            string str3 = "";
            return (SecurityHelper.MD5String((((str3 + str[str.Length / 3]) + str[(str.Length * 2) / 3] + str[str.Length - 2]) + "-" + str2[6]) + str2[str2.Length - 2] + str2[3]) == string_0);
        }
        catch
        {
            return false;
        }
    }

    private static string smethod_1()
    {
        try
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            string str = null;
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = searcher.Get().GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    ManagementObject current = (ManagementObject) enumerator.Current;
                    str = current["SerialNumber"].ToString().Trim();
                }
            }
            return str;
        }
        catch
        {
            return "";
        }
    }

    private static string smethod_2()
    {
        try
        {
            string str = "";
            ManagementClass class2 = new ManagementClass("Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                if ((bool) obj2["IPEnabled"])
                {
                    str = str + obj2["MACAddress"].ToString();
                }
            }
            return str;
        }
        catch
        {
            return "";
        }
    }
}

