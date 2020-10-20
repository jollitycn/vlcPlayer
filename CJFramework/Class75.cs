using CJFramework;
using CJFramework.Engine.Udp.Reliable;
using CJFramework.Server.UserManagement;
using CJPlus.Application.P2PSession;
using System;
using System.Net;

internal class Class75 : Interface30
{
    private bool bool_0;
    private IActionType interface31_0;
    private IStreamContractHelper interface9_0;
    private P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0;
    private string string_0;

    public Class75()
    {
        this.bool_0 = false;
        this.string_0 = "";
        this.interface31_0 = null;
        this.interface9_0 = null;
        this.p2PSessionMessageTypeRoom_0 = null;
    }

    public Class75(IActionType interface31_1, IStreamContractHelper interface9_1, P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1)
    {
        this.bool_0 = false;
        this.string_0 = "";
        this.interface31_0 = null;
        this.interface9_0 = null;
        this.p2PSessionMessageTypeRoom_0 = null;
        this.interface31_0 = interface31_1;
        this.interface9_0 = interface9_1;
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
    }

    public UserAddressInfo GetUserData(string string_1)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_5<ReqUserDataContract>(this.string_0, this.p2PSessionMessageTypeRoom_0.ReqUserData, new ReqUserDataContract(string_1));
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.p2PSessionMessageTypeRoom_0.ReqUserData));
        return this.interface9_0.imethod_1<ResUserDataContract>(interface3);
    }

    public void imethod_0(string string_1)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>(this.string_0, this.p2PSessionMessageTypeRoom_0.InviteTcpP2P, null, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public void imethod_1(string string_1)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>(this.string_0, this.p2PSessionMessageTypeRoom_0.InviteUdpP2P, null, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public IPEndPoint imethod_2()
    {
        IMessageHandler interface2 = this.interface9_0.imethod_6(this.string_0, this.p2PSessionMessageTypeRoom_0.GetMyPublicIPE);
        IMessageHandler interface3 = this.interface31_0.imethod_1(interface2, new int?(this.p2PSessionMessageTypeRoom_0.GetMyPublicIPE));
        PublicIPEResponseContract contract = this.interface9_0.imethod_1<PublicIPEResponseContract>(interface3);
        return new IPEndPoint(IPAddress.Parse(contract.IP.Trim()), contract.PublicPort);
    }

    public void imethod_3(P2PAddress p2PAddress_0)
    {
        bool isPublic = p2PAddress_0.PrivateIP != p2PAddress_0.PublicIP;
        P2PLogonContract body = new P2PLogonContract(p2PAddress_0, isPublic);
        this.interface31_0.Send(this.interface9_0.imethod_4<P2PLogonContract>(this.string_0, this.p2PSessionMessageTypeRoom_0.P2PLogon, body, "_0"), false, ActionTypeOnChannelIsBusy.Continue);
    }

    public void imethod_4(string string_1, FeedbackVacancyBody feedbackVacancyBody_0)
    {
        byte[] stream = new byte[feedbackVacancyBody_0.BodyTotalLength];
        feedbackVacancyBody_0.ToStream(stream, 0);
        ExpectedVacancyBodyContract body = new ExpectedVacancyBodyContract(stream);
        IMessageHandler interface2 = this.interface9_0.imethod_4<ExpectedVacancyBodyContract>(this.string_0, this.p2PSessionMessageTypeRoom_0.Help4UDP_FeedbackVacancy, body, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public void imethod_5(string string_1, AgileIPE agileIPE_0, string string_2)
    {
        PublicIPEResponseContract body = new PublicIPEResponseContract(agileIPE_0.String_0, agileIPE_0.Port);
        IMessageHandler interface2 = this.interface9_0.imethod_4<PublicIPEResponseContract>(this.string_0, this.p2PSessionMessageTypeRoom_0.Help4UDP_SynAck, body, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public void imethod_6(AgileIPE agileIPE_0, string string_1)
    {
        PublicIPEResponseContract body = new PublicIPEResponseContract(agileIPE_0.String_0, agileIPE_0.Port);
        IMessageHandler interface2 = this.interface9_0.imethod_4<PublicIPEResponseContract>(this.string_0, this.p2PSessionMessageTypeRoom_0.Help4UDP_Exit, body, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public void imethod_7(string string_1, ushort ushort_0)
    {
        GClass1 body = new GClass1(ushort_0);
        IMessageHandler interface2 = this.interface9_0.imethod_4<GClass1>(this.string_0, this.p2PSessionMessageTypeRoom_0.Help4UDP_PMTUTestAck, body, string_1);
        this.interface31_0.imethod_3(interface2, null);
    }

    public bool method_0()
    {
        return this.bool_0;
    }

    public void method_1(string string_1)
    {
        this.string_0 = string_1;
        this.bool_0 = true;
    }

    public void SetInterface31(IActionType interface31_1)
    {
        this.interface31_0 = interface31_1;
    }

    public void SetInterface9(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void SetP2PSessionMessageTypeRoom(P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_1)
    {
        this.p2PSessionMessageTypeRoom_0 = p2PSessionMessageTypeRoom_1;
    }
}

