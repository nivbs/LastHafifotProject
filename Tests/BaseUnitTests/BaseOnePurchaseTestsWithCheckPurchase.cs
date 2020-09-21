using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;

namespace Tests
{
    [TestClass]
    public abstract class BaseOnePurchaseTestsWithCheckPurchase : BaseOnePurchaseTests
    {
        protected PurchaseInQueue CheckPurchase { get; set; }
        
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            CheckPurchase = new PurchaseInQueue();
        }
    }
}
