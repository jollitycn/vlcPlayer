using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet.Core.Dev.InteractEntity
{
    public class WeiXinUserWebCache
    {
        /// <summary>
        /// 用户Openid
        /// </summary>
        public string Openid { get; set; }

        /// <summary>
        /// 帐套ID
        /// </summary>
        public string BusinessAccountID { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 导购ID或老板ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }

        public BusinessAccount BusinessAccount { get; set; }
    }
}
