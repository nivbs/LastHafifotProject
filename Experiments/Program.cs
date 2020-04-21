using System;
using RabbitMQ.Client;
using DAL;
using Core;

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
