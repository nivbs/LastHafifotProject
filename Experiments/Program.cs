using System;
using RabbitMQ.Client;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            new RabbitMQExperiments().SendMessage();
        }
    }
}
