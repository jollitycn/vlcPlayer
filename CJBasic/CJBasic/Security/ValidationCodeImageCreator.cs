namespace CJBasic.Security
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;

    public static class ValidationCodeImageCreator
    {
        private static string GenCode(int num)
        {
            string[] strArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string str = "";
            Random random = new Random();
            for (int i = 0; i < num; i++)
            {
                str = str + strArray[random.Next(0, strArray.Length)];
            }
            return str;
        }

        public static Bitmap Generate(int codeLength, out string validationCode)
        {
            validationCode = GenCode(codeLength);
            return GenImg(validationCode);
        }

        private static Bitmap GenImg(string code)
        {
            return GenImg(code, Color.DimGray, Color.White);
        }

        private static Bitmap GenImg(string code, Color foreColor, Color backColor)
        {
            return GenImg(code, foreColor, backColor, new Font("Courier New", 18f, FontStyle.Bold));
        }

        private static Bitmap GenImg(string code, Color foreColor, Color backColor, Font font)
        {
            int width = code.Length * 0x12;
            Bitmap image = new Bitmap(width, 0x1c);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, width, 0x1c);
            graphics.FillRectangle(new SolidBrush(backColor), rect);
            graphics.DrawString(code, font, new SolidBrush(foreColor), rect);
            graphics.Dispose();
            return image;
        }
    }
}

