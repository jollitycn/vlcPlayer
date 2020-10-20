using CJFramework.Server.UserManagement;
using System;
using System.Collections.Generic;

internal class Class119
{
    private IDateTime interface42_0;
    private IUserManager iuserManager_0;
    private DateTime? nullable_0;
    private Random random_0 = new Random();

    public Class119(IDateTime interface42_1, IUserManager iuserManager_1)
    {
        this.interface42_0 = interface42_1;
        this.iuserManager_0 = iuserManager_1;
    }

    public bool? method_0()
    {
        if (!AuthorizeTool.bool_1)
        {
            return false;
        }
        int num = 3;
        try
        {
            List<string> onlineUserList = this.iuserManager_0.GetOnlineUserList();
            if (onlineUserList.Count < num)
            {
                return null;
            }
            int num2 = this.random_0.Next(0, onlineUserList.Count);
            List<DateTime> list2 = new List<DateTime>();
            for (int i = 0; i < onlineUserList.Count; i++)
            {
                int num4 = (num2 + i) % onlineUserList.Count;
                DateTime? nullable3 = this.GetTime(onlineUserList[num4]);
                if (nullable3.HasValue)
                {
                    list2.Add(nullable3.Value);
                }
                if (list2.Count >= num)
                {
                    break;
                }
            }
            if (list2.Count < num)
            {
                return null;
            }
            int num5 = 0;
            foreach (DateTime time in list2)
            {
                if (time > this.method_1())
                {
                    num5++;
                }
            }
            return new bool?(num5 >= (num - 1));
        }
        catch
        {
            return null;
        }
    }

    private DateTime method_1()
    {
        if (!this.nullable_0.HasValue)
        {
            Class120 class2 = Class120.smethod_0(Class62.string_2);
            this.nullable_0 = new DateTime?(class2.method_0());
        }
        return this.nullable_0.Value;
    }

    private DateTime? GetTime(string string_0)
    {
        try
        {
            return this.interface42_0.GetTime(string_0);
        }
        catch
        {
            return null;
        }
    }
}

