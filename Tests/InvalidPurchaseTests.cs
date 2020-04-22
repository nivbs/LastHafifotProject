using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
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
        public void SendPurchaseWithIncorrectCreditCardNumberSuccess(string creditCardNumber)
        {
            PurchaseInQueue.CreditCardNumber = creditCardNumber;

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases
                .Count()
                .Should()
                .Be(1);

            purchases.First()
                .WhyInvalid
                .Should()
                .Be("The credit card number is not valid");

            purchases.First()
                .IsValid
                .Should()
                .BeFalse();
        }

        [TestMethod]
        public void SendPurchaseWithTooMuchInstallmentsSuccess()
        {
            PurchaseInQueue.Installments = $"{PurchaseInQueue.TotalPrice * 10 + 1}";

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases
                .Count()
                .Should()
                .Be(1);

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

            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases
                .Count()
                .Should()
                .Be(1);

            purchases.First()
                .WhyInvalid
                .Should()
                .Be("Price per installment cant be higher than 5000");

            purchases.First()
                .IsValid
                .Should()
                .BeFalse();
        }

        [TestMethod]
        public void SendPurchaseWithFuturedPurchaseDateSuccess()
        {
            PurchaseInQueue.PurchaseDate = DateTime.Now + TimeSpan.FromDays(4);

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());

            IEnumerable<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases();

            purchases
                .Count()
                .Should()
                .Be(1);

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
        public void SendPurchasesWhenSomeOfThemInvalidSuccess()
        {
            PurchaseInQueue.CreditCardNumber = "0";
            PurchaseInQueue purchaseInQueue = new PurchaseInQueue();

            TalkWithMQ.SendMessage($"{purchaseInQueue}\n{purchaseInQueue}");

            List<ExpandPurchase> purchases = DBPruchasesAccess.GetAllPruchases().ToList();

            purchases
                .Count()
                .Should()
                .Be(1);

            purchases.First()
                .WhyInvalid
                .Should()
                .NotBeNullOrEmpty();

            purchases.First()
                .IsValid
                .Should()
                .BeFalse();

            purchases[1].WhyInvalid
                .Should()
                .BeNull();

            purchases[1].IsValid
                .Should()
                .BeTrue();
        }
    }
}
