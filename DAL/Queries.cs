using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DAL
{
    public static class Queries
    {
        public static string InsertPurchase(ExpandPurchase expandPurchase)
        {
            string isValid;
            if (expandPurchase.IsValid)
            {
                isValid = "1";
            }
            else
            {
                isValid = "0";
            }
            return $"INSERT hafifot.purchases VALUES('{expandPurchase.PurchaseId}', '{expandPurchase.StoreType}', '{expandPurchase.StoreId}', '{expandPurchase.ActivityDays}'" +
                $", '{expandPurchase.CreditCard}', '{expandPurchase.PurchaseDate.ToString("yyy-MM-dd")}', '{expandPurchase.InsertionDate.ToString("yyy-MM-dd")}', {expandPurchase.TotalPrice}," +
                $"{expandPurchase.Installments}, {expandPurchase.PricePerInstallments}, {isValid}, {expandPurchase.WhyInvalid})";
        }

        public static string GetAllPurchases => "SELECT * FROM hafifot.purchases";
        public static string GetPurchaseByPurchaseDetails(PurchaseInQueue purchaseInQueue)
        {
            string whereQuery = "";
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(purchaseInQueue.CreditCardNumber))
            {
                conditions.Add($"credit_card = '{purchaseInQueue.CreditCardNumber}'");
            }
            if (!string.IsNullOrEmpty(purchaseInQueue.Installments))
            {
                conditions.Add(purchaseInQueue.Installments == "FULL" ? "installments = 1" : $"installments = {purchaseInQueue.Installments}");
            }
            if (purchaseInQueue.TotalPrice != 0)
            {
                conditions.Add($"total_price = '{purchaseInQueue.TotalPrice}'");
            }
            if (purchaseInQueue.PurchaseDate != null)
            {
                conditions.Add($"purchase_date = '{purchaseInQueue.PurchaseDate.ToString("yyy-MM-dd")}'");
            }
            if (!char.IsWhiteSpace(purchaseInQueue.StoreID.ActivityDays))
            {
                conditions.Add($"activity_days = '{StoreIdDictionary.ActivityDays[purchaseInQueue.StoreID.ActivityDays]}'");
            }
            if (!char.IsWhiteSpace(purchaseInQueue.StoreID.StoreType))
            {
                conditions.Add($"store_type = '{StoreIdDictionary.Types[purchaseInQueue.StoreID.StoreType]}'");
            }
            if (purchaseInQueue.StoreID.StoreIdNumbers != 0)
            {
                conditions.Add($"store_id = '{purchaseInQueue.StoreID.StoreIdNumbers}'");
            }

            whereQuery = conditions[0];
            for(int i=1; i< conditions.Count; i++)
            {
                whereQuery += $" AND {conditions[i]}";
            }

            return whereQuery;
        }

        public static string GetAllPurchasesByOrderInsertionDate => "SELECT * FROM hafifot.purchases ORDER BY insertion_date DESC";

        public static string GetPurchasesByLimit(int limit)
            => $"SELECT * FROM hafifot.purchases LIMIT 0, {limit}";

        public static string GetPurchasesByCondition(string condition)
            => $"SELECT * FROM hafifot.purchases WHERE {condition}";

        public static string DeleteAllPurchases => $"DELETE FROM hafifot.purchases";
    }
}
