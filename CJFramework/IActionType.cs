using CJFramework;
using CJFramework.Passive;
using System;

internal interface IActionType
{
    bool imethod_0(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    IMessageHandler imethod_1(IMessageHandler interface37_0, int? resMessageType);
    void imethod_2(IMessageHandler interface37_0, int int_0, Delegate0 delegate0_0, object object_0);
    IMessageHandler imethod_3(IMessageHandler interface37_0, int? resMessageType);
    void imethod_4(IMessageHandler interface37_0, int int_0, Delegate0 delegate0_0, object object_0);
    void imethod_5(Interface36 interface36_0);
    Interface13 imethod_6();
    void imethod_7(Interface13 interface13_0);
    bool IsP2PChannelExist(string string_0);
    bool Send(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool SendByP2PChannel(IMessageHandler interface37_0, ActionTypeOnNoP2PChannel actionTypeOnNoP2PChannel_0, bool bool_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);

    bool? Connected { get; }
}

