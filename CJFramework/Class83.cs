using CJFramework;
using System;
using System.Net;

internal class Class83 : BaseUdpEngine, IDisposable, IEngine, IAction, IUdpHelper, Interface43
{
    public Class83()
    {
        base.bool_0 = true;
    }

    public bool IsBusy(IPEndPoint ipendPoint_0)
    {
        if (base.GetIUdpSessionHelper() == null)
        {
            return false;
        }
        return base.GetIUdpSessionHelper().imethod_2(ipendPoint_0);
    }

    public bool SendMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (this.IsBusy(ipendPoint_0) && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        base.SendMessage(interface37_0, ipendPoint_0);
        return true;
    }

    public bool PostMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (this.IsBusy(ipendPoint_0) && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        base.sendMessage(interface37_0, ipendPoint_0);
        return true;
    }

    protected override IPv6UdpClient GetPv6UdpClient()
    {
        if (base.imethod_4() == null)
        {
            return new IPv6UdpClient(base.int_0);
        }
        return new IPv6UdpClient(base.imethod_4(), base.int_0);
    }
}

