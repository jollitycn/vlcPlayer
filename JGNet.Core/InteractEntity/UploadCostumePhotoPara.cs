using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class UploadCostumePhotoPara
    {
        public string ID { get; set; }

        public string PhotoName { get; set; }

        public Byte[] Photo { get; set; }
    }
}
