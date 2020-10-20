using CJBasic;
using CJBasic.Helpers;
using CJBasic.Loggers;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

internal class Class134
{
    private bool bool_0 = false;
    private static Class134 class134_0 = new Class134();
    private Enum3 enum3_0 = ((Enum3) 0);
    private IAgileLogger iagileLogger_0;
    internal object object_0 = 1;
    private string string_0 = "9d6732b1e26b9fd6";
    internal string string_1 = "elinkshop";
    internal string string_2 = "82f3dd89b9c4187631b258b15842f5";
    internal string string_3 = "19-1-1";

    private Class134()
    {
    }

    private bool ElVcbBfDex(Assembly assembly_0, string string_4)
    {
        string str = null;
        string[] strArray = assembly_0.FullName.Split(new char[] { ',' });
        string str2 = "PublicKeyToken=";
        foreach (string str4 in strArray)
        {
            string str3 = str4.Trim();
            if (str3.StartsWith(str2))
            {
                str = str3.Substring(str2.Length);
                break;
            }
        }
        return (str == string_4);
    }

    private bool mbmcEasTlf(string string_4, string string_5, string string_6)
    {
        try
        {
            X509Certificate certificate = X509Certificate.CreateFromSignedFile(string_4);
            if (certificate == null)
            {
                return false;
            }
            X509Certificate2 certificate2 = new X509Certificate2(certificate);
            return ((certificate2.SerialNumber == string_5) && (certificate2.GetPublicKeyString() == string_6));
        }
        catch (Exception)
        {
            return false;
        }
    }

    private void method_0()
    {
        Thread.Sleep(0x15f90);
        string str = " This is unauthorized user ! please contact to www.jollitycn.com . Error type is ";
        if (this.bool_0)
        {
            this.object_0 = !MachineHelper.IsGreater(this.string_3);
            if (this.object_0 == null)
            {
                this.iagileLogger_0.LogWithTime(str + "EC102");
                return;
            }
        }
        try
        {
            this.object_0 = this.method_2("http://59.175.145.163/AuthorizeService.asmx");
        }
        catch
        {
            try
            {
                this.object_0 = this.method_2("http://ws.oraycn.com/AuthorizeService.asmx");
            }
            catch
            {
            }
        }
        if (this.object_0 == null)
        {
            this.iagileLogger_0.LogWithTime(str + "EC103");
        }
        else if (this.enum3_0 == ((Enum3) 1))
        {
            this.object_0 = this.method_1(this.string_0);
            if (this.object_0 == null)
            {
                this.iagileLogger_0.LogWithTime(str + "EC104");
            }
        }
    }

    private bool method_1(string string_4)
    {
        if (this.string_1 == "yonyou")
        {
            foreach (Assembly assembly2 in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (this.ElVcbBfDex(assembly2, string_4))
                {
                    return true;
                }
            }
            string str = "2CA197DFBE665B60223DB9BBC6800642";
            string str2 = "3082010A0282010100BAA16283472AA5BE2D0B4D642D2D54297CAE42456F8EF15F592AE44293F7F882C0D47ADA7C81D1DD270D20948F050A8F8A13FEDE37589A4197A50678116935CB4422126F04313368599E69D29AADB845340DA8A22D233572D79A8AD9DA0F90BDD9C675C0D11B897D78186B30275FC94E4CC2C2D509B6CB8E08F105FAC967C29C696B57146033D7C043633BE20CCCA7ABE053EDA4CE58AFC61669E758D056AF21443E5F2795DE0C69331AA9756F31A3335FC6D03FDF2AE4CC3249FB26143ED9420E85A11AF9B8B77E07D39B8E0D56BDC021E0802CE8843535066221D334188C8FAE33EE580160BC90413A08C8A378E3342310C8170D6140A13A80114C50B0ED710203010001";
            foreach (string str3 in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (this.mbmcEasTlf(str3, str, str2))
                {
                    return true;
                }
            }
            return false;
        }
        Assembly entryAssembly = Assembly.GetEntryAssembly();
        return this.ElVcbBfDex(entryAssembly, string_4);
    }

    private bool method_2(string string_4)
    {
        return (bool) Class92.smethod_0(string_4, "AllowStartNewInstance", new object[] { Platform.string_0, this.string_1 });
    }

    private DateTime method_3()
    {
        DateTime now = DateTime.Now;
        try
        {
            now = (DateTime) Class92.smethod_0("http://59.175.145.163/AuthorizeService.asmx", "GetTime", null);
        }
        catch (Exception)
        {
        }
        return now;
    }

    internal static Class134 smethod_0()
    {
        return class134_0;
    }

    internal void WfJlzZyoUa(bool bool_1, IAgileLogger iagileLogger_1)
    {
        if (!bool_1)
        {
            this.iagileLogger_0 = iagileLogger_1;
            new CbGeneric(this.method_0).BeginInvoke(null, null);
        }
    }
}

