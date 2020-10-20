using System;
using System.Collections.Generic;

using System.Text;


namespace JGNet
{
    public partial class Guide
    {
        public string RoleNames { get; set; }
        
        public String ShopName
        {
            get;set;
        }

        public String StateSign
        {
            get
            {
                return this.State == 0 ? "启用" : "禁用";
            }
        }

        public String SexSign
        {
            get { return this.Sex ? "男" : "女"; }
        }
        public String MarriagedSign
        {
            get { return this.Marriaged ? "已婚" : "未婚"; }
        }
    }
}
