using System;
using System.IO;
using System.Net;
using System.Text;
//using System.Net.Http;

namespace JGNet.Core
{
    public class HttpHandler
    {
    //    private HttpClient httpClient;

        public HttpHandler Initialize()
        {
            //if (httpClient == null)
            //{
            //    httpClient = new HttpClient();
            //    httpClient.MaxResponseContentBufferSize = 256000;
            //    httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            //    httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            //    httpClient.Timeout = TimeSpan.FromMilliseconds(20000);
                 
            //}
            return this;
        }

        public String GetHttpResponse(String url)
        {
            //HttpResponseMessage response = this.httpClient.GetAsync(url).Result;
            //String res = response.Content.ReadAsStringAsync().Result;
            //return res; 
            string content = "";
            HttpWebRequest HttpWReq = null;
            HttpWebResponse HttpWResp = null;
            try
            {
                HttpWReq =
   (HttpWebRequest)WebRequest.Create(url);
                HttpWReq.UserAgent = "MSIE6.0";
                HttpWReq.Method = "GET";

                HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                Stream resStream = HttpWResp.GetResponseStream();

                using (StreamReader sr = new StreamReader(resStream))
                {
                    content = sr.ReadToEnd();
                }
                // Insert code that uses the response object.
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                HttpWResp?.Close();
            }
            return content;
        }

        //public void Close()
        //{
        //    try
        //    {
        //        if (this.httpClient != null)
        //        {
        //            this.httpClient.Dispose();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }



        public byte[] PostHttpResponse(String url, string data)
        {
            string content = "";
            HttpWebRequest HttpWReq = null;
            HttpWebResponse HttpWResp = null;
            byte[] result;
            try
            {
                byte[] bs = Encoding.UTF8.GetBytes(data);//UTF-8
                HttpWReq =
                (HttpWebRequest)WebRequest.Create(url);
                HttpWReq.UserAgent = "MSIE6.0";
                HttpWReq.Method = "POST";
                HttpWReq.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                HttpWReq.ContentLength = bs.Length;
                using (Stream reqStream = HttpWReq.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }

                HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
                Stream resStream = HttpWResp.GetResponseStream();
                byte[] buffer = new byte[1024];
                int actual = 0;
                //先保存到内存流中MemoryStream
                MemoryStream ms = new MemoryStream();
                while ((actual = resStream.Read(buffer, 0, 1024)) > 0)
                {
                    ms.Write(buffer, 0, actual);
                }

                ms.Position = 0;
                //再从内存流中读取到byte数组中
                result = ms.ToArray();
                
                //using (StreamReader sr = new StreamReader(resStream))
                //{
                //    content = sr.ReadToEnd();
                //}
                // Insert code that uses the response object.
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

                HttpWResp?.Close();
            }
            return result;
        }
        
    }
}