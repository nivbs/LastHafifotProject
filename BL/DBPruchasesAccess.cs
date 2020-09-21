using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using DAL;

namespace BL
{
    public class DBPruchasesAccess
    {
        private ITalkWithDB TalkWithDB { get; set; }

        public DBPruchasesAccess()
        {
            TalkWithDB = new TalkWithMySQLDB();
        }

        public DBPruchasesAccess(ITalkWithDB talkWithDB)
        {
            TalkWithDB = talkWithDB;
        }

        public IEnumerable<ExpandPurchase> GetPurchasesByCondition(string condition)
            => TalkWithDB.GetPurchasesByCondition(condition);

        public IEnumerable<ExpandPurchase> GetFirstProchasesByLimit(int count = 1000)
            => TalkWithDB.GetFirstPurchasesByLimit(count);

        public IEnumerable<ExpandPurchase> GetProchasesByProchaseDetails(PurchaseInQueue purchaseInQueue)
            => TalkWithDB.GetProchasesByPurchaseDetails(purchaseInQueue);

        public void CleanDB()
            => TalkWithDB.CleanDB();

        public IEnumerable<ExpandPurchase> GetAllPruchases()
            => TalkWithDB.GetAllPurchases();

        public void InsertPurchase(ExpandPurchase purchase)
            => TalkWithDB.InsertPurchaseToDB(purchase);

        private void WaitUntilPruchaseExistWithTimer(PurchaseInQueue purchaseInQueue, DateTime endingDateTime)
        {
            if (DateTime.Now < endingDateTime)
            {
                if (GetProchasesByProchaseDetails(purchaseInQueue).Count() == 0)
                {
                    WaitUntilPruchaseExistWithTimer(purchaseInQueue, endingDateTime);
                }
            }
            else
            {
                throw new TimeoutException($"TimeOut Exception !\nAfter the time you sent left, the purchase you sent still not exist in the DB");
            }
        }

        public void WaitUntilPurchaseExist(PurchaseInQueue purchaseInQueue, int seconds = 5)
        {
            WaitUntilPruchaseExistWithTimer(purchaseInQueue, DateTime.Now + TimeSpan.FromSeconds(seconds));
        }

        private void WaitUntilConditionReturnRowsWithTimer(string condition, DateTime endingDateTime)
        {
            if (DateTime.Now < endingDateTime)
            {
                if (GetPurchasesByCondition(condition).Count() == 0)
                {
                    WaitUntilConditionReturnRowsWithTimer(condition, endingDateTime);
                }
            }
            else
            {
                throw new TimeoutException($"TimeOut Exception !\nAfter the time you sent left, the condition you sent still not return any rows in the DB");
            }
        }

        public void WaitUntilConditionReturnRows(string condition, int seconds = 5)
        {
            WaitUntilConditionReturnRowsWithTimer(condition, DateTime.Now + TimeSpan.FromSeconds(seconds));
        }

        private void WaitUntilRowsCountEqualsWithTimer(int rowsCount, DateTime endingDateTime)
        {
            if (DateTime.Now < endingDateTime)
            {
                if (GetAllPruchases().Count() != rowsCount)
                {
                    WaitUntilRowsCountEqualsWithTimer(rowsCount, endingDateTime);
                }
            }
            else
            {
                throw new TimeoutException($"Timeout Exception.\nAfter The time you sent left, the rows count is not equals to {rowsCount}");
            }
        }

        public void WaitUntilRowsCountEquals(int rowsCount, int seconds = 5)
        {
            WaitUntilRowsCountEqualsWithTimer(rowsCount, DateTime.Now + TimeSpan.FromSeconds(seconds));
        }
    }
}