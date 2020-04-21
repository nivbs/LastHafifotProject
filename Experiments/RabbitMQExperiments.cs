using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Experiments
{
    public class RabbitMQExperiments
    {
        public void SendMessage ()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var body = Encoding.UTF8.GetBytes("AA19345,4557446145890236,2019-09-03,100.0");
                    channel.BasicPublish("", "TEST", null, body);
                }
            }
        }
    }
}