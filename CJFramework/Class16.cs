using CJFramework.Engine.ContractStyle.Stream;
using CJPlus.Core;
using CJPlus.Serialization;
using System;
using System.Collections.Generic;

internal class Class16 : Class14, IStreamContractHelper, IStreamContract
{
    private Dictionary<Type, SerializeStrategy> dictionary_0 = new Dictionary<Type, SerializeStrategy>();
    private Type type_0 = typeof(BaseSerializeContract);

    public override Enum6 imethod_0()
    {
        return (Enum6) 0;
    }

    public override TBody imethod_1<TBody>(IMessageHandler interface37_0) where TBody: class//, new()
    {
        MessageHandler class2 = (MessageHandler) interface37_0;
        if (class2.method_0().imethod_5() == 0)
        {
            return default(TBody);
        }
        Type type = typeof(TBody);
        if (type.IsSubclassOf(this.type_0))
        {
            return BaseSerializeContract.smethod_0<TBody>(class2);
        }
        return ((this.method_1(type) == SerializeStrategy.Property) ? CompactPropertySerializer.Default.Deserialize<TBody>(class2.Body.Data, class2.Body.Offset) : Class136.smethod_0().Deserialize<TBody>(class2.Body.Data, class2.Body.Offset));
    }

    public Interface22 imethod_10(byte[] byte_0, int int_1)
    {
        return Class41.smethod_1(byte_0, int_1);
    }

    public override IMessageHandler imethod_3<TBody>(string string_0, int int_1, TBody body, string string_1, int int_2) where TBody: class
    {
        byte[] buffer = null;
        if (body != null)
        {
            BaseSerializeContract contract = body as BaseSerializeContract;
            if (contract != null)
            {
                buffer = contract.ToStream();
            }
            else
            {
                buffer = (this.method_1(typeof(TBody)) == SerializeStrategy.Property) ? CompactPropertySerializer.Default.Serialize<TBody>(body) : Class136.smethod_0().Serialize<TBody>(body);
            }
        }
        return new MessageHandler(new Class41(string_0, int_1, (buffer == null) ? 0 : buffer.Length, string_1, int_2), buffer, 0, null);
    }

    public byte imethod_8()
    {
        return Class41.byte_0;
    }

    public int imethod_9()
    {
        return Class41.int_1;
    }

    private SerializeStrategy method_1(Type type_1)
    {
        lock (this.dictionary_0)
        {
            if (!this.dictionary_0.ContainsKey(type_1))
            {
                StreamContratAttribute[] customAttributes = (StreamContratAttribute[]) type_1.GetCustomAttributes(typeof(StreamContratAttribute), false);
                if ((customAttributes == null) || (customAttributes.Length == 0))
                {
                    this.dictionary_0.Add(type_1, SerializeStrategy.Property);
                }
                else
                {
                    this.dictionary_0.Add(type_1, customAttributes[0].SerializeStrategy);
                }
            }
            return this.dictionary_0[type_1];
        }
    }
}

