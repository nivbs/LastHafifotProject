using System.Collections.Generic;
using Core;

namespace DAL
{
    public interface ITalkWithDB
    {
        IEnumerable<ExpandPurchase> GetAllPurchases();
        IEnumerable<ExpandPurchase> GetPurchasesByCondition(string condition);
        IEnumerable<ExpandPurchase> GetFirstPurchasesByLimit(int count = 1000);
        IEnumerable<ExpandPurchase> GetProchasesByPurchaseDetails(PurchaseInQueue purchaseInQueue);
        ExpandPurchase GetLastInsertPurchase();
        void CleanDB();
        void InsertPurchaseToDB(ExpandPurchase expandPurchase);
    }
}