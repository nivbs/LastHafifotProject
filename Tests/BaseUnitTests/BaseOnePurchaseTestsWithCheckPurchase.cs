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
