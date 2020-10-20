namespace CJBasic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml;

    public static class XmlHelper
    {
        public static void ConfigObject(XmlNode objNode, object target)
        {
            foreach (XmlAttribute attribute in objNode.Attributes)
            {
                ReflectionHelper.SetProperty(target, attribute.Name, attribute.Value);
            }
            foreach (XmlNode node in objNode.ChildNodes)
            {
                ReflectionHelper.SetProperty(target, node.Name, node.InnerText);
            }
        }

        public static void FillObjectNode(XmlNode objNode, object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo info in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                string val = "";
                object obj2 = info.GetValue(obj, null);
                if (obj2 != null)
                {
                    val = obj2.ToString();
                }
                SetPropertyValue(objNode, info.Name, val, XmlPropertyPosition.ChildNode);
            }
        }

        public static XmlNode GetChildNode(XmlNode obj, string childNodeName)
        {
            foreach (XmlNode node in obj.ChildNodes)
            {
                if (node.Name == childNodeName)
                {
                    return node;
                }
            }
            return null;
        }

        public static IList<XmlNode> GetChildNodes(XmlNode obj, string childNodeName)
        {
            IList<XmlNode> list = new List<XmlNode>();
            foreach (XmlNode node in obj.ChildNodes)
            {
                if (node.Name == childNodeName)
                {
                    list.Add(node);
                }
            }
            return list;
        }

        public static string GetPropertyValue(XmlNode obj, string proName)
        {
            if (obj.Attributes[proName] != null)
            {
                return obj.Attributes[proName].Value;
            }
            foreach (XmlNode node in obj.ChildNodes)
            {
                if (node.Name == proName)
                {
                    return node.InnerText;
                }
            }
            return null;
        }

        public static string GetXmlNodeString(XmlNode node)
        {
            return node.OuterXml;
        }

        public static XmlNode ParseXmlNodeString(string outXml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(outXml);
            return document.ChildNodes[0];
        }

        public static void SetPropertyValue(XmlNode objNode, string proName, string val)
        {
            SetPropertyValue(objNode, proName, val, XmlPropertyPosition.ChildNode);
        }

        public static void SetPropertyValue(XmlNode objNode, string proName, string val, XmlPropertyPosition pos)
        {
            SetPropertyValue(objNode, proName, val, pos, true);
        }

        public static void SetPropertyValue(XmlNode objNode, string proName, string val, XmlPropertyPosition pos, bool overrideExist)
        {
            if (pos == XmlPropertyPosition.ChildNode)
            {
                if (overrideExist)
                {
                    foreach (XmlNode node in objNode.ChildNodes)
                    {
                        if (node.Name == proName)
                        {
                            node.InnerText = val;
                            return;
                        }
                    }
                }
                XmlNode newChild = objNode.OwnerDocument.CreateElement(proName);
                newChild.InnerText = val;
                objNode.AppendChild(newChild);
            }
            else
            {
                if (overrideExist)
                {
                    foreach (XmlAttribute attribute in objNode.Attributes)
                    {
                        if (attribute.Name == proName)
                        {
                            attribute.Value = val;
                            return;
                        }
                    }
                }
                XmlAttribute attribute2 = objNode.OwnerDocument.CreateAttribute(proName);
                objNode.Attributes.Append(attribute2);
                attribute2.Value = val;
            }
        }
    }
}

