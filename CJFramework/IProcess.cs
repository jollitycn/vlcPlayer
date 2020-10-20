using System;

internal interface IProcess
{
    bool CanProcess(int int_0);
    IMessageHandler ProcessMessage(IMessageHandler interface37_0);
}

