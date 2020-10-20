namespace CJPlus.Serialization
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class SimpleFont
    {
        [CompilerGenerated]
        private float float_0;
        [CompilerGenerated]
        private int int_0;
        [CompilerGenerated]
        private string string_0;

        public SimpleFont()
        {
        }

        public SimpleFont(Font font)
        {
            this.FontFamily = font.FontFamily.Name;
            this.Size = font.Size;
            this.FontStyle = (int) font.Style;
        }

        public Font GetFont()
        {
            return new Font(this.FontFamily, this.Size, (System.Drawing.FontStyle) this.FontStyle);
        }

        public string FontFamily
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        public int FontStyle
        {
            [CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }

        public float Size
        {
            [CompilerGenerated]
            get
            {
                return this.float_0;
            }
            [CompilerGenerated]
            set
            {
                this.float_0 = value;
            }
        }
    }
}

