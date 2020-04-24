using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assertions;
using BL;
using Extensions;
using Core;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class InvalidPurchaseTests : BaseOnePurchaseTests
    {
        //change the condition of WhyInvaild To Something more specific

        [TestMethod]
        [DataRow("0")]
        [DataRow("473849734")]
        [DataRow("2938472938493823")]
        [DataRow("dkfleoritorkfldf")]
        [DataRow("39485849584950495834")]
        public void SendPurchaseWithIncorrectCreditCardNumberSuccess(string creditCardNumber)
        {
            PurchaseInQueue.CreditCardNumber = creditCardNumber;
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());
            
            DBPruchasesAccess.WaitUntilRowsCountEquals(1);
            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases.First()
                .Should()
                .BeInvalid("The credit card number is not valid");
        }

        [TestMethod]
        public void SendPurchaseWithTooMuchInstallmentsSuccess()
        {
            PurchaseInQueue.Installments = $"{PurchaseInQueue.TotalPrice * 10 + 1}";
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);
            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases.First()
                .WhyInvalid
                .Should()
                .NotBeNullOrEmpty();

            purchases.First()
                .IsValid
                .Should()
                .BeFalse();
        }

        [TestMethod]
        public void SendPurchaseWithPricePerInstallmentBiggerThan5000Success()
        {
            PurchaseInQueue.TotalPrice = int.Parse(PurchaseInQueue.Installments) * 5001;
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);
            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases.First()
                .Should()
                .BeInvalid("Price per installment cant be higher than 5000");
        }

        [TestMethod]
        public void SendPurchaseWithFuturedPurchaseDateSuccess()
        {
            PurchaseInQueue.PurchaseDate = DateTime.Now + TimeSpan.FromDays(4);
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);
            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases.First()
                .Should()
                .BeInvalid("The purchase date cant be in the future");
        }

        [TestMethod]
        public void SendPurchaseWithPurchaseDateWhenStoreClosedSuccess()
        {
            PurchaseInQueue.PurchaseDate = new DateTime(2020, 4, 18);
            PurchaseInQueue.StoreID.ActivityDays = 'C';
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            DBPruchasesAccess.WaitUntilRowsCountEquals(1);
            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases.First()
                .Should()
                .BeInvalid("Purchase was made on a day that the store is closed");
        }

        [TestMethod]
        public void SendPurchasesWhenSomeOfThemInvalidSuccess()
        {
            PurchaseInQueue.CreditCardNumber = "0";
            PurchaseInQueue purchaseInQueue = new PurchaseInQueue();
            TalkWithMQ.SendMessage($"{purchaseInQueue}\n{purchaseInQueue}");

            DBPruchasesAccess.WaitUntilRowsCountEquals(2);
            List<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases().ToList();

            purchases.First()
                .Should()
                .BeInvalid("The credit card number is not valid");

            purchases[1].WhyInvalid
                .Should()
                .BeNull();

            purchases[1].IsValid
                .Should()
                .BeTrue();
        }
    }
}
