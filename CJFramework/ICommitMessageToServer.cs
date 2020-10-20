using CJFramework;
using System;

internal interface ICommitMessageToServer : IDisposable, IEngine
{
    AgileIPE GetAgileIPE();
    void SetAgileIPE(AgileIPE agileIPE_0);
    bool CommitMessageToServer(IMessageHandler interface37_0, bool bool_0, ActionTypeOnChannelIsBusy actionTypeOnChannelIsBusy_0);

    bool ChannelIsBusy { get; }
}

