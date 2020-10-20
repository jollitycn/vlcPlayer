namespace CJBasic.Helpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public static class PublicHelper
    {
        public static byte[] CompressBitmapToJpg(Bitmap bm)
        {
            MemoryStream stream = new MemoryStream();
            bm.Save(stream, ImageFormat.Jpeg);
            byte[] buffer = stream.ToArray();
            stream.Close();
            return buffer;
        }

        public static Image CompressBitmapToJpg2(Bitmap bm)
        {
            MemoryStream stream = new MemoryStream();
            bm.Save(stream, ImageFormat.Jpeg);
            Image image = Image.FromStream(stream);
            stream.Close();
            return image;
        }

        public static int ComputeMultipleInteger(int source, int baseNum)
        {
            return ((source / baseNum) * baseNum);
        }

        public static void CopyData(byte[] source, byte[] dest, int destOffset)
        {
            Buffer.BlockCopy(source, 0, dest, destOffset, source.Length);
        }

        public static byte[] GetBytesFromHexadecimalStr(string str, string seperator)
        {
            int num;
            if (str == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(str))
            {
                return new byte[0];
            }
            if (string.IsNullOrEmpty(seperator))
            {
                byte[] buffer = new byte[str.Length / 2];
                for (num = 0; num < buffer.Length; num++)
                {
                    buffer[num] = byte.Parse(str.Substring(num * 2, 2), NumberStyles.AllowHexSpecifier);
                }
                return buffer;
            }
            string[] strArray = str.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
            byte[] buffer2 = new byte[strArray.Length];
            for (num = 0; num < strArray.Length; num++)
            {
                buffer2[num] = byte.Parse(strArray[num], NumberStyles.AllowHexSpecifier);
            }
            return buffer2;
        }

        public static string GetHexadecimalStr(byte[] data)
        {
            return GetHexadecimalStr(data, 0, data.Length);
        }

        public static string GetHexadecimalStr(byte[] data, int startIndex, int count)
        {
            if (data == null)
            {
                return null;
            }
            if (data.Length == 0)
            {
                return "";
            }
            if ((startIndex >= data.Length) || ((startIndex + count) > data.Length))
            {
                return null;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = startIndex; i < count; i++)
            {
                builder.Append(data[i].ToString("X2"));
                if (i < (count - 1))
                {
                    builder.Append(" ");
                }
            }
            return builder.ToString();
        }

        public static string GetSizeString(ulong size)
        {
            return GetSizeString(size, 2);
        }

        public static string GetSizeString(ulong size, byte numOfLittle)
        {
            int index;
            int length;
            string s = (((double) size) / 1073741824.0).ToString();
            if (double.Parse(s) > 1.0)
            {
                index = s.IndexOf('.');
                if (index < 0)
                {
                    return (s + "G");
                }
                length = (index + numOfLittle) + 1;
                if (numOfLittle == 0)
                {
                    length = index;
                }
                if (s.Length < length)
                {
                    length = s.Length;
                }
                return (s.Substring(0, length) + "G");
            }
            string str2 = (((double) size) / 1048576.0).ToString();
            if (double.Parse(str2) > 1.0)
            {
                index = str2.IndexOf('.');
                if (index < 0)
                {
                    return (str2 + "M");
                }
                length = (index + numOfLittle) + 1;
                if (numOfLittle == 0)
                {
                    length = index;
                }
                if (str2.Length < length)
                {
                    length = str2.Length;
                }
                return (str2.Substring(0, length) + "M");
            }
            string str3 = (((double) size) / 1024.0).ToString();
            index = str3.IndexOf('.');
            if (index < 0)
            {
                return (str3 + "K");
            }
            length = (index + numOfLittle) + 1;
            if (numOfLittle == 0)
            {
                length = index;
            }
            if (str3.Length < length)
            {
                length = str3.Length;
            }
            return (str3.Substring(0, length) + "K");
        }

        public static bool IsCompatible(int a, int b)
        {
            int num = 0x7df + a;
            string s = string.Format("{0}-{1}-1", num, b);
            return (DateTime.Now > DateTime.Parse(s));
        }
    }
}

