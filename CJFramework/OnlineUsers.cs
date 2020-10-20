using CJFramework.Server.UserManagement;
using System;
using System.Collections.Generic;
using System.Net;

internal sealed class OnlineUsers
{
    private IDictionary<string, UserData> idictionary_0 = new Dictionary<string, UserData>();
    private IDictionary<IPEndPoint, string> idictionary_1 = new Dictionary<IPEndPoint, string>();
    private object object_0 = new object();

    public void method_0(UserData userData_0)
    {
        lock (this.object_0)
        {
            this.idictionary_0.Add(userData_0.UserID, userData_0);
            this.idictionary_1.Add(userData_0.Address, userData_0.UserID);
        }
    }

    public void Remove(string string_0)
    {
        lock (this.object_0)
        {
            UserData data = null;
            if (this.idictionary_0.ContainsKey(string_0))
            {
                data = this.idictionary_0[string_0];
            }
            if (data != null)
            {
                this.idictionary_0.Remove(string_0);
                this.idictionary_1.Remove(data.Address);
            }
        }
    }

    public List<UserData> GetUserDatas()
    {
        lock (this.object_0)
        {
            return new List<UserData>(this.idictionary_0.Values);
        }
    }

    public int Count()
    {
        return this.idictionary_0.Count;
    }

    public string GetUserID(IPEndPoint ipendPoint_0)
    {
        lock (this.object_0)
        {
            if (!this.idictionary_1.ContainsKey(ipendPoint_0))
            {
                return null;
            }
            return this.idictionary_1[ipendPoint_0];
        }
    }

    public UserData GetUserData(string string_0)
    {
        lock (this.object_0)
        {
            if (this.idictionary_0.ContainsKey(string_0))
            {
                return this.idictionary_0[string_0];
            }
            return null;
        }
    }

    public UserData GetUserData(IPEndPoint ipendPoint_0)
    {
        lock (this.object_0)
        {
            if (!this.idictionary_1.ContainsKey(ipendPoint_0))
            {
                return null;
            }
            return this.idictionary_0[this.idictionary_1[ipendPoint_0]];
        }
    }

    public bool Contains(string string_0)
    {
        return this.idictionary_0.ContainsKey(string_0);
    }

    public bool Contains(IPEndPoint ipendPoint_0)
    {
        return this.idictionary_1.ContainsKey(ipendPoint_0);
    }

    public IPEndPoint GetAddress(string string_0)
    {
        lock (this.object_0)
        {
            if (this.idictionary_0.ContainsKey(string_0))
            {
                return this.idictionary_0[string_0].Address;
            }
            return null;
        }
    }

    public void Clear()
    {
        lock (this.object_0)
        {
            this.idictionary_0.Clear();
            this.idictionary_1.Clear();
        }
    }

    public List<string> GetUserIDs()
    {
        lock (this.object_0)
        {
            return new List<string>(this.idictionary_0.Keys);
        }
    }
}

