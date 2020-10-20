using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class VersionUpdateRecord
    {
        public List<string> Contents
        {
            get
            {
                if (string.IsNullOrEmpty(this.UpdateContent))
                {
                    return new List<string>();
                }
                return new List<string>(this.UpdateContent.Split('#'));
            }
        }
    }
}
