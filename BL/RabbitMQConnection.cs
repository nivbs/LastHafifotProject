using RabbitMQ.Client;
using System.Text;
using Core.Configurations;

namespace BL
{
    public class RabbitMQConnection : ITalkWithMQ
    {
        protected ConnectionFactory Factory { get; set; }

        public RabbitMQConnection(ConnectionFactory factory = null)
        {
            Factory = factory ?? (new ConnectionFactory() { HostName = Configurations.MQHostName, Password = Configurations.MQPassowrd, UserName = Configurations.MQUserName });
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