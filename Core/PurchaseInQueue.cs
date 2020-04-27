using System;

namespace Core
{
    public class PurchaseInQueue
    {
        private static Random Random = new Random();
        public Store StoreID { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
        public string Installments { get; set; }

        public PurchaseInQueue(Store storeID, string creditCardNumber, DateTime purchaseDate, float price, string installments)
        {
            StoreID = storeID;
            CreditCardNumber = creditCardNumber;
            PurchaseDate = purchaseDate;
            TotalPrice = price;
            Installments = installments;
        }

        public PurchaseInQueue()
        {
            StoreID = new Store();
            CreditCardNumber = $"{GenerateCreditCardNumber.GetRandomMasterCardFakeCCNumber()}";
            PurchaseDate = new DateTime((DateTime.Now - new DateTime(((long)Random.Next(int.MaxValue)) * 100)).Ticks);
            TotalPrice = Random.Next(200000) + Random.Next(10) / (float)10;
            Installments = Random.Next((int)TotalPrice*10).ToString();
        }

        public string ToCSVString()
            => $"{StoreID.ToCSVString()},{CreditCardNumber},{PurchaseDate.ToString("yyy-MM-dd")},{TotalPrice},{Installments}";
    }
}