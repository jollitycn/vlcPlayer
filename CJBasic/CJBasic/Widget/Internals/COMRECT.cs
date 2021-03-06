﻿namespace CJBasic.Widget.Internals
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class COMRECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public COMRECT()
        {
        }

        public COMRECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public static COMRECT FromXYWH(int x, int y, int width, int height)
        {
            return new COMRECT(x, y, x + width, y + height);
        }
    }
}

