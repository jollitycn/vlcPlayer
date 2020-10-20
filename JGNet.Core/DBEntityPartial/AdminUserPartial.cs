using System;
using System.Collections.Generic;
using JGNet.Core.Const;
using DataRabbit;

namespace JGNet
{
    public partial class AdminUser : IEntity<System.String>
    {
        public string RoleNames { get; set; }

        public String StateName
        {
            get
            {
                String value = "";
                switch (State)
                {
                    case 0:
                        value = "启用";
                        break;
                    case 1:
                        value = "禁用";
                        break;
                    default:
                        value = "启用";
                        break;
                }
                return value;
            }
        }

        public List<String> AllPermissons()
        {

            List<String> allPermissons = null;
            if (String.IsNullOrEmpty(PCManagePermission))
            {
                allPermissons = new List<string>();
            }
            else if (PCManagePermission == SystemDefault.ADMIN_USER_DEFAULT_NO_PERMISSION)
            {

            }
            else
            {
                allPermissons = new List<string>();
                   String[] permissions = PCManagePermission.Split(',');
                foreach (var item in permissions)
                {
                    String[] ps = item.Split('.');
                    foreach (var p in ps)
                    {
                        if (allPermissons.Find(t => t == p) == null)
                        {
                            allPermissons.Add(p);
                        }
                    }
                }
            }

            return allPermissons;
        }
    }
}
