namespace CJBasic.Helpers
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Text;
    using System.Xml.Serialization;

    public static class SerializeHelper
    {
        public static object DeserializeBytes(byte[] buff, int index, int count)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(buff, index, count);
            object obj2 = formatter.Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        public static object DeserializeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            IFormatter formatter = new SoapFormatter();
            MemoryStream serializationStream = new MemoryStream(bytes, 0, bytes.Length);
            object obj2 = formatter.Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        public static T ObjectXml<T>(string str)
        {
            return (T) ObjectXml(str, typeof(T));
        }

        public static object ObjectXml(string str, Type targetType)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            XmlSerializer serializer = new XmlSerializer(targetType);
            MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length);
            object obj2 = serializer.Deserialize(stream);
            stream.Close();
            return obj2;
        }

        public static object ReadFromFile(string filePath)
        {
            byte[] buff = FileHelper.ReadFileReturnBytes(filePath);
            return DeserializeBytes(buff, 0, buff.Length);
        }

        public static void SaveToFile(object obj, string filePath)
        {
            FileStream serializationStream = new FileStream(filePath, FileMode.OpenOrCreate);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, obj);
            serializationStream.Flush();
            serializationStream.Close();
        }

        public static byte[] SerializeObject(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, obj);
            byte[] buffer = serializationStream.ToArray();
            serializationStream.Close();
            return buffer;
        }

        public static void SerializeObject(object obj, ref byte[] buff, int offset)
        {
            byte[] buffer = SerializeObject(obj);
            for (int i = 0; i < buffer.Length; i++)
            {
                buff[offset + i] = buffer[i];
            }
        }

        public static string SerializeObjectToString(object obj)
        {
            IFormatter formatter = new SoapFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, obj);
            serializationStream.Position = 0L;
            string str = new StreamReader(serializationStream).ReadToEnd();
            serializationStream.Close();
            return str;
        }

        public static string XmlObject(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.Serialize((Stream) stream, obj);
            stream.Position = 0L;
            string str = new StreamReader(stream).ReadToEnd();
            stream.Close();
            return str;
        }
    }
}

