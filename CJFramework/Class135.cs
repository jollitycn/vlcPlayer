using CJFramework.Server.UserManagement;
using System;
using System.Collections.Generic;

internal class Class135 : GInterface8
{
    private IUserManager iuserManager_0;

    public Class135()
    {
    }

    public Class135(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public List<string> GetOnlineUserList()
    {
        return this.iuserManager_0.GetOnlineUserList();
    }

    public UserData GetUserData(string userID)
    {
        return this.iuserManager_0.GetUserData(userID);
    }

    public bool IsUserOnLine(string userID)
    {
        return this.iuserManager_0.IsUserOnLine(userID);
    }

    public void method_0(IUserManager iuserManager_1)
    {
        this.iuserManager_0 = iuserManager_1;
    }

    public void method_1(string string_0, P2PAddress p2PAddress_0)
    {
        this.iuserManager_0.SetP2PAddress(string_0, p2PAddress_0);
    }

    public List<string> SelectOnlineUserFrom(IEnumerable<string> users)
    {
        List<string> list = new List<string>();
        if (users != null)
        {
            foreach (string str in users)
            {
                if (this.iuserManager_0.IsUserOnLine(str))
                {
                    list.Add(str);
                }
            }
        }
        return list;
    }

    public int UserCount
    {
        get
        {
            return this.iuserManager_0.UserCount;
        }
    }
}

