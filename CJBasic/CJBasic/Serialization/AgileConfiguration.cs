namespace CJBasic.Serialization
{
    using CJBasic.Helpers;
    using System;
    using System.IO;
    using System.Xml;

    public abstract class AgileConfiguration
    {
        protected AgileConfiguration()
        {
        }

        public static AgileConfiguration Load(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                return null;
            }
            XmlDocument document = new XmlDocument();
            document.Load(configFilePath);
            return (AgileConfiguration) SpringFox.ObjectXml(document.ChildNodes[0].OuterXml);
        }

        public void Save(string configFilePath)
        {
            string text = SpringFox.XmlObject(this);
            FileHelper.GenerateFile(configFilePath, text);
        }
    }
}

