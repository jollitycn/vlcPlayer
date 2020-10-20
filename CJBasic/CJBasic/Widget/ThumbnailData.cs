namespace CJBasic.Widget
{
    using System;
    using System.Drawing;

    public class ThumbnailData
    {
        private System.Drawing.Image image;
        private string name;

        public ThumbnailData()
        {
        }

        public ThumbnailData(string _name, System.Drawing.Image _image)
        {
            this.name = _name;
            this.image = _image;
        }

        public System.Drawing.Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}

