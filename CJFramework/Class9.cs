using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

internal class Class9
{
    private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

    public Class9(string string_0)
    {
        string[] separator = new string[] { "\r\n" };
        foreach (string str in string_0.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        {
            int index = str.IndexOf(':');
            if (index > 0)
            {
                string key = str.Substring(0, index).Trim();
                if (key.ToLower().IndexOf("origin") > 0)
                {
                    key = "Origin";
                }
                string str3 = str.Substring(index + 1).Trim();
                this.dictionary_0.Add(key, str3);
            }
        }
    }

    public string method_0()
    {
        string str = this.method_1("Sec-WebSocket-Key");
        string str2 = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
        return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(str + str2)));
    }

    public string method_1(string string_0)
    {
        if (this.dictionary_0.ContainsKey(string_0))
        {
            return this.dictionary_0[string_0].ToString();
        }
        return string.Empty;
    }

    public string method_2()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("HTTP/1.1 101 Web Socket Protocol Handshake\r\n");
        builder.AppendFormat("Upgrade: {0}\r\n", this.method_1("Upgrade"));
        builder.AppendFormat("Connection: {0}\r\n", this.method_1("Connection"));
        builder.AppendFormat("Sec-WebSocket-Accept: {0}\r\n", this.method_0());
        builder.AppendFormat("WebSocket-Origin: {0}\r\n", this.method_1("Origin"));
        builder.AppendFormat("WebSocket-Location: {0}\r\n", this.method_1("Host"));
        builder.Append("\r\n");
        return builder.ToString();
    }
}

