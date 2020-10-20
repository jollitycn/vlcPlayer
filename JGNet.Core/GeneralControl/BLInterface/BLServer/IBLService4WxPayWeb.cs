using System;
using System.Collections.Generic;
using System.Text;
using JGNet.Core.Dev.InteractEntity;
using JGNet.Core.InteractEntity;
using JGNet.Core.RemotingEntity;

namespace JGNet.Core.Dev.BLInterface.BLServer
{
    public interface IBLService4WxPayWeb
    {
        void InsertWxPayCallbackRecord(WxPayCallbackRecord wxPayCallbackRecord);

        LoadServerInfo GetLoadServerInfo(string businessAccountId);

        InteractResult InsertPaymentRecord(WxPayCallbackRecord wxPayCallbackRecord);

        WxPayInfo GetWxPayInfo();
    }
}
