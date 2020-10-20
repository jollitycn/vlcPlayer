namespace CJBasic.Serialization
{
    using CJBasic.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml;

    public static class SimpleXmlConverter
    {
        private static void DoXmlSerializeObject(XmlNode curNode, PropertyInfo pro, object val)
        {
            string classSimpleName;
            XmlNode node2;
            PropertyInfo[] properties;
            if (pro.PropertyType.IsGenericType && (pro.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                string name = pro.Name;
                XmlNode newChild = curNode.OwnerDocument.CreateElement(name);
                curNode.AppendChild(newChild);
                Type t = pro.PropertyType.GetGenericArguments()[0];
                if (TypeHelper.IsSimpleType(t))
                {
                    foreach (object obj2 in (IEnumerable) val)
                    {
                        XmlHelper.SetPropertyValue(newChild, "value", obj2.ToString(), XmlPropertyPosition.ChildNode, false);
                    }
                }
                else
                {
                    foreach (object obj2 in (IEnumerable) val)
                    {
                        classSimpleName = TypeHelper.GetClassSimpleName(t);
                        node2 = curNode.OwnerDocument.CreateElement(classSimpleName);
                        newChild.AppendChild(node2);
                        properties = t.GetProperties();
                        foreach (PropertyInfo info in properties)
                        {
                            if (info.CanRead)
                            {
                                object obj3 = info.GetValue(obj2, null);
                                DoXmlSerializeObject(node2, info, obj3);
                            }
                        }
                    }
                }
            }
            else if (TypeHelper.IsSimpleType(pro.PropertyType))
            {
                string str3 = (val == null) ? "" : val.ToString();
                XmlHelper.SetPropertyValue(curNode, pro.Name, str3);
            }
            else
            {
                classSimpleName = TypeHelper.GetClassSimpleName(pro.PropertyType);
                node2 = curNode.OwnerDocument.CreateElement(classSimpleName);
                curNode.AppendChild(node2);
                properties = pro.PropertyType.GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    if (info.CanRead)
                    {
                        DoXmlSerializeObject(node2, info, info.GetValue(val, null));
                    }
                }
            }
        }

        public static string XmlSerializeObject(object target)
        {
            string classSimpleName = TypeHelper.GetClassSimpleName(target.GetType());
            XmlElement curNode = new XmlDocument().CreateElement(classSimpleName);
            foreach (PropertyInfo info in target.GetType().GetProperties())
            {
                if (info.CanRead)
                {
                    DoXmlSerializeObject(curNode, info, info.GetValue(target, null));
                }
            }
            return curNode.OuterXml;
        }
    }
}

