namespace CJPlus.Serialization
{
    using CJBasic;
    using CJBasic.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;

    public abstract class BaseCompactSerializer : GInterface9
    {
        protected BaseCompactSerializer()
        {
        }

        public T Deserialize<T>(byte[] buff, int startIndex) where T: new()
        {
            Type type = typeof(T);
            if (buff == null)
            {
                throw new NullReferenceException(string.Format("buff is null  --  on Deserializing Type {0} !", type));
            }
            int offset = startIndex;
            return (T) this.DoDeserialize(type, buff, ref offset);
        }

        protected object DoDeserialize(Type type, byte[] buff, ref int offset)
        {
            int num;
            object obj2;
            int num3;
            int num4;
            if (type == typeof(object))
            {
                return null;
            }
            if (type == typeof(Font))
            {
                SimpleFont font = (SimpleFont) this.DoDeserialize(typeof(SimpleFont), buff, ref offset);
                if (font == null)
                {
                    return null;
                }
                return font.GetFont();
            }
            if (ByteConverter.SupportType(type))
            {
                return ByteConverter.Parse(type, buff, ref offset);
            }
            if (type == typeof(Color))
            {
                Color color = Color.FromArgb(buff[offset], buff[offset + 1], buff[offset + 2]);
                offset += 3;
                return color;
            }
            if (type == typeof(string))
            {
                int count = ByteConverter.Parse<int>(buff, ref offset);
                string str = null;
                if (count == 0)
                {
                    return string.Empty;
                }
                if (count > -1)
                {
                    str = Encoding.UTF8.GetString(buff, offset, count);
                    offset += count;
                }
                return str;
            }
            if (type == typeof(byte[]))
            {
                num = ByteConverter.Parse<int>(buff, ref offset);
                byte[] dst = null;
                if (num > -1)
                {
                    dst = new byte[num];
                    Buffer.BlockCopy(buff, offset, dst, 0, num);
                    offset += num;
                }
                return dst;
            }
            if ((type == typeof(Image)) || type.IsSubclassOf(typeof(Image)))
            {
                num = ByteConverter.Parse<int>(buff, ref offset);
                Image image = null;
                if (num > -1)
                {
                    bool flag = BitConverter.ToBoolean(buff, offset);
                    offset++;
                    if (flag)
                    {
                        image = (Image) SerializeHelper.DeserializeBytes(buff, offset, num);
                    }
                    else
                    {
                        byte[] buffer2 = new byte[num];
                        Buffer.BlockCopy(buff, offset, buffer2, 0, num);
                        image = ImageHelper.Convert(buffer2);
                    }
                    offset += num;
                }
                return image;
            }
            if (type.IsGenericType && ((type.GetGenericTypeDefinition() == typeof(IList<>)) || (type.GetGenericTypeDefinition() == typeof(List<>))))
            {
                num3 = ByteConverter.Parse<int>(buff, ref offset);
                IList list = null;
                if (num3 > -1)
                {
                    Type type2 = type.GetGenericArguments()[0];
                    list = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { type2 }));
                    for (num4 = 0; num4 < num3; num4++)
                    {
                        object obj3 = this.DoDeserialize(type2, buff, ref offset);
                        list.Add(obj3);
                    }
                }
                return list;
            }
            if (type.IsGenericType && ((type.GetGenericTypeDefinition() == typeof(IDictionary<,>)) || (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))))
            {
                num3 = ByteConverter.Parse<int>(buff, ref offset);
                IDictionary dictionary = null;
                if (num3 > -1)
                {
                    Type type3 = type.GetGenericArguments()[0];
                    Type type4 = type.GetGenericArguments()[1];
                    dictionary = (IDictionary) Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(new Type[] { type3, type4 }));
                    for (num4 = 0; num4 < num3; num4++)
                    {
                        object key = this.DoDeserialize(type3, buff, ref offset);
                        object obj5 = this.DoDeserialize(type4, buff, ref offset);
                        dictionary.Add(key, obj5);
                    }
                }
                return dictionary;
            }
            if (type.IsArray)
            {
                throw new Exception(string.Format("CompactSerializer don't support Type {0} ! ", type));
            }
            try
            {
                obj2 = this.DoDeserializeComplicatedType(type, buff, ref offset);
            }
            catch (Exception exception)
            {
                throw new SerializeException(string.Format("{0}  --  on Deserializing Type {1} ! BufferLen:{2} ,Offset:{3}", new object[] { exception.Message, type, buff.Length, (int) offset }), exception);
            }
            return obj2;
        }

        protected abstract object DoDeserializeComplicatedType(Type type, byte[] buff, ref int offset);
        protected void DoSerialize(MemoryStream stream, Type type, object obj)
        {
            if (type != typeof(object))
            {
                byte[] buffer5;
                if (type == typeof(Font))
                {
                    if (obj != null)
                    {
                        obj = new SimpleFont((Font) obj);
                    }
                    type = typeof(SimpleFont);
                }
                if (ByteConverter.SupportType(type))
                {
                    buffer5 = ByteConverter.ToBytes(type, obj);
                    stream.Write(buffer5, 0, buffer5.Length);
                }
                else if (type == typeof(Color))
                {
                    Color color = (Color) obj;
                    byte[] bytes = BitConverter.GetBytes((short) color.R);
                    byte[] buffer3 = BitConverter.GetBytes((short) color.G);
                    byte[] buffer4 = BitConverter.GetBytes((short) color.B);
                    stream.Write(bytes, 0, 1);
                    stream.Write(buffer3, 0, 1);
                    stream.Write(buffer4, 0, 1);
                }
                else if (type == typeof(string))
                {
                    if (obj == null)
                    {
                        buffer5 = ByteConverter.ToBytes<int>(-1);
                        stream.Write(buffer5, 0, buffer5.Length);
                    }
                    else
                    {
                        byte[] buffer8 = Encoding.UTF8.GetBytes(obj.ToString());
                        byte[] buffer9 = ByteConverter.ToBytes<int>(buffer8.Length);
                        stream.Write(buffer9, 0, buffer9.Length);
                        stream.Write(buffer8, 0, buffer8.Length);
                    }
                }
                else
                {
                    byte[] buffer;
                    byte[] buffer7;
                    if (type == typeof(byte[]))
                    {
                        if (obj == null)
                        {
                            buffer5 = ByteConverter.ToBytes<int>(-1);
                            stream.Write(buffer5, 0, buffer5.Length);
                        }
                        else
                        {
                            buffer = (byte[]) obj;
                            buffer7 = ByteConverter.ToBytes<int>(buffer.Length);
                            stream.Write(buffer7, 0, buffer7.Length);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    else if ((type == typeof(Image)) || type.IsSubclassOf(typeof(Image)))
                    {
                        if (obj == null)
                        {
                            buffer5 = ByteConverter.ToBytes<int>(-1);
                            stream.Write(buffer5, 0, buffer5.Length);
                        }
                        else
                        {
                            buffer = null;
                            bool flag = false;
                            Image image = (Image) obj;
                            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
                            if (image.GetFrameCount(dimension) > 1)
                            {
                                flag = true;
                                buffer = SerializeHelper.SerializeObject(image);
                            }
                            else
                            {
                                buffer = ImageHelper.Convert(image);
                            }
                            buffer7 = ByteConverter.ToBytes<int>(buffer.Length);
                            stream.Write(buffer7, 0, buffer7.Length);
                            stream.Write(BitConverter.GetBytes(flag), 0, 1);
                            stream.Write(buffer, 0, buffer.Length);
                        }
                    }
                    else
                    {
                        byte[] buffer6;
                        if (type.IsGenericType && ((type.GetGenericTypeDefinition() == typeof(IList<>)) || (type.GetGenericTypeDefinition() == typeof(List<>))))
                        {
                            if (obj == null)
                            {
                                buffer5 = ByteConverter.ToBytes<int>(-1);
                                stream.Write(buffer5, 0, 4);
                            }
                            else
                            {
                                Type type4 = type.GetGenericArguments()[0];
                                IList list = (IList) obj;
                                buffer6 = ByteConverter.ToBytes<int>(list.Count);
                                stream.Write(buffer6, 0, 4);
                                for (int i = 0; i < list.Count; i++)
                                {
                                    object obj1 = list[i];
                                    this.DoSerialize(stream, type4, list[i]);
                                }
                            }
                        }
                        else if (type.IsGenericType && ((type.GetGenericTypeDefinition() == typeof(IDictionary<,>)) || (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))))
                        {
                            if (obj == null)
                            {
                                buffer5 = ByteConverter.ToBytes<int>(-1);
                                stream.Write(buffer5, 0, 4);
                            }
                            else
                            {
                                Type type2 = type.GetGenericArguments()[0];
                                Type type3 = type.GetGenericArguments()[1];
                                ICollection is2 = (ICollection) obj;
                                buffer6 = ByteConverter.ToBytes<int>(is2.Count);
                                stream.Write(buffer6, 0, 4);
                                foreach (object obj2 in is2)
                                {
                                    object property = ReflectionHelper.GetProperty(obj2, "Key");
                                    object obj4 = ReflectionHelper.GetProperty(obj2, "Value");
                                    this.DoSerialize(stream, type2, property);
                                    this.DoSerialize(stream, type3, obj4);
                                }
                            }
                        }
                        else
                        {
                            if (type.IsArray)
                            {
                                throw new Exception(string.Format("CompactSerializer don't support Type {0} ! ", type));
                            }
                            this.DoSerializeComplicatedType(type, obj, stream);
                        }
                    }
                }
            }
        }

        protected abstract void DoSerializeComplicatedType(Type type, object obj, MemoryStream stream);
        public byte[] Serialize<T>(T obj)
        {
            Type type = typeof(T);
            return this.Serialize(type, obj);
        }

        public byte[] Serialize(Type type, object obj)
        {
            MemoryStream stream = new MemoryStream();
            this.DoSerialize(stream, type, obj);
            return stream.ToArray();
        }
    }
}

