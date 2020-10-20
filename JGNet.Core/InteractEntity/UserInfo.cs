using JGNet.Core.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.InteractEntity
{
    [Serializable]
    public class UserInfo
    {
        public string ID { get; set; }

        /// <summary>
        /// 导购为所属店铺ID； 管理员为总店ID
        /// </summary>
        public string ShopId { get; set; }

        public UserInfoType Type { get; set; }

        public List<int> RolePermissions { get; set; }
    }

    public enum UserInfoType
    {
        Admin = 0,

        Guide = 1
    }
}
