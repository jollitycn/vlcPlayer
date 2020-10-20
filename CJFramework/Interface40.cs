using CJFramework;
using System;
using System.Collections.Generic;
using System.Net;

internal interface Interface40
{
    bool imethod_0(IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool PostMessage(IMessageHandler interface37_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    void PostMessage(IMessageHandler interface37_0, IEnumerable<string> ienumerable_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool PostMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool SendMessage(IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    void SendMessage(IMessageHandler interface37_0, IEnumerable<string> ienumerable_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool SendMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool SendMessage(IMessageHandler interface37_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
}

