namespace CJBasic.Widget
{
    using System;

    public class DefaultImagePathGetter : IImagePathGetter
    {
        private string folderPath;
        private string imageExtendName;

        public DefaultImagePathGetter()
        {
            this.folderPath = null;
            this.imageExtendName = ".gif";
        }

        public DefaultImagePathGetter(string _folderPath, string _imageExtendName)
        {
            this.folderPath = null;
            this.imageExtendName = ".gif";
            this.folderPath = _folderPath;
            this.imageExtendName = _imageExtendName ?? ".gif";
        }

        public string GetPath(uint imageID)
        {
            if ((this.folderPath == null) || (this.folderPath == ""))
            {
                return string.Format("{0}{1}", imageID, this.imageExtendName);
            }
            return string.Format(@"{0}\{1}{2}", this.folderPath, imageID, this.imageExtendName);
        }
    }
}

