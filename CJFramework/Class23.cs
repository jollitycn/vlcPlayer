using System;
using System.Threading;

internal static class Class23
{
    private static int int_0 = 0;
    private static Random random_0 = new Random();

    public static string smethod_0(string string_0)
    {
        Interlocked.Increment(ref int_0);
        return (string_0 + "_" + int_0.ToString());
    }
}

