

namespace Processer
{
    using DTO;
    using Repository;
    using System.Collections.Generic;
    using System.ServiceProcess;
    using System.Threading;
    using Util;

    public partial class Processer : ServiceBase
    {

        public List<ClientDTO> MessagesList { get; set; }
        public Processer()
        {
            InitializeComponent();
        }

        public Timer Timer { get; set; }

        protected override void OnStart(string[] args)
        {
            this.Timer = new Timer(new TimerCallback(ReceiveMessagesQueues), null, 15000, 60000);
        }

        private void ReceiveMessagesQueues(object state)
        {
            this.MessagesList = new RabbitmqUtil(true).ReceiveClientDTOSerialized("MACHINES-MONITOR");
        }

        protected override void OnStop()
        {
            if (this.MessagesList.Count > 0)
            {
                var rep = new MachineRepository();
                foreach (var client in this.MessagesList)
                {
                    rep.Insert(client);
                }
            }

        }
    }
}
