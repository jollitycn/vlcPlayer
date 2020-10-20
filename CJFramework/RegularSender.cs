using CJBasic.Loggers;
using CJFramework;
using CJFramework.Server.UserManagement;
using System;
using System.Collections.Generic;
using System.Net;

internal class RegularSender : Interface40
{
    protected IAgileLogger emptyAgileLogger_0 = new EmptyAgileLogger();
    private IMessageForbidden interface39_0;
    private IAction interface6_0 = null;
    private IUserManager iuserManager_0;

    public bool imethod_0(IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return this.PostMessage(interface37_0, interface37_0.Header.DestUserID, actionTypeOnChannelIsBusy_0);
    }

    public bool PostMessage(IMessageHandler interface37_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        try
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 == null)
            {
                return false;
            }
            IPEndPoint userAddress = this.iuserManager_0.GetUserAddress(string_0);
            if (userAddress == null)
            {
                return this.vmethod_1(interface37_0, string_0, true, actionTypeOnChannelIsBusy_0);
            }
            return this.interface6_0.PostMessageToClient(userAddress, interface2, actionTypeOnChannelIsBusy_0);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.PostMessage", ErrorLevel.Standard);
            return false;
        }
    }

    public void PostMessage(IMessageHandler interface37_0, IEnumerable<string> ienumerable_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if ((interface37_0 != null) && (ienumerable_0 != null))
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 != null)
            {
                List<string> foreigners = null;
                foreach (string str in ienumerable_0)
                {
                    try
                    {
                        IPEndPoint userAddress = this.iuserManager_0.GetUserAddress(str);
                        if (userAddress == null)
                        {
                            if (foreigners == null)
                            {
                                foreigners = new List<string>();
                            }
                            foreigners.Add(str);
                        }
                        else
                        {
                            this.interface6_0.PostMessageToClient(userAddress, interface2, actionTypeOnChannelIsBusy_0);
                        }
                    }
                    catch (Exception exception)
                    {
                        this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.PostMessage", ErrorLevel.Standard);
                    }
                }
                if (foreigners != null)
                {
                    this.vmethod_0(interface37_0, foreigners, true, actionTypeOnChannelIsBusy_0);
                }
            }
        }
    }

    public bool PostMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        try
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 == null)
            {
                return false;
            }
            return this.interface6_0.PostMessageToClient(ipendPoint_0, interface2, actionTypeOnChannelIsBusy_0);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.PostMessage", ErrorLevel.Standard);
            return false;
        }
    }

    public void method_0(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_1(IAction interface6_1)
    {
        this.interface6_0 = interface6_1;
    }

    public void method_2(IMessageForbidden interface39_1)
    {
        this.interface39_0 = interface39_1;
    }

    public void method_3(IAgileLogger iagileLogger_0)
    {
        this.emptyAgileLogger_0 = iagileLogger_0 ?? new EmptyAgileLogger();
    }

    public bool SendMessage(IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return this.SendMessage(interface37_0, interface37_0.Header.DestUserID, actionTypeOnChannelIsBusy_0);
    }

    public void SendMessage(IMessageHandler interface37_0, IEnumerable<string> ienumerable_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        if ((interface37_0 != null) && (ienumerable_0 != null))
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 != null)
            {
                List<string> foreigners = null;
                foreach (string str in ienumerable_0)
                {
                    try
                    {
                        IPEndPoint userAddress = this.iuserManager_0.GetUserAddress(str);
                        if (userAddress == null)
                        {
                            if (foreigners == null)
                            {
                                foreigners = new List<string>();
                            }
                            foreigners.Add(str);
                        }
                        else
                        {
                            this.interface6_0.SendMessageToClient(userAddress, interface2, actionTypeOnChannelIsBusy_0);
                        }
                    }
                    catch (Exception exception)
                    {
                        this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.SendMessage", ErrorLevel.Standard);
                    }
                }
                if (foreigners != null)
                {
                    this.vmethod_0(interface37_0, foreigners, false, actionTypeOnChannelIsBusy_0);
                }
            }
        }
    }

    public bool SendMessage(IMessageHandler interface37_0, IPEndPoint ipendPoint_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        try
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 == null)
            {
                return false;
            }
            return this.interface6_0.SendMessageToClient(ipendPoint_0, interface2, actionTypeOnChannelIsBusy_0);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.SendMessage", ErrorLevel.Standard);
            return false;
        }
    }

    public bool SendMessage(IMessageHandler interface37_0, string string_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        try
        {
            IMessageHandler interface2 = this.interface39_0.imethod_3(interface37_0);
            if (interface2 == null)
            {
                return false;
            }
            IPEndPoint userAddress = this.iuserManager_0.GetUserAddress(string_0);
            if (userAddress == null)
            {
                return this.vmethod_1(interface37_0, string_0, false, actionTypeOnChannelIsBusy_0);
            }
            return this.interface6_0.SendMessageToClient(userAddress, interface2, actionTypeOnChannelIsBusy_0);
        }
        catch (Exception exception)
        {
            this.emptyAgileLogger_0.Log(exception, "CJFramework.Server.RegularSender.SendMessage", ErrorLevel.Standard);
            return false;
        }
    }

    protected virtual void vmethod_0(IMessageHandler interface37_0, IEnumerable<string> foreigners, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
    }

    protected virtual bool vmethod_1(IMessageHandler interface37_0, string string_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0)
    {
        return false;
    }
}

