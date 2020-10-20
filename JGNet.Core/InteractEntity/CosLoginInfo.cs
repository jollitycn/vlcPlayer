using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class CosLoginInfo
    {
        public int AppID { get; set; }

        public string SecretId { get; set; }

        public string SecretKey { get; set; }

        /// <summary>
        /// 存储桶
        /// </summary>
        public string BucketName { get; set; }
    }
}
