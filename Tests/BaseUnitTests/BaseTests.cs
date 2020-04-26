using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;

namespace Tests
{
    [TestClass]
    public abstract class BaseUnitTests
    {
        protected static ITalkWithMQ TalkWithMQ = new RabbitMQConnection();
        protected static DBPruchasesAccess DBPruchasesAccess = new DBPruchasesAccess();

        [TestCleanup]
        public virtual void CleanUp()
        {
            DBPruchasesAccess.CleanDB();
        }
    }
}