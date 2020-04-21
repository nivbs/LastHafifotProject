using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ExpandPurchase
    {
        public string PurchaseId { get; set; }
        public string StoreType { get; set; }
        public string StoreId { get; set; }
        public string ActivityDays { get; set; }
        public string CreditCard { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime InsertionDate { get; set; }
        public float TotalPrice { get; set; }
        public int Installments { get; set; }
        public float PricePerInstallments { get; set; }
        public bool IsValid { get; set; }
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
    }
}
