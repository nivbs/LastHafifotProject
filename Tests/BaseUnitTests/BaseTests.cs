using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public abstract class BaseUnitTests
    {
        protected static ITalkWithMQ TalkWithMQ = new RabbitMQConnection();
        protected static DBPruchasesAccess DBPruchasesAccess = new DBPruchasesAccess();
        protected Process Process { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WorkingDirectory = @"D:\Hafifot\LastProject",
                Arguments = "/c java -jar PurchasesPipeline_1.0.1.jar"
            };

            Process = new Process { StartInfo = startInfo };
            Process.Start();
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Process.CloseMainWindow();
            DBPruchasesAccess.CleanDB();
        }
    }
}