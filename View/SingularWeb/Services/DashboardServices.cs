using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Util.RestLib;
using Microsoft.Extensions.Options;

namespace SingularWeb.Services
{
    public class DashboardServices
    {

        public DashboardServices()
        {

        }

        public static DashboardDTO Get()
        {
            string apiUrl = "http://localhost:1483/api";
            var requisicaoWeb = WebRequest.CreateHttp(apiUrl);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "WebRequest";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var response = JsonConvert.DeserializeObject<DashboardDTO>(objResponse.ToString());

                streamDados.Close();
                resposta.Close();

                return response;
            }
        }
    }
}
