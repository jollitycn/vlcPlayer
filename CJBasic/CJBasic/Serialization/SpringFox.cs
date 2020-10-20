namespace CJBasic.Serialization
{
    using CJBasic.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml;

    public static class SpringFox
    {
        private static void ConfigObject(XmlNode objNode, ref object target)
        {
            foreach (XmlAttribute attribute in objNode.Attributes)
            {
                ReflectionHelper.SetProperty(target, attribute.Name, attribute.Value);
            }
            foreach (XmlNode node in objNode.ChildNodes)
            {
                if (node.Attributes["value"] != null)
                {
                    ReflectionHelper.SetProperty(target, node.Attributes["name"].Value, node.Attributes["value"].Value);
                }
                else
                {
                    XmlNode node2 = node.ChildNodes[0];
                    if (node2.Name == "object")
                    {
                        object obj2 = Activator.CreateInstance(ReflectionHelper.GetType(node2.Attributes["type"].Value));
                        ConfigObject(node2, ref obj2);
                        ReflectionHelper.SetProperty(target, node.Attributes["name"].Value, obj2);
                    }
                    else if (node2.Name == "list")
                    {
                        object obj4;
                        Type type = ReflectionHelper.GetType(node2.Attributes["element-type"].Value);
                        Type type3 = typeof(List<>).MakeGenericType(new Type[] { type });
                        object obj3 = Activator.CreateInstance(type3);
                        if (TypeHelper.IsSimpleType(type))
                        {
                            foreach (XmlNode node3 in node2.ChildNodes)
                            {
                                obj4 = TypeHelper.ChangeType(type, node3.InnerText);
                                type3.GetMethod("Add").Invoke(obj3, new object[] { obj4 });
                            }
                        }
                        else
                        {
                            foreach (XmlNode node3 in node2.ChildNodes)
                            {
                                Type type4 = type;
                                if (node3.Attributes["type"] != null)
                                {
                                    type4 = ReflectionHelper.GetType(node3.Attributes["type"].Value);
                                }
                                obj4 = Activator.CreateInstance(type4);
                                ConfigObject(node3, ref obj4);
                                type3.GetMethod("Add").Invoke(obj3, new object[] { obj4 });
                            }
                        }
                        ReflectionHelper.SetProperty(target, node.Attributes["name"].Value, obj3);
                    }
                }
            }
        }

        private static void DoXmlObject(object obj, XmlDocument xmlDoc, XmlNode curNode)
        {
            try
            {
                if (!TypeHelper.IsSimpleType(obj.GetType()))
                {
                    foreach (PropertyInfo info in obj.GetType().GetProperties())
                    {
                        if (info.CanRead)
                        {
                            object[] customAttributes = info.GetCustomAttributes(typeof(NonXmlAttribute), true);
                            if ((customAttributes == null) || (customAttributes.Length <= 0))
                            {
                                object obj2 = info.GetValue(obj, null);
                                if (obj2 != null)
                                {
                                    if (TypeHelper.IsSimpleType(info.PropertyType))
                                    {
                                        if (info.PropertyType == typeof(DateTime))
                                        {
                                            SetPropertyValue(curNode, info.Name, ((DateTime) obj2).ToString("yyyy/MM/dd HH:mm:ss"), XmlPropertyPosition.ChildNode);
                                        }
                                        else
                                        {
                                            SetPropertyValue(curNode, info.Name, obj2.ToString(), XmlPropertyPosition.ChildNode);
                                        }
                                    }
                                    else
                                    {
                                        XmlElement element;
                                        if (!info.PropertyType.IsGenericType)
                                        {
                                            bool flag2 = typeof(IEnumerable).IsAssignableFrom(info.PropertyType);
                                            bool flag3 = info.PropertyType.IsSubclassOf(typeof(Array));
                                            if (!(flag2 || flag3))
                                            {
                                                element = xmlDoc.CreateElement("property");
                                                SetPropertyValue(element, "name", info.Name, XmlPropertyPosition.Attribute);
                                                curNode.AppendChild(element);
                                                XmlElement objNode = xmlDoc.CreateElement("object");
                                                SetPropertyValue(objNode, "type", TypeHelper.GetTypeRegularName(obj2.GetType()), XmlPropertyPosition.Attribute);
                                                element.AppendChild(objNode);
                                                DoXmlObject(obj2, xmlDoc, objNode);
                                            }
                                        }
                                        else if ((info.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)) || (info.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                                        {
                                            element = xmlDoc.CreateElement("property");
                                            SetPropertyValue(element, "name", info.Name, XmlPropertyPosition.Attribute);
                                            curNode.AppendChild(element);
                                            Type destType = info.PropertyType.GetGenericArguments()[0];
                                            XmlElement element3 = xmlDoc.CreateElement("list");
                                            SetPropertyValue(element3, "element-type", TypeHelper.GetTypeRegularName(destType), XmlPropertyPosition.Attribute);
                                            element.AppendChild(element3);
                                            if (TypeHelper.IsSimpleType(destType))
                                            {
                                                foreach (object obj3 in (IEnumerable) obj2)
                                                {
                                                    XmlHelper.SetPropertyValue(element3, "value", obj3.ToString(), XmlPropertyPosition.ChildNode, false);
                                                }
                                            }
                                            else
                                            {
                                                foreach (object obj3 in (IEnumerable) obj2)
                                                {
                                                    XmlElement element4 = xmlDoc.CreateElement("object");
                                                    if (destType != obj3.GetType())
                                                    {
                                                        XmlHelper.SetPropertyValue(element4, "type", TypeHelper.GetTypeRegularName(obj3.GetType()), XmlPropertyPosition.Attribute);
                                                    }
                                                    element3.AppendChild(element4);
                                                    DoXmlObject(obj3, xmlDoc, element4);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("XmlObject {0} Error !", obj.GetType().ToString()), exception);
            }
        }

        public static object ObjectXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            XmlNode node = document.ChildNodes[0];
            object target = Activator.CreateInstance(ReflectionHelper.GetType(XmlHelper.GetPropertyValue(node, "type")));
            ConfigObject(node, ref target);
            return target;
        }

        private static void SetPropertyValue(XmlNode objNode, string proName, string val, XmlPropertyPosition pos)
        {
            if (pos == XmlPropertyPosition.ChildNode)
            {
                foreach (XmlNode node in objNode.ChildNodes)
                {
                    if (node.Attributes["name"].Value == proName)
                    {
                        node.Attributes["value"].Value = val;
                        return;
                    }
                }
                XmlNode newChild = objNode.OwnerDocument.CreateElement("property");
                XmlAttribute attribute = objNode.OwnerDocument.CreateAttribute("name");
                attribute.Value = proName;
                newChild.Attributes.Append(attribute);
                XmlAttribute attribute2 = objNode.OwnerDocument.CreateAttribute("value");
                attribute2.Value = val;
                newChild.Attributes.Append(attribute2);
                objNode.AppendChild(newChild);
            }
            else
            {
                foreach (XmlAttribute attribute3 in objNode.Attributes)
                {
                    if (attribute3.Name == proName)
                    {
                        attribute3.Value = val;
                        return;
                    }
                }
                XmlAttribute attribute4 = objNode.OwnerDocument.CreateAttribute(proName);
                objNode.Attributes.Append(attribute4);
                attribute4.Value = val;
            }
        }

        public static string XmlObject(object obj)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement objNode = xmlDoc.CreateElement("object");
            SetPropertyValue(objNode, "type", TypeHelper.GetTypeRegularName(obj.GetType()), XmlPropertyPosition.Attribute);
            DoXmlObject(obj, xmlDoc, objNode);
            return objNode.OuterXml;
        }
    }
}

