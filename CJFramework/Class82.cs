using CJFramework;
using System;
using System.Collections.Generic;
using System.Net;

internal class Class82 : BaseUdpEngine, IDisposable, IEngine, ICommitMessageToServer, IUdpHelper, Interface29
{
    private AgileIPE agileIPE_0;

    public Class82()
    {
        base.bool_0 = false;
    }

    public AgileIPE GetAgileIPE()
    {
        return this.agileIPE_0;
    }

    public void SetAgileIPE(AgileIPE agileIPE_1)
    {
        this.agileIPE_0 = agileIPE_1;
    }
     

    public bool CommitMessageToServer(IMessageHandler interface37_0, bool bool_3, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if (this.ChannelIsBusy && (actionTypeOnChannelIsBusy_0 == ActionTypeOnChannelIsBusy.Discard))
        {
            return false;
        }
        if (bool_3)
        {
            base.SendMessage(interface37_0, this.agileIPE_0.IPEndPoint_0);
        }
        else
        {
            base.SendMessage(interface37_0, this.agileIPE_0.IPEndPoint_0);
        }
        return true;
    }

    protected override IPv6UdpClient GetPv6UdpClient()
    {
        if (!NetworkHelper.smethod_3(this.agileIPE_0.String_0))
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(this.agileIPE_0.String_0);
            if (hostEntry.AddressList.Length > 0)
            {
                this.agileIPE_0 = new AgileIPE(hostEntry.AddressList[0].ToString(), this.agileIPE_0.Port);
            }
        }
        IPAddress address = IPAddress.Parse(this.agileIPE_0.String_0);
        if ((base.int_0 <= 0) && (base.imethod_4() == null))
        {
            return new IPv6UdpClient(address.AddressFamily);
        }
        if (base.int_0 <= 0)
        {
            return new IPv6UdpClient(base.imethod_4(), 0);
        }
        if (base.imethod_4() == null)
        {
            List<string> list = NetworkHelper.smethod_1(address.AddressFamily);
            base.LjXdpkRter(list[0]);
            return new IPv6UdpClient(base.imethod_4(), base.int_0);
        }
        return new IPv6UdpClient(base.imethod_4(), base.int_0);
    }

    public void CommitMessageToServer(IMessageHandler interface37_0, IPEndPoint ipendPoint_0)
    {
        throw new NotImplementedException();
    }

    public bool ChannelIsBusy
    {
        get
        {
            if (base.GetIUdpSessionHelper() == null)
            {
                return false;
            }
            return base.GetIUdpSessionHelper().imethod_2(this.agileIPE_0.IPEndPoint_0);
        }
    }
}

