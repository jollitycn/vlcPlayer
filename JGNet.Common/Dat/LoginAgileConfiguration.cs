using System;
using System.Collections.Generic;

using System.Text;
using JGNet.Core.RemotingEntity;

namespace JGNet.Common
{
    [Serializable]
    public class LoginAgileConfiguration : CJBasic.Serialization.AgileConfiguration
    {
        public List<LoginInfo> LoginInfos { get; set; }
        public BusinessAccount BusinessAccount { get;set; } 
        public String WebUrlIP { get; set; }
        public AutoUpgradeInfo AutoUpgradeInfo { get; set; }
    }


    public class LoginInfo {

        /// <summary>
        /// 是否保存账号密码
        /// </summary>
        public bool SavePassword { get; set; }

        /// <summary>
        /// 最后登录账号
        /// </summary>
        public String LastLoginID { get; set; }

        /// <summary>
        /// 登录密码，加密后的
        /// </summary>
        public String Password { get; set; }

        public DateTime loginTime { get; set; }

        public DateTime ExitTime { get; set; }
    }
}
