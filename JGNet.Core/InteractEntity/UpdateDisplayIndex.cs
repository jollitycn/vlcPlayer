using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class UpdateDisplayIndex
    {
        public string PhotoName { get; set; }

        public int DisplayIndex { get; set; }
    }
}
