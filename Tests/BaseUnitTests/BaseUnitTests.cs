using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace Tests
{
    [TestClass]
    public abstract class BaseUnitTests
    {
        protected static ITalkWithMQ TalkWithMQ = new TalkWithRabbitMQ();
        protected static DBPruchasesAccess DBPruchasesAccess = new DBPruchasesAccess();

        [TestCleanup]
        public virtual void CleanUp()
        {
            DBPruchasesAccess.CleanDB();
        }
    }
}