using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Core.Configurations
{
    public static class Configurations
    {
        public static string DBServer => ConfigurationManager.AppSettings["DBServer"];
        public static string Database => ConfigurationManager.AppSettings["Database"];
        public static string DBUserName => ConfigurationManager.AppSettings["DBUserName"];
        public static string DBPassword => ConfigurationManager.AppSettings["DBPassword"];
        public static string MQHostName => ConfigurationManager.AppSettings["MQHostName"];
        public static string MQUserName => ConfigurationManager.AppSettings["MQUserName"];
        public static string MQPassowrd => ConfigurationManager.AppSettings["MQPassword"];
    }
}