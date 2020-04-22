using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DAL;

namespace BL
{
    public class DBPruchasesAccess
    {
        private ITalkWithDB TalkWithDB { get; set; }

        ////public DBPruchasesAccess(ITalkWithDB talkWithDB = null)
        ////{
        ////    if (talkWithDB == null)
        ////    {
        ////        TalkWithDB = new TalkWithMySQLDB();
        ////    }
        ////    else
        ////    {
        ////        TalkWithDB = talkWithDB;
        ////    }
        ////}

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
    }
}
