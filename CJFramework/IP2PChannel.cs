using CJFramework;
using System;

internal interface IP2PChannel : IDisposable
{
    bool IsP2PChannelExist(string destUserID);
    bool SendMessage(string string_0, IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
}

