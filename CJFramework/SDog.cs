using System;
using System.Runtime.InteropServices;

internal class SDog
{
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_change_passwd(IntPtr intptr_0, int int_0, byte[] byte_0, byte[] byte_1);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_close(IntPtr intptr_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_decrypt(IntPtr intptr_0, byte[] byte_0, byte[] byte_1);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_encrypt(IntPtr intptr_0, byte[] byte_0, byte[] byte_1);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_get_hardware_info(IntPtr intptr_0, ref Struct0 struct0_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_get_software_info(ref Struct1 struct1_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_hmac(IntPtr intptr_0, byte[] byte_0, int int_0, byte[] byte_1);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_hmac_software(byte[] byte_0, int int_0, byte[] byte_1, byte[] byte_2);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_open(int int_0, int int_1, ref IntPtr intptr_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_passwd(IntPtr intptr_0, int int_0, byte[] byte_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_read(IntPtr intptr_0, int int_0, byte[] byte_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_set_key(IntPtr intptr_0, int int_0, byte[] byte_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_set_passwd(IntPtr intptr_0, int int_0, byte[] byte_0, int int_1);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_update(IntPtr intptr_0, byte[] byte_0);
    [DllImport("sdog.dll", CallingConvention=CallingConvention.Cdecl)]
    internal static extern int LIV_write(IntPtr intptr_0, int int_0, byte[] byte_0);
}

