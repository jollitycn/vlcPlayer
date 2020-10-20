namespace CJBasic.Widget
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class SystemIconShell
    {
        private static uint FILE_ATTRIBUTE_NORMAL = 0x80;
        private static uint LVM_FIRST = 0x1000;
        private static uint LVM_SETIMAGELIST = (LVM_FIRST + 3);
        private static uint LVSIL_NORMAL = 0;
        private static uint LVSIL_SMALL = 1;
        private static uint SHGFI_ATTRIBUTES = 0x800;
        private static uint SHGFI_DISPLAYNAME = 0x200;
        private static uint SHGFI_EXETYPE = 0x2000;
        private static uint SHGFI_ICON = 0x100;
        private static uint SHGFI_ICONLOCATION = 0x1000;
        private static uint SHGFI_LARGEICON = 0;
        private static uint SHGFI_LINKOVERLAY = 0x8000;
        private static uint SHGFI_OPENICON = 2;
        private static uint SHGFI_PIDL = 8;
        private static uint SHGFI_SELECTED = 0x10000;
        private static uint SHGFI_SHELLICONSIZE = 4;
        private static uint SHGFI_SMALLICON = 1;
        private static uint SHGFI_SYSICONINDEX = 0x4000;
        private static uint SHGFI_TYPENAME = 0x400;
        private static uint SHGFI_USEFILEATTRIBUTES = 0x10;

        public static int FileIconIndex(string filePath)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            SHGetFileInfo(filePath, 0, ref psfi, Marshal.SizeOf(psfi), SHGFI_SYSICONINDEX);
            return psfi.iIcon;
        }

        public static void ListViewSysImages(ListView AListView)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            IntPtr lParam = SHGetFileInfo("", 0, ref psfi, Marshal.SizeOf(psfi), (SHGFI_SHELLICONSIZE | SHGFI_SYSICONINDEX) | SHGFI_LARGEICON);
            SendMessage(AListView.Handle, LVM_SETIMAGELIST, (IntPtr) LVSIL_NORMAL, lParam);
            lParam = SHGetFileInfo("", 0, ref psfi, Marshal.SizeOf(psfi), (SHGFI_SHELLICONSIZE | SHGFI_SYSICONINDEX) | SHGFI_SMALLICON);
            SendMessage(AListView.Handle, LVM_SETIMAGELIST, (IntPtr) LVSIL_SMALL, lParam);
        }

        [DllImport("User32.DLL")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbfileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            public string szDisplayName;
            public string szTypeName;
        }
    }
}

