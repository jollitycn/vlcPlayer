using CJFramework;
using System;

internal static class Class62
{
    internal static string string_0 = "FreeUser";
    internal static string string_1 = "";
    internal static string string_2 = null;
    internal static string string_3 = "127.0.0.1";
    private static VersionType versionType_0 = VersionType.Professional;

    public static void lnSukhqmte(string string_4)
    {
        string_3 = string_4;
    }

    public static void SetAuthorizedUser(string string_4, string string_5)
    {
        string_0 = string_4;
        string_1 = string_5;
    }

    public static VersionType GetVersionType()
    {
        return versionType_0;
    }

    public static void SetStartCode(string string_4)
    {
        string_2 = string_4;
    }

    public static string FreeUser
    {
        get
        {
            return "FreeUser";
        }
    }
}

