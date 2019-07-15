

namespace Util
{
    using DTO;
    using Microsoft.IdentityModel.Protocols;
    using Newtonsoft.Json;
    using Repository;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using Util.RestLib;

    public partial class ClientService : ServiceBase
    {
        public Timer timer1 { get; set; }

        public ClientService()
        {
            InitializeComponent();
        } 

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(SendMessageQueues), null, 15000, 60000);

        }


        

        protected override void OnStop()
        {
           
             
        }

        private void SendMessageQueues(object sender)
        {
            post();
        }


        public Post post()
        {
            string apiUrl = ConfigurationManager.AppSettings["API"];

            ClientDTO dto = new ClientRepository().dto;

            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto));
            var requisicaoWeb = WebRequest.CreateHttp(apiUrl);
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
            requisicaoWeb.ContentLength = data.Length;
            requisicaoWeb.UserAgent = "WebRequest";
            //precisamos escrever os dados post para o stream
            using (var stream = requisicaoWeb.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            //ler e exibir a resposta
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());

                streamDados.Close();
                resposta.Close();
                return post;
            }

        }


    }
}
