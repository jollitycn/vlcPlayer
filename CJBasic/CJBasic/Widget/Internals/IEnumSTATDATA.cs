﻿namespace CJBasic.Widget.Internals
{
    using System;
    using System.Runtime.InteropServices;

    [Guid("00000105-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
    public interface IEnumSTATDATA
    {
        void Next([In, MarshalAs(UnmanagedType.U4)] int celt, [Out] STATDATA rgelt, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pceltFetched);
        void Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
        void Reset();
        void Clone([Out, MarshalAs(UnmanagedType.LPArray)] IEnumSTATDATA[] ppenum);
    }
}

