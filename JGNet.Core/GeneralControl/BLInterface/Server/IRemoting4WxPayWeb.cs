using System;
using System.Collections.Generic;
using System.Text;
using JGNet.Core.RemotingEntity;

namespace JGNet.Core.Dev.BLInterface.Server
{
    public interface IRemoting4WxPayWeb
    {
        bool InsertRechargeRecord(WxPayCallbackRecord wxPayCallbackRecord);

        WxPayInfo GetWxPayInfo();

        bool PayInWx(WxPayCallbackRecord wxPayCallbackRecord);

        bool PayPfCustomerOrder(WxPayCallbackRecord wxPayCallbackRecord);
    }
}
