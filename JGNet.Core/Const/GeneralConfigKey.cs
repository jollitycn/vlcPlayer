using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Const
{
    public class GeneralConfigKey
    {
        #region cos腾讯云
        public const string APPID = "APPID";

        public const string SecretId = "SecretId";

        public const string SecretKey = "SecretKey";

        public const string Readonly_SecretId = "Readonly_SecretId";

        public const string Readonly_SecretKey = "Readonly_SecretKey";

        /// <summary>
        /// 存储桶名称
        /// </summary>
        public const string BucketName = "BucketName"; 
        #endregion

        public const string AutoUpgradeIP = "AutoUpgradeIP";

        public const string ManagerUpgradePort = "ManagerUpgradePort";

        public const string PostUpgradePort = "PostUpgradePort";

        /// <summary>
        /// 商户账套续期(钱/时间/时间单位，例如： 1/1/月#2/1/年#3/2/年)
        /// </summary>
        public const string Renewal = "Renewal";

        /// <summary>
        /// 试用时间
        /// </summary>
        public const string TrialTime = "TrialTime";

        #region 微信小程序
        public const string Wx_AppID = "Wx_AppID";

        public const string Wx_AppSecret = "Wx_AppSecret";

        public const string Wx_KEY = "Wx_KEY";

        public const string Wx_MCHID = "Wx_MCHID";

        public const string Wx_NOTIFY_URL = "Wx_NOTIFY_URL";
        #endregion
    }
}
