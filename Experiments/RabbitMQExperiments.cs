using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;
using RabbitMQ.Client;

namespace Experiments
{
    public class RabbitMQExperiments
    {
        public void SendMessage ()
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Publish("AA19345,4557446145890236,2019-09-03,100.0");
            }
        }
    }
}
