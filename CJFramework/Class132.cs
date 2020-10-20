using CJBasic.Loggers;
using CJFramework;
using CJFramework.Server.UserManagement;
using CJPlus.Application.P2PSession;
using System;
using System.Net;

internal class Class132 : IProcess
{
    protected EmptyAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private GInterface8 ginterface8_0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private IUserManager iuserManager_0;
    private P2PSessionMessageTypeRoom object_0 = null;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void method_0(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public void method_1(P2PSessionMessageTypeRoom p2PSessionMessageTypeRoom_0)
    {
        this.object_0 = p2PSessionMessageTypeRoom_0;
    }

    public void method_2(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public void method_3(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_4(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
    }

    public void method_5(IAgileLogger iagileLogger_0)
    {
        if (iagileLogger_0 != null)
        {
            this.emptyAgileLogger_0 = (EmptyAgileLogger) iagileLogger_0;
        }
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        IHeader interface2;
        if (interface37_0.Header.MessageType == this.object_0.P2PLogon)
        {
            P2PLogonContract contract2 = this.interface9_0.imethod_1<P2PLogonContract>(interface37_0);
            this.iuserManager_0.SetP2PAddress(interface37_0.Header.UserID, contract2.P2PAddress_0);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.ReqUserData)
        {
            ReqUserDataContract contract = this.interface9_0.imethod_1<ReqUserDataContract>(interface37_0);
            UserData userData = this.ginterface8_0.GetUserData(contract.FriendID);
            interface2 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<ResUserDataContract>(interface2, (userData == null) ? null : new ResUserDataContract(contract.FriendID, userData.P2PAddress_0));
        }
        if (interface37_0.Header.MessageType == this.object_0.InviteTcpP2P)
        {
            this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.GetMyPublicIPE)
        {
            interface2 = this.interface9_0.imethod_7(interface37_0.Header);
            IPEndPoint userAddress = this.iuserManager_0.GetUserAddress(interface37_0.Header.UserID);
            string str = userAddress.ToString();
            string str2 = userAddress.Address.ToString();
            if (!str.StartsWith(str2))
            {
                string msg = string.Format("IP地址怪异。UserID：[{0}],IPEndPoint:[{1}],IPAddres:[{2}]", interface37_0.Header.UserID, str, str2);
                this.emptyAgileLogger_0.LogWithTime(msg);
            }
            return this.interface9_0.imethod_2<PublicIPEResponseContract>(interface2, new PublicIPEResponseContract(str2.Trim(), userAddress.Port));
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_FeedbackVacancy)
        {
            this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_SynAck)
        {
            this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_Exit)
        {
            this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.Help4UDP_PMTUTestAck)
        {
            this.interface40_0.PostMessage(interface37_0, interface37_0.Header.DestUserID, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        return null;
    }
}

