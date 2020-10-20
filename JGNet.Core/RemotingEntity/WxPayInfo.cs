using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.RemotingEntity
{
    [Serializable]
    public class WxPayInfo
    {
        public string APPID { get; set; }

        public string MCHID { get; set; }

        public string KEY { get; set; }

        public string APPSECRET { get; set; }

        public string NOTIFY_URL { get; set; }
    }
}
