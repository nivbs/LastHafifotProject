using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
    [TestClass]
    public abstract class BaseOnePurchaseTests : BaseUnitTests
    {
        protected PurchaseInQueue PurchaseInQueue { get; set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            PurchaseInQueue = new PurchaseInQueue();
        }
    }
}
