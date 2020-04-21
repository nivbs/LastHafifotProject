using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PurchaseInQueue
    {
        private static Random Random = new Random();
        public StoreID StoreID { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float Price { get; set; }
        public string Installments { get; set; }

        public PurchaseInQueue(StoreID storeID, string creditCardNumber, DateTime purchaseDate, float price, string installments)
        {
            StoreID = storeID;
            CreditCardNumber = creditCardNumber;
            PurchaseDate = purchaseDate;
            Price = price;
            Installments = installments;
        }

        public PurchaseInQueue()
        {
            StoreID = new StoreID();
            CreditCardNumber = $"{Random.Next(10000000, 99999999)}{Random.Next(10000000, 99999999)}";
            PurchaseDate = new DateTime((DateTime.Now - new DateTime(((long)Random.Next(int.MaxValue)) * 100)).Ticks);
            Price = Random.Next(200000) + Random.Next(10) / (float)10;
            Installments = Random.Next((int)Price*10).ToString();
        }
    }
}