namespace CJBasic.Helpers
{
    using System;
    using System.Windows.Forms;

    [Serializable]
    public class ScreenResolution
    {
        private int bitsPerPixels;
        private int displayFrequency;
        private int height;
        private int width;

        public ScreenResolution()
        {
            this.bitsPerPixels = 0x20;
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            this.displayFrequency = 60;
            this.bitsPerPixels = 0x20;
        }

        public ScreenResolution(int _width, int _height, int _displayFrequency, int _bitsPerPixels)
        {
            this.bitsPerPixels = 0x20;
            this.width = _width;
            this.height = _height;
            this.displayFrequency = _displayFrequency;
            this.bitsPerPixels = _bitsPerPixels;
        }

        public override string ToString()
        {
            return string.Format("{0,4}\x00d7{1,-4} {2,2}Bits {3,3}Hz", new object[] { this.width, this.height, this.bitsPerPixels, this.displayFrequency });
        }

        public int BitsPerPixels
        {
            get
            {
                return this.bitsPerPixels;
            }
            set
            {
                this.bitsPerPixels = value;
            }
        }

        public int DisplayFrequency
        {
            get
            {
                return this.displayFrequency;
            }
            set
            {
                this.displayFrequency = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
    }
}

