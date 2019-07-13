

namespace Processer
{
    using DTO;
    using Repository;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
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
            this.MessagesList = new RabbitmqUtil(true).ReceiveSerialized("MACHINES-MONITOR");
        }

        protected override void OnStop()
        {

        }
    }
}
