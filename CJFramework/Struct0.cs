using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
internal struct Struct0
{
    internal int int_0;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
    internal byte[] byte_0;
    internal int int_1;
    internal int int_2;
}

