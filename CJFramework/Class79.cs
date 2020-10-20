using CJFramework;
using CJFramework.Passive;
using System;

internal sealed class Class79 : IActionType
{
    private Interface13 interface13_0;
    private Interface36 interface36_0;

    public Class79()
    {
    }

    public Class79(Interface13 interface13_1, Interface36 interface36_1)
    {
        this.interface13_0 = interface13_1;
        this.interface36_0 = interface36_1;
    }

    public bool imethod_0(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return this.interface36_0.SendMessage(interface37_0, true, bool_0, actionTypeOnChannelIsBusy_0);
    }

    public IMessageHandler imethod_1(IMessageHandler interface37_0, int? resKey)
    {
        this.interface36_0.SendMessage(interface37_0, false, false, ActionTypeOnChannelIsBusy.Continue);
        if (!resKey.HasValue)
        {
            return null;
        }
        return this.interface13_0.PickupResponse(resKey.Value, interface37_0.Header.MessageID);
    }

    public void imethod_2(IMessageHandler interface37_0, int int_0, Delegate0 delegate0_0, object object_0)
    {
        this.interface13_0.RegisterCallback(int_0, interface37_0.Header.MessageID, delegate0_0, object_0);
        this.interface36_0.SendMessage(interface37_0, false, true, ActionTypeOnChannelIsBusy.Continue);
    }

    public IMessageHandler imethod_3(IMessageHandler interface37_0, int? resMessageType)
    {
        this.interface36_0.SendMessage(interface37_0, true, true, ActionTypeOnChannelIsBusy.Continue);
        if (!resMessageType.HasValue)
        {
            return null;
        }
        return this.interface13_0.PickupResponse(resMessageType.Value, interface37_0.Header.MessageID);
    }

    public void imethod_4(IMessageHandler interface37_0, int int_0, Delegate0 delegate0_0, object object_0)
    {
        this.interface13_0.RegisterCallback(int_0, interface37_0.Header.MessageID, delegate0_0, object_0);
        this.interface36_0.SendMessage(interface37_0, true, true, ActionTypeOnChannelIsBusy.Continue);
    }

    public void imethod_5(Interface36 interface36_1)
    {
        this.interface36_0 = interface36_1;
    }

    public Interface13 imethod_6()
    {
        return this.interface13_0;
    }

    public void imethod_7(Interface13 interface13_1)
    {
        this.interface13_0 = interface13_1;
    }

    public bool IsP2PChannelExist(string string_0)
    {
        return this.interface36_0.IsP2PChannelExist(string_0);
    }

    public bool Send(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return this.interface36_0.SendMessage(interface37_0, false, bool_0, actionTypeOnChannelIsBusy_0);
    }

    public bool SendByP2PChannel(IMessageHandler interface37_0, ActionTypeOnNoP2PChannel actionTypeOnNoP2PChannel_0, bool bool_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return this.interface36_0.SendByP2PChannel(interface37_0, actionTypeOnNoP2PChannel_0, bool_0, string_0, actionTypeOnChannelIsBusy_0);
    }

    public bool? Connected
    {
        get
        {
            return this.interface36_0.Connected;
        }
    }
}

