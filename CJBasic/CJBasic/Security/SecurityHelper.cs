namespace CJBasic.Security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class SecurityHelper
    {
        public static string MD5String(string pwd)
        {
            return MD5String(pwd, Encoding.UTF8);
        }

        public static string MD5String(string pwd, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(pwd);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < buffer2.Length; i++)
            {
                builder.Append(buffer2[i].ToString("x"));
            }
            return builder.ToString();
        }

        public static string MD5String2(string pwd)
        {
            return MD5String2(pwd, Encoding.UTF8);
        }

        public static string MD5String2(string pwd, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(pwd);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; i < buffer2.Length; i++)
            {
                string str = buffer2[i].ToString("x");
                if (str.Length == 1)
                {
                    str = "0" + str;
                }
                builder.Append(str);
            }
            return builder.ToString();
        }
    }
}

