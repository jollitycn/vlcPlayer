using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.InteractEntity
{
    public class WeiXinUserLoginData
    {
        public string Openid { get; set; }

        public string Session_key { get; set; }

        // public string session_key { get; set; }

        //  public string openid { get; set; }
        public override string ToString()
        {
            return string.Format("Openid:{0};Session_key:{1}", Openid, Session_key);
        }
    }

    public class WeiXinAccessToken
    {
        /// <summary>
        /// 使用标识
        /// </summary>
        public string Access_token { get; set; }

        /// <summary>
        /// 有效时间（秒）
        /// </summary>
        public int Expires_in { get; set; }
    }


    public class MiniProgramOpenidInfo
    {
        public string session_key { get; set; }

        public string openid { get; set; }
    }
}
