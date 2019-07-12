

namespace ClientWinService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    /// <summary>
    /// Class to work with mq for send and receive.
    /// </summary>
    public class RabbitmqRepository
    {
        private string _hostName = "localhost";
        private string _userName = "guest";
        private string _password = "guest";
        public static string SerialisationQueueName = "SerialisationDemoQueue";
        public ConnectionFactory factory { get; private set; }

        public RabbitmqRepository(bool serialize = false)
        {

            IConnection connection = GetRabbitMqConnection();

            if (serialize)
            {
                IModel model = connection.CreateModel();
                //SetupSerialisationMessageQueue(model);
            }
        }



        public IConnection GetRabbitMqConnection()
        {
            this.factory = new ConnectionFactory();
            this.factory.HostName = _hostName;
            this.factory.UserName = _userName;
            this.factory.Password = _password;

            return this.factory.CreateConnection();
        }

    

        public void Send(string message = "")
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MACHINES-MONITOR",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                                
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "MACHINES-MONITOR",
                                     basicProperties: null,
                                     body: body);

            }
        }


        public void SendSerialized(IModel serializedMessage)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MACHINES-MONITOR",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                                 
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(serializedMessage));

                channel.BasicPublish(exchange: "",
                                     routingKey: "MACHINES-MONITOR",
                                     basicProperties: null,
                                     body: body);

            }
        }




        public void Receive()
        {
           
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "MACHINES-MONITOR",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);


                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                    };

                    channel.BasicConsume(queue: "MACHINES-MONITOR",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }

        }



        public object ReceiveSerialized()
        {
            Object message = new Object();
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "MACHINES-MONITOR",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        message = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(body));                       
                        
                    };

                    channel.BasicConsume(queue: "MACHINES-MONITOR",
                                         autoAck: true,
                                         consumer: consumer);

                    return message;
                }
            }

        }

    }
}
