using System;
using Core.Extensions;
using MySql.Data.Types;

namespace Core
{
    public class ExpandPurchase
    {
        [MySqlColName("id")]
        public string PurchaseId { get; set; }
        [MySqlColName("store_type")]
        public string StoreType { get; set; }
        [MySqlColName("store_id")]
        public string StoreId { get; set; }
        [MySqlColName("activity_days")]
        public string ActivityDays { get; set; }
        [MySqlColName("credit_card")]
        public string CreditCard { get; set; }
        [MySqlColName("purchase_date")]
        public DateTime PurchaseDate { get; set; }
        [MySqlColName("insertion_date")]
        public DateTime InsertionDate { get; set; }
        [MySqlColName("total_price")]
        public float TotalPrice { get; set; }
        [MySqlColName("installments")]
        public int Installments { get; set; }
        [MySqlColName("price_per_installments")]
        public float PricePerInstallments { get; set; }
        [MySqlColName("is_valid")]
        public bool IsValid { get; set; }
        [MySqlColName("why_invalid")]
        public string WhyInvalid { get; set; }

        public ExpandPurchase(string purchaseId, string storeType, string storeId, string activityDays, string creditCard, DateTime purchaseDate,
            DateTime insertionDate, float totalPrice, int installments, float pricePerInstallments, bool isValid, string whyInvalid)
        {
            PurchaseId = purchaseId;
            StoreType = storeType;
            StoreId = storeId;
            ActivityDays = activityDays;
            CreditCard = creditCard;
            PurchaseDate = purchaseDate;
            InsertionDate = insertionDate;
            TotalPrice = totalPrice;
            Installments = installments;
            PricePerInstallments = pricePerInstallments;
            IsValid = isValid;
            WhyInvalid = whyInvalid;
        }

        public ExpandPurchase()
        {
        }

        public bool DeepEquals(ExpandPurchase purchase)
            => PurchaseId.IsEquals(purchase.PurchaseId) && StoreType.IsEquals(purchase.StoreType) &&
                StoreId.IsEquals(purchase.StoreId) && ActivityDays.IsEquals(purchase.ActivityDays) &&
                CreditCard.IsEquals(purchase.CreditCard) && PurchaseDate.IsEquals(purchase.PurchaseDate) &&
                InsertionDate.IsEquals(purchase.InsertionDate) && TotalPrice.IsEquals(purchase.TotalPrice) &&
                Installments.IsEquals(purchase.Installments) && PricePerInstallments.IsEquals(purchase.PricePerInstallments) &&
                WhyInvalid.IsEquals(purchase.WhyInvalid) && IsValid == purchase.IsValid;
    }
}
