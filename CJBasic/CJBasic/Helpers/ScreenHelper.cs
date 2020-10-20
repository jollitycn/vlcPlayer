namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class ScreenHelper
    {
        public static Bitmap CaptureScreen()
        {
            return CaptureScreen(new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
        }

        public static Bitmap CaptureScreen(Rectangle region)
        {
            Bitmap image = new Bitmap(region.Width, region.Height);
            Graphics.FromImage(image).CopyFromScreen(region.Location, new Point(0, 0), region.Size);
            return image;
        }

        public static void ChangeDisplayMode(DisplayMode displayMode)
        {
            ChangeDisplaySettings(ref displayMode, 0);
        }

        public static void ChangeDisplayMode(ScreenResolution screenResolution)
        {
            if ((screenResolution.BitsPerPixels == 0) || (screenResolution.DisplayFrequency == 0))
            {
                ChangeDisplayMode(screenResolution.Width, screenResolution.Height);
            }
            else
            {
                bool flag = false;
                foreach (DisplayMode mode in GetSupportedDisplayModes())
                {
                    if ((((mode.dmPelsWidth == screenResolution.Width) && (mode.dmPelsHeight == screenResolution.Height)) && (mode.dmDisplayFrequency == screenResolution.DisplayFrequency)) && (mode.dmBitsPerPel == screenResolution.BitsPerPixels))
                    {
                        flag = true;
                        ChangeDisplayMode(mode);
                        break;
                    }
                }
                if (!flag)
                {
                    throw new Exception("ScreenResolution settings Not Supported");
                }
            }
        }

        public static void ChangeDisplayMode(int width, int heigth)
        {
            DisplayMode? nullable = null;
            foreach (DisplayMode mode in GetSupportedDisplayModes())
            {
                if ((mode.dmPelsWidth == width) && (mode.dmPelsHeight == heigth))
                {
                    if (!nullable.HasValue)
                    {
                        nullable = new DisplayMode?(mode);
                    }
                    else if ((mode.dmDisplayFrequency > nullable.Value.dmDisplayFrequency) || (mode.dmBitsPerPel > nullable.Value.dmBitsPerPel))
                    {
                        nullable = new DisplayMode?(mode);
                    }
                }
            }
            if (!nullable.HasValue)
            {
                throw new Exception("ScreenResolution settings Not Supported");
            }
            ChangeDisplayMode(nullable.Value);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        internal static extern int ChangeDisplaySettings([In] ref DisplayMode lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        internal static extern bool EnumDisplaySettings(int lpszDeviceName, int iModeNum, ref DisplayMode lpDevMode);
        public static List<DisplayMode> GetSupportedDisplayModes()
        {
            List<DisplayMode> list = new List<DisplayMode>();
            DisplayMode lpDevMode = new DisplayMode();
            for (int i = 0; EnumDisplaySettings(0, i, ref lpDevMode); i++)
            {
                list.Add(lpDevMode);
            }
            return list;
        }

        public static List<ScreenResolution> GetSupportedScreenResolutions()
        {
            Dictionary<string, DisplayMode> dictionary = new Dictionary<string, DisplayMode>();
            foreach (DisplayMode mode in GetSupportedDisplayModes())
            {
                if (mode.dmPelsWidth >= mode.dmPelsHeight)
                {
                    string key = string.Format("{0}*{1}", mode.dmPelsWidth, mode.dmPelsHeight);
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, mode);
                    }
                    else if (mode.dmBitsPerPel > dictionary[key].dmBitsPerPel)
                    {
                        dictionary[key] = mode;
                    }
                    else if ((mode.dmBitsPerPel == dictionary[key].dmBitsPerPel) && (mode.dmDisplayFrequency > dictionary[key].dmDisplayFrequency))
                    {
                        dictionary[key] = mode;
                    }
                }
            }
            List<ScreenResolution> list = new List<ScreenResolution>();
            foreach (DisplayMode mode in dictionary.Values)
            {
                list.Add(mode.GetScreenResolution());
            }
            return list;
        }
    }
}

