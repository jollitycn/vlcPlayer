namespace CJBasic.Helpers
{
    using Microsoft.Win32;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class WindowsHelper
    {
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        public static Image CaptureScreenImage()
        {
            Size size = Screen.PrimaryScreen.Bounds.Size;
            IntPtr desktopWindow = GetDesktopWindow();
            IntPtr windowDC = GetWindowDC(desktopWindow);
            IntPtr hdc = CreateCompatibleDC(windowDC);
            IntPtr bmp = CreateCompatibleBitmap(windowDC, size.Width, size.Height);
            IntPtr ptr5 = SelectObject(hdc, bmp);
            bool flag = BitBlt(hdc, 0, 0, size.Width, size.Height, windowDC, 0, 0, CopyPixelOperation.CaptureBlt | CopyPixelOperation.SourceCopy);
            Bitmap bitmap = Image.FromHbitmap(bmp);
            SelectObject(hdc, ptr5);
            DeleteObject(bmp);
            DeleteDC(hdc);
            ReleaseDC(desktopWindow, windowDC);
            return bitmap;
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteObject(IntPtr hDc);
        public static void DoWindowsEvents()
        {
            Application.DoEvents();
        }

        public static void FlashWindow(Form form)
        {
            if (!((form.WindowState != FormWindowState.Minimized) && form.Focused))
            {
                FlashWindow(form.Handle, true);
            }
        }

        [DllImport("User32")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        public static Cursor GetCurrentCursor()
        {
            CursorInfo info;
            info.cbSize = Marshal.SizeOf(typeof(CursorInfo));
            GetCursorInfo(out info);
            return new Cursor(info.hCursor);
        }

        [DllImport("user32.dll")]
        internal static extern bool GetCursorInfo(out CursorInfo pci);
        public static Point GetCursorPosition()
        {
            return Cursor.Position;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        private static Icon GetIcon(string path, FILE_ATTRIBUTE dwAttr, SHGFI dwFlag)
        {
            SHFILEINFO sfi = new SHFILEINFO();
            int num = (int) SHGetFileInfo(path, dwAttr, ref sfi, 0, dwFlag);
            return Icon.FromHandle(sfi.hIcon);
        }

        public static Form GetMdiChildForm(Form parentForm, System.Type childFormType)
        {
            foreach (Form form in parentForm.MdiChildren)
            {
                if (form.GetType() == childFormType)
                {
                    return form;
                }
            }
            return null;
        }

        public static string GetStartupDirectoryPath()
        {
            return Application.StartupPath;
        }

        public static Icon GetSystemIconByFileType(string fileType, bool isLarge)
        {
            if (isLarge)
            {
                return GetIcon(fileType, FILE_ATTRIBUTE.NORMAL, SHGFI.ICON | SHGFI.USEFILEATTRIBUTES);
            }
            return GetIcon(fileType, FILE_ATTRIBUTE.NORMAL, SHGFI.ICON | SHGFI.SMALLICON | SHGFI.USEFILEATTRIBUTES);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr ptr);
        public static void KeybdEvent(byte key, byte bScan, KeybdEventFlag flags, uint dwExtraInfo)
        {
            CJBasic.Helpers.INPUT pInputs = new CJBasic.Helpers.INPUT();
            pInputs.type = 1;
            pInputs.ki.wVk = key;
            pInputs.ki.wScan = MapVirtualKey(key, 0);
            pInputs.ki.dwFlags = (int) flags;
            SendInput(1, ref pInputs, Marshal.SizeOf(pInputs));
        }

        [DllImport("user32.dll")]
        private static extern byte MapVirtualKey(byte wCode, int wMap);
        public static bool MdiChildIsExist(Form parentForm, System.Type childFormType)
        {
            return (GetMdiChildForm(parentForm, childFormType) != null);
        }

        [DllImport("user32.dll", EntryPoint="mouse_event")]
        public static extern void MouseEvent(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32.dll", EntryPoint="mouse_event")]
        public static extern void MouseEvent4Wheel(MouseEventFlag flags, int dx, int dy, int data, UIntPtr extraInfo);
        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        public static void RunWhenStart_usingReg(bool started, string name, string path)
        {
            RegistryKey localMachine = Registry.LocalMachine;
            try
            {
                RegistryKey key2 = localMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\");
                if (started)
                {
                    key2.SetValue(name, path);
                }
                else if (key2.GetValue(name) != null)
                {
                    key2.DeleteValue(name);
                }
            }
            finally
            {
                localMachine.Close();
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, ref CJBasic.Helpers.INPUT pInputs, int cbSize);
        [DllImport("user32.dll", EntryPoint="SetForegroundWindow")]
        private static extern bool SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        public static void SetForegroundWindow(Form window)
        {
            SetActiveWindow(window.Handle);
        }

        [DllImport("shell32", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern IntPtr SHGetFileInfo(string pszPath, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);
        public static bool ShowQuery(string query)
        {
            if (DialogResult.Yes != MessageBox.Show(query, "提示", MessageBoxButtons.YesNo))
            {
                return false;
            }
            return true;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct CursorInfo
        {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public WindowsHelper.POINT ptScreenPos;
        }

        [Flags]
        public enum FILE_ATTRIBUTE
        {
            ARCHIVE = 0x20,
            COMPRESSED = 0x800,
            DEVICE = 0x40,
            DIRECTORY = 0x10,
            ENCRYPTED = 0x4000,
            HIDDEN = 2,
            NORMAL = 0x80,
            NOT_CONTENT_INDEXED = 0x2000,
            OFFLINE = 0x1000,
            READONLY = 1,
            REPARSE_POINT = 0x400,
            SPARSE_FILE = 0x200,
            SYSTEM = 4,
            TEMPORARY = 0x100
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public string szTypeName;
        }

        [Flags]
        public enum SHGFI : uint
        {
            ADDOVERLAYS = 0x20,
            ATTR_SPECIFIED = 0x20000,
            ATTRIBUTES = 0x800,
            DISPLAYNAME = 0x200,
            EXETYPE = 0x2000,
            ICON = 0x100,
            ICONLOCATION = 0x1000,
            LARGEICON = 0,
            LINKOVERLAY = 0x8000,
            OPENICON = 2,
            OVERLAYINDEX = 0x40,
            PIDL = 8,
            SELECTED = 0x10000,
            SHELLICONSIZE = 4,
            SMALLICON = 1,
            SYSICONINDEX = 0x4000,
            TYPENAME = 0x400,
            USEFILEATTRIBUTES = 0x10
        }
    }
}

