using CJBasic.Security;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

internal class AuthorizeTool
{
    internal bool bool_0 = true;
    internal static bool bool_1 = false;
    private bool bool_2 = false;
    private static AuthorizeTool class87_0 = new AuthorizeTool();
    private DateTime dateTime_0 = DateTime.Parse("2019-01-01 00:00:00");
    private Enum3 enum3_0 = ((Enum3) 0);
    internal int int_0 = 0x7fffffff;
    private string string_0 = "5851cfd3b57cff1a";
    internal string string_1 = "elinkshop";
    internal string string_2 = "82f3dd89b9c4187631b258b15842f5";

    private AuthorizeTool()
    {
    }

    internal string Authorize()
    {
        if (this.string_1 != Class62.string_0)
        {
            return "100";
        }
        if (SecurityHelper.MD5String(Class62.string_1) != this.string_2)
        {
            return "101";
        }
        if (this.bool_2 && (DateTime.Now > this.dateTime_0))
        {
            return "102";
        }
        Enum5 enum2 = this.method_4();
        if (enum2 != ((Enum5) 0))
        {
            return ("106 - " + Class120.smethod_1(enum2));
        }
        if (this.bool_0)
        {
            bool flag = true;
            try
            {
                flag = this.AllowStartNewInstance("http://59.175.145.163/AuthorizeService.asmx");
            }
            catch
            {
                try
                {
                    flag = this.AllowStartNewInstance("http://ws.oraycn.com/AuthorizeService.asmx");
                }
                catch
                {
                }
            }
            if (!flag)
            {
                return "103";
            }
        }
        if ((this.enum3_0 == ((Enum3) 1)) && !this.CheckToken(this.string_0))
        {
            return "104";
        }
        return null;
    }

    internal bool CheckToken(string string_3)
    {
        if (this.string_1 == "yonyou")
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (this.CheckToken(assembly, string_3))
                {
                    return true;
                }
            }
            string str = "2CA197DFBE665B60223DB9BBC6800642";
            string str2 = "3082010A0282010100BAA16283472AA5BE2D0B4D642D2D54297CAE42456F8EF15F592AE44293F7F882C0D47ADA7C81D1DD270D20948F050A8F8A13FEDE37589A4197A50678116935CB4422126F04313368599E69D29AADB845340DA8A22D233572D79A8AD9DA0F90BDD9C675C0D11B897D78186B30275FC94E4CC2C2D509B6CB8E08F105FAC967C29C696B57146033D7C043633BE20CCCA7ABE053EDA4CE58AFC61669E758D056AF21443E5F2795DE0C69331AA9756F31A3335FC6D03FDF2AE4CC3249FB26143ED9420E85A11AF9B8B77E07D39B8E0D56BDC021E0802CE8843535066221D334188C8FAE33EE580160BC90413A08C8A378E3342310C8170D6140A13A80114C50B0ED710203010001";
            foreach (string str3 in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (this.method_2(str3, str, str2))
                {
                    return true;
                }
            }
            return false;
        }
        Assembly entryAssembly = Assembly.GetEntryAssembly();
        return this.CheckToken(entryAssembly, string_3);
    }

    private bool method_2(string string_3, string string_4, string string_5)
    {
        try
        {
            X509Certificate certificate = X509Certificate.CreateFromSignedFile(string_3);
            if (certificate == null)
            {
                return false;
            }
            X509Certificate2 certificate2 = new X509Certificate2(certificate);
            return ((certificate2.SerialNumber == string_4) && (certificate2.GetPublicKeyString() == string_5));
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool CheckToken(Assembly assembly_0, string string_3)
    {
        string str = null;
        string[] strArray = assembly_0.FullName.Split(new char[] { ',' });
        string str2 = "PublicKeyToken=";
        foreach (string str3 in strArray)
        {
            string str4 = str3.Trim();
            if (str4.StartsWith(str2))
            {
                str = str4.Substring(str2.Length);
                break;
            }
        }
        return (str == string_3);
    }

    private Enum5 method_4()
    {
        try
        {
            if (bool_1)
            {
                Class120 class2 = Class120.smethod_0(Class62.string_2);
                if (!Class118.smethod_0(class2.string_0))
                {
                    return (Enum5) 2;
                }
                DateTime time = class2.method_0();
                if (DateTime.Now > time)
                {
                    return (Enum5) 3;
                }
            }
            return (Enum5) 0;
        }
        catch
        {
            return (Enum5) 1;
        }
    }

    public bool method_5()
    {
        return (this.bool_2 && (DateTime.Now > this.dateTime_0));
    }

    internal static AuthorizeTool smethod_0()
    {
        return class87_0;
    }

    private bool AllowStartNewInstance(string string_3)
    {
        return (bool) Class92.smethod_0(string_3, "AllowStartNewInstance", new object[] { Platform.string_0, this.string_1 });
    }
}

