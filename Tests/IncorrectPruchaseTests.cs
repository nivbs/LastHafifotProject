using FluentAssertions;
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
    public class IncorrectPruchaseTests : BaseOnePurchaseTestsWithCheckPurchase
    {
        [TestMethod]
        [DataRow("-53")]
        [DataRow("null")]
        [DataRow("NULL")]
        [DataRow("fdkl")]
        public void SendPruchaseWithInstallmentsFailed(string installments)
        {
            PurchaseInQueue.Installments = installments;
            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        [DataRow("2018-02-30")]
        [DataRow("2018-22-11")]
        public void SendPurchaseWithIncorrectPurchaseDateFailed(string purchaseDate)
        {
            TalkWithMQ.SendMessage($"{PurchaseInQueue.StoreID},{PurchaseInQueue.CreditCardNumber},{purchaseDate},{PurchaseInQueue.TotalPrice}" +
                $",{PurchaseInQueue.Installments}");
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        [DataRow("TB30493")]
        [DataRow("AW20394")]
        public void SendPurchaseWithUnknownStoreIdCharsFailed(string storeId)
        {
            PurchaseInQueue.StoreID = new StoreID(storeId);

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        [DataRow("AB903")]
        [DataRow("A23954")]
        [DataRow("29484AA")]
        [DataRow("5BFL49A")]
        public void SendPurchaseWithIncorrectStoreIdFormatFailed(string storeId)
        {
            TalkWithMQ.SendMessage($"{storeId},{PurchaseInQueue.CreditCardNumber},{PurchaseInQueue.PurchaseDate},{PurchaseInQueue.TotalPrice}" +
                $",{PurchaseInQueue.Installments}");
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        public void SendPurchaseWithNegativeTotalPriceFailed()
        {
            PurchaseInQueue.TotalPrice *= -1;

            TalkWithMQ.SendMessage(PurchaseInQueue.ToString());
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }

        [TestMethod]
        [DataRow("4557446145890236,AA12345,100.0,5,2019-09-03")]
        [DataRow("AA1232,2019-09-03,100.0,5")]
        [DataRow("AA12345,4557446145890236,2019-09-03,100.0,5,20")]
        [DataRow("")]
        public void SendPruchaseWithIncorrectFormatFailed(string purchaseInQueue)
        {
            TalkWithMQ.SendMessage(purchaseInQueue);
            TalkWithMQ.SendMessage(CheckPurchase.ToString());

            DBPruchasesAccess.WaitUntilConditionReturnRows($"credit_card = '{CheckPurchase.CreditCardNumber}'");

            DBPruchasesAccess.GetAllPruchases()
                .Count()
                .Should()
                .Be(1);
        }
    }
}
