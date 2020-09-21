using System;
using System.Linq;

namespace Core
{
    public class Store
    {
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public int StoreIdNumbers { get; set; }
        private static Random Random = new Random(); 

        public Store(char storeType, char abilityDays, int storeIdNumbers)
        {
            StoreType = storeType;
            ActivityDays = abilityDays;
            StoreIdNumbers = storeIdNumbers;
        }

        public Store()
        {
            StoreType = StoreIdDictionary.Types.ToList()[Random.Next(StoreIdDictionary.Types.Count)].Key.ToString()[0];
            ActivityDays = StoreIdDictionary.ActivityDays.ToList()[Random.Next(StoreIdDictionary.ActivityDays.Count)].Key.ToString()[0];
            StoreIdNumbers = Random.Next(10000, 99999);
        }

        public Store(string storeId)
        {
            StoreType = storeId[0];
            ActivityDays = storeId[1];
            StoreIdNumbers = int.Parse(storeId.Remove(0, 2));
        }

        public string ToCSVString()
            => $"{StoreType}{ActivityDays}{StoreIdNumbers}";
        
    }
}
