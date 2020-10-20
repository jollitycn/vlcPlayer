using CJBasic;
using CJBasic.Loggers;
using CJFramework.Server;
using CJFramework.Server.UserManagement;
using System;

internal class Class17
{
    private ISecurityLogger isecurityLogger_0;
    private IUserManager iuserManager_0;

    public Class17()
    {
    }

    public Class17(IUserManager iuserManager_1, ISecurityLogger isecurityLogger_1)
    {
        this.iuserManager_0 = iuserManager_1;
        this.isecurityLogger_0 = isecurityLogger_1;
    }

    public void method_0(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_1(ISecurityLogger isecurityLogger_1)
    {
        this.isecurityLogger_0 = isecurityLogger_1;
    }

    public void method_2()
    {
        this.iuserManager_0.SomeOneConnected += new CbGeneric<UserData>(this.method_4);
        this.iuserManager_0.SomeOneDisconnected += new CbGeneric<UserData, DisconnectedType>(this.method_3);
    }

    private void method_3(UserData userData_0, DisconnectedType disconnectedType_0)
    {
        this.isecurityLogger_0.Log(userData_0.UserID, userData_0.Address.ToString(), string.Format("Disconnected-{0}", disconnectedType_0), string.Format("LogonTime:{0}", userData_0.TimeLogon));
    }

    private void method_4(UserData userData_0)
    {
        this.isecurityLogger_0.Log(userData_0.UserID, userData_0.Address.ToString(), "Connected", "");
    }
}

