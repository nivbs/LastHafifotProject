using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PurchaseInQueue
    {
        public StoreID StoreID { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }
        public string Installments { get; set; }

        public PurchaseInQueue(StoreID storeID, string creditCardNumber, DateTime purchaseDate, double price, string installments)
        {
            StoreID = storeID;
            CreditCardNumber = creditCardNumber;
            PurchaseDate = purchaseDate;
            Price = price;
            Installments = installments;
        }
    }
}