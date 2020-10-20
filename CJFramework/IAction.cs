using CJFramework;
using System;
using System.Net;

internal interface IAction : IDisposable, IEngine
{
    void imethod_18(string string_0);
    bool IsBusy(IPEndPoint ipendPoint_0);
    bool SendMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);
    bool PostMessageToClient(IPEndPoint ipendPoint_0, IMessageHandler interface37_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);

    string ServerID { get; }
}

