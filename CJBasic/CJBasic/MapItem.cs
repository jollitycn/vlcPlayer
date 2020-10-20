namespace CJBasic
{
    using System;

    public class MapItem
    {
        private string source;
        private string target;

        public MapItem()
        {
        }

        public MapItem(string theSource, string theTarget)
        {
            this.source = theSource;
            this.target = theTarget;
        }

        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        public string Target
        {
            get
            {
                return this.target;
            }
            set
            {
                this.target = value;
            }
        }
    }
}

