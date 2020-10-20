using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class UpdateEMallLogoPara
    {
        public string BusinessAccountID { get; set; }

        public byte[] Logo { get; set; }
    }

    [Serializable]
    public class UpdateEMallPhotoPara
    {
        public string BusinessAccountID { get; set; }

        public byte[] Logo { get; set; }
    }
}
