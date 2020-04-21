using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class StoreID
    {
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public int StoreIdNumbers { get; set; }
        private static Random Random = new Random(); 

        public StoreID(char storeType, char openingDays, int storeIdNumbers)
        {
            StoreType = storeType;
            ActivityDays = openingDays;
            StoreIdNumbers = storeIdNumbers;
        }

        public StoreID()
        {
            StoreType = StoreIdDictionary.Types.ToList()[Random.Next(StoreIdDictionary.Types.Count)].Key.ToString()[0];
            ActivityDays = StoreIdDictionary.OpeningDays.ToList()[Random.Next(StoreIdDictionary.OpeningDays.Count)].Key.ToString()[0];
            StoreIdNumbers = Random.Next(10000, 99999);
        }
    }
}
