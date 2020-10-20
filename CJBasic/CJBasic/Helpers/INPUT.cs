namespace CJBasic.Helpers
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(4)]
        public HARDWAREINPUT hi;
        [FieldOffset(4)]
        public KEYBDINPUT ki;
        [FieldOffset(4)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public int type;
    }
}

