using JGNet.Core.Const;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace JGNet.Core.Tools
{
    public static class KuaiDi100Helper
    {
        public static string Md5Hex(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dataHash = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in dataHash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public static bool CheckKuaiDi(string type, string postid)
        { 
                bool rightOrder = false;
                string jsonText = WebQueryJson(type, postid);
                //Object jObject =JsonConvert.DeserializeObject(jsonText);
                //if (!jObject.ContainsKey("state"))
                //{
                //    throw new KuaiDiException(jObject["message"].ToString());
                //}
                //String state = jObject["state"].ToString();
                //String status = jObject["status"].ToString();

                //if (status == "200")
                //{
                //    //查询有记录OK
                //    rightOrder = true;
                //}
                //else
                //{
                //    //查询失败
                //    rightOrder = false;
                //}
           
            return rightOrder;
        }

        public static string WebQueryJson(string type, string postid)
        {
            if (string.IsNullOrEmpty(type))
            {
                List<string> types = KuaiDi100Helper.WebAutoComNum(postid);
                if (types.Count == 0)
                {
                    throw new KuaiDiException("快递类型必填");
                }
                type = types[0];
            }
            return KuaiDi100Helper.GetResult(type, postid);
        }

        public static string GetResult(string type, string postid)
        {
            StringBuilder param = new StringBuilder("{");
            param.Append("\"com\":\"").Append(type).Append("\"");
            param.Append(",\"num\":\"").Append(postid).Append("\"");
            param.Append(",\"from\":\"").Append("\"");
            param.Append(",\"phone\":\"").Append("\"");
            param.Append(",\"to\":\"").Append("\"");
            param.Append(",\"resultv2\":0");
            param.Append("}");
            string sign = KuaiDi100Helper.Md5Hex(param + SystemDefault.KuaiDI100Key + SystemDefault.KuaiDI100Customer).ToUpper();
            string url = string.Format(SystemDefault.KuaiDi100Url2, SystemDefault.KuaiDI100Customer, sign, param.ToString());
            HttpHandler httpHandler = new HttpHandler();
            string jsonText = httpHandler.Initialize().GetHttpResponse(url);
            return jsonText;
        }

        public static List<string> WebAutoComNum(string text)
        {
            List<string> comCodes = new List<string>();
            string url = string.Format("https://www.kuaidi100.com/autonumber/autoComNum?resultv2=1&text={0}", text);
            HttpHandler httpHandler = new HttpHandler(); 
            string jsonText = httpHandler.Initialize().GetHttpResponse(url);
            AutoComNum autoComNum = (AutoComNum)JavaScriptConvert.DeserializeObject(jsonText, typeof(AutoComNum));
            List<Auto> auto = autoComNum.auto;
            int length = autoComNum.auto.Count;
            for (int i = 0; i < length; i++)
            {
                comCodes.Add(auto[i].comCode);
            }
            return comCodes;
        }
    }
    
    public class AutoComNum
    {
        public string comCode { get; set; }

        public string num { get; set; }

        public List<Auto> auto { get; set; }
    }

    public class Auto
    {
        public string comCode { get; set; }

        public string id { get; set; }

        public int noCount { get; set; }

        public string noPre { get; set; }

        public string startTime { get; set; }
    }

    [Serializable]
    public class DataInfo
    {
        public string time { get; set; }

        public string ftime { get; set; }

        public string context { get; set; }

        public string location { get; set; }
    }
}
