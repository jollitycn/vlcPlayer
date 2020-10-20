using CJFramework;
using System;

internal interface IHeader : ICloneable
{
    ClientType GetClientType();
    void SetClientType(ClientType clientType_0);

    string DestUserID { get; set; }

    int MessageID { get; set; }

    int MessageType { get; set; }

    string UserID { get; set; }
}

