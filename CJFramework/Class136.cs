using CJBasic;
using CJBasic.Helpers;
using CJPlus.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

internal class Class136 : BaseCompactSerializer
{
    private static Class136 class136_0 = new Class136();
    [CompilerGenerated]
    private static Comparison<FieldInfo> comparison_0;
    private Dictionary<Type, Class138> dictionary_0 = new Dictionary<Type, Class138>();

    protected override object DoDeserializeComplicatedType(Type type, byte[] buff, ref int offset)
    {
        int num = ByteConverter.Parse<int>(buff, ref offset);
        object obj2 = null;
        if (num > -1)
        {
            obj2 = Activator.CreateInstance(type);
            Class138 class2 = this.method_0(type);
            for (int i = 0; i < class2.method_0().Length; i++)
            {
                object val = base.DoDeserialize(class2.method_0()[i].FieldType, buff, ref offset);
                ReflectionHelper.SetFieldValue(obj2, class2.method_0()[i].Name, val);
            }
        }
        return obj2;
    }

    protected override void DoSerializeComplicatedType(Type type, object obj, MemoryStream stream)
    {
        if (obj == null)
        {
            byte[] buffer3 = ByteConverter.ToBytes<int>(-1);
            stream.Write(buffer3, 0, buffer3.Length);
        }
        else
        {
            Class138 class2 = this.method_0(type);
            MemoryStream stream2 = new MemoryStream();
            for (int i = 0; i < class2.method_0().Length; i++)
            {
                object fieldValue = ReflectionHelper.GetFieldValue(obj, class2.method_0()[i].Name);
                base.DoSerialize(stream2, class2.method_0()[i].FieldType, fieldValue);
            }
            byte[] buffer = stream2.ToArray();
            byte[] buffer2 = ByteConverter.ToBytes<int>(buffer.Length);
            stream.Write(buffer2, 0, buffer2.Length);
            stream.Write(buffer, 0, buffer.Length);
        }
    }

    private Class138 method_0(Type type_0)
    {
        lock (this.dictionary_0)
        {
            if (this.dictionary_0.ContainsKey(type_0))
            {
                return this.dictionary_0[type_0];
            }
            FieldInfo[] fields = type_0.GetFields(BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            List<FieldInfo> list = new List<FieldInfo>();
            foreach (FieldInfo info in fields)
            {
                if (info.GetCustomAttributes(typeof(NotSerializedCompactlyAttribute), true).Length <= 0)
                {
                    list.Add(info);
                }
            }
            if (comparison_0 == null)
            {
                comparison_0 = new Comparison<FieldInfo>(Class136.smethod_1);
            }
            list.Sort(comparison_0);
            Class138 class3 = new Class138(list.ToArray());
            this.dictionary_0.Add(type_0, class3);
            return class3;
        }
    }

    public static GInterface9 smethod_0()
    {
        return class136_0;
    }

    [CompilerGenerated]
    private static int smethod_1(MemberInfo memberInfo_0, MemberInfo memberInfo_1)
    {
        return memberInfo_0.Name.CompareTo(memberInfo_1.Name);
    }
}

