using System;
using System.Runtime.InteropServices;

internal class ContinueTransFile
{
    private int int_0 = 2;
    private int int_1 = 8;
    private int int_2 = 0x20;
    private int int_3 = 0;
    private int int_4 = 1;
    private int int_5 = 2;
    private int int_6 = 4;
    private int int_7 = 8;
    private int int_8 = 0x10;
    private string string_0 = "SeShutdownPrivilege";

    [DllImport("advapi32.dll", SetLastError=true, ExactSpelling=true)]
    private static extern bool AdjustTokenPrivileges(IntPtr intptr_0, bool bool_0, ref Struct2 struct2_0, int int_9, IntPtr intptr_1, IntPtr intptr_2);
    [DllImport("user32.dll", SetLastError=true, ExactSpelling=true)]
    private static extern bool ExitWindowsEx(int int_9, int int_10);
    [DllImport("kernel32.dll", ExactSpelling=true)]
    private static extern IntPtr GetCurrentProcess();
    [DllImport("advapi32.dll", SetLastError=true)]
    private static extern bool LookupPrivilegeValue(string string_1, string string_2, ref long long_0);
    public void method_0()
    {
        Struct2 struct2;
        IntPtr currentProcess = GetCurrentProcess();
        IntPtr zero = IntPtr.Zero;
        OpenProcessToken(currentProcess, this.int_2 | this.int_1, ref zero);
        struct2.int_0 = 1;
        struct2.long_0 = 0L;
        struct2.PgOkjylUi3 = this.int_0;
        LookupPrivilegeValue(null, this.string_0, ref struct2.long_0);
        AdjustTokenPrivileges(zero, false, ref struct2, 0, IntPtr.Zero, IntPtr.Zero);
        ExitWindowsEx(this.int_7 | this.int_6, 0);
    }

    [DllImport("advapi32.dll", SetLastError=true, ExactSpelling=true)]
    private static extern bool OpenProcessToken(IntPtr intptr_0, int int_9, ref IntPtr intptr_1);

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Struct2
    {
        public int int_0;
        public long long_0;
        public int PgOkjylUi3;
    }
}

