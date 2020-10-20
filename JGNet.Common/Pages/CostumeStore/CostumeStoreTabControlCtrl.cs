using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms; 
using JGNet.Core.InteractEntity;
using CCWin;
using JGNet.Core;
using CJBasic.Loggers;
using JGNet.Common;
using JGNet.Common.Core.Util;
using JGNet.Common.Components;
using JGNet.Server.Tools;
using JGNet.Common.Core;

namespace JGNet.Manage
{
    public partial class CostumeStoreTabControlCtrl : Common.Core.BaseModifyUserControl
    {


        public CostumeStoreTabControlCtrl()
        {
            InitializeComponent();
            MenuPermission = RolePermissionMenuEnum.库存查询;
        } 

    }
}
