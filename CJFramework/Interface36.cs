using CJFramework;
using CJFramework.Passive;
using System;

internal interface Interface36
{
    void imethod_0(IMessageForbidden interface39_0);
    void imethod_1(ICommitMessageToServer interface4_0);
    void imethod_2(IP2PChannel interface23_0);
    bool IsP2PChannelExist(string string_0);
    bool SendByP2PChannel(IMessageHandler interface37_0, ActionTypeOnNoP2PChannel actionTypeOnNoP2PChannel_0, bool bool_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool SendMessage(IMessageHandler interface37_0, bool bool_0, bool bool_1, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);

    bool? Connected { get; }
}

