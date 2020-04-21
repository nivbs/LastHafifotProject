using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TalkWithRabbitMQ : ITalkWithMQ
    {
        protected ConnectionFactory Factory { get; set; }

        public TalkWithRabbitMQ(ConnectionFactory factory = null)
        {
            if(factory == null)
            {
                Factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
            }
            else
            {
                Factory = factory;
            }
        }

        public void SendMessage(string message)
        {
                using (var channel = Factory.CreateConnection().CreateModel())
                {
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "TEST", null, body);
                }
        }
    }
}