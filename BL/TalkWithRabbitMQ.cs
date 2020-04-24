using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Configurations;

namespace BL
{
    public class TalkWithRabbitMQ : ITalkWithMQ
    {
        protected ConnectionFactory Factory { get; set; }

        public TalkWithRabbitMQ(ConnectionFactory factory = null)
        {
            if(factory == null)
            {
                Factory = new ConnectionFactory() { HostName = Configurations.MQHostName, Password = Configurations.MQPassowrd, UserName = Configurations.MQUserName};
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