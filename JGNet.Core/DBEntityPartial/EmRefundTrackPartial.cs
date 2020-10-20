using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet
{
    public partial class EmRefundTrack
    {
        public string State
        {
            get => EnumHelper.GetDescription((RefundTrackType)this.OperateType);
        }
    }
}
