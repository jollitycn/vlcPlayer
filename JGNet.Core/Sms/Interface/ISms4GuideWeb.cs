using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Sms.Interface
{
    public interface ISms4GuideWeb
    {
        void Send(string memberID, string smsContent);
    }
}
