using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Sms.Interface
{
    public interface IRemotingManager
    {
        ISms4GuideWeb Sms4GuideWeb { get; }
    }
}
