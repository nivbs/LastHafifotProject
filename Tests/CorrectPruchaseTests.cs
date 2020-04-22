using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using BL;
using FluentAssertions;
using Extensions;

namespace Tests
{
    [TestClass]
    public class CorrectPruchaseTests : BaseOnePurchaseTests
    {
        [TestMethod]
        public void SendOneCorrectPurchaseSuccess()
        {
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        public void SendOneCorrectPurchaseWillParseSuccessfully()
        {
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            PurchaseInQueue.GetExpandedPurchase()
                .Equals(DBPruchasesAccess.GetAllPruchases().First())
                .Should()
                .BeTrue();    
        }

        [TestMethod]
        [DataRow(100.2f)]
        [DataRow(100f)]
        [DataRow(50000.2f)]
        public void SendPurchaseWithSpecialPriceSuccess(float price)
        {
            PurchaseInQueue.TotalPrice = price;

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        public void SendExistPurchaseSuccess()
        {
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(2);
        }

        [TestMethod]
        [DataRow("FULL")]
        [DataRow("")]
        public void SendPurchaseWithSpecialInstallmentsSuccess(string installments)
        {
            TalkWithMQ.SendMessage($"{PurchaseInQueue.StoreID},{PurchaseInQueue.CreditCardNumber},{PurchaseInQueue.PurchaseDate.ToString("yyy-MM-dd")},{PurchaseInQueue.TotalPrice}{installments}");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        public void SendFewPurchasesInOneMessageSuccess()
        {
            PurchaseInQueue purchaseInQueue = new PurchaseInQueue();
            TalkWithMQ.SendMessage($"{PurchaseInQueue}\n{purchaseInQueue}");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(2);
        }
    }
}