using System;

internal interface Interface13 : IDisposable
{
    IMessageHandler PickupResponse(int int_0, int int_1);
    void PushResponse(IMessageHandler interface37_0);
    void RegisterCallback(int int_0, int int_1, Delegate0 delegate0_0, object object_0);

    int Int32_0 { get; }

    int TimeoutSec { get; }
}

