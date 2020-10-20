using System;

internal class Platform
{
    internal static string string_0 = "CJFramework";

    public static void SetPlatform(string string_1)
    {
        string_0 = string_1;
    }

    public static int GetPlatform()
    {
        if ((string_0 != "CJFramework") && (string_0 == "CJPlatform"))
        {
            return 3;
        }
        return 0;
    }
}

