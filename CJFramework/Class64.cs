using CJPlus.Advanced;
using CJPlus.Application.Basic.Server;
using CJPlus.Application.Contacts.Server;
using CJPlus.Application.CustomizeInfo;
using CJPlus.Application.Friends.Server;
using CJPlus.Application.Group.Server;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class Class64 : ICustomizeHandler, IBasicHandler, IGroupManager, IFriendsManager, IContactsManager
{
    private Class66 class66_0 = new Class66();
    private IBasicHandler ibasicHandler_0;
    private IContactsManager icontactsManager_0;
    private ICustomizeHandler icustomizeHandler_0;
    private IFriendsManager ifriendsManager_0;
    private IGroupManager igroupManager_0;

    public List<string> GetContacts(string userID)
    {
        List<string> contacts;
        int num = this.class66_0.method_0(-10005, InformationStyle.GetFriendsList);
        bool flag = false;
        try
        {
            if (this.icontactsManager_0 == null)
            {
                return new List<string>();
            }
            contacts = this.icontactsManager_0.GetContacts(userID);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return contacts;
    }

    public List<string> GetFriendsList(string userID, string tag)
    {
        List<string> friendsList;
        int num = this.class66_0.method_0(-10001, InformationStyle.GetFriendsList);
        bool flag = false;
        try
        {
            if (this.ifriendsManager_0 == null)
            {
                return new List<string>();
            }
            friendsList = this.ifriendsManager_0.GetFriendsList(userID, tag);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return friendsList;
    }

    public List<string> GetGroupmates(string userID)
    {
        List<string> groupmates;
        int num = this.class66_0.method_0(-10003, InformationStyle.GetGroupmates);
        bool flag = false;
        try
        {
            if (this.igroupManager_0 == null)
            {
                return new List<string>();
            }
            groupmates = this.igroupManager_0.GetGroupmates(userID);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return groupmates;
    }

    public List<string> GetGroupMemberList(string groupID)
    {
        List<string> groupMemberList;
        int num = this.class66_0.method_0(-10004, InformationStyle.GetGroupMembers);
        bool flag = false;
        try
        {
            if (this.icontactsManager_0 == null)
            {
                return new List<string>();
            }
            groupMemberList = this.icontactsManager_0.GetGroupMemberList(groupID);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return groupMemberList;
    }

    public List<string> GetGroupMembers(string groupID)
    {
        List<string> groupMembers;
        int num = this.class66_0.method_0(-10002, InformationStyle.GetGroupMembers);
        bool flag = false;
        try
        {
            if (this.igroupManager_0 == null)
            {
                return new List<string>();
            }
            groupMembers = this.igroupManager_0.GetGroupMembers(groupID);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return groupMembers;
    }

    public void HandleInformation(string sourceUserID, int informationType, byte[] info)
    {
        int num = this.class66_0.method_0(informationType, InformationStyle.Common);
        bool flag = false;
        try
        {
            this.icustomizeHandler_0.HandleInformation(sourceUserID, informationType, info);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
    }

    public byte[] HandleQuery(string sourceUserID, int requestInfoType, byte[] requestInfo)
    {
        byte[] buffer;
        int num = this.class66_0.method_0(requestInfoType, InformationStyle.Query);
        bool flag = false;
        try
        {
            buffer = this.icustomizeHandler_0.HandleQuery(sourceUserID, requestInfoType, requestInfo);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return buffer;
    }

    public void ieduNnurne(ICustomizeHandler icustomizeHandler_1, IBasicHandler ibasicHandler_1, IGroupManager igroupManager_1, IFriendsManager ifriendsManager_1, IContactsManager icontactsManager_1)
    {
        this.icustomizeHandler_0 = icustomizeHandler_1;
        this.ibasicHandler_0 = ibasicHandler_1;
        this.igroupManager_0 = igroupManager_1;
        this.ifriendsManager_0 = ifriendsManager_1;
        this.icontactsManager_0 = icontactsManager_1;
    }

    internal Class66 method_0()
    {
        return this.class66_0;
    }

    public bool VerifyUser(string systemToken, string userID, string password, out string failureCause)
    {
        bool flag2;
        int num = this.class66_0.method_0(-10000, InformationStyle.Login);
        bool flag = false;
        try
        {
            flag2 = this.ibasicHandler_0.VerifyUser(systemToken, userID, password, out failureCause);
        }
        catch
        {
            flag = true;
            throw;
        }
        finally
        {
            this.class66_0.method_1(num, flag);
        }
        return flag2;
    }
}

