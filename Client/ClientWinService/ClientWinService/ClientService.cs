

namespace ClientWinService
{
    using System;
    using System.IO;
    using System.ServiceProcess;
    using System.Threading;

    public partial class ClientService : ServiceBase
    {
        Timer timer1;
        public ClientService()
        {
            InitializeComponent();
        } 

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(timer1_Tick), null, 15000, 60000);
        }


        

        protected override void OnStop()
        {



            //try
            //{

            //    List<string> list = new ClientDAL().InstalledsPrograms();
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}





            StreamWriter vWriter = new StreamWriter(@"c:\testeServico.txt", true);

            vWriter.WriteLine("Servico Parado: " + DateTime.Now.ToString());
            vWriter.Flush();
            vWriter.Close();
        }

        private void timer1_Tick(object sender)
        {
            StreamWriter vWriter = new StreamWriter(@"c:\testeServico.txt", true);
            vWriter.WriteLine("Servico Rodando: " + DateTime.Now.ToString());
            vWriter.Flush();
            vWriter.Close();
        }



    }
}
