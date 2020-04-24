using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

            Action action = () => DBPruchasesAccess.WaitUntilRowsCountEquals(1);

            action
                .Should()
                .NotThrow<TimeoutException>();
        }

        [TestMethod]
        public void SendOneCorrectPurchaseWillParseSuccessfully()
        {
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);

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

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);

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

            Action action = () => DBPruchasesAccess.WaitUntilRowsCountEquals(2);

            action.Should()
                .NotThrow<TimeoutException>();
        }

        [TestMethod]
        [DataRow(",FULL")]
        [DataRow("")]
        public void SendPurchaseWithSpecialInstallmentsSuccess(string installments)
        {
            TalkWithMQ.SendMessage($"{PurchaseInQueue.StoreID},{PurchaseInQueue.CreditCardNumber},{PurchaseInQueue.PurchaseDate.ToString("yyy-MM-dd")},{PurchaseInQueue.TotalPrice}{installments}");

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);

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

            Action action = () => DBPruchasesAccess.WaitUntilRowsCountEquals(2);

            action
                .Should()
                .NotThrow<TimeoutException>();
        }
    }
}