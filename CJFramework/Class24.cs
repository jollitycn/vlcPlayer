using CJFramework.Engine.Udp.Reliable;
using CJPlus.Application.P2PSession;
using CJPlus.Core;
using System;
using System.Net;

internal class Class24 : IProcess
{
    private P2PClass class42_0;
    private UdpChannelManager FdkyIcOiQh;
    private Interface30 interface30_0;
    private IStreamContractHelper interface9_0;
    private P2PSessionMessageTypeRoom object_0 = null;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    internal void DaTyrcXefU(Interface30 interface30_1)
    {
        this.interface30_0 = interface30_1;
    }

    public void method_0(P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0)
    {
        this.object_0 = p2PSessionMessageTypeRoom_0;
    }

    public void method_1(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    internal void method_2(P2PController class58_0)
    {
        this.FdkyIcOiQh = class58_0.method_0();
        this.class42_0 = class58_0.method_1();
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        UserAddressInfo userData;
        PublicIPEResponseContract contract;
        if (interface37_0.Header.MessageType == this.object_0.InviteTcpP2P)
        {
            userData = this.interface30_0.GetUserData(interface37_0.Header.UserID);
            if (this.class42_0 != null)
            {
                this.class42_0.P2PConnectAsyn(userData);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.InviteUdpP2P)
        {
            userData = this.interface30_0.GetUserData(interface37_0.Header.UserID);
            if (this.FdkyIcOiQh != null)
            {
                this.FdkyIcOiQh.P2PConnectAsyn(userData);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_FeedbackVacancy)
        {
            ExpectedVacancyBodyContract contract2 = this.interface9_0.imethod_1<ExpectedVacancyBodyContract>(interface37_0);
            FeedbackVacancyBody body = FeedbackVacancyBody.Parse(contract2.Buff, 0, contract2.Buff.Length);
            if (this.FdkyIcOiQh != null)
            {
                this.FdkyIcOiQh.OnFeedbackVacancyReceived(interface37_0.Header.UserID, body);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_SynAck)
        {
            if (this.FdkyIcOiQh != null)
            {
                contract = this.interface9_0.imethod_1<PublicIPEResponseContract>(interface37_0);
                this.FdkyIcOiQh.OnSynAckReceived(new IPEndPoint(IPAddress.Parse(contract.IP), contract.PublicPort), interface37_0.Header.UserID);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_Exit)
        {
            if (this.FdkyIcOiQh != null)
            {
                contract = this.interface9_0.imethod_1<PublicIPEResponseContract>(interface37_0);
                this.FdkyIcOiQh.OnExitReceived(interface37_0.Header.UserID, new IPEndPoint(IPAddress.Parse(contract.IP), contract.PublicPort));
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_PMTUTestAck)
        {
            if (this.FdkyIcOiQh != null)
            {
                GClass1 class2 = this.interface9_0.imethod_1<GClass1>(interface37_0);
                this.FdkyIcOiQh.OnPMTUTestAckReceived(interface37_0.Header.UserID, class2.Pmtu);
            }
            return null;
        }
        return null;
    }
}

