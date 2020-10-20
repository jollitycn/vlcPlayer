using CJBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class ScrapOrder
    {
        public int DateInt { get { return new Date(this.CreateTime).ToDateInteger(); } }

        public string OperatorUserName { get; set; }

        public string ShopName { get; set; }
    }
}
