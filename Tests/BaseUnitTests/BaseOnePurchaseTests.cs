using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
    [TestClass]
    public abstract class BaseOnePurchaseTests : BaseUnitTests
    {
        protected PurchaseInQueue PurchaseInQueue { get; set; }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            PurchaseInQueue = new PurchaseInQueue();
        }
    }
}
