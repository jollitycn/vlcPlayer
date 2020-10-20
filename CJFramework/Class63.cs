using CJBasic.Helpers;
using CJFramework;
using System;
using System.Collections.Generic;

internal static class Class63
{
    internal static int int_0 = 0;
    internal static string string_0 = "";
    internal static string string_1 = "";
    internal static string string_2 = "";

    static Class63()
    {
        try
        {
            int_0 = new Random().Next(0xf4240, 0x4c4b40);
            IList<string> macAddress = MachineHelper.GetMacAddress();
            if ((macAddress != null) && (macAddress.Count > 0))
            {
                string_1 = macAddress[0];
            }
            string_0 = NetworkHelper.GetFirstIP();
            if (string_0 == null)
            {
                string_0 = NetworkHelper.GetFirstIP();
            }
            string_2 = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
        }
        catch (Exception exception)
        {
            exception = exception;
        }
    }
}

