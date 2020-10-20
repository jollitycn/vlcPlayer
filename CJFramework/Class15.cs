using CJBasic.Helpers;
using System;
using System.Xml;
using System.Text;

internal class Class15 : Class14, IStreamContract, Interface10, ITextContractHelper
{
    private byte[] byte_0 = Encoding.UTF8.GetBytes("</Message>");

    public override Enum6 imethod_0()
    {
        return (Enum6) 1;
    }

    public override TBody imethod_1<TBody>(IMessageHandler interface37_0) where TBody: class//, new()
    {
        string xml = ((Message1) interface37_0).method_0();
        XmlDocument document = new XmlDocument();
        document.LoadXml(xml);
        XmlNode node = document.ChildNodes[0];
        XmlNode childNode = XmlHelper.GetChildNode(node, "Body");
        if (childNode == null)
        {
            return default(TBody);
        }
        TBody target = (TBody) Activator.CreateInstance(typeof(TBody));
        XmlHelper.ConfigObject(childNode, target);
        return target;
    }

    public byte[] imethod_10()
    {
        return this.byte_0;
    }

    public virtual IHeader4 imethod_11(string string_0)
    {
        try
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(string_0);
            XmlNode node = document.ChildNodes[0];
            XmlNode childNode = XmlHelper.GetChildNode(node, "Header");
            return new DotNETHeader { 
                UserID = XmlHelper.GetPropertyValue(childNode, "UserID"),
                MessageType = int.Parse(XmlHelper.GetPropertyValue(childNode, "MessageType")),
                MessageID = int.Parse(XmlHelper.GetPropertyValue(childNode, "MessageID")),
                DestUserID = XmlHelper.GetPropertyValue(childNode, "DestUserID")
            };
        }
        catch
        {
            return null;
        }
    }

    public bool imethod_12(string string_0)
    {
        return true;
    }

    public override IMessageHandler imethod_3<TBody>(string string_0, int int_1, TBody body, string string_1, int int_2) where TBody: class
    {
        DotNETHeader class2 = new DotNETHeader(string_0, int_1, string_1, int_2);
        return new Message1(class2, this.method_1(class2, body), null);
    }

    public string imethod_8(byte[] byte_1, int int_1, int int_2)
    {
        return Class84.smethod_0().imethod_8(byte_1, int_1, int_2);
    }

    public byte[] imethod_9(string string_0)
    {
        return Class84.smethod_0().imethod_9(string_0);
    }

    private string method_1(IHeader interface21_0, object object_0)
    {
        XmlDocument document = new XmlDocument();
        document.LoadXml("<Message></Message>");
        XmlNode node = document.ChildNodes[0];
        XmlNode objNode = document.CreateElement("Header");
        XmlHelper.SetPropertyValue(objNode, "UserID", interface21_0.UserID, XmlPropertyPosition.ChildNode);
        XmlHelper.SetPropertyValue(objNode, "MessageType", interface21_0.MessageType.ToString(), XmlPropertyPosition.ChildNode);
        XmlHelper.SetPropertyValue(objNode, "MessageID", interface21_0.MessageID.ToString(), XmlPropertyPosition.ChildNode);
        XmlHelper.SetPropertyValue(objNode, "DestUserID", interface21_0.DestUserID, XmlPropertyPosition.ChildNode);
        node.AppendChild(objNode);
        if (object_0 != null)
        {
            XmlNode node3 = document.CreateElement("Body");
            XmlHelper.FillObjectNode(node3, object_0);
            node.AppendChild(node3);
        }
        return node.OuterXml;
    }
}

