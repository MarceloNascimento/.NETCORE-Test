

namespace Util
{
    using Repository;
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
            timer1 = new Timer(new TimerCallback(SendMessageQueues), null, 15000, 60000);

        }


        

        protected override void OnStop()
        {
           
             
        }

        private void SendMessageQueues(object sender)
        {
            new RabbitmqUtil(true).SendSerialized(new ClientRepository().dto);
        }



    }
}
