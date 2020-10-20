using CJBasic.Collections;
using CJBasic.Helpers;
using CJPlus.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

internal class Class40 : IServiceTypeNameMatcher
{
    private Class141 class141_0;
    private IDictionary<int, string> idictionary_0;
    private List<IMessageTypeRoom> list_0;

    public Class40()
    {
        this.idictionary_0 = new Dictionary<int, string>();
        this.list_0 = new List<IMessageTypeRoom>();
        this.class141_0 = null;
    }

    public Class40(IEnumerable<IMessageTypeRoom> messageTypeRooms, Class141 class141_1)
    {
        this.idictionary_0 = new Dictionary<int, string>();
        this.list_0 = new List<IMessageTypeRoom>();
        this.class141_0 = null;
        this.list_0 = new List<IMessageTypeRoom>(messageTypeRooms);
        this.class141_0 = class141_1;
    }

    public string GetServiceName(int messageType)
    {
        if (this.idictionary_0.ContainsKey(messageType))
        {
            return this.idictionary_0[messageType];
        }
        return messageType.ToString();
    }

    public void method_0(List<IMessageTypeRoom> value)
    {
        this.list_0 = value ?? new List<IMessageTypeRoom>();
    }

    public void method_1(Class141 class141_1)
    {
        this.class141_0 = class141_1;
    }

    public void method_2()
    {
        for (int i = 0; i < (this.list_0.Count - 1); i++)
        {
            IMessageTypeRoom room = this.list_0[i];
            KeyScope scope = new KeyScope(room.StartKey, room.MaxKeyValue);
            for (int j = i + 1; j < this.list_0.Count; j++)
            {
                IMessageTypeRoom room2 = this.list_0[j];
                if (scope.Intersect(new KeyScope(room2.StartKey, room2.MaxKeyValue)))
                {
                    throw new Exception(string.Format("MessageType Conflicted between [{0}] and [{1}] !", room.GetType(), room2.GetType()));
                }
            }
        }
        foreach (IMessageTypeRoom room in this.list_0)
        {
            Type t = room.GetType();
            string classSimpleName = TypeHelper.GetClassSimpleName(t);
            foreach (PropertyInfo info in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if ((info.CanWrite && (info.PropertyType == typeof(int))) && (info.Name != "StartKey"))
                {
                    int key = (int) info.GetValue(room, null);
                    string str2 = string.Format("{0}.{1}", classSimpleName, info.Name);
                    lock (this.idictionary_0)
                    {
                        this.idictionary_0.Remove(key);
                        this.idictionary_0.Add(key, str2);
                    }
                }
            }
        }
        if (this.class141_0 != null)
        {
            foreach (IMessageTypeRoom room3 in this.list_0)
            {
                foreach (int num5 in room3.PushKeyList)
                {
                    this.class141_0.method_9(num5);
                }
            }
        }
    }

    public void method_3(int int_0, string string_0)
    {
        if (!this.idictionary_0.ContainsKey(int_0))
        {
            this.idictionary_0.Add(int_0, string_0);
        }
    }
}

