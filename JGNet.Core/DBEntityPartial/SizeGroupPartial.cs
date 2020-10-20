using System;
using System.Collections.Generic;
using DataRabbit;

namespace JGNet
{
    public partial class SizeGroup
    {
        public String DisplayName { get { return this.ShowName + "(" + this.Comment + ")"; } }
    }
}
