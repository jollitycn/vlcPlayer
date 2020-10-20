namespace CJPlus.Serialization
{
    using CJBasic;
    using CJBasic.Emit.ForEntity;
    using CJBasic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class CompactPropertySerializer : BaseCompactSerializer
    {
        [CompilerGenerated]
        private static Comparison<PropertyInfo> comparison_0;
        private static GInterface9 ginterface9_0 = new CompactPropertySerializer();
        private Dictionary<Type, Class137> YkdcNurUyP = new Dictionary<Type, Class137>();

        protected override object DoDeserializeComplicatedType(Type type, byte[] buff, ref int offset)
        {
            int num = ByteConverter.Parse<int>(buff, ref offset);
            object obj2 = null;
            if (num > -1)
            {
                obj2 = Activator.CreateInstance(type);
                Class137 class2 = this.xrxcLalgu3(type);
                for (int i = 0; i < class2.method_1().Length; i++)
                {
                    object obj3 = base.DoDeserialize(class2.method_1()[i].PropertyType, buff, ref offset);
                    this.method_0(type, class2.method_0(), obj2, class2.method_1()[i].Name, obj3);
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
                Class137 class2 = this.xrxcLalgu3(type);
                MemoryStream stream2 = new MemoryStream();
                for (int i = 0; i < class2.method_1().Length; i++)
                {
                    object obj2 = class2.method_0().GetValue(obj, class2.method_1()[i].Name);
                    base.DoSerialize(stream2, class2.method_1()[i].PropertyType, obj2);
                }
                byte[] buffer = stream2.ToArray();
                byte[] buffer2 = ByteConverter.ToBytes<int>(buffer.Length);
                stream.Write(buffer2, 0, buffer2.Length);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public void GetFromat(string fieldName, Type type, ref int startOffet, StringBuilder offsetBuilder, StringBuilder formats)
        {
            if (ByteConverter.SupportType(type))
            {
                object obj2 = Activator.CreateInstance(type);
                byte[] buffer = ByteConverter.ToBytes(type, obj2);
                formats.Append(string.Format("FieldName:{0,-20} ;", fieldName));
                formats.Append(string.Format("Type:{0,-20} ;", TypeHelper.GetClassSimpleName(type)));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", buffer.Length));
                formats.Append("\n");
                startOffet += buffer.Length;
            }
            else if (type == typeof(string))
            {
                formats.Append(string.Format("FieldName:{0,-20} ;", fieldName + "Len"));
                formats.Append(string.Format("Type:{0,-20} ;", "int"));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", 4));
                formats.Append("\n");
                startOffet += 4;
                formats.Append(string.Format("FieldName:{0,-20} ;", fieldName));
                formats.Append(string.Format("Type:{0,-20} ;", TypeHelper.GetClassSimpleName(type)));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", fieldName + "Len"));
                formats.Append("\n");
                offsetBuilder.Append(string.Format("+{0}Len", fieldName));
            }
            else if (type == typeof(byte[]))
            {
                formats.Append(string.Format("FieldName:{0,-20} ;", fieldName + "Len"));
                formats.Append(string.Format("Type:{0,-20} ;", "int"));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", 4));
                formats.Append("\n");
                startOffet += 4;
                formats.Append(string.Format("FieldName:{0,-20} ;", fieldName));
                formats.Append(string.Format("Type:{0,-20} ;", TypeHelper.GetClassSimpleName(type)));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", fieldName + "Len"));
                formats.Append("\n");
                offsetBuilder.Append(string.Format("+{0}Len", fieldName));
            }
            else if (((!type.IsGenericType || ((type.GetGenericTypeDefinition() != typeof(IList<>)) && (type.GetGenericTypeDefinition() != typeof(List<>)))) && (!type.IsGenericType || ((type.GetGenericTypeDefinition() != typeof(IDictionary<,>)) && (type.GetGenericTypeDefinition() != typeof(Dictionary<,>))))) && (!type.IsGenericType && !type.IsArray))
            {
                string classSimpleName = TypeHelper.GetClassSimpleName(type);
                formats.Append(string.Format("FieldName:{0,-20} ;", classSimpleName + "Len"));
                formats.Append(string.Format("Type:{0,-20} ;", "int"));
                formats.Append(string.Format("StartOffet:{0,-20} ;", ((int) startOffet).ToString() + offsetBuilder.ToString()));
                formats.Append(string.Format("Length:{0,-20} ;", 4));
                formats.Append("\n");
                startOffet += 4;
                Class137 class2 = this.xrxcLalgu3(type);
                for (int i = 0; i < class2.method_1().Length; i++)
                {
                    this.GetFromat(class2.method_1()[i].Name, class2.method_1()[i].PropertyType, ref startOffet, offsetBuilder, formats);
                }
            }
        }

        private void method_0(Type type_0, IPropertyQuicker ipropertyQuicker_0, object object_0, string string_0, object object_1)
        {
            if (type_0.IsValueType)
            {
                ReflectionHelper.SetProperty(object_0, string_0, object_1);
            }
            else
            {
                ipropertyQuicker_0.SetValue(object_0, string_0, object_1);
            }
        }

        [CompilerGenerated]
        private static int smethod_0(MemberInfo memberInfo_0, MemberInfo memberInfo_1)
        {
            return memberInfo_0.Name.CompareTo(memberInfo_1.Name);
        }

        private Class137 xrxcLalgu3(Type type_0)
        {
            lock (this.YkdcNurUyP)
            {
                if (this.YkdcNurUyP.ContainsKey(type_0))
                {
                    return this.YkdcNurUyP[type_0];
                }
                IPropertyQuicker quicker = PropertyQuickerFactory.CreatePropertyQuicker(type_0);
                List<PropertyInfo> list = new List<PropertyInfo>();
                foreach (PropertyInfo info in type_0.GetProperties())
                {
                    if ((info.CanRead && info.CanWrite) && (info.GetCustomAttributes(typeof(NotSerializedCompactlyAttribute), true).Length <= 0))
                    {
                        list.Add(info);
                    }
                }
                if (comparison_0 == null)
                {
                    comparison_0 = new Comparison<PropertyInfo>(CompactPropertySerializer.smethod_0);
                }
                list.Sort(comparison_0);
                Class137 class2 = new Class137(quicker, list.ToArray());
                this.YkdcNurUyP.Add(type_0, class2);
                return class2;
            }
        }

        public static GInterface9 Default
        {
            get
            {
                return ginterface9_0;
            }
        }
    }
}

