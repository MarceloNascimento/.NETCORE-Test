using Newtonsoft.Json;


namespace Util.RestLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    public class RestUtil
    {
        public RestUtil()
        {

        }

        public object GET(string url, object postData)
        {
            var webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = "WebRequest";

            object objResponse = new object();
            using (var resposta = webRequest.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                objResponse = reader.ReadToEnd();
                 
                streamDados.Close();
                resposta.Close();
            }
            return objResponse;
        }



        public Post POST(string url, object postData)
        {
            try
            {
                var data = Encoding.ASCII.GetBytes(postData);

                var request = (HttpWebRequest)WebRequest.Create(url);
                var post = new Post();
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = "WebRequest";

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }

                using (var resposta = request.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());
                                       
                    streamDados.Close();
                    resposta.Close();
                }
                
                return post;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PUT(string url, object postData)
        {
            return string.Empty;
        }


        public string DELETE(string url, object postData)
        {
            return string.Empty;
        }

    }
}
