using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Common.Core
{ 
    public enum OperationEnum
    {
        [Description("添加")]
        Add = -1, 
        [Description("编辑")]
        Edit = 0, 
        [Description("删除")]
        Delete, 
        [Description("查询")]
        Query, 
        [Description("冲单")]
        Cancel, 
        [Description("提单")]
        Pick, 
        [Description("重做")]
        Redo,
        [Description("发货")]
        Send
    }
  
}
