using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CosCloudSignature
    {
        public string Signature { get; set; }

        public int AppID { get; set; }

        public string BucketName { get; set; }

        public string COSAPI_CGI_URL { get; set; }
    }
}
