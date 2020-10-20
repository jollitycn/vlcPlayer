using CJFramework;
using System;

[Serializable]
internal class DotNETHeader : ICloneable, IHeader, IHeader4
{
    private int messageType;
    private int messageID;
    private string userID;
    private string destUserID;

    public DotNETHeader()
    {
        this.destUserID = "";
        this.messageID = 0;
    }

    public DotNETHeader(string string_2, int int_2, string string_3, int int_3)
    {
        this.destUserID = "";
        this.messageID = 0;
        this.MessageType = int_2;
        this.UserID = string_2;
        this.messageID = int_3;
        this.DestUserID = string_3;
    }

    public object Clone()
    {
        return base.MemberwiseClone();
    }
     

    public ClientType GetClientType()
    {
        return ClientType.DotNET;
    }

    public void SetClientType(ClientType clientType_0)
    {
    }

    public Interface10 imethod_2()
    {
        return Class84.smethod_0();
    } 

    public string DestUserID
    {
        get
        {
            return this.destUserID;
        }
        set
        {
            this.destUserID = value;
        }
    }

    public int MessageID
    {
        get
        {
            return this.messageID;
        }
        set
        {
            this.messageID = value;
        }
    }

    public int MessageType
    {
        get
        {
            return this.messageType;
        }
        set
        {
            this.messageType = value;
        }
    }

    public string UserID
    {
        get
        {
            return this.userID;
        }
        set
        {
            this.userID = value;
        }
    }
}

