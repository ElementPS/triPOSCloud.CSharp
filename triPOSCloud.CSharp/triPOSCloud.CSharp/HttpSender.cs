using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;


namespace triPOSCloud.CSharp
{
    public class HttpSender
    {
        public string Send(string data, string url, string type, string action, Dictionary<string, string> headerDict)
        {
            string result = string.Empty;

            var byteData = Encoding.ASCII.GetBytes(data);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            if (type == "json")
            {
                webRequest.ContentType = "application/json";
                webRequest.Accept = "application/json";

                foreach (KeyValuePair<string,string> kv in headerDict)
                {
                    webRequest.Headers.Add(kv.Key, kv.Value);
                }
            }
            else
            {
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
            }
            webRequest.Method = action.ToUpper();
            webRequest.ContentLength = data.Length;


            if (action != "GET")
            {
                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
            }

            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();

            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                }
            }

            return result;
        }
    }
}
