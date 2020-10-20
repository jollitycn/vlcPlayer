using System;

internal interface IStreamContractHelper : IStreamContract
{
    Enum6 imethod_0();
    TBody imethod_1<TBody>(IMessageHandler interface37_0) where TBody: class, new();
    IMessageHandler imethod_2<TBody>(IHeader interface21_0, TBody body) where TBody: class;
    IMessageHandler imethod_3<TBody>(string string_0, int int_0, TBody body, string string_1, int int_1) where TBody: class;
    IMessageHandler imethod_4<TBody>(string string_0, int int_0, TBody body, string string_1) where TBody: class;
    IMessageHandler imethod_5<TBody>(string string_0, int int_0, TBody body) where TBody: class;
    IMessageHandler imethod_6(string string_0, int int_0);
    IHeader imethod_7(IHeader interface21_0);
}

