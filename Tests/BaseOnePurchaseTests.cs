using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Tests
{
    [TestClass]
    public abstract class BaseOnePurchaseTests : BaseUnitTests
    {
        protected PurchaseInQueue PurchaseInQueue { get; set; }

        [TestInitialize]
        public virtual void Intitalize()
        {
            PurchaseInQueue = new PurchaseInQueue();
        }
    }
}
